using System;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour, ITickable
{
    public Action OnOpenDoor;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    public bool isAlive = true;

    public bool BelowTheDoor;
    private TickableManager _tickableManager;

    [Inject]
    public void Construct(TickableManager tickableManager)
    {
        _tickableManager = tickableManager;
        _tickableManager.Add(this);
    }
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnOpenDoor?.Invoke();
        }
    }
    public class Pool : MonoMemoryPool<PlayerView>
    {
        
    }
}