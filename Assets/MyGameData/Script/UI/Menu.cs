using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _quitGame;

    [SerializeField] private Toggle _muteSound;
    [SerializeField] private Slider _sound;

    private void Awake()
    {
        _startGame.onClick.AddListener(StartGame);
        _quitGame.onClick.AddListener(QuitGame);

        _muteSound.onValueChanged.AddListener(SetMuteSound);

        _sound.value = _sound.maxValue * 0.8f;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void SetMuteSound(bool isMute)
    {

    }

    private void SetVoice(float _voice)
    {
        int voice = (int)_voice;
    }
}
