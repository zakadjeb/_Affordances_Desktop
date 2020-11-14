using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAround : MonoBehaviour
{

    private float MovementX;
    private float MovementY;
    public float MovingSpeed = .8f;
    public float MouseSpeed = 2.0f;

    private float MouseX = 0.0f;
    private float MouseY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        MouseX = 180f;
    }

    // Update is called once per frame
    void Update()
    {
        MovementX = Input.GetAxis ("Horizontal");
        MovementY = Input.GetAxis ("Vertical");

        if (MovementY != 0 || MovementX != 0) 
        {
            move();
        }

        if (Input.GetMouseButton(0)){
            MouseX += MouseSpeed * Input.GetAxis("Mouse X");
            // MouseY += MouseSpeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(MouseY, MouseX, 0.0f);
        }
        
    }

    void move()
    {
        transform.position += transform.forward * MovementY * Time.deltaTime * MovingSpeed;
        transform.position += transform.right * MovementX * Time.deltaTime * MovingSpeed;
    }

    // void rotate()
    // {
    //     transform.Rotate (new Vector3 (0f, inputX * Time.deltaTime, 0f) * RotateSpeed);
    // }
}
