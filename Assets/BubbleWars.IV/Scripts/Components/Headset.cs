using BinaryEyes.Common;
using UnityEngine;
using UnityEngine.XR.Hands;

namespace BubbleWarIV.Components
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
        public HeadsetFade Fade;
    }
}
