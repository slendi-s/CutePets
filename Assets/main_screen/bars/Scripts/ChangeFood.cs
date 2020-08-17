using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeFood : MonoBehaviour
{
    public Sprite[] texture = new Sprite[8];
    public SpriteRenderer food;
    public Image iconfood;

    private void Update()
    {
        
        if (StartGame.changeFood)
        {
            iconfood.fillAmount += 0.25f;
          StartGame.changeFood = false;
          ChangeFoodTexture();
          if (iconfood.fillAmount <= 0.75f)
          {
                XPProcess.giveexpforgame = true;
          }
        }
       
  //      ChangeFoodTexture();
    }

    public void ChangeFoodTexture()
    {
        var count = Random.Range(0,8);
        food.sprite = texture[count];
    }

}
