using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    // THIS CONTORLLS IF MOVE CAN BE DONE
    public bool _hasStamina;
    // SET THIS BOOL TO TRUE TO USE THE SCRIPT
    private bool _doAction;


    [SerializeField] private float _staminaLeft;
    [SerializeField] private float _staminaCount = 25;
    [SerializeField] private float _staminaCap = 25;
    // Call with int to remove stamina
    public int _depleadStamina = 3;
    // Stops counter
    private bool _Stop = true;
    // Limits speed of stamina regen. Higher = slower
    [SerializeField] private float _regainSpeed = 40;
    public float _waitfor = 1;

    public string StaminaCounter;

    // Update is called once per frame
    void Update()
    {
        // for testing
        if (Input.GetKeyDown(KeyCode.C)) { _doAction = true; }
        StaminaCounter = ("Stamina: " + _staminaCount);
        //These calls need to happen in update
        CalculateStamina();
        Timer();
    }
    public void Timer()
    {
        if (_doAction == true)
        {
            _waitfor -= Time.deltaTime;
        }
        // Reset Wait
        if (_waitfor <= 0)
        {
            _waitfor = 3;
            _doAction = false;
        }
    }
    void CalculateStamina()
    {
        if(_hasStamina == true && _doAction == true && _waitfor <= 0)
        {
            _staminaCount -= _depleadStamina;
            _doAction = false;
        }
        else if(_staminaCount <= _staminaCap && _doAction == false)
        {
            _Stop = false;
            _hasStamina = true;
        }
        else if(_staminaCount <= _depleadStamina) {_hasStamina = false;}
        else
        {
            _Stop = true;
        }

    }
    void FixedUpdate()
    {
        if(_staminaCount == _staminaCap)
        {
            _hasStamina = true;
            _Stop = true;
        }
        else if(_staminaCount <= _staminaCap && _Stop == false)
        {
            _staminaCount += 1f / _regainSpeed;
            // Set by _staminaCount = xf;
        }    
    }

    public void ChangeDoActionBool(bool stateBool)
    {
        _doAction = stateBool;
    }
}
