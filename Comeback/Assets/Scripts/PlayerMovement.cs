using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D player;

    public float moveHoz;
    public float moveSpeed;
    public float speedLimit;

    public float moveVert;
    public float jumpForce;
    public bool canJump;
    public float jumpCooldown;
    public float jumpTimer;
    public bool grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        player = gameObject.GetComponent<Rigidbody2D>();
        moveHoz = 0f;
        moveSpeed = 3f;
        speedLimit = 7f;
        jumpForce = 50f;
        canJump = false;
        jumpCooldown = 6f;
        jumpTimer = 0.0f;
        grounded = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.D)) {
            moveHoz = 1;
        }
        else if (Input.GetKeyUp(KeyCode.D)) {
            moveHoz = 0;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            moveHoz = -1;
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            moveHoz = 0;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            moveVert = 1;
        }
        else if (Input.GetKeyUp(KeyCode.W)) {
            moveVert = 0;
        }
    }

    private void FixedUpdate() {
        //Horizonal movement
        if (moveHoz > 0.1f || moveHoz < -0.1f) {
            player.AddForce(new Vector2(moveHoz * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        //Jump cooldown
        if (jumpTimer >= jumpCooldown) {
            canJump = true;
        }
        else {
            jumpTimer += Time.deltaTime;
            canJump = false;
        }
        //Jump  
        if (canJump && moveVert > 0.1f) {
            player.AddForce(new Vector2(0f, moveVert * jumpForce), ForceMode2D.Impulse);
            jumpTimer = 0.0f;
            grounded = false;
        }
        //Speed limit
        if (moveSpeed > speedLimit) {
            moveHoz = speedLimit;
        }

        if (grounded) {
            jumpTimer = jumpCooldown;
            moveSpeed = 3f;
        }
        else {
            moveSpeed = 1.2f;
        }
    }

    //Checks if game object is in contact with the ground, if so it is not jumping. (Using "Surface" tag)
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Surface") {
            grounded = true;
        }
    }

    //Check if game object is in contact with the ground, if not it is jumping.
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Surface") {
            grounded = false;
        }
    }
}
