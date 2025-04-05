using UnityEngine;

public class Hud : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject interactPrompt;

    public void ShowInteractPrompt(bool show)
    {
        interactPrompt.SetActive(show);
    }
}
