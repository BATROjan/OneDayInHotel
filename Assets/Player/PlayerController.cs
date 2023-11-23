using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using WallsItem;
using Zenject;

namespace Player
{
    public class PlayerController : ITickable
    {
        public Action IsDead;
        public Action OnTakeTowel;
        public PlayerView PlayerView => _playerView;

        private readonly WallsItemController _wallsItemController;
        private readonly PlayerView.Pool _playerPool;
        private readonly PlayerConfig _playerConfig;

        private TickableManager _tickableManager;

        public PlayerController(
            WallsItemController wallsItemController,
            PlayerConfig playerConfig,
            PlayerView.Pool playerPool,
            TickableManager tickableManager)
        {
            _playerConfig = playerConfig;
            _playerPool = playerPool;
            _wallsItemController = wallsItemController;
            
            _tickableManager = tickableManager;

        }

        private PlayerView _playerView;

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
                OnTakeTowel?.Invoke();
                Debug.Log(0);
            }
            else
            {
                IsDead?.Invoke();
                Debug.Log(1);
            }
        }

        public void Spawn()
        {
            _playerView = _playerPool.Spawn();
            _playerView.transform.position = _playerConfig.SpawnPoint;
            Moving(_playerConfig.PlayingPoint);
            _tickableManager.Add(this);
        }

        public void Despawn()
        {
            _playerPool.Despawn(_playerView); 
            _tickableManager.Remove(this);
        }

        private void Moving(Vector3 point)
        {
            _playerView.transform.DOMove(point, 4);
        }
    }
}