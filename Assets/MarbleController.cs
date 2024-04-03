using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour
{
    //determines how fast the ball will roll forward
    public float acceleration;
    //this will hold the camera anchor object
    public GameObject cameraAnchor;
    //how many degrees per second the player can turn
    public float cameraTurnSpeed;
    public float jumpPower;
    public float gravity;
    public Vector2 inputThisFrame;
    private Vector3 movementThisFrame = new Vector3();
    [SerializeField] private LayerMask groundedMask;

    public Rigidbody rb;

    public float score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis will be somewhere between -1 and 1
        inputThisFrame.x = Input.GetAxis("Horizontal");
        inputThisFrame.y = Input.GetAxis("Vertical");

        movementThisFrame.x = inputThisFrame.x;
        movementThisFrame.z = inputThisFrame.y;


        movementThisFrame.y = rb.velocity.y - gravity * Time.deltaTime;
        cameraAnchor.transform.Rotate(Vector3.up, cameraTurnSpeed * Time.deltaTime * inputThisFrame.x);

        cameraAnchor.transform.position = transform.position;


        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity += Vector3.up * 10f;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(cameraAnchor.transform.forward * acceleration * inputThisFrame.y);
        if (rb.velocity.magnitude > 80)
        {
            rb.velocity *= 0.98f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //we're going to check what we touched
        if (other.gameObject.tag == "Pickup")
        {
            Destroy(other.gameObject);
            score += other.GetComponent<Pickup>().pointWorth;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Speed")
        {
            rb.velocity *= 1.15f;
        }

        if (other.gameObject.tag == "Jump")
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.up * 500f);
            rb.velocity += Vector3.up * 50f;
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.001f, groundedMask);
    }
}
