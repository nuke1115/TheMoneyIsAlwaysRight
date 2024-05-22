using AboutAssetUtills;
using AboutPrintManager;

namespace AboutCommandManager
{
	public class CommandManager : IGetCommandInput , IInitialize
	{
		private List<string> _uiMessages;
		public string[] GetCommandInput()
		{

			PrintManager.PrintToConsole(_uiMessages, 2);

			string[] input = Console.ReadLine().Split(" ");

			return input;

		}

		public void Initialize(params object[] parameters)
		{
			string path = (string)parameters[0];
			path = Path.Combine(path , "Assets\\UIMessages.xlsx");
			ILoadExcelFile excelFileLoadManager = new ExcelFileLoadManager(path,0);
			_uiMessages = excelFileLoadManager.LoadExcelFile(0);
		}

	}
}