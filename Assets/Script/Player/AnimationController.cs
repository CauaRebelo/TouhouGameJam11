using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator agentAnimator;

    private void SetWalkAnimation(bool val)
    {
        agentAnimator.SetBool("Walk", val);
    }

    private void SetJumpAnimation(bool val)
    {
        agentAnimator.SetBool("Grounded", val);
    }

    public void AnimatePlayerWalk(float velocity)
    {
        if (velocity > 0)
        {
            SetWalkAnimation(true);
        }
        else if (velocity < 0)
        {
            SetWalkAnimation(true);
        }
        else
        {
            SetWalkAnimation(false);
        }
    }

    public void AnimatePlayerJump(bool grounded)
    {
        SetJumpAnimation(grounded);
    }
}
