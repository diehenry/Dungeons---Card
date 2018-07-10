using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    public Mplayer player;
    void Start()
    {
        player = FindObjectOfType<Mplayer>();
    }
    public void PressUpArrow()
    {
        player.moveUp = true;
        player.moveDown = false;
        player.moveLeft = false;
        player.moveRight = false;
    }
    public void PressDownArrow()
    {
        player.moveUp = false;
        player.moveDown = true;
        player.moveLeft = false;
        player.moveRight = false;
    }
    public void PressLeftArrow()
    {
        player.moveUp = false;
        player.moveDown = false;
        player.moveLeft = true;
        player.moveRight = false;
    }
    public void PressRightArrow()
    {
        player.moveUp = false;
        player.moveDown = false;
        player.moveLeft = false;
        player.moveRight = true;
    }
    public void ReleaseUpArrow()
    {
        player.moveUp = false;
    }
    public void ReleaseDownArrow()
    {
        player.moveDown = false;
    }
    public void ReleaseLeftArrow()
    {
        player.moveLeft = false;
    }
    public void ReleaseRightArrow()
    {
        player.moveRight = false;
    }
    public void NothingCanDo()
    {
        player.moveUp = false;
        player.moveDown = false;
        player.moveLeft = false;
        player.moveRight = false;
    }
}
