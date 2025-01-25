using System.Collections.Generic;
using System.Linq;
using BinaryEyes.Common;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BubbleWarsEp4.Components
{
    public sealed class SoundManager
        : SingletonBehaviour<SoundManager>
    {
        private readonly List<AudioSource> _sources = new(30);
        public AudioClip[] BubblePops;

        public void PlayBubblePop()
            => PlaySound(BubblePops.GetRandom());

        public void PlaySound(AudioClip clip)
        {
            var source = _sources.FirstOrDefault(entry => !entry.isPlaying);
            if (!source)
                return;

            source.clip = clip;
            source.Play();
        }

        protected override void Awake()
        {
            base.Awake();
            for (var i = 0; i < 30; i++)
            {
                var sourceEntity = new GameObject("AudioSource");
                var source = sourceEntity.AddComponent<AudioSource>();
                source.loop = false;
                source.playOnAwake = false;
                _sources.Add(source);
            }
        }
    }
}