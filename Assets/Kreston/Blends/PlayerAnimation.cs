using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animators and Bools")]
    private bool isWalking = false;
    public Animator armsAnimator;
    public Animator gunAnimator;
    public bool coolingShot = false;
    public bool coolingReload = false;
    
    [Header("Shooting and Reloading")]
    [SerializeField] public float shootSpeedMult = 1f;
    [SerializeField] public float reloadSpeedMult = 1f;
    [SerializeField] private bool isAutomatic;
     private GunBase gunBase;   
    [Header("Particles")]
    [SerializeField] private List<ParticleSystem> shootParticles = new();
    [SerializeField] private List<ParticleSystem> reloadParticles = new();

    private void Start()
    {
        gunBase = FindFirstObjectByType<GunBase>();
    }
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

                if (shootParticles != null && shootParticles.Count > 0)
                {
                    foreach (var item in shootParticles)
                    {
                        if(gunBase.bulletsLeft > 0) 
                            item.Play();
                    }
                }
            }
        }
        else
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && !coolingShot)
            {
                armsAnimator.SetTrigger("Shoot");
                gunAnimator.SetTrigger("Shoot");

                if (shootParticles != null && shootParticles.Count > 0)
                {
                    foreach (var item in shootParticles)
                    {
                        if(gunBase.bulletsLeft > 0)
                            item.Play();
                    }
                }
            }
        }

        // Reload
        armsAnimator.SetFloat("ReloadSpeedMult", reloadSpeedMult);
        gunAnimator.SetFloat("ReloadSpeedMult", reloadSpeedMult);

        if (Keyboard.current.rKey.wasPressedThisFrame && !coolingReload)
        {
            armsAnimator.SetTrigger("Reload");
            gunAnimator.SetTrigger("Reload");

            if (reloadParticles != null && reloadParticles.Count > 0)
            {
                foreach (var item in reloadParticles)
                {
                    item.Play();
                }
            }
        }
    }
}