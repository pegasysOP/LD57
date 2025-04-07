using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource bubbleSource;

    [Header("Player")]
    public List<AudioClip> footsteps = new List<AudioClip>();

    [Header("UI")]
    public AudioClip buttonPressClip;
    public AudioClip buttonHoverClip;
    public AudioClip pauseMenuOpenClip;
    public AudioClip pauseMenuClosedClip;

    [Header("Interaction Sounds")]
    public AudioClip selectClip;
    public AudioClip doorOpenClip;
    public AudioClip doorCloseClip;
    public AudioClip itemAcquireClip;
    public AudioClip doorLockedClip;

    [Header("Voice Lines")]
    public AudioClip correctDoorClip;

    [Header("Music")]
    public AudioClip dreamStartClip;
    public AudioClip corridorClip;
    public AudioClip hiddenRoomClip;
    public AudioClip museaumClip;
    public AudioClip fieldOfHorsesClip;
    public AudioClip manyDoorsClip;

    public static AudioManager Instance;

    public void Init()
    {
        Instance = this;
        PlayDreamStartClip();
        UpdateVolume(SettingsUtils.GetMasterVolume());
    }

    //================================ UI =================================
    public void PlayButtonPressedClip()
    {
        sfxSource.clip = buttonPressClip;
        sfxSource.Play();
    }

    public void PlayButtonHoverClip()
    {
        sfxSource.clip = buttonHoverClip;
        sfxSource.Play();
    }

    public void PauseMenuOpenClip()
    {
        sfxSource.clip = pauseMenuOpenClip;
        sfxSource.Play();
    }

    public void PauseMenuClosedClip()
    {
        sfxSource.clip = pauseMenuClosedClip;
        sfxSource.Play();
    }

    //================================ Interaction =============================
    public void PlayDoorOpenClip()
    {
        sfxSource.clip = doorOpenClip;
        sfxSource.Play();
    }
    public void PlayDoorClosedClip()
    {
        sfxSource.clip = doorCloseClip;
        sfxSource.Play();
    }
    public void PlayItemAcquireClip()
    {
        sfxSource.clip = itemAcquireClip;
        sfxSource.Play();
    }
    public void PlayDoorLockedClip()
    {
        sfxSource.clip = doorLockedClip;
        sfxSource.Play();
    }

    public void PlaySelectClip()
    {
        sfxSource.clip = selectClip;
        sfxSource.Play();
    }

    public void PlayFootstep()
    {
        if (sfxSource == null || footsteps == null || footsteps.Count == 0)
            return;

        int step = Random.Range(0, footsteps.Count);
        sfxSource.clip = footsteps[step];
        sfxSource.pitch = Random.Range(0.8f, 1.2f);
        sfxSource.PlayOneShot(footsteps[step]);
    }

    public void PlayCorrectDoorClip()
    {
        sfxSource.clip = correctDoorClip;
        sfxSource.Play();
    }

    //================================ Music ==============================================
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
    public void PlayDreamStartClip()
    {
        musicSource.clip = dreamStartClip;
        musicSource.Play();
    }

    public void PlayCorridoorClip()
    {
        musicSource.clip = corridorClip;
        musicSource.Play();
    }

    public void UpdateVolume(float value)
    {
        musicSource.volume = value / 3;
        sfxSource.volume = value;
        if(bubbleSource != null)
        {
             bubbleSource.volume = value;
        }
       
    }
}
