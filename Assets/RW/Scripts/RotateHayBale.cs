using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Space;

public class RotateHayBale : MonoBehaviour
{
    public Vector3 movementSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(movementSpeed);

    }
}
