using DG.Tweening;
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

    public StartWindow()
    {
    }
    
    private void StartGame()
    {
        StartWindowTransform.DOMoveY(120, 0.7f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
        _gameController.StartGame();
    }

    private void Start()
    {
        CanvasWindow.worldCamera = _mainCamera;
        StartButton.OnClickButton += StartGame;
    }
}

