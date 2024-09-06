namespace quiz
{
	internal class Quiz
	{
		private string? _login = null;
		private string? _password = null;
		private string? _dataBirth = null;

		public bool Registration(string filePath = "./Users.txt")
		{
			if (File.Exists(filePath))
			{
				Console.WriteLine("Enter login");
				this._login = Console.ReadLine();
				Console.WriteLine("Enter pssword");
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
	}
}


