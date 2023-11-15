using System.Collections.Generic;
using DG.Tweening;
using WallsItem;
using UnityEngine;

public class HallController
{
    private readonly HallView.Pool _hallViewPool;
    private readonly HallConfig _hallConfig;
    
    private List<HallView> _hallsList = new List<HallView>();
    private readonly WallsItemView.Pool _doorPool;

    private int ResetDoor;
    private readonly WallsItemController _wallsItemController;

    public HallController(
        WallsItemController wallsItemController,
        WallsItemView.Pool doorPool,
        HallView.Pool hallViewPool,
        HallConfig hallConfig
    )
    {
        _wallsItemController = wallsItemController;
        _doorPool = doorPool;
        _hallViewPool = hallViewPool;
        _hallConfig = hallConfig;
    }

    public void Spawn()
    {
        var position = new Vector3(17, 0.5f, 0);
        var hall = _hallViewPool.Spawn(position);
        if (hall.transform.childCount>0)
        {
            _doorPool.Despawn(hall.transform.GetComponentInChildren<WallsItemView>());
        }
        
        var random = Random.Range(0, 1f);
        if (random>0.5f)
        {
            SpawnDoor(hall);
            if (ResetDoor>0)
            {
                ResetDoor--;
            }
        }
        else
        {
            ResetDoor++;
            if (ResetDoor>=3)
            {
                SpawnDoor(hall);
                
                ResetDoor = 0;
            }
        }
        AddToList(hall);
        hall.AddAnimatin(() => Despawn(hall));
    }

    private WallsItemView SpawnDoor(HallView hall)
    {
        var random = Random.Range(0, 3);
        WallsItemView wallsItem;
        if (random ==0)
        {
            wallsItem = _wallsItemController.Spawn(random);
            wallsItem.transform.SetParent(hall.transform, worldPositionStays: false);
        }
        else
        {
            wallsItem = _wallsItemController.Spawn(random);
            wallsItem.transform.SetParent(hall.transform, worldPositionStays: false);
        }
        var transformLocalPosition = wallsItem.transform.localPosition;
        transformLocalPosition.y = 1.72f;
        wallsItem.transform.localPosition = transformLocalPosition;

        return wallsItem;
    }
    
    public void SpawnStartHall()
    {
        var position = new Vector3(-4.2f, 0.5f, 0);
        var hall = _hallViewPool.Spawn(position);
        AddToList(hall);
        hall.AddAnimatin(() => Despawn(hall));

        position = new Vector3(8f, 0.5f, 0);
        var hall1 = _hallViewPool.Spawn(position);
        AddToList(hall);
        hall1.AddAnimatin(() => Despawn(hall1));
    }
    
    public void Despawn(HallView hallView)
    {
        hallView._hallAnimation.Kill();
        _hallViewPool.Despawn(hallView);
    }
    
    public void DespawnAll()
    {
        foreach (var hallView in _hallsList)
        {
            Despawn(hallView);
        }

        _hallsList.Clear();
    }

    public void AddToList(HallView hall)
    {
        if (_hallsList.Contains(hall))
        {
            _hallsList.Add(hall);
        }
    }
}