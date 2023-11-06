using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Player
{
    public class PlayerController
    {
        public Action OnIsAlive;
        public PlayerView PlayerView => _playerView;
        
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
                
            }
            else
            {
                OnIsAlive?.Invoke();
            }
        }

        public void Spawn(Text ScoreText)
        {
            _playerView = _playerPool.Spawn(ScoreText);
            _playerView.OnOpenDoor += DoSomeThing;
        }
        public void Despawn()
        {
            _playerView.OnOpenDoor -= DoSomeThing;
            _playerPool.Despawn(_playerView);
        }
    }
}