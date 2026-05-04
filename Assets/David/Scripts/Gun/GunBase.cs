using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class GunBase : MonoBehaviour
{
    public AudioManager audioManager;  // I have no idea where to put the reloading sound here, so just whenever you want to put that in just put  audioManager.PlaySFX(audioManager.Charge);
                                     
    public character_movement player;   
    public string gunName;
    public Sprite gunIcon;

    [SerializeField] private float baseDamage;
    public float fireRate;  //fire rate = seconds between shots
    private float CurrentFireRate;

    [SerializeField] private int baseMagazineSize;
    [HideInInspector] public int bulletsLeft;
    public int bulletsShot;

    [SerializeField] Recoil recoil;


    [InspectorName("Relaod time Per Bullet")]  public float reloadTime;
    public Image reloadSprite;

    private bool isHoldingShoot;
    private bool isReloading;

    private PlayerAnimation playerAnimation;
    [SerializeField] private AnimationClip shoot;
    [SerializeField] private AnimationClip reload;

    private bool CanShoot => bulletsLeft > 0 && !isReloading;
    public int MagazineSize => baseMagazineSize + PlayerStatsInstance.Instance.stats.ammoUp;
    public float Damage => baseDamage * PlayerStatsInstance.Instance.stats.damageMultiplier;

    public void Awake()
    {
        player = FindFirstObjectByType<character_movement>();
        playerAnimation = FindFirstObjectByType<PlayerAnimation>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        bulletsLeft = MagazineSize;
        CurrentFireRate = 0;
    }

    public void Update()
    {
       playerAnimation.shootSpeedMult = 1 / (fireRate / shoot.length);

        playerAnimation.reloadSpeedMult = 1 / (reloadTime / reload.length);

        playerAnimation.gunAnimator.SetBool("HasAmmo", bulletsLeft>0);
        playerAnimation.armsAnimator.SetBool("HasAmmo", bulletsLeft > 0);

        CurrentFireRate -= Time.deltaTime;

        if (isHoldingShoot && CanShoot)
        {
           
            if (CurrentFireRate <= 0f)
            {
                CurrentFireRate = fireRate; // Reset fire rate timer
                bulletsLeft--;
                bulletsShot++;
                audioManager.PlaySFX(audioManager.fire);
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
        if(playerAnimation.coolingShot) yield break;
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
            bulletsLeft = MagazineSize;
            yield return new WaitForSeconds(.3f);

            reloadSprite.fillAmount = 0;
            bulletsShot = 0;
           
        }
    }
}
