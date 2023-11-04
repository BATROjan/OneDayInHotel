using System.Collections.Generic;
using UnityEngine;

public class HallController
{
    private readonly HallView.Pool _hallViewPool;
    private readonly HallConfig _hallConfig;
    
    private List<HallView> _hallsList = new List<HallView>();

    public HallController(HallView.Pool hallViewPool,
        HallConfig hallConfig
        )
    {
        _hallViewPool = hallViewPool;
        _hallConfig = hallConfig;
    }

    public void Spawn()
    {
        var position = new Vector3(17, 0.5f, 0);
        var hall = _hallViewPool.Spawn(position);
        _hallsList.Add(hall);
        hall.AddAnimatin(() => Despawn(hall));
    }
    
    public void SpawnStartHall()
    {
        var position = new Vector3(-4.2f, 0.5f, 0);
        var hall = _hallViewPool.Spawn(position);
        _hallsList.Add(hall);
        hall.AddAnimatin(() => Despawn(hall));

        position = new Vector3(8f, 0.5f, 0);
        var hall1 = _hallViewPool.Spawn(position);
        _hallsList.Add(hall);
        hall1.AddAnimatin(() => Despawn(hall1));
    }
    
    public void Despawn(HallView hallView)
    {
        _hallsList.Add(hallView);
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
