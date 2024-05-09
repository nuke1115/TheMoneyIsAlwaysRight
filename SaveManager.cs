
using AboutAssetUtills;

namespace AboutSaveManager
{
	public static class SaveManager
	{
		public static void SaveData(IPlayerTag player , string path)
		{
			jsonFileManager jsonFileManager = new jsonFileManager();
			string saveDataPath = Path.Combine(path, "Assets\\PlayerSaveFile.json");
			jsonFileManager.WriteJson(saveDataPath, player);
		}


	}
}