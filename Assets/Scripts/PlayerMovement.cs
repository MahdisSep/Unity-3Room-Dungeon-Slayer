using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; // add speed to move player faster , make serializefield to edit directly from unity( varibale speed in player )
    [SerializeField] LayerMask groundLayer;

    private Rigidbody2D body; //create refrence to body of char

     private Animator anim; //create refrence to animation of char

     private BoxCollider2D boxCollider;
    
    //everytime the scripts loaded , get and store the component in body variable
    private void Awake()
    {
        body=GetComponent<Rigidbody2D>();
        anim =GetComponent<Animator>();
        boxCollider=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity=new Vector2(horizontalInput*speed,body.velocity.y); //input.getaxis ->left key = -1 and right key =1

        if(horizontalInput > 0.01f) //flip character to the right
        {
            transform.localScale = new Vector3(5,5,5);
        }
        else if (horizontalInput < -0.01f) //flip character to the left
        {
            transform.localScale = new Vector3(-5,5,5);
        }

        if(Input.GetKey(KeyCode.Space) && isGrounded()) // if the key is space and character is on the ground then jump
            jump();
           
        anim.SetBool("run", horizontalInput != 0); // if it moves ->  bool run = true , if not -> bool run = false ;
        anim.SetBool("grounded",isGrounded()); // initial this bool with the boolean variable grounded in the code
    
    }

    private void jump()
    {
         body.velocity=new Vector2(body.velocity.x,speed); // jump with space key
         
         anim.SetTrigger("jump");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            
    }

    private bool isGrounded(){ 
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);  //make virtual line(arrow to down from char feet) from a point origin to certain direction , if it intersects with an object with collider on it -> true , if not -> false
        return raycastHit.collider != null;                                  // we use box with width of player - > we can now know if player is actually on the ground or not
    }                                                   // 1 : origin , 2 : size , 3 : angle , 4: direction , 5 : position of virtual box(distance) , 6: layer mask

    
}
