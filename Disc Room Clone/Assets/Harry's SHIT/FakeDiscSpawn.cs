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
    public GameObject camVector;
    
    public float spawn;
    public float spawnTimer = 400f;
    public int maxDisc;
    public int counter;

    void Start()
    {
        spawn = spawnTimer;
        canSpawn = true;
    }


    void Update()
    {
        // below is used to determind what disc to spawn in different levels
        if (gM.inZero == true && gM.isAlive == true)
        {
            //print("Spawner intro");
            zeroSpawn();
        }

        if (gM.inOne == true && gM.isAlive == true)
        {
            print("Spawner 1");
            oneSpawn();
        }
        
        if (gM.inTwo == true && gM.isAlive == true)
        {
            print("Spawner 2");
            twoSpawn();
        }
        
        if (gM.inThree == true && gM.isAlive == true)
        {
            print("Spawner 3");
            threeSpawn();
        }
        
        if (gM.inFour == true && gM.isAlive == true)
        {
            print("Spawner 4");
            fourSpawn();
        }
        
        if (gM.inFive == true && gM.isAlive == true)
        {
            print("Spawner 5");
            fiveSpawn();
        }
        
        if (gM.inSix == true && gM.isAlive == true)
        {
            print("Spawner 6");
            sixSpawn();
        }
        
        if (gM.inBoss == true && gM.isAlive == true)
        {
            print("Spawner B");
            BossSpawn();
        }
        
    }

    #region discSpawnFunctions
    public void zeroSpawn()
    {
        //print("canspawn:" + canSpawn);
        if (canSpawn = true)
        {
            maxDisc = 1;
            //counter = 0;
            //print(counter);
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
                Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                counter += 1;
                print("spawning a disc");
                spawn = spawnTimer;
            }
        }
    }

    public void oneSpawn()
    {
        if (canSpawn = true)
        {
            maxDisc = 5;
            //counter = 0;
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
                Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
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
            //counter = 0;
        }

        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }
            if (spawn == 0)
            {
                Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
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
            //counter = 0;
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
                    Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 1)
                {
                    Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 2)
                {
                    Instantiate(discBig, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 3)
                {
                    Instantiate(discBig, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 4)
                {
                    Instantiate(discBig, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
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
            //counter = 0;
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
                    Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 1)
                {
                    Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 2)
                {
                    Instantiate(discTarget, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 3)
                {
                    Instantiate(discTarget, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 4)
                {
                    Instantiate(discTarget, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
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
            //counter = 0;
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
                    Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 1)
                {
                    Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 2)
                {
                    Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 3)
                {
                    Instantiate(discBig, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 4)
                {
                    Instantiate(discBig, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
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
            //counter = 0;
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
                    Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 1)
                {
                    Instantiate(discStandard, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 2)
                {
                    Instantiate(discTarget, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 3)
                {
                    Instantiate(discTarget, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }

                if (newDisc == 4)
                {
                    Instantiate(discBig, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }
                
                if (newDisc == 5)
                {
                    Instantiate(discTarget, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                    counter += 1;
                }
                
                spawn = spawnTimer;
            }
        }
        
        
    }
    
    public void BossSpawn()
    {
        if (canSpawn = true)
        {
            maxDisc = 1;
            //counter = 0;
        }

        if (counter < maxDisc)
        {
            if (spawn > 0)
            {
                spawn--;
            }
            if (spawn == 0)
            {
                Instantiate(discBoss, new Vector3(camVector.transform.position.x, camVector.transform.position.y, 0), Quaternion.identity);
                counter += 1;
                spawn = spawnTimer;
            }
        }
        
        
    }
    #endregion
    
}
