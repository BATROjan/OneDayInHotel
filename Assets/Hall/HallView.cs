using DG.Tweening;
using UnityEngine;
using Zenject;

public class HallView : MonoBehaviour
{
    public Tween _hallAnimation;

    private int allDuraction;
    private int endPositionX;
    private int spawnPositionX;
    private int sumPath;
    private float speedAnimation;

    public HallView()
    {
        allDuraction = 20;
        endPositionX = -17;
        spawnPositionX = 17;
        sumPath = 34;

        speedAnimation = sumPath / allDuraction;
    }
    
    public void AddAnimatin(TweenCallback despawn)
    {
        _hallAnimation.Kill();
        var duraction = (spawnPositionX + transform.position.x)/(speedAnimation);
        
        _hallAnimation = transform
            .DOMoveX(-17,duraction)
            .SetEase(Ease.Linear)
            .OnComplete(despawn);
    }

    private void Reinit(Vector3 SpawnPosition)
    {
        transform.position = SpawnPosition;
    }
    public class Pool : MonoMemoryPool<Vector3, HallView>
    {
        protected override void Reinitialize(Vector3 SpawnPosition, HallView item)
        {
            item.Reinit(SpawnPosition);
        }
        
    }
}