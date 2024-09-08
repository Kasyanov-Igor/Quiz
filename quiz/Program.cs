using quiz;

Quiz quizGame = new Quiz();

while (true)
{
	if (quizGame.CheckingUserExistence())
	{
		quizGame.PrintMenu();
	}
	Console.WriteLine("User does not exist, please register\n register?");
	string? UserAnswer = Console.ReadLine();
	if (UserAnswer == "yes")
	{
		quizGame.Registration();
	}
	Console.Clear();
}

