using AboutAssetUtills;
using AboutPlayer;
using MainProgram;
using System.IO;
using System.Numerics;

namespace AboutExecuteManager
{
	public class ExecuteManager : IExecuteLogics , IInitialize
	{
		private List<string> _commandConditions;
		private IPlayerTag _player; // to be changed to interface
		private ITerminateProgram _terminateProgram;
		private int _nowStage;

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
			using (excelFileLoadManager excelFileLoader = new excelFileLoadManager(path, 1))
			{
				_commandConditions = excelFileLoader.LoadExcelFile(1);
			}
		}
		

		public void Initialize(params object[] parameters)
		{
			_player = (IPlayerTag)parameters[0];
			_terminateProgram = (ITerminateProgram)parameters[1];
			_nowStage = _player.GetNowStage();
			string path = (string)parameters[2];

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