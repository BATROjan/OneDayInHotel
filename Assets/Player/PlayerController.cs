using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerController 

    { 
        private readonly PlayerView.Pool _playerPool;
        private PlayerView _playerView;

        public PlayerController(
            PlayerView.Pool playerPool)
        {
            _playerPool = playerPool;
        }

        public void DoSomeThing()
        {
            if (_playerView.BelowTheDoor)
            {
                Debug.Log("Open");
            }
            else
            {
               Debug.Log("Close"); 
            }
        }

        public void Spawn()
        {
            _playerView = _playerPool.Spawn();
            _playerView.OnOpenDoor += DoSomeThing;
        }
    }
}