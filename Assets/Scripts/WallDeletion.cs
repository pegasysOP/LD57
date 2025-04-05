using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WallDeletion : MonoBehaviour
{
    public GameObject wall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E) && calculateMagnitude(GameManager.Instance.playerController.transform.position, this.transform.position) < 2.5f) {
            wall.SetActive(false);
        }
    }

    float calculateMagnitude(Vector3 origin, Vector3 target)
    {
        return Vector3.Distance(origin, target);
    }
}
