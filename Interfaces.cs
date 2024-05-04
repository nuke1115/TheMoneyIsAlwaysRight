using AboutPlayer;
using Excel = Microsoft.Office.Interop.Excel;

public interface ITerminateProgram
{
	public void TerminateProgram();
}

public interface IPlayerTag
{
	//empty
}

public interface IInitialize
{
	public void Initialize();
}

public interface IInitializeWithInject
{
	public void InitializeWithInject(Player player);
}

public interface IExecuteLogics
{
	public bool ExecuteLogics(string[] commands);
}

public interface IGetCommandInput
{
	public string[] GetCommandInput();
}

public interface ILoadExcelFile
{

	public Excel.Worksheet LoadExcelFile();
	public List<string> LoadExcelFile(int columnNum);
}