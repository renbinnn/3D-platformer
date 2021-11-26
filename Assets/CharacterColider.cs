using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColider : MonoBehaviour
{
    

    public float maxSpeed = 3.0f;
    public float normalSpeed = 10.0f;
    public float sprintSpeed = 20.0f;

    public float maxSprint = 5.0f;
    float sprintTimer; 
    
    float rotation = 0.0f;

    float camRotation = 0.0f;
    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;

     
    GameObject cam;
    Rigidbody myRigidbody;

    public float jumpForce = 300.0f; 



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
            
        sprintTimer = maxSprint;

        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)&& sprintTimer > 0.0f )
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime; 
        } else
        {
              maxSpeed = normalSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false )
            {
                sprintTimer = sprintTimer + Time.deltaTime; 
            }
        }

        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce); 
        }

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed + (transform.right * Input.GetAxis("Horizontal") * maxSpeed));


        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);  
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);
       

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        Debug.Log(rotation);

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-camRotation, 0.0f, 0.0f));


        myRigidbody = GetComponent<Rigidbody>();
    }
}
