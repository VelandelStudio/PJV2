using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKamikaze : MonoBehaviour
{
    private Transform player;
    private Transform bullet;
    private BlueEnemy enemy;
    private Explosion explosion;

    private float timeCount = 15f;

    public bool launched = false; 
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<BlueEnemy>();
        explosion = GetComponent<Explosion>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //search for bullet ? 
        if(attack.launched){
            timeCount -= Time.deltaTime;

            float distanceWithPlayer = Vector3.distance(transform.position, player.position);
            float distanceWithBullet = Vector3.distance(transform.position, bullet.position);

            if(distanceWithPlayer == 0 || timeCount <= 0)
            {
                Exploding();
            }

            if(distanceWithBullet == 0)
            {
                int bulletObject = bullet.GetComponentInParent<Bullet>();
                health -= bulletObject.damage;
                
                if(health<=0)
                {
                    Exploding();
                }
            }
    }

    void Exploding()
    {
        explosion.explode = true;
        enemy.health = 0;
        launched = false; 
    }
}
