using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveName : MonoBehaviour
{
    public TextMeshPro showName;
    public TMP_InputField fieldName;
    public GameObject profile;

    private void OnApplicationQuit()
    {
        profile.gameObject.SetActive(true);
        PlayerPrefs.SetString("SaveName",ChangeName.saveName);
        profile.gameObject.SetActive(false);
    }

    
    private void Awake()
    {
        profile.gameObject.SetActive(true);
        if (PlayerPrefs.HasKey("SaveName"))
        {
            showName.text = PlayerPrefs.GetString("SaveName");
        }
        profile.gameObject.SetActive(false);
    }

    private void Update()
    {
        PlayerPrefs.SetString("SaveName", ChangeName.saveName);
    }
}
