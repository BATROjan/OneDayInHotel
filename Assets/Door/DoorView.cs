using Player;
using UnityEngine;
using Zenject;

namespace Door
{
    public class DoorView : MonoBehaviour
    {
        [Inject] private PlayerController _playerController;
        [Inject] private DoorConfig _doorConfig;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        private DoorModel _doorModel;
        public bool IsOpen;

        public void Reinit(DoorModel doorModel)
        {
            _doorModel = doorModel;
            spriteRenderer.sprite = _doorModel.Sprite;
            IsOpen = _doorModel.Sprite;
        }

        private void CloseDoor()
        {
            spriteRenderer.sprite = _doorConfig.GetTypeWithId(1).Sprite;
            IsOpen = _doorConfig.GetTypeWithId(1).Sprite;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsOpen)
            {
                var player = other.GetComponent<PlayerView>();
                player.OnOpenDoor += CloseDoor;
                player.BelowTheDoor = true;
            }

            if (Time.timeScale < 25)
            {
                Time.timeScale += 0.25f;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerView>();
            player.OnOpenDoor -= CloseDoor;
            player.BelowTheDoor = false;
        }

        public class Pool : MonoMemoryPool<DoorModel, DoorView>
        {
            protected override void Reinitialize(DoorModel doorModel, DoorView item)
            {
                item.Reinit(doorModel);
            }
        }
    }
}