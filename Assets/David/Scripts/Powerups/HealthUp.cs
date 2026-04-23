using UnityEngine;


public class HealthUp : PowerUpBase
{
    public float healthIncrease = 8f;
    public float enemyHealthIncrease = 4f;

    protected override void Awake()
    {
        Stats.Instance.healthPointsUp += healthIncrease;
        Stats.Instance.healthPointsUp += enemyHealthIncrease;

        character_movement player = FindFirstObjectByType<character_movement>();
        player.currentHealth = player.maxHealth;
    }

    protected override void OnDestroy()
    {
        Stats.Instance.healthPointsUp -= healthIncrease;
        Stats.Instance.healthPointsUp -= enemyHealthIncrease;
    }
}