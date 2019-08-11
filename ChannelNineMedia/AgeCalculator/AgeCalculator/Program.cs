using System;
using System.Collections.Generic;
using ChannelNineMedia.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeCalculator
{
    class Program
    {
        /// <summary>
        /// This Method is used to calculate the age based upon the races
        /// Hardcoded List of Races 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Person> lstPerson = new List<Person>();
            Random rnd = new Random();
            
            var listRaces = new List<string> { "Angles", "Saxons", "Jutes", "Hawaiian" };

            int CAge;
            string CRace;
            using (PersonContext context = new PersonContext())
            {
                for (int i = 0; i < 10000; i++)
                {

                    Person ObjPerson = new Person();
                    ObjPerson.id = i + 1;
                    ObjPerson.PersonName = "Person #" + i.ToString();
                    CAge = ObjPerson.Age = rnd.Next(1, 98) + 1;
                    CRace = ObjPerson.Races = listRaces[rnd.Next(listRaces.Count)];
                    ObjPerson.Height = Convert.ToInt32(HeightCalculator(CAge, CRace));
                    context.person.Add(ObjPerson);
                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// This method used to calculate the height based upon the age and races
        /// </summary>
        /// <param name="Age"></param>
        /// <param name="race"></param>
        /// <returns></returns>
        private static double HeightCalculator(int Age, string race)
        {
            double Height = 0;

            if (race == "Angles" || race == "Saxons")
            {
                Height = 1.5 + (Age * 0.45);
            }
            else if (race == "Jutes")
            {
                Height = ((Age * 1.6) / 2);
            }
            else
            {
                Height = (1.7 + ((Age + 2) * 0.23));
            }
            return Math.Round(Height, 2);
        }
    }    
}
