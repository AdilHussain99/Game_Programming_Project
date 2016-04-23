using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
    Author: Adil Hussain
    Date Created: 22nd April 2016
    Description: Monitors Player Score and Lives
    Last Modified: 22nd April 2016
*/
public class GameControllerFinal : MonoBehaviour
{
    public GameObject player;

    private int health = 10;
    private int score = 0;
    private bool isGameOver = false;

    public Text LivesLabel;

    //damage taken
    public void damage(int value)
    {
        if (health >= value)
        {
            health -= value;
        }
        else
        {
            //Game over
            health = 0;
            isGameOver = true;
            LivesLabel.enabled = false;
            Application.LoadLevel("Menu");

        }
        this.LivesLabel.text = "Lives: " + health;
        Debug.Log("Lives: " + health);
    }


    // Use this for initialization
    void Start()
    {
        LivesLabel.enabled = true;
        health = 5;
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //if all hp is lost
        if (isGameOver)
        {
            Debug.Log("GAME OVER");
            player.SetActive(false);
        }
        if (score > 20)
        {
            score -= 20;
            health += 1;
        }
        this.LivesLabel.text = "Lives: " + health;
    }
}
