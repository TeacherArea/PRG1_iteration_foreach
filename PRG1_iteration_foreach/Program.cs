using System;

namespace PRG1_iteration_foreach
{
    internal class Students
    {
        public string _FirstName;
        public string _LastName;
        public int _Age;
    }
    internal class Program
    {
        static List<Students> studentList;
        static void Main(string[] args)
        {
            bool run = true;
            int userChoice = 0;
            while (run)
            {
                Console.WriteLine(
                    "Välj ur menyn:\n\t" +
                    "1. Använd lista på tre studenter\n\t" +
                    "2. Lägg till en student\n\t" +
                    "3. Visa lista över studenter\n\t" +
                    "4. Sök efter efternamn\n\t" +
                    "5. Ta bort en person\n\t" +
                    "0. Avsluta");
                userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        SomeStudentsPreset();
                        break;
                    case 2:
                        AskUserToAddStudent();
                        break;
                    case 3:
                        ShowList();
                        break;
                    case 4:
                        SerachStudent();
                        break;
                    case 5:
                        DeleteStudent();
                        break;
                    case 0:
                        run = false;
                       break;
                }
            }
            Console.WriteLine("\n\tBye bye ...");
        }
        static private void SomeStudentsPreset()
        {
            // ett sätt att fylla en lista
            studentList = new List<Students>()
            {
                new Students { _FirstName = "Anna", _LastName = "Andersson", _Age = 17},
                new Students { _FirstName = "Bengt", _LastName = "Bengtsson", _Age = 59 },
                new Students { _FirstName = "Caecar", _LastName = "Ceacar", _Age = 38 },
            };
        }
        static private void AskUserToAddStudent()
        {
            if(studentList == null)
            {
                studentList = new List<Students>();
            }
            // ett bättre sätt kan vara att fråga användaren
            Students student = new Students();

            Console.Write("Förnamn: ");
            student._FirstName = Console.ReadLine();
            Console.Write("Efternamn: ");
            student._LastName = Console.ReadLine();
            Console.Write("Ålder: ");
            student._Age = int.Parse(Console.ReadLine());
            studentList.Add(student);

        }
        static private void ShowList()
        {
            foreach(Students item in studentList)
            {
                Console.WriteLine("Student: " + item._FirstName + " " + item._LastName + " Ålder: " + item._Age);
            }
        }

        static private void DeleteStudent()
        {

        }

        private static void SerachStudent()
        {

        }
    }
}