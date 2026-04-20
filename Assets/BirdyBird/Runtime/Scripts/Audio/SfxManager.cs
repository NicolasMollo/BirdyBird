using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Audio
{
    internal class SfxManager : MonoBehaviour
    {
        [SerializeField] private Sfx[] _sfxArray = null;
        private Dictionary<SfxType, Sfx> _sfxDictionary = null;
        private List<AudioSource> _sourcePool = null;
        [SerializeField]
        private int _sourceCount = 2;
        private int _sourceIndex = 0;

        private void Awake()
        {
            CreateDictionary();
            _sourceCount = Mathf.Max(1, _sourceCount);
            CreateSourcePool();
        }

        internal void PlaySfx(SfxType sfx)
        {
            if (!_sfxDictionary.TryGetValue(sfx, out Sfx sfxValue))
            {
                Debug.LogError($"SFX {sfx.ToString()} not found!", this);
                return;
            }
            GetAudioSource().PlayOneShot(sfxValue.Clip, sfxValue.Volume);
        }

        private void CreateDictionary()
        {
            _sfxDictionary = new Dictionary<SfxType, Sfx>();
            for (int i = 0; i < _sfxArray.Length; i++)
            {
                _sfxDictionary[_sfxArray[i].Type] = _sfxArray[i];
            }
        }
        private void CreateSourcePool()
        {
            _sourcePool = new List<AudioSource>();
            AudioSource temp = null;
            for (int i = 0; i < _sourceCount; i++)
            {
                temp = CreateSource();
                _sourcePool.Add(temp);
            }
        }
        private AudioSource CreateSource()
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.loop = false;

            return source;
        }

        private AudioSource GetAudioSource()
        {
            AudioSource source = _sourcePool[_sourceIndex];
            _sourceIndex = (_sourceIndex + 1) % _sourcePool.Count;
            return source;
        }

    }
}