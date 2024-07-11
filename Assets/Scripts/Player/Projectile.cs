using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float lifetime;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private float direction; //which direction the fireball will fly

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(hit) return;
        float movementSpeed = speed * Time.deltaTime*direction;
        transform.Translate(movementSpeed,0,0); // just x asix changed ???
        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision) //check if fireball hit any objects
    {
        hit = true;
        boxCollider.enabled = false; ///???
        anim.SetTrigger("explode");

        if (collision.tag == "Enemy")
            collision.GetComponent<Health>().TakeHurt(1);
    }

    public void SetDirection(float _direction) // call this method everytime we shoot for choosing the direction left or right
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false ;
        boxCollider.enabled = true;

// for changing the direction of fireball(not nessecery for us)

        float localScaleX = transform.localScale.x;
        if (Math.Sign(localScaleX) != _direction)
        {
            localScaleX = - localScaleX;
        }
        transform.localScale = new Vector3(localScaleX,transform.localScale.y,transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false); // deactivate the fireball after explosion animation finished.
    }
}
