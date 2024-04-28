using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Burner Sizes:   6-12 inches     15.24-30.48 cm
Pan Sizes:
Frying Pan:     9.00 inches     22.860 cm
Sauce Pan:      6.25 inhces     15.875 cm
Tall Pan:       7.50 inches     19.050 cm

Thermal Conductivity:
Stainless Steel:    15  watts/Kelvin
Cast Iron:          50  watts/Kelvin
Copper:             385 watts/Kelvin
*/

// debug should always be last in the list
public enum Contents
{
    water,
    sauce,
    pasta,
    debug
}
[System.Serializable] public struct contentData
{
    public Contents type;
    public float volume;
    public float temp;
}
public class Cookware : Grabbable
{
    // we'll measure volume in ml, 1000ml = 1L
    [SerializeField] public float maxVolume = 1000;
    [SerializeField] public float currentVolume = 0;
    // we'll measure temp in celsius
    // 20-22 is room temp 0 is freezing 100 is boiling
    [SerializeField] public float currentTemp = 22;
    public int[] intArray = new int[5];
    [SerializeField] private bool heating;
    [SerializeField] private float incomingHeat;

    // neat idea, but dictionary would be better =/
    // make serializable dictionary?
    // Alternative: initialize list on awake, use Contents to access list and never add or remove from list
    [SerializeField] public List<contentData> contentList;

    protected override void Awake()
    {
        base.Awake();
        for (Contents i = 0; i < Contents.debug; i++)
        {
            contentData data;
            data.type = i;
            data.temp = 22;
            data.volume = 0;

            contentList.Add(data);
        }
    }

    public void TestFill()
    {
        Fill(Contents.water, 133);
    }

    public void Fill(Contents _content, float _amount)
    {
        if (currentVolume < maxVolume)
        {
            contentData temp = contentList[(int)_content];

            temp.volume += _amount;
            currentVolume += _amount;

            contentList[(int)_content] = temp;
        }
        else
        {
            Debug.Log(gameObject.name + " is full!");
        }
    }

    public void Heat(float _targetTemp)
    {
        if (currentTemp < _targetTemp)
        {

        }
        else if (currentTemp > _targetTemp)
        {

        }
        else
        {

        }
    }

    public float CalculateHeatTransfer(float _stoveTemp, float _potTemp, float _stoveSA, float _potSA, float _conductivity, float _time)
    {
        // heat transfer rate using Fourier's law of heat conduction
        return (_conductivity * _stoveSA * (_stoveTemp - _potTemp) / _potSA) * _time;
    }
}
