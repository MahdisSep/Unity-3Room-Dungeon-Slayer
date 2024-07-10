
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float initialHealth;
    public float currentHealth {get ; private set;} //only can change in this script but we can get it in another scripts
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = initialHealth ;
        anim = GetComponent<Animator>();
    }

    public void TakeHurt(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage , 0, initialHealth);

        if (currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                 //player dead
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false; //player can not move if it is dead.
            dead = true;
            }
        }   
    }

    public void addHealth(float _heart)
    {
        currentHealth = Mathf.Clamp(currentHealth + _heart , 0, initialHealth);

    }

    // private void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.E))
    //     {
    //         TakeHurt(1); // everytime we tap E red heart gonna disapeared -> just for testing
    //     }
    // }
}
