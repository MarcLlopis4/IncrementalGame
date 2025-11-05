using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2  movementDirection;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;


  

 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

      

    }
    void Update()
    {
        movementDirection = playerInput.actions["Movement"].ReadValue<Vector2>();
        
        if (movementDirection != Vector2.zero)
        {
             Vector2 movementDirNorm = movementDirection.normalized;
             rb.linearVelocity = new Vector3(movementDirNorm.x, 0, movementDirNorm.y) * movementSpeed;

            Quaternion toRotation = Quaternion.LookRotation(new Vector3(movementDirection.x, 0, movementDirection.y), Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);



        }
    }


    
}
