using UnityEngine;

public class Enemy_Side2 : MonoBehaviour
{
    [SerializeField] private float movementDis;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingL;
    private float LEdge;
    private float REdge;
    
     private float horizontalInput;

    private void Awake()
    {
        LEdge = transform.position.x - movementDis;
        REdge = transform.position.x + movementDis;
    }

    private void Update()
    {
        if(movingL)
        {
            if(transform.position.x > LEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime , transform.position.y , transform.position.z);
                 transform.localScale = new Vector3(-5,5,5);
            }
            else
            {
                movingL = false;
            }
        }
        else
        {
            if(transform.position.x < REdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime , transform.position.y , transform.position.z);
                transform.localScale = new Vector3(5,5,5);

            }
            else
            {
                movingL = true;
            }
            
        }

        //horizontalInput = Input.GetAxis("Horizontal");

        // if(transform.position.x < REdge) //flip character to the right
        // {
        //     transform.localScale = new Vector3(5,5,5);
        // }
        // else if (horizontalInput < -0.01f) //flip character to the left
        // {
        //     transform.localScale = new Vector3(-5,5,5);
        // }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if(collision.tag == "Player") // if collision is between player and slime
        {
            collision.GetComponent<Health>().TakeHurt(damage);
        }
    }
}
