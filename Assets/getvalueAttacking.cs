using UnityEngine;
using UnityEngine.Animations;
public class GetvalueAttacking : MonoBehaviour
{
    public ShrimpleENEMY ShrimpleENEMY;
    public bool IsAttacking1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
        IsAttacking1 = ShrimpleENEMY.isAttacking;
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsAttacking", IsAttacking1);
    }
}
