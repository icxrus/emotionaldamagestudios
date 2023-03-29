using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField] private float _staminaLeft;
    [SerializeField] private float _staminaCount;
    [SerializeField] private float _staminaCap = 25;
    public int _depleadStamina = 3;
    public bool _hasStamina;
    private bool _doAction;
    [SerializeField] private float _regainSpeed = (1/2);
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_hasStamina == true && _doAction == true)
        {
            _staminaCount -= _depleadStamina;
        }
        CalculateStamina();

    }
    void CalculateStamina()
    {
        if(_staminaCount == _staminaCap)
        {
            _hasStamina = true;
            //stop count
        }
        else if(_staminaCount <= _staminaCap && _staminaCount > 0 && _doAction == false)
        {
            // increase stamina count
            _hasStamina = true;
        }
        else
        {
            //stop count
        }
    }
    void FixedUpdate()
    {
        if(_staminaCount <= _staminaCap)
        {
            _staminaCount += Time.deltaTime / _regainSpeed;
        }    
    }
}
