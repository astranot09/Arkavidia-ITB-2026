using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currHealth;

    private void Start()
    {
        currHealth = maxHealth;
    }

    public void getDamage(float damage)
    {
        currHealth -= damage;
        if(currHealth <= 0)
        {
            //teleport ke waypoin
        }
    }

}
