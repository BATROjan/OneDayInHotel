using DG.Tweening;
using UnityEngine;
using Zenject;

public class StartWindow : MonoBehaviour
{
    public UIButton startButton;
    public Canvas CanvasWindow;
    [Inject] private GameController _gameController;
    [Inject] private Camera _mainCamera;

    public StartWindow()
    {
    }
    
    private void StartGame()
    {
        _gameController.StartGame();
        transform.DOMoveY(2, 0.7f).OnComplete(() => { gameObject.SetActive(false); });
    }

    private void Start()
    {
        CanvasWindow.worldCamera = _mainCamera;
        startButton.OnClickButton += StartGame;
    }
}

