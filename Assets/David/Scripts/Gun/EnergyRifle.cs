using System.Collections;
using UnityEngine;

public class EnergyRifle : GunBase
{
    public GameObject Bullet;

    public float shootForce, upwardForce;

    public GameObject energyRifle;



    protected override void ShootGun()
    {
        
        StartCoroutine(Shoot());
        Debug.Log("Shooting Energy Rifle");
    }


    IEnumerator Shoot()
    {
        

        if (Bullet != null)
        {

            GameObject bulletInstance = Instantiate(Bullet, transform.position, transform.rotation);

            Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                Vector3 shootDirection = transform.forward;
                bulletRigidbody.AddForce(shootDirection * shootForce + Vector3.up * upwardForce, ForceMode.Impulse);
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
}
