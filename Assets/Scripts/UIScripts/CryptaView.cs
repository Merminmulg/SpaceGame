using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryptaView : MonoBehaviour
{
    [SerializeField] public Text cryptaText;
    [SerializeField] public GameObject player;
    // Start is called before the first frame update

    private int playerCripta;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCripta = player.GetComponent<SpaceShip>().Cripta;
        cryptaText.text = "Crypta: "+playerCripta.ToString();
    }
}
