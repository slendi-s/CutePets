using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerResult : MonoBehaviour
{
    private bool emptySlot1 = true, emptySlot2 = true, emptySlot3 = true;
    private bool changeNow=false;
    public Drag_Hand dragHand;
    public GameObject boxMove;
    private void Start()
    {
        dragHand = GetComponent<Drag_Hand>();
        Debug.Log(dragHand.startPosition);
    }
    public void Update()
    {
        
        try
        {
            if (dragHand.startPosition != boxMove.transform.position)
            {
                changeNow = true;
                
            }
            else
            {
                changeNow = false;
            }
        }
        catch
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((emptySlot1 == true) && (col.CompareTag("EmptySlot")))
        {
            Debug.Log("Торкнуло");
        }
        
    }
}
