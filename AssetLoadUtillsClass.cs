using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using AboutPlayer;

namespace AboutAssetUtills
{
	/// <summary>
	/// an excel loader class <br/>
	/// reads excel file from path, and returns List(string) that contains excel data
	/// </summary>
	public class excelFileLoadManager : ILoadExcelFile, IDisposable
	{

		Excel.Application excelApp = new Excel.Application();
		Excel.Workbook workbook;
		Excel.Worksheet worksheet;
		private const int _defaultRowNumber = 1;


		public excelFileLoadManager(string Path)
		{
			workbook = excelApp.Workbooks.Open(Path);
		}

		public excelFileLoadManager(string Path, int sheetNumber)
		{
			workbook = excelApp.Workbooks.Open(Path);
			worksheet = workbook.Worksheets[sheetNumber];
		}


		public void SetWoksheet(int sheetNumber)
		{
			worksheet = workbook.Worksheets[sheetNumber];
		}



		public Excel.Worksheet LoadExcelFile()
		{
			return worksheet;
		}



		public List<string> LoadExcelFile(int columnNum)
		{
			List<string> loadedExcelFile = new List<string>();

			ReadExcelFile(out loadedExcelFile, columnNum);

			return loadedExcelFile;

		}


		private void ReadExcelFile(out List<string> loadedExcelFile, int columnNum)
		{
			loadedExcelFile = new List<string>();

			int rowNum = _defaultRowNumber;
			int maxRowCount = worksheet.UsedRange.Rows.Count;
			dynamic? loadedData;

			for (; rowNum <= maxRowCount; rowNum++)
			{
				loadedData = worksheet.Cells[rowNum, columnNum].Value2;
				if (loadedData != null)
				{
					string data = loadedData.ToString();
					loadedExcelFile.Add(data);
				}

			}
		}




		#region dispose
		//dispose resources 객체 해제



		private bool _disposed = false;
		[DllImport("user32.dll", SetLastError = true)]
		static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this); //GC가 이 객체를 이중으로 해제하지 않기위한것//맞나?

		}

		protected virtual void Dispose(bool disposing)
		{

			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				//dispose managed resource
			}

			//dispose unmanaged resource
			uint processId = 0;
			GetWindowThreadProcessId(new IntPtr(excelApp.Hwnd), out processId);

			excelApp.DisplayAlerts = false;

			workbook.Close();
			excelApp.Quit();


			if (worksheet != null)
			{
				Marshal.FinalReleaseComObject(worksheet);
				worksheet = null;
			}

			if (workbook != null)
			{
				Marshal.FinalReleaseComObject(workbook);
				workbook = null;
			}

			if (excelApp != null)
			{
				Marshal.FinalReleaseComObject(excelApp);
				excelApp = null;
			}

			if (processId != 0)
			{
				System.Diagnostics.Process excelProcess = System.Diagnostics.Process.GetProcessById((int)processId);
				excelProcess.CloseMainWindow();
				excelProcess.Refresh();
				excelProcess.Kill();
			}


			_disposed = true;
		}





		//idisposable 과 gc 더 알아보기

		#endregion



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