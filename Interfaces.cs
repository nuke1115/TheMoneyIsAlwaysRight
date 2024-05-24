
using AboutPlayer;

public interface ITerminateProgram
{
	public void TerminateProgram();
}

public interface IPlayerTag
{
	public int GetNowStage();
	public void SaveNowStage(int nowStage);
	public bool GetBaguetteState();
	public void SaveBaguetteState(bool baguetteState);
	public bool GetReturnItemState();
	public void SaveReturnItemState(bool returnItemState);
	public bool GetCaveBranchState();
	public void SaveCaveBranchState(bool CaveBranchState);
	public void ResetPlayer();

}

public interface IGetInstance
{
	public IExecutableStage GetInstance(int nowStage);
}

public interface IExecutableStage
{
	public bool ExecuteStageLogics(string selectedBranch, ref int nowStage, ref int branchNumber, ref int stageCode);
}

public interface IInitialize
{
	public void Initialize(params object[] parameters);
}

public interface IExecuteLogics
{
	public bool ExecuteLogics(string[] commands , ref int sectionNumber , ref int branchNumber);
}

public interface IGetCommandInput
{
	public string[] GetCommandInput();
}


public interface ILoadExcelFile
{

	public List<string> LoadExcelFile(int columnNum);
}

public  interface ILoadJsonFile
{
	public Player LoadJsonFile(string path);
}

public interface ISaveJsonFile
{
	public void SaveJsonFile(string path, IPlayerTag player);
}

public interface IReset
{
	public void Reset();
}
//으아아아ㅡ아아아ㅡㅏ아ㅣ이ㅏ아어라ㅣ이라아르아른이ㅏ르이ㅏ러ㅢㅏ나ㅣ