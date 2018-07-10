﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ToggleTooltips : MonoBehaviour {

    private VRTK_ControllerTooltips tooltips;
    private VRTK_ObjectTooltip[] individualTooltips;
    public VRTK_ObjectTooltip triggerTooltip, gripTooltip, touchpadTooltip, buttonOne, buttonTwo;


    void Start ()
    {
        tooltips = GetComponentInChildren<VRTK_ControllerTooltips>();
        individualTooltips = GetComponentsInChildren<VRTK_ObjectTooltip>(true);
        InitializeIndividualTooltips();

    }

    private void InitializeIndividualTooltips()
    {
        for (int i = 0; i < individualTooltips.Length; i++)
        {
            VRTK_ObjectTooltip tooltip = individualTooltips[i];

            switch (tooltip.name.Replace("Tooltip", "").ToLower())
            {
                case "trigger":
                    triggerTooltip = tooltip;
                    break;
                case "grip":
                    gripTooltip = tooltip;
                    break;
                case "touchpad":
                    touchpadTooltip = tooltip;
                    break;
                case "buttonone":
                    buttonOne = tooltip;
                    break;
                case "buttontwo":
                    buttonTwo = tooltip;
                    break;
            }
        }
    }

    public void ChangeContainerColor(VRTK_ObjectTooltip tooltip, Color newColor)
    {
        tooltip.containerColor = newColor;
    }

    public void ChangeFontColor(VRTK_ObjectTooltip tooltip, Color newColor)
    {
        tooltip.fontColor = newColor;
    }

    public void ChangeLineColor(VRTK_ObjectTooltip tooltip, Color newColor)
    {
        tooltip.lineColor = newColor;
    }

}