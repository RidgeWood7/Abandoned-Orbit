using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCam : MonoBehaviour
{
    [SerializeField] private float SensitivityX = 100f;
    [SerializeField] private float SensitivityY = 100f;
    [SerializeField] private character_movement playerMovement;

    private AllControls controls;
    private CinemachineCamera cam;
    private CinemachinePanTilt camPanTilt;
    private Vector2 lookInput;








    private void Awake()
    {
        cam = GetComponent<CinemachineCamera>();
        camPanTilt = GetComponent<CinemachinePanTilt>();
        controls = new AllControls();
        controls.Enable();
        
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HandleMouseLook(InputAction.CallbackContext context)
    {
      
    }

    private void Update()
    {
       
    }
}


