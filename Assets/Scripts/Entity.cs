using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] protected float speed;
    [SerializeField] public int HP;
    protected Rigidbody2D rb;
    [SerializeField] protected float timeBtwShoots;
    protected float nowTimeBtwShoots;
    [SerializeField] protected GameObject blast;
    [SerializeField] protected Transform shotPoint;
}
