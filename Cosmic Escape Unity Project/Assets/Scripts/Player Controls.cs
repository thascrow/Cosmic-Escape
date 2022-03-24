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
        }
    ],
    ""controlSchemes"": []
}");
        // Board Scene
        m_BoardScene = asset.FindActionMap("Board Scene", throwIfNotFound: true);
        m_BoardScene_BeginGame = m_BoardScene.FindAction("Begin Game", throwIfNotFound: true);
        m_BoardScene_RollDice = m_BoardScene.FindAction("Roll Dice", throwIfNotFound: true);
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
    public interface IBoardSceneActions
    {
        void OnBeginGame(InputAction.CallbackContext context);
        void OnRollDice(InputAction.CallbackContext context);
    }
}
