using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    [SerializeField] [Range(0f, 200f)] float RotateSpeed = 130f;
    [SerializeField] [Range(0f, 2f)] float MoveUpSpeed;
    private bool movedUp = false;
    private Vector3 targetPos;
    public GameObject Manager;
    private Manager m;
    // Start is called before the first frame update
    void Start()
    {
        m = Manager.GetComponent<Manager>();
        targetPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        MoveUpSpeed = MoveUpSpeed/1000;
    }
private void OnTriggerEnter(Collider other) {
        if (!movedUp && !m.isDark) {
            m.circleTouched = true;
            StartCoroutine(MoveCircle());
            RotateSpeed += 600f;
            }
}

private void OnTriggerExit(Collider other) {
    RotateSpeed -= 600f;
}
    // Update is called once per frame
    void Update()
    {
        if (m.isDark && movedUp) {
            m.circleTouched = false;
            movedUp = false;
            }
        transform.RotateAround(transform.position, Vector3.up, RotateSpeed*Time.deltaTime);
    }
    IEnumerator MoveCircle(){
        for (float f = 0; f < 1; f += MoveUpSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, f);
            yield return new WaitForSeconds(MoveUpSpeed);
        }
    }
}
