using AboutAssetUtills;
using AboutStages;

namespace AboutStageFactory
{
	public class StageFactory : IGetInstance , IInitialize
	{
		private List<string> _story;
		private IExecutableStage[] _instances;
		public IExecutableStage GetInstance(int nowStage)
		{
			return _instances[nowStage];
		}

		public void Initialize(params object[] parameters)
		{
			#region excel_load
			string storyPath = Path.Combine((string)parameters[0],"Assets\\Stories.xlsx");

			ExcelFileLoadManager excelFileLoadManager = new ExcelFileLoadManager(storyPath , 0);
			_story = excelFileLoadManager.LoadExcelFile(0);

			#endregion excel_load

			_instances = new IExecutableStage[4];

			_instances[0] = new Stage0(_story);
			_instances[1] = new Stage1(_story);
			_instances[2] = new Stage2(_story); 
			_instances[3] = null;//temporary test
		}
		
	}
}