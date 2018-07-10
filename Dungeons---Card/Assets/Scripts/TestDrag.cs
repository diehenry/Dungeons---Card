using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    bool isExit;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //ArrowManager.instance.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
            ArrowManager.instance.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ArrowManager.instance.OnEndDrag(eventData);
    }

    // Use this for initialization
    void Start()
    {
        isExit = GetComponent<Draggable>().placeholderParent.GetComponent<DropZone>().isExit;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
