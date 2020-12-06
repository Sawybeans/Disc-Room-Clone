using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDiscSpawn : MonoBehaviour
{

    public GameObject discStandard;
    public GameObject discBig;
    public GameObject discWall;
    public GameObject discTarget;
    public GameObject discBoss;
    public GameManager gM;
    public bool canSpawn;
    
    
    public float spawn;
    public float spawnTimer = 400f;
    int maxDisc;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        spawn = spawnTimer;
        canSpawn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gM.inZero == true)
        {
            print("Spawner intro");
            zeroSpawn();
        }

        if (gM.inOne == true)
        {
            print("Spawner 1");
            oneSpawn();
        }
        
        if (gM.inTwo == true)
        {
            print("Spawner 2");
            twoSpawn();
        }
        
        if (gM.inThree == true)
        {
            print("Spawner 3");
            threeSpawn();
        }
        
        if (gM.inFour == true)
        {
            print("Spawner 4");
            fourSpawn();
        }
        
        if (gM.inFive == true)
        {
            print("Spawner 5");
            fiveSpawn();
        }
        
        if (gM.inSix == true)
        {
            print("Spawner 6");
            sixSpawn();
        }
        
        if (gM.inBoss == true)
        {
            print("Spawner B");
        }
        
    }

    public void zeroSpawn()
    {
        if (canSpawn = true)
        {
            maxDisc = 1;
            counter = 0;
            canSpawn = false;
        }
        
        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }
            if (spawn == 0)
            {
                Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                counter += 1;
                spawn = spawnTimer;
            }
        }
    }

    public void oneSpawn()
    {
        if (canSpawn = true)
        {
            maxDisc = 5;
            counter = 0;
        }

        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }
            if (spawn == 0)
            {
                Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                counter += 1;
                spawn = spawnTimer;
            }
        }
    }

    public void twoSpawn()
    {
        if (canSpawn = true)
        {
            maxDisc = 5;
            counter = 0;
            Instantiate(discWall, new Vector3(-13.5f, 20.5f, 0), Quaternion.identity);
            Instantiate(discWall, new Vector3(-20.5f, 13.5f, 0), Quaternion.identity);
        }

        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }
            if (spawn == 0)
            {
                Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                counter += 1;
                spawn = spawnTimer;
            }
        }
    }

    public void threeSpawn()
    {
        if (canSpawn = true)
        {
            maxDisc = 5;
            counter = 0;
        }

        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }
            if (spawn == 0)
            {
                int newDisc = Random.Range(0, 4);

                if (newDisc == 0)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 1)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 2)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 3)
                {
                    Instantiate(discBig, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 4)
                {
                    Instantiate(discBig, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }
                
                spawn = spawnTimer;
            }
        }
    }
    
    public void fourSpawn()
    {
        if (canSpawn = true)
        {
            maxDisc = 5;
            counter = 0;
        }

        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }
            if (spawn == 0)
            {
                int newDisc = Random.Range(0, 4);

                if (newDisc == 0)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 1)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 2)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 3)
                {
                    Instantiate(discTarget, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 4)
                {
                    Instantiate(discTarget, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }
                
                spawn = spawnTimer;
            }
        }
    }

    public void fiveSpawn()
    {
        if (canSpawn = true)
        {
            maxDisc = 5;
            counter = 0;
            Instantiate(discWall, new Vector3(20.5f, 37.5f, 0), Quaternion.identity);
            Instantiate(discWall, new Vector3(13.5f, 30.5f, 0), Quaternion.identity);
        }

        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }
            if (spawn == 0)
            {
                int newDisc = Random.Range(0, 4);

                if (newDisc == 0)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 1)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 2)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 3)
                {
                    Instantiate(discBig, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 4)
                {
                    Instantiate(discBig, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }
                
                spawn = spawnTimer;
            }
        }
    }

    public void sixSpawn()
    {
        if (canSpawn = true)
        {
            maxDisc = 6;
            counter = 0;
            Instantiate(discWall, new Vector3(-13.5f, 54.5f, 0), Quaternion.identity);
            Instantiate(discWall, new Vector3(-20.5f, 47.5f, 0), Quaternion.identity);
        }

        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }
            if (spawn == 0)
            {
                int newDisc = Random.Range(0, 5);

                if (newDisc == 0)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 1)
                {
                    Instantiate(discStandard, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 2)
                {
                    Instantiate(discTarget, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 3)
                {
                    Instantiate(discTarget, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 4)
                {
                    Instantiate(discBig, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }
                
                if (newDisc == 5)
                {
                    Instantiate(discTarget, new Vector3(0, 0, 0), Quaternion.identity);
                    counter += 1;
                }
                
                spawn = spawnTimer;
            }
        }
        
        
    }
}
