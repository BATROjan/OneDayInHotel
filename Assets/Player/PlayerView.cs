using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerView : MonoBehaviour, ITickable
{
    public Action OnOpenDoor;
    public bool BelowTheDoor;
    public Text ScoreText;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
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
            var score = int.Parse(ScoreText.text);
            score++;
            ScoreText.text = score.ToString();
        }
    }
    public class Pool : MonoMemoryPool<Text ,PlayerView>
    {
        protected override void Reinitialize(Text score, PlayerView item)
        {
            item.ScoreText = score;
        }
    }
}