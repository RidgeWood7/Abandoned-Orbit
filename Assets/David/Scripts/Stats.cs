using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats Instance;

    public float damageMultiplier = 1f;
    public float speedMultiplier = 1f;
    public float healthPointsUp;
    public int ammoUp;

    void Awake()
    {
        Instance = this;
    }
}
