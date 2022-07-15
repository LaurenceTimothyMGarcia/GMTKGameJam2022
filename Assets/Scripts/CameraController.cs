using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    //2) smooth camera
    [Range(1,10)]
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        //add player to transform target
        Vector3 targetPosition = target.position + offset;

        //2) smooth camera
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);//smooths out camera movement

        transform.position = smoothPosition;
    }
}
