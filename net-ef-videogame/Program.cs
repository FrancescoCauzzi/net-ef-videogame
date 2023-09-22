using net_ef_videogame.Database;
using net_ef_videogame.Models;
using static System.Console;
using System;
namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string welcomeMessage = @"Insert a command you wish to run:
            - 1: insert a new videogame 
            - 2: find a videogame by its id
            - 3: find a videogame by a string snippet matching its name
            - 4: delete a specific videogame by its id
            - 5: insert a new software house
            - 6: close the program";
            WriteLine("Welcome to our videogame manager console app!");
            Write(welcomeMessage);
            WriteLine();
            Write("Insert a command: ");
            int selectedOption = InputChecker.GetIntInput();
            WriteLine();
            while (selectedOption != 6)
            {
                switch (selectedOption)
                {
                    case 1:
                        WriteLine("Insert the data of a new videogame");
                        Write("Insert the name of the videogame: ");
                        string name = InputChecker.GetStringInput();
                        
                        Write("Insert the overview of the videogame: ");
                        string overview = InputChecker.GetStringInput();
                        Write("Insert the release dateof the videogame: ");
                        DateTime releaseDate = InputChecker.GetDateTimeInput();
                        Write("Insert the software house id: ");
                        long softwareHouseId = InputChecker.GetIntInput();
                        /*
                         * this type of instantiation gave me CS0272 error
                        Videogame newVideogame = new Videogame() { 
                            Name = name, 
                            Overview = overview, 
                            ReleaseDate = releaseDate, 
                            SoftwareHouseId = softwareHouseId
                        };
                        */

                        Videogame newVideogame = new Videogame( name, overview, releaseDate, softwareHouseId);


                        using (VideogamesContext db = new VideogamesContext())
                        {
                            try {
                                db.Add(newVideogame);
                                db.SaveChanges();
                                WriteLine("The videogame has been added");
                            }
                            catch (Exception ex) {
                                WriteLine("There has been a problem in adding the videogame: " + ex.Message);
                            }
                            
                        }

                        break;
                        

                    case 2:
                        Write("Insert the id of the videogame you are looking for: ");
                        long videogameId = InputChecker.GetIntInput();
                        // LINQ method syntax
                        //search videogame by its id
                        using (VideogamesContext db = new VideogamesContext())
                        {
                            try
                            {
                                //WriteLine("The videogame has been added");
                                Videogame vgById = db.Videogames.Where(videogame => videogame.Id == videogameId).FirstOrDefault();
                                WriteLine(vgById);

                            }
                            catch (Exception ex)
                            {
                                WriteLine("There has been a problem in adding the videogame: " + ex.Message);
                            }

                        }
                        
                        


                        break;

                    case 3:
                        Write("Insert the snippet of the name of the videogame you are looking for: ");
                        string videogameSnippet = InputChecker.GetStringInput();
                        

                        break;

                    case 4:
                        Write("Insert the id of the videogame you want to delete: ");
                        long idVideogameToDelete = InputChecker.GetIntInput();
                        

                        break;
                    case 5:
                        // insert a new software house
                        WriteLine("Insert the data of the new software house: ");
                        Write("Insert the name of the software house: ");
                        string shName = InputChecker.GetStringInput();

                        Write("Insert the tax-id of the software house: ");
                        string shTaxId = InputChecker.GetStringInput();
                        Write("Insert the city of the software house: ");
                        string shCity = InputChecker.GetStringInput();
                        Write("Insert the country of the software house: ");
                        string shCountry = InputChecker.GetStringInput();
                        
                        SoftwareHouse newSoftwareHouse = new SoftwareHouse()
                        {
                            SoftwareHouseName = shName,
                            SoftwareHouseTaxId = shTaxId,
                            SoftwareHouseCity = shCity,
                            SoftwareHouseCountry = shCountry
                        };

                       
                        using (VideogamesContext db = new VideogamesContext())
                        {
                            try
                            {
                                db.Add(newSoftwareHouse);
                                db.SaveChanges();
                                WriteLine("The software house has been added");
                            }
                            catch (Exception ex)
                            {
                                WriteLine("There has been a problem in adding the software house: " + ex.Message);
                            }

                        }

                        break;

                    default:
                        WriteLine("Invalid option");
                        break;

                }
                WriteLine();
                WriteLine("What do you want to do now?");
                WriteLine(welcomeMessage);
                Write("Insert a command: ");
                selectedOption = InputChecker.GetIntInput();
                WriteLine();
            }

        }
    }
}