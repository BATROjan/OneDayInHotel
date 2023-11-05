using System;
using UnityEngine;
using Zenject;

namespace Door
{
    public class DoorView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnTriggerStay2D(Collider2D other)
        {
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerView>();
            player.BelowTheDoor = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerView>();
            player.BelowTheDoor = false;

        }

        public class Pool : MonoMemoryPool<DoorView>
        {
        }
    }
}