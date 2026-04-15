using UnityEngine;

public class DamageUp : PowerUpBase
{
    public float damageMultiplier = 1.5f;

    protected override void Awake()
    {
        Stats.Instance.damageMultiplier *= damageMultiplier;
    }

    protected override void OnDestroy()
    {
        Stats.Instance.damageMultiplier /= damageMultiplier;
    }
}
