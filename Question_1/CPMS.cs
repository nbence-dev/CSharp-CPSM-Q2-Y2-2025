using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
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

        
          
    }
}
