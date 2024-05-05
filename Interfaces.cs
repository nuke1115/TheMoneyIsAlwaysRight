﻿using Excel = Microsoft.Office.Interop.Excel;

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

	public Excel.Worksheet LoadExcelFile();
	public List<string> LoadExcelFile(int columnNum);
}