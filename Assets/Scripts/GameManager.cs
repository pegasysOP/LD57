using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController playerController;
    public CameraController cameraController;
    public PlayerInteraction playerInteraction;

    [Header("UI")]
    public PauseMenu pauseMenu;
    public Hud hud;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
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

    public void Pause(bool pausing)
    {
        Time.timeScale = pausing ? 0 : 1;

        cameraController.SetLocked(pausing);
        playerInteraction.SetLocked(pausing);
    }
}
