using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WallDeletion : MonoBehaviour
{
    public GameObject[] wallsToBeDeleted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            foreach (GameObject wall in wallsToBeDeleted)
            {
                wall.SetActive(false);
            }
        }
    }
}
