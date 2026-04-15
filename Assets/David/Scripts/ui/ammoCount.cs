using TMPro;
using UnityEngine;

public class ammoCount : MonoBehaviour
{
    private GunBase gun;
    public TextMeshProUGUI ammoText;
    

    void Start()
    {
        gun =FindFirstObjectByType<GunBase>();
    }   

    // Update is called once per frame
    void Update()
    {
        ammoText.text = string.Format("Ammo: {0}", gun.bulletsLeft);

        //var damage = damage * Stats.Instance.damageMultiplier;
    }
}
