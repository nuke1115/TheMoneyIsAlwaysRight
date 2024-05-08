namespace AboutPlayer
{

	public class Player : IPlayerTag
	{
		public int _nowStage;


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