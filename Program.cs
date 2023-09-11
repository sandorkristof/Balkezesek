using Balkezesek;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
class Program
{
    static void Main()
    {
       
        
        //2.feladat
        List<Dictionary<string, string>> adatok = new List<Dictionary<string, string>>();
        string csvFile = "balkezesek.csv";
        int rowCount = CsvSorok(csvFile);
        Console.WriteLine($"A balkezesek.csv fájl {rowCount} adatsorból áll.");
      //  Console.Write(_4feladat);
        List<Player> players = ReadCsvFile(csvFile);

        // Szűrjük azokat a játékosokat, akik utoljára 1999 októberében léptek pályára
        var filteredPlayers = players.Where(player => player.LastGameDate.Month == 10 && player.LastGameDate.Year == 1999);

        // Átváltjuk az inch-ben megadott magasságot centiméterbe
        foreach (var player in filteredPlayers)
        {
            player.HeightCm = player.HeightInches * 2.54;
        }

        // Kiírjuk a nevet és a magasságot
        Console.WriteLine("Azok a játékosok, akik utoljára 1999 októberében léptek pályára:");

        foreach (var player in filteredPlayers)
        {
            Console.WriteLine($"{player.Name}: {player.HeightCm:F1} cm");
        }




        if (File.Exists(csvFile))
        {
            string[] sorok = File.ReadAllLines(csvFile);

            if (sorok.Length > 0)
            {
                string[] fejlec = sorok[0].Split(',');

                for (int i = 1; i < sorok.Length; i++)
                {
                    string[] adatSor = sorok[i].Split(',');
                    Dictionary<string, string> adatSorDict = new Dictionary<string, string>();

                    for (int j = 0; j < fejlec.Length; j++)
                    {
                        if (j < adatSor.Length)
                        {
                            adatSorDict[fejlec[j]] = adatSor[j];
                        }
                        else
                        {
                            adatSorDict[fejlec[j]] = string.Empty;
                        }
                    }

                    adatok.Add(adatSorDict);
                }
            }
            else
            {
                Console.WriteLine("Az állomány üres.");
            }
        }
        else
        {
            Console.WriteLine("Az állomány nem található.");
        }

        if (adatok.Count > 0)
        {
            Dictionary<string, string> elsoSor = adatok[0];
            foreach (var kvp in elsoSor)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
        else
        {
            Console.WriteLine("Nincsenek adatok.");
        }


    }

    //3.Feladat
    static int CsvSorok(string csvFile)
    {
        int rowCount = 0;

        try
        {
            using (StreamReader sr = new StreamReader(csvFile))
            {
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    rowCount++;
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Hiba történt a fájl olvasása során: {e.Message}");
        }

        return rowCount;
    }
    //4.feladat
    static List<Player> ReadCsvFile(string filePath)
    {
        List<Player> players = new List<Player>();

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        string name = parts[0];
                        DateTime lastGameDate = DateTime.ParseExact(parts[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        double heightInches = double.Parse(parts[2], CultureInfo.InvariantCulture);
                        players.Add(new Player(name, lastGameDate, heightInches));
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Hiba történt a fájl olvasása során: {e.Message}");
        }

        return players;
    }


    class Player
    {
        public string Name { get; set; }
        public DateTime LastGameDate { get; set; }
        public double HeightInches { get; set; }
        public double HeightCm { get; set; }

        public Player(string name, DateTime lastGameDate, double heightInches)
        {
            Name = name;
            LastGameDate = lastGameDate;
            HeightInches = heightInches;
        }
    }
    //5.feladat
   

}


