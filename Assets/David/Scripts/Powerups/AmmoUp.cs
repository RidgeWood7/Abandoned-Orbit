using UnityEngine;

public class Ammoup : PowerUpBase
{
    public int ammoUp =5;

    protected override void Awake()
    {
        Stats.Instance.ammoUp += ammoUp;

    }

    protected override void OnDestroy()
    {
        Stats.Instance.ammoUp -= ammoUp;
    }
}
