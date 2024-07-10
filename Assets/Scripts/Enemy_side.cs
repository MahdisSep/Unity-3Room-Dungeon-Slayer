
using UnityEngine;

public class Enemy_side : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") // if collision is between player and slime
        {
            collision.GetComponent<Health>().TakeHurt(damage);
        }
    }
}
