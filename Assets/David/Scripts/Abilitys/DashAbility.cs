using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEngine;

public class DashAbility : AbilityBase
{
    [HideInInspector] public bool isDashing;  
    public float dashPower;//how much force the dash will apply to the player
    public float dashingDuration;
    public CharacterController character;
    public TrailRenderer tr;
    public character_movement playerMovement;
    public AnimationCurve dashCurve;
    public Transform Transform;
    public LayerMask wallCheck;



    public void Awake()
    {
        character = GetComponent<CharacterController>();
        tr = GetComponent<TrailRenderer>();
        playerMovement = GetComponent<character_movement>();
        
        
    }

    protected override void Ability()
    {
        StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        playerMovement.velocityY = 0;
        isDashing = true;
        playerMovement.enabled = false;
        tr.emitting = true;
        
        Vector3 oldPos = character.transform.position;
        Vector3 direction = Camera.main.transform.forward * playerMovement._direction.z + Camera.main.transform.right * playerMovement._direction.x;
        direction.y = 0;
        direction.Normalize();
        Vector3 newPos = oldPos + direction * dashPower;

        for (float T = 0; T< dashingDuration; T += Time.deltaTime)
        {
            character.transform.position = Vector3.Lerp(oldPos, newPos, dashCurve.Evaluate( T / dashingDuration));

            if (Physics.Raycast(character.transform.position, direction, 1f, wallCheck))
            {
                Debug.Log("Hit wall during dash, stopping dash");

                break;
            }

            yield return new WaitForEndOfFrame();
        }
        
        tr.emitting = false;
        playerMovement.enabled = true;
        isDashing = false;
        
        
    }
}
