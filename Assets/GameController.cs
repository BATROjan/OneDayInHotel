using Door;
using Player;
using UnityEngine;
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
    
    public void StartGame(Text ScoreText)
    {
        Spawn(ScoreText);
    }

    public void StopGame()
    {
        Despawn();
    }
        
    private void Spawn(Text ScoreText)
    {
        _hallController.SpawnStartHall();
        _hallViewsSpawner.StartSpawn();
        _playerController.Spawn(ScoreText);
    }

    private void Despawn()
    {
        _hallViewsSpawner.StopSpawn();
        _playerController.Despawn();
    }
}