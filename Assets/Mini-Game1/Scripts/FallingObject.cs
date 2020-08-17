using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingObject : MonoBehaviour
{
     public  GameObject fallingObject;
     public Collider2D zoneDespawn;
     public GameObject spawnPoint;
     public  Transform canvas;
     public  float xSpawn, ySpawn, zSpawn;
     public int index;
     public  GameObject deleteObj;
     private float timer=2;    
     public static float score;
    public GameObject secondSpawnPoint;



    
    private void Start()
    {
        
   
        CoordinatesSpawn();
        SpawnObject();
    }

    private void Update()
    {
       
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            SpawnObject();
            timer = 2;
        }
        
    }

    public void CoordinatesSpawn()
    {
         xSpawn = Random.Range(spawnPoint.transform.position.x,secondSpawnPoint.transform.position.x);
         ySpawn = spawnPoint.transform.position.y;
         zSpawn = spawnPoint.transform.position.z;
    }
    public  void SpawnObject()
    {
        
        CoordinatesSpawn();
        deleteObj = Instantiate(fallingObject, new Vector3(xSpawn, ySpawn, zSpawn), Quaternion.identity);
        deleteObj.transform.SetParent(canvas.transform);
      
        deleteObj.SetActive(true);
     //  Texture(Random.RandomRange(1, triggerTexture.Length + 1));
       // Instantiate(fallingObject, new Vector3(xSpawn, ySpawn, zSpawn), Quaternion.identity).transform.SetParent(canvas.transform);
    }

   
}
