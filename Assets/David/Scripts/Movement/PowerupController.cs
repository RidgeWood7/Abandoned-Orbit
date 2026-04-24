using UnityEngine;

public class PowerupController : MonoBehaviour
{
	private	GameObject enemyPrefab;
	
	
	void Start()
	{
		enemyPrefab = FindAnyObjectByType<ShrimpleENEMY>().gameObject;
    }

    public void AddPowerup(Powerup powerup)
	{
		gameObject.GetComponent<PowerUpInstance>().Apply(powerup);
		enemyPrefab.GetComponent<PowerUpInstance>().Apply(powerup);
    }
}
