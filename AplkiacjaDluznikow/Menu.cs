using System;
using System.IO;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace AplkiacjaDluznikow
{
    class Menu
    {
        public dManager manager { get; set; }

        public Menu()
        {
            manager = new dManager();
        }
        public void LoopMenu()
        {
            Console.WriteLine("Witaj w aplikacji 'Mój dłużnik'.");
            Console.WriteLine("Aby przejść dalej wybierz opcję z menu poniżej wpisując odpowiedni numer:");
            Console.WriteLine("");
            Console.WriteLine("0 - Pokaż listę dłużników.");
            Console.WriteLine("1 - Dodaj nowego dłużnika.");
            Console.WriteLine("2 - Usuń dłużnika z listy.");
            Console.WriteLine("3 - Modyfikuj już istniejącego dłużnika.");
            Console.WriteLine("4 - Wyjdź z programu.");
            Console.WriteLine("");
            if (int.TryParse(Console.ReadLine(), out var choose) && choose>=0 && choose<=4)
            {
                MakeDecision(choose);

            }
            else
            {
                Console.WriteLine("Wpisana opcja nie istnieje. Proszę wpisać ponownie");
                Thread.Sleep(3000);
                Console.Clear();
            };






            
            LoopMenu();
        }

        public void MakeDecision(int decision)
        {


            if (File.Exists(manager.FilePath))
            {
                switch (decision)
                {

                    case 0:
                        {
                            manager.Show();
                        }
                        break;
                    case 1:
                        {
                            manager.Add();
                        }
                        break;
                    case 2:
                        {
                            manager.Delete();
                        }
                        break;
                    case 3:
                        {
                            manager.Modify();
                            
                        }
                        break;
                    case 4:
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Błąd! brak pliku listy dłużników.\nCzy chcesz go teraz stworzyć?[y/n]:");
                if (Console.ReadLine() == "y")
                {
                    manager.CreateList();
                }
                else
                {
                    return;
                };
            }
            

        }
       
    }
}
