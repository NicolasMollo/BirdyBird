using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace BirdyBird.DummyPlayer
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public class DummyPlayerController : MonoBehaviour
    {
        private Animator _animator = null;
        private AnimatorController _animatorController = null;

        private void Awake() => _animator = GetComponent<Animator>();
        private void Start()
        {
            _animator.speed = 3.0f;
        }

    }
}