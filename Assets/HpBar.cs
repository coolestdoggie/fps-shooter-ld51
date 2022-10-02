using System;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private Target playerTarget;
    
    private void Awake()
    {
        playerTarget = Controller.Instance.GetComponent<Target>();
    }

    private void OnEnable()
    {
        playerTarget.GotDamage += UpdateBar;
    }
    
    private void OnDisable()
    {
        playerTarget.GotDamage -= UpdateBar;
    }
    
    private void UpdateBar()
    {
        fillImage.fillAmount = playerTarget.CurrentHealth / playerTarget.health;
    }
}
