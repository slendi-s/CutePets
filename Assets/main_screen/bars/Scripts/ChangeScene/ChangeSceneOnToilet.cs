using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeSceneOnToilet : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public GameObject bgToilet;
    public static bool onToilet;
    private void OnMouseUp()
    {
        onToilet = true;
        bgToilet.SetActive(true);
        text.text = "Use";
        // Debug.Log("Toilet");
    }
}
