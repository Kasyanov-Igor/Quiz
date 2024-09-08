﻿namespace quiz
{
    internal class Quiz
    {
        private string? _login = null;
        private string? _password = null;
        private string? _dataBirth = null;

        public void PrintMenu()
        {
            const uint NUMBER_EXIT_MENU_ELEMENT = 5;
            byte numberMenuElement = 0;

            while (numberMenuElement != NUMBER_EXIT_MENU_ELEMENT)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. New quiz");
                Console.WriteLine("2. View the result of the last quiz");
                Console.WriteLine("3. View top 20");
                Console.WriteLine("4. Change profile settings");
                Console.WriteLine("5. Exit");

                Console.WriteLine("\nEnter:");
                ConsoleKeyInfo userInputSymbol;
                do
                {
                    userInputSymbol = Console.ReadKey(true);
                }
                while (userInputSymbol.Key < ConsoleKey.D0 || userInputSymbol.Key > ConsoleKey.D5);

                numberMenuElement = Convert.ToByte(userInputSymbol.KeyChar.ToString());

                switch (numberMenuElement)
                {
                    case 1:
                        Console.WriteLine("Quiz section: Biology, Informatics, Mathematics");
                        string? userDirectory = Console.ReadLine();
                        Console.Clear();

                        if (PlayQuiz(userDirectory))
                        {
                            Console.WriteLine("Test passed");
                        }
                        Console.WriteLine("ERROR");

                        break;
                    case 2:

                        break;
                }
            }
        }

        /*!
		 * @brief Checking for user existence
		 */
        public bool CheckingUserExistence(string filePath = "./Users.txt")
        {
            Console.WriteLine("Enter login");
            this._login = Console.ReadLine();
            Console.WriteLine("Enter pssword");
            this._password = Console.ReadLine();
            Console.Clear();
            if (File.ReadLines(filePath).Any(line => line.Contains($"{this._login} {this._password}")))
            {
                return true;
            }

            return false;
        }

        public bool Registration(string filePath = "./Users.txt")
        {
            if (File.Exists(filePath))
            {
                Console.Clear();
                Console.WriteLine("Enter login to register");
                this._login = Console.ReadLine();
                Console.WriteLine("Enter pssword to register");
                this._password = Console.ReadLine();
                Console.WriteLine("Data to Birth");
                this._dataBirth = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{this._login} {this._password} {this._dataBirth}");

                    writer.Close();
                }

                return true;
            }

            return false;
        }

        private bool PlayQuiz(string fileDirectory)
        {
            byte answersTrue = 0;
            if (!File.Exists("./" + fileDirectory + "Questions.txt"))
            {
                using (StreamReader readerQuest = new StreamReader("./" + fileDirectory + "/Questions.txt"))
                {
                    int lineCount = 0;
                    byte count = 1;
                    string? line;
                    while ((line = readerQuest.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        lineCount++;

                        if (lineCount % 9 == 0)
                        {
                            Console.WriteLine("\tAnswer");
                            char answerUser = Convert.ToChar(Console.ReadLine());

                            if (File.ReadLines("./" + fileDirectory + "/Answers.txt").Any(line => line.Contains($"{count} {answerUser})")))
                            {
                                answersTrue++;
                            }
                            count++;
                            Console.Clear();
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter("./" + fileDirectory + "/Top20.txt", true))
                {
                    writer.WriteLine($"{this._login}-{answersTrue}");
                    writer.Close();
                }
                Console.Clear();
                Console.WriteLine($"Quiz section: {fileDirectory}\n{this._login} - True Answer: {answersTrue}");
                Console.Read();
                return true;
            }
            return false;
        }
    }
}


