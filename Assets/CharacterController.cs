using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    
    public float maxSpeed;
    public float normalSpeed = 5.0f;
    public float sprintSpeed = 7.0f;
    public float maxSprint = 8.0f;
    public float crouchSpeed = 2.5f;
    

    public CharacterController controller;

    float rotation = 0.0f;
    float camRotation = 0.0f;
    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;
    public float jumpForce = 300.0f;
    GameObject cam;
    Rigidbody myRigidbody;
    CapsuleCollider playerCollider;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;


    bool inClimbTrigger = false;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        playerCollider = GetComponent<CapsuleCollider>();

        
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((inClimbTrigger == true) && Input.GetKey(KeyCode.W))
        {
            myRigidbody.useGravity = false;
            myRigidbody.position += (Vector3.up * Time.deltaTime);
            rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

            camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
            cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

            camRotation = Mathf.Clamp(camRotation, -30.0f, 40.0f);

            Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);

            myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);
        } else
        {
            myRigidbody.useGravity = true;

            isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

            if (isOnGround && Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.AddForce(transform.up * jumpForce);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerCollider.height = 2;
                maxSpeed = sprintSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                maxSpeed = crouchSpeed;
                playerCollider.height = 1;
            }
            else
            {
                playerCollider.height = 2;
                maxSpeed = normalSpeed;
            }

            Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);

            myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

            rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

            camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
            cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

            camRotation = Mathf.Clamp(camRotation, -30.0f, 40.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "climb")
        {
            inClimbTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "climb")
        {
            inClimbTrigger = false;
        }
    }

}
