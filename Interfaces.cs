
public interface ITerminateProgram
{
	public void TerminateProgram();
}

public interface IPlayerTag
{
	public int GetNowStage();
	public void SaveNowStage(int nowStage);
}

public interface IInitialize
{
	public void Initialize(params object[] parameters);
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

	public List<string> LoadExcelFile(int columnNum);
}
//으아아아ㅡ아아아ㅡㅏ아ㅣ이ㅏ아어라ㅣ이라아르아른이ㅏ르이ㅏ러ㅢㅏ나ㅣ