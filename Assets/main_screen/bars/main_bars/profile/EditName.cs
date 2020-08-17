using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EditName : MonoBehaviour
{

    public TMP_InputField fildeName;
    public TextMeshPro showName;
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            
            
            showName.gameObject.SetActive(true);
            ChangeName.saveName = fildeName.text;
            showName.text = fildeName.text;
            fildeName.gameObject.SetActive(false);
            
                
            
        }
       
    }

}
