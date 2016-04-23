using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 15th April 2016
    Description: Enemy Control, Movement and Animation 
    Last Modified: 16th April 2016
*/
public class EnemyController : MonoBehaviour
{

    // Public Variables
    public float speed = 100f;
    public Transform groundCheck;
    public Transform groundAhead;

    // Private Variables
    private Transform _transform;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded = false;
    private bool _isGroundAhead = true;
    private bool _isFacingRight = true;
    private bool _isDead = false;
    // Use this for initialization
    void Start()
    {
        this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if enemy is grounded
        this._isGrounded = Physics2D.Linecast(this._transform.position, this.groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(this._transform.position, this.groundCheck.position);

        this._isGroundAhead = Physics2D.Linecast(this._transform.position, this.groundAhead.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(this._transform.position, this.groundAhead.position);

        if (this._isGrounded && !_isDead)
        {
            Debug.Log("Grounded");
            this._animator.SetInteger("AnimState", 1);
            this._rigidbody2D.velocity = new Vector2(this._transform.localScale.x, 0) * this.speed;

            if (this._isGroundAhead == false)
            {
                this._flip();
            //    Vector2 currentPosition = this._transform.position;
            //    currentPosition += new Vector2(5f, 0f);
            //    this._transform.position = currentPosition;
            //}
            //else
            //{
            //    this._isFacingRight = false;
            //    this._flip();
            //    Vector2 currentPosition = this._transform.position;
            //    currentPosition -= new Vector2(5f, 0f);
            //    this._transform.position = currentPosition;
            }
        }

    }
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Enemy"))
        {
            this._flip();
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            this.Death();
        }
    }


    IEnumerator CallDestroy()
    {
        Debug.Log("Call destroy");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }

    public void Death()
    {
        Debug.Log("call death");
        _isDead = true;
        _animator.SetInteger("AnimState", 2);
        StartCoroutine("CallDestroy");
    }

    private void _flip() // To flip Enemy Sprite
    {
        if (this._transform.localScale.x == 2)
        {
            this.gameObject.transform.position = new Vector2((_transform.position.x + 5), _transform.position.y);
            this._transform.localScale = new Vector2(-2f, 2f);
        }
        else
        {
            this.gameObject.transform.position = new Vector2((_transform.position.x - 5), _transform.position.y);
            this._transform.localScale = new Vector2(2f, 2f);
        }
    }
}
