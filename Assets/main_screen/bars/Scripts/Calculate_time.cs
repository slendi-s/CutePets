using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Calculate_time : MonoBehaviour
{
    public TimeSpan SubtractionTime;
    public SubtractionBarOnline sbo;



    public void Awake()
    {
        CheckOffline();
    }
   
    public void CheckOffline()
    {

        if (PlayerPrefs.HasKey("BarBall"))
        {
            sbo.FillIconBall.fillAmount = PlayerPrefs.GetFloat("BarBall");
        }
        
        if (PlayerPrefs.HasKey("BarCutlery"))
        {
            sbo.FillIconCutlery.fillAmount = PlayerPrefs.GetFloat("BarCutlery");
        }
        if (PlayerPrefs.HasKey("BarLightning"))
        {
            sbo.FillIconLightning.fillAmount = PlayerPrefs.GetFloat("BarLightning");
        }
        if (PlayerPrefs.HasKey("BarGraduationCap"))
        {
            sbo.FillIconGraduationCap.fillAmount = PlayerPrefs.GetFloat("BarGraduationCap");
        }
        if (PlayerPrefs.HasKey("BarToilet"))
        {
            sbo.FillIconToilet.fillAmount = PlayerPrefs.GetFloat("BarToilet");
        }
        if (PlayerPrefs.HasKey("LastSession"))
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            print(string.Format("Вы отсутстовали: {0} дней, {1} часов, {2} минут, {3} секунд", ts.Days, ts.Hours, ts.Minutes, ts.Seconds));
            SubtractionTime = ts;
        //    Debug.Log((int)ts.TotalSeconds);
        }
        

        
    }

    public void OnApplicationQuit()
    { 
        SaveBar();
    }
    public void SaveBar()
    {
        PlayerPrefs.SetString("SaveName", string.Format("{0}",ChangeName.saveName));

        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());

        PlayerPrefs.SetFloat("BarBall", sbo.FillIconBall.fillAmount);
        PlayerPrefs.SetFloat("BarCutlery", sbo.FillIconCutlery.fillAmount);
        PlayerPrefs.SetFloat("BarLightning", sbo.FillIconLightning.fillAmount);
        PlayerPrefs.SetFloat("BarGraduationCap", sbo.FillIconGraduationCap.fillAmount);
        PlayerPrefs.SetFloat("BarToilet", sbo.FillIconToilet.fillAmount);
    }
    public void Update()
    {
        if (StartGame.triggerSave)
        {
            SaveBar();
            StartGame.triggerSave = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(sbo.FillIconBall.fillAmount);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            sbo.FillIconBall.fillAmount = sbo.FillIconBall.fillAmount + 0.25f;
            sbo.FillIconCutlery.fillAmount = sbo.FillIconCutlery.fillAmount + 0.25f;
            sbo.FillIconLightning.fillAmount = sbo.FillIconLightning.fillAmount + 0.25f;
            sbo.FillIconGraduationCap.fillAmount = sbo.FillIconGraduationCap.fillAmount + 0.25f;
            sbo.FillIconToilet.fillAmount = sbo.FillIconToilet.fillAmount + 0.25f;

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            sbo.FillIconBall.fillAmount = sbo.FillIconBall.fillAmount - 0.25f;
            sbo.FillIconCutlery.fillAmount = sbo.FillIconCutlery.fillAmount - 0.25f;
            sbo.FillIconLightning.fillAmount = sbo.FillIconLightning.fillAmount - 0.25f;
            sbo.FillIconGraduationCap.fillAmount = sbo.FillIconGraduationCap.fillAmount - 0.25f;
            sbo.FillIconToilet.fillAmount = sbo.FillIconToilet.fillAmount - 0.25f;

        }
    }
}
