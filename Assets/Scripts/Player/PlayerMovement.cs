using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; // add speed to move player faster , make serializefield to edit directly from unity( varibale speed in player )
    [SerializeField] private float jPower;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;

    private Rigidbody2D body; //create refrence to body of char

     private Animator anim; //create refrence to animation of char

     private BoxCollider2D boxCollider;

     private float wallJump;

     private float horizontalInput;
    
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
        horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput > 0.01f) //flip character to the right
        {
            transform.localScale = new Vector3(5,5,5);
        }
        else if (horizontalInput < -0.01f) //flip character to the left
        {
            transform.localScale = new Vector3(-5,5,5);
        }
  
        anim.SetBool("run", horizontalInput != 0); // if it moves ->  bool run = true , if not -> bool run = false ;
        anim.SetBool("grounded",isGrounded()); // initial this bool with the boolean variable grounded in the code
    
    // wall logic
        if(wallJump > 0.2f )
        {
          
             body.velocity=new Vector2(horizontalInput*speed,body.velocity.y); //input.getaxis ->left key = -1 and right key =1

             if(onWall() && !isGrounded()) 
             {
                body.gravityScale = 0;
                body.velocity = Vector2.zero; // if player is on wall -> stuck and don't able to fall down
             }
             else
             {
                body.gravityScale = 6; // if char is not on wall then fall
             }

            if(Input.GetKey(KeyCode.Space)) // if the key is space and character is on the ground then jump
                jump();


        }
        else 
        {

            wallJump += Time.deltaTime; /// ??????
        }
    }

    private void jump()
    {
        if(isGrounded()){

         body.velocity=new Vector2(body.velocity.x,jPower); // jump with space key
         
         anim.SetTrigger("jump");
        }

        else if (onWall() && !isGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            }
            else
            {
                body.velocity= new Vector2(-Mathf.Sign(transform.localScale.x)*3,6);

            }
            wallJump = 0; // wait a bit before next jump

        }
        
    }

    private bool isGrounded(){ 
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);  //make virtual line(arrow to down from char feet) from a point origin to certain direction , if it intersects with an object with collider on it -> true , if not -> false
        return raycastHit.collider != null;                                  // we use box with width of player - > we can now know if player is actually on the ground or not
    }                                                   // 1 : origin , 2 : size , 3 : angle , 4: direction , 5 : position of virtual box(distance) , 6: layer mask (what object we want to detect)

    private bool onWall(){ 
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,new Vector2(transform.lossyScale.x,0),0.1f,wallLayer);
        return raycastHit.collider != null;                                 
    }  

    public bool canAttack()
    {
        return horizontalInput==0 && isGrounded() && !onWall(); // player can attack if 1 : not moving left or right , 2 : being on the ground , 3 : not being on the wall
    }     
}
