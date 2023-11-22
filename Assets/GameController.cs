using Player;
using UnityEngine.UI;

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
        
    private void Spawn( )
    {
        _hallController.FirstSpawn();
        _hallViewsSpawner.StartSpawn();
        _playerController.Spawn();
        _playerController.IsDead += StopGame;
    }

    private void Despawn()
    {
        _hallViewsSpawner.StopSpawn();
        _playerController.Despawn();
        _playerController.IsDead -= StopGame;
    }
}