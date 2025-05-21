using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    public float FlySpeed;
    private float Yaw;
    public float YawAmount;
    public GameObject MyLight;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 90, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 20, Mathf.Abs(horizontalInput)) * Mathf.Sign(horizontalInput);

        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);

       


    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("is working");
        if (other.gameObject.tag=="kryg")
        {

            Destroy(other.gameObject);

        }

    }




}

