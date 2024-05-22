

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
		private List<string> _story;
		private int _sectionNumber;
		private int _branchNumber;
		private bool _isGameEnd = false;
		

		public static void Main()	
		{
			Program program = new Program();
			ITerminateProgram terminateProgram = program;
			program.Initialize(terminateProgram);
			program.Start();
		}


		private void Start()//main loop
		{
			InitialMessage();

			while (_running)
			{
				_commandArgs = GetCommandInput();
				_isExecutedSuccessfully = ExecuteLogics(_commandArgs);
				if (!_isExecutedSuccessfully || _isGameEnd)
				{
					continue;
				}
				PrintResult();
				
			}
			EndOfGame(_player , _path);
		}

		private void InitialMessage()
		{
			if (_player.GetNowStage() != 0)
			{
				PrintManager.PrintToConsole(_story, _player.GetNowStage() - 1, 1);
			}
		}

		private void PrintResult()
		{
			PrintManager.PrintToConsole(_story, _sectionNumber, _branchNumber);
		}

		private void EndOfGame(IPlayerTag player , string path)
		{
			SaveManager.SaveData(player, path);
			PrintManager.PrintToConsole(_UIMessages , 3);
		}

		private bool ExecuteLogics(string[] commandArgs)
		{
			_isExecutedSuccessfully = _executeManager.ExecuteLogics(commandArgs , ref _sectionNumber , ref _branchNumber);
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
			string StoryPath = Path.Combine(_path, "Assets\\Stories.xlsx");

			ILoadExcelFile excelFileLoadManager = new ExcelFileLoadManager(UIMessagePath, 0);
			_UIMessages = excelFileLoadManager.LoadExcelFile(0);
			excelFileLoadManager = new ExcelFileLoadManager(StoryPath, 0);
			_story = excelFileLoadManager.LoadExcelFile(0);


		}


		public void TerminateProgram()
		{
			_running = false;
			_isGameEnd = true;
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