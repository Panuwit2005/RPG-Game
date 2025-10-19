using System.Collections.Generic;
using UnityEngine;

public class ElectronicGenerator : MonoBehaviour
{
    private void Start()
    {
        LightBulb lightbulb = new LightBulb();
        lightbulb.TurnOn();
        lightbulb.TurnOff();
        Debug.Log("Lightbulb is On : " + lightbulb.isOn);


        PortableFan portableFan = new PortableFan();
        portableFan.TurnOn();
        portableFan.TurnOn();
        portableFan.TurnOn();
        portableFan.TurnOn();
        portableFan.TurnOff();
        portableFan.TurnOn();
        Debug.Log("Portable Fan is on : " + portableFan.isOn);

        List<ISwitchControl> smartHome = new List<ISwitchControl>();
        smartHome.Add(portableFan);
        smartHome.Add(lightbulb);

        Debug.Log("Come Home");
            foreach(ISwitchControl device in smartHome)
        {
            device.TurnOn();
        }
        Debug.Log("Go to Work");
            foreach (ISwitchControl device in smartHome)
        {
            device.TurnOff();
        }
        Debug.Log("See Status device");
            foreach (ISwitchControl device in smartHome)
        {
            Debug.Log(device.isOn);
        }
    }
}
