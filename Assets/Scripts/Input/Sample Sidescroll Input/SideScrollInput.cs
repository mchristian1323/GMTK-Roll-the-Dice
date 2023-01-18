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
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""7f70b527-f390-48ea-bbcf-f3e6b2289b95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimUp"",
                    ""type"": ""Button"",
                    ""id"": ""1ca492ea-7c3b-4aab-b1b1-c5a10f283074"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimDown"",
                    ""type"": ""Button"",
                    ""id"": ""8a4bb969-a83e-4159-b1b5-49d221a3d0e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tongue"",
                    ""type"": ""Button"",
                    ""id"": ""e6fbf5b7-5fcd-49c9-841e-f74fc2831da3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpellSelectionUp"",
                    ""type"": ""Button"",
                    ""id"": ""94b90a97-96ea-4816-b2aa-557fada29bdc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpellSelectionDown"",
                    ""type"": ""Button"",
                    ""id"": ""193245a0-7835-4124-ba5b-fbd95a906f16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpellActivate"",
                    ""type"": ""Button"",
                    ""id"": ""54cd649a-dbf5-405c-8404-a6bf3edd342c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""One"",
                    ""type"": ""Button"",
                    ""id"": ""73a2af0b-0766-4aa1-8014-4321f7393c8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Two"",
                    ""type"": ""Button"",
                    ""id"": ""34bb5cd5-c970-4b9b-947a-0933ce8a5df0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Three"",
                    ""type"": ""Button"",
                    ""id"": ""0a4ddfb7-6268-4731-9c8b-448d7d4b56ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Four"",
                    ""type"": ""Button"",
                    ""id"": ""663f4303-1d38-481e-8a2b-3cb4bcdc1dcc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Five"",
                    ""type"": ""Button"",
                    ""id"": ""88ab2317-918e-401d-a65c-ba67c7e8cfa8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Six"",
                    ""type"": ""Button"",
                    ""id"": ""df0958db-cf8d-4ffe-9eeb-919d8d1b07bf"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""5e1d25a6-7db2-4fdf-a7b1-6273ec57ffbd"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db66ddd0-6508-4b11-aa77-a100ce6a8767"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""AimUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a497c26-8f18-4a66-a92a-c0fdf724302f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""AimDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb790e38-7a5e-4f25-b60a-b831c5513d56"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Tongue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92b61e17-1e46-4595-ba66-ece2ea06887d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""SpellSelectionUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e8549aa-9955-4fe4-bfc8-5e6847117543"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""SpellSelectionDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a78488b5-31c5-4e05-8ceb-ca49edb8945a"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""SpellActivate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cd91bba-e21b-457d-bde5-7127560b5baf"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""One"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff4a5539-d138-4f47-97e2-d75977933256"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Two"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be98c82b-2524-4307-81a6-b5c298f417ba"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Three"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef017fc1-c0f7-4099-a59b-6376625fd960"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Four"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c25be4c7-394e-4ed0-9d9c-07d643d4015d"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Five"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4584436c-2322-416e-85ff-4ae43b07426f"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Six"",
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
        m_NormalSideScroll_Shoot = m_NormalSideScroll.FindAction("Shoot", throwIfNotFound: true);
        m_NormalSideScroll_AimUp = m_NormalSideScroll.FindAction("AimUp", throwIfNotFound: true);
        m_NormalSideScroll_AimDown = m_NormalSideScroll.FindAction("AimDown", throwIfNotFound: true);
        m_NormalSideScroll_Tongue = m_NormalSideScroll.FindAction("Tongue", throwIfNotFound: true);
        m_NormalSideScroll_SpellSelectionUp = m_NormalSideScroll.FindAction("SpellSelectionUp", throwIfNotFound: true);
        m_NormalSideScroll_SpellSelectionDown = m_NormalSideScroll.FindAction("SpellSelectionDown", throwIfNotFound: true);
        m_NormalSideScroll_SpellActivate = m_NormalSideScroll.FindAction("SpellActivate", throwIfNotFound: true);
        m_NormalSideScroll_One = m_NormalSideScroll.FindAction("One", throwIfNotFound: true);
        m_NormalSideScroll_Two = m_NormalSideScroll.FindAction("Two", throwIfNotFound: true);
        m_NormalSideScroll_Three = m_NormalSideScroll.FindAction("Three", throwIfNotFound: true);
        m_NormalSideScroll_Four = m_NormalSideScroll.FindAction("Four", throwIfNotFound: true);
        m_NormalSideScroll_Five = m_NormalSideScroll.FindAction("Five", throwIfNotFound: true);
        m_NormalSideScroll_Six = m_NormalSideScroll.FindAction("Six", throwIfNotFound: true);
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
    private readonly InputAction m_NormalSideScroll_Shoot;
    private readonly InputAction m_NormalSideScroll_AimUp;
    private readonly InputAction m_NormalSideScroll_AimDown;
    private readonly InputAction m_NormalSideScroll_Tongue;
    private readonly InputAction m_NormalSideScroll_SpellSelectionUp;
    private readonly InputAction m_NormalSideScroll_SpellSelectionDown;
    private readonly InputAction m_NormalSideScroll_SpellActivate;
    private readonly InputAction m_NormalSideScroll_One;
    private readonly InputAction m_NormalSideScroll_Two;
    private readonly InputAction m_NormalSideScroll_Three;
    private readonly InputAction m_NormalSideScroll_Four;
    private readonly InputAction m_NormalSideScroll_Five;
    private readonly InputAction m_NormalSideScroll_Six;
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
        public InputAction @Shoot => m_Wrapper.m_NormalSideScroll_Shoot;
        public InputAction @AimUp => m_Wrapper.m_NormalSideScroll_AimUp;
        public InputAction @AimDown => m_Wrapper.m_NormalSideScroll_AimDown;
        public InputAction @Tongue => m_Wrapper.m_NormalSideScroll_Tongue;
        public InputAction @SpellSelectionUp => m_Wrapper.m_NormalSideScroll_SpellSelectionUp;
        public InputAction @SpellSelectionDown => m_Wrapper.m_NormalSideScroll_SpellSelectionDown;
        public InputAction @SpellActivate => m_Wrapper.m_NormalSideScroll_SpellActivate;
        public InputAction @One => m_Wrapper.m_NormalSideScroll_One;
        public InputAction @Two => m_Wrapper.m_NormalSideScroll_Two;
        public InputAction @Three => m_Wrapper.m_NormalSideScroll_Three;
        public InputAction @Four => m_Wrapper.m_NormalSideScroll_Four;
        public InputAction @Five => m_Wrapper.m_NormalSideScroll_Five;
        public InputAction @Six => m_Wrapper.m_NormalSideScroll_Six;
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
                @Shoot.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnShoot;
                @AimUp.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnAimUp;
                @AimUp.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnAimUp;
                @AimUp.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnAimUp;
                @AimDown.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnAimDown;
                @AimDown.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnAimDown;
                @AimDown.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnAimDown;
                @Tongue.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnTongue;
                @Tongue.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnTongue;
                @Tongue.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnTongue;
                @SpellSelectionUp.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSpellSelectionUp;
                @SpellSelectionUp.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSpellSelectionUp;
                @SpellSelectionUp.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSpellSelectionUp;
                @SpellSelectionDown.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSpellSelectionDown;
                @SpellSelectionDown.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSpellSelectionDown;
                @SpellSelectionDown.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSpellSelectionDown;
                @SpellActivate.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSpellActivate;
                @SpellActivate.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSpellActivate;
                @SpellActivate.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSpellActivate;
                @One.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnOne;
                @One.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnOne;
                @One.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnOne;
                @Two.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnTwo;
                @Two.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnTwo;
                @Two.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnTwo;
                @Three.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnThree;
                @Three.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnThree;
                @Three.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnThree;
                @Four.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnFour;
                @Four.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnFour;
                @Four.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnFour;
                @Five.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnFive;
                @Five.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnFive;
                @Five.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnFive;
                @Six.started -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSix;
                @Six.performed -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSix;
                @Six.canceled -= m_Wrapper.m_NormalSideScrollActionsCallbackInterface.OnSix;
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
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @AimUp.started += instance.OnAimUp;
                @AimUp.performed += instance.OnAimUp;
                @AimUp.canceled += instance.OnAimUp;
                @AimDown.started += instance.OnAimDown;
                @AimDown.performed += instance.OnAimDown;
                @AimDown.canceled += instance.OnAimDown;
                @Tongue.started += instance.OnTongue;
                @Tongue.performed += instance.OnTongue;
                @Tongue.canceled += instance.OnTongue;
                @SpellSelectionUp.started += instance.OnSpellSelectionUp;
                @SpellSelectionUp.performed += instance.OnSpellSelectionUp;
                @SpellSelectionUp.canceled += instance.OnSpellSelectionUp;
                @SpellSelectionDown.started += instance.OnSpellSelectionDown;
                @SpellSelectionDown.performed += instance.OnSpellSelectionDown;
                @SpellSelectionDown.canceled += instance.OnSpellSelectionDown;
                @SpellActivate.started += instance.OnSpellActivate;
                @SpellActivate.performed += instance.OnSpellActivate;
                @SpellActivate.canceled += instance.OnSpellActivate;
                @One.started += instance.OnOne;
                @One.performed += instance.OnOne;
                @One.canceled += instance.OnOne;
                @Two.started += instance.OnTwo;
                @Two.performed += instance.OnTwo;
                @Two.canceled += instance.OnTwo;
                @Three.started += instance.OnThree;
                @Three.performed += instance.OnThree;
                @Three.canceled += instance.OnThree;
                @Four.started += instance.OnFour;
                @Four.performed += instance.OnFour;
                @Four.canceled += instance.OnFour;
                @Five.started += instance.OnFive;
                @Five.performed += instance.OnFive;
                @Five.canceled += instance.OnFive;
                @Six.started += instance.OnSix;
                @Six.performed += instance.OnSix;
                @Six.canceled += instance.OnSix;
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
        void OnShoot(InputAction.CallbackContext context);
        void OnAimUp(InputAction.CallbackContext context);
        void OnAimDown(InputAction.CallbackContext context);
        void OnTongue(InputAction.CallbackContext context);
        void OnSpellSelectionUp(InputAction.CallbackContext context);
        void OnSpellSelectionDown(InputAction.CallbackContext context);
        void OnSpellActivate(InputAction.CallbackContext context);
        void OnOne(InputAction.CallbackContext context);
        void OnTwo(InputAction.CallbackContext context);
        void OnThree(InputAction.CallbackContext context);
        void OnFour(InputAction.CallbackContext context);
        void OnFive(InputAction.CallbackContext context);
        void OnSix(InputAction.CallbackContext context);
    }
}
