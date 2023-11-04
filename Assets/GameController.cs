using UnityEngine;

public class GameController
{
    private readonly HallController _hallController;
    private readonly HallViewsSpawner _hallViewsSpawner;

    public GameController(
        HallController hallController,
        HallViewsSpawner hallViewsSpawner)
    {
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
        }

        private void Despawn()
        {
            _hallController.DespawnAll();
        }
        
}
