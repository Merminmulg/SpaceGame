using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] public GameObject objectSpawnerEnemy;
    [SerializeField] public GameObject objectSpawnerAsteroid;
    private int killedEnemy;
    private int enemyprogress;
    // Start is called before the first frame update
    void Start()
    {
    enemyprogress = 1;
    killedEnemy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        float rand = Random.Range(0, 10);
        if (rand>8 && killedEnemy == 0) {
            GameObject g = Instantiate(objectSpawnerEnemy, transform.position, Quaternion.identity);
            g.GetComponent<RandomSpawn>().objectLimit *= enemyprogress;
            if (enemyprogress < 4) {
                enemyprogress++;
            }
        }
    }
    public void SpawnAsteroid()
    {
        killedEnemy++;
        if (killedEnemy >= 2*(enemyprogress-1))
        {
            Instantiate(objectSpawnerAsteroid, transform.position, Quaternion.identity);
            killedEnemy = 0;
        }
    }
}
