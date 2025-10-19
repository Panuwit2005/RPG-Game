using UnityEngine;

public interface ISwitchControl
{
    //bool isOn;
    bool isOn {  get; set; }

    void TurnOn();

    void TurnOff();

    //void turnOff() {
    //ผิดหลักการทำงานของ interface
    //}
}
