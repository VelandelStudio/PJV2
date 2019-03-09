using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivingEntities {
    
    int HP { get; }
    E_Type Type { get; }
    void SetHP(int HP);
    void Takedamage(int HP, E_Type type);
    void Die();
}
