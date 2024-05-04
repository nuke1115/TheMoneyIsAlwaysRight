using AboutAssetUtills;
using AboutCommandManager;
using AboutExecuteManager;
using AboutPlayer;

namespace AboutInitializeManager
{
	public class InitializeManager
	{
		public void Initialize(ExecuteManager executeManager , CommandManager commandManager ,ITerminateProgram program )
		{
			string path = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("\\TheMoneyIsAlwaysRight\\") + "\\TheMoneyIsAlwaysRight\\".Length);
			string saveDataPath = Path.Combine(path, "Assets\\PlayerSaveFile.json");
			jsonFileManager jsonFileManager = new jsonFileManager();
			Player player = jsonFileManager.readJson(saveDataPath);

			executeManager.InitializeWithInject(player , program, path);
			commandManager.Initialize(path);
		}
	}
}