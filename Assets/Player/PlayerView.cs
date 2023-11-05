using System;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour
{
    public Action OnOpenDoor;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public bool BelowTheDoor;
    
       private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnOpenDoor?.Invoke();
            }
        }
    public class Pool  : MonoMemoryPool<PlayerView>
    {
        
    }

 
}
