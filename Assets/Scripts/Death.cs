using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField]
    GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
