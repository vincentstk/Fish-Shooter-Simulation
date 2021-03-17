// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e446382e-5622-453e-b460-02bc41b971b1"",
            ""actions"": [
                {
                    ""name"": ""Choose Direction"",
                    ""type"": ""Button"",
                    ""id"": ""16e40d9e-4c75-4ad4-b0fe-c7147af58585"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""934ba1c9-1020-4f54-bf37-d9a510667189"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC Input Filter"",
                    ""action"": ""Choose Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12e78851-7b56-42b8-a936-aae266aec3cf"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile Input Filter"",
                    ""action"": ""Choose Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC Input Filter"",
            ""bindingGroup"": ""PC Input Filter"",
            ""devices"": []
        },
        {
            ""name"": ""Mobile Input Filter"",
            ""bindingGroup"": ""Mobile Input Filter"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_ChooseDirection = m_Player.FindAction("Choose Direction", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_ChooseDirection;
    public struct PlayerActions
    {
        private @InputManager m_Wrapper;
        public PlayerActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChooseDirection => m_Wrapper.m_Player_ChooseDirection;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @ChooseDirection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChooseDirection;
                @ChooseDirection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChooseDirection;
                @ChooseDirection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChooseDirection;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ChooseDirection.started += instance.OnChooseDirection;
                @ChooseDirection.performed += instance.OnChooseDirection;
                @ChooseDirection.canceled += instance.OnChooseDirection;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PCInputFilterSchemeIndex = -1;
    public InputControlScheme PCInputFilterScheme
    {
        get
        {
            if (m_PCInputFilterSchemeIndex == -1) m_PCInputFilterSchemeIndex = asset.FindControlSchemeIndex("PC Input Filter");
            return asset.controlSchemes[m_PCInputFilterSchemeIndex];
        }
    }
    private int m_MobileInputFilterSchemeIndex = -1;
    public InputControlScheme MobileInputFilterScheme
    {
        get
        {
            if (m_MobileInputFilterSchemeIndex == -1) m_MobileInputFilterSchemeIndex = asset.FindControlSchemeIndex("Mobile Input Filter");
            return asset.controlSchemes[m_MobileInputFilterSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnChooseDirection(InputAction.CallbackContext context);
    }
}
