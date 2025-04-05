using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;

    private void OnEnable()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);

#if UNITY_WEBGL
        quitButton.gameObject.SetActive(false);
#endif
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonClick);
        quitButton.onClick.RemoveListener(OnQuitButtonClick);
    }

    private void OnStartButtonClick()
    {
        SceneUtils.LoadGameScene();
    }

    private void OnSettingsButtonClick()
    {
        SceneUtils.LoadSettingsScene();
    }

    private void OnQuitButtonClick()
    {
        SceneUtils.QuitApplication();
    }
}
