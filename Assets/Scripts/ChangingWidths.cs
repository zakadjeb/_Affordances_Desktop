using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWidths : MonoBehaviour
{
    public GameObject WallRight;
    public GameObject WallLeft;
    public float NarrowWidth = 0.1f;
    public float MidWidth = 0.5f;
    public float WideWidth = 0.75f;
    public GameObject Manager;
    private Manager m;

    // Start is called before the first frame update
    void Start()
    {
        m = Manager.GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m.CurrentDoorType == "Narrow") {
            WallRight.transform.position = new Vector3(-NarrowWidth, 0, 0);
            WallLeft.transform.position = new Vector3(NarrowWidth, 0, 0);
        }
        if (m.CurrentDoorType == "Mid") {
            WallRight.transform.position = new Vector3(-MidWidth, 0, 0);
            WallLeft.transform.position = new Vector3(MidWidth, 0, 0);
        }
        if (m.CurrentDoorType == "Wide") {
            WallRight.transform.position = new Vector3(-WideWidth, 0, 0);
            WallLeft.transform.position = new Vector3(WideWidth, 0, 0);
        }
    }
}
