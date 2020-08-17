using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseAll : MonoBehaviour
{
    
    [SerializeField] public GameObject bgBall;
    [SerializeField] public GameObject bgCutlery;
    [SerializeField] public GameObject bgLightning;
    [SerializeField] public GameObject bgGroduct;
    [SerializeField] public GameObject bgToilet;
    [SerializeField] public GameObject play;
    public GameObject food;
    public GameObject dreamblack;


    private void OnMouseUp()
    {
        AllCloseObjects();
    }

    public void AllCloseObjects()
    {
        dreamblack.SetActive(false);
        ChangeSceneOnToilet.onToilet = false;
        ChangeSceneOnLightning.onLightning = false;
        ChangeSceneOnCutlery.onCutlery = false;
        food.SetActive(false);
        ChangeSceneOnGraduationCap.onGC = false;
        ChangeSceneOnBall.onBall = false;
        bgBall.SetActive(false);
        bgCutlery.SetActive(false);
        bgGroduct.SetActive(false);
        bgLightning.SetActive(false);
        bgToilet.SetActive(false);
        //  play.SetActive(false);
        
    }
}
