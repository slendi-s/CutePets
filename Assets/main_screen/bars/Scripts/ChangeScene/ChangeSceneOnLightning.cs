using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeSceneOnLightning : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public GameObject bgLightning;
    public static bool onLightning;
    private void OnMouseUp()
    {
        onLightning = true;
        bgLightning.SetActive(true);
        text.text = "Sleep";
        //Debug.Log("Lightning");
    }
}
