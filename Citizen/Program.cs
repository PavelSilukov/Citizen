using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "-----Citizen's journal-----";
            Console.WriteLine("-----Citizen's  journal-----\n");
            Queue instance = new Queue();
            
            while (true)
            {
                
                Console.WriteLine("Choose action:");
                Console.WriteLine("1 - Add Citizen");
                Console.WriteLine("2 - Remove First Citizen");
                Console.WriteLine("3 - Remove Citizen By Name");
                Console.WriteLine("4 - Contains Citizen by Passport");
                Console.WriteLine("5 - Return Last Citizen");
                Console.WriteLine("6 - Show All List");
                Console.WriteLine("7 - Quit");
                Console.WriteLine();
                int sign = 0;
                try
                {
                    sign = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    sign = 0;
                }

                switch (sign)
                {
                    case 1:
                        Console.Write("Enter name of Citizen:\n");
                        string name = Console.ReadLine();
                        Console.Write("Enter age of Citizen:\n");
                        int age = 0;
                        bool ageSuccess = Int32.TryParse(Console.ReadLine(), out age);
                        if (ageSuccess)
                        {
                        }
                        else
                        {
                            Console.WriteLine("You entered invalid character!");
                            Console.WriteLine("Enter any key for continue . . . ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        Console.Write("Enter number of passport:\n");
                        int passport = 0;
                        bool passportSuccess = Int32.TryParse(Console.ReadLine(), out passport);
                        if (passportSuccess)
                        {
                        }
                        else
                        {
                            Console.WriteLine("You entered invalid character!");
                            Console.WriteLine("Enter any key for continue . . . ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        
                        if (age < 24)
                        {
                            Student student = new Student(name, passport, age);
                            instance.Add(student);
                        }
                        else if (age >= 24 && age < 65)
                        {
                            Worker worker = new Worker(name, passport, age);
                            instance.Add(worker);
                        }
                        else
                        {
                            Retiree retiree = new Retiree(name, passport, age);
                            instance.Add(retiree);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter any key for continue . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        instance.RemoveFirst();
                        Console.WriteLine();
                        Console.WriteLine("Enter any key for continue . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("Enter the Name of Citizen");
                        string nameForRemove = Console.ReadLine();
                        instance.Remove(nameForRemove);
                        Console.WriteLine();
                        Console.WriteLine("Enter any key for continue . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("Enter number of passport for Cheking");
                        int numberOfPassport = 0;
                        bool successByPassport = Int32.TryParse(Console.ReadLine(), out numberOfPassport);
                        if (successByPassport)
                        { }
                        else
                        {
                            Console.WriteLine("You entered invalid character!");
                            Console.WriteLine("Enter any key for continue . . . ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        int numberOfCitizen = instance.Contains(numberOfPassport);
                        if (numberOfCitizen == -1)
                        {
                            Console.WriteLine("There is no citizen with this Passport");
                        }
                        else
                        {
                            Console.WriteLine("The Citizen under the number {0}", numberOfCitizen);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter any key for continue . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        Node citizen = new Node();
                        citizen = instance.ReturnLast();
                        if (citizen == null)
                        {
                            Console.WriteLine("The Queue is empty");
                        }
                        else
                        {
                            Console.WriteLine("The Last Citizen is {0}, number is {1}", citizen.Citizen.Name, citizen.Index);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter any key for continue . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                            foreach (Citizen man in instance)
                            {
                                Console.WriteLine("Name - {0},\t\t Age - {1}, Passport - \t{2}", man.Name, man.Age, man.Passport);
                            }
                        Console.WriteLine();
                        Console.WriteLine("Enter any key for continue . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("You entered invalid character!");
                        Console.WriteLine("Enter any key for continue . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }               
            }
        }
    }
}
