using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2  movementDirection;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private CameraShake cameraShake;


  

 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

      

    }
    void FixedUpdate()
    {
        movementDirection = playerInput.actions["Movement"].ReadValue<Vector2>();
        
        if (movementDirection != Vector2.zero)
        {
             Vector2 movementDirNorm = movementDirection.normalized;
             rb.linearVelocity = new Vector3(movementDirNorm.x, 0, movementDirNorm.y) * movementSpeed;

            Quaternion toRotation = Quaternion.LookRotation(new Vector3(movementDirection.x, 0, movementDirection.y), Vector3.up);

           transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);



        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {

        switch (context.phase)
        {
            case InputActionPhase.Performed: 
                
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

                cameraShake.ShakeCamera(0.3f, 0.02f);
               

            break;
        }
       
        
    }


    
}
