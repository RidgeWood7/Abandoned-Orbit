using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static EnemyStats instance;

    public float damageMultiplier = 1f;
    public float speedMultiplier = 1f;
    public float healthPointsUp;
    public float attackSpeedUp;

    void Awake()
    {   
        instance = this;
    }   
}
