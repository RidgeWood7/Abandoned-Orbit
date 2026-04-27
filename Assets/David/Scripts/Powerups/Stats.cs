using System;

[Serializable]
public struct Stats
{
    public float damageMultiplier;
    public float speedMultiplier;
    public float healthPointsUp;
    public float attackSpeedUp;
    public int ammoUp;

    public static Stats operator +(Stats lhs, Stats rhs)
    {
        return new Stats
        {
            damageMultiplier = lhs.damageMultiplier + rhs.damageMultiplier,
            speedMultiplier = lhs.speedMultiplier + rhs.speedMultiplier,
            healthPointsUp = lhs.healthPointsUp + rhs.healthPointsUp,
            attackSpeedUp = lhs.attackSpeedUp + rhs.attackSpeedUp,
            ammoUp = lhs.ammoUp + rhs.ammoUp
        };
    }

    public static Stats operator -(Stats lhs, Stats rhs)
    {
        return new Stats
        {
            damageMultiplier = lhs.damageMultiplier - rhs.damageMultiplier,
            speedMultiplier = lhs.speedMultiplier - rhs.speedMultiplier,
            healthPointsUp = lhs.healthPointsUp - rhs.healthPointsUp,
            attackSpeedUp = lhs.attackSpeedUp - rhs.attackSpeedUp,
            ammoUp = lhs.ammoUp - rhs.ammoUp
        };
    }

    public static Stats operator *(Stats lhs, Stats rhs)
    {
        return new Stats
        {
            damageMultiplier = lhs.damageMultiplier * rhs.damageMultiplier,
            speedMultiplier = lhs.speedMultiplier * rhs.speedMultiplier,
            healthPointsUp = lhs.healthPointsUp * rhs.healthPointsUp,
            attackSpeedUp = lhs.attackSpeedUp * rhs.attackSpeedUp,
            ammoUp = lhs.ammoUp * rhs.ammoUp
        };
    }

    public static Stats operator /(Stats lhs, Stats rhs)
    {
        return new Stats
        {
            damageMultiplier = lhs.damageMultiplier / rhs.damageMultiplier,
            speedMultiplier = lhs.speedMultiplier / rhs.speedMultiplier,
            healthPointsUp = lhs.healthPointsUp / rhs.healthPointsUp,
            attackSpeedUp = lhs.attackSpeedUp / rhs.attackSpeedUp,
            ammoUp = lhs.ammoUp / rhs.ammoUp
        };
    }
}
