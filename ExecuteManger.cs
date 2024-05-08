using AboutAssetUtills;


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


		public void Initialize(params object[] parameters)
		{
			_player = (IPlayerTag)parameters[0];
			_terminateProgram = (ITerminateProgram)parameters[1];
			_nowStage = _player.GetNowStage();
			_path = (string)parameters[2];

			string CommandConditionsPath = Path.Combine(_path, "Assets\\CommandConditions.xlsx");
			ILoadExcelFile excelFileLoadManager = new ExcelFileLoadManager(CommandConditionsPath, 0);
			_commandConditions = excelFileLoadManager.LoadExcelFile(0);



		}



		public bool ExecuteLogics(string[] commands)
		{
			bool isExecutedSuccessfully = true;


			if (commands[0] == _commandConditions[0])
			{
				_terminateProgram.TerminateProgram();
			}
            else if (commands[0] == _commandConditions[1] || commands[0] == _commandConditions[2] || commands[0] == _commandConditions[3])
            {
				Console.WriteLine("test");
				_nowStage++;
            }
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
				if (nowStage == 1)
				{

				}



				_player.SaveNowStage(nowStage);
			}

		}

		private bool CheckIsStageChanged(int nowStage)
		{
			return nowStage == _player.GetNowStage();
		}
	}
}