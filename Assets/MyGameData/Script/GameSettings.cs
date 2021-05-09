using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    #region "Value"
    private int _mouseSensitivity;
    private int _soundVolume;
    private bool _soundMute;

    [SerializeField] private Slider _soundVolumeSlider;
    [SerializeField] private Slider _mouseSensitivitySlider;
    [SerializeField] private Toggle _soundMuteToggle;
    #endregion "Value"

    #region "Property"
    public int MouseSensitivity => _mouseSensitivity;
    public int SoundVolume => _soundVolume;
    public bool SoundMute => _soundMute;
    #endregion "Property"

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            _soundVolumeSlider.onValueChanged.AddListener(SetSoundVolume);
            _mouseSensitivitySlider.onValueChanged.AddListener(SetMouseSensitivity);
            _soundMuteToggle.onValueChanged.AddListener(SetsoundMute);
        }
        else
            Destroy(gameObject);
    }

    private void SetMouseSensitivity(float value)
    {
        instance._mouseSensitivity = (int)value;
    }

    private void SetSoundVolume(float value)
    {
        instance._soundVolume = (int)value;
    }

    private void SetsoundMute(bool value)
    {
        instance._soundMute = value;
    }
}