using AboutAssetUtills;
using AboutPlayer;
using MainProgram;
using System.IO;

namespace AboutExecuteManager
{
	public class ExecuteManager : IExecuteLogics
	{
		private List<string> _commandConditions;
		private Player _player; // to be changed to interface
		ITerminateProgram _terminateProgram;
		private int _nowStage;

		public ExecuteManager()
		{
			
		}

		public void InitializeWithInject(Player player , ITerminateProgram program, string path)
		{
			_terminateProgram = program;
			_player = player;
			_nowStage = _player.nowStage;

			path = Path.Combine(path, "Assets\\CommandConditions.xlsx");
			using (excelFileLoadManager excelFileLoader = new excelFileLoadManager(path, 1))
			{
				_commandConditions = excelFileLoader.LoadExcelFile(1);
			}
		}
		


		public bool ExecuteLogics(string[] commands)
		{
			bool isExecutedSuccessfully = true;


			if (commands[0] == _commandConditions[0])
			{
				_terminateProgram.TerminateProgram();
			}
            else if (commands[0] == _commandConditions[1])
            {
				Console.WriteLine("this is test 1"); //test
            }
			else if (commands[0] == _commandConditions[2])
			{
				Console.WriteLine("this is test 2"); //test
			}
			else if (commands[0] == _commandConditions[3])
			{
				Console.WriteLine("this is test 3"); //test
			}

			return isExecutedSuccessfully;
		}

		private void ReturnStageInstance()
		{

		}

		private bool CheckIsStageChanged()
		{
			bool isChanged = false;

			//logics 

			return isChanged;
		}
	}
}