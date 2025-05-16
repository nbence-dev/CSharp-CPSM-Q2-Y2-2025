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

        const int size = 10;
        private static CPMS[] People = new CPMS[size];
        

        
        


        public static void AddPatient()
        {
            // Before administrator is prompted to enter values, first test if there is a open place in array.
            int filledSlots = People.Count(element => element != null);

            if (filledSlots >= People.Length)
            {
                Console.WriteLine("\nArray is full!\n");
            }
            else
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
            


            
        }
        public static void AddTenPatients()
        {
            string filePath = "10_patients.txt";
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int counter = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            string name = parts[0].Trim();
                            int age = int.Parse(parts[1].Trim());
                            string condition = parts[2].Trim();
                            People[counter] = new CPMS(name, age, condition);
                        }
                        counter++;

                    }
                }
            }
            else
            {
                Console.WriteLine("File not found. Could not instantiate array with 10 people.");
                
            }
            

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

        public static void SaveToTxt()
        {
            //Getting the folder path of the desktop of the current user
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Create and write to file
            string filePath = Path.Combine(desktopPath, "patient_information.txt");
            //if (File.Exists(filePath))

            using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var person in People)
                    {
                    if (person != null)
                    {
                        writer.WriteLine($"Name: {person.Name}\nAge: {person.Age}\nMedical condition: {person.MedicalCondition}\n");
                    }
                        
                    }
                }
                Console.WriteLine($"Patient information printed to file [{filePath}].\n");
            



        }
        




    }
}
