using System;
using System.ComponentModel.Design;

namespace PRG1_iteration_foreach
{
    internal class Students
    {
        public string firstName;
        public string lastName;
        public int age;
    }
    internal class Program
    {
        static List<Students> studentList = new List<Students>();
        static void Main(string[] args)
        {
            bool run = true;
            int userChoice = 0;
            while (run)
            {
                Console.WriteLine(
                    "\nVälj ur menyn:\n\t" +
                    "1. Använd lista på tre studenter\n\t" +
                    "2. Lägg till en student\n\t" +
                    "3. Visa lista över studenter\n\t" +
                    "4. Sök efter efternamn\n\t" +
                    "5. Ändra någons ålder\n\t" +
                    "6. Ta bort en person\n\t" +
                    "7. BubbleSort av en random array\n\t" +
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
                        ChangeStudentAge();
                        break;
                    case 6:
                        DeleteStudent();
                        break;
                    case 7: SortArray();
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
            studentList.Add(new Students { firstName = "Anna", lastName = "Andersson", age = 17 });
            studentList.Add(new Students { firstName = "Bengt", lastName = "Bengtsson", age = 59 });
            studentList.Add(new Students { firstName = "Caecar", lastName = "Svensson", age = 38 });
            Console.WriteLine("Tre studenter lades till");
        }
        static private void AskUserToAddStudent()
        {
            Students student = new Students();

            Console.Write("Förnamn: ");
            student.firstName = Console.ReadLine();
            Console.Write("Efternamn: ");
            student.lastName = Console.ReadLine();
            Console.Write("Ålder: ");
            student.age = int.Parse(Console.ReadLine());
            studentList.Add(student);

        }
        static private void ShowList()
        {
            foreach (Students item in studentList)
            {
                Console.WriteLine("Student: " + item.firstName + " " + item.lastName + ", ålder: " + item.age);
            }
        }

        static private void DeleteStudent()
        {
            Console.Write("Ta bort vilken student (efternamn)? ");
            string seached = Console.ReadLine();

            if (studentList == null)
            {
                Console.WriteLine("Det finns ingen lista. Lägg till några studenter först.\n\t");
                return;
            }
       
            foreach (Students item in studentList)
            {
                if (item.lastName.Equals(seached, StringComparison.OrdinalIgnoreCase))
                {
                    /* Notera två saker här:
                      1) om du skriver item.lastName och sen en punkt, så ser du många möjliga metoder
                         använda på en sträng; inklusive Equals.
                      2) att RemoveAll med item => item.lastName.Equals() använder en lambdafunktion
                    */
                    studentList.RemoveAll(item => item.lastName.Equals(seached, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine($"{seached} är borttagen.");
                    break;
                }
                else
                {
                    Console.WriteLine($"Ingen med namnet {seached} finns i listan.");
                }
            }
        }

        private static void ChangeStudentAge()
        {
            Console.Write("Vems ålder vill du ändra? Efternamn: ");
            string lastName = Console.ReadLine();
            Console.Write("Vad är den nya åldern (heltal)? ");
            int age = int.Parse(Console.ReadLine());
            foreach (Students item in studentList)
            {
                if (item.lastName == lastName)
                {
                    item.age = age;
                    break;
                }
                else
                {
                    Console.WriteLine("Det verkar inte finnas en person med det namnet i listan.");
                }
            }
        }

        private static void SerachStudent()
        {
            Console.Write("Sök efter vilken student (efternamn)? ");
            string seached = Console.ReadLine();

            List<Students> foundList = new List<Students>();

            foreach (Students item in studentList)
            {
                if (item.lastName.Equals(seached, StringComparison.OrdinalIgnoreCase))
                {
                    foundList.Add(item);
                }
            }

            if (foundList.Count == 0)
            {
                Console.WriteLine("Ingen hittades med det namnet.");
            }
            else
            {
                foreach (Students item in foundList)
                {
                    Console.WriteLine($"I lista: {item.firstName} {item.lastName}");
                }
            }
        }

        private static void SortArray()
        {
            Random rnd = new Random();
            int random = 0;
            int temp = 0;
            bool changed = false;

            int[] someInts = new int[25];

            for (int i = 0; i < someInts.Length; i++)
            {
                random = rnd.Next(0, 100);
                someInts[i] = random;
            }

            Console.WriteLine("Först osorterad lista:");
            foreach (int items in someInts)
            {
                Console.Write(items + " ");
            }

            // BubbleSort
            for (int i = 0; i < someInts.Length - 1; i++)
            {
                for (int j = 0; j < someInts.Length - 1 - i; j++)
                {
                    if (someInts[j] > someInts[j + 1])
                    {
                        temp = someInts[j];
                        someInts[j] = someInts[j + 1];
                        someInts[j + 1] = temp;
                        changed = true;
                    }
                }
                if (!changed)
                    break;
            }

            Console.WriteLine("\nNu sorterad lista:");
            foreach (int items in someInts)
            {
                Console.Write(items + " ");
            }
            
        }
    }
}