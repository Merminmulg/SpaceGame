using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    [SerializeField]
    GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
}
