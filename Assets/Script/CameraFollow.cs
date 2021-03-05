using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    /// <summary>
    /// This is just a smooth transition of the camera when the player progresses.
    /// </summary>
    void LateUpdate()
    {
        if (target != null)
        {
            if (target.position.y > transform.position.y)
            {
                Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
    }
}
