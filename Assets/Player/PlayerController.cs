using System;
using UnityEngine;
using UnityEngine.UI;
using WallsItem;
using Zenject;

namespace Player
{
    public class PlayerController : ITickable
    {
        public Action IsDead;
        public PlayerView PlayerView => _playerView;

        private readonly PlayerView.Pool _playerPool;
        private readonly WallsItemController _wallsItemController;

        private TickableManager _tickableManager;
        private PlayerView _playerView;

        public PlayerController(
            WallsItemController wallsItemController,
            PlayerView.Pool playerPool,
            TickableManager tickableManager)
        {
            _playerPool = playerPool;
            _wallsItemController = wallsItemController;
            
            _tickableManager = tickableManager;

        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                TakeTowels(); 
            } 
        }

        private void TakeTowels()
        {
            if (_playerView.BelowTheDoor)
            {
                _wallsItemController.CloseTheDoor();
            }
            else
            {
                IsDead?.Invoke();
            }
        }

        public void Spawn()
        {
            _playerView = _playerPool.Spawn();
            _tickableManager.Add(this);
        }

        public void Despawn()
        {
            _playerPool.Despawn(_playerView); 
            _tickableManager.Remove(this);
        } 
    }
}