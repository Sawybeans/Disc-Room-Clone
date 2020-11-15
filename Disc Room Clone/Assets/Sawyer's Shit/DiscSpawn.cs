using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSpawn : MonoBehaviour
{

    public GameObject discStandard;
    public GameObject discBig;
    public GameObject discWall;
    public GameObject discTarget;

    public float spawn;
    public float spawnTimer = 800f;
    public int maxDisc;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        spawn = spawnTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }

            if (spawn == 0)
            {
                int newDisc = Random.Range(0, 5);

                if (newDisc <= 2)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc >= 3)
                {
                    Instantiate(discBig, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                spawn = spawnTimer;
            }
        }
    }
}
