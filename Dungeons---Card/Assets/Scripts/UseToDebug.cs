using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UseToDebug : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (Debug.isDebugBuild == false)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (float i = 0; i < 1; i+=0.01f)
        {
            Debug.DrawLine(po(new Vector3(-10, -5), new Vector3(10, -5), new Vector3(0,0), i )
                , po(new Vector3(-10, -5), new Vector3(10, -5), new Vector3(0,0), i + 0.01f),Color.red);
        }
    }

    Vector2 Bezier(Vector2 a, Vector2 b,Vector2 c,float t)
    {
        var ab = Vector2.Lerp(a, b, t);
        var bc = Vector2.Lerp(b, c, t);
        var result = Vector2.Lerp(ab, bc, t);
        return result;
    }

    private Vector2 po(Vector2 v0, Vector2 v1, Vector2 a0,float t)//根据当前时间t 返回路径  其中v0为起点 v1为终点 a为中间点   
    {
        Vector2 a;
        a = t * t * (v1 - 2 * a0 + v0) + v0 + 2 * t * (a0 - v0);//公式为B(t)=(1-t)^2*v0+2*t*(1-t)*a0+t*t*v1 其中v0为起点 v1为终点 a为中间点   
        return a;
    }
}