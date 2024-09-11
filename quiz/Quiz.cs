namespace quiz
{
	public class Quiz
	{
		private string? _login;
		private string? _password;
		private string? _dataBirth;
		public Quiz()
		{
			this._login = String.Empty;
			this._password = String.Empty;
			this._dataBirth = String.Empty;
		}
		public Quiz(string login, string password, string data)
		{
			this._login = login;
			this._password = password;
			this._dataBirth = data;
		}

		~Quiz()
		{

		}
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

						QuizLast();

						break;
					case 3:

						Console.WriteLine("Quiz section: Biology, Informatics, Mathematics");
						userDirectory = Console.ReadLine();
						Console.Clear();

						Top20(userDirectory);

						break;
					case 4:

						SettingsProfile();

						break;
				}
			}
		}

		/*!
		 * @brief Checking for user existence
		 * param[in] Path file
		 * return True - user is; False - user not is.
		 */
		public bool CheckingUserExistence(string filePath = "./Users.txt")
		{
			Console.WriteLine("Enter login");
			this._login = Console.ReadLine();
			Console.WriteLine("Enter pssword");
			this._password = Console.ReadLine();
			Console.Clear();
			string[] lines = File.ReadAllLines(filePath);
			if (lines.Any(line => line.Contains($"{this._login} {this._password}")) && this._password != null && this._login != null)
			{
				for (int i = 0; i < lines.Length; i++)
				{
					if (lines[i].Contains($"{this._login} {this._password}"))
					{
						string[] a = lines[i].Split(' ');
						this._dataBirth = a[2];
					}
				}
				return true;
			}

			return false;
		}

		/*!
	   * @brief Registration users
	   * param[in] Path file.
	   * return True - registration was successful; False - registration failed.
	   */
		public bool Registration(string filePath = "./Users.txt")
		{
			if (File.Exists(filePath))
			{
				using (StreamWriter writer = new StreamWriter(filePath, true))
				{
					writer.WriteLine($"{this._login} {this._password} {this._dataBirth}");

					writer.Close();
				}

				return true;
			}

			return false;
		}

		/*!
		 * @brief Play the quiz.
		 * param[in] name directory.
		 * return True - game complete, data saved; False - uncompleted.
		 */
		private bool PlayQuiz(string fileDirectory)
		{
			string filePath = "./" + fileDirectory + "/Questions.txt";
			byte answersTrue = 0;
			if (File.Exists(filePath))
			{
				using (StreamReader readerQuest = new StreamReader(filePath))
				{
					int lineCount = 0;
					byte numQuestion = 1;
					string? line;
					while ((line = readerQuest.ReadLine()) != null)
					{
						Console.WriteLine(line);
						lineCount++;

						if (lineCount % 9 == 0)
						{
							Console.WriteLine("\tAnswer");
							char answerUser = Convert.ToChar(Console.ReadLine());

							if (File.ReadLines("./" + fileDirectory + "/Answers.txt").Any(line => line.Contains($"{numQuestion} {answerUser})")))
							{
								answersTrue++;
							}
							numQuestion++;
							Console.Clear();
						}
					}
				}
				using (StreamWriter writer = new StreamWriter("./" + fileDirectory + "/Top20.txt", true))
				{
					writer.WriteLine($"{answersTrue}-{this._login}");
					writer.Close();
				}
				Console.Clear();
				Console.WriteLine($"Quiz section: {fileDirectory}\n{this._login} - True Answer: {answersTrue}");
				Console.ReadKey();
				return true;
			}
			return false;
		}

		/*!
		 * @brief Profile customization.
		 * param[in] Path file.
		 */
		private void SettingsProfile(string filePath = "./Users.txt")
		{
			string[] lines = File.ReadAllLines(filePath).Where(line => line != $"{this._login} {this._password} {this._dataBirth}").ToArray();
			File.WriteAllLines(filePath, lines);

			Console.WriteLine($"{this._login} - setting password");
			this._password = Console.ReadLine();
			Console.WriteLine($"{this._login} - setting data");
			this._dataBirth = Console.ReadLine();
			Console.Clear();
			using (StreamWriter writer = new StreamWriter(filePath, true))
			{
				writer.WriteLine($"{this._login} {this._password} {this._dataBirth}");
				writer.Close();
			}
			Console.WriteLine($"The data has been changed");
			Console.ReadKey();
		}

		/*!
	   * @brief Top 20 result.
	   * param[in] Name directory.
	   */
		private void Top20(string fileDirectory)
		{
			File.ReadAllLines("./" + fileDirectory + "/Top20.txt").OrderByDescending(line => line).ToList().ForEach(line => Console.WriteLine(line));
			Console.ReadKey();
		}

		/*!
		* @brief Displays the most recently completed quizzes on the screen.
		*/
		private void QuizLast()
		{
			File.ReadAllLines("./Biology/Top20.txt").Where(line => line.Contains(this._login)).ToList().ForEach(line => Console.WriteLine($"Biology: {line}"));
			File.ReadAllLines("./Informatics/Top20.txt").Where(line => line.Contains(this._login)).ToList().ForEach(line => Console.WriteLine($"Informatics: {line}"));
			File.ReadAllLines("./Mathematics/Top20.txt").Where(line => line.Contains(this._login)).ToList().ForEach(line => Console.WriteLine($"Mathematics: {line}"));
			Console.ReadKey();
		}
	}
}


