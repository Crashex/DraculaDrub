// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace SPCombat
{
    public class @PlayerControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Combat"",
            ""id"": ""8e7a1d09-da02-4490-a594-dc799836cdab"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""f545ec95-11cc-4990-941e-2c22ac549dac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e5493ef9-9012-49fd-84a0-51cccdb9e09a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""39e77bdc-63a2-4b9d-9994-2b48419e8dbf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""661891ef-397c-4f7e-8150-f100abe732b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2d25e8bc-3299-4baf-b23f-cb109da943fc"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81621e04-5008-4c08-b0d4-d171ccd95b9c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a045e88d-6fa9-4abe-a744-8ba80ed7b003"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d1465c3d-167d-4262-bb4f-fee263b882fb"",
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
                    ""id"": ""b487f4f2-2ebc-44e3-8ba2-0d749d1261c2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ea624a93-d8f2-45be-b674-1b93077162bd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5cfc78f0-4db4-4f6b-b3aa-a2bc0054e5ff"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e20531c9-aa08-4f65-b225-0639cead0bcc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e0020e8e-3ddf-45b3-899e-2ba4794fcd43"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""751d37fc-6199-45a5-8a6c-c5b04b41211d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Cutscene"",
            ""id"": ""5011835c-278e-4c3b-b63a-cb5460ce071c"",
            ""actions"": [
                {
                    ""name"": ""Advance"",
                    ""type"": ""Value"",
                    ""id"": ""dd802b5e-1803-4353-bff4-9fddfcc4e673"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackTrack"",
                    ""type"": ""Value"",
                    ""id"": ""93d3f067-c1f4-49ae-92ea-6dc72a9be583"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skip"",
                    ""type"": ""Button"",
                    ""id"": ""223adf74-c841-4d03-bb72-e20b2f835fc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""84a085db-82c3-4cdf-a011-99d720825cd5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Advance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff540276-9893-4be0-b9a0-dfbdc6c47ecd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackTrack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ba0470a-8e33-4b43-8df0-a573b839c806"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Combat
            m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
            m_Combat_Attack = m_Combat.FindAction("Attack", throwIfNotFound: true);
            m_Combat_Move = m_Combat.FindAction("Move", throwIfNotFound: true);
            m_Combat_Jump = m_Combat.FindAction("Jump", throwIfNotFound: true);
            m_Combat_Dash = m_Combat.FindAction("Dash", throwIfNotFound: true);
            // Cutscene
            m_Cutscene = asset.FindActionMap("Cutscene", throwIfNotFound: true);
            m_Cutscene_Advance = m_Cutscene.FindAction("Advance", throwIfNotFound: true);
            m_Cutscene_BackTrack = m_Cutscene.FindAction("BackTrack", throwIfNotFound: true);
            m_Cutscene_Skip = m_Cutscene.FindAction("Skip", throwIfNotFound: true);
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

        // Combat
        private readonly InputActionMap m_Combat;
        private ICombatActions m_CombatActionsCallbackInterface;
        private readonly InputAction m_Combat_Attack;
        private readonly InputAction m_Combat_Move;
        private readonly InputAction m_Combat_Jump;
        private readonly InputAction m_Combat_Dash;
        public struct CombatActions
        {
            private @PlayerControls m_Wrapper;
            public CombatActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Attack => m_Wrapper.m_Combat_Attack;
            public InputAction @Move => m_Wrapper.m_Combat_Move;
            public InputAction @Jump => m_Wrapper.m_Combat_Jump;
            public InputAction @Dash => m_Wrapper.m_Combat_Dash;
            public InputActionMap Get() { return m_Wrapper.m_Combat; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
            public void SetCallbacks(ICombatActions instance)
            {
                if (m_Wrapper.m_CombatActionsCallbackInterface != null)
                {
                    @Attack.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnAttack;
                    @Move.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnJump;
                    @Dash.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnDash;
                }
                m_Wrapper.m_CombatActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                }
            }
        }
        public CombatActions @Combat => new CombatActions(this);

        // Cutscene
        private readonly InputActionMap m_Cutscene;
        private ICutsceneActions m_CutsceneActionsCallbackInterface;
        private readonly InputAction m_Cutscene_Advance;
        private readonly InputAction m_Cutscene_BackTrack;
        private readonly InputAction m_Cutscene_Skip;
        public struct CutsceneActions
        {
            private @PlayerControls m_Wrapper;
            public CutsceneActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Advance => m_Wrapper.m_Cutscene_Advance;
            public InputAction @BackTrack => m_Wrapper.m_Cutscene_BackTrack;
            public InputAction @Skip => m_Wrapper.m_Cutscene_Skip;
            public InputActionMap Get() { return m_Wrapper.m_Cutscene; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CutsceneActions set) { return set.Get(); }
            public void SetCallbacks(ICutsceneActions instance)
            {
                if (m_Wrapper.m_CutsceneActionsCallbackInterface != null)
                {
                    @Advance.started -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnAdvance;
                    @Advance.performed -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnAdvance;
                    @Advance.canceled -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnAdvance;
                    @BackTrack.started -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnBackTrack;
                    @BackTrack.performed -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnBackTrack;
                    @BackTrack.canceled -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnBackTrack;
                    @Skip.started -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnSkip;
                    @Skip.performed -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnSkip;
                    @Skip.canceled -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnSkip;
                }
                m_Wrapper.m_CutsceneActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Advance.started += instance.OnAdvance;
                    @Advance.performed += instance.OnAdvance;
                    @Advance.canceled += instance.OnAdvance;
                    @BackTrack.started += instance.OnBackTrack;
                    @BackTrack.performed += instance.OnBackTrack;
                    @BackTrack.canceled += instance.OnBackTrack;
                    @Skip.started += instance.OnSkip;
                    @Skip.performed += instance.OnSkip;
                    @Skip.canceled += instance.OnSkip;
                }
            }
        }
        public CutsceneActions @Cutscene => new CutsceneActions(this);
        public interface ICombatActions
        {
            void OnAttack(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
        }
        public interface ICutsceneActions
        {
            void OnAdvance(InputAction.CallbackContext context);
            void OnBackTrack(InputAction.CallbackContext context);
            void OnSkip(InputAction.CallbackContext context);
        }
    }
}
