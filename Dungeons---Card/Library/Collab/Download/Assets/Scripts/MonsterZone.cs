using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform focusRingTfm;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowFocusRing(this.transform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideFocusRing();
    }
    void ShowFocusRing(Transform focusTargetTfm)
    {
        //focusRingTfm.localScale = Vector3.one;
        focusRingTfm.gameObject.SetActive(true);
        focusRingTfm.position = focusTargetTfm.position;
    }
    void HideFocusRing()
    {
        //focusRingTfm.localScale = Vector3.zero;
        focusRingTfm.gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
        focusRingTfm = GameObject.Find("FocusRing").transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
