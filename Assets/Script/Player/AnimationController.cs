using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator agentAnimator;
    [SerializeField] private PlayerItemGrab playerItemGrab;

    private void SetWalkAnimation(bool val)
    {
        agentAnimator.SetBool("Walk", val);
    }

    private void SetItemWalkAnimation(bool val)
    {
        agentAnimator.SetBool("ItemWalk", val);
    }

    private void SetJumpAnimation(bool val)
    {
        agentAnimator.SetBool("Grounded", val);

        if (!val && playerItemGrab.itemCarry)
        {
            agentAnimator.SetBool("ItemJump", true);
        }
        else
        {
            agentAnimator.SetBool("ItemJump", false);
        }
    }

    public void AnimatePlayerWalk(float velocity)
    {
        // Se player não carrega um item
        if (!playerItemGrab.itemCarry)
        {
            SetItemWalkAnimation(false);

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

        // Se player carrega um item
        else
        {
            SetItemWalkAnimation(true);

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

    public void AnimatePlayerJump(bool grounded)
    {
        SetJumpAnimation(grounded);
    }
}
