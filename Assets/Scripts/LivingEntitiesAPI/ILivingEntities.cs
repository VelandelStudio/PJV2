using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivingEntities {
    
    int HP { get; }
    void SetHP(int HP);
    void Takedamage(int HP);
    void Die();
}
