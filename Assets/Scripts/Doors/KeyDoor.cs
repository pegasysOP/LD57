using UnityEngine;

public class KeyDoor : Door
{
    public GameObject keyObject;
    public GameObject facade;
    public AudioClip horseClip;

    private bool hasKey = false;

    public override void Interact()
    {
        if (state == DoorState.Locked)
        {
            if (hasKey)
            {
                keyObject.SetActive(true);
                GameManager.Instance.hud.ShowKeyIcon(false);
                OpenDoor();
                facade.SetActive(true);
                hasKey = false;
                if(horseClip != null)
                {
                    AudioManager.Instance.Play(AudioManager.Instance.musicSource, horseClip, AudioManager.FadeType.CROSS_FADE);
                }
            }
            else
            {
                ShowLockedAnimation();
            }
        }
    }

    public override bool IsInteractable()
    {
        return state != DoorState.Open;
    }

    public void SetKey()
    {
        hasKey = true;
    }
}
