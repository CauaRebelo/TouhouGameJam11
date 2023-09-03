using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator agentAnimator;

    public void SetWalkAnimation(bool val)
    {
        agentAnimator.SetBool("Walk", val);
    }

    public void AnimatePlayer(float velocity)
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
}
