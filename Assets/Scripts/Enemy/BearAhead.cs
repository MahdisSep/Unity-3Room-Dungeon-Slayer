using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAhead : EnemyDamage
{
    [Header("BearAhead attributes")]
   [SerializeField] private float speed;
   [SerializeField] private float range; // how far can bear see ?
   private Vector3 destination;
   private bool attacking; // when bear is attacking
   [SerializeField]private float checkDelay; // the delay between 2 attacks
   private float checkTime ; // when can bear attack ? 
   private Vector3[] directions = new Vector3[2]; // check four directions
   [SerializeField] private LayerMask playerLayer;


    private void OnEnable()
    {
        Stop();
    }
    // Update is called once per frame
    void Update()
    {
        //move bear to destination only if attacking
        if(attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else 
        {
            checkTime += Time.deltaTime;
            if(checkTime > checkDelay)
            {
                checkForPlayer(); // if bear can see the player.
            }

        }
        
    }

    private void checkForPlayer()
    {
        CalculateDirections();
        
        //check 2 directions

        for(int i = 0 ; i < directions.Length ; i++ )
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer); //to detect the player
            
            if(hit.collider != null && !attacking) // if detect player and it is not in attacking mode.
            {
                attacking = true;
                destination = directions[i];
                if (i == 0)
                {
                    transform.localScale = new Vector3(5,5,5);
                }
                else
                {
                    transform.localScale = new Vector3(-5,5,5);
                }
                checkTime = 0;
            }
        }
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range;
        directions[1] = -transform.right * range ;
    }

     private void Stop()
    {
        destination = transform.position; //Set destination as current position so it doesn't move
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Stop(); 
        //Stop bear once he hits something
    }
}
