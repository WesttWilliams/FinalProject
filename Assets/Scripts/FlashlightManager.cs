using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum FlashlightState
{
    Off, // When the flashlight is off
    On, // When the flashlight is on
    Dead // When there is no battery left

}
[RequireComponent(typeof(AudioSource))]
public class FlashlightManager : MonoBehaviour
{
public TextMeshProUGUI papersText;
[Header("Options")]
[Tooltip("This is the amount of battery that the player starts with.")] [SerializeField] int startBattery = 100;
[Tooltip("The speed that the battery is lost at")] [Range(0.0f, 2f)][SerializeField] float batteryLossTick = 0.5f;
[Tooltip("This is the amount of battery that the player currently has.")] public int currentBattery;

[Tooltip("The current state of the flashlight")] public FlashlightState state;

[Tooltip("Is the flashlight on?")] private bool flashlightIsOn;

[Tooltip("The key that is required to be pressed to turn on/off the flashlight.")] [SerializeField] KeyCode ToggleKey = KeyCode.F;



[Header("References")]

[Tooltip("The light that will be shown if the flashlight is on.")] [SerializeField] GameObject FlashlightLight;

[Tooltip("Sounds that will be played when the flashlight is toggled.")] [SerializeField] AudioClip FlashlightOn_FX, FlashlightOff_FX;
private void Start()
{
    currentBattery = startBattery; // Set the current battery to the start battery when the game starts.

    InvokeRepeating(nameof(LoseBattery), 0, batteryLossTick);// Loses the battery at a set interval of time.
}
private void Update()
{
    papersText.text = currentBattery.ToString() + "%";
    if (Input.GetKeyDown(ToggleKey)) ToggleFlashlight();// Toggles the flashlight

    if (state == FlashlightState.Off) FlashlightLight.SetActive(false);
    else if (state == FlashlightState.On) FlashlightLight.SetActive(true);
    else if (state == FlashlightState.Dead) FlashlightLight.SetActive(false);

    // Handling the battery being dead.
    if (currentBattery <=0 )
    {
        currentBattery = 0;
        state = FlashlightState.Dead;
        flashlightIsOn = false; // (Automatically) turns the flashlight off.)
    }

}



public void GainBattery(int amount) // Handle the gaining of battery
{
    if(currentBattery == 0)
    {
        state = FlashlightState.On;
        flashlightIsOn = true;
    }
    
    
    
    
    
    
    if (currentBattery + amount > startBattery)
    
        currentBattery = startBattery; // Automatically cause the battery to be the maximum.
    else
        currentBattery += amount; // Adds the <amount> of battery to the current battery.
}



private void LoseBattery() // Handle the loss of battery
{
    if (state == FlashlightState.On) currentBattery--; // Subtracts the battery by 1, if the flashlight is on.
}

private void ToggleFlashlight() // Toggle the on/off state of the flashlight
{
    flashlightIsOn = !flashlightIsOn;

        if (state == FlashlightState.Dead) flashlightIsOn = false; // Automatically overrides the state, if there's no battery.
        // Handles the light/sound that are seen/heard when the player toggles the flashlight.
        if (flashlightIsOn) 
        {
            if (FlashlightOn_FX != null) GetComponent<AudioSource>() .PlayOneShot(FlashlightOn_FX);
            state = FlashlightState.On; // Turn the flashlight light on.
        }
        else 
        {
            if (FlashlightOff_FX != null) GetComponent<AudioSource>() .PlayOneShot(FlashlightOff_FX);

             state = FlashlightState.Off; // Turns the flashlight light off.
    }
        
    
    }

}