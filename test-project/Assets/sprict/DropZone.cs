using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    public GameObject gameData;

    private HandData handData;

    void Start()
    {
        handData = gameData.GetComponent<HandData>();
    }

	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log("OnPointerEnter");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.placeholderParent = this.transform;
		}
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("OnPointerExit");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}
	
	public void OnDrop(PointerEventData eventData) {
		Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.parentToReturnTo = this.transform;
		}
        

	}
    public void updateHand()
    {
        int[] currentHand = new int[5];
        Debug.Log(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            switch (transform.GetChild(i).name)
            {
                case "Card 1(Clone)":
                    currentHand[i] = 1;
                    
                    break;
                case "Card 2(Clone)":
                    currentHand[i] = 2;
                 
                    break;
                case "Card 3(Clone)":
                    currentHand[i] = 3;
                    
                    break;
                case "Card 4(Clone)":
                    currentHand[i] = 4;
                   
                    break;
                case "Card 5(Clone)":
                    currentHand[i] = 5;
                    
                    break;
            }
        }
        handData.moveCount++;
        handData.handData = currentHand;
        
    }
    
}
