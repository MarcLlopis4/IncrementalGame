using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;
    Vector3 direction;

    [SerializeField] private float bulletSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       direction = transform.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Motion();
    }

    private void Motion()
    {
        rb.linearVelocity = direction * bulletSpeed;
    }
}
