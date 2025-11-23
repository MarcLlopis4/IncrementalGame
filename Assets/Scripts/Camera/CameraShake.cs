using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private Vector3 initialPos = new Vector3(0,0,0);
    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void ShakeCamera(float duration, float shakeAmount)
    {
        StartCoroutine(ShakeCoroutine(duration, shakeAmount));
    }
    IEnumerator ShakeCoroutine(float duration, float shakeAmount)
    {
        float time = 0f;

        while (time < duration) 
        {
            transform.localPosition = initialPos + Random.onUnitSphere * shakeAmount;

            time += Time.deltaTime;

            yield return null;
        
        
  
        }

        transform.localPosition = initialPos;

    }
}
