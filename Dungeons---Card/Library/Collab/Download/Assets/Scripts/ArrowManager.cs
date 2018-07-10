using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class ArrowManager : MonoBehaviour
{

    public static ArrowManager instance;

    /// <summary>
    /// 箭頭聚焦的圓環
    /// </summary>
    Transform focusRingTfm;

    RectTransform canvasRect;

    /// <summary>
    /// 將屏幕上的一點投影到RectTransform上的世界空間坐標
    /// </summary>
    Vector3 worldPosInRect;

    //Transform arrowHeadTfm ;

    /// <summary>
    /// The arrow mask tfm.
    /// </summary>
    Transform arrowMaskTfm;

    Transform nodesContainerTfm;

    /// <summary>
    /// 箭頭從哪個物體起始的
    /// </summary>
    Transform startTfm;

    /// <summary>
    /// 箭頭身體的從第幾個孩子——Node開始
    /// </summary>
    int initialIndex;

    /// <summary>
    /// 臨時的Node節點
    /// </summary>
    Transform tempNodeTfm;

    /// <summary>
    /// 箭頭的可見長度
    /// </summary>
    float visibleLen = 150f;

    /// <summary>
    /// 箭頭的流動速度
    /// </summary>
    [Range(10f, 300f)]
    public float flowSpeed = 150f;

    /// <summary>
    /// 遮罩箭頭Node的RectTransform
    /// </summary>
    RectTransform maskRect;

    /// <summary>
    /// Rectangle上拖拽的起始位點的世界坐標
    /// </summary>
    Vector2 dragStartPos;

    [Range(30f, 120f)]
    public float offset = 50f;

    Vector3 offsetV = new Vector3(0f, 50f, 0f);

    /// <summary>
    /// Arrow 的 Head 部分的高度
    /// </summary>
    [Range(40f, 120f)]
    const float minHeight = 80f;

    /// <summary>
    /// 箭頭當前是否處於激活狀態
    /// </summary>
    bool mActive = false;

    float dist;

    protected void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    void FixedUpdate()
    {

        MakeArrowFlow();

    }

    void Initialize()
    {
        //arrowHeadTfm = transform.Find ("ArrowHead");
        mActive = false;

        arrowMaskTfm = transform.GetChild(0);

        maskRect = arrowMaskTfm.GetComponent<RectTransform>();

        nodesContainerTfm = arrowMaskTfm.Find("NodesContainer");

        focusRingTfm = GameObject.Find("FocusRing").transform;

        canvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();

    }

    void MakeArrowFlow()
    {
        if (!mActive)
            return;
        //改變箭頭前端的透明度
        for (int i = 0; i < nodesContainerTfm.childCount; i++)
        {
            tempNodeTfm = nodesContainerTfm.GetChild(i);

            tempNodeTfm.localPosition = new Vector3(0f, tempNodeTfm.localPosition.y + Time.fixedDeltaTime * flowSpeed, 0f);
            
            //改變箭頭起點的透明度
            initialIndex = (int)(visibleLen / 100f);

            if (i <= 2)
            {
                tempNodeTfm.GetComponent<Image>().color = Color.Lerp(tempNodeTfm.GetComponent<Image>().color, new Color(1, 1, 1, (60 * i + 60) / 255f), Time.fixedDeltaTime * 5f);
            }
            else if (i <= (initialIndex + 3) && i >= (initialIndex - 3))
            {
                int diff = i - (initialIndex - 3);
                tempNodeTfm.GetComponent<Image>().color = Color.Lerp(tempNodeTfm.GetComponent<Image>().color, new Color(1, 1, 1, (255f - 40f * diff) / 255f), Time.fixedDeltaTime * 5f);
            }
            else if (i > (initialIndex + 3))
            {
                tempNodeTfm.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
            else
            {
                tempNodeTfm.GetComponent<Image>().color = Color.white;
            }
            
            if (tempNodeTfm.localPosition.y > -90f)
            {
                tempNodeTfm.GetComponent<Image>().color = Color.white;
                tempNodeTfm.localPosition = new Vector3(0f, -100+ nodesContainerTfm.GetChild(nodesContainerTfm.childCount - 1).localPosition.y, 0f);
                tempNodeTfm.SetAsLastSibling();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mActive = true;

        transform.localScale = Vector3.one;

        Vector3 startObjPos = eventData.pointerDrag.gameObject.transform.position;

        //WorldPointInRectangle(canvasRect, startObjPos, Camera.main, out worldPosInRect);
        worldPosInRect = startObjPos;
        transform.position = startObjPos;

        dragStartPos = startObjPos;
    }


    /// <summary>
    /// 將世界空間下一點投影到目標Rectangle上，得到投影點在世界空間中的坐標
    /// </summary>
    /// <param name="rect">Rect.</param>
    /// <param name="worldPos">World position.</param>
    /// <param name="camera">Camera.</param>
    /// <param name="worldPosInRect">World position in rect.</param>
    void WorldPointInRectangle(RectTransform rect, Vector3 worldPos, Camera camera, out Vector3 worldPosInRect)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, screenPos, camera, out worldPosInRect);
    }


    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = eventData.pointerDrag.gameObject.transform.position;

        //RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect, eventData.position, Camera.main, out worldPosInRect);

        transform.position = eventData.position;

        transform.rotation = CaculateRotation(eventData.position, dragStartPos);
        //dist = Vector2.Distance (worldPosInRect, dragStartPos) + offset;
        CaculateVisibleLen(eventData.position);
        dist = visibleLen + offset;
        dist = dist >= minHeight ? dist : minHeight;
        maskRect.sizeDelta = new Vector2(200f, dist);
        RayCastCheck(eventData);
    }

    void RayCastCheck(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(transform.position, 10000 * eventData.position, Color.red);
        Debug.DrawLine(transform.position, eventData.position, Color.red);
        RaycastHit2D hit;
        //Physics2D.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("BattleUnit"))
        /*hit = Physics2D.Raycast(transform.position, eventData.position, Vector3.Distance(transform.position, eventData.position), 1 << LayerMask.NameToLayer("BattleUnit"));
        if (hit.collider)
        {
            Transform hitTfm = hit.collider.transform;
            if (hitTfm != startTfm)
            {
                ShowFocusRing(hitTfm);
                RotateFocusRing(worldPosInRect);
            }
        }
        else
        {
            HideFocusRing();
        }*/
    }

    void ShowFocusRing(Transform focusTargetTfm)
    {
        //focusRingTfm.localScale = Vector3.one;
        focusRingTfm.gameObject.SetActive(true);
        focusRingTfm.position = focusTargetTfm.position;
    }

    /// <summary>
    /// Rotates the focus ring.
    /// </summary>
    /// <param name="currentPos">當前鼠標投影到CanvasRect上的世界坐標.</param>
    void RotateFocusRing(Vector3 currentPos)
    {
        Vector3 focusRingPosInRect;
        //WorldPointInRectangle(canvasRect, focusRingTfm.position, Camera.main, out focusRingPosInRect);
        focusRingPosInRect = focusRingTfm.position;
        focusRingTfm.rotation = CaculateRotation(currentPos, focusRingPosInRect);
    }

    void HideFocusRing()
    {
        //focusRingTfm.localScale = Vector3.zero;
        focusRingTfm.gameObject.SetActive(false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localScale = Vector3.zero;
        this.startTfm = null;
        mActive = false;
        HideFocusRing();
    }

    /// <summary>
    /// 計算箭頭身體的可見長度
    /// </summary>
    /// <param name="currentPos">Current position.</param>
    void CaculateVisibleLen(Vector2 currentPos)
    {
        Vector2 dirVector = currentPos - dragStartPos;

        //因為Arrow本身是處在Canvas上的，Arrow的長度會受父物體影響
        //這先將這一長度尺寸還原到世界空間下的尺寸，然後被父物體縮放影響，得到正確尺寸
        //visibleLen = dirVector.magnitude / canvasRect.localScale.x;
        visibleLen = dirVector.magnitude;
    }

    /// <summary>
    /// 輸入當前拖拽位置，獲得箭頭的正確轉向——rotation
    /// </summary>
    /// <returns>The rotation.</returns>
    /// <param name="currentPos">Current position.</param>
    Quaternion CaculateRotation(Vector2 currentPos, Vector2 middlePos)
    {

        Vector2 fromVector = Vector2.up;
        Vector2 toVector = currentPos - middlePos;

        //雖然形參的名稱好像是會有方向區別
        //即從哪個向量到哪個向量
        //然而實際中操作發現，它只會返回兩個向量之間的最小非負數夾角
        float angle = Vector2.Angle(fromVector, toVector);

        //當x份量大於0時，Vector2.Angle 函數得到的角度為繞z軸順時針度數
        if (toVector.x > 0)
        {
            angle = 360f - angle;
        }

        //組合得到歐拉角
        Vector3 diff = new Vector3(0f, 0f, angle);

        //將歐拉角轉化為四元數
        Quaternion rotation = Quaternion.Euler(diff);

        return rotation;
    }
}