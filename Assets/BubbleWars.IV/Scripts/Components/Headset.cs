using BinaryEyes.Common;
using BinaryEyes.Common.Extensions;
using UnityEngine;
using UnityEngine.XR.Hands;

namespace BubbleWarsEp4.Components
{
    public sealed class Headset
        : SingletonBehaviour<Headset>
    {
        [Header("Controllers")]
        public GameObject LeftController;
        public GameObject RightController;

        [Header("Hands")]
        public XRHandSkeletonDriver LeftHandDriver;
        public XRHandSkeletonDriver RightHandDriver;

        [Header("Features")]
        public Camera Camera;
        public HeadsetFade Fade;
        public GameHead Head;
        public GameHand LeftHand;
        public GameHand RightHand;

        protected override void Awake()
        {
            base.Awake();
            Fade.SetActiveState(true);
        }
    }
}
