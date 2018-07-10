using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapIcon : MonoBehaviour {

    public GameObject icon;
    //public string nextScene; 
    private Touch rolePlayer;
    void Start()
    {
        rolePlayer = FindObjectOfType<Touch>();
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
             if (icon.tag == "Monster")
             {
                 icon.SetActive(false);
                 rolePlayer.NothingCanDo();
                 SceneManager.LoadScene("Fight");
             }
             else if (icon.tag == "Treasure")
             {
                 icon.SetActive(false);

             }
             else if(icon.tag == "Next Level")
             {
                icon.SetActive(false);
                SceneManager.LoadScene("GameMap");
             }
              
        }
    }

}
