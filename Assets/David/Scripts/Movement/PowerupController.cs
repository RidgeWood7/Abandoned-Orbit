using UnityEngine;

public class PowerupController : MonoBehaviour
{
    character_movement character;
	private PowerUpInstance player;
    public AudioManager audioManager;

    private void Awake()
    {
        player = FindFirstObjectByType<PowerUpInstance>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void AddPowerup(Powerup powerup)
	{
        character = FindFirstObjectByType<character_movement>();
        character.currentHealth = character.maxHealth;
        audioManager.PlaySFX(audioManager.HealAndPowerUp);
        player.Apply(powerup);
    }
}
