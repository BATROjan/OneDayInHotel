namespace WallsItem
{
    public class WallsItemController
    {
        private readonly WallsItemView.Pool _doorPool;
        private readonly WallsItemConfig _wallsItemConfig;

        private WallsItemView _wallsItemView;

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
            _wallsItemView = door;
            return door;
        }

        public void CloseTheDoor()
        {
            if (_wallsItemView.IsOpen)
            {
                _wallsItemView.SpriteRenderer.sprite = _wallsItemConfig.GetTypeWithId(1).Sprite;
                _wallsItemView.IsOpen = false;
            }
        }
    }
}