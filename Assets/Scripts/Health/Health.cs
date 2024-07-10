
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float initialHealth;
    public float currentHealth {get ; private set;} //only can change in this script but we can get it in another scripts

    private void Awake()
    {
        currentHealth = initialHealth ;
    }

    public void TakeHurt(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage , 0, initialHealth);

        if (currentHealth > 0)
        {
            //player hurt
        }
        else
        {
            //player dead
        }
    }
}
