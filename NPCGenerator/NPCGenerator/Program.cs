using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NPCGenerator {
    class Program {
        static void Main(string[] args) {
            #region Properties
            string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //Randomizer.
            Random rnd = new Random();
            //Genders. Feel free to add more, if that's your thing.
            string[] gender = {"male", "female"};
            //Male names.
            string maleNamePath = dir + "\\MaleNames.txt";
            string[] maleNames = File.ReadAllLines(maleNamePath);
            //Female names.
            string femaleNamePath = dir + @"\FemaleNames.txt";
            string[] femaleNames = File.ReadAllLines(femaleNamePath);
            //Fantasy races. Really anything can go in here. could also change it to 'nationality' if not using a fantasy setting.
            string racesPath = dir + @"\Races.txt";
            string[] races = File.ReadAllLines(racesPath);
            //Class
            string classesPath = dir + @"\Classes.txt";
            string[] classes = File.ReadAllLines(classesPath);
            //Professions
            string professionsPath = dir + @"\Professions.txt";
            string[] professions = File.ReadAllLines(professionsPath);
            //Personality traits
            string traitsPath = dir + @"\Traits.txt";
            string[] traits = File.ReadAllLines(traitsPath);
            #endregion
            //Get input from player for how many NPCs they want to generate.
            Console.WriteLine("How many NPCs to Generate?");
            if (int.TryParse(Console.ReadLine(), out int numberToGenerate)) {
                Console.WriteLine("Number To Generate: " + numberToGenerate);
                //For each NPC they want to generate, first get gender, then name, then race. All randomly determined.
                for (int i = 0; i < numberToGenerate; i++) {
                    int gIndex = rnd.Next(gender.Length);
                    //Console.WriteLine("Genders: " + gender.Length);
                    int nIndex;
                    if (gIndex == 0) {
                        nIndex = rnd.Next(maleNames.Length);
                        //Console.WriteLine("Male Names: " + maleNames.Length);
                    } else {
                        nIndex = rnd.Next(femaleNames.Length);
                        //Console.WriteLine("Female Names: " + femaleNames.Length);
                    }
                    int rIndex = rnd.Next(races.Length);
                  //  Console.WriteLine("Races: " + races.Length);
                    int cIndex = rnd.Next(classes.Length);
                   // Console.WriteLine("Classes: " + classes.Length);
                    int pIndex = rnd.Next(professions.Length);
                  //  Console.WriteLine("Professions: " + professions.Length);
                    int tIndex = rnd.Next(traits.Length);
                   // Console.WriteLine("Traits: " + traits.Length);
                    if(gIndex == 0){
                        Console.WriteLine("{0}, A {1} {2}. Profession: {3}. Personality: {4}",maleNames[nIndex],gender[gIndex],classes[cIndex],professions[pIndex],traits[tIndex]);
                    } else {
                        Console.WriteLine("{0}, A {1} {2}. Profession: {3}. Personality: {4}", femaleNames[nIndex], gender[gIndex], classes[cIndex], professions[pIndex], traits[tIndex]);
                    }
                }
                //If the player didn't enter a number, try again.
            } else Console.WriteLine("Please enter a number");
            //TODO: Save to text file or Spreadsheet.
            Console.ReadKey();

        }
    }
}
