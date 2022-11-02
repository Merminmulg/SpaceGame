using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPView : MonoBehaviour
{
    [SerializeField] public Text hpText;
    [SerializeField] public GameObject player;
    // Start is called before the first frame update

    private int playerHP;
    private int playerMaxHP;
    // Start is called before the first frame update
    void Start()
    {
        playerMaxHP = player.GetComponent<SpaceShip>().MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        playerHP = player.GetComponent<SpaceShip>().HP;
        hpText.text = "HP: " + playerHP.ToString() + "/" + playerMaxHP;
    }
}
