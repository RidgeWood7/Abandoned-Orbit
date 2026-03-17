using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class GunBase : MonoBehaviour
{
    public string gunName;
    public Sprite gunIcon;
    public float damage;
    public float shootCooldown;
    public bool canShoot = true;
    public AllControls allControls;
    


    public void ApplyShootInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
          if (canShoot)
          {
            Debug.Log("Shooting " + gunName);
            StartShootCooldown();
            ShootGun();
          }   
        }
    }

    protected abstract void ShootGun();

    void StartShootCooldown()
    {
       StartCoroutine(ShootCooldownCoroutine());
    }

    IEnumerator ShootCooldownCoroutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
