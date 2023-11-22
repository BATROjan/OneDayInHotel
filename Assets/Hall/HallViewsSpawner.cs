using UnityEngine;
using Zenject;

public class HallViewsSpawner: ITickable
{
    private readonly TickableManager _tickableManager;
    private readonly HallController _hallController;
    private float _spawnPeriod= 3.25f;

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
        _hallController.DespawnAll();
        _tickableManager.Remove(this);
    }

    public void Tick()
    {
        if (_hallController._hallsList.Count < 5)
        {
            //_hallController.Spawn();
        }
    }
}
