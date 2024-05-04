

using AboutInitializeManager;
using AboutExecuteManager;
using AboutCommandManager;

namespace MainProgram
{
	public class Program : ITerminateProgram
	{

		private bool _running = true;
		private string[] _commandArgs;
		private bool _isExecutedSuccessfully;
		private IGetCommandInput _getCommandInput;
		private IExecuteLogics _executeManager;


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
				ExecuteLogics(_commandArgs);
				PrintResult();
			}

		}

		private void PrintResult()
		{

		}

		private void ExecuteLogics(string[] commandArgs)
		{
			_isExecutedSuccessfully = _executeManager.ExecuteLogics(commandArgs);
		}

		private string[] GetCommandInput()
		{
			string[] input = _getCommandInput.GetCommandInput();

			return input;

		}


		private void Initialize(ITerminateProgram terminateProgram)
		{
			InitializeManager initializeManager = new InitializeManager();
			ExecuteManager executeManager = new ExecuteManager();
			CommandManager commandManager = new CommandManager();

			_getCommandInput = commandManager;
			_getCommandInput = commandManager;
			_executeManager = executeManager;

			initializeManager.Initialize(executeManager, commandManager , terminateProgram);

			
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
static 붙은거 수정 가능한건 최대한 고치기
di패턴 내 지식상에서 구현 가능한거로 최대한해보기
싱글톤패턴 지우기
 */