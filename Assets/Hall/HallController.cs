using System.Collections.Generic;

public class HallController
{
    private readonly HallView.Pool _hallViewPool;
    private readonly HallConfig _hallConfig;
    
    private List<HallView> _hallsList = new List<HallView>();

    public HallController(HallView.Pool hallViewPool,
        HallConfig hallConfig)
    {
        _hallViewPool = hallViewPool;
        _hallConfig = hallConfig;
    }

    public void Spawn()
    {
        _hallViewPool.Spawn();
    }
    
    public void SpawnStartHall()
    {
        //_hallViewPool.Spawn(startPosition);
    }
    
    public void Despawn(HallView hallView)
    {
        _hallViewPool.Despawn(hallView);
    }
    
    public void DespawnAll()
    {
        foreach (var hallView in _hallsList)
        {
            _hallViewPool.Despawn(hallView);
        }
    }
}
