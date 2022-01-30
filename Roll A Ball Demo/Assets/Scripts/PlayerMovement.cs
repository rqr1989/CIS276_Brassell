using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveInput;
    [SerializeField] private Rigidbody rb;
   
    private PlayerCamera playerCam;

    [SerializeField] private float speed = 3f;

    [SerializeField] private float jumpForce = 3f;

    private void Awake()
    {
        //sets rb equal to Rigibody
        rb = GetComponent<Rigidbody>();

        playerCam = FindObjectOfType<PlayerCamera>();

    }
    //works with physics timestep
    private void FixedUpdate()
    {
        //calls MovePlayer method
        MovePlayer();
    }

    private void Update()
    {
        //assign
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
   //jump
    if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }

    
    }
    private void MovePlayer()
    {
        transform.forward = playerCam.transform.forward;

        Vector3 directionX = transform.right.normalized * moveInput.x;
        
        Vector3 directionZ = transform.forward.normalized * moveInput.z;


        rb.velocity = new Vector3(0, rb.velocity.y, 0) + (directionX + directionZ) * speed;

    }
}
