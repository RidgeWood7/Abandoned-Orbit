using UnityEngine;

public class Ammoup : PowerUpBase
{
    public int ammoUp;

    protected override void Awake()
    {
        Stats.Instance.ammoUp += ammoUp;

    }

    protected override void OnDestroy()
    {
        Stats.Instance.ammoUp -= ammoUp;
    }
}
