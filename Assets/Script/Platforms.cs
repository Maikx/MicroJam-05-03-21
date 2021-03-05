using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private EdgeCollider2D eC;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("PlayerCheck").GetComponent<Transform>();
        eC = GetComponent<EdgeCollider2D>();
    }

    /// <summary>
    /// This is a bad way to check if the player is above the platform and to activate its collider.
    /// </summary>
    void Update()
    {
        if (target != null)
        {
            if (target.position.y >= transform.position.y)
                eC.enabled = true;
        }
    }
}
