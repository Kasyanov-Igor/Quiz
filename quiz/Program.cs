using quiz;

QuizEditor file = new QuizEditor();
Console.WriteLine("ADMIN");
string? loginAdmin = Console.ReadLine();
string? passwordAdmin = Console.ReadLine();
if (file.CheckLogin(loginAdmin, passwordAdmin))
{
	file.PrintMenu();
	Console.Clear();
}

Quiz quizGame = new Quiz();

while (true)
{
	if (quizGame.CheckingUserExistence())
	{
		quizGame.PrintMenu();
		Console.Clear();
		Console.WriteLine("program terminated");
		break;
	}
	Console.WriteLine("User does not exist, please register\n register?");
	string? UserAnswer = Console.ReadLine();

	if (UserAnswer == "yes")
	{
		Console.Clear();
		Console.WriteLine("Enter login to register");
		string? login = Console.ReadLine();
		Console.WriteLine("Enter pssword to register");
		string? password = Console.ReadLine();
		Console.WriteLine("Data to Birth");
		string? dataBirth = Console.ReadLine();

		quizGame = new Quiz(login, password, dataBirth);
		quizGame.Registration();
	}
	Console.Clear();
}


