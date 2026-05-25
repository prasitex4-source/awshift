using UnityEngine;

public class CameraIntro : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void EndIntro()
    {
        animator.enabled = false;
    }
}