using System.Collections.Generic;
using DG.Tweening;
using Door;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class HallController
{
    private readonly HallView.Pool _hallViewPool;
    private readonly HallConfig _hallConfig;
    
    private List<HallView> _hallsList = new List<HallView>();
    private readonly DoorView.Pool _doorPool;

    private int ResetDoor;
    private readonly DoorController _doorController;

    public HallController(
        DoorController doorController,
        DoorView.Pool doorPool,
        HallView.Pool hallViewPool,
        HallConfig hallConfig
    )
    {
        _doorController = doorController;
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
            _doorPool.Despawn(hall.transform.GetComponentInChildren<DoorView>());
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

    private void SpawnDoor(HallView hall)
    {
        var random = Random.Range(0, 2);
        if (random ==0)
        {
            var door = _doorController.Spawn(random);
            door.transform.SetParent(hall.transform, worldPositionStays: false);
        }
        else
        {
            var door = _doorController.Spawn(random);
            door.transform.SetParent(hall.transform, worldPositionStays: false);
        }
        
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
        _hallsList.Remove(hallView);
        _hallViewPool.Despawn(hallView);
        var door = hallView.GetComponentInChildren<DoorView>();
    }
    
    public void DespawnAll()
    {
        foreach (var hallView in _hallsList)
        {
            Despawn(hallView);
        }
    }

    public void AddToList(HallView hall)
    {
        if (_hallsList.Contains(hall))
        {
            _hallsList.Add(hall);
        }
    }
}