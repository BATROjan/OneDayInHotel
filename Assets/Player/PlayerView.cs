using System;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour
{
    public Action OnOpenDoor;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public bool BelowTheDoor;
    
    public class Pool  : MonoMemoryPool<PlayerView>
    {
        
    }
}
