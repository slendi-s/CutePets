using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FallingObject))]
public class Collider : MonoBehaviour
{
    private FallingObject fo;
    public Animator textureObject;
    private string[] triggerTexture = new string[9];
    private int randomCount;

    private void Awake()
    {
        InitializedTexture();
        Texture(Random.RandomRange(1, triggerTexture.Length + 1));
    }
    private void Start()
    {
        //  var SpawnObject = GetComponent<FallingObject>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Zone"))
        {
            SendMessage("SpawnObject");
            Destroy(this.gameObject);
           // FallingObject.SpawnObject();
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Korzina"))
        {
            FallingObject.score += 1;
           
            Destroy(this.gameObject);
        }
       
    }

    public void SpawnObject()
    {
        // Instantiate(fallingObject, new Vector3(xSpawn, ySpawn, zSpawn), Quaternion.identity).transform.SetParent(canvas.transform);
    }



    public void Texture(int texture)
    {

        // randomCount = Random.RandomRange(1, triggerTexture.Length+1);
        // textureObject.SetTrigger("Bannana");
         textureObject.SetTrigger(triggerTexture[texture]);
        //  Textur.SetTrigger();
    }
    public void InitializedTexture()
    {
        triggerTexture[1] = "Apple";
        triggerTexture[2] = "Bannana";
        triggerTexture[3] = "Cabbage";
        triggerTexture[4] = "Carrot";
        triggerTexture[5] = "Eggplant";
        triggerTexture[6] = "Orange";
        triggerTexture[7] = "Radish";
        triggerTexture[8] = "Strawberry";
    }

}
