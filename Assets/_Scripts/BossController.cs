using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
    Author: Adil Hussain
    Date Created: 22nd April 2016
    Description: Boss Controls     
    Last Modified: 22nd April 2016
*/
public class BossController : MonoBehaviour
{
    //Private Variables
    private int health = 20;
    private bool isDead = false;
    private Animator _animator;
    private float attackTimer = 0;
    private float attackCD = 3f;
    private bool attacking = false;

    //Public Variables
    public Text BossHPLabel;
    public Collider2D attackTrigger1;
    public Collider2D attackTrigger2;

    public void damage()
    {
        if (health >= 1)
        {
            health -= 1;
        }
        else
        {
            //Boss Dead
            health = 0;
            isDead = true;
            this._animator.SetInteger("AnimState", 3);
            BossHPLabel.enabled = false;
        }
    }
    // Use this for initialization
    void Start()
    {
        BossHPLabel.enabled = true;
        this._animator = gameObject.GetComponent<Animator>();
        this.attackTrigger1.enabled = false;
        this.attackTrigger2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if (attacking)
        {
            attackTimer += Time.deltaTime;
            //Debug.Log(attackTimer);
            //Debug.Log(Time.deltaTime);
            if (attackTimer > 1)
            {
                attackTimer = 0;
                Debug.Log(attackTimer);
                int attack = Random.Range(0, 3);
                if (attack == 0)
                {
                    attacking = false;
                    //attackTimer = attackCD;
                    this._animator.SetInteger("AnimState", 0);
                    attackTrigger1.enabled = false;
                    attackTrigger2.enabled = false;
                }
                if (attack == 1 && !attacking)
                {
                    attacking = true;
                    //attackTimer = attackCD;
                    this._animator.SetInteger("AnimState", 1);
                    attackTrigger1.enabled = true;
                }
                if (attack == 2 && !attacking)
                {
                    attacking = true;
                    //attackTimer = attackCD;
                    this._animator.SetInteger("AnimState", 2);
                    attackTrigger2.enabled = true;
                }
            }
           /* else
            {
                attacking = false;
                attackTrigger1.enabled = false;
                attackTrigger2.enabled = false;
            }*/
        }
        _animator.SetBool("Attacking", attacking);
    }

    //IEnumerable AttackTriggerCD()
    //{
    //    Debug.Log("Boss Attack");
    //    yield return new WaitForSeconds(2f);
    //    attackTrigger1.enabled = false;
    //    attackTrigger2.enabled = false;

    //}

    //public void TriggerAttack()
    //{

    //}
}
