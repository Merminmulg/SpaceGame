using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesView : MonoBehaviour
{
    [SerializeField] public Text resourcesText;
    [SerializeField] public GameObject player;
    // Start is called before the first frame update

    private int playerResources;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerResources = player.GetComponent<SpaceShip>().Resources;
        resourcesText.text = "Resources: " + playerResources.ToString() + " Øò.";
    }
}
