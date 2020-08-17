using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ProfilePage : MonoBehaviour
{
    [SerializeField] public GameObject profilePage;
    [SerializeField] public GameObject iconLVL;
    public TextMeshPro lvlCount;
    public TextMeshPro amountLvlLine;
    public Image lvlLine;
    public XPProcess xpProcess;
    
    private void OnMouseUp()
    {
        iconLVL.SetActive(false);
        profilePage.SetActive(true);    
    }
    private void Update()
    {
        lvlLine.fillAmount = xpProcess.barXP.fillAmount;
        lvlCount.text = xpProcess.lvlText.text;
        amountLvlLine.text = string.Format("{0}/{1}",Mathf.Round(xpProcess.amounteXp*xpProcess.barXP.fillAmount),xpProcess.amounteXp);
    }
}
