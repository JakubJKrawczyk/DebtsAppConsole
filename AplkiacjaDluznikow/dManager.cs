using System;
using System.IO;

namespace AplkiacjaDluznikow
{

    
    public class dManager
    {
        public string FilePath { get; set; }
        public dManager()
        {
            FilePath = "dluznicy.txt";
        }
        public void Show()
        {
            var i = 1;
            
          
                
                foreach (string line in File.ReadAllLines(FilePath))
                {
                    var listOfWords = line.Split(" ");
                Console.WriteLine("\nDłużnik nr." + i);
                Console.ForegroundColor = ConsoleColor.Blue;
                
                Console.WriteLine("Imię: " + listOfWords[0]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dług: " + listOfWords[1]);
                Console.ForegroundColor = ConsoleColor.White;
                i += 1;
                }
            
        }
        public void CreateList()
        {
            File.Create("dluznicy.txt").Close(); ;

        }
        public void Add()
        {

            
            Console.WriteLine("\n\nPodaj imię dłużnika:");
            var name = Console.ReadLine().Trim();
            Console.WriteLine("Podaj kwotę zadłużenia:");
            var price = Console.ReadLine().Trim();
            
            File.AppendAllText(FilePath,name + " " + price + "zl");
            File.AppendAllText(FilePath, "\n");

        }
        public void Delete()
        {
            Console.WriteLine("Podaj imię dłużnika, którego chcesz usunąć z listy dłużników: ");

            var NameToDelete = Console.ReadLine();
            var IsDeleted = false;
            File.Create("DluznicyKopia.txt").Close();
            foreach (string line in File.ReadAllLines(FilePath))
            {
                var ListOfWords = line.Split(" ");
                if (ListOfWords[0] == NameToDelete)
                {
                    IsDeleted = true;
                    continue;

                }
                else
                {
                    File.AppendAllText("DluznicyKopia.txt", ListOfWords[0] + " " + ListOfWords[1] + "\n");

                }
                
            
            }
            if (!IsDeleted)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dłużnik, którego próbujesz usunąć nie znajduje się na liście lub źle podałeś jego imie!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            File.Delete(FilePath);
            File.Copy("DluznicyKopia.txt", FilePath);
            File.Delete("DluznicyKopia.txt");
            

        }
        public void Modify()
        {
            var path = "dluznicykopia.txt";
            Console.WriteLine("Podaj imię dłużnika, którego chcesz edytować: ");
            var nameToEdit = Console.ReadLine();
            Console.WriteLine("Podaj nową wartość długu: ");
            if (int.TryParse(Console.ReadLine(), out var NewDebet))
            {
                var IsEdited = false;
                File.Create(path).Close();

                foreach (var line in File.ReadAllLines(FilePath))
                {
                    var ListOfWords = line.Split(" ");
                    if (ListOfWords[0] == nameToEdit)
                    {
                        File.AppendAllText(path, ListOfWords[0] + " " + NewDebet.ToString() + "zl\n");
                        IsEdited = true;
                    }
                    else
                    {
                        File.AppendAllText(path, ListOfWords[0] + " " + ListOfWords[1] + "\n");
                    }
                }

                if (!IsEdited)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dłużnik, którego próbujesz usunąć nie znajduje się na liście lub źle podałeś jego imie!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                File.Delete(FilePath);
                File.Copy("DluznicyKopia.txt", FilePath);
                File.Delete("DluznicyKopia.txt");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nowa podana wartość jest niepoprawna. Nowy dług musi być liczbą całkowitą!");
                Console.ForegroundColor = ConsoleColor.White;
            };
            
           
        }


    }
}
