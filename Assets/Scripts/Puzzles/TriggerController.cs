using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public MonoBehaviour[] triggerNodes;

    private TriggerNode[] triggerNodesCasted;

    private void Start()
    {
        triggerNodesCasted = (TriggerNode[])triggerNodes;
    }

    public void Awake()
    {
        foreach (var triggerNode in triggerNodesCasted)
        {
            triggerNode.Activate();
        }
    }
}
