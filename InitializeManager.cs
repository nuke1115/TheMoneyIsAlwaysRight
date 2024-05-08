using AboutAssetUtills;
using AboutCommandManager;
using AboutExecuteManager;
using AboutPlayer;

namespace AboutInitializeManager
{
	public static class InitializeManager
	{
		public static void Initialize(out IExecuteLogics executeLogicsManager, out IGetCommandInput getCommandInputManager,out IPlayerTag pPlayer, ITerminateProgram program ,string path)
		{
			ExecuteManager executeManager = new ExecuteManager();
			CommandManager commandManager = new CommandManager();

			string saveDataPath = Path.Combine(path, "Assets\\PlayerSaveFile.json");
			jsonFileManager jsonFileManager = new jsonFileManager();

			Player player = jsonFileManager.readJson(saveDataPath);
			
			
			IPlayerTag playerTag = player;
			IInitialize commandManagerInitialize = commandManager;
			IInitialize executeManagerInitialize = executeManager;

			executeManagerInitialize.Initialize(playerTag, program, path);
			commandManagerInitialize.Initialize(path);


			executeLogicsManager = executeManager;
			getCommandInputManager = commandManager;
			pPlayer = player;

		}
	}
}