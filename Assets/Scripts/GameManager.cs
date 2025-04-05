using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController playerController;
    public CameraController cameraController;

    [Header("UI")]
    public PauseMenu pauseMenu;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseMenu.Toggle();
    }

    public static void Pause(bool pausing)
    {
        Time.timeScale = pausing ? 0 : 1;

        // TODO: Also lock player input
    }
}
