using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
    Author: Adil Hussain
    Date Created: 15th April 2016
    Description: Monitors Player Score and Lives ||Still need to add calls for when game is over/new game||Add coins
    Last Modified: 16th April 2016
*/
public class GameController : MonoBehaviour
{
    public GameObject player;

    private int health = 5;
    private int score = 0;
    private bool isGameOver = false;

    public Text LivesLabel;
    public Text ScoreLabel;
    


    public void YOUWIN()
    {
        isGameOver = true;
        ScoreLabel.enabled = false;
        LivesLabel.enabled = false;
    }
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
            ScoreLabel.enabled = false;
            LivesLabel.enabled = false;

        }
        this.LivesLabel.text = "Lives: " + health;
        Debug.Log("Lives: " + health);
    }
    //adding score
    public void moneyUp(int value)
    {
        score += value;
        this.ScoreLabel.text = "Money: " + score;
        Debug.Log("Score: " + score);

    }


    // Use this for initialization
    void Start()
    {
        LivesLabel.enabled = true;
        ScoreLabel.enabled = true;
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
            this.ScoreLabel.gameObject.SetActive(false);
        }
        if (score > 20)
        {
            score -= 20;
            health += 1;
        }
        this.LivesLabel.text = "Lives: " + health;
        this.ScoreLabel.text = "Money: " + score;
    }
}
