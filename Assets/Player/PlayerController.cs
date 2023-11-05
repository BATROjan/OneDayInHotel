using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerController :ITickable

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Open");
            }

            Debug.Log("Close");
        }

        public void Spawn()
        {
            _playerView = _playerPool.Spawn();
            _playerView.OnOpenDoor += DoSomeThing;
        }

        public void Tick()
        {
            DoSomeThing();
        }
    }
}