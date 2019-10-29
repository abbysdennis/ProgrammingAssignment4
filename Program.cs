using System;
using System.IO;

namespace PA4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CreateMenu();
        }

        //This method creates the Main Menu for the user to navigate from
        public static void CreateMenu()
        {
            string menuChoice = GetMenuChoice();

            while  (menuChoice != "4")
            {
                //This portion of the code directs the user to the Encode a File option
                if (menuChoice == "1")
                {
                    Console.WriteLine("You have selected the Encode a File option.");
                    Console.WriteLine("Please enter the name of the file you want to encode: ");
                    string fileName = Console.ReadLine();

                    //This checks the users computer to see if the file the user wants to encode exists
                    while (!(File.Exists(fileName)))
                    {
                        Console.WriteLine("File does not exist.");
                        Console.WriteLine("Please enter the name of a valid file: ");
                        fileName = Console.ReadLine();
                    }
                    
                    EncodeFile(fileName);
                }

                //This portion of the code directs the user to the Decode a File option
                else if (menuChoice == "2")
                {
                    Console.WriteLine("You have selected the Decode a File option.");
                    Console.WriteLine("Please enter the name of the file you want to decode: ");
                    string fileName = Console.ReadLine();

                    //This checks the users computer to see if the file the user wants to decode exists
                    while (!(File.Exists(fileName)))
                    {
                        Console.WriteLine("File does not exist.");
                        Console.WriteLine("Please enter the name of a valid file: ");
                        fileName = Console.ReadLine();
                    }

                    DecodeFile(fileName);
                }

                //This portion of the code directs the user to the Word Count function
                else
                {
                    Console.WriteLine("You have selected the Word Count option.");
                    Console.WriteLine("Please enter the name of the file you want to word count: ");
                    string fileName = Console.ReadLine();

                    //This checks the user's computer to see if the file the user wants to word count exists
                    while (!(File.Exists(fileName)))
                    {
                        Console.WriteLine("File does not exist.");
                        Console.WriteLine("Please enter the name of a valid file: ");
                        fileName = Console.ReadLine();
                    }

                    WordCount(fileName);
                }

                menuChoice = GetMenuChoice();
            }

            //This portion of the code exits the program when the user selects menu option "4"
            if (menuChoice == "4")
            {
                Console.WriteLine("Thank you.  Good-bye!");
            }
        }

        //This portion of the code gets the users menu choice
        public static string GetMenuChoice()
        {
            Console.WriteLine("File Menu Options");
            Console.WriteLine("Please select an option from the menu below: ");
            Console.WriteLine("1: Encode a File");
            Console.WriteLine("2: Decode a File");
            Console.WriteLine("3: Word Count");
            Console.WriteLine("4: Exit");
            Console.WriteLine("");

            string userInput = Console.ReadLine();
            int choice;
            bool notValid = true;

            //This portion of the code checks the validaity of the user's menu option
            if (int.TryParse(userInput, out choice))
            {
                if (choice >= 1 && choice <=4)
                {
                    notValid = false;
                }
            }

            //If the user's choie is not valid, then the error message loops until a valid option is found
            while (notValid)
            {
                Console.WriteLine("Please enter a valid menu option: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out choice))
                {
                    if (choice >= 1 && choice <= 4)
                    {
                        notValid = false;
                    }
                }
            }

            return choice + "";
        }

        //This portion of the code is responsible for the Encode a File menu option
        public static void EncodeFile(string fileName)
        {
            //This portion of the code opens and copies the file to be manipulated
            StreamReader inFile = new StreamReader(fileName);

            string fileRaw = inFile.ReadToEnd();

            //This line of the code converts the text file to uppercase letters
            string file = fileRaw.ToUpper();

            char[] letters = new char[file.Length];

            //This line closes the file
            inFile.Close();

            int len = file.Length;

            //This portion of the code copies the file into characters to be manipulated
            for(int i=0; i < len; i++)
            {
                letters[i] = file[i];
            }

            for(int j=0; j < len; j++)
            {
                //This line of the code converts the character letters in "letters" to numbers to be manipulated
                int num = (int)letters[j];

                if (num >= 'A' && num <= 'Z')
                {
                    if (num > 'M')
                    {
                        num = num - 13;
                    }

                    else
                    {
                        num = num + 13;
                    }
                }

                letters[j] = (char)num;
            }

            //This portion of the code creates a new file, where the encoded file will be saved
            Console.WriteLine(" ");
            Console.WriteLine("Enter the name of the new encoded file: ");
            string newFileName = Console.ReadLine();

            StreamWriter outFile = new StreamWriter(newFileName);

            //This line copies the contents of "letters" into the new text file
            outFile.WriteLine(letters);

            //This line of code closes the new file created with the encoded text
            outFile.Close();

            Console.WriteLine(" ");
            Console.WriteLine("File successfully saved.");
            Console.WriteLine(" ");

        }

        //This portion of the code is responsible for the Decode a File menu option
        public static void DecodeFile(string fileName)
        {
            //This portion of the code opens and copies the file to be manipulated
            StreamReader inFile = new StreamReader(fileName);

            string fileRaw = inFile.ReadToEnd();

            //This line of the code converts the text file to uppercase letters
            string file = fileRaw.ToUpper();

            char[] letters = new char[file.Length];

            //This line closes the file
            inFile.Close();

            int len = file.Length;

            //This portion of the code copies the file into characters to be manipulated
            for (int i = 0; i < len; i++)
            {
                letters[i] = file[i];
            }

            for (int j = 0; j < len; j++)
            {
                //This line of the code converts the character letters in "letters" to numbers to be manipulated
                int num = (int)letters[j];

                if (num >= 'A' && num <= 'Z')
                {
                    if (num > 'M')
                    {
                        num = num - 13;
                    }

                    else
                    {
                        num = num + 13;
                    }
                }

                letters[j] = (char)num;
            }

            //This portion of the code creates a new file, where the decoded file will be saved
            Console.WriteLine(" ");
            Console.WriteLine("Enter the name of the new encoded file: ");
            string newFileName = Console.ReadLine();

            StreamWriter outFile = new StreamWriter(newFileName);

            //This line copies the contents of "letters" into the new text file
            outFile.WriteLine(letters);

            //This line of code closes the new file created with the decoded text
            outFile.Close();

            Console.WriteLine(" ");
            Console.WriteLine("File successfully saved.");
            Console.WriteLine(" ");
        }

        //This portion of the code calculates Word Count for a text file
        public static void WordCount(string fileName)
        {
            //This portion of the code opens and copies the file to be manipulated
            StreamReader inFile = new StreamReader(fileName);

            string file = inFile.ReadToEnd();

            //This line closes the file
            inFile.Close();

            int len = file.Length;

            string[] words = new string[len];

            //This line splits the file into words when it finds a space
            words = file.Split(' ');

            int count = 0;

            //This loop increases a count variable when a space is found
            foreach (var word in words)
            {
                count++;
            }

            //This prints the total words found in the text file
            Console.WriteLine(" ");
            Console.WriteLine("Total Words: {0}", count);
            Console.WriteLine(" ");
        }
    }
}
