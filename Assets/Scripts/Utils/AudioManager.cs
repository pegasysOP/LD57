using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource bubbleSource;
    public AudioSource fadeSource;

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

    private Coroutine currentCoroutine;

    public enum FadeType { None, FadeIn, CrossFade }

    public void Init()
    {
        Instance = this;
        PlayDreamStartClip();
        UpdateVolume(SettingsUtils.GetMasterVolume());
    }

    //==================== Utility ====================
    public bool IsClipPlaying(AudioSource source, AudioClip clip)
    {
        return source.isPlaying && source.clip == clip;
    }

    public void PlayMusic(AudioClip clip, FadeType fadeType = FadeType.None, float fadeTime = 2f, bool isDucking = false)
    {
        Play(musicSource, clip, fadeType, fadeTime, isDucking);
    }

    public void Play(AudioSource source, AudioClip clip, FadeType fadeType = FadeType.None, float fadeTime = 2f, bool isDucking = false)
    {
        if (source == null || clip == null)
        {
            Debug.LogError("ERROR: You must provide an audio source and clip to play on it");
        }
        if (isDucking)
        {
            if(fadeType != FadeType.None)
            {
                Debug.LogError("ERROR: Simultaneously ducking and fading is not supported!");
            }
            StartDuckAudio(source);
        }
        else if (fadeType == FadeType.FadeIn)
        {
            StartFadeIn(source, clip, fadeTime);
        }
        else if (fadeType == FadeType.CrossFade)
        {
            StartCrossFade(clip, fadeTime);
        }
        else
        {
            source.clip = clip;
            source.Play();
        }
    }

    public void Stop(AudioSource source, bool fadeOutEnabled, float fadeTime = 2f)
    {
        if(source == null)
        {
            Debug.LogError("ERROR: Must provide a source to stop playing");
        }
        if (fadeOutEnabled)
        {
            StartFadeOut(source, fadeTime);
        }
        else
        {
            source.Stop();
        }
    }

    //==================== UI ====================
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

    //==================== Interaction ====================
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

    //==================== Music ====================

    public void PlayDreamStartClip()
    {
        musicSource.clip = dreamStartClip;
        musicSource.Play();
    }

    public void PlayCorridoorClip()
    {
        musicSource.clip = corridorClip;
        musicSource.Play();
        //StartCoroutine(CrossFade( corridorClip, 5));
    }

    public void UpdateVolume(float value)
    {
        musicSource.volume = value / 3;
        fadeSource.volume = value / 3;
        sfxSource.volume = value;
        if(bubbleSource != null)
        {
             bubbleSource.volume = value;
        }
       
    }

    private void StartDuckAudio(AudioSource sourceToDuck, float duckVolumePercent = 0.3f, float duckDuration = 2f, float fadeTime = 0.5f)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        currentCoroutine = StartCoroutine(DuckAudio(sourceToDuck, duckVolumePercent, duckDuration, fadeTime));
    }

    private IEnumerator DuckAudio(AudioSource source, float duckVolumePercent, float duckDuration, float fadeTime)
    {
        if (!source.isPlaying)
        {
            yield break;
        }

        float originalVolume = SettingsUtils.GetMasterVolume() / 3;
        float duckVolume = originalVolume * duckVolumePercent;

        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            float normalized = t / fadeTime;
            source.volume = Mathf.Lerp(originalVolume, duckVolume, normalized);
            yield return null;
        }

        source.volume = duckVolume;

        yield return new WaitForSeconds(duckDuration);

        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            float normalized = t / fadeTime;
            source.volume = Mathf.Lerp(duckVolume, originalVolume, normalized);
            yield return null;
        }

        source.volume = originalVolume;

        currentCoroutine = null;
    }

    //==================== Fading ====================

    private void StartFadeIn(AudioSource source, AudioClip clip, float duration)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(FadeIn(source, clip, duration));
    }

    private IEnumerator FadeIn(AudioSource source, AudioClip clipToFadeIn, float fadeDuration)
    {
        source.Stop();

        float initialVolume = SettingsUtils.GetMasterVolume() / 3;
        source.volume = 0;

        source.clip = clipToFadeIn;
        source.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            source.volume = Mathf.Lerp(0f, initialVolume, t / fadeDuration);
            yield return null;
        }
        source.volume = initialVolume;
        //source.volume = Mathf.Lerp(0, SettingsUtils.GetMasterVolume(), fadeDuration);
    }

    private void StartFadeOut(AudioSource source, float duration)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(FadeOut(source, duration));
    }

    private IEnumerator FadeOut(AudioSource source, float fadeOutDuration)
    {
        for(float t = 0; t < fadeOutDuration; t+= Time.deltaTime)
        {
            source.volume = Mathf.Lerp(SettingsUtils.GetMasterVolume() / 3, 0f, t / fadeOutDuration);
            yield return null;
        }

        source.volume = 0;
        source.Stop();
    }

    private void StartCrossFade(AudioClip clipToFadeIn, float fadeOutDuration)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(CrossFade(clipToFadeIn, fadeOutDuration));
    }

    private IEnumerator CrossFade(AudioClip fadeInClip, float fadeDuration)
    {
        AudioSource fromSource = musicSource;
        AudioSource toSource = fadeSource;

        if (fromSource.clip == null)
        {
            Debug.LogError("CrossFade: No currently playing clip.");
            yield break;
        }

        // If the same clip is requested again, we can optionally skip
        if (fromSource.clip == fadeInClip)
        {
            Debug.LogWarning("WARNING: you are trying to switch to the same song as you are fading out ");
        }

        float masterVolume = SettingsUtils.GetMasterVolume();
        float fromStartVolume = fromSource.volume > 0f ? fromSource.volume : masterVolume / 3f;
        float toTargetVolume = masterVolume / 3f;

        // Setup fade in 
        toSource.clip = fadeInClip;
        toSource.volume = 0f;
        toSource.Play();

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / fadeDuration);

            fromSource.volume = Mathf.Lerp(fromStartVolume, 0f, normalized);
            toSource.volume = Mathf.Lerp(0f, toTargetVolume, normalized);

            yield return null;
        }

        fromSource.Stop();
        fromSource.volume = 0f;
        toSource.volume = toTargetVolume;

        // Swap roles after fade completes
        AudioSource temp = musicSource;
        musicSource = fadeSource;
        fadeSource = temp;

        currentCoroutine = null;

    }
}
