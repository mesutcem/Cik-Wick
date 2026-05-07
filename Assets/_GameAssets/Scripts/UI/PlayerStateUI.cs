using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerStateUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private RectTransform _playerWalkingTransform;
    [SerializeField] private RectTransform _playerSlidingTransform;
    [SerializeField] private RectTransform _boosterSpeedTransform;
    [SerializeField] private RectTransform _boosterJumpTransform;
    [SerializeField] private RectTransform _boosterSlowTransform;

    [Header("Images")]
    [SerializeField] private Image _goldBoosterWheatImage;
    [SerializeField] private Image _holyBoosterWheatImage;
    [SerializeField] private Image _rottenBoosterWheatImage;

    [Header("Sprites")]
    [SerializeField] private Sprite _playerWalkingActiveSprite; 
    [SerializeField] private Sprite _playerWalkingPassiveSprite; 
    [SerializeField] private Sprite _playerSlidingActiveSprite; 
    [SerializeField] private Sprite _playerSlidingPassiveSprite;

    [Header("Settings")]
    [SerializeField] private float _moveDirection;
    [SerializeField] private Ease _moveEase;

    private Image _playerWalkingImage;
    private Image _playerSlidingImage;

    public RectTransform GetBoosterJumpTransform => _boosterJumpTransform;
    public RectTransform GetBoosterSpeedTransform => _boosterSpeedTransform;
    public RectTransform GetBoosterSlowTransform => _boosterSlowTransform;
    public Image GetGoldBoosterWheatImage => _goldBoosterWheatImage;
    public Image GetHolyBoosterWheatImage => _holyBoosterWheatImage;
    public Image GetRottenBoosterWheatImage => _rottenBoosterWheatImage;

    private void Awake()
    {
        _playerWalkingImage = _playerWalkingTransform.GetComponent<Image>();
        _playerSlidingImage = _playerSlidingTransform.GetComponent<Image>();
    }
    private void Start()
    {
        _playerController.OnPlayerStateChanged += PlayerController_OnPlayerStateChanged;
        SetStateUI(_playerWalkingActiveSprite, _playerSlidingPassiveSprite,
                        _playerWalkingTransform, _playerSlidingTransform);
    }

    private void PlayerController_OnPlayerStateChanged(PlayerState playerState)
    {
        switch(playerState)
        {
            case PlayerState.Idle:
            case PlayerState.Move:
            SetStateUI(_playerWalkingActiveSprite, _playerSlidingPassiveSprite,
                        _playerWalkingTransform, _playerSlidingTransform);
                break;

            case PlayerState.SlideIdle:
            case PlayerState.Slide:
            SetStateUI(_playerWalkingPassiveSprite, _playerSlidingActiveSprite,
                        _playerSlidingTransform, _playerWalkingTransform);
                break;
        }
    }

    private void SetStateUI(Sprite playerWalkingSprite, Sprite playerSlidingSprite,
                            RectTransform activeTransform, RectTransform passiveTransform)
    {
        _playerWalkingImage.sprite = playerWalkingSprite;
        _playerSlidingImage.sprite = playerSlidingSprite;

        activeTransform.DOAnchorPosX(-25f, _moveDirection).SetEase(_moveEase);
        activeTransform.DOAnchorPosX(-90f, _moveDirection).SetEase(_moveEase);
    }

    private IEnumerator SetBoosterUI(RectTransform activeTransform, Image boosterImage,
    Image wheatImage, Sprite activeSprite, Sprite passiveSprite, Sprite activeWheatSprite,
    Sprite passiveWheatSprite, float duration)
    {
        boosterImage.sprite = activeSprite;
        wheatImage.sprite = activeWheatSprite;
        activeTransform.DOAnchorPosX(25f, _moveDirection).SetEase(_moveEase);

        yield return new WaitForSeconds(duration);

        boosterImage.sprite = passiveSprite;
        wheatImage.sprite = passiveWheatSprite;
        activeTransform.DOAnchorPosX(90f, _moveDirection).SetEase(_moveEase);
    }

    public void SetBoosterUIAnimator(RectTransform activeTransform, Image boosterImage,
    Image wheatImage, Sprite activeSprite, Sprite passiveSprite, Sprite activeWheatSprite,
    Sprite passiveWheatSprite, float duration)
    {
        StartCoroutine(SetBoosterUI(activeTransform, boosterImage, wheatImage, activeSprite,
        passiveSprite, activeWheatSprite, passiveWheatSprite, duration));
    }
}
