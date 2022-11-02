using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float lifetime;
    [SerializeField] protected float distance;
    [SerializeField] protected float distanceFly;
    [SerializeField] protected GameObject shooter;
    protected int damage;
    protected float tempDistance;

    [SerializeField] protected LayerMask whatIsSolid;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        shooter = GameObject.Find("SpaceShip");
        damage = shooter.GetComponent<SpaceShip>().damage;
        tempDistance = 0;
    }

    // Update is called once per frame
    protected void Update()
    {
        HitDetector();
        Move();
    }
    protected void Move()
    {
        tempDistance += speed * Time.deltaTime;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (tempDistance > distanceFly)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void HitDetector()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
