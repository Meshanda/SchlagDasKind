using System;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;

    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        Init();
    }

    private void Init()
    {
        if (_gameManager.GameWon)
            InitWin();
        else
            InitLose();
    }

    private void InitWin()
    {
        _winCanvas.SetActive(true);
        _loseCanvas.SetActive(false);
    }

    private void InitLose()
    {
        _winCanvas.SetActive(false);
        _loseCanvas.SetActive(true);
    }

    #region Buttons

    public void ClickNextLevel()
    {
        SceneLoader.LoadLevel(_gameManager.CurrentLevel + 1);
    }

    public void ClickBackToMenu()
    {
        SceneLoader.LoadMainMenu();
    }

    public void ClickRetry()
    {
        SceneLoader.LoadLevel(_gameManager.CurrentLevel);
    }

    #endregion
}
