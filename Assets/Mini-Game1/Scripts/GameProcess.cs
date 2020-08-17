using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameProcess : MonoBehaviour
{
    [SerializeField] public GameObject mainMoveObject;
    [SerializeField] public TextMeshProUGUI scorecount;
    [SerializeField] public TextMeshProUGUI textTimer;
    private float timer=30;
    private float xPositionMouse;
    private Vector2 cor;
    private void Update()
    {
        textTimer.text = string.Format("Time: {0}", Mathf.Round(timer));
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            timer = 30;
            FallingObject.score = 0;
            ChangeSceneOnBall.fillUpBallBar = true;
            MoneyManagment.givemoneyforgame = true;
            XPProcess.giveexpforgame = true;
            SceneManager.LoadScene(0);
        }
        scorecount.text = string.Format("Score: {0}",FallingObject.score);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            HorizontalMove();
        }

    }

    private void HorizontalMove()
    {
        xPositionMouse = Input.mousePosition.x;
        mainMoveObject.transform.position = new Vector3 (xPositionMouse, mainMoveObject.transform.position.y, mainMoveObject.transform.position.z);   
    }
}
