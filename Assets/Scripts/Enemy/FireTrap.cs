using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay; //how much time traps needs to be active after the player steps on it.//for example if it is 2 , it means when player steps on it , it will be active after 2s.
    [SerializeField] private float activeTime; // how long the trap will be active after being activated.
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; //when the trap gets triggered
    private bool active; //when the trap is active and can hurt the player

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());//when we use IEnumerator we should startCoroutine.

            if (active)
                collision.GetComponent<Health>().TakeHurt(damage);
        }
    }
    private IEnumerator ActivateFiretrap() //beacuse we have to deal with delay.
    {
        //turn the sprite red to notify the player and trigger the trap
        triggered = true; //being sure that multiple coroutine doesn't start at the same time.
        spriteRend.color = Color.red; 

        //Wait for delay, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //turn the sprite back to normal
        active = true;
        anim.SetBool("activate", true);

//wait for some times
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activate", false);
    }
}