using UnityEngine;

public class PowerupController : MonoBehaviour
{
	public void AddAmmoPowerup()
	{
		gameObject.AddComponent<Ammoup>();

	}
	public void AddDamagePowerup()
	{
		gameObject.AddComponent<DamageUp>();
    }
}
