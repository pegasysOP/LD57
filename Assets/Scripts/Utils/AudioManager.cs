using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Player")]
    public List<AudioClip> footsteps = new List<AudioClip>();

    [Header("UI")]
    public AudioClip buttonPressClip;

    [Header("Interaction Sounds")]
    public AudioClip selectClip;

    public static AudioManager Instance;

    public void Init()
    {
            Instance = this;
    }

    public void PlayButtonPressedClip()
    {
        sfxSource.clip = buttonPressClip;
        sfxSource.Play();
    }

    public void PlaySelectClip()
    {
        sfxSource.clip = selectClip;
        musicSource.Play();
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
}
