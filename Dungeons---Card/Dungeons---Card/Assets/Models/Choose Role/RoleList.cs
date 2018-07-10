using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class RoleList :  MonoBehaviour 
{
    private int length; //角色個數
    private int selectingIndex = 0; // 選擇哪個角色
    private GameObject[] roleShow; //顯示角色的陣列
    public GameObject[] role; //角色陣列

	// Use this for initialization
	void Start () {
        length = role.Length;
        roleShow = new GameObject[length];
        Clone();
    }

    public void UpdateRoleShow()
    {
        roleShow[selectingIndex].SetActive(true);
        for(int i=0; i<length; i++)
        {
            if(i!=selectingIndex)
            {
                roleShow[i].SetActive(false);
            }
        }
    }
    public void OnNextButtonClick()
    {
        selectingIndex++;
        if(selectingIndex >= length)
        {
            selectingIndex = 0;
        }
        UpdateRoleShow();
    }
    public void OnPreButtonClick()
    {
        selectingIndex--;
        if(selectingIndex < 0)
        {
            selectingIndex = length - 1;
        }
        UpdateRoleShow();
    }

    public void OnLoadButtonClick()
    {
   //     Debug.Log("selectingIndex:"+selectingIndex);
        PlayerPrefs.SetInt("SelectRoleIndex", selectingIndex);
        SceneManager.LoadScene("GameMap");
    }
    public void Clone()
    {
        for (int i = 0; i < role.Length; i++)
        {
            roleShow[i] = Instantiate(role[i]);
            roleShow[i].transform.position = new Vector3(0, 0, 1);
        }
        UpdateRoleShow();
    }
}
