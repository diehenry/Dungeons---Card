using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhichRole : MonoBehaviour {
    private int select;
    public GameObject[] useRole;
    
    void Start () {
        GetRoleMessage();
	}

    public void GetRoleMessage()
    {
        select = PlayerPrefs.GetInt("SelectRoleIndex");
     //   Debug.Log("select:" + select);
        for (int i = 0; i < 2; i++)
        {
            if (select == i)
            {
                useRole[select].SetActive(true);
                break;
            }
            else
            {
                useRole[select].SetActive(false);
            }
        }
    }
}
