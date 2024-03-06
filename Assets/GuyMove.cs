using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMove : MonoBehaviour
{
    public float moveSpeed; 
    public float camSpeed;
    public float maxSpeed;
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
        }
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X"));
        Move();
       
    }
    private void Move()
    {
        Vector3 movement = Vector3.zero;
        movement += Vector3.forward * Input.GetAxis("Vertical");
        movement += Vector3.right * Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().AddForce(movement * Time.deltaTime * moveSpeed);

        movement = GetComponent<Rigidbody>().velocity;
        movement = Vector3.ClampMagnitude(movement,maxSpeed);
        GetComponent<Rigidbody>().velocity = movement;
    }
}
