using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 15th April 2016
    Description: Player Collision Detection and Interaction     ||Audio to be added
    Last Modified: 22nd April 2016
*/
public class PlayerCollision : MonoBehaviour {

    public GameController gameController;
    private PlayerAttack playerAttack;
    public GameObject player;
    // Use this for initialization
    void Start () {
        player = this.gameObject;
        playerAttack = player.GetComponent<PlayerAttack>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !playerAttack.Attacking)
        {
            gameController.damage(1);
        }
        if (other.CompareTag("Coin"))
        {
            gameController.moneyUp(5);
            CoinController c = other.GetComponent<CoinController>();
            c.Destroy();
        }
        if (other.CompareTag("BossAttack1"))
        {
            gameController.damage(1);
        }
        if (other.CompareTag("BossAttack2"))
        {
            gameController.damage(1);
        }
    }
}
