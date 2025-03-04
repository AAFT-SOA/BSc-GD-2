using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    public Vector3 offset;   

    // Update is called once per frame
    void LateUpdate()
    {        
        if(Target != null)
            transform.position = Target.position + offset;
    }
}
