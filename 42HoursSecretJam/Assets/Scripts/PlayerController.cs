using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;

    private bool jumpPressed = false;
    private bool grounded = true;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        grounded = GroundCheck();
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetAxis("Vertical") > 0 && grounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            grounded = false;
        }
        
    }

    bool GroundCheck()
    {


        Vector2 pos = new Vector2(transform.position.x, transform.position.y - GetComponent<BoxCollider2D>().bounds.extents.y - 0.1f);
        Vector2 size = new Vector2(GetComponent<BoxCollider2D>().bounds.size.x, 0.1f);
        float angle = transform.rotation.eulerAngles.z;
        var hit = Physics2D.BoxCast(pos, size, angle, new Vector2(0, 0));


        if (!jumpPressed  && hit.collider != null && hit.collider.name != "Cube")
        {
            jumpPressed = true;
            this.InvokeDelegate(() => { jumpPressed = false; }, 0.01f);
            return true;
        }
        else return false;

    }
}
