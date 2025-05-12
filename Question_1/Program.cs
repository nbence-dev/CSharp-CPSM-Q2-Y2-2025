using System.Diagnostics.Metrics;

namespace Question_1
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // declare array that will display menu.
            string[] menu = { "1. Add Patient", "2. Remove Patient", "3. Search Patient", "4. Display All Patients", "5. Exit" };

            //array of objects
            const int size = 1;  // To easily change the size
            CPMS[] People = new CPMS[size];

            bool isRunning = true;
            //Run application
            while (isRunning)
            {
                bool isValidChoice = false;
                int choice = 0;
                //Display menu
                displayMenu(menu);

                //Prompt user to enter a choice
                Console.Write("Enter your choice: ");
                //Add validation to ensure user added a number
                try
                {
                    //Convert number to integer
                    choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 6)
                    {
                        isValidChoice = true;
                    }
                    //If user chooses a number outside the boundary, error is displayed
                    else
                    {
                        Console.WriteLine("You must choose a number from 1 to 5.\n");

                    }

                }// Error if user enters non-integer value
                catch (FormatException err)
                {
                    Console.WriteLine('\n'+err.Message + '\n');
                }


                //If a valid choice is entered, the user can continue
                if (isValidChoice)
                {
                    //case statement because it is easier to read than if-statement
                    switch (choice)
                    {
                        case 1:
                            //Add new patient to array.
                            AddPatient(People);
                            Console.WriteLine();
                            break;
                        case 2:
                            //Remove patient from array using name
                            RemovePatient(People);
                            break;
                        case 3:
                            //Search for patient and display details via name.
                            SearchPatient(People);
                            Console.WriteLine();
                            break;
                        case 4:
                            //Display all patients in array
                            DisplayAll(People);
                            break;
                        case 5:
                            //Exit program
                            Console.WriteLine("Have a good day!");
                            Environment.Exit(0);
                            Console.WriteLine();
                            break;
                    }
                }
                // Reset so that validation works
                isValidChoice = false;



            }

        }

        //Function to display menu to add cleanliness to code
        static void displayMenu(string[] menu)
        {
            foreach (string i in menu)
            {
                Console.WriteLine(i);
            }
            //Increase readability
            Console.WriteLine();
        }

        static void AddPatient(CPMS[] People)
        {
            // Before administrator is prompted to enter values, first test if there is a open place in array.
            bool allNull = People.All(element => element == null);
            if (allNull)
            {
                // Get user info: name, age and medical condition
                Console.Write("\nEnter the patient's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the patient's age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter the patient's medical condition: ");
                string medicalCondition = Console.ReadLine();

                bool isPlace = false;
                // for loop to determine first null value in array. Stores object in null value.
                CPMS addNew = new CPMS(name, age, medicalCondition);
                for (int i = 0; i < People.Length; i++)
                {
                    if (People[i] == null)
                    {
                        People[i] = addNew;
                        //isPlace = true;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nArray full.\n");
            }

            
            //if (!isPlace)
            //{
            //    Console.WriteLine("\nArray is full.\n");
            //}
        }
        //Searches where array is not equal to null, therefore it must contain an object. If object is found, compare it with name entered. If found, delete info. Delete only for one patient.
        static void RemovePatient(CPMS[] People)
        {
            Console.Write("\nEnter patient name that you want to remove: ");
            string name = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < People.Length; i++)
            {
                if (People[i] != null)
                {
                    if (People[i].Name == name)
                    {
                        People[i] = null;
                        found = true;
                        break;
                    }

                }
            }
            if (found)
            {
                Console.WriteLine("\nPatient successfully removed from array.\n");
            }
            else
            {
                Console.WriteLine("\nNo patient found.\n");
            }
        }
        //Searches where array is not equal to null, therefore it must contain an object. If object is found, compare it with name entered. If found, display all info. Display all patients with same name.
        static void SearchPatient(CPMS[] People)
        {
            Console.Write("\nEnter patient name that you want to search: ");
            string name = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < People.Length; i++)
            {
                if (People[i] != null)
                {
                    if (People[i].Name == name)
                    {
                        Console.WriteLine($"Patient Name: {People[i].Name}\nAge: {People[i].Age}\nMedical Condition: {People[i].MedicalCondition}\n");
                        found = true;
                    }

                }
            }
            if (!found)
            {
                Console.WriteLine($"\nNo search results for {name}.\n");
            }

        }
        //Display all current patients' info in array.
        static void DisplayAll(CPMS[] People)
        {
            bool found = false;
            foreach (var person in People)
            {
                if (person != null)
                {
                    Console.WriteLine($"Name: {person.Name}\nAge: {person.Age}\nMedical Condition: {person.MedicalCondition}\n");
                    found = true;

                }
            }
            if (!found)
            {
                Console.WriteLine("\nNo patient records to display.\n");
            }
        }
    }

}
