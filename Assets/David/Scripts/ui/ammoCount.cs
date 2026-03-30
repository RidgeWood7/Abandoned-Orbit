using TMPro;
using UnityEngine;

public class ammoCount : MonoBehaviour
{
    private GunBase gun;
    public TextMeshProUGUI ammoText;
    private int ammoAmount;
    

    void Start()
    {
        gun =FindFirstObjectByType<GunBase>();
    }   

    // Update is called once per frame
    void Update()
    {
        ammoAmount = gun.bulletsLeft;
        ammoText.text = ammoAmount.ToString("Ammo:" + ammoAmount);

        //var damage = damage * Stats.Instance.damageMultiplier;
    }
}
