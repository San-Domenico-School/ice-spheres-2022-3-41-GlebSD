using UnityEngine;

/*  Player Controller
 *   
 * the FocalPointRotator will be a component of the FocalPoint
 * Gleb 
 * V1
 */


public class FocalPointRotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5;

    private PlayerInputActions inputActions;
    private float moveDirection;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Movement.performed += ctx => CameraRotate(ctx.ReadValue<Vector2>());
        inputActions.Player.Movement.canceled += ctx => moveDirection = 0f;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up,  moveDirection * rotationSpeed * Time.deltaTime);
        Debug.Log("Rotate in FPR is Activated"+ moveDirection  + rotationSpeed);
    }

    public void CameraRotate(Vector2 input)
    {
        moveDirection = input.x;
        Debug.Log($"Move Direction Updated: {moveDirection}");
    }
}
