using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class Storage_slot : MonoBehaviour, IHasChanged
{
    [SerializeField] TextMeshProUGUI slotText1, slotText2, slotText3;
    [SerializeField] Transform slot1,slot2,slot3;
    public Transform slots;
    [SerializeField] GameObject Result1, Result2, Result3;
    [SerializeField] Text resultText;
    [SerializeField] Write_Examples resultExample;
    [SerializeField] BoxCollider2D boxResult1, boxResult2, boxResult3;
    [SerializeField] Collider2D emptySlot1, emptySlot2, emptySlot3;
    int nextExample = 0;
    float comparisonResult1, comparisionResult2, comparisionResult3;
    public Text inventoryText;


   // void Start()
    //{
     //   HasChanged();
    //}
    
    public void HasChanged()
    {
          System.Text.StringBuilder builder = new System.Text.StringBuilder();
          // builder.Append("");
         foreach (Transform slotTransform in slots)
         {
          GameObject item = slotTransform.GetComponent<Slot>().item;
          if (item)
          {
                //builder.Append(resultExample);
                builder.Append(item.name); //builder.Append(item.name);
                builder.Append("-");
         }
        
         }
          inventoryText.text = builder.ToString();
    }
}
namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
        
    }
}