using System.Collections;
using System.Collections.Generic;
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
       
    }

}