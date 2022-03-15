using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    public Variable var;
    public Slider slider;
    public Image fill;
    public Gradient gradient;
    
    public void SetMaxHealth()
    {
        slider.maxValue = var.health;
        slider.value = var.health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth()
    {
        slider.value = var.health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
