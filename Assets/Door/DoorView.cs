using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Door
{
    public class DoorView : MonoBehaviour
    {
        [Inject] private PlayerController _playerController;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        public bool IsOpen;

        public void Reinit(Sprite sprite, bool isOpen)
        {
            spriteRenderer.sprite = sprite;
            IsOpen = isOpen;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsOpen)
            {
                var player = other.GetComponent<PlayerView>();
                player.BelowTheDoor = true;
                
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerView>();
            player.BelowTheDoor = false;
            if (IsOpen )
            {
                _playerController.OnIsAlive?.Invoke(); 
            }
        }

        public class Pool : MonoMemoryPool<Sprite, bool, DoorView>
        {
            protected override void Reinitialize(Sprite sprite, bool isOpen, DoorView item)
            {
                item.Reinit(sprite, isOpen);
            }
        }
    }
}