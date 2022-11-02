using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Store : MonoBehaviour
{
    [SerializeField]
    private GameObject store;
    [SerializeField]
    private Text gunButton;
    [SerializeField]
    private Text shieldButton;
    [SerializeField]
    private Text minerButton;
    [SerializeField]
    private SpaceShip player;
    [SerializeField]
    private int enginePrice;
    [SerializeField]
    private int engineResources;
    [SerializeField]
    GameObject winP;
    [SerializeField]
    Text winPT;
    private int gunPrice;
    private int shieldPrice;
    private int minerPrice;
    private int gunLvl;
    private int shieldLvl;
    private int minerLvl;
    private DateTime time;
    // Start is called before the first frame update
    void Start()
    {
        store.SetActive(false);
        gunPrice = 100;
        shieldPrice = 100;
        minerPrice = 100;
        gunButton.text = "Gun lvl 1 -" + gunPrice + " C";
        shieldButton.text = "Shield lvl 1 -" + shieldPrice + " C";
        minerButton.text = "Miner lvl 1 -" + minerPrice + " C";
        time = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameObject.Find("SpaceShipEnemy(Clone)") == null)
        {
            store.SetActive(true);
            Time.timeScale = 0;
            player.HP = player.MaxHP;
            player.Energy = 500;
        }
    }
    public void Exit()
    {
        store.SetActive(false);
        Time.timeScale = 1;
    }
    public void GunUp()
    {
        if (player.Cripta >= gunPrice)
        {
            player.damage *= 2;
            gunPrice *= 10;
            gunLvl++;
            switch (gunLvl)
            {
                case 1:
                    gunButton.text = "Gun lvl 2 -" + gunPrice + " C";
                    break;
                case 2:
                    gunButton.text = "Gun lvl 3 -" + gunPrice + " C";
                    break;
                case 3:
                    gunButton.text = "Max";
                    gunPrice *= 1000;
                    break;
            }
        }
    }
    public void ShieldUp()
    {
        if (player.Cripta >= shieldPrice)
        {
            player.Cripta -= shieldPrice;
            player.MaxHP += 25;
            shieldPrice *= 10;
            shieldLvl++;
            switch (shieldLvl)
            {
                case 1:
                    shieldButton.text = "Shield lvl 2 -" + shieldPrice + " C";
                    break;
                case 2:
                    shieldButton.text = "Shield lvl 3 -" + shieldPrice + " C";
                    break;
                case 3:
                    shieldPrice *= 1000;
                    shieldButton.text = "Max";
                    break;
            }
        }
    }
    public void MiningUp()
    {
        if (player.Cripta >= minerPrice)
        {
            player.Cripta -= minerPrice;
            player.minePerMin *= 2;
            minerPrice *= 10;
            minerLvl++;
            switch (minerLvl)
            {
                case 1:
                    minerButton.text = "Miner lvl 2 -" + minerPrice + " C";
                    break;
                case 2:
                    minerButton.text = "Miner lvl 3 -" + minerPrice + " C";
                    break;
                case 3:
                    minerButton.text = "Miner lvl 4 -" + minerPrice + " C"; ;
                    break;
                case 4:
                    minerButton.text = "Max";
                    minerPrice *= 1000;
                    break;
            }
        }
    }

    public void EngineBuy()
    {
        if (player.Cripta >= enginePrice && player.Resources >= engineResources)
        {
            winP.SetActive(true);
            winPT.text = "Вы потратили на это: "+ (-(time - DateTime.Now).Minutes) +" дней";
            Time.timeScale = 0;
        }
    }
}
