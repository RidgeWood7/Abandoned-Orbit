using System.Collections;
using UnityEngine;

public class EnergyRifle : GunBase
{
    public GameObject Bullet;

    public float shootForce, upwardForce;

    public GameObject energyRifle;



    protected override void ShootGun()
    {

        GameObject bulletInstance = Instantiate(Bullet, transform.position, transform.rotation);

        Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            Vector3 shootDirection = transform.forward;
            bulletRigidbody.AddForce(shootDirection * shootForce + Vector3.up * upwardForce, ForceMode.Impulse);
        }

        Debug.Log("Shooting Energy Rifle");
    }

}
