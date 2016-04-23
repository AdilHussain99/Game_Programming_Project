using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 15th April 2016
    Description: Player Collision Detection and Interaction     ||Audio to be added
    Last Modified: 22nd April 2016
*/
public class AttackTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController e = other.GetComponent<EnemyController>();
            Debug.Log("attack");
            e.Death();
        }
        if (other.CompareTag("Boss"))
        {
            BossController b = other.GetComponent<BossController>();
            Debug.Log("attacked Boss");
            b.damage();
        }
    }
}
