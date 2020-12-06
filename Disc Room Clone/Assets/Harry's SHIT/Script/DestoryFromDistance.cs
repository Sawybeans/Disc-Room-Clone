using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DestoryFromDistance : MonoBehaviour
{
    // Start is called before the first frame update
    public float distanceToPlayer;
    void Start()
    {
        //distanceToPlayer = math.sqrt(math.pow((GameObject.Find("PlayerPrefab(Clone)").transform.position.x - this.transform.position.x),2) + 
                                        //math.pow((GameObject.Find("PlayerPrefab(Clone)").transform.position.y - this.transform.position.y),2));
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = math.sqrt(math.pow((GameObject.Find("PlayerPrefab(Clone)").transform.position.x - this.transform.position.x),2) + 
                                     math.pow((GameObject.Find("PlayerPrefab(Clone)").transform.position.y - this.transform.position.y),2));
        //print("d2p: " + distanceToPlayer);

        if (distanceToPlayer >= 9.3f)
        {
            Destroy(this.gameObject);
        }
    }
}
