using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapManager : MonoBehaviour
{

    static MapManager instance;
    // Use this for initialization
    void Awake()
    {
        if(instance ==  null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        
    }

}
