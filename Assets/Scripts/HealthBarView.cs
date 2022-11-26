using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Health health;
    [SerializeField] private float healthChangingSpeed;
    private float currentFillAmount;
    private float accumulation = 0;

    void Start() {
        currentFillAmount = healthBar.fillAmount;
    }

    void ChangeColor() {
        Color healthColor = Color.Lerp(Color.red, Color.green, health.hp/health.maxHP);
        healthBar.color = healthColor;

    }

    void ChangeHealthFillAmount() { 
        float healthFillAmount = health.hp / health.maxHP;
        if (accumulation <= 1) 
        {
            accumulation += healthChangingSpeed * Time.deltaTime;
            healthBar.fillAmount = Mathf.Lerp(currentFillAmount, healthFillAmount, accumulation);
            ChangeColor();
            return;
        }
        accumulation = 0;
        currentFillAmount = healthBar.fillAmount;
    }

    void Update()
    {
        ChangeHealthFillAmount();
    }
}
