using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hiraishin.Utilities;
using Pixeye.Unity;
using Zenject;
using UnityEngine.InputSystem;

public class Player : BaseSingleton<Player>
{
    #region Systems
    [Inject] readonly ShootSystem.Factory ShootSystemFactory;
    private InputManager _InputSystem;
    private ShootSystem _ShootSystem;
    //[Inject] MainPooler test;
    #endregion

    #region Components
    [Foldout("Components", true)]
    [SerializeField]
    private ShootComponent shootComp;
    #endregion

    private Camera cam;

    protected override void OnAwake()
    {
        base.OnAwake();
    }
    // Start is called before the first frame update
    void Start()
    {
        _ShootSystem = ShootSystemFactory.Create(this);
        _InputSystem = new InputManager();
        _InputSystem.Player.ChooseDirection.performed += RotateGun;
        _InputSystem.Enable();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.GetGold > 0)
        {
            _ShootSystem.Tick(ref shootComp);
        }
    }
    private void RotateGun(InputAction.CallbackContext context)
    {
        Vector2 PointerPos = Pointer.current.position.ReadValue();
        Ray ray = cam.ScreenPointToRay(PointerPos);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            transform.rotation = Quaternion.LookRotation(hit.point - transform.position);
        }
    }
}
