using UnityEngine;
[CreateAssetMenu(fileName = "New Powerup", menuName = "Powerup")]
public class Powerup : ScriptableObject
{
    public enum ModifierType
    {
        additive,
        multiplicative
    }

    public Sprite powerUpIcon;
    [TextArea]public string description;

    public ModifierType modType;
    public Stats playerStatsDelta;
    public Stats enemyStatsDelta;
}
