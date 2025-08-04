using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveHoz;
    public float moveSpeed;
    private Rigidbody2D player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        player = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 1f;
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
    }

    private void FixedUpdate() {
        if (moveHoz > 0.1f || moveHoz < -0.1f) {
            player.AddForce(new Vector2(moveHoz * moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }
}
