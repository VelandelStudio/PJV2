using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour {

    public string type = "red";

    private int hp = 30;

    public void TakeDamage(int damage, RedBullet bullet)
    {
        if (bullet.type == type)
        {
            hp -= damage;
        }

        if (hp <= 0)
        {
            BeKilled();
        }
    }

    private void BeKilled()
    {
        Destroy(GetComponent<Collider>());
        Destroy(gameObject, 2f);
    }

}
