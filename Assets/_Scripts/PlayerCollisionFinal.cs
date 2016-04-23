using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 22nd April 2016
    Description: Player Collision Detection and Interaction     ||Audio to be added
    Last Modified: 22nd April 2016
*/
public class PlayerCollisionFinal : MonoBehaviour
{

    public GameControllerFinal gameControllerFinal;
    private PlayerAttack playerAttack;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        player = this.gameObject;
        playerAttack = player.GetComponent<PlayerAttack>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BossAttack1"))
        {
            gameControllerFinal.damage(1);
        }
        if (other.CompareTag("BossAttack2"))
        {
            gameControllerFinal.damage(1);
        }
    }
}
