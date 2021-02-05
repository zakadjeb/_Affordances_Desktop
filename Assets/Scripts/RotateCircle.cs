using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    [SerializeField] [Range(0f, 200f)] float RotateSpeed = 130f;
    private float OriginRotateSpeed;
    [SerializeField] [Range(0f, 2f)] float MoveUpSpeed;
    [SerializeField] [Range(0.5f, 2.0f)] float CircleHeight = 1.5f;
    public bool movedUp = false;
    private Vector3 targetPos;
    public List<Vector3> newPosTemp;
    public List<Vector3> newPos;
    public GameObject Manager;
    private Manager m;
    
    // Start is called before the first frame update
    void Start()
    {
        m = Manager.GetComponent<Manager>();
        MoveUpSpeed = MoveUpSpeed/1000;
        OriginRotateSpeed = RotateSpeed;

        //Generating a list of possible positions
        for (int i = -4; i <= -1; i++) {
            for (int y = -7; y <= -4; y++) {
                newPosTemp.Add(new Vector3(i,CircleHeight,y));
            }
        }

        //Defining the Random
        System.Random rnd = new System.Random();
        //Randomize the list
        for (int i = 0; i < m.TotalNumberTrials; i++) {
            newPos.Add(newPosTemp[rnd.Next(0,15)]);
        }

        transform.position = newPos[m.CurrentTrial];
    }
    private void OnTriggerEnter(Collider other) {
            if (!movedUp && !m.isDark) {
                m.circleTouched = true;
                movedUp = true;
                StartCoroutine(MoveCircle());
                RotateSpeed += 800f;
            }
    }

    private void OnTriggerExit(Collider other) {
        RotateSpeed -= 800f;
    }

    // Update is called once per frame
    void Update()
    {
        // Identifying the target position of the circle
        targetPos = new Vector3(newPos[m.CurrentTrial].x,newPos[m.CurrentTrial].y+2,newPos[m.CurrentTrial].z);

        if (m.isDark && movedUp) {
            transform.position = newPos[m.CurrentTrial];
            RotateSpeed = OriginRotateSpeed;
            m.circleTouched = false;
            movedUp = false;
        }
        transform.RotateAround(transform.position, Vector3.up, RotateSpeed*Time.deltaTime);
    }
    IEnumerator MoveCircle(){
        for (float f = 0; f < 1; f += MoveUpSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x , transform.position.y+2, transform.position.z), f);
            //transform.position = Vector3.Lerp(transform.position, new Vector3(newPos[m.CurrentTrial].x, newPos[m.CurrentTrial].y+2, newPos[m.CurrentTrial].z), f);
            yield return new WaitForSeconds(MoveUpSpeed);
        }
        //transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        //yield return null;
    }
}
