using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    private const string MAIN_MENU = "MainMenu";
    private const string END_SCREEN = "EndScreen";
    private const string LEVEL_1 = "Level1";
    private const string LEVEL_2 = "Level2";
    private const string LEVEL_3 = "Level3";

    public static void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(MAIN_MENU, LoadSceneMode.Single);
    }

    public static void LoadLevel1()
    {
        SceneManager.LoadSceneAsync(LEVEL_1, LoadSceneMode.Single);
    }
    
    public static void LoadLevel2()
    {
        SceneManager.LoadSceneAsync(LEVEL_2, LoadSceneMode.Single);
    }
    
    public static void LoadLevel3()
    {
        SceneManager.LoadSceneAsync(LEVEL_3, LoadSceneMode.Single);
    }

    public static void LoadEndScreen()
    {
        SceneManager.LoadSceneAsync(END_SCREEN, LoadSceneMode.Additive);
    }
}
