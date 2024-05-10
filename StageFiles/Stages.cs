
using AboutPrintManager;

namespace AboutStages
{
	public abstract class BaseStage : IExecutableStage
	{
		List<string> _story;

		public int ExecuteInitialStageLogics(int nowStage)
		{
			throw new NotImplementedException();
		}

		public abstract int ExecuteStageLogics(string selectedBranch , int nowStage, ref bool isExecutedSuccessfully);
	}

	public class Stage0 : IExecutableStage
	{
		List<string> _story;
		private const int _NOW_STAGE_CODE = 0;
		private const int _TO_NEXT = 1;

		public Stage0(List<string> story)
		{
			_story = story;
		}

		public int ExecuteInitialStageLogics(int nowStage)
		{
			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE, 0);

			return nowStage;
			
		}

		public int ExecuteStageLogics(string selectedBranch, int nowStage, ref bool isExecutedSuccessfully)
		{
			if (selectedBranch == "1")
			{
				nowStage = Branch1(nowStage);
			}
			else
			{
				isExecutedSuccessfully = false;
			}

			return nowStage;
		}	

		private int Branch1(int nowStage)
		{
			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE, 1);
			return nowStage + _TO_NEXT;
		}
	}

	public class Stage1 : IExecutableStage
	{
		List<string> _story;
		private const int _TO_NEXT = 1;
		private const int _NO_MOVE = 0;
		private const int _RESET = -1;
		private const int _NOW_STAGE_CODE = 1;

		public Stage1(List<string> story)
		{
			_story = story;
		}

		public int ExecuteInitialStageLogics(int nowStage)
		{

			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE - 1, 1);
			return nowStage;
		}

		public int ExecuteStageLogics(string selectedBranch, int nowStage, ref bool isExecutedSuccessfully)
		{
			
			if (selectedBranch == "1")
			{
				nowStage = Branch1(nowStage);
			}
            else if (selectedBranch == "2")
            {
				nowStage = Branch2(nowStage);
            }
			else if (selectedBranch == "3")
			{
				nowStage = Branch3(nowStage);
			}
			else
			{
				isExecutedSuccessfully = false;
			}

			return nowStage;
		}

		private int Branch1(int nowStage)
		{
			PrintManager.PrintToConsole(_story , _NOW_STAGE_CODE , 1);
			return nowStage + _TO_NEXT;
		}

		private int Branch2(int nowStage)
		{
			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE , 2);
			return nowStage + (nowStage*_RESET) ;
		}

		private int Branch3(int nowStage)
		{
			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE , 3);
			return nowStage + _NO_MOVE;
		}
	}

	
	public class Stage2 : IExecutableStage
	{
		List<string> _story;
		private const int _TO_NEXT = 1;
		private const int _TO_PREV = -1;
		private const int _NO_MOVE = 0;
		private const int _RESET = -1;
		private const int _NOW_STAGE_CODE = 2;

		public Stage2(List<string> story)
		{
			_story = story;
		}

		public int ExecuteInitialStageLogics(int nowStage)
		{

			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE - 1, 1);
			return nowStage;
		}

		public int ExecuteStageLogics(string selectedBranch, int nowStage, ref bool isExecutedSuccessfully)
		{

			if (selectedBranch == "1")
			{
				nowStage = Branch1(nowStage);
			}
			else if (selectedBranch == "2")
			{
				nowStage = Branch2(nowStage);
			}
			else if (selectedBranch == "3")
			{
				nowStage = Branch3(nowStage);
			}
			else if (selectedBranch == "4")
			{
				nowStage = Branch4(nowStage);
			}
			else
			{
				isExecutedSuccessfully = false;
			}

			return nowStage;
		}

		private int Branch1(int nowStage)
		{
			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE, 1);
			return nowStage + _TO_NEXT;
		}

		private int Branch2(int nowStage)
		{
			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE , 2);
			return nowStage + (nowStage * _RESET);
		}

		private int Branch3(int nowStage)
		{
			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE , 3);
			return nowStage + _NO_MOVE;
		}

		private int Branch4(int nowStage)
		{
			PrintManager.PrintToConsole(_story, _NOW_STAGE_CODE , 4);
			return nowStage + _TO_PREV;
		}
	}

}