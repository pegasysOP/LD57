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
        room.transform.Translate(offset); //TODO: first we want to inverse the previous offset (i.e. if the offset is (0,0, 10) we want to do (0,0,-10) first. Then we add the current offset to it)
    }

    public override bool IsInteractable()
    {
        return true;
    }
}

