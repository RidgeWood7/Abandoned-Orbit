using UnityEngine;
using UnityEngine.Animations;
public class getvalueAttacking : MonoBehaviour
{
    public ShrimpleENEMY ShrimpleENEMY;
    public bool IsAttacking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
        IsAttacking = ShrimpleENEMY.isAttacking;
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsAttacking", IsAttacking);
    }
}
