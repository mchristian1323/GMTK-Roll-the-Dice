// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/Sample Sidescroll Input/SideScrollInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SideScrollInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SideScrollInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SideScrollInput"",
    ""maps"": [
        {
            ""name"": ""Normal Side Scroll"",
            ""id"": ""81c6302c-98d2-4c50-beb1-d760208ac826"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""65d262e4-5573-428b-920e-85175912099e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c948b234-7406-4ba8-9155-443827404b5c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDetect"",
                    ""type"": ""Button"",
                    ""id"": ""d56a88ca-5479-49ef-81bb-17e921f1fa52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DiceThrow"",
                    ""type"": ""Button"",
                    ""id"": ""2227265b-bbda-44c9-8b74-380dda13370a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charge Jump"",
                    ""type"": ""Button"",
                    ""id"": ""21b6d0eb-0bd6-445c-99ee-25a404659f8a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""8264e75b-31ad-41e0-87b4-bfb0440d25f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b0006b2d-3a5c-487d-a51e-dc2040bbcdf2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3857b335-e875-4a45-8192-e3ff33e216b7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""168b02ef-452f-41ff-959d-d3f3dd4109c1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""38c993a8-ad7d-46e8-97c6-fdcc69498cc9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e9f488af-8f69-48ff-a92d-8819280da028"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a7e40b1c-0f97-461b-8920-924cd708f1e9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e682f0f8-ec3f-478d-898d-a3ee0bf67e6b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""388cfccc-8db5-43c2-95de-09489d081d03"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MoveDetect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be29773a-c1be-40a3-b8cc-45b61759c78c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MoveDetect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeea8991-55d8-4895-911e-1d5fbff1b436"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""DiceThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73367116-3d1a-47b3-a10a-90c54bf73df0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Charge Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""844d2872-18a5-475c-8ad6-68968932b9ba"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and mouse"",
            ""bindingGroup"": ""Keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Normal Side Scroll
        m_NormalSideScroll = asset.FindActionMap("Normal Side Scroll", throwIfNotFound: true);
        m_NormalSideScroll_Jump = m_NormalSideScroll.FindAction("Jump", throwIfNotFound: true);
        m_NormalSideScroll_Move = m_NormalSideScroll.FindAction("Move", throwIfNotFound: true);
        m_NormalSideScroll_MoveDetect = m_NormalSideScroll.FindAction("MoveDetect", throwIfNotFound: true);
        m_NormalSideScroll_DiceThrow = m_NormalSideScroll.FindAction("DiceThrow", throwIfNotFound: true);
        m_NormalSideScroll_ChargeJump = m_NormalSideScroll.FindAction("Charge Jump", throwIfNotFound: true);
        m_NormalSideScroll_Pause = m_NormalSideScroll.FindAction("Pause", throwIfNotFound: true);
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

    // Normal Side Scroll
    private readonly InputActionMap m_NormalSideScroll;
    private INormalSideScrollActions m_NormalSideScrollActionsCallbackInterface;
    private readonly InputAction m_NormalSideScroll_Jump;
    private readonly InputAction m_NormalSideScroll_Move;
    private readonly InputAction m_NormalSideScroll_MoveDetect;
    private readonly InputAction m_NormalSideScroll_DiceThrow;
    private readonly InputAction m_NormalSideScroll_ChargeJump;
    private readonly InputAction m_NormalSideScroll_Pause;
    public struct NormalSideScrollActions
    {
        private @SideScrollInput m_Wrapper;
        public NormalSideScrollActions(@SideScrollInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_NormalSideScroll_Jump;
        public InputAction @Move => m_Wrapper.m_NormalSideScroll_Move;
        public InputAction @MoveDetect => m_Wrapper.m_NormalSideScroll_MoveDetect;
        public InputAction @DiceThrow => m_Wrapper.m_NormalSideScroll_DiceThrow;
        public InputAction @ChargeJump => m_Wrapper.m_NormalSideScroll_ChargeJump;
        public InputAction @Pause => m_Wrapper.m_NormalSideScroll_Pause;
        public InputActionMap Get() { return m_Wrapper.m_NormalSideScroll; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NormalSideScrollActions set) { return set.Get(); }
        public void SetCallbacks(INormalSideScrollActions instance)
        {
            if (m_Wrapper.m_NormalSideScrollActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnMove;
                @MoveDetect.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnMoveDetect;
                @MoveDetect.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnMoveDetect;
                @MoveDetect.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnMoveDetect;
                @DiceThrow.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnDiceThrow;
                @DiceThrow.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnDiceThrow;
                @DiceThrow.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnDiceThrow;
                @ChargeJump.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnChargeJump;
                @ChargeJump.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnChargeJump;
                @ChargeJump.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnChargeJump;
                @Pause.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_NormalSideScrollActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MoveDetect.started += instance.OnMoveDetect;
                @MoveDetect.performed += instance.OnMoveDetect;
                @MoveDetect.canceled += instance.OnMoveDetect;
                @DiceThrow.started += instance.OnDiceThrow;
                @DiceThrow.performed += instance.OnDiceThrow;
                @DiceThrow.canceled += instance.OnDiceThrow;
                @ChargeJump.started += instance.OnChargeJump;
                @ChargeJump.performed += instance.OnChargeJump;
                @ChargeJump.canceled += instance.OnChargeJump;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public NormalSideScrollActions @NormalSideScroll => new NormalSideScrollActions(this);
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get
        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface INormalSideScrollActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnMoveDetect(InputAction.CallbackContext context);
        void OnDiceThrow(InputAction.CallbackContext context);
        void OnChargeJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
