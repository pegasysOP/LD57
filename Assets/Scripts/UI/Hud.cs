using UnityEngine;

public class Hud : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject interactPrompt;
    public GameObject keyIcon;

    public void ShowInteractPrompt(bool show)
    {
        interactPrompt.SetActive(show);
    }

    public void ShowKeyIcon(bool show)
    {
        keyIcon.SetActive(show);
    }
}
