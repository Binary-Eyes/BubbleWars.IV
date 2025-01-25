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

        public void PlayBubblePop(Transform location)
        {
            var source = PlaySound(BubblePops.GetRandom());
            source.transform.position = location.position;
        }

        public AudioSource PlaySound(AudioClip clip)
        {
            var source = _sources.FirstOrDefault(entry => !entry.isPlaying);
            if (!source)
                _sources.Add(source = GenerateSource());

            source.clip = clip;
            source.Play();
            return source;
        }

        protected override void Awake()
        {
            base.Awake();
            for (var i = 0; i < 30; i++)
                _sources.Add(GenerateSource());
        }

        private static AudioSource GenerateSource()
        {
            var sourceEntity = new GameObject("AudioSource");
            var source = sourceEntity.AddComponent<AudioSource>();
            source.loop = false;
            source.playOnAwake = false;

#if !UNITY_EDITOR
            source.spatialize = true;
#endif
            return source;
        }
    }
}