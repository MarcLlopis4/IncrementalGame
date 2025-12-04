using UnityEngine;

public class CanvasDamage : MonoBehaviour
{

    GameObject player;
   
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
      
        //Quaternion rotation = Quaternion.rota(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        
        //gameObject.transform.rotation.SetFromToRotation(transform.eulerAngles, rotation );

        transform.LookAt(Camera.main.transform.position);
    }
}
