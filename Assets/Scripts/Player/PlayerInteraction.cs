using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange;
    public bool canInteract;
    public LayerMask interactLayer;

    private IInteractable highlightedInteractable;
    private bool locked;

    private void Start()
    {
        if (GameManager.Instance.playerController)
            Debug.LogError("WARNING: Duplicate player interaction instances in scene");

        GameManager.Instance.playerInteraction = this;
    }

    private void Update()
    {
        HandleInteractionHighlight();

        if (locked)
            return;

        if (Input.GetKeyDown(KeyCode.E) && highlightedInteractable != null)
        {
            highlightedInteractable.Interact();
        }
    }

    private void HandleInteractionHighlight()
    {
        Debug.DrawRay(transform.position, transform.forward * interactRange, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactRange, interactLayer))
        {
            if (hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                canInteract = true;
                if (interactable == null)
                    return;

                if (highlightedInteractable == null && interactable.IsInteractable())
                {
                    highlightedInteractable = interactable;
                    GameManager.Instance.hud.ShowInteractPrompt(true);
                    //Debug.Log($"{hit.collider.name}");
                }
            }
            else
            {
                if (highlightedInteractable == null)
                    return;

                highlightedInteractable = null;
                GameManager.Instance.hud.ShowInteractPrompt(false);
                //Debug.Log($"nothing to interact with");
                canInteract = false;
            }
        }
        else
        {
            if (highlightedInteractable == null)
                return;

            highlightedInteractable = null;
            GameManager.Instance.hud.ShowInteractPrompt(false);
            //Debug.Log($"nothing to interact with");
            canInteract = false;
        }
    }

    public void SetLocked(bool locked)
    {
        this.locked = locked;
    }
}
