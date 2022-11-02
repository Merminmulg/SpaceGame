using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private GameObject spawner;
    [SerializeField] public SpaceShip player;
    private Vector2 movement;
    private float neededDistanse;
    [SerializeField] protected Transform shotPoint2;
    [SerializeField] protected Transform shotPoint3;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        spawner = GameObject.Find("SpawnController");
        player = GameObject.Find("SpaceShip").GetComponent<SpaceShip>();
    }

    // Update is called once per frame
    void Update()
    {
        DeathDetector();
        EnemyAI();
    }
    void DeathDetector()
    {
        if (HP<=0)
        {
            spawner.GetComponent<SpawnController>().SpawnAsteroid();
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int gDamage)
    {
        HP -= gDamage;
    }

    public void EnemyAI()
    {
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle-90;
        neededDistanse = direction.magnitude;
        Debug.Log(direction + " " + neededDistanse);
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        if (neededDistanse > 10)
        {
            Move(movement);
        }
        else
        {
            Shoot();
        }
    }
    private void Move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    private void Shoot()
    {
        if (nowTimeBtwShoots <= 0)
        {
                Instantiate(blast, shotPoint2.position, shotPoint2.rotation);
                Instantiate(blast, shotPoint3.position, shotPoint3.rotation);
                Instantiate(blast, shotPoint.position, transform.rotation);
            nowTimeBtwShoots = timeBtwShoots;
        }
        else
        {
            nowTimeBtwShoots -= Time.deltaTime;
        }
    }
}
