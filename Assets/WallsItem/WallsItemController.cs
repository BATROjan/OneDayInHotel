namespace WallsItem
{
    public class WallsItemController
    {
        private readonly WallsItemView.Pool _doorPool;
        private readonly WallsItemConfig _wallsItemConfig;

        public WallsItemController( 
            WallsItemView.Pool doorPool,
            WallsItemConfig wallsItemConfig)
        {
            _wallsItemConfig = wallsItemConfig;
            _doorPool = doorPool;
        }

        public WallsItemView Spawn(int i)
        {
            var door = _doorPool.Spawn(_wallsItemConfig.GetTypeWithId(i));
            door.IsOpen = _wallsItemConfig.GetTypeWithId(i).IsOpen;
            return door;
        }
    }
}