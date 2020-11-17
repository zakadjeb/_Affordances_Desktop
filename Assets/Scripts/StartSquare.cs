using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSquare : MonoBehaviour
{
    public bool insideSquare = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
private void OnTriggerEnter(Collider other) {
    insideSquare = true;
}
private void OnTriggerExit(Collider other) {
    insideSquare = false;
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
