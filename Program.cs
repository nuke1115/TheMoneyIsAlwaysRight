﻿

using AboutInitializeManager;
using AboutSaveManager;
using AboutAssetUtills;
using AboutPrintManager;
using System.IO;

namespace MainProgram
{
	public class Program : ITerminateProgram
	{

		private bool _running = true;
		private string[] _commandArgs;
		private bool _isExecutedSuccessfully;
		private IGetCommandInput _getCommandInput;
		private IExecuteLogics _executeManager;
		private IPlayerTag _player;
		private string _path;
		private List<string> _UIMessages;
		

		public static void Main()	
		{
			Program program = new Program();
			ITerminateProgram terminateProgram = program;
			program.Initialize(terminateProgram);
			program.Start();
		}


		private void Start()//main loop
		{
			

			while (_running)
			{
				_commandArgs = GetCommandInput();
				_isExecutedSuccessfully = ExecuteLogics(_commandArgs);
				if (!_isExecutedSuccessfully)
				{
					continue;
				}
				
			}
			EndOfGame(_player , _path);



		}

		private void EndOfLoop()
		{

		}

		private void EndOfGame(IPlayerTag player , string path)
		{
			SaveManager.SaveData(player, path);
			PrintManager.PrintToConsole(_UIMessages , 3);
		}

		private bool ExecuteLogics(string[] commandArgs)
		{
			_isExecutedSuccessfully = _executeManager.ExecuteLogics(commandArgs);
			return _isExecutedSuccessfully;
		}

		private string[] GetCommandInput()
		{
			string[] input = _getCommandInput.GetCommandInput();

			return input;

		}


		private void Initialize(ITerminateProgram terminateProgram)
		{
			
			_path = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("\\TheMoneyIsAlwaysRight\\") + "\\TheMoneyIsAlwaysRight\\".Length);
			InitializeManager.Initialize(out _executeManager ,out _getCommandInput ,out _player  ,terminateProgram , _path);

			string UIMessagePath = Path.Combine(_path, "Assets\\UIMessages.xlsx");


			ExcelFileLoadManager excelFileLoadManager = new ExcelFileLoadManager(UIMessagePath, 0);
			_UIMessages = excelFileLoadManager.LoadExcelFile(0);


		}


		public void TerminateProgram()
		{
			_running = false;
		}


	}
}

/*
 TODO: 
initialize 메서드 관련 코드 전부 뜯어고치기
di패턴 내 지식상에서 구현 가능한거로 최대한해보기
싱글톤패턴 지우기

무료 엑셀 라이브러리 찾기 fuckkkkkkkkkkkkkkkkkkkkkkk //후보: NPOI
 */