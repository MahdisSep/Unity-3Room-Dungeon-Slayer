using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private float nextAttackTime; // how much time should spend between 2 attacks
   [SerializeField] private Transform firePoint; // the position which the ball will be fired
   [SerializeField] private GameObject[] fireballs; // 10 fireballs we've created.
   private Animator anim;
   private PlayerMovement playerMovement;
   private float coolDownTimer = Mathf.Infinity; // if we don't set it player can't attack at first of the game

   private void Awake()
   {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
   }
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButton(0) && coolDownTimer > nextAttackTime && playerMovement.canAttack())
        {
            Attack();
        }
        coolDownTimer += Time.deltaTime; // update every frame
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        coolDownTimer = 0;
        //object pooling -> everytime we shoot we should make new object and everytime it hits , it should destroy.


        // 1-> everytime we attack , we will take on of the fireballs and reset its position to the firepoint.
        fireballs[0].transform.position = firePoint.position;
        //2-> get the projectile component and see which the direction is ;
        fireballs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }
}
