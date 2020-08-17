using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeSceneOnCutlery : MonoBehaviour
{
    [SerializeField] GameObject bgCutlery;
    [SerializeField] public TextMeshProUGUI text;
    public GameObject food;
    public static bool onCutlery;
    private void OnMouseUp()
    {
        onCutlery = true;
        food.SetActive(true);
        bgCutlery.SetActive(true);
        text.text = "Food";
        //Debug.Log("cutlery");
    }
}
