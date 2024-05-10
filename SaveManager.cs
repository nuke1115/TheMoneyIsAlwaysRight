
using AboutAssetUtills;

namespace AboutSaveManager
{
	public static class SaveManager
	{
		public static void SaveData(IPlayerTag player , string path)
		{
			ISaveJsonFile jsonFileManager = new JsonFileManager();
			string saveDataPath = Path.Combine(path, "Assets\\PlayerSaveFile.json");
			jsonFileManager.SaveJsonFile(saveDataPath, player);
		}


	}
}