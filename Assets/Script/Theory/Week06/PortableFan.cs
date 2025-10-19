using UnityEngine;

public class PortableFan : ISwitchControl
{
    bool _isOn;
    public bool isOn {  get => _isOn; set => _isOn = value; }
    int currentNumber;
    int MaxNumber = 3;

    public void TurnOff()
    {
        _isOn = false;
        currentNumber = 0;
        Debug.Log("Motor turned off stopped");
    }


    public void TurnOn()
    {
        currentNumber++;
        if (currentNumber > MaxNumber)
        {
            currentNumber = 1;
        }
        if (currentNumber == 1)
        {
            Debug.Log("Motor turned On Low speed");
        }
        if (currentNumber == 2)
        {
            Debug.Log("Motor turned On Medium speed");
        }
        if (currentNumber == 3)
        {
            Debug.Log("Motor turned On High speed");
        }
    }
}

