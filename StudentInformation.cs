using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB4_Student_Information
{
    class StudentInformation
    {

        private string[] names;
        private string[] foods;
        private string[] titles;

        private string[] foodInputs;
        private string[] titleInputs;
        private string[] bothInputs;

        private int selectedStudent;
        private const int CLASS_SIZE = 14;

        private enum Selection
        {
            Food = 1,
            Title,
            Both
        }

        public StudentInformation()
        {
            names = new string[CLASS_SIZE] { "Chuck Allen", "Adam Gerecke", "Tyler Satkowiak", "Zach Scholts", "Kathryn Pidek", 
                "Dave Gedert", "Eugene Hill", "David Heizer", "James Nofs", "Aaron Rudzki", "Adam Gerecke", "Brendan Burch", "Manny Salazar", "Eric Slutz" };

            foods = new string[CLASS_SIZE] { "Reese's", "Milky Way Simply Caramel", "Reese's Fast Break", "All Reese's", "M&M's", 
                "Snickers", "Kit Kat", "Combos", "Hershey's", "Candy Sticks", "Laffy Taffy", "Fudge", "Kit Kat", "Snickers" };

            titles = new string[CLASS_SIZE] { "Resolution Analyst", "Desktop Support Technician", "Government Insuring Specialist", "Desktop Support Technician", 
                "Desktop Support Technician", "Desktop Support Technician", "Desktop Support Technician", "Desktop Support Technician", "Desktop Support Technician", 
                "Desktop Support Technician", "Desktop Support Technician", "Desktop Support Technician", "Desktop Support Technician", "Desktop Support Technician" };

            foodInputs = new string[] { "FAVORITE CANDY", "CANDY", "FAV", "FAVORITE", "FOOD", "F", "C", "1" };
            titleInputs = new string[] { "PREVIOUS TITLE", "TITLE", "PREVIOUS", "PREV", "JOB", "P", "T", "2" };
            bothInputs = new string[] { "BOTH", "B", "ALL", "A", "3" };
        }

        public void Start()
        {
            bool showAgain;

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to our class! Which student would you like to learn more about?");
                GetStudentChoice();

                Console.WriteLine($"\nStudent {selectedStudent+1} is {names[selectedStudent]}. What would you like to know about {names[selectedStudent].Split(" ")[0]}?");
                
                switch (GetDataChoice())
                {
                    case Selection.Food:
                        Console.WriteLine($"{names[selectedStudent].Split(" ")[0]}'s favorite candy is {foods[selectedStudent]}.");
                        break;
                    case Selection.Title:
                        Console.WriteLine($"{names[selectedStudent].Split(" ")[0]}'s previous title was {titles[selectedStudent]}.");
                        break;
                    case Selection.Both:
                        Console.WriteLine($"{names[selectedStudent].Split(" ")[0]}'s favorite candy is {foods[selectedStudent]} and previous title was {titles[selectedStudent]}.");
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                Console.WriteLine();
                showAgain = RunAgain();
            } while (showAgain);
        }

        private void GetStudentChoice()
        {
            Console.Write($"Enter \"(S)how All\" or a number 1-{names.Length}: ");
            string input = Console.ReadLine().ToUpper().Trim();
            while (!int.TryParse(input, out selectedStudent) || (selectedStudent < 1 || selectedStudent > names.Length))
            {
                if (input == "SHOW ALL" || input == "S" || input == "SHOW")
                {
                    Console.WriteLine("The students are:");
                    for(int index = 0; index < names.Length; index++)
                    {
                        Console.WriteLine($"{index+1}. {names[index]}");
                    }
                    Console.Write($"Enter \"(S)how All\" or a number 1-{names.Length}: ");
                }
                else
                {
                    Console.Write($"\nThat student does not exist. Please try again. \nEnter \"(S)how All\" or a number, 1-{names.Length}: ");
                }
                input = Console.ReadLine().ToUpper().Trim();
            }
            selectedStudent--; //sets it to the index of the student.
        }

        private Selection GetDataChoice()
        {
            Console.Write("Enter \"Favorite Candy\" or \"Previous Title\" or \"Both\": ");
            string userChoice = Console.ReadLine().ToUpper().Trim();
            while (!foodInputs.Contains(userChoice) && !titleInputs.Contains(userChoice) && !bothInputs.Contains(userChoice))
            {
                Console.Write("\n\nThat data does not exist. Please try again. \nEnter \"Favorite Candy\" or \"Previous Title\" or \"Both\": ");
                userChoice = Console.ReadLine().ToUpper().Trim(); ;
            }

            Console.WriteLine();

            if (foodInputs.Contains(userChoice))
            {
                return Selection.Food;
            }
            else if (titleInputs.Contains(userChoice))
            {
                return Selection.Title;
            }
            else
            {
                return Selection.Both;
            }
        }

        private bool RunAgain()
        {
            Console.Write("Would you like to know about another student? (enter \"yes\" or \"no\"): ");
            string choice = Console.ReadLine().ToUpper().Trim();

            while (!((choice == "YES") || (choice =="NO") || (choice == "Y") || (choice == "N") || (choice == "1") || (choice == "2")))
            {
                Console.Write("That was not a valid option. Enter \"yes\" or \"no\"): ");
                choice = Console.ReadLine().ToUpper().Trim();
            }

            Console.WriteLine();

            if(choice == "YES" || choice == "Y" || choice == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
