using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class WinLoseUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _blackBackgroundObject;
    [SerializeField] private GameObject _winPopup;
    [SerializeField] private GameObject _losePopup;

    [Header("Settings")]
    [SerializeField] private float _animationDuration = 0.3f;

    private Image _blackBackGroundImage;
    private RectTransform _winPopupTransform;
    private RectTransform _losePopupTransform;

    void Awake()
    {
        _blackBackGroundImage = _blackBackgroundObject.GetComponent<Image>();
        _winPopupTransform = _winPopup.GetComponent<RectTransform>();
        _losePopupTransform = _losePopup.GetComponent<RectTransform>();
    }

    public void OnGameWin()
    {
        _blackBackgroundObject.SetActive(true);
        _winPopup.SetActive(true);

        _blackBackGroundImage.DOFade(0.8f,_animationDuration).SetEase(Ease.Linear); 
        _winPopupTransform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);
    }

    public void OnGameLose()
    {
        _blackBackgroundObject.SetActive(true);
        _losePopup.SetActive(true);

        _blackBackGroundImage.DOFade(0.8f,_animationDuration).SetEase(Ease.Linear); 
        _losePopupTransform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);
    }
}
