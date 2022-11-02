using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    [SerializeField] public SpaceShip player;
    [SerializeField] public GameObject spawner;
    [SerializeField] public Text Name;
    [SerializeField] public Text MineIndicator;
    [SerializeField] private int resourcesAwailable;
    public string namePlanet;
    protected float nowTimeBtwMine;
    private static readonly string[] Names = {  "Фобос", "Деймос ", "Метида", "Адрастея", "Амальтея",
                                                "Теба", "Ио", "Европа", "Ганимед", "Каллисто", "Калипсо",
                                                "Диона", "Елена", "Гиперион","Розалинда", "Дездемона",
                                                "Умбриэль", "Таласса", "Рея", "Япет", "Феба"};
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("SpaceShip").GetComponent<SpaceShip>();
        //resourcesAwailable = Random.Range(0, 1000);
        namePlanet = Names[Random.Range(0, Names.Length-1)];
        Name.text = namePlanet;
        MineIndicator.text = "";
    }
    //private void Awake()
    //{
    //    player = GameObject.Find("Player").GetComponent<SpaceShip>();
    //    resourcesAwailable = Random.Range(0, 1000);
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MineIndicator.text = "Mining in progress...";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        MineIndicator.text = "";
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (nowTimeBtwMine <= 0)
        {
            if (collision.tag == "Player")
            {
                player.Mining();
                nowTimeBtwMine = 1;
                spawner.GetComponent<SpawnController>().SpawnEnemy();
            }
        }
        else
        {
            nowTimeBtwMine -= Time.deltaTime;
        }
    }
}
