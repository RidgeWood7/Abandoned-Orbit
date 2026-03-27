using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Charge : MonoBehaviour
{
    public GunBase gun;

    public float lerpChargeSpeed;
    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;
    public Image chargeBar;


    
    void Start()
    {
        
    }

   
    void Update()
    {

        lerpChargeSpeed = 3f* Time.deltaTime;
        if (gun.bulletsLeft == 0)
        {
            
            Cooldown();
        }
    }

    public void ChargeAttack()
    {
        


    }
    public void Cooldown()
    {
        StartCoroutine(CooldownCoroutine());

    }

    IEnumerator CooldownCoroutine()
    {
        while (cur_cooldown < max_cooldown)
        {
            cur_cooldown += Time.deltaTime;
            chargeBar.fillAmount = Mathf.Lerp(chargeBar.fillAmount, cur_cooldown / max_cooldown, lerpChargeSpeed * Time.deltaTime);
            yield return null;
        }
        gun.bulletsLeft = gun.MagazineSize;
        cur_cooldown = 0f;
    }
}
