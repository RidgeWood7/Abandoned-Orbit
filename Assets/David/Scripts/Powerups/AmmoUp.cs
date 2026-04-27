using UnityEngine;

public class Ammoup : PowerUpBase
{
    public int ammoUp =5;
    public float enemyAttackSpeedUp = .2f;

    protected override void Awake()
    {
        Stats.Instance.ammoUp += ammoUp;
        EnemyStats.instance.attackSpeedUp -= enemyAttackSpeedUp;

    }

    protected override void OnDestroy()
    {
        Stats.Instance.ammoUp -= ammoUp;
        EnemyStats.instance.attackSpeedUp += enemyAttackSpeedUp;
    }
}
