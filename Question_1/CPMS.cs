using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    internal class CPMS
    {
        //Fields. We want to set the name, age and medicalcondition of the patient.
        public string Name { get; set; }
        public int Age { get; set; }
        public string MedicalCondition { get; set; }







        public CPMS(string name, int age, string medicalCondition)
        {
            Name = name;
            Age = age;
            MedicalCondition = medicalCondition;
        }

        //const int size = 20;
        private static CPMS[] People = new CPMS[]
        {
            new CPMS("John Doe", 45, "Diabetes"),
            new CPMS("Jane Smith", 32, "Asthma"),
            new CPMS("Michael Johnson", 50, "Hypertension"),
            new CPMS("Emily Davis", 27, "Migraine"),
            new CPMS("Robert Wilson", 60, "Arthritis"),
            new CPMS("Sophia Martinez", 38, "Heart Disease"),
            new CPMS("Daniel Brown", 41, "Allergies"),
            new CPMS("Olivia Taylor", 29, "Depression"),
            new CPMS("James Anderson", 55, "High Cholesterol"),
            new CPMS("Emma Thomas", 36, "Anemia")
        };

        


        public static void AddPatient()
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
        public static void RemovePatient()
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

        public static void SearchPatient()
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

        public static void DisplayAll()
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
