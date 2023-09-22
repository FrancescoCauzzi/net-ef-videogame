using net_ef_videogame.Database;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public static class VideogameManager
    {
        public static List<Videogame> GetVideoGameListBySHId(int shId)
        {
            using (VideogamesContext db = new VideogamesContext())
            {
                List<Videogame> videogamesBySHId = db.Videogames.Where(v => v.SoftwareHouseId == shId).ToList();
                 return videogamesBySHId;

            }



        }

        public static List<SoftwareHouse> GetAllSoftwareHouses()
        {
            using (VideogamesContext db = new VideogamesContext())
            {
                List<SoftwareHouse> allSoftwareHouses = db.SoftwareHouse.ToList();
                return allSoftwareHouses;
            }

        }
    }
}
