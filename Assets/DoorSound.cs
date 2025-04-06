using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class DoorSound : MonoBehaviour
{
    public AudioSource doorSource;
    public int interval = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (doorSource == null)
            doorSource = GetComponent<AudioSource>();

        StartCoroutine(PlaySoundLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlaySoundLoop()
    {
        while (true)
        {
            doorSource.Play();
            yield return new WaitForSeconds(interval);
        }
    }
}
