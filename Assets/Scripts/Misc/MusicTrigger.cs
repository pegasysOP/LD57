using UnityEngine;

public class MusicTrigger : MonoBehaviour
{

    public GameObject[] prefabsToDisable;

    public AudioClip audioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter - " + audioClip.name);
        //If we are alerady playing the correct song then don't retrigger this
        if (AudioManager.Instance.musicSource.clip != audioClip || AudioManager.Instance.fadeSource.clip != audioClip)
        {
            AudioManager.Instance.Play(AudioManager.Instance.musicSource, audioClip, AudioManager.FadeType.CrossFade);
        }

        Debug.Log("On Trigger Enter after cross fade- " + audioClip.name);

        if (prefabsToDisable != null && prefabsToDisable.Length != 0)
        {
            foreach(GameObject trigger in prefabsToDisable)
            {
                trigger.SetActive(false);
            }
            
        }
        
    }
}
