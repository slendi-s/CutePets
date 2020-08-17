using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Subtraction_bar : MonoBehaviour
{
   [SerializeField]  public Image FillIcon;
    public Calculate_time calculateOfflineScript;
    private float cash;
    private void Start()
    {

        FillIcon.fillAmount = FillIcon.fillAmount - ((float)calculateOfflineScript.SubtractionTime.TotalSeconds / 500);
        //calculateOfflineScript.SubtractionTime.TotalSeconds
        Debug.Log((float)calculateOfflineScript.SubtractionTime.TotalSeconds);
    }
}
//Debug.Log((int) ts.TotalSeconds);