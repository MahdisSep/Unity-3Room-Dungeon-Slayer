using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private float nextAttackTime; // how much time should spend between 2 attacks
   private Animator anim;
   private PlayerMovement playerMovement;
   private float coolDownTimer = math.INFINITY; // if we don't set it player can't attack at first of the game

   private void Awake()
   {
        anim=GetComponent<Animator>();
        playerMovement=GetComponent<PlayerMovement>();
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
    }
}
