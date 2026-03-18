using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class GunBase : MonoBehaviour
{
    public string gunName;
    public Sprite gunIcon;
    public float damage;
    public float fireRate; //fire rate = seconds between shots
    public float magazineSize;
    public float reloadTime;
    private int bulletsLeft, bulletsShot;
    public bool canShoot = true;
    public AllControls allControls;

    public void Awake()
    {
        allControls = new AllControls();
        allControls.Player.Attack.performed += ApplyShootInput;
    }

    public void Update()
    {

    }

    public void ApplyShootInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (canShoot)
            {
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
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
