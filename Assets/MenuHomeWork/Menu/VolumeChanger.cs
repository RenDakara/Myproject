using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _parameterName;

    private const float MinDb = -80f;
    private const float MaxDb = 0f;

    private void Start()
    {
        if (_audioMixer.GetFloat(_parameterName, out float currentVolume))
        {
            _volumeSlider.value = DbToNormalized(currentVolume);
        }

        _volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDestroy()
    {
        _volumeSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        float dB;
        float max = 20f;

        if (value <= 0.0001f)
        {
            dB = MinDb;
        }
        else
        {
            dB = Mathf.Log10(value) * max;
            dB = Mathf.Clamp(dB, MinDb, MaxDb);
        }

        _audioMixer.SetFloat(_parameterName, dB);
    }

    private float DbToNormalized(float dB)
    {
        float min = 10f;
        float num = 0.01f;
        float max = 20f;

        if (dB <= MinDb + num)
            return 0f;

        return Mathf.Pow(min, dB / max);
    }
}