using AboutAssetUtills;
using AboutCommandManager;
using AboutExecuteManager;
using AboutPlayer;
using AboutStageFactory;

namespace AboutInitializeManager
{
	public static class InitializeManager
	{
		public static void Initialize(out IExecuteLogics executeLogicsManager, out IGetCommandInput getCommandInputManager,out IPlayerTag pPlayer, ITerminateProgram program ,string path)
		{
			ExecuteManager executeManager = new ExecuteManager();
			CommandManager commandManager = new CommandManager();
			StageFactory stageFactory = new StageFactory();

			string saveDataPath = Path.Combine(path, "Assets\\PlayerSaveFile.json");
			ILoadJsonFile jsonFileManager = new JsonFileManager();

			Player player = jsonFileManager.LoadJsonFile(saveDataPath);
			
			
			IPlayerTag playerTag = player;
			IInitialize commandManagerInitialize = commandManager;
			IInitialize executeManagerInitialize = executeManager;
			IInitialize stageFactoryInitialize = stageFactory;

			
			commandManagerInitialize.Initialize(path);
			stageFactoryInitialize.Initialize(path , playerTag);
			executeManagerInitialize.Initialize(playerTag, program, path, stageFactory);

			executeLogicsManager = executeManager;
			getCommandInputManager = commandManager;
			pPlayer = player;

		}
	}
}