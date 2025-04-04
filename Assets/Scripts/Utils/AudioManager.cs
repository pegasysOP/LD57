using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("UI")]
    public AudioClip buttonPressClip;

    [Header("Phase Music")]
    public AudioClip menuClip;
    public AudioClip gameOverClip;
    public AudioClip gameWonClip;

    [Header("Interaction Sounds")]
    public AudioClip selectClip;

    [Header("Special Attacks")]
    public AudioClip attackClip;

    public static AudioManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Ensure this object persists between scenes
        }
        else if (Instance != this)
        {
            // Destroy duplicate instances to prevent multiple AudioManagers
            Destroy(gameObject);
            return;
        }
    }

    public void PlayButtonPressedClip()
    {
        sfxSource.clip = buttonPressClip;
        sfxSource.Play();
    }

    public void PlayMenuClip()
    {
        musicSource.clip = menuClip;
        musicSource.Play();
    }

    public void PlayGameOverClip()
    {
        musicSource.clip = gameOverClip;
        musicSource.Play();
    }

    public void PlayGameWonClip()
    {
        musicSource.clip = gameWonClip;
        musicSource.Play();
    }

    public void PlaySelectClip()
    {
        sfxSource.clip = selectClip;
        musicSource.Play();
    }

    public void PlayAttackClip()
    {
        sfxSource.clip = attackClip;
        sfxSource.Play();
    }

}
