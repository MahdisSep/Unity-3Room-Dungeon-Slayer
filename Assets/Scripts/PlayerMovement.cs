using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; // add speed to move player faster , make serializefield to edit directly from unity( varibale speed in player )
    private Rigidbody2D body; //create refrence to it
    
    //everytime the scripts loaded , get and store the component in body variable
    private void Awake()
    {
        body=GetComponent<Rigidbody2D>();
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

        if(Input.GetKey(KeyCode.Space))
            body.velocity=new Vector2(body.velocity.x,speed); // jump with space key
    }
}
