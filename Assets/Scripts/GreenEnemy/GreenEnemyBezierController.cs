using System.Diagnostics;
using UnityEngine;
using BezierSolution;

/// <summary>
/// Controller that handles the Bezier Spline of the green enemy.
/// </summary>
public class GreenEnemyBezierController : MonoBehaviour
{
    [SerializeField] private GameObject bezierSplineModel;
    [SerializeField] private bool fakeLaunch;

    /// <summary>
    /// Creates a new spline with the Target.
    /// When the spline is created, we detach it from the greenEnemy.
    /// </summary>
    /// <param name="target"></param>
    public BezierSpline CreateCustomBezierSpline(Vector3 target)
    {
        GameObject inst = Instantiate(bezierSplineModel, transform.position, Quaternion.identity, transform);
        Transform START_POINT = inst.transform.GetChild(0);
        Transform APEX_POINT = inst.transform.GetChild(1);
        Transform END_POINT = inst.transform.GetChild(2);

        END_POINT.position = target;
        APEX_POINT.position = CalculateApexPosition(START_POINT.position, END_POINT.position, APEX_POINT.position.y);
        inst.GetComponent<BezierSpline>().AutoConstructSpline();
        inst.transform.SetParent(null);
        Destroy(inst, 10f);
        return inst.GetComponent<BezierSpline>();
    }

#if DEVELOPMENT_BUILD || UNITY_EDITOR
    [SerializeField] private Vector3 fakeTarget;
    public void DEV_FakeCalculation()
    {
        CreateCustomBezierSpline(fakeTarget);
    }
#endif

    void Update()
    {
        if(fakeLaunch)
        {
            DEV_FakeCalculation();
            fakeLaunch = false;
        }
    }

    private Vector3 CalculateApexPosition(Vector3 startPos, Vector3 endPos, float YApex)
    {
        return new Vector3((startPos.x + endPos.x) / 2.0f, YApex, (startPos.z + endPos.z) / 2.0f);
    }
}