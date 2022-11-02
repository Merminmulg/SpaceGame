using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyView : MonoBehaviour
{
    [SerializeField] public Text energyText;
    [SerializeField] public GameObject player;
    // Start is called before the first frame update

    private int playerEnergy;
    private int playerMaxEnergy;
    void Start()
    {
        playerMaxEnergy = player.GetComponent<SpaceShip>().MaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        playerEnergy = player.GetComponent<SpaceShip>().Energy;
        energyText.text = "Energy: " + playerEnergy.ToString() + "/" + playerMaxEnergy + " ÃÂò";
    }
}
