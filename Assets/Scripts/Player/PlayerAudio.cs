using System.Collections;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Range(0f, 1f)]
    public float footstepTimer;

    private Coroutine footstepAudio;

    private void Update()
    {
        if (footstepAudio == null)
            footstepAudio = StartCoroutine(Footstep());
    }

    private IEnumerator Footstep()
    {
        if (GameManager.Instance.playerController.groundDetector.IsGrounded && GameManager.Instance.playerController.inputDir.magnitude > 0f)
        {
            AudioManager.Instance.PlayFootstep();
            yield return new WaitForSeconds(footstepTimer);
            footstepAudio = null;
        }
    }
}
