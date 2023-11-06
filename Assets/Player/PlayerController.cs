using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerController
    {
        public Action OnIsAlive;
        
        private readonly PlayerView.Pool _playerPool;
        private PlayerView _playerView;

        public PlayerController(
            PlayerView.Pool playerPool)
        {
            _playerPool = playerPool;
        }

        public void DoSomeThing()
        {
            if (_playerView.BelowTheDoor )
            {
                Debug.Log("Open");
            }
            else
            {
                OnIsAlive?.Invoke();
               Debug.Log("Close"); 
            }
        }

        public void Spawn()
        {
            _playerView = _playerPool.Spawn();
            _playerView.OnOpenDoor += DoSomeThing;
        }
        public void Despawn()
        {
            _playerView.OnOpenDoor -= DoSomeThing;
            _playerPool.Despawn(_playerView);
        }
    }
}