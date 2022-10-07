using PlatFormService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatFormService.Data
{
   public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetPlatforms();

        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}
