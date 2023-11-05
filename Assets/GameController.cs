using Door;
using UnityEngine;

public class GameController
{
    private readonly HallController _hallController;
    private readonly HallViewsSpawner _hallViewsSpawner;
    private readonly DoorController _doorController;

    public GameController(
        HallController hallController,
        HallViewsSpawner hallViewsSpawner,
        DoorController doorController)
    {
        _doorController = doorController;
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
            _doorController.Spawn();
        }

        private void Despawn()
        {
            _hallController.DespawnAll();
        }
        
}
