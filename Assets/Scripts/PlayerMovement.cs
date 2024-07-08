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
        body.velocity=new Vector2(Input.GetAxis("Horizontal")*speed,body.velocity.y); //input.getaxis ->left key = -1 and right key =1
        // if(Input.GetKey(KeyCode.Space))
        //     body.velocity=new Vector2(body.velocity.x,speed);
    }
}
