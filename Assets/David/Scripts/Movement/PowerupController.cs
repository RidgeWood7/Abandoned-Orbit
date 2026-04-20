using UnityEngine;

public class PowerupController : MonoBehaviour
{
	private	 GameObject enemyPrefab;
	
	void Start()
	{
		enemyPrefab = FindAnyObjectByType<ShrimpleENEMY>().gameObject;
    }
    public void AddAmmoPowerup()
	{
		gameObject.AddComponent<Ammoup>();
		enemyPrefab.AddComponent<Ammoup>();

    }
	public void AddDamagePowerup()
	{
		gameObject.AddComponent<DamageUp>();
		enemyPrefab.AddComponent<DamageUp>();
    }
}
