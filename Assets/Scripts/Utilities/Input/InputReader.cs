using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Decent
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Decent/Input Reader")]
    public class InputReader : ScriptableObject, UserInput.IGameplayActions, UserInput.IUIActions
    {
        // Gameplay
        public event UnityAction PrimaryEvent;
        public event UnityAction SecondaryEvent;
        public event UnityAction<Vector2> MoveEvent;
        public event UnityAction<float> RotateEvent;
        public event UnityAction<float> ZoomEvent;
        //public event UnityAction InteractEvent;
        public event UnityAction SwitchModeEvent;
        public Vector2 LookPosition { get; private set; }

        private UserInput _userInput;

        private void OnEnable()
        {
            if (_userInput == null)
            {
                _userInput = new UserInput();
                _userInput.Gameplay.SetCallbacks(this);
                _userInput.UI.SetCallbacks(this);
            }

            EnableGameplayInput();
        }

        private void OnDisable()
        {
            _userInput.Disable();
        }

        public void EnableGameplayInput()
        {
            _userInput.Disable();
            _userInput.Gameplay.Enable();
        }

        // Gameplay
        public void OnPrimary(InputAction.CallbackContext context)
        {
            if (context.ReadValue<float>() > 0f)
            {
                PrimaryEvent?.Invoke();
            }
        }

        public void OnSecondary(InputAction.CallbackContext context)
        {
            if (context.ReadValue<float>() > 0f)
            {
                SecondaryEvent?.Invoke();
            }
        }


        public void OnLook(InputAction.CallbackContext context)
        {
            LookPosition = context.ReadValue<Vector2>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnRotate(InputAction.CallbackContext context)
        {
            RotateEvent?.Invoke(context.ReadValue<float>());
        }

        public void OnZoom(InputAction.CallbackContext context)
        {
            ZoomEvent?.Invoke(context.ReadValue<float>());
        }

        public void OnSwitchMode(InputAction.CallbackContext context)
        {
            if (context.ReadValue<float>() > 0f)
            {
                SwitchModeEvent?.Invoke();
            }
        }

        // User Interface
        public void OnNavigate(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnSubmit(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnScrollWheel(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnMiddleClick(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnTrackedDevicePosition(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }

}