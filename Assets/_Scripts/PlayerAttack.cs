﻿using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 15th April 2016
    Description: Player Attack and Exit
    Last Modified: 22nd April 2016
*/
public class PlayerAttack : MonoBehaviour {
    private bool attacking = false;

    public bool Attacking
    {
        get { return this.attacking; }
    }

    private float attackTimer = 0;
    private float attackCD = 0.3f;

    public Collider2D attackTrigger;

    private Animator _animator;

    void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButton("Fire1")&& !attacking){
            attacking = true;
            attackTimer = attackCD;
            this._animator.SetInteger("AnimState", 3);
            attackTrigger.enabled = true;

        }

        if(attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;

            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        _animator.SetBool("Attacking", attacking);
	
	}
}
