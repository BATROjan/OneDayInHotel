using UnityEngine;
using Zenject;

public class testCub : MonoBehaviour
{
    [Inject] private GameController _gameController;
    void Start()
    {
        _gameController.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}