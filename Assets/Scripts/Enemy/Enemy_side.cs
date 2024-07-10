
using UnityEngine;

public class Enemy_side : MonoBehaviour
{
    [SerializeField] private float movementDis;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingL;
    private float LEdge;
    private float REdge;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if(collision.tag == "Player") // if collision is between player and slime
        {
            collision.GetComponent<Health>().TakeHurt(damage);
        }
    }
}
