using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneUtils
{
    public const string GAME_SCENE = "Game";
    public const string MENU_SCENE = "Menu";
    public const string SETTINGS_SCENE = "Settings";

    public static void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public static void LoadMenuScene()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }

    public static void LoadSettingsScene()
    {
        SceneManager.LoadScene(SETTINGS_SCENE);
    }

    public static void QuitApplication()
    {
        Application.Quit();
    }
}
