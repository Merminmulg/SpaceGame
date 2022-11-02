using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] public int objectLimit;
    private Vector2 spawnCoords;
    private float randX;
    private float randY;
    public int counter;
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ObjDrop();
    }
    void ObjDrop()
    {
            if (counter == 0)
            {
                while (counter < objectLimit)
                {
                    randX = (float)(Mathf.Round(Random.Range(-19, 19))+0.5);
                    randY = (float)(Mathf.Round(Random.Range(-19, 19)) + 0.5);
                    spawnCoords = new Vector2(randX, randY);
                    if (Physics2D.OverlapCircleAll(spawnCoords, 1f).Length < 2)
                    {
                        GameObject aster = Instantiate(obj, spawnCoords, Quaternion.identity);
                        spawnCoords = new Vector2(randX, (float)(randY + 0.8));
                        //Instantiate(DistanceText, spawnCoords, Quaternion.identity);
                    }
                    counter++;
                }
            }
        Destroy(gameObject);
            //yield return new WaitForSeconds(0.1f);
    }
}
