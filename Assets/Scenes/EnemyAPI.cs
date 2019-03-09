using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivingEntities {
   void SetHP(int HP);
   void Takedamage(int HP);
   void Die();

}
