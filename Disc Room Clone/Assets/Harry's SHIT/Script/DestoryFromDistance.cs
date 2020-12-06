using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DestoryFromDistance : MonoBehaviour
{

    public float distanceToPlayer;
    private GameManager GameManagerScript;
    void Start()
    {
        GameManagerScript = GameObject.FindObjectOfType<GameManager>();

    }
    
    void Update()
    {
        distanceToPlayer = math.sqrt(math.pow((GameObject.Find("PlayerPrefab(Clone)").transform.position.x - this.transform.position.x),2) + 
                                     math.pow((GameObject.Find("PlayerPrefab(Clone)").transform.position.y - this.transform.position.y),2));

        if (Input.GetKeyDown(KeyCode.R) && GameManagerScript.isAlive == false)
        {
            Destroy(this.gameObject);
        }
    }
}
