using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePageClose : MonoBehaviour
{
    [SerializeField] public GameObject profilePage;
    [SerializeField] public GameObject iconLVL;

    private void OnMouseUp()
    {
        iconLVL.SetActive(true);
        profilePage.SetActive(false);
    }
}
