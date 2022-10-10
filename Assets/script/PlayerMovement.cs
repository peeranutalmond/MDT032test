using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("SFX")]
    [SerializeField] private AudioClip JumpSound;
    private void Rigidbody()
    {
        Rigid();
    }
    private void Update()
    {
        jumpcooldown();
         jumpping();
    }
    private bool isGrounded()
    {
        return Onground();
    }
    private bool onWall()
    {
        return Onwalljump();
    }
    //private long code
    private bool Onwalljump()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    private bool Onground()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool groundandwall()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
     private void Rigid()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
   private void jumpcooldown()
   {horizontalInput = Input.GetAxis("Horizontal");
        //Flip player when moving left-right
        
	if (horizontalInput > 0.01f)
	            transform.localScale = Vector3.one;
	        else if (horizontalInput < -0.01f)
	            transform.localScale = new Vector3(-1, 1, 1);

        
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
                jumpping();
        }
        else
            wallJumpCooldown += Time.deltaTime;}

        private void jumpping()
        {if (isGrounded())
        {
            SoundManager.instance.PlaySound(JumpSound);
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }}
}