using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] private Vector3 camOffset;

    [SerializeField] private float smoothtime = 0.3f;
    
    [SerializeField] private Vector3 velocity;

    [SerializeField] private Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = target.position + camOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothtime);

      
        //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothtime);

        //transform.position = targetPos;
    }
}
