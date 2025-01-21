using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private SphereCollider playerCollider;
    private Light powerUpIndicator;
    private PlayerInputActions inputActions;
    private Transform localPoint;

    private float moveForceMagnitude;
    private float moveDirection;
    private bool hasPowerUp;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
        powerUpIndicator = GetComponentInChildren<Light>();
        inputActions = new PlayerInputActions();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerRB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
        powerUpIndicator = GetComponentInChildren<Light>();

        playerCollider.material.bounciness = 0.4f;
        powerUpIndicator.intensity = 0;
       
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Movement.performed += ctx => SetMoveDirection(ctx.ReadValue<Vector2>());
        inputActions.Player.Movement.canceled += ctx => moveDirection = 0f;
        Debug.Log("rotate");
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetMoveDirection(Vector2 value)
    {
        moveDirection = value.y;
    }

    private void Move()
    {
        if (localPoint != null)
        {
            Vector3 force = localPoint.forward.normalized * moveDirection * moveForceMagnitude;
            playerRB.AddForce(force);
        }
    }

    public void AssignLevelValues()
    {
        transform.localScale = GameManager.Instance.playerScale;
        playerRB.mass = GameManager.Instance.playerMass;
        playerRB.drag = GameManager.Instance.playerDrag;
        moveForceMagnitude = GameManager.Instance.playerMoveForce;
        localPoint = GameObject.Find("Focal Point").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Startup"))
        {
            collision.gameObject.tag = "Ground";
            playerCollider.material.bounciness = GameManager.Instance.playerBounce;
            AssignLevelValues();
        }
    }

    private void OnTriggerEnter(Collider other) { }

    private void OnTriggerExit(Collider other) { }

    public IEnumerator PowerUpCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
    }
}
