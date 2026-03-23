using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class GunBase : MonoBehaviour
{
    public string gunName;
    public Sprite gunIcon;

    public float damage;
    public float fireRate;  //fire rate = seconds between shots


    public float magazineSize;
    public float reloadTime;
    public Image reloadSprite;
    private float bulletsLeft;
    public bool canShoot = true;
    public AllControls allControls;

    public void Awake()
    {
        allControls = new AllControls();
        allControls.Player.Attack.performed += ApplyShootInput;
        reloadSprite = GetComponent<Image>();
        reloadTime = reloadTime - Time.deltaTime;
        bulletsLeft = magazineSize;
    }

    public void Update()
    {
        if (bulletsLeft <= 0)
        {
            canShoot = false;
            
        }
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


    public void ApplyReload(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            startReload();
        }
    }
    void startReload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    IEnumerator ReloadCoroutine()
    {
        if (bulletsLeft < magazineSize)
        {
            Debug.Log("Reloading...");
            canShoot = false;
            reloadSprite.fillAmount = 0f + reloadTime * Time.deltaTime;
            yield return new WaitForSeconds(reloadTime);
            canShoot = true;
            new WaitForSeconds(1f);
            reloadSprite.fillAmount = 0;
        }
    }
}
