using UnityEngine;
/* Controls ice SPhere
 * 
 * Evrething that happens with Ice Sphere
 * Child of
 * 
 * Gleb
 * V1
 * 01/21/25
*/

public class IceSphereController : MonoBehaviour
{
    [SerializeField] private float startDelay;
    [SerializeField] private float reductionEachRepeat;
    [SerializeField] private float minimumVolume;
    [SerializeField] private Rigidbody iceRB;
    [SerializeField] private ParticleSystem iceVFX;

    private void Start()
    {
        // Initialization logic here
    }

    public void RandomizeSizeAndMass()
    {
        // Logic for randomizing size and mass
    }

    public void Dissolution()
    {
        // Logic for gradual reduction
    }

    public void Melt()
    {
        // Logic for melting
    }
}
