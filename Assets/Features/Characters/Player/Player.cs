using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(HealthEvent))]
public class Player : MonoBehaviour
{
    public static Vector3 LookDirection {  get; private set; }
    public static Vector3 Direction { get; private set; }
    public static Vector3 Position { get; private set; }

    [SerializeField]
    private AnimationCurve ScreenshakeCurve;

    [SerializeField]
    private Transform camLock;

    [SerializeField] 
    private Animator anim;

    HealthEvent healthEvent;
    Health health;

    private void Awake()
    {
        healthEvent = GetComponent<HealthEvent>();
    }

    private void OnEnable()
    {
        healthEvent.OnDeath += PlayerDied;
        healthEvent.OnHit += Screenshake;
        healthEvent.OnHit += BloodyScreen;
    }

    private void OnDisable()
    {
        healthEvent.OnDeath -= PlayerDied;
        healthEvent.OnHit -= Screenshake;
        healthEvent.OnHit -= BloodyScreen;
    }

    private void FixedUpdate()
    {
        Direction = transform.forward;
        Position = transform.position; 
        LookDirection = camLock.forward;
    }

    private void PlayerDied()
    {
        GameEvents.Instance.PlayerDied.Invoke();
    }

    private void Screenshake()
    {
        GameEvents.Instance.Screenshake.Invoke(ScreenshakeCurve);
    }

    private void BloodyScreen()
    {
        anim.Play("bloody_screen");
    }
}
