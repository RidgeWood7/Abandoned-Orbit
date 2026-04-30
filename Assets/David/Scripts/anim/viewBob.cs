using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class viewBob : MonoBehaviour
{
    public Animator animator;

    public void Update()
    {

    }
    public void walking(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("isWalking", true); 
            Debug.Log("Checking for movement input...");
        }
        else
        {
            animator.SetBool("isWalking", false);
            if(context.canceled)
            {
                gameObject.transform.localPosition = new Vector3(0,0,-.11f);
            }
        }
    }
}
