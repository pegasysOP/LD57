using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WallDeletion : MonoBehaviour
{
    public GameObject wall;
    public float activiationDistance = 6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E) && calculateMagnitude(GameManager.Instance.playerController.transform.position, this.transform.position) < activiationDistance) {
            Ray ray = new Ray(GameManager.Instance.cameraController.transform.position, GameManager.Instance.cameraController.transform.forward);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform)
                {
                    wall.SetActive(false);

                    Debug.Log("Door hit");
                }
            }
        }
    }

    float calculateMagnitude(Vector3 origin, Vector3 target)
    {
        return Vector3.Distance(origin, target);
    }
}
