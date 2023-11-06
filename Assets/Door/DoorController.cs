using UnityEngine;

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

        public DoorView Spawn(int i)
        {
            var door = _doorPool.Spawn(_doorConfig.GetTypeWithId(i).Sprite, _doorConfig.GetTypeWithId(i).IsOpen);
            return door;
        }
    }
}