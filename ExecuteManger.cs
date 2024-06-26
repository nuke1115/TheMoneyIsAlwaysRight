﻿using AboutAssetUtills;
using AboutStageFactory;


namespace AboutExecuteManager
{
	public class ExecuteManager : IExecuteLogics , IInitialize
	{
		private List<string> _commandConditions;
		private IPlayerTag _player; // to be changed to interface
		private ITerminateProgram _terminateProgram;
		private int _nowStage;
		private string _path;
		private IGetInstance _stageFactory;
		private IExecutableStage _stage;

		public ExecuteManager()
		{
			
		}


		public void Initialize(params object[] parameters)
		{
			_player = (IPlayerTag)parameters[0];
			_terminateProgram = (ITerminateProgram)parameters[1];
			_nowStage = _player.GetNowStage();
			_path = (string)parameters[2];
			_stageFactory = (IGetInstance)parameters[3];

			string CommandConditionsPath = Path.Combine(_path, "Assets\\CommandConditions.xlsx");
			ILoadExcelFile excelFileLoadManager = new ExcelFileLoadManager(CommandConditionsPath, 0);

			_commandConditions = excelFileLoadManager.LoadExcelFile(0);
			_stage = _stageFactory.GetInstance(_nowStage);

		}


		public bool ExecuteLogics(string[] commands , ref int sectionNumber , ref int branchNumber)
		{
			bool isExecutedSuccessfully = true;

			_stage = _stageFactory.GetInstance(_nowStage);

			if (commands[0] == _commandConditions[0])
			{
				_terminateProgram.TerminateProgram();
			}
            else if (commands[0] != _commandConditions[0] && _commandConditions.Contains(commands[0]))
            {
				isExecutedSuccessfully = _stage.ExecuteStageLogics(commands[0], ref _nowStage , ref branchNumber , ref sectionNumber);
            }
			else
			{
				isExecutedSuccessfully = false;
			}

			_player.SaveNowStage(_nowStage);

			return isExecutedSuccessfully;
		}

		
	}
}