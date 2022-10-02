using System.Collections;
using DG.Tweening;
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
        playerTarget.HpUpdated += UpdateBar;
    }
    
    private void OnDisable()
    {
        playerTarget.HpUpdated -= UpdateBar;
    }
    
    private void UpdateBar()
    {
        float newHp = playerTarget.CurrentHealth / playerTarget.health;
        DOTween.To(() => fillImage.fillAmount, x => fillImage.fillAmount = x, newHp, 0.2f)
            .SetEase(Ease.InOutSine); 
    }
}
