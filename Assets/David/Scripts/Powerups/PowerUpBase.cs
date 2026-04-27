using Unity.VisualScripting;
using UnityEngine;

//This script contains general variables and functions for all powerups.
public abstract class PowerUpBase : MonoBehaviour
{
    public string powerUpName;
    public Sprite powerUpIcon;
    

    protected abstract void Awake();
    protected abstract void OnDestroy();
}

