using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _soundEffect;
    [SerializeField] private AudioSource[] _otherSounds;

    private ToggleMuter toggleMuter;

    private void OnEnable()
    {
        if (_button != null)
            _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(OnButtonClicked);
    }

    public void Initialize(ToggleMuter muter)
    {
        toggleMuter = muter;
    }

    public void SetToggleMuter(ToggleMuter muter)
    {
        toggleMuter = muter;
    }

    private void OnButtonClicked()
    {
        if (toggleMuter == null || _soundEffect == null)
            return;

        if (!toggleMuter.isMuted)
        {
            foreach (var sound in _otherSounds)
                sound.Stop();

            _soundEffect.Play();
        }
    }
}
