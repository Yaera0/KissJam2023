using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MyGameInputToUnityEvent : MonoBehaviour
{


    MyGameInput m_input;

    public float m_leftRightValue;
    public UnityEventFloat m_leftRightChanged;

    [Serializable]
    public class UnityEventFloat : UnityEvent<float> { }
    // Start is called before the first frame update
    void Start()
    {
        m_input = new MyGameInput();
        m_input.Enable();
        m_input.MainPlayer.Enable();
        m_input.MainPlayer.MoveLeftRight.Enable();
        m_input.MainPlayer.MoveLeftRight.canceled += StopChangingLeftRight;
        m_input.MainPlayer.MoveLeftRight.performed += ChangingLeftRight;
    }

    private void ChangingLeftRight(InputAction.CallbackContext obj)
    {
        m_leftRightValue = 0;
        m_leftRightChanged.Invoke(0);
    }

    private void StopChangingLeftRight(InputAction.CallbackContext obj)
    {
        m_leftRightValue = obj.ReadValue<float>();
        m_leftRightChanged.Invoke(obj.ReadValue<float>());
    }

}
