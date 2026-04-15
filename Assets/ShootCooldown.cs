using UnityEngine;

public class ShootCooldown : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindFirstObjectByType<PlayerAnimation>().coolingReload = true;
        FindFirstObjectByType<PlayerAnimation>().coolingShot = true;
        animator.SetBool("IsShooting", true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindFirstObjectByType<PlayerAnimation>().coolingReload = false;
        FindFirstObjectByType<PlayerAnimation>().coolingShot = false;
        animator.SetBool("IsShooting", false);
    }
}
