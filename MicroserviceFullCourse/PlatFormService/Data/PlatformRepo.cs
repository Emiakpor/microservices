using PlatFormService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatFormService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext appDbContext;

        public PlatformRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void CreatePlatform(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            appDbContext.Platforms.Add(platform);
        }

        public Platform GetPlatformById(int id)
        {
            return appDbContext.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            return appDbContext.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            return (appDbContext.SaveChanges() >= 0);
        }
    }
}
