using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OlxCore.Enums;
using OlxCore.Interfaces.Configuration;
using OlxInfrastructure.Data;
using OlxInfrastructure.Identity;
using OlxWebAPI.Helpers.MockGenerator;
using System.Security.Cryptography;

namespace OlxWebAPI.Helpers
{
    public class DataSeeder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DataSeeder(
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedApplicationDbAsync()
        {
            try
            {
                await SeedDefaultUserIdentitiesAsync();

                EntityGenerator.InitializeMock();

                await _unitOfWork.CategoryRepository.AddRangeAsync(EntityGenerator._categories);
                await _unitOfWork.CategoryRepository.AddRangeAsync(EntityGenerator._);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async Task SeedDefaultUserIdentitiesAsync()
        {
            #region -- User Roles --

            if (await _roleManager.FindByNameAsync(Roles.Admin.ToString()) is null
                && await _roleManager.FindByNameAsync(Roles.Customer.ToString()) is null)
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await _roleManager.CreateAsync(new IdentityRole(Roles.Customer.ToString()));
            }

            #endregion

            #region -- User --

            if (!await _userManager.Users.AnyAsync())
            {
                var defaultAdmin = new ApplicationUser
                {
                    UserName = DefaultAuthorization.default_administrator_name,
                    Email = DefaultAuthorization.dafault_administrator_email,
                };

                var createAdminIdentityResult = await _userManager.CreateAsync(defaultAdmin, DefaultAuthorization.default_administrator_password);

                if (createAdminIdentityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(defaultAdmin, DefaultAuthorization.default_administrator_role.ToString());
                }
                var defaultCustomer = new ApplicationUser
                {
                    UserName = DefaultAuthorization.default_customer_name,
                    Email = DefaultAuthorization.dafault_customer_email,
                };

                var createCustomerIdentityResult = await _userManager.CreateAsync(defaultCustomer, DefaultAuthorization.default_customer_password);

                if (createCustomerIdentityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(defaultCustomer, DefaultAuthorization.default_customer_role.ToString());
                }
            }

            #endregion
        }
    }
}
