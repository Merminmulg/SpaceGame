using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    [SerializeField] private float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        if (this.playerTransform == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }

            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }

        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z - 10,
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z - 10,
            };
            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.movespeed * Time.deltaTime);

            this.transform.position = pos;
        }
    }
}
