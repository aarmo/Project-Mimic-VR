using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedController))]
public class ButtonController : MonoBehaviour {

    public string controllerName = "Controller";
    public ControllerButton interactionButton = ControllerButton.Trigger;
    public ButtonObject activeButton;

    SteamVR_TrackedController _controller;

    private void Start()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
    }

    // Update is called once per frame
    private void Update () {

        if (activeButton == null) return;

        var buttonPressed = false;
        switch (interactionButton)
        {
            case ControllerButton.Scripted:
                return;

            case ControllerButton.Grip:
                buttonPressed = _controller.gripped;
                break;

            case ControllerButton.Trigger:
                buttonPressed = _controller.triggerPressed;
                break;

            case ControllerButton.Pad:
                buttonPressed = _controller.padPressed;
                break;
        }

        if (buttonPressed)
        {
            activeButton.button.Click(controllerName);
            activeButton = null;
        }
    }
}
