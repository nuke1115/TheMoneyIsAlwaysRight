namespace AboutGetInitialStorySectionManager
{
	public static class GetInitialStorySectionManager
	{

		public static void GetInitialStorySection(IPlayerTag player , out int branch , out int nowStage , out bool isItStartPoint)
		{
			int _branch = 0;
			int _nowStage = player.GetNowStage();
			bool _caveState = player.GetCaveBranchState();
			bool _isItStartPoint = false;

			if (_nowStage == 3)
			{
				_nowStage = 2;
				_branch = 2;
			}
			else if(_caveState)
			{
				_branch = 4;
				_nowStage = 2;
			}
			else if (_nowStage == 4)
			{
				_nowStage -= 2;
				_branch = 1;
			}
			else if(_nowStage != 0 && _caveState == false)
			{
				_nowStage -= 1;
				_branch = 1;
			}
			else if (_nowStage == 0)
			{
				_isItStartPoint = true;
			}
			isItStartPoint = _isItStartPoint;
			branch = _branch;
			nowStage = _nowStage;
		}
	}
}