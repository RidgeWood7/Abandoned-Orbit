using UnityEngine;

public class PowerupController : MonoBehaviour
{
	private PowerUpInstance player;

    private void Awake()
    {
        player = FindFirstObjectByType<PowerUpInstance>();
    }

    public void AddPowerup(Powerup powerup)
	{
		player.Apply(powerup);
    }
}
