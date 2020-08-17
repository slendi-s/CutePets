using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChangeName : MonoBehaviour
{
    public TMP_InputField fildeName;
    public TextMeshPro showName;
    public static string saveName;

    private void OnApplicationQuit()
    {
       // PlayerPrefs.SetString("SaveName",saveName);
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveName"))
        {
            //saveName = PlayerPrefs.GetString("SaveName");
            
        }
       
    }
    private void Update()
    {
       // Debug.Log(PlayerPrefs.GetString("BarBall"));
    }
    private void OnMouseUp()
    {
        // showName.text = PlayerPrefs.GetString("SaveName");

        // showName.text = fildeName.text;
        
        fildeName.gameObject.SetActive(true);
        showName.text = saveName;
        fildeName.text = showName.text;
        showName.gameObject.SetActive(false);
    }
}
