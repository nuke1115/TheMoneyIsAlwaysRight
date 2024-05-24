
using AboutPlayer;

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
		private IPlayerTag _player;
		public Stage1(IPlayerTag player)
		{
			_player = player;
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
			_player.ResetPlayer(); 
			Console.Clear();
			return (int)StageMovementCode.SHOW_ME_THE_ENDING;
		}

	}

	public class Stage2 : IExecutableStage
	{
		private const int _NOW_STAGE_CODE = 2;
		private IPlayerTag _player;

		public Stage2(IPlayerTag player)
		{
			_player = player;
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
				if (_player.GetCaveBranchState() == false)
				{
					nowStage += Branch2(ref branchNumber);
				}
				else
				{
					nowStage += Branch3(ref branchNumber);
				}
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
			return (int)StageMovementCode.TO_NEXT_OVER_SUB;
		}

		private int Branch2(ref int branchNumber)
		{
			branchNumber = (int)StageMovementCode.BRANCH_2;
			return (int)StageMovementCode.TO_SUB;
		}

		private int Branch3(ref int branchNumber)
		{
			branchNumber = (int)StageMovementCode.BRANCH_3;
			return (int)StageMovementCode.TO_NEXT_OVER_SUB;
		}
	}

	public class Stage2_Sub : IExecutableStage
	{
		private const int _NOW_STAGE_CODE = 3;
		private IPlayerTag _player;

		public Stage2_Sub(IPlayerTag player)
		{
			_player = player;
		}

		public bool ExecuteStageLogics(string selectedBranch, ref int nowStage, ref int branchNumber, ref int stageCode)
		{

			bool isExecutedSuccessfully = true;
			stageCode = _NOW_STAGE_CODE;
			_player.SaveCaveBranchState(true);

			if (selectedBranch == "1")
			{
				nowStage += Branch1(ref branchNumber);
			}
			else if (selectedBranch == "2")
			{
				nowStage += Branch2(ref branchNumber);
			}
			else
			{
				isExecutedSuccessfully = false;
			}

			return isExecutedSuccessfully;
		}


		private int Branch1(ref int branchNumber)
		{
			_player.SaveBaguetteState(true);
			branchNumber = (int)StageMovementCode.BRANCH_1;
			return (int)StageMovementCode.TO_PREV;
		}

		private int Branch2(ref int branchNumber)
		{
			branchNumber = (int)StageMovementCode.BRANCH_2;
			return (int)StageMovementCode.TO_PREV;
		}

	}

	public class Stage3 : IExecutableStage
	{
		private const int _NOW_STAGE_CODE = 4;
		private IPlayerTag _player;
		public Stage3(IPlayerTag player)
		{
			_player = player;
		}

		public bool ExecuteStageLogics(string selectedBranch, ref int nowStage, ref int branchNumber, ref int stageCode)
		{

			bool isExecutedSuccessfully = true;
			stageCode = _NOW_STAGE_CODE;


			if (selectedBranch == "1")
			{
				if(_player.GetBaguetteState() == true)
				{
					nowStage += Branch1(ref branchNumber);
				}
				else
				{
					nowStage *= Branch3(ref branchNumber);
				}
			}
			else if (selectedBranch == "2")
			{
				nowStage += Branch2(ref branchNumber);
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
			return (int)StageMovementCode.TO_NEXT;
		}

		private int Branch3(ref int branchNumber)
		{
			Console.Clear();
			_player.ResetPlayer();
			branchNumber = (int)StageMovementCode.BRANCH_3;
			return (int)StageMovementCode.SHOW_ME_THE_ENDING;
		}

	}

	public class Stage4 : IExecutableStage
	{
		private const int _NOW_STAGE_CODE = 5;
		private IPlayerTag _player;
		public Stage4(IPlayerTag player)
		{
			_player = player;
		}

		public bool ExecuteStageLogics(string selectedBranch, ref int nowStage, ref int branchNumber, ref int stageCode)
		{

			bool isExecutedSuccessfully = true;
			stageCode = _NOW_STAGE_CODE;


			if (selectedBranch == "1")
			{
				nowStage *= Branch1(ref branchNumber);
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
			Console.Clear();
			_player.ResetPlayer();
			branchNumber = (int)StageMovementCode.BRANCH_1;
			return (int)StageMovementCode.SHOW_ME_THE_ENDING;
		}

		private int Branch2(ref int branchNumber)
		{
			Random random = new Random();
			int endingBranch = random.Next(2,4);
			if (endingBranch == (int)StageMovementCode.BRANCH_2)
			{
				branchNumber = (int)StageMovementCode.BRANCH_2;
			}
			else
			{
				branchNumber = (int)StageMovementCode.BRANCH_3;
			}
			Console.Clear();
			_player.ResetPlayer();
			return (int)StageMovementCode.SHOW_ME_THE_ENDING;
		}


	}

	enum StageMovementCode : int
	{
		TO_NEXT_OVER_SUB = 2,
		TO_NEXT = 1,
		STAY_HERE = 0,
		TO_PREV = -1,
		TO_SUB = 1,
		SHOW_ME_THE_ENDING = 0,
		BRANCH_0 = 0,
		BRANCH_1 = 1,
		BRANCH_2 = 2,
		BRANCH_3 = 3,
		BRANCH_4 = 4,
		BRANCH_5 = 5,
		BRANCH_6 = 6
	}

}