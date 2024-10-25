using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public float playerSpeed;
    public Vector2 jumpHegith;
    private bool isOnGround;
    public float positionRadidus;
    public LayerMask ground;
    public Transform playerPos;


    void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int k = i + 1; k < colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                anim.Play("Walk");
                rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
            }
            else
            {
                anim.Play("WalkBack");
                rb.AddForce(Vector2.left * playerSpeed * Time.deltaTime);
            }
        } else
        {
            anim.Play("Idle");
        }

        isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadidus, ground);
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jumping");
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime);
        }
    }
}
