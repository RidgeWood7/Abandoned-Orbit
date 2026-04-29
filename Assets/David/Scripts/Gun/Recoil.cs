using Unity.Cinemachine;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource recoilSource;
    [SerializeField] float powerAmount;
    

    public void RecoilFire(Vector3 dir)
    {
        recoilSource.GenerateImpulseWithVelocity(dir);
        
    }
}
