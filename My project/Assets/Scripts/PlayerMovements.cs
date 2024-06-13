using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Public variables
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float turnSpeed = 10f;
    public float stoppingDistance = 0.1f;
    public Transform faceTarget;

    // Private variables
    private CharacterController controller;
    private Animation animationComponent;
    private Vector3 targetPosition;
    private bool isRunning;
    private bool isMoving = false;

    // Reference to the enemy object
    private GameObject enemyObject;
    private HefestoController enemyController; // Adjust based on your actual setup

    // Attack availability
    private bool canAttack = false;
    private float attackRange = 14f; // Adjust as needed

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animationComponent = GetComponent<Animation>();

        // Assuming you find the enemy object and get its HefestoController component
        enemyObject = GameObject.FindGameObjectWithTag("Enemy"); // Adjust with your enemy tag or reference
        if (enemyObject != null)
        {
            enemyController = enemyObject.GetComponent<HefestoController>(); // Adjust based on your actual setup
        }
        else
        {
            Debug.LogError("Enemy object not found!");
        }

        FindObjectOfType<Platform>().OnClick.AddListener(MoveToTarget);
    }

    private void OnDisable()
    {
        FindObjectOfType<Platform>().OnClick.RemoveListener(MoveToTarget);
    }

    public void MoveToTarget(Vector3 target)
    {
        targetPosition = target;
        isMoving = true;
        PlayMovementAnimation();
    }

    void Update()
    {
        if (isMoving)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            isRunning = Input.GetKey(KeyCode.LeftShift);
            float speed = isRunning ? runSpeed : walkSpeed;

            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
            {
                controller.Move(moveDirection * speed * Time.deltaTime);
                PlayMovementAnimation();

                // Calculate distance to the enemy and check attack availability
                if (enemyController != null)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemyController.GetPosition());
                    Debug.Log("Distance to enemy: " + distanceToEnemy);

                    // Check if attack is available
                    if (distanceToEnemy < attackRange)
                    {
                        canAttack = true;
                    }
                    else
                    {
                        canAttack = false;
                    }
                }
            }
            else
            {
                isMoving = false;
                PlayIdleAnimation();
            }
        }
        else if (faceTarget != null)
        {
            Vector3 directionToFace = (faceTarget.position - transform.position).normalized;
            if (directionToFace != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            }
        }

        // Example: Pressing space to attack
        if (canAttack && Input.GetKeyDown(KeyCode.Space))
        {
            AttackEnemy(); // Implement your attack logic here
        }
    }

    private void PlayMovementAnimation()
    {
        if (isRunning)
        {
            if (!animationComponent.IsPlaying("Run"))
            {
                animationComponent.CrossFade("Run");
            }
        }
        else
        {
            if (!animationComponent.IsPlaying("Walk"))
            {
                animationComponent.CrossFade("Walk");
            }
        }
    }

    private void PlayIdleAnimation()
    {
        if (!animationComponent.IsPlaying("Idle_01"))
        {
            animationComponent.CrossFade("Idle_01");
        }
    }

    public bool CanAttack()
    {
        return canAttack;
    }

    void AttackEnemy()
    {
        // Example attack logic
        Debug.Log("Attacking enemy!");
        // Implement your attack behavior here
    }
}
