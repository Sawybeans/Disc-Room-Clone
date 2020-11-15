using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public Vector3 SpawnVector3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(playerPrefab,SpawnVector3,Quaternion.Euler(0, 0, 0));
        }
    }
}
