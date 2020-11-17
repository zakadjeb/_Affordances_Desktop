using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAround : MonoBehaviour
{

    private float MovementX;
    private float MovementY;
    [SerializeField] [Range(0f, 10f)] public float MovingSpeed;
    [SerializeField] [Range(0f, 10f)] public float MouseSpeed;
    public float PlayerHeight = 1.8f;

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
            transform.position += transform.forward * MovementY * Time.deltaTime * MovingSpeed;
            transform.position += transform.right * MovementX * Time.deltaTime * MovingSpeed;
            transform.position = new Vector3(transform.position.x, PlayerHeight, transform.position.z);
        }

        if (Input.GetMouseButton(0)){
            MouseX += MouseSpeed * Input.GetAxis("Mouse X");
            MouseY += MouseSpeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(MouseY, MouseX, 0.0f);
        }
        
    }

}
