using System;
using System.IO;

namespace NPCGenerator {
    class Program {
        #region Properties
        static string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        //Randomizer.
        static Random rnd = new Random();
        //Genders. Feel free to add more, if that's your thing.
        static string[] gender = { "male", "female" };
        //Male names.
        static string maleNamePath = dir + "\\MaleNames.txt";
        static string[] maleNames = File.ReadAllLines(maleNamePath);
        //Female names.
        static string femaleNamePath = dir + @"\FemaleNames.txt";
        static string[] femaleNames = File.ReadAllLines(femaleNamePath);
        //Fantasy races. Really anything can go in here. could also change it to 'nationality' if not using a fantasy setting.
        static string racesPath = dir + @"\Races.txt";
        static string[] races = File.ReadAllLines(racesPath);
        //Class
        static string classesPath = dir + @"\Classes.txt";
        static string[] classes = File.ReadAllLines(classesPath);
        //Professions
        static string professionsPath = dir + @"\Professions.txt";
        static string[] professions = File.ReadAllLines(professionsPath);
        //Personality traits
        static string traitsPath = dir + @"\Traits.txt";
        static string[] traits = File.ReadAllLines(traitsPath);

        //Booleans
        static bool genderBasedNames;
        #endregion
        static void Main(string[] args) {
           
            //Get input from player for how many NPCs they want to generate.
            Console.WriteLine("How many NPCs to Generate?");
            if (int.TryParse(Console.ReadLine(), out int numberToGenerate)) {
                Console.WriteLine("Number To Generate: " + numberToGenerate);
                //For each NPC they want to generate, first get gender, then name, then race. All randomly determined.
                for (int i = 0; i < numberToGenerate; i++) {
                    GenerateCharacter();
                }
                //If the player didn't enter a number, try again.
            } else Console.WriteLine("Please enter a number");
            //TODO: Save to text file or Spreadsheet.
            Console.ReadKey();

        }
        static void GenerateCharacter() {
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
                if (gIndex == 0) {
                Console.WriteLine("{0}, A {1} {2}. Profession: {3}. Personality: {4}", maleNames[nIndex], gender[gIndex], classes[cIndex], professions[pIndex], traits[tIndex]);
                string output = ($"Name: {maleNames[nIndex]}.   Gender: {gender[gIndex]}.    Class: {classes[cIndex]}.    Profession: {professions[pIndex]}     Personality Trait:{traits[tIndex]}. \r\n\r\n");
                File.AppendAllText(dir + @"\Output.txt", output);
            } else {
                Console.WriteLine("{0}, A {1} {2}. Profession: {3}. Personality: {4}", femaleNames[nIndex], gender[gIndex], classes[cIndex], professions[pIndex], traits[tIndex]);
                string output = ($"Name: {femaleNames[nIndex]}.   Gender: {gender[gIndex]}.    Class: {classes[cIndex]}.    Profession: {professions[pIndex]}     Personality Trait:{traits[tIndex]}.\r\n\r\n");
                File.AppendAllText(dir + @"\Output.txt", output);
            }
        }

        static void AddToSpreadsheet() {

        }
        static void GenerateSpreadsheet() {
        }
    }
}
