using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// BakingRealTime Class
/// Class Downloaded to set up easily the NavMesh.
/// Just put this script on the gameObject you want to be NavMeshed.
/// </summary>
public class BakingRealTime : MonoBehaviour {

    public NavMeshSurface[] surfaces;
	
	void Start ()
    {
	    for(int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }	
	}
}
