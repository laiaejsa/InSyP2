using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;

    public GameObject hayMachinePrefab;
    public Transform haySpawnpoint; 
    public float shootInterval; 
    private float shootTimer;

    public Transform modelParent; 

    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;

    void Start()
    {
        LoadModel();
    }

    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject); 

        switch (GameSettings.hayMachineColor) 
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }

    void Update()
    {
        UpdateMovement();
        Shotting();
        UpdateShooting();
    }
    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); 
 
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) 
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) 
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }

    }

    void Shotting()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(hayMachinePrefab, transform.position,Quaternion.identity);
           
            SoundManager.Instance.PlayShootClip();
        }
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime; 

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) 
        {
            shootTimer = shootInterval; 
            Shotting(); 
        }
    }
}
