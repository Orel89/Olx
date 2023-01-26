using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OlxCore.Entities;
using OlxCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxInfrastructure.Data
{
    public class AnnouncementRepository : GenericRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<Announcement>> AllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} AllAsync function error", typeof(AnnouncementRepository));
                return new List<Announcement>();
            }
        }
        public override async Task<bool> UpdateAsync(Announcement announcemen)
        {
            try
            {
                var existingAnnouncement = await dbSet.Where(x => x.Id == announcemen.Id)
                                                    .FirstOrDefaultAsync();

                if (existingAnnouncement == null)
                    return await AddAsync(announcemen);

                existingAnnouncement = announcemen;


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(AnnouncementRepository));
                return false;
            }
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(AnnouncementRepository));
                return false;
            }
        }
    }
}
