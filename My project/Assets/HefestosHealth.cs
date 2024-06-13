using System.Collections;
using UnityEngine;

public class HefestosHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animation animationComponent;

    void Start()
    {
        currentHealth = maxHealth;
        animationComponent = GetComponent<Animation>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy Health: " + currentHealth);
        animationComponent.CrossFade("getHit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Hefestos has been defeated!");
        animationComponent.CrossFade("die");
    }
}
