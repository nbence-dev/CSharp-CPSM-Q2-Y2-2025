using System.Diagnostics.Metrics;

namespace Question_2
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // declare array that will display menu.
            string[] menu = { "1. Add Patient", "2. Remove Patient", "3. Search Patient", "4. Display All Patients","5. Print Patient Information to File" ,"6. Exit" };

            //array of objects
            const int size = 1;  // To easily change the size
            //CPMS[] People = new CPMS[size];
            
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

                    if (choice > 0 && choice < 7)
                    {
                        isValidChoice = true;
                    }
                    //If user chooses a number outside the boundary, error is displayed
                    else
                    {
                        Console.WriteLine("You must choose a number from 1 to 6.\n");

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
                            CPMS.AddPatient();
                            Console.WriteLine();
                            break;
                        case 2:
                            //Remove patient from array using name
                            CPMS.RemovePatient();
                            break;
                        case 3:
                            //Search for patient and display details via name.
                            CPMS.SearchPatient();
                            Console.WriteLine();
                            break;
                        case 4:
                            //Display all patients in array
                            CPMS.DisplayAll();
                            break;
                        case 5:
                            //Prints all array information to a textfile
                            //CPMS.PrintToFile();
                            break;
                        case 6:
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
    }

}
