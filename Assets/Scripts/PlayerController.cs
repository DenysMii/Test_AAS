
using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody rb;
    private AudioSource audio;

    private InputAction moveAction;
    private InputAction jumpAction;

    private float currentSpeed;

    private void Awake()
    {
        Cursor.visible = false;

        if (!TryGetComponent<Rigidbody>(out rb))
            rb = gameObject.AddComponent<Rigidbody>();

        if(!TryGetComponent<AudioSource>(out audio))
            audio = gameObject.AddComponent<AudioSource>();

        var playerMap = actionAsset.FindActionMap("Player");

        moveAction = playerMap?.FindAction("Move");
        moveAction?.Enable();
            
        jumpAction = playerMap?.FindAction("Jump");
        if ( jumpAction != null)
        {
            jumpAction.Enable();
            jumpAction.performed += OnJump;
        }
        
        currentSpeed = horizontalSpeed;
    }

    private void Update()
    {
        float moveForce = moveAction.ReadValue<float>() * currentSpeed;
        rb.AddForce(moveForce, 0, 0, ForceMode.Acceleration);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        audio.Play();
        rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        jumpAction.performed -= OnJump;
        currentSpeed = horizontalSpeed / 2;
    }

    private void OnDisable()
    {
        if( jumpAction != null )
            jumpAction.performed -= OnJump;
    }

    private void OnDestroy()
    {
        moveAction?.Disable();
        jumpAction?.Disable();
        Cursor.visible = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            jumpAction.performed += OnJump;
            currentSpeed = horizontalSpeed;
        }
    }

}
