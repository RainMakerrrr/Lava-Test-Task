// GENERATED AUTOMATICALLY FROM 'Assets/Input System/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""be30a437-9373-456e-9bb7-7f7e50b25be2"",
            ""actions"": [
                {
                    ""name"": ""PointerPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c4a67aef-fc49-4645-99a4-32321287d784"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PointerClicked"",
                    ""type"": ""Button"",
                    ""id"": ""66ea232e-a79b-4417-9e7c-418e6d73cfa7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c00fc4e-99e3-4293-a97d-776fb70bf712"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db7479e2-8490-43b6-a602-a6d4dd5d60ac"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f85c7e46-f11f-4dcc-9084-414b5e1dc474"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerClicked"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0b3bb05-c2d6-4057-91e0-28c473fb575f"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerClicked"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shooting"",
            ""id"": ""eca2edab-12f2-4c31-be7d-d96be000e030"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c582984b-83ff-42d0-ae31-25f1534287e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""684c6902-88c9-4c1c-9722-13ff6e4a3ba4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d856e95f-267a-4d9b-8b3a-f68ee1090336"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_PointerPosition = m_Movement.FindAction("PointerPosition", throwIfNotFound: true);
        m_Movement_PointerClicked = m_Movement.FindAction("PointerClicked", throwIfNotFound: true);
        // Shooting
        m_Shooting = asset.FindActionMap("Shooting", throwIfNotFound: true);
        m_Shooting_Shoot = m_Shooting.FindAction("Shoot", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_PointerPosition;
    private readonly InputAction m_Movement_PointerClicked;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PointerPosition => m_Wrapper.m_Movement_PointerPosition;
        public InputAction @PointerClicked => m_Wrapper.m_Movement_PointerClicked;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @PointerPosition.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnPointerPosition;
                @PointerPosition.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnPointerPosition;
                @PointerPosition.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnPointerPosition;
                @PointerClicked.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnPointerClicked;
                @PointerClicked.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnPointerClicked;
                @PointerClicked.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnPointerClicked;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PointerPosition.started += instance.OnPointerPosition;
                @PointerPosition.performed += instance.OnPointerPosition;
                @PointerPosition.canceled += instance.OnPointerPosition;
                @PointerClicked.started += instance.OnPointerClicked;
                @PointerClicked.performed += instance.OnPointerClicked;
                @PointerClicked.canceled += instance.OnPointerClicked;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Shooting
    private readonly InputActionMap m_Shooting;
    private IShootingActions m_ShootingActionsCallbackInterface;
    private readonly InputAction m_Shooting_Shoot;
    public struct ShootingActions
    {
        private @PlayerControls m_Wrapper;
        public ShootingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Shooting_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Shooting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootingActions set) { return set.Get(); }
        public void SetCallbacks(IShootingActions instance)
        {
            if (m_Wrapper.m_ShootingActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_ShootingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public ShootingActions @Shooting => new ShootingActions(this);
    public interface IMovementActions
    {
        void OnPointerPosition(InputAction.CallbackContext context);
        void OnPointerClicked(InputAction.CallbackContext context);
    }
    public interface IShootingActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
