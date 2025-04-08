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
        this.gameObject.SetActive(false);
        AudioManager.Instance.PlayMusic(audioClip);

        if(prefabsToDisable != null && prefabsToDisable.Length != 0)
        {
            foreach(GameObject trigger in prefabsToDisable)
            {
                trigger.SetActive(false);
            }
            
        }
        
    }
}
