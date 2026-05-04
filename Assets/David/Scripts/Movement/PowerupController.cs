using UnityEngine;

public class PowerupController : MonoBehaviour
{
	private PowerUpInstance player;
    public AudioManager audioManager;

    private void Awake()
    {
        player = FindFirstObjectByType<PowerUpInstance>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void AddPowerup(Powerup powerup)
	{
        audioManager.PlaySFX(audioManager.HealAndPowerUp);
        player.Apply(powerup);
    }
}
