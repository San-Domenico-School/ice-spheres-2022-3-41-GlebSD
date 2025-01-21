using UnityEngine;

/*Power Interactor
 * 
 * What happens when Ai touches Ise sphere
 * Child of
 * 
 * Gleb
 * V1
 * 01/21/25
*/

public class PowerInteractor : MonoBehaviour
{
    [SerializeField] private float pushForce;
    [SerializeField] private Rigidbody iceRB;
    [SerializeField] private IceSphereController iceController;

    private void Start()
    {
        // Initialization logic here
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Logic for applying force to IceSphere
    }
}
