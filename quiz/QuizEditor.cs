namespace quiz
{
	internal class QuizEditor
	{
		private string _login = "admin";
		private string _password = "123";


		public void PrintMenu()
		{
			const uint NUMBER_EXIT_MENU_ELEMENT = 4;
			byte numberMenuElement = 0;

			while (numberMenuElement != NUMBER_EXIT_MENU_ELEMENT)
			{
				Console.Clear();
				Console.WriteLine("Menu:");
				Console.WriteLine("1. Creating a quiz");
				Console.WriteLine("2. Add quiz");
				Console.WriteLine("3. Editing a quiz");
				Console.WriteLine("4. Exit");

				Console.WriteLine("\nEnter:");
				ConsoleKeyInfo userInputSymbol;
				do
				{
					userInputSymbol = Console.ReadKey(true);
				}
				while (userInputSymbol.Key < ConsoleKey.D0 || userInputSymbol.Key > ConsoleKey.D4);

				numberMenuElement = Convert.ToByte(userInputSymbol.KeyChar.ToString());

				switch (numberMenuElement)
				{
					case 1:
						СreateFile("Answers", "./Biology");
						СreateFile("Questions", "./Biology");
						СreateFile("Top20", "./Biology");



						СreateFile("Answers", "./Informatics");
						СreateFile("Questions", "./Informatics");
						СreateFile("Top20", "./Informatics");


						СreateFile("Answers", "./Mathematics");
						СreateFile("Questions", "./Mathematics");
						СreateFile("Top20", "./Mathematics");

						AddQuestions("./Informatics/Questions.txt", "./Mathematics/Questions.txt", "./Biology/Questions.txt");
						AddAnswer("./Informatics/Answers.txt", "./Mathematics/Answers.txt", "./Biology/Answers.txt");

						СreateFile("Users", "./");

						break;

					case 2:

						Console.WriteLine("Enter name quiz");
						string? quizName = Console.ReadLine();

						СreateFile("Answers", "./" + quizName);
						СreateFile("Questions", "./" + quizName);
						СreateFile("Top20", "./" + quizName);

						break;

					case 3:

						Console.WriteLine("Which quiz to add a question to?");
						string? questionName = Console.ReadLine();
						AddQuestions(questionName);

						break;
				}
			}
		}

		public void СreateFile(string fileName, string directory, string format = ".txt")
		{
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
			using (FileStream file = File.Create(Path.Combine(directory, fileName + format))) { }
		}

		private bool AddQuestions(string filePathInformatic, string filePathMathematics, string filePathBiology)
		{
			if (File.Exists(filePathInformatic) && File.Exists(filePathMathematics) && File.Exists(filePathBiology))
			{
				using (StreamWriter writer = new StreamWriter(filePathInformatic))
				{
					writer.Write("1. Какое из этих устройств не является устройством ввода информации?\r\na) Клавиатура\r\n\r\nb) Мышь\r\n\r\nc) Монитор\r\n\r\nd) Сканер\r\n\r\n2. Что такое операционная система?\r\na) Программа, которая запускает игры.\r\n\r\nb) Программа, которая управляет работой компьютера.\r\n\r\nc) Программа, которая создает веб-сайты.\r\n\r\nd) Программа, которая редактирует изображения.\r\n\r\n3. Какой из этих языков программирования является объектно-ориентированным?\r\na) Python\r\n\r\nb) C\r\n\r\nc) Assembly\r\n\r\nd) BASIC\r\n\r\n4 Что такое алгоритм?\r\na) Программа, которая запускает компьютер.\r\n\r\nb) Сборник инструкций для выполнения задачи.\r\n\r\nc) Устройство для хранения информации.\r\n\r\nd) Сетевой протокол для передачи данных.\r\n\r\n5.Какое из этих устройств не является устройством вывода информации?\r\na) Монитор\r\n\r\nb) Принтер\r\n\r\nc) Динамики\r\n\r\nd) Сканер\r\n\r\n6 Какая единица измерения информации является самой маленькой?\r\na) Байт\r\n\r\nb) Килoбайт\r\n\r\nc) Мегабайт\r\n\r\nd) Бит\r\n\r\n7 Что такое интернет-протокол?\r\na) Протокол для передачи данных в локальной сети.\r\n\r\nb) Протокол для передачи данных в глобальной сети.\r\n\r\nc) Протокол для передачи данных по Bluetooth.\r\n\r\nd) Протокол для передачи данных по USB.\r\n\r\n8 Что такое веб-браузер?\r\na) Программа для создания веб-сайтов.\r\n\r\nb) Программа для поиска информации в интернете.\r\n\r\nc) Программа для просмотра веб-страниц.\r\n\r\nd) Программа для отправки электронных писем.\r\n\r\n9 Какое из этих понятий не относится к базам данных?\r\na) Таблица\r\n\r\nb) Запись\r\n\r\nc) Поле\r\n\r\nd) Файл\r\n\r\n10 Что такое искусственный интеллект?\r\na) Программа, которая имитирует человеческое мышление.\r\n\r\nb) Программа, которая управляет роботами.\r\n\r\nc) Программа, которая создает видеоигры.\r\n\r\nd) Программа, которая рисует картины.\r\n\r\n11 Что такое облачные вычисления?\r\na) Использование вычислительных ресурсов на удаленном сервере.\r\n\r\nb) Использование вычислительных ресурсов на локальном компьютере.\r\n\r\nc) Использование вычислительных ресурсов на мобильных устройствах.\r\n\r\nd) Использование вычислительных ресурсов на квантовом компьютере.\r\n\r\n12 Что такое кибербезопасность?\r\na) Защита от вирусов и вредоносных программ.\r\n\r\nb) Защита от взлома компьютеров и сетей.\r\n\r\nc) Защита от кражи личных данных.\r\n\r\nd) Все вышеперечисленное.\r\n\r\n13 Что такое брандмауэр?\r\na) Программа, которая защищает от вирусов.\r\n\r\nb) Программа, которая защищает от взлома.\r\n\r\nc) Программа, которая защищает от кражи данных.\r\n\r\nd) Программа, которая защищает от нежелательного доступа к сети.\r\n\r\n14 Что такое вирус?\r\na) Программа, которая может распространяться по компьютерам и наносить им вред.\r\n\r\nb) Программа, которая защищает от вирусов.\r\n\r\nc) Программа, которая создает веб-сайты.\r\n\r\nd) Программа, которая редактирует изображения.\r\n\r\n15 Какой из этих языков программирования не используется для создания веб-сайтов?\r\na) HTML\r\n\r\nb) CSS\r\n\r\nc) JavaScript\r\n\r\nd) Assembly\r\n\r\n16 Что такое поисковая система?\r\na) Программа, которая создает веб-сайты.\r\n\r\nb) Программа, которая позволяет пользователям просматривать веб-страницы.\r\n\r\nc) Программа, которая позволяет пользователям находить информацию в интернете.\r\n\r\nd) Программа, которая защищает от вирусов.\r\n\r\n17 Что такое машинное обучение?\r\na) Раздел искусственного интеллекта, изучающий алгоритмы, позволяющие компьютерам обучаться на данных.\r\n\r\nb) Раздел искусственного интеллекта, изучающий алгоритмы для создания игр.\r\n\r\nc) Раздел искусственного интеллекта, изучающий алгоритмы для создания роботов.\r\n\r\nd) Раздел искусственного интеллекта, изучающий алгоритмы для создания искусственного языка.\r\n\r\n18 Что такое квантовые вычисления?\r\na) Тип вычислений, использующий квантовые явления для решения задач, недоступных для классических компьютеров.\r\n\r\nb) Тип вычислений, использующий классические компьютеры для решения задач, недоступных для квантовых компьютеров.\r\n\r\nc) Тип вычислений, использующий суперкомпьютеры для решения задач, недоступных для классических компьютеров.\r\n\r\nd) Тип вычислений, использующий мобильные устройства для решения задач, недоступных для классических компьютеров.\r\n\r\n19 Что такое блокчейн?\r\na) Технология распределенного реестра, обеспечивающая безопасность и прозрачность записей.\r\n\r\nb) Технология для хранения данных на локальном компьютере.\r\n\r\nc) Технология для создания веб-сайтов.\r\n\r\nd) Технология для редактирования изображений.\r\n\r\n20 Что такое цифровая подпись?\r\na) Цифровая подпись, подтверждающая подлинность и целостность документа.\r\n\r\nb) Цифровая подпись, подтверждающая авторство документа.\r\n\r\nc) Цифровая подпись, подтверждающая дату создания документа.\r\n\r\nd) Все вышеперечисленное.");

					writer.Close();
				}

				using (StreamWriter writer = new StreamWriter(filePathMathematics))
				{
					writer.Write("1. Какое число является наименьшим общим кратным чисел 6 и 8?\r\n    * a) 12\r\n    * b) 24\r\n    * c) 48\r\n    * d) 72\r\n\r\n\r\n\r\n\r\n2. Решите уравнение: 2x + 5 = 11\r\n    * a) x = 3\r\n    * b) x = 4\r\n    * c) x = 5\r\n    * d) x = 6\r\n\r\n\r\n\r\n\r\n3. Чему равна площадь прямоугольника со сторонами 5 см и 8 см?\r\n    * a) 13 см²\r\n    * b) 26 см²\r\n    * c) 30 см²\r\n    * d) 40 см²\r\n\r\n\r\n\r\n\r\n4. Какое число является корнем уравнения x² - 9 = 0?\r\n    * a) 3\r\n    * b) -3\r\n    * c) 3 и -3\r\n    * d) Ни одно из вышеперечисленных\r\n\r\n\r\n\r\n\r\n5. Чему равна сумма углов треугольника?\r\n    * a) 90°\r\n    * b) 180°\r\n    * c) 270°\r\n    * d) 360°\r\n\r\n\r\n\r\n\r\n6. Какое из следующих чисел является простым?\r\n    * a) 10\r\n    * b) 12\r\n    * c) 17\r\n    * d) 24\r\n\r\n\r\n\r\n\r\n7. Решите неравенство: x + 3 < 7\r\n    * a) x < 4\r\n    * b) x > 4\r\n    * c) x < 10\r\n    * d) x > 10\r\n\r\n\r\n\r\n\r\n8. Чему равен периметр квадрата со стороной 6 см?\r\n    * a) 12 см\r\n    * b) 18 см\r\n    * c) 24 см\r\n    * d) 36 см\r\n\r\n\r\n\r\n\r\n9. Какое из следующих чисел является рациональным?\r\n    * a) √2\r\n    * b) π\r\n    * c) 0.333...\r\n    * d) √7\r\n\r\n\r\n\r\n\r\n10. Какое число является наибольшим общим делителем чисел 12 и 18?\r\n    * a) 2\r\n    * b) 3\r\n    * c) 6\r\n    * d) 12\r\n\r\n\r\n\r\n\r\n11. Решите систему уравнений: \r\n    x + y = 5\r\n    x - y = 1\r\n    * a) x = 3, y = 2\r\n    * b) x = 2, y = 3\r\n    * c) x = 4, y = 1\r\n    * d) x = 1, y = 4\r\n\r\n\r\n12. Чему равен объем куба с ребром 4 см?\r\n    * a) 16 см³\r\n    * b) 32 см³\r\n    * c) 64 см³\r\n    * d) 128 см³\r\n\r\n\r\n\r\n\r\n13. Какое из следующих чисел является иррациональным?\r\n    * a) 1/2\r\n    * b) 0.5\r\n    * c) √3\r\n    * d) 2.5\r\n\r\n\r\n\r\n\r\n14. Решите уравнение: x² + 4x + 4 = 0\r\n    * a) x = 2\r\n    * b) x = -2\r\n    * c) x = 2 и x = -2\r\n    * d) Ни одно из вышеперечисленных\r\n\r\n\r\n\r\n\r\n15. Чему равен тангенс угла 45°?\r\n    * a) 1\r\n    * b) √2\r\n    * c) √3\r\n    * d) 1/2\r\n\r\n\r\n\r\n\r\n16. Какое из следующих чисел является целым?\r\n    * a) √5\r\n    * b) 2.7\r\n    * c) -3\r\n    * d) 1/3\r\n\r\n\r\n\r\n\r\n17. Решите неравенство: 2x - 1 > 5\r\n    * a) x > 3\r\n    * b) x < 3\r\n    * c) x > 2\r\n    * d) x < 2\r\n\r\n\r\n\r\n\r\n18. Чему равен периметр равностороннего треугольника со стороной 10 см?\r\n    * a) 10 см\r\n    * b) 20 см\r\n    * c) 30 см\r\n    * d) 40 см\r\n\r\n\r\n\r\n\r\n19. Какое число является квадратом числа 7?\r\n    * a) 14\r\n    * b) 21\r\n    * c) 35\r\n    * d) 49\r\n\r\n\r\n\r\n\r\n20. Чему равен объем цилиндра с радиусом основания 5 см и высотой 8 см?\r\n    * a) 200π см³\r\n    * b) 400π см³\r\n    * c) 600π см³\r\n    * d) 800π см³");

					writer.Close();
				}

				using (StreamWriter writer = new StreamWriter(filePathBiology))
				{
					writer.Write("");

					writer.Close();
				}

				return true;
			}

			return false;
		}

		private bool AddAnswer(string filePathInformatic, string filePathMathematics, string filePathBiology)
		{
			if (File.Exists(filePathInformatic) && File.Exists(filePathMathematics) && File.Exists(filePathBiology))
			{
				using (StreamWriter writer = new StreamWriter(filePathInformatic))
				{
					writer.Write("1 c) \r\n\r\n2 b) \r\n\r\n3 a) \r\n\r\n4 b) \r\n\r\n5 d) \r\n\r\n6 d) \r\n\r\n7 b) \r\n\r\n8 c) \r\n\r\n9 d) \r\n\r\n11 a) \r\n\r\n12 a) \r\n\r\n13 d) \r\n\r\n14 d) \r\n\r\n15 a) \r\n\r\n16 d) \r\n\r\n17 c) \r\n\r\n18 a) \r\n19 a) \r\n\r\n20 a) \r\n\r\nd) Все вышеперечисленное.\r\n");
					writer.Close();
				}

				using (StreamWriter writer = new StreamWriter(filePathMathematics))
				{
					writer.Write("1 b) \r\n2 a) \r\n3 d) \r\n4 c) \r\n5 b) \r\n6 c) \r\n7 a) \r\n8 c) \r\n9 c) \r\n10 c) \r\n11 a) \r\n12 c) \r\n13 c) \r\n14 b) \r\n15 a) \r\n16 c) \r\n17 a) \r\n18 c) \r\n19 d) \r\n20 a) \r\n");
					writer.Close();
				}

				using (StreamWriter writer = new StreamWriter(filePathBiology))
				{
					writer.Write("");

					writer.Close();
				}

				return true;
			}
			return false;
		}

		public bool AddQuestions(string filePath)
		{
			if (File.Exists("./" + filePath + "/Questions.txt"))
			{
				using (StreamWriter writer = new StreamWriter("./" + filePath + "/Questions.txt"))
				{
					string[]? question = null;

					Console.WriteLine("Add Questions and 4 answer options");
					for (int i = 0; i < 5; i++)
					{
						question[i] += Console.ReadLine();
					}
					writer.Write(question[0] + "\r\n" + question[1] + "\r\n" + question[2] + "\r\n" + question[3] + "\r\n" + question[4] + "\r\n\r\n\r\n\r\n\r\n");

					writer.Close();
				}

				using (StreamWriter writer = new StreamWriter("./" + filePath + "/Answers.txt"))
				{
					string[]? answer = null;

					Console.WriteLine("Num quest and answer");
					for (int i = 0; i < 2; i++)
					{
						answer[i] += Console.ReadLine();
					}
					writer.Write(answer[0] + " " + answer[1] + ")");
					writer.Close();
				}

				return true;
			}
			return false;
		}

		public bool CheckLogin(string login, string password)
		{
			if (login == this._login && password == this._password)
			{
				return true;
			}
			return false;
		}
	}

}










