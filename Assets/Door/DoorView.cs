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

        public class Pool : MonoMemoryPool<DoorView>
        {
        }
    }
}