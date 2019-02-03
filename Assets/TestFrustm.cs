using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFrustm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + 0.25f * transform.forward;
    }
}
