using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePopup : MonoBehaviour
{
[Header("References")]
[SerializeField] private Button _tryAgainButton;
[SerializeField] private Button _mainMenuButton;
[SerializeField] private TMP_Text _timerText;
[SerializeField] private TimerUI _timerUI;

    void OnEnable()
    {
        _timerText.text = _timerUI.GetFinalTime();
        _tryAgainButton.onClick.AddListener(OnTryAgainButtonClicked);
    }

    private void OnTryAgainButtonClicked()
    {
        SceneManager.LoadScene(Consts.GameSceneNames.GAME_SCENE);
    }

}
