using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public GameObject Door;
    private Color originalColor;
    private Collider doorCollider;
    public bool Colliding;
    private float time = 0f;
    public Color NoGoColor;
    public Color GoColor;
    public GameObject Manager;
    private Manager m;
    public bool doneChange;

    // Start is called before the first frame update
    void Start()
    {
        m = Manager.GetComponent<Manager>();
        originalColor = Door.GetComponent<Renderer>().material.color;
        doorCollider = Door.GetComponent<Collider>();
        doneChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m.shownImperative && !doneChange){
            ColourChanging(m.GoNoGoState);
        }

        if (doneChange) {
            time = 0;
            doneChange = false;
        }
    }

private void OnTriggerEnter(Collider other) {
    Colliding = true;
    Door.transform.position = Vector3.Lerp(Door.transform.position, new Vector3(1.67f, 0, 0), time += Time.deltaTime/2);
}

 private void OnTriggerExit(Collider other) {
    Colliding = false;
}
    void ColourChanging(string GoNoGo)
    {
        if (GoNoGo == "NoGo" && 1 > time){
            Door.GetComponent<Renderer>().material.color = Color.Lerp(NoGoColor, originalColor, time += Time.deltaTime/2);
        }
        if (GoNoGo == "Go" && 1 > time){
            Door.GetComponent<Renderer>().material.color = Color.Lerp(GoColor, originalColor, time += Time.deltaTime/2);
        }
        if (time <= 0) {doneChange = true;}
    }
}
