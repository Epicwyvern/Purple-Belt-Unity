using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Default jumping power")]
    public float jumpPower = 6.5f;
    [Header("Boolean isGrounded")]
    public bool isGrounded = false;
    float posX = 0.0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f));
        }

        if(transform.position.x < posX) {
            GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(collision.collider.tag == "Ground") {
            isGrounded = true;
        }

        if(collision.collider.tag == "Enemy") {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Coin") {
            GameObject.Find("GameController").GetComponent<GameController>().IncrementScore();
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        if(collision.collider.tag == "Ground") {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.collider.tag == "Ground") {
            isGrounded = false;
        }
    }

    void GameOver() {
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }
}
