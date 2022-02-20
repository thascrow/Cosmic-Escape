using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private DamagableCharacter damagableCharacter;
    private float maxHealth;

    private void Start()
    {
        maxHealth = damagableCharacter.health;

        if (maxHealth > slider.maxValue)
        {
            slider.value = maxHealth;
            slider.maxValue = maxHealth;
        }
    }

    private void Update()
    {
        if (damagableCharacter.health < maxHealth)
        {
            slider.value = damagableCharacter.health;
        }
    }
}