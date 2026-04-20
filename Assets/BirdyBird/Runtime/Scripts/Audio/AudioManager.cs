using UnityEngine;

namespace BirdyBird.Audio
{
    [RequireComponent(typeof(AudioSource), typeof(SfxManager))]
    public class AudioManager : MonoBehaviour
    {
        [Header("SETTINGS")]
        [SerializeField]
        private float _musicVolume = 1f;

        private AudioSource _musicSource = null;
        private SfxManager _sfxManager = null;

        private void Awake()
        {
            _musicSource = GetComponent<AudioSource>();
            _musicSource.playOnAwake = false;
            _musicSource.loop = true;
            _musicSource.volume = _musicVolume;
            _sfxManager = GetComponent<SfxManager>();
        }

        public void PlayMusic(AudioClip clip)
        {
            if (_musicSource.clip == clip && _musicSource.isPlaying) 
                return;
            _musicSource.clip = clip;
            _musicSource.Play();
        }

        public void PlaySfx(SfxType sfx)
        {
            _sfxManager.PlaySfx(sfx);
        }

    }
}