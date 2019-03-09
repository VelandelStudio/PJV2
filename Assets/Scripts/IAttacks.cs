using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacks
{
    int puissance { get; }
    void setPower(int puissance, int forceIndividu);
    void dealDamage();
}