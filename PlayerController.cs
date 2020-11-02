using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float Jumpspeed = 5f;
    private float movement = 0f;
    public Transform groundCheckpoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Rigidbody2D rigidbody;
    private Animator playeranimation;
    public Vector3 respawningPoint;

    public LevelManager gameLevelManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D> ();
        playeranimation = GetComponent<Animator>();
        respawningPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckpoint.position, groundCheckRadius, groundLayer);

        movement = Input.GetAxis ("Horizontal");
        Debug.Log (movement);
        if (movement > 0f){
            rigidbody.velocity = new Vector2(movement*speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(0.88f, 0.57379f);
        }
        else if (movement < 0f){
            rigidbody.velocity = new Vector2(movement*speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(-0.88f, 0.57379f);
        }
        
        if (Input.GetButtonDown("Jump") && isTouchingGround){

            rigidbody.velocity = new Vector2(rigidbody.velocity.x, Jumpspeed);
        }

        playeranimation.SetFloat("speed",Mathf.Abs(rigidbody.velocity.x));
        playeranimation.SetBool("onGround", isTouchingGround);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Fell"){
            //transform.position = respawning;
            gameLevelManager.Respawn();
            Debug.Log("fell");
        }
        if (other.tag == "Checkpoint"){
            respawningPoint = other.transform.position;
            Debug.Log("Checkpoint");
        }
    }
}
