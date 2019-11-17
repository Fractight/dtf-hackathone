using UnityEngine;
using System.Collections;

public class PlayerMoveController : MonoBehaviour {
    [SerializeField]
    private float jumpVelocity;                //Floating point variable to store the player's movement speed.
    [SerializeField]
    private float horizontalSpeed;
    private BoxCollider2D bc2d;
    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    
    [SerializeField]
    private LayerMask platformsLayerMask;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        bc2d = GetComponent<BoxCollider2D> ();
    }

    void Update()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        Debug.Log(move_horizontal);

        rb2d.velocity = new Vector2 (move_horizontal * horizontalSpeed, rb2d.velocity.y);

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            rb2d.velocity += Vector2.up * jumpVelocity;
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycasthit2d = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycasthit2d.collider != null;
    }
}