using UnityEngine;
using UnityEngine.InputSystem;

public class BasicInput : MonoBehaviour
{
    [SerializeField, Header("InputAction")]
    private InputActionAsset inp_base;


    [SerializeField, Header("MapName")]
    private string BaseMapName;

    [SerializeField, Header("InputNames")]
    private string pauseName;

    private InputAction pauseAction;
    public static bool Pause { get; private set; }


    private void Awake()
    {
        InputActionMap inputActionMap = inp_base.FindActionMap(BaseMapName);

        pauseAction = inputActionMap.FindAction(pauseName);
       
    }

    private void Update()
    {
        Pause = pauseAction.WasPressedThisFrame();
    }

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }
}
