using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartWindow : MonoBehaviour
{
    public UIButton StartButton;
    public Canvas CanvasWindow;
    public Transform StartWindowTransform;
    public Text ScoreText;
    [Inject] private GameController _gameController;
    [Inject] private Camera _mainCamera;
    [Inject] private PlayerController _playerController;

    public StartWindow()
    {
    }
    
    private void StartGame()
    {
        Time.timeScale = 1;
        StartWindowTransform.DOLocalMoveY(1550f, 1f).OnComplete(() =>
        {
            Time.timeScale = 12;
            CanvasWindow.gameObject.SetActive(false);
        });
        ScoreText.text = 0.ToString();
        _gameController.StartGame(ScoreText);
    }

    public void EndGame()
    {
        CanvasWindow.gameObject.SetActive(true);
        StartWindowTransform.DOLocalMoveY(1f, 0.5f).OnComplete(()=>{Time.timeScale = 99;});
        _gameController.StopGame();
    }

    private void Start()
    {
        CanvasWindow.worldCamera = _mainCamera;
        StartButton.OnClickButton += StartGame;
        _playerController.OnIsAlive += EndGame;
    }
}

