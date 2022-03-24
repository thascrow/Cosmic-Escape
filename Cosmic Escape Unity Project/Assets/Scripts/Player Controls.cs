// GENERATED AUTOMATICALLY FROM 'Assets/Player Controls.inputactions'

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
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Board Scene"",
            ""id"": ""34052b13-e1be-431c-b789-504c815c6c44"",
            ""actions"": [
                {
                    ""name"": ""Begin Game"",
                    ""type"": ""Button"",
                    ""id"": ""bc5ed0a3-1b7c-4899-9c4b-325b2406cfba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll Dice"",
                    ""type"": ""Button"",
                    ""id"": ""6fb1bb7c-b4c6-4000-a24a-6f714e7afcbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f03870e6-d36d-474b-a5cf-8469f2981e01"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Begin Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a03f14d6-648c-47bb-8d0b-03810411ca5a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll Dice"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TP Movement"",
            ""id"": ""3cad1f99-e323-45df-91db-b678ce3ba011"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""90700205-0b61-4203-b9a7-33c001316b3b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b4d5d1ee-364d-4721-b0e6-6ec86a1dc350"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3f7f735-3755-42d2-a5ba-3b67ec9e9c5d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8652e669-cf44-4f1f-bf1b-92789cc784bc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Board Scene
        m_BoardScene = asset.FindActionMap("Board Scene", throwIfNotFound: true);
        m_BoardScene_BeginGame = m_BoardScene.FindAction("Begin Game", throwIfNotFound: true);
        m_BoardScene_RollDice = m_BoardScene.FindAction("Roll Dice", throwIfNotFound: true);
        // TP Movement
        m_TPMovement = asset.FindActionMap("TP Movement", throwIfNotFound: true);
        m_TPMovement_Rotate = m_TPMovement.FindAction("Rotate", throwIfNotFound: true);
        m_TPMovement_Move = m_TPMovement.FindAction("Move", throwIfNotFound: true);
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

    // Board Scene
    private readonly InputActionMap m_BoardScene;
    private IBoardSceneActions m_BoardSceneActionsCallbackInterface;
    private readonly InputAction m_BoardScene_BeginGame;
    private readonly InputAction m_BoardScene_RollDice;
    public struct BoardSceneActions
    {
        private @PlayerControls m_Wrapper;
        public BoardSceneActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @BeginGame => m_Wrapper.m_BoardScene_BeginGame;
        public InputAction @RollDice => m_Wrapper.m_BoardScene_RollDice;
        public InputActionMap Get() { return m_Wrapper.m_BoardScene; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BoardSceneActions set) { return set.Get(); }
        public void SetCallbacks(IBoardSceneActions instance)
        {
            if (m_Wrapper.m_BoardSceneActionsCallbackInterface != null)
            {
                @BeginGame.started -= m_Wrapper.m_BoardSceneActionsCallbackInterface.OnBeginGame;
                @BeginGame.performed -= m_Wrapper.m_BoardSceneActionsCallbackInterface.OnBeginGame;
                @BeginGame.canceled -= m_Wrapper.m_BoardSceneActionsCallbackInterface.OnBeginGame;
                @RollDice.started -= m_Wrapper.m_BoardSceneActionsCallbackInterface.OnRollDice;
                @RollDice.performed -= m_Wrapper.m_BoardSceneActionsCallbackInterface.OnRollDice;
                @RollDice.canceled -= m_Wrapper.m_BoardSceneActionsCallbackInterface.OnRollDice;
            }
            m_Wrapper.m_BoardSceneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @BeginGame.started += instance.OnBeginGame;
                @BeginGame.performed += instance.OnBeginGame;
                @BeginGame.canceled += instance.OnBeginGame;
                @RollDice.started += instance.OnRollDice;
                @RollDice.performed += instance.OnRollDice;
                @RollDice.canceled += instance.OnRollDice;
            }
        }
    }
    public BoardSceneActions @BoardScene => new BoardSceneActions(this);

    // TP Movement
    private readonly InputActionMap m_TPMovement;
    private ITPMovementActions m_TPMovementActionsCallbackInterface;
    private readonly InputAction m_TPMovement_Rotate;
    private readonly InputAction m_TPMovement_Move;
    public struct TPMovementActions
    {
        private @PlayerControls m_Wrapper;
        public TPMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_TPMovement_Rotate;
        public InputAction @Move => m_Wrapper.m_TPMovement_Move;
        public InputActionMap Get() { return m_Wrapper.m_TPMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TPMovementActions set) { return set.Get(); }
        public void SetCallbacks(ITPMovementActions instance)
        {
            if (m_Wrapper.m_TPMovementActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_TPMovementActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_TPMovementActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_TPMovementActionsCallbackInterface.OnRotate;
                @Move.started -= m_Wrapper.m_TPMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TPMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TPMovementActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_TPMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public TPMovementActions @TPMovement => new TPMovementActions(this);
    public interface IBoardSceneActions
    {
        void OnBeginGame(InputAction.CallbackContext context);
        void OnRollDice(InputAction.CallbackContext context);
    }
    public interface ITPMovementActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
