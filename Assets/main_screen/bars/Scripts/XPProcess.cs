using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class XPProcess : MonoBehaviour
{
    public Image barXP;
    public TextMeshProUGUI lvlText;
    public int amounteXp=10;
    public int lvlcount=1;
    public float residue;
    public float sumxp;
    public static bool giveexpforgame=false;
 

    private void Awake()
    {
        LoadLvl();
    }
    
    private void OnApplicationQuit()
    {
        SaveLvl();
    }


    public void Start()
    {

        GiveExp(0);
        //PlayerPrefs.SetFloat("Lvl", barXP);
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log(sumxp);
        }
        if (giveexpforgame)
        {
            GiveExp(Random.Range(1, 10));
            giveexpforgame = !giveexpforgame;
        }
      //  Debug.Log(lvlText.text);
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GiveExp(9);
        }
        
    }
    private void GiveExp(float exp)
    {
        sumxp += exp;
       // Debug.Log(sumxp);
        if (amounteXp-barXP.fillAmount * amounteXp < exp) // если в избытке то
        {
            residue = amounteXp - barXP.fillAmount * amounteXp;
            exp = exp - residue;
            LevelUp();
            //Debug.Log(exp);
            barXP.fillAmount = barXP.fillAmount + (exp / amounteXp);
        }
        else
        {
            
            barXP.fillAmount = barXP.fillAmount + (exp / amounteXp);
        }
        SaveLvl();
    }
    private void SaveLvl()
    {
            PlayerPrefs.SetFloat("sumxp", sumxp);
            PlayerPrefs.SetInt("lvlcount", lvlcount);
            PlayerPrefs.SetFloat("Lvl", barXP.fillAmount);
            PlayerPrefs.SetInt("amounteXp",amounteXp);
            PlayerPrefs.SetString("lvlText", lvlText.text);
    }
    private void LoadLvl()
    {
        if (PlayerPrefs.HasKey("lvlText"))
            lvlText.text = string.Format("{0}", PlayerPrefs.GetString("lvlText"));
        Debug.Log(PlayerPrefs.GetString("lvlText"));
        Debug.Log(lvlText.text);
        if (PlayerPrefs.HasKey("sumxp"))
            sumxp = PlayerPrefs.GetFloat("sumxp", sumxp);
        if (PlayerPrefs.HasKey("amounteXp"))
            amounteXp = PlayerPrefs.GetInt("amounteXp");
        if (PlayerPrefs.HasKey("Lvl"))
            barXP.fillAmount = PlayerPrefs.GetFloat("Lvl");
        if (PlayerPrefs.HasKey("lvlcount"))
            lvlcount = PlayerPrefs.GetInt("lvlcount");
    }
    private void LevelUp()
    {
        amounteXp = Mathf.RoundToInt(amounteXp * 1.25f);
        lvlcount = lvlcount + 1;
        lvlText.text = string.Format("{0}",lvlcount);
        barXP.fillAmount = 0;
    }
}
