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
            - 6: get all the videogames of a specific software house
            - 7: close the program";
            WriteLine("Welcome to our videogame manager console app!");
            Write(welcomeMessage);
            WriteLine();
            Write("Insert a command: ");
            int selectedOption = InputChecker.GetIntInput();
            WriteLine();
            while (selectedOption != 7)
            {
                switch (selectedOption)
                {
                    case 1:
                        WriteLine("Insert the data of a new videogame");
                        Write("Insert the name of the videogame: ");
                        string name = InputChecker.GetStringInput();
                        Write("Insert the overview of the videogame: ");
                        string overview = InputChecker.GetStringInput();
                        Write("Insert the release date of the videogame: ");
                        DateTime releaseDate = InputChecker.GetDateTimeInput();
                        try
                        {
                            List<SoftwareHouse> shList = VideogameManager.GetAllSoftwareHouses();
                            WriteLine("Insert the software house id: ");
                            WriteLine("The software house available are: ");
                            foreach (SoftwareHouse sh in shList)
                            {
                                WriteLine($"{sh.SoftwareHouseId}. {sh}");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLine(ex.Message);
                        }
                        long softwareHouseId = InputChecker.GetIntInput();

                        try
                        {
                            bool isVideogameInserted = VideogameManager.InsertVideogame(name, overview, releaseDate, softwareHouseId);
                            if (isVideogameInserted)
                            {
                                WriteLine("The videogame has been added");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        Write("Insert the id of the videogame you are looking for: ");
                        long videogameId = InputChecker.GetIntInput();
                        try
                        {
                            Videogame videogame = VideogameManager.GetVideoGameByItsId(videogameId);
                            WriteLine("We have found the following videogame: ");
                            WriteLine(videogame.ToString());
                        }
                        catch (Exception ex)
                        {
                            WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        Write("Insert the snippet of the name of the videogame you are looking for: ");
                        string videogameSnippet = InputChecker.GetStringInput();
                        try
                        {
                            List<Videogame> videogameList = VideogameManager.GetAllVideoGamesByStringSnippet(videogameSnippet);
                            if (videogameList.Count == 0)
                            {
                                WriteLine("No videogames found.");
                            }
                            else
                            {
                                WriteLine("We have found the following videogames: ");
                                foreach (Videogame videogame in videogameList)
                                {
                                    WriteLine(videogame.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        Write("Insert the id of the videogame you want to delete: ");
                        long idVideogameToDelete = InputChecker.GetIntInput();
                        try
                        {
                            bool isDeleted = VideogameManager.DeleteAVideogame(idVideogameToDelete);
                        }
                        catch (Exception ex)
                        {
                            WriteLine(ex.Message);
                        }
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
                        try
                        {
                            bool isSHInserted = VideogameManager.InsertASoftwareHouse(shName, shTaxId, shCity, shCountry);
                            if (isSHInserted)
                            {
                                WriteLine("The software house has been added");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLine(ex.Message);
                        }
                        break;
                    case 6:
                        try
                        {
                            List<SoftwareHouse> shList = VideogameManager.GetAllSoftwareHouses();
                            if (shList.Count > 0)
                            {
                                WriteLine("Here are all the software houses in our db with the associated id");
                                foreach (SoftwareHouse sh in shList)
                                {
                                    WriteLine($"{sh.SoftwareHouseId}. {sh}");
                                }
                                Write("Select a software house by its id you wish to see its games: ");
                                long shIdSelected = InputChecker.GetIntInput();
                                try
                                {
                                    List<Videogame> gameList = VideogameManager.GetVideoGameListBySHId(shIdSelected);
                                    if (gameList.Count > 0)
                                    {
                                        foreach (Videogame game in gameList)
                                        {
                                            WriteLine($"{game}");
                                        }
                                    }
                                    else
                                    {
                                        WriteLine("There are no videogames available for this software house");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                WriteLine("There are no software houses available in our database");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLine(ex.Message);
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