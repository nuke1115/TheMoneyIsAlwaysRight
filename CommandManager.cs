using AboutAssetUtills;
using AboutPrintManager;

namespace AboutCommandManager
{
	public class CommandManager : IGetCommandInput
	{
		private List<string> _uiMessages;
		public string[] GetCommandInput()
		{

			//print description method
			//the ment will be loaded from excel file
			PrintManager.PrintToConsole(_uiMessages, 2);

			//PrintManager.PrintToConsole();
			//TODO

			string[] input = Console.ReadLine().Split(" ");




			return input;

		}

		public void Initialize(string path)
		{
			path = Path.Combine(path , "Assets\\UIMessages.xlsx");
			using (excelFileLoadManager excelFileLoadManager = new excelFileLoadManager(path , 1))
			{
				_uiMessages = excelFileLoadManager.LoadExcelFile(1);
			}
		}

	}
}