using Excel = Microsoft.Office.Interop.Excel;

public interface ITerminateProgram
{
	public void TerminateProgram();
}




public interface ILoadExcelFile
{

	public Excel.Worksheet LoadExcelFile();
	public List<string> LoadExcelFile(int columnNum);
}