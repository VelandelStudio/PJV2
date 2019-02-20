using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;


public class BlueEnemyPattern : MonoBehaviour
{
    public static BezierSpline create(Vector3 initPos)
    {
        BezierSpline pattern = new GameObject().AddComponent<BezierSpline>();
        pattern.loop = true;

        pattern.Initialize( 2 );
        pattern[0].position = initPos;
        pattern[0].precedingControlPointLocalPosition = new Vector3( 0, 0, 17 );
        pattern[0].precedingControlPointLocalPosition = new Vector3( 0, 0, -17 );

        pattern[1].localPosition = new Vector3(30,0,30);
        pattern[1].precedingControlPointLocalPosition = new Vector3( 0, 0, 17 );
        pattern[1].precedingControlPointLocalPosition = new Vector3( 0, 0, -17 );

        return pattern;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
