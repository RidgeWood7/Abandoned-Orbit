using UnityEngine;

public class DamageUp : PowerUpBase
{
    public float damageMultiplier = .5f;
    public float enemyDamageMultiplier = .2f;

    protected override void Awake()
    {
        Stats.Instance.damageMultiplier += damageMultiplier;
        EnemyStats.instance.damageMultiplier += enemyDamageMultiplier;
    }

    protected override void OnDestroy()
    {
        Stats.Instance.damageMultiplier -= damageMultiplier;
        EnemyStats.instance.damageMultiplier -= enemyDamageMultiplier;
    }
}
