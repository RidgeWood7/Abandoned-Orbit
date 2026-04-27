using UnityEngine;

public class EnemyStatsInstance : MonoBehaviour
{
    public static EnemyStatsInstance Instance;

    public Stats stats = new()
    {
        speedMultiplier = 1f,
        damageMultiplier = 1f,

        healthPointsUp = 0f,
        ammoUp = 0
    };

    void Awake()
    {
        Instance = this;
    }
}
