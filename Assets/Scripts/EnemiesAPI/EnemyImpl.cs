using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class EnemyImpl : MonoBehaviour, IEnemies
{
    public int DetectionField
    {
        get;
        protected set;
    }
    public int ScoreValue
    {
        get;
        protected set;
    }
    public int ForceIndividu
    {
        get;
        protected set;
    }

    public abstract void AttributeValues();

    private void Awake()
    {
        AttributeValues();
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
        if(col is SphereCollider)
        {
            SphereCollider sphereCollider = (SphereCollider)col;
            sphereCollider.radius = DetectionField;
            return;
        }

        if (col is BoxCollider)
        {
            BoxCollider BoxCollider = (BoxCollider)col;
            BoxCollider.size = new Vector3(DetectionField, DetectionField, DetectionField);
            return;
        }

        Debug.LogError("Le GameObject "+gameObject.name+" ne possède pas un collider géré par le jeu. Corrigez svp.");
        Application.Quit(-1);
    }

    /*
Attack[] Attacks {get;}
Movement[] Movements {get;}
*/
}
 