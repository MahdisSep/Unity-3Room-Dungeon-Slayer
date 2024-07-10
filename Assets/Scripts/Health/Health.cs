
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float initialHealth;
    private float currentHealth;

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
