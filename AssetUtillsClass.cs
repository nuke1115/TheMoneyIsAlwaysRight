
using Newtonsoft.Json;
using AboutPlayer;
using NPOI.SS.UserModel;


namespace AboutAssetUtills
{
	/// <summary>
	/// an excel loader class <br/>
	/// reads excel file from path, and returns List(string) that contains excel data
	/// </summary>
	public class ExcelFileLoadManager : ILoadExcelFile//TODO : change interop.excel to other free libraries
	{

		private string _filePath;
		private int _sheetNumber;
		private const string _ENDOFFILE = "#EOF";
		private const int _DEFAULTSHEETNUM = 0;

		public ExcelFileLoadManager(string Path, int sheetNumber)
		{
			_filePath = Path;
			_sheetNumber = sheetNumber;
		}




		public List<string> LoadExcelFile(int columnNum) //in this case , columnNum equals cell number
		{
			List<string> loadedExcelFile = new List<string>();

			ReadExcelFile(out loadedExcelFile, columnNum);

			return loadedExcelFile;

		}


		private void ReadExcelFile(out List<string> loadedExcelFile, int columnNum)
		{
			loadedExcelFile = new List<string>();

			using (var workbook = WorkbookFactory.Create(_filePath))
			{

				ISheet sheet = workbook.GetSheetAt(_sheetNumber);

				foreach (IRow row in sheet)
				{

					var cell = row.GetCell(columnNum);

					string cellData = cell == null ? "" : cell.ToString();
					if (cellData == _ENDOFFILE)
					{
						break;
					}
					loadedExcelFile.Add(cellData);
				}
			}



		}


		//idisposable 과 gc 더 알아보기



	}



	public class jsonFileManager
	{
		//todo

		public Player readJson(string path)
		{
			Player returnClass;
			using (StreamReader file = File.OpenText(path))
			{
				JsonSerializer serializer = new JsonSerializer();
				returnClass = (Player)serializer.Deserialize(file, typeof(Player));
			}
			return returnClass;
		}

		public void WriteJson(string path , IPlayerTag player)
		{
			using (StreamWriter file = File.CreateText(path))
			{
				JsonSerializer serializer = new JsonSerializer();
				serializer.Serialize(file, player);
			}
		}

	}





}
/*
 * ToDo:
 * 엑셀파일 로드 로직 짜기//일단 된듯?
 * 함수 오버로딩
 * json 로드 로직 짜기
 */