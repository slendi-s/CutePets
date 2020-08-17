using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class ChangeSceneOnGraduationCap : MonoBehaviour
{
    [SerializeField] public GameObject bgGraduationCap;
    [SerializeField] public GameObject buttonStart;
    [SerializeField] public TextMeshProUGUI text;
    public static bool onGC;
    public Image graduattonCapBar;
    public static bool fillUpGraduationCapBar = false;
    private void OnMouseUp()
    {
        onGC = true;
        buttonStart.SetActive(true);
        bgGraduationCap.SetActive(true);
        text.text = "Play";

        // SceneManager.LoadScene("Game1");
        //  Debug.Log("GraduationCap");
    }
    private void Update()
    {
        if (fillUpGraduationCapBar)
        {
            graduattonCapBar.fillAmount += 0.5f;
            fillUpGraduationCapBar = false;
        }
    }
}
