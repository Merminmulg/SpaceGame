using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Asteroid : MonoBehaviour
{
    [SerializeField] public SpaceShip player;
    [SerializeField] private int resourcesAwailable;
    [SerializeField] private GameObject SpawnController;
    private string nameAsteroid;
    [SerializeField] private GameObject textLine;
    private static readonly string[] Names = {"abcdefghigklmnopqrstuvwxyz1234567890"};
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("SpaceShip").GetComponent<SpaceShip>();
        resourcesAwailable = Random.Range(30, 200);
        SpawnController = GameObject.Find("SpawnController");
        CreateName();
    }
    void CreateName()
    {
        for (int i = 0; i<6; i++) {
            nameAsteroid += Names[Random.Range(0, Names.Length)];
        }
        textLine.GetComponent<Text>().text = nameAsteroid;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.Cripta += resourcesAwailable;
            SpawnController.GetComponent<SpawnController>().objectSpawnerAsteroid.GetComponent<RandomSpawn>().counter--;
            Destroy(gameObject);
        }
    }
}
