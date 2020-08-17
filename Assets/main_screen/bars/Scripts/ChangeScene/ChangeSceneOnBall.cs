using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ChangeSceneOnBall : MonoBehaviour
{
    [SerializeField] public GameObject bgBall;
    [SerializeField] public GameObject buttonStart;
    [SerializeField] public TextMeshProUGUI text;
    public static bool onBall;
    public Image ballBar;
    public static bool fillUpBallBar;
    
    private void OnMouseUp()
    {
        onBall = true;
        buttonStart.SetActive(true);
        bgBall.SetActive(true);
        text.text = "Play";
       // Debug.Log("ball"); 
    }
    private void Update()
    {
        if (fillUpBallBar)
        {
            ballBar.fillAmount += 0.5f;
            fillUpBallBar = false;
        }
    }
}
