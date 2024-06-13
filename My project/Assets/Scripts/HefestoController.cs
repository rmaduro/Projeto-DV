using UnityEngine;

public class HefestoController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the enemy moves towards the character

    private GameObject player; // Reference to the player character
    private Animation animationComponent; // Reference to the Animation component

    private bool isMoving = false; // Flag to check if the enemy is moving

    void Start()
    {
        animationComponent = GetComponent<Animation>(); // Get the Animation component

        if (animationComponent == null)
        {
            Debug.LogWarning("Animation component is missing on HefestoController.");
        }
        else
        {
            // Set the Idle_02 animation to loop
            if (animationComponent["Idle_02"] != null)
            {
                animationComponent["Idle_02"].wrapMode = WrapMode.Loop;
                animationComponent.Play("Idle_02"); // Start playing the idle animation
            }
        }
    }

    // Public method to return the current position of the enemy
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
