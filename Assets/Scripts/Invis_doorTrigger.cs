using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invis_doorTrigger : MonoBehaviour
{
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //conditions need to be set
        Debug.Log("invis wall has been entered");
        manager.marker.Write("invis wall has been entered");

    }
}
