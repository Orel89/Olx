using OlxCore.Enums;

namespace OlxWebAPI.Helpers
{
    public class DefaultAuthorization
    {
        #region default user 

        public const string default_customer_name = "Customer";

        public const string default_customer_password = "Oleksii1989!";
        public const Roles default_customer_role = Roles.Customer;

        public const string dafault_customer_email = "oleksiiorel@gmail.com";

        #endregion

        #region default administrator

        public const string default_administrator_name = "Admin";

        public const string default_administrator_password = "Oleksii1989!";
        public const Roles default_administrator_role = Roles.Admin;

        public const string dafault_administrator_email = "oleksiiorel@gmail.com";

        #endregion
    }
}
