using Door;
using Player;
using UnityEngine;

public class GameController
{
    private readonly HallController _hallController;
    private readonly HallViewsSpawner _hallViewsSpawner;
    private readonly PlayerView.Pool _playerPool;
    private readonly PlayerController _playerController;

    public GameController(
        PlayerController playerController,
        HallController hallController,
        HallViewsSpawner hallViewsSpawner)
    {
        _playerController = playerController;
        _hallController = hallController;
        _hallViewsSpawner = hallViewsSpawner;
    }
    
    public void StartGame()
    {
        Spawn();
    }

    public void StopGame()
    {
        Despawn();
    }
        
    private void Spawn()
    {
        _hallController.SpawnStartHall();
        _hallViewsSpawner.StartSpawn();
        _playerController.Spawn();
    }

    private void Despawn()
    {
        _hallController.DespawnAll();
    }
        
}