using AboutStages;

namespace AboutStageFactory
{
	public class StageFactory : IGetInstance , IInitialize
	{
		private IExecutableStage[] _instances;
		private IPlayerTag _player;
		public IExecutableStage GetInstance(int nowStage)
		{
			return _instances[nowStage];
		}

		public void Initialize(params object[] parameters)
		{

			_player = (IPlayerTag)parameters[1];

			_instances = new IExecutableStage[6];

			_instances[0] = new Stage0();
			_instances[1] = new Stage1();
			_instances[2] = new Stage2(_player);
			_instances[3] = new Stage2_Sub(_player);
			_instances[4] = new Stage3(_player);
			_instances[5] = new Stage4();
		}
		
	}
}