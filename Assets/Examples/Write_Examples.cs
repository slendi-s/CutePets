using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Write_Examples : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI exampleText1, exampleText2, exampleText3, resultText1, resultText2, resultText3;
    private string writeText;
    private int method;
    private float resultExample;
    private float term1, term2;
    private int slotResultRandom;
    private float slotResult;
    private float resultNumber;
    private float result;
    private float comparisonResultExample1, comparisonResultExample2, comparisonResultExample3;
    public GameObject slot1, slot2, slot3;
    [SerializeField] Text trueresult;
    [SerializeField] Text processresult;
    private float coderesult1, coderesult2, coderesult3;
    [SerializeField] TextMeshProUGUI victoryText;
    private float timer=3;
    private float triggerTimer;
    static float countScore;

    private void Start()
    {
      
        StartGame();
    }
    private void Update()
    {
        if (trueresult.text == processresult.text)
        {

            victoryText.gameObject.SetActive(true);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 3;
                countScore += 1;
                if (countScore == 5)
                {
                    countScore = 0;
                    MoneyManagment.givemoneyforgame = true;
                    XPProcess.giveexpforgame = true;
                    ChangeSceneOnGraduationCap.fillUpGraduationCapBar = true;
                    SceneManager.LoadScene(0);
                    return;
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                
            }
            Debug.Log(countScore);
        }
    }
    private void StartGame()
    {
        Reset();
        ChoiseMethod();
        comparisonResultExample1 = resultExample;
        exampleText1.text = writeText;
        coderesult1 = resultExample;
        //slot1.name = string.Format("{0}",resultExample);
        RememberRandomResult();
        ChoiseMethod();
        comparisonResultExample2 = resultExample;
        exampleText2.text = writeText;
        coderesult2 = resultExample;
        //slot2.name = string.Format("{0}", resultExample);
        RememberRandomResult();
        ChoiseMethod();
        exampleText3.text = writeText;
        comparisonResultExample3 = resultExample;
        coderesult3 = resultExample;
        //slot3.name = string.Format("{0}", resultExample);
        RememberRandomResult();
        trueresult.text = string.Format("{0}-{1}-{2}-", coderesult1, coderesult2, coderesult3);
        // Debug.Log(method);
    }

    private void RememberRandomResult()
    {
        resultNumber = Random.Range(1, 4);

        switch (resultNumber)
        {
            case 1:
                if (resultText1.text == "")
                {
                    resultText1.text = string.Format("{0}", resultExample);
                    slot1.name = string.Format("{0}", resultExample);
                    
                }
                else
                {
                    RememberRandomResult();
                }
                
                break;
            case 2:
                if (resultText2.text == "")
                {
                    resultText2.text = string.Format("{0}", resultExample);
                    slot2.name = string.Format("{0}", resultExample);
                    
                }
                else
                {
                    RememberRandomResult();
                }
                break;
            case 3:
                if (resultText3.text == "")
                {
                    resultText3.text = string.Format("{0}", resultExample);
                    slot3.name = string.Format("{0}", resultExample);
                    
                }
                else
                {
                    RememberRandomResult();
                }
                break;
        }
    }

   private void ChoiseResult()
    {
        slotResultRandom = Random.Range(1,4);

        switch (slotResultRandom)
        {
            case 1:
                slotResult = resultExample;
                break;
            case 2:
               
                break;
            case 3:
              
                break;
        }
    }
    private void Reset()
    {
        resultText1.text = "";
        resultText2.text = "";
        resultText3.text = "";
    }
    private void ChoiseMethod()
    {
        method = Random.Range(1, 5);
        term1 = Random.Range(0, 10);
        term2 = Random.Range(0, 10);

        switch (method)
        {
            case 1:
              //  Debug.Log("Сложение");    
                resultExample = term1 + term2;
                writeText = string.Format("{0} + {1} =",term1,term2);
                break;
            case 2:
              //  Debug.Log("Вычетание");
                resultExample = term1 - term2;
                writeText = string.Format("{0} - {1} =", term1, term2);
                break;
            case 3:
               // Debug.Log("Умножение");
                resultExample = term1 * term2;
                writeText = string.Format("{0} * {1} =", term1, term2);
                break;
            case 4:
              //  Debug.Log("Деление");
                while (term1 % term2 != 0)
                {
                    term1 = Random.Range(0, 10);
                    term2 = Random.Range(0, 10);
                }
                resultExample = term1 / term2;
                writeText = string.Format("{0} / {1} =", term1, term2);
                break;
        }
       
    }
}
