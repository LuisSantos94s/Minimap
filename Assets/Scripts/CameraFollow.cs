using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject target1;        // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.


    Vector3 offset1;                   // The initial offset from the target.

    public static bool stopCam = false;

    void Start ()
    {
        // Calculate the initial offset.
        offset1 = transform.position - target1.transform.position;
        stopCam = false;
    }


    void FixedUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos1 = target1.transform.position + offset1;

        // Smoothly interpolate between the camera's current position and it's target position.
        if (!stopCam)
        {
                transform.position = Vector3.Lerp(transform.position, targetCamPos1, smoothing * Time.deltaTime);
        }
    }

    public void StopCamera() //Para parar la camara cuando entre en el trigger
    {
        stopCam = true;
    }
        
    public void ResumeCamera() //Para que la camara vuelva a seguirte
    {
        stopCam = false;
    }
}
