using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level CurrentLevel;
    
    [HideInInspector] public bool GameWon;

    private bool _gameEnded;
    private void OnEnable()
    {
        MancheManager.GameWon += OnGameWin;
        Base.OnBaseDestruction += OnGameLose;
    }

    private void OnDisable()
    {
        MancheManager.GameWon -= OnGameWin;
        Base.OnBaseDestruction -= OnGameLose;
    }

    private void Start()
    {
        _gameEnded = false;
    }

    private void OnGameWin()
    {
        if (_gameEnded) return; 
        
        _gameEnded = true;
        GameWon = true;
        SceneLoader.LoadEndScreen();
    }
    
    private void OnGameLose()
    {
        if (_gameEnded) return;
        
        _gameEnded = true;
        GameWon = false;
        SceneLoader.LoadEndScreen();
    }
}
