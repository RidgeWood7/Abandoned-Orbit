using System.Collections.Generic;

public class PowerUpInstance : PowerUpBase
{
    public List<Powerup> powerups;

    public void Apply(Powerup powerup)
    {
        powerups.Add(powerup);

        if (powerup.modType == Powerup.ModifierType.additive)
            PlayerStatsInstance.Instance.stats += powerup.playerStatsDelta;
        else if (powerup.modType == Powerup.ModifierType.multiplicative)
            PlayerStatsInstance.Instance.stats *= powerup.playerStatsDelta;

        if (powerup.modType == Powerup.ModifierType.additive)
            EnemyStatsInstance.Instance.stats += powerup.enemyStatsDelta;
        else if (powerup.modType == Powerup.ModifierType.multiplicative)
            EnemyStatsInstance.Instance.stats *= powerup.enemyStatsDelta;
    }

    public void Remove(Powerup powerup)
    {
        powerups.Remove(powerup);

        if (powerup.modType == Powerup.ModifierType.additive)
            PlayerStatsInstance.Instance.stats -= powerup.playerStatsDelta;
        else if (powerup.modType == Powerup.ModifierType.multiplicative)
            PlayerStatsInstance.Instance.stats -= powerup.playerStatsDelta;

        if (powerup.modType == Powerup.ModifierType.additive)
            EnemyStatsInstance.Instance.stats /= powerup.enemyStatsDelta;
        else if (powerup.modType == Powerup.ModifierType.multiplicative)
            EnemyStatsInstance.Instance.stats /= powerup.enemyStatsDelta;
    }
}
