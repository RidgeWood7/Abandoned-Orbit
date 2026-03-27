using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class GunBase : MonoBehaviour
{
    public character_movement player;   
    public string gunName;
    public Sprite gunIcon;

    [SerializeField] private float baseDamage;
    public float fireRate;  //fire rate = seconds between shots
    private float CurrentFireRate;

    [SerializeField] private int baseMagazineSize;
    [HideInInspector] public int bulletsLeft;
    public int bulletsShot;
    
    

    [InspectorName("Relaod time Per Bullet")]  public float reloadTime;
    public Image reloadSprite;

    private bool isHoldingShoot;
    private bool isReloading;

    private bool CanShoot => bulletsLeft > 0 && !isReloading;
    public int MagazineSize => baseMagazineSize + Stats.Instance.ammoUp;
    public float Damage => baseDamage * Stats.Instance.damageMultiplier;

    public void Awake()
    {
        player = FindFirstObjectByType<character_movement>();
       
    }
    private void Start()
    {
        bulletsLeft = MagazineSize;
        CurrentFireRate = 0;
    }

    public void Update()
    {
       

        CurrentFireRate -= Time.deltaTime;

        if (isHoldingShoot && CanShoot)
        {
            if (CurrentFireRate <= 0f)
            {
                CurrentFireRate = fireRate; // Reset fire rate timer
                bulletsLeft--;
                bulletsShot++;

                ShootGun();
            }
        }
    }

    public void ApplyShootInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
                       
            isHoldingShoot = true;
            
        }
        else if (context.canceled)
        {
            isHoldingShoot = false;
        }
    }

    protected abstract void ShootGun();

    public void ApplyReload(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    IEnumerator ReloadCoroutine()
    {
        if (bulletsLeft < MagazineSize)
        {
            Debug.Log("Reloading...");

            isReloading = true;
           

            int oldBullets = bulletsLeft;
            for (float t = 0; t < reloadTime ; t += Time.deltaTime)
            {
                reloadSprite.fillAmount = t / reloadTime;
                bulletsLeft = Mathf.RoundToInt(Mathf.Lerp(oldBullets, MagazineSize, t / reloadTime ));

                yield return new WaitForEndOfFrame();
            }

            isReloading = false;

            yield return new WaitForSeconds(1f);

            reloadSprite.fillAmount = 0;
            bulletsShot = 0;
            bulletsLeft = MagazineSize;
        }
    }

    private void DamageEnemy(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            

            // Handle collision with enemy
            Debug.Log("Collided with Enemy!");
        }
    }
}
