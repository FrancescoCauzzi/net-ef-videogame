using Microsoft.EntityFrameworkCore.Infrastructure;
using net_ef_videogame.Database;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace net_ef_videogame
{
    public static class VideogameManager
    {
        public static bool InsertVideogame(string name, string overview, DateTime releaseDate, long softwareHouseId)
        {
            bool isVideogameInserted = false;
            Videogame newVideogame = new Videogame(name, overview, releaseDate, softwareHouseId);

            using (VideogamesContext db = new VideogamesContext())
            {
                try
                {
                    db.Add(newVideogame);
                    db.SaveChanges();
                    isVideogameInserted = true;
                }
                catch (Exception ex)
                {
                    throw new Exception($"There has been a problem in adding the videogame: {ex.Message}");
                }
            }
            return isVideogameInserted;
        }

        public static Videogame GetVideoGameByItsId(long videogameId)
        {
            using (VideogamesContext db = new VideogamesContext())
            {
                try
                {
                    //WriteLine("The videogame has been added");
                    Videogame vgById = db.Videogames.Where(videogame => videogame.Id == videogameId).First();

                    return vgById;
                }
                catch (Exception ex)
                {
                    throw new Exception("There has been a problem in getting the videogame: " + ex.Message);
                }
            }
        }

        public static List<Videogame> GetAllVideoGamesByStringSnippet(string snippet)
        {
            List<Videogame> videogamesByName = new();
            try
            {
                using (VideogamesContext db = new VideogamesContext())
                {
                    // Use LINQ to query the database for videogames that contain the snippet in their name
                    videogamesByName = db.Videogames.Where(v => v.Name.Contains(snippet)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There has been a problem in getting the videogames: " + ex.Message);

            }
            return videogamesByName;
        }

        public static bool DeleteAVideogame(long vGId)
        {
            bool isDeleted = false;
            try
            {
                using (VideogamesContext db = new VideogamesContext())
                {

                    // Find the videogame by its ID
                    Videogame videogameToDelete = db.Videogames.First(v => v.Id == vGId);

                    // Remove the videogame from the DbContext
                    db.Videogames.Remove(videogameToDelete);

                    // Save changes to the database
                    db.SaveChanges();
                    isDeleted = true;

                    WriteLine("The videogame has been deleted.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There has bee a problem in deleting the videogame: " + ex.Message);
            }
            return isDeleted;
        }

        public static bool InsertASoftwareHouse(string shName, string shTaxId, string shCity, string shCountry)
        {
            bool isSHInserted = false;
            SoftwareHouse newSoftwareHouse = new SoftwareHouse()
            {
                SoftwareHouseName = shName,
                SoftwareHouseTaxId = shTaxId,
                SoftwareHouseCity = shCity,
                SoftwareHouseCountry = shCountry
            };
            try
            {
                using (VideogamesContext db = new VideogamesContext())
                {
                    db.Add(newSoftwareHouse);
                    db.SaveChanges();
                    isSHInserted = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There has been a problem in inserting the software house: " + ex.Message);
            }
            return isSHInserted;
        }
        public static List<Videogame> GetVideoGameListBySHId(long shId)
        {
            try
            {
                using (VideogamesContext db = new VideogamesContext())
                {
                    List<Videogame> videogamesBySHId = db.Videogames.Where(v => v.SoftwareHouseId == shId).ToList();
                    return videogamesBySHId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured: " + ex.Message);
            }
        }

        public static List<SoftwareHouse> GetAllSoftwareHouses()
        {
            try
            {
                using (VideogamesContext db = new VideogamesContext())
                {
                    List<SoftwareHouse> allSoftwareHouses = db.SoftwareHouse.ToList();
                    return allSoftwareHouses;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured: " + ex.Message);
            }
        }
    }
}
