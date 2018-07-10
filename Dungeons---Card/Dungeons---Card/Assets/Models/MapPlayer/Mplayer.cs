using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mplayer : MonoBehaviour {

    public Rigidbody2D mapPlayer;
    private float speed = 10;
    private int facing = 1;
    public bool moveUp;
    public bool moveDown;
    public bool moveLeft;
    public bool moveRight;

    void Start() {
        mapPlayer = GetComponent<Rigidbody2D>();
    }
    void Update() {

        if (moveUp)
        {
            mapPlayer.transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        else if (moveDown)
        {
            mapPlayer.transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        else if (moveLeft)
        {
            mapPlayer.transform.Translate(Vector2.left * Time.deltaTime * speed);
            if (facing == 1)
            {
                mapPlayer.transform.localScale = new Vector3(-1f, 1f, 1f);
                facing = 0;
            }
        }
        else if (moveRight)
        {
            mapPlayer.transform.Translate(Vector2.right * Time.deltaTime * speed);
            if (facing == 0)
            {
                mapPlayer.transform.localScale = new Vector3(1f, 1f, 1f);
                facing = 1;
            }
        }
    }
    
}
