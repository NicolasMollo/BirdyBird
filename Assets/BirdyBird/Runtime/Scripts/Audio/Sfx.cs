using UnityEngine;

namespace BirdyBird.Audio
{
    public enum SfxType : byte
    {
        ConfirmButton,
        BackButton,
        Fly,
        Death,
        Score
    }
    [System.Serializable]
    internal class Sfx
    {
        [field: SerializeField] internal string Name { get; private set; }
        [field: SerializeField] internal int Index { get; private set; } = 0;
        [field: SerializeField] internal SfxType Type { get; private set; }
        [field: SerializeField] internal AudioClip Clip { get; private set; }
        [field: SerializeField, Range(0f, 1f)] internal float Volume { get; private set; } = 1f;
    }
}