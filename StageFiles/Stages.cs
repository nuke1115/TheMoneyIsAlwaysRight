
using AboutPlayer;
using AboutPrintManager;

namespace AboutStages
{
	
	

	public class Stage0 : IExecutableStage
	{
		private const int _NOW_STAGE_CODE = 0;

		public Stage0()//버튼 누르라고 알려주는 그런것
		{
		}

		public bool ExecuteStageLogics(string selectedBranch, ref int nowStage, ref int branchNumber , ref int stageCode)
		{
			
			bool isExecutedSuccessfully = true;
			stageCode = _NOW_STAGE_CODE;

			if (selectedBranch == "0")
			{
				nowStage += Branch0(ref branchNumber);
			}
			else if (selectedBranch == "1")
			{
				nowStage += Branch1(ref branchNumber);
			}
			else
			{
				isExecutedSuccessfully = false;	
			}

			return isExecutedSuccessfully;
		}

		private int Branch0(ref int branchNumber)
		{
			branchNumber = (int)StageMovementCode.BRANCH_0;
			return (int)StageMovementCode.STAY_HERE;
		}

		private int Branch1(ref int branchNumber)
		{
			branchNumber = (int)StageMovementCode.BRANCH_1;
			return (int)StageMovementCode.TO_NEXT;
		}

	}

	public class Stage1 : IExecutableStage
	{
		private const int _NOW_STAGE_CODE = 1;

		public Stage1()
		{
		}

		public bool ExecuteStageLogics(string selectedBranch, ref int nowStage, ref int branchNumber, ref int stageCode)
		{

			bool isExecutedSuccessfully = true;
			stageCode = _NOW_STAGE_CODE;


			if (selectedBranch == "1")
			{
				nowStage += Branch1(ref branchNumber);
			}
			else if (selectedBranch == "2")
			{
				nowStage *= Branch2(ref branchNumber);
			}
			else
			{
				isExecutedSuccessfully = false;
			}

			return isExecutedSuccessfully;
		}


		private int Branch1(ref int branchNumber)
		{
			branchNumber = (int)StageMovementCode.BRANCH_1;
			return (int)StageMovementCode.TO_NEXT;
		}

		private int Branch2(ref int branchNumber)
		{
			branchNumber = (int)StageMovementCode.BRANCH_2;
			return (int)StageMovementCode.SHOW_ME_THE_ENDING;
		}

	}


	enum StageMovementCode : int
	{
		TO_NEXT = 1,
		STAY_HERE = 0,
		TO_PREV = -1,
		SHOW_ME_THE_ENDING = 0,
		BRANCH_0 = 0,
		BRANCH_1 = 1,
		BRANCH_2 = 2,
		BRANCH_3 = 3,
		BRANCH_4 = 4
	}

}