using UnityEngine;

public class SpawnRoom : Door
{
    public GameObject room;
    public bool correctDoor;
    public Vector3 offset;

    public override void Interact()
    {
        if (correctDoor)
        {
            SceneUtils.LoadMenuScene();
        }
        else
        {
            MoveRoom(offset);
            room.SetActive(true);
        }

        base.Interact();
    }

    private void MoveRoom(Vector3 offset)
    {
        room.transform.Translate(offset);
    }

    public override bool IsInteractable()
    {
        return true;
    }
}

