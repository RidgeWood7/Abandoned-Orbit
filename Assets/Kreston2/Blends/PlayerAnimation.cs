using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animators and Bools")]
    private bool isWalking = false;
    [SerializeField] private Animator armsAnimator;
    [SerializeField] private Animator gunAnimator;
    public bool coolingShot = false;
    public bool coolingReload = false;
    [Header("Shooting and Reloading")]
    [SerializeField] private float shootSpeedMult = 1f;
    [SerializeField] private float reloadSpeedMult = 1f;
    [SerializeField] private bool isAutomatic;

    private void Update()
    {
        if (armsAnimator == null) return;
        if (gunAnimator == null) return;

        // Walking Bool
        if (Keyboard.current.wKey.isPressed || Keyboard.current.aKey.isPressed || Keyboard.current.sKey.isPressed || Keyboard.current.dKey.isPressed)
            isWalking = true;
        else
            isWalking = false;

        armsAnimator.SetBool("IsWalking", isWalking);
        gunAnimator.SetBool("IsWalking", isWalking);

        //Shoot
        armsAnimator.SetFloat("ShootSpeedMult", shootSpeedMult);
        gunAnimator.SetFloat("ShootSpeedMult", shootSpeedMult);
        if (isAutomatic)
        {
            if (Mouse.current.leftButton.isPressed && !coolingShot)
            {
                armsAnimator.SetTrigger("Shoot");
                gunAnimator.SetTrigger("Shoot");
            }
        }
        else
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && !coolingShot)
            {
                armsAnimator.SetTrigger("Shoot");
                gunAnimator.SetTrigger("Shoot");
            }
        }

        // Reload
        armsAnimator.SetFloat("ReloadSpeedMult", reloadSpeedMult);
        gunAnimator.SetFloat("ReloadSpeedMult", reloadSpeedMult);

        if (Keyboard.current.rKey.wasPressedThisFrame && !coolingReload)
        {
            armsAnimator.SetTrigger("Reload");
            gunAnimator.SetTrigger("Reload");
        }
    }
}