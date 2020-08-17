using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{

    [SerializeField] public AudioSource hru;
    public static bool changeFood = false;
    public GameObject dreamback;
    public static bool triggercurutin = false;
    public Image toiletBar;
    public static bool isDream = false;
    public Image lightningBar;
    public static bool triggerSave = false;
    private void OnMouseUp()
    {
        changeFood = true;

        hru.Play();

        if (ChangeSceneOnCutlery.onCutlery)
        {
            triggercurutin = true;
        }
        if (ChangeSceneOnToilet.onToilet)
        {
            triggercurutin = true;
            toiletBar.fillAmount += 0.25f;
        }


        if (ChangeSceneOnBall.onBall)
        {
            triggerSave = true;
            SceneManager.LoadScene(2);
        }
        if (ChangeSceneOnGraduationCap.onGC)
        {
            PlayerPrefs.SetString("SaveName",ChangeName.saveName);
            triggerSave = true;
            SceneManager.LoadScene(1);
        }
        if (ChangeSceneOnLightning.onLightning && !isDream)
        {
            dreamback.SetActive(true);
            isDream = true;
        }
        else if (ChangeSceneOnLightning.onLightning && isDream)
        {
            dreamback.SetActive(false);
            isDream = false;
        }
        
    }
    private void Update()
    {
        if (ChangeSceneOnLightning.onLightning && isDream)
        {
            dreamback.SetActive(true);
            lightningBar.fillAmount += 0.001f;
        }
    }
}
