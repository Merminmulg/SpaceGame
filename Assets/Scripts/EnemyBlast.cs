using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlast : Blast
{
    protected override void HitDetector()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<SpaceShip>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    protected override void Start()
    {
        damage = shooter.GetComponent<Enemy>().damage;
        tempDistance = 0;
    }
}
