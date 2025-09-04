using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private ToggleMuter _toggleMuter;
    [SerializeField] private SoundButton[] _soundControllers;
    [SerializeField] private AudioSource _backGroundMusic;
    [SerializeField] private AudioSource[] _allMusic;

    private float _previousVolume = 1f;

    private void Awake()
    {
        foreach (var controller in _soundControllers)
        {
            controller.Initialize(_toggleMuter);
            controller.SetToggleMuter(_toggleMuter);
        }

        if (_toggleMuter != null)
            _toggleMuter.OnMuteToggle += HandleMuteToggle;
    }

    private void HandleMuteToggle(bool isMuted)
    {
        if (_backGroundMusic != null)
        {
            if (isMuted)
            {
               ResetVolume();

            }
            else
            {
                _backGroundMusic.volume = _previousVolume;

                foreach (var music in _allMusic)
                    music.volume = _previousVolume;
            }
        }
    }

    private void ResetVolume()
    {
        _previousVolume = _backGroundMusic.volume;
        _backGroundMusic.volume = 0f;

        foreach (var music in _allMusic)
            music.volume = 0;
    }
}
