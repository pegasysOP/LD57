using NUnit.Framework;
using UnityEngine;

public class DeletePrefab : MonoBehaviour
{
    public GameObject gameObjectToDisable;
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
        if(gameObjectToDisable != null) 
            gameObjectToDisable.SetActive(false);
    }
}
