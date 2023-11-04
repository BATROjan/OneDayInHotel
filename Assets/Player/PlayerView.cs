using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public class Pool  : MonoMemoryPool<PlayerView>
    {
        
    }
}
