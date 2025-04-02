using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneUtils
{
    public const string GAME_SCENE = "Game";
    public const string MENU_SCENE = "Menu";

    public static void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public static void LoadMenuScene()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }

    public static void QuitApplication()
    {
        Application.Quit();
    }
}
