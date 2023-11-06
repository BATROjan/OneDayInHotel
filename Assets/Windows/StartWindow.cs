using DG.Tweening;
using Door;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class StartWindow : MonoBehaviour
{
    public UIButton StartButton;
    public Canvas CanvasWindow;
    public Transform StartWindowTransform;
    [Inject] private GameController _gameController;
    [Inject] private Camera _mainCamera;
    [Inject] private PlayerController _playerController;

    public StartWindow()
    {
    }
    
    private void StartGame()
    {
        StartWindowTransform.DOMoveY(120, 1.4f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
        _gameController.StartGame();
    }

    public void EndGame()
    {
        gameObject.SetActive(true);
        StartWindowTransform.DOMoveY(0.5f, 1.4f);
        _gameController.StopGame();
    }

    private void Start()
    {
        CanvasWindow.worldCamera = _mainCamera;
        StartButton.OnClickButton += StartGame;
        Time.timeScale = 10;
        _playerController.OnIsAlive += EndGame;
    }
}

