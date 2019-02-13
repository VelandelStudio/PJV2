using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueEnemyPattern : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform EnemyPos;
    private Vector3 coordA;
    private Vector3 coordB;
    public float period = 2*Mathf.PI;
    private float distance = 0f;
    private bool forward = true;

    void Start()
    {
        EnemyPos = GetComponent<Transform>();
        coordA = EnemyPos.position;
        //movement will depend only on the X axis
        coordB = new Vector3(coordA.x+period, coordA.y, coordA.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 actualPos = transform.position;
        distance += Time.deltaTime;
        if(distance>=period)
        {
            if(forward)
            {
                forward = false;
            }
            else
            {
                forward = true;
            }
            distance = 0f;
        }
        if(forward)
        {
            transform.position = new Vector3(actualPos.x + 2*Time.deltaTime, actualPos.y, 2*Mathf.Sin(actualPos.x + 2*Time.deltaTime));
        }
        else
        {
             transform.position = new Vector3(actualPos.x - 2*Time.deltaTime, actualPos.y, -2*Mathf.Sin(actualPos.x - 2*Time.deltaTime));
        }
    }
}
