using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacks
{
    int Puissance { get; }
    void SetPower(int puissance, int forceIndividu);
    void DealDamage();
}