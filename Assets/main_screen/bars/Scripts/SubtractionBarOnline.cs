using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SubtractionBarOnline : MonoBehaviour
{
     public float countBarBall= 86400f;
     public float countBarCutlery= 43200f;
     public float countBarLightning= 86400f;
     public float countBarGraduationCap= 86400f;
     public float countBarToilet= 43200f;
     public Image FillIconBall;
     public Image FillIconCutlery;
     public Image FillIconLightning;
     public Image FillIconGraduationCap;
     public Image FillIconToilet;
    //  public Calculate_time calculateOfflineScript;
     public Calculate_time ct;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PermanentSubtraction();
        }
        
        // FillIcon.fillAmount = FillIcon.fillAmount - ((float)calculateOfflineScript.SubtractionTime.TotalSeconds / 500);
        SubtractionBarBall();
        SubtractionBarCutlery();
        SubtractionBarLightning();
        SubtractionBarGraduationCap();
        SubtractionBarToilet();
    }

    public void Start()
    {
        FillIconBall.fillAmount = FillIconBall.fillAmount - ((float)ct.SubtractionTime.TotalSeconds / countBarBall);
        FillIconCutlery.fillAmount = FillIconCutlery.fillAmount - ((float)ct.SubtractionTime.TotalSeconds / countBarCutlery);
        FillIconLightning.fillAmount = FillIconLightning.fillAmount - ((float)ct.SubtractionTime.TotalSeconds / countBarLightning);
        FillIconGraduationCap.fillAmount = FillIconGraduationCap.fillAmount - ((float)ct.SubtractionTime.TotalSeconds / countBarGraduationCap);
        FillIconToilet.fillAmount = FillIconToilet.fillAmount - ((float)ct.SubtractionTime.TotalSeconds / countBarToilet);
        // FillIcon.fillAmount = FillIcon.fillAmount - ((float)calculateOfflineScript.SubtractionTime.TotalSeconds / 500);
        //calculateOfflineScript.SubtractionTime.TotalSeconds
        // Debug.Log((float)calculateOfflineScript.SubtractionTime.TotalSeconds);
    }
    public void SubtractionBarBall()
    {
        FillIconBall.fillAmount = FillIconBall.fillAmount - (Time.deltaTime / countBarBall);
     //   FillIconBall.fillAmount = FillIconBall.fillAmount - ((float)calculateOfflineScript.SubtractionTime.TotalSeconds / 2400000);
    }
    public void SubtractionBarCutlery()
    {
        FillIconCutlery.fillAmount = FillIconCutlery.fillAmount - (Time.deltaTime / countBarCutlery);
    }
    public void SubtractionBarLightning()
    {
        FillIconLightning.fillAmount = FillIconLightning.fillAmount - (Time.deltaTime / countBarLightning);
    }
    public void SubtractionBarGraduationCap()
    {
        FillIconGraduationCap.fillAmount = FillIconGraduationCap.fillAmount - (Time.deltaTime / countBarGraduationCap);
    }
    public void SubtractionBarToilet()
    {
        FillIconToilet.fillAmount = FillIconToilet.fillAmount - (Time.deltaTime / countBarToilet);
    }
    public void PermanentSubtraction()
    {
        FillIconBall.fillAmount = FillIconBall.fillAmount - (1f / 5f);
    }
}

