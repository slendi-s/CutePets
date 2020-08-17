using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalView : MonoBehaviour
{
    public CashSpriteAnimal cashSpriteAnimal;
    public SpriteRenderer spriteRenderer;

    public Image ballBar;
    public Image cutleryBar;
    public Image lightningBar;
    public Image graduationCapBar;
    public Image toiletBar;

    private void Start()
    {
      
    }

    private void Update()
    {
     if (ballBar.fillAmount >= 0.5 && ChangeSceneOnBall.onBall)
        {
            DoHappyEmotion();
        }
     else if (ballBar.fillAmount <= 0.5 && ChangeSceneOnBall.onBall)
        {
            DoSadEmotion();
        }

        if (StartGame.triggercurutin && ChangeSceneOnCutlery.onCutlery)
        {
            spriteRenderer.sprite = cashSpriteAnimal.eating;
            StartCoroutine(Corutine());
        }
        if (cutleryBar.fillAmount <= 0.5 && ChangeSceneOnCutlery.onCutlery && !StartGame.triggercurutin)
        {
            spriteRenderer.sprite = cashSpriteAnimal.hungry;
        }
        else if (cutleryBar.fillAmount >= 0.5 && ChangeSceneOnCutlery.onCutlery && !StartGame.triggercurutin)
        {
            DoHappyEmotion();
        }


        if (StartGame.isDream && ChangeSceneOnLightning.onLightning)
        {
            spriteRenderer.sprite = cashSpriteAnimal.sleeping;
        }
        else if (lightningBar.fillAmount <= 0.25 && ChangeSceneOnLightning.onLightning)
        {
            spriteRenderer.sprite = cashSpriteAnimal.wantSleep;
        }
        else if (lightningBar.fillAmount >= 0.25 && ChangeSceneOnLightning.onLightning)
        {
            DoHappyEmotion();
        }


        if (graduationCapBar.fillAmount <= 0.5 && ChangeSceneOnGraduationCap.onGC)
        {
            DoSadEmotion();
        }
        else if (graduationCapBar.fillAmount >= 0.5 && ChangeSceneOnGraduationCap.onGC)
        {
            DoHappyEmotion();
        }

       if (StartGame.triggercurutin && ChangeSceneOnToilet.onToilet && toiletBar.fillAmount-0.25 <= 0.76 && toiletBar.fillAmount-0.25 >= 0.51)
        {
            spriteRenderer.sprite = cashSpriteAnimal.useToilet;
            StartCoroutine(Peepee());
        }
        else if (StartGame.triggercurutin && ChangeSceneOnToilet.onToilet && toiletBar.fillAmount-0.25 <= 0.5)
        {
            
            spriteRenderer.sprite = cashSpriteAnimal.latherAnimal;
            StartCoroutine(ClearBody());
        }
        else if (toiletBar.fillAmount <= 0.5 && ChangeSceneOnToilet.onToilet)
        {
            spriteRenderer.sprite = cashSpriteAnimal.dirtyAnimal;
        }
        else if (toiletBar.fillAmount >= 0.76 && ChangeSceneOnToilet.onToilet)
        {
            DoHappyEmotion();
        }
        else if (toiletBar.fillAmount <= 0.76 && toiletBar.fillAmount >= 0.51 && ChangeSceneOnToilet.onToilet )
        {
            spriteRenderer.sprite = cashSpriteAnimal.wantToilet;
        }
    }
    public IEnumerator Peepee()
    {
        spriteRenderer.sprite = cashSpriteAnimal.useToilet;
        yield return new WaitForSeconds(1f);
        StartGame.triggercurutin = false;
    }
    public IEnumerator ClearBody()
    {
        spriteRenderer.sprite = cashSpriteAnimal.latherAnimal;
        yield return new WaitForSeconds(1f);
        StartGame.triggercurutin = false;
        
       
    }
    public IEnumerator Corutine()
    {
        //spriteRenderer.sprite = cashSpriteAnimal.eating;
        yield return new WaitForSeconds(0.5f);
        StartGame.triggercurutin = false;
        
    }
    public void DoHappyEmotion()
    {
        spriteRenderer.sprite = cashSpriteAnimal.happyEmotion;
    }
    public void DoSadEmotion()
    {
        spriteRenderer.sprite = cashSpriteAnimal.sadEmotion;
    }
}
