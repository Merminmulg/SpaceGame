using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceShip : Entity
{
    [SerializeField] public int Cripta;
    [SerializeField] public int Energy;
    [SerializeField] public int Resources;
    [SerializeField] public int MaxEnergy;
    [SerializeField] public int MaxHP;
    [SerializeField] public CommandCenter commandCenter;
    [SerializeField] public Text endF;
    private Vector2 direction;
    [SerializeField]
    public int minePerMin;
    [SerializeField]
    GameObject deathPanel;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nowTimeBtwShoots = 0;
        endF.text = "";
    }

    // Update is called once per frame
    public void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Move();
        Shoot();
        Debug.Log((Vector2)Input.mousePosition);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EndFrame")
        {
            endF.text = "„тобы улететь нужен двигатель дл€ гиперскачков";
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "EndFrame")
        {
            endF.text = "";
        }
    }
    private void Move()
    {
        //if (Energy>0 && Input.GetMouseButton(0) && nowTimeBtwShoots <= 0) {
        //    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    pos.x = (float)(Mathf.Floor(pos.x)+0.5);
        //    pos.y = (float)(Mathf.Floor(pos.y)+0.5);
        //    if (transform.position != pos)
        //    {
        //        Energy -= (int)Mathf.Floor(((Vector2)(pos - transform.position)).magnitude);
        //    }
        //    Vector2 mouseDiference = (Vector2)(pos - transform.position);
        //    float rotateZ = Mathf.Atan2(mouseDiference.x, mouseDiference.y) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.Euler(0f, 0f, -rotateZ);
        //    transform.position = pos;
        //    nowTimeBtwShoots = timeBtwShoots;
        //}
        //else
        //{
        //    nowTimeBtwShoots -= Time.deltaTime;
    //}
    //Debug.Log("SPACESHIP - " +(rb.position + direction* speed * Time.deltaTime).ToString());
    Vector2 mouseDiference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    float rotateZ = Mathf.Atan2(mouseDiference.x, mouseDiference.y) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, 0f, -rotateZ);
        rb.MovePosition(rb.position+direction*speed*Time.deltaTime);
    }
    private void Shoot()
    {
        if (nowTimeBtwShoots <= 0) {
            if (Input.GetKey(KeyCode.Space))
            {
                Energy -= 5;
                Instantiate(blast, shotPoint.position, transform.rotation);
                nowTimeBtwShoots = timeBtwShoots;
            }
        }
        else
        {
            nowTimeBtwShoots -= Time.deltaTime;
        }
    }
    public void TakeDamage(int gDamage)
    {
        HP -= gDamage;
        if (HP==0)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Mining()
    {
        Resources += minePerMin;
        Energy -= 5;
    }
}
