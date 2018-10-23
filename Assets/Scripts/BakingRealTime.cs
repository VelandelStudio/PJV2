using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BakingRealTime : MonoBehaviour {

    public NavMeshSurface[] surfaces;
	
	void Update ()
    {
	    for(int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }	
	}
}
