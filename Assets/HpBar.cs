using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private Target playerTarget;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        
        playerTarget = Controller.Instance.GetComponent<Target>();
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
