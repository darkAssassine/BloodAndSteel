using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField, Header("InputAction")]
    private InputActionAsset playerActionAsset;


    [SerializeField, Header("MapName")]
    private string playerActionMapName;

    [SerializeField, Header("InputNames")]
    private string moveXname;

    [SerializeField]
    private string moveYname;

    [SerializeField]
    private string dashName;


    [SerializeField]
    private string attackName;

    [SerializeField]
    private string throwName;

    [SerializeField]
    private string interactName;

    [SerializeField]
    private string kickName;

    private InputAction moveXAction;
    private InputAction moveYAction;
    private InputAction dashAction;
    private InputAction attackAction;
    private InputAction throwWeaponAction;
    private InputAction interactAction;
    private InputAction kickAction;
    private InputAction mouseXAction;
    private InputAction mouseYAction;
    public float MoveX { get; private set; }
    public float MoveY { get; private set; }
    public bool Dash { get; private set; }
    public bool Attack { get; private set; }

    public bool Throw { get; private set; }

    public bool Interact { get; private set; }

    public bool Kick { get; private set; }
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }

    private void Awake()
    {
        InputActionMap inputActionMap = playerActionAsset.FindActionMap(playerActionMapName);

        moveXAction = inputActionMap.FindAction(moveXname);
        moveYAction = inputActionMap.FindAction(moveYname);
        dashAction = inputActionMap.FindAction(dashName);
        attackAction = inputActionMap.FindAction(attackName);
        throwWeaponAction = inputActionMap.FindAction(throwName);
        interactAction = inputActionMap.FindAction(interactName);
        kickAction = inputActionMap.FindAction("Kick");
        mouseXAction = inputActionMap.FindAction("Mouse X");
        mouseYAction = inputActionMap.FindAction("Mouse Y");
        moveXAction.performed += MoveXPerformed;
        moveXAction.canceled += MoveXCanceled;
        moveYAction.performed += MoveYPerformed;
        moveYAction.canceled += MoveYCanceled;
        mouseXAction.performed += MouseXPerformed;
        mouseXAction.canceled += MouseXCanceled;
        mouseYAction.performed += MouseYPerformed;
        mouseYAction.canceled += MouseYCanceled;

        //  attackAction.performed += AttackPerformed;
        // attackAction.canceled += AttackCanceled;
        dashAction.performed += DashPerformed;
        dashAction.canceled += DashCanceled;
        throwWeaponAction.performed += ThrowWeaponPerformed;
        throwWeaponAction.canceled += ThrowWeaponCanceled;
    }

    private void Update()
    {
        Interact = interactAction.WasPressedThisFrame();
        Attack = attackAction.WasPressedThisFrame();    
        Kick = kickAction.WasPressedThisFrame();
    }

    private void ThrowWeaponPerformed(InputAction.CallbackContext context)
    {
        Throw = true;
    }

    private void ThrowWeaponCanceled(InputAction.CallbackContext context)
    {
        Throw = false;
    }


    private void DashPerformed(InputAction.CallbackContext context)
    {
        Dash = true;
    }

    private void DashCanceled(InputAction.CallbackContext context)
    {
        Dash = false;
    }
    private void MoveXPerformed(InputAction.CallbackContext context)
    {
        MoveX = context.ReadValue<float>();
    }

    private void MoveXCanceled(InputAction.CallbackContext context)
    {
        MoveX = 0;
    }
    private void MoveYPerformed(InputAction.CallbackContext context)
    {
        MoveY = context.ReadValue<float>();
    }

    private void MoveYCanceled(InputAction.CallbackContext context)
    {
        MoveY = 0;
    }

    private void AttackPerformed(InputAction.CallbackContext context)
    {
        Attack = true;
    }

    private void AttackCanceled(InputAction.CallbackContext context)
    {
        Attack = false;
    }

    private void MouseXPerformed(InputAction.CallbackContext context)
    {
        MouseX = context.ReadValue<float>();
    }

    private void MouseXCanceled(InputAction.CallbackContext context)
    {
        MouseX = 0;
    }

    private void MouseYPerformed(InputAction.CallbackContext context)
    {
        MouseY = context.ReadValue<float>();
    }

    private void MouseYCanceled(InputAction.CallbackContext context)
    {
        MouseY = 0;
    }
    private void Start()
    {
        Enable();
        GameEvents.Instance.OnPause += Disable;
        GameEvents.Instance.OnResume += Enable;
    }

    private void OnDisable()
    {
        Disable();
    }

    private void Disable()
    {
        moveXAction.Disable();
        dashAction.Disable();
        attackAction.Disable();
        throwWeaponAction.Disable();
        moveYAction.Disable();
        interactAction.Disable();
        kickAction.Disable();
        mouseXAction.Disable();
        mouseYAction.Disable();
    }

    private void Enable()
    {
        moveXAction.Enable();
        dashAction.Enable();
        attackAction.Enable();
        throwWeaponAction.Enable();
        moveYAction.Enable();
        interactAction.Enable();
        kickAction.Enable();    
        mouseXAction.Enable();
        mouseYAction.Enable();
    }
}
