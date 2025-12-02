using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;
    Vector3 direction;
    [SerializeField] float timeToDestroy;

    [SerializeField] private float bulletSpeed;

    bool canMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = transform.forward;
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canMove)
        {
            Motion();
        }
       
    }

    private void Motion()
    {
        rb.linearVelocity = direction * bulletSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":

                canMove = false;
                rb.useGravity = true;
                rb.AddForce(Vector3.forward * 4);
               
                Destroy(this.gameObject,0.5f);

                break;
        }
    }
}
