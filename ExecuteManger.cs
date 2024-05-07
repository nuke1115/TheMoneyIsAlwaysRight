using AboutAssetUtills;
using System.IO;


namespace AboutExecuteManager
{
	public class ExecuteManager : IExecuteLogics , IInitialize
	{
		private List<string> _commandConditions;
		private IPlayerTag _player; // to be changed to interface
		private ITerminateProgram _terminateProgram;
		private int _nowStage;
		private string _path;
		
		public ExecuteManager()
		{
			
		}

		[Obsolete("Not use anymore",true)]
		public void InitializeWithInject(IPlayerTag player , ITerminateProgram program, string path)
		{
			_terminateProgram = program;
			_player = player;
			_nowStage = _player.GetNowStage();

			path = Path.Combine(path, "Assets\\CommandConditions.xlsx");

			ExcelFileLoadManager excelFileLoadManager = new ExcelFileLoadManager(path, 0);
			_commandConditions = excelFileLoadManager.LoadExcelFile(0);

		}
		

		public void Initialize(params object[] parameters)
		{
			_player = (IPlayerTag)parameters[0];
			_terminateProgram = (ITerminateProgram)parameters[1];
			_nowStage = _player.GetNowStage();
			_path = (string)parameters[2];

			string CommandConditionsPath = Path.Combine(_path, "Assets\\CommandConditions.xlsx");
			ExcelFileLoadManager excelFileLoadManager = new ExcelFileLoadManager(CommandConditionsPath, 0);
			_commandConditions = excelFileLoadManager.LoadExcelFile(0);



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
				_nowStage++;
            }
			else if (commands[0] == _commandConditions[2])
			{
				Console.WriteLine("this is test 2"); //test
				_nowStage++;
			}
			else if (commands[0] == _commandConditions[3])
			{
				Console.WriteLine("this is test 3"); //test
				_nowStage++;
			}//end of options
			else
			{
				isExecutedSuccessfully = false;
			}


			_player.SaveNowStage(_nowStage);

			//stage change logics



			return isExecutedSuccessfully;
		}

		private void ReturnStageInstance(int nowStage)
		{
			if (CheckIsStageChanged(nowStage))
			{
				//return stage instance logics
				_player.SaveNowStage(nowStage);
			}
		}

		private bool CheckIsStageChanged(int nowStage)
		{
			return nowStage == _player.GetNowStage();
		}
	}
}