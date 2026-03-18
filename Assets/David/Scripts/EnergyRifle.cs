using UnityEngine;

public class EnergyRifle : GunBase
{
    private void Awake()
    {
        
    }


    protected override void ShootGun()
   {
       // Implement the shooting logic for the energy rifle here
       Debug.Log("Energy Rifle fired!");
    }
}
