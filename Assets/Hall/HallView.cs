using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class HallView : MonoBehaviour
{
    public Tween _hallAnimation;

    public void AddAnimatin(TweenCallback despawn, float duraction)
    {
        _hallAnimation.Kill();
        duraction = (17 + transform.position.x)/(34/20);
        
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
