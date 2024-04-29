using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 movementSpeed;
    public Space translationSpeed;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, translationSpeed);

    }
}
