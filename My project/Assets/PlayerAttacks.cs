using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // Reference to the Animation component
    private Animation animationComponent;
    private PlayerMovements playerMovements; // Reference to PlayerMovements script

    void Start()
    {
        // Get the Animation component
        animationComponent = GetComponent<Animation>();
        
        // Get reference to PlayerMovements script
        playerMovements = GetComponent<PlayerMovements>();
    }

    void Update()
    {
        // Check for attack inputs Q and W, and ensure the idle animation is not playing
        if (playerMovements.CanAttack())
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                AttackAnimation("Attack_01");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                AttackAnimation("Attack_02");
            }
        }
    }

    void AttackAnimation(string animationName)
    {
        // Play the specified attack animation
        if (!animationComponent.IsPlaying(animationName))
        {
            animationComponent.CrossFade(animationName);
        }
    }
}
