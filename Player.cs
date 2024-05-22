﻿namespace AboutPlayer
{

	public class Player : IPlayerTag
	{
		public int _nowStage;
		public bool _isBaguetteEnforced;
		public bool _isReturnItemGained;
		public bool _isCaveBranchSelected;

		public bool GetCaveBranchState()
		{
			return _isCaveBranchSelected;
		}

		public void SaveCaveBranchState(bool CaveBranchState)
		{
			_isCaveBranchSelected = CaveBranchState;
		}
		public bool GetReturnItemState()
		{
			return _isReturnItemGained;
		}

		public void SaveReturnItemState(bool ReturnItemState)
		{
			_isReturnItemGained = ReturnItemState;
		}

		public bool GetBaguetteState()
		{
			return _isBaguetteEnforced;
		}

		public void SaveBaguetteState(bool BaguetteState)
		{
			_isBaguetteEnforced = BaguetteState;
		}

		public int GetNowStage()
		{
			return _nowStage;
		}

		public void SaveNowStage(int nowStage)
		{
			_nowStage = nowStage;
		}


		public Player()
		{

		}


	}
}