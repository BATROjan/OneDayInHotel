namespace Door
{
    public class DoorController
    {
        private readonly DoorView.Pool _doorPool;
        private readonly DoorConfig _doorConfig;

        public DoorController( 
            DoorView.Pool doorPool,
            DoorConfig doorConfig)
        {
            _doorConfig = doorConfig;
            _doorPool = doorPool;
        }

        public void Spawn()
        {
            _doorPool.Spawn();
        }
    }
}