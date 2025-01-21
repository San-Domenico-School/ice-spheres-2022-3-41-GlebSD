using System.Collections;
using UnityEngine;

/*  Player Controller
 *   
 * GameManager will be a component of the GameManager.
 * Gleb 
 * V1
 */

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Fields")]
    public Vector3 playerScale;
    public float playerMass;
    public float playerDrag;
    public float playerMoveForce;
    public float playerRepelForce;
    public float playerBounce;

    [Header("Some Fields")]
    public GameObject[] waypoints;

    [Header("Debug Fields")]
    public bool debugSpawnWaves;
    public bool debugSpawnPortal;
    public bool debugSpawnPowerUp;
    public bool debugPowerUpRepel;

    public bool switchLevels { get; set; }
    public bool gameOver { get; set; }
    public bool playerHasPowerUp { get; set; }

    void Awake()
    {
        // Awake is called before any Start methods are called
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
        {
            Instance = this;
        }
        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one GameManager object in a scene at a time.
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void Start() { }
    public void Update() { }
    public void EnablePlayer() { }
    public void SwitchLevels() { }
}
