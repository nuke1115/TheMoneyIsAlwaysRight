


using AboutCommandManager;

namespace MainProgram
{
	public class Program : ITerminateProgram
	{

		private bool _running = true;
		private string[] commandArgs;

		public static void Main()
		{
			Program program = new Program();
			program.Initialize();
			program.Start();
		}


		private void Start()//main loop
		{
			

			while (_running)
			{
				//getCommandInput method
				commandArgs = GetCommandInput();
				//executeLogics or Update method
				//print or printResult or updateScreen method

			}

		}

		private string[] GetCommandInput()
		{
			string[] input = CommandManager.GetCommandInput();

			return input;

		}


		private void Initialize()
		{

		}

		public void TerminateProgram()
		{
			_running = false;
		}


	}
}