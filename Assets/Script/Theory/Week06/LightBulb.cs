using UnityEngine;

public class LightBulb : ISwitchControl
{
    private bool _isOn = false;
    public bool isOn
    {
        get { return _isOn; }
        set { _isOn = value; }
    }

    
        public void TurnOff()
    {
        isOn = false;
        Debug.Log("Light bulb turn off. ");
    }


    public void TurnOn()
    {
        _isOn = true;
        Debug.Log("Light bulb turn on. ");
    }
}

    
