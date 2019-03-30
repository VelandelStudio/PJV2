using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TestAlpha
{
    A = 1,
    B = 2,
    C = 4,
    E = 5,
    D = 3
}

public class TestEnum : MonoBehaviour
{
    [SerializeField] private TestAlpha alpha;
}
