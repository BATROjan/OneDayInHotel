using UnityEngine;
using Zenject;

public class HallViewsSpawner: ITickable
{
    private readonly TickableManager _tickableManager;
    private readonly HallController _hallController;
    private float _spawnPeriod= 3.25f;
    private float _timer;

    public HallViewsSpawner(TickableManager tickableManager,
        HallController hallController)
    {
        _hallController = hallController;
        _tickableManager = tickableManager;
    }
    
    public void StartSpawn()
    {
        _tickableManager.Add(this);
    }

    public void StopSpawn()
    {
        _tickableManager.Remove(this);
        _hallController.DespawnAll();
    }

    public void Tick()
    {
        _spawnPeriod -= Time.deltaTime;
        _timer += Time.deltaTime;
        
        if (_spawnPeriod <= 0)
        {
            _hallController.Spawn();
            _spawnPeriod = 12f;
        }
    }
}
