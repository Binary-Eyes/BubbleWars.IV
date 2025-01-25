using BinaryEyes.Common.Extensions;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace BubbleWarIV.Components
{
    public sealed class XRHeadsetController
        : MonoBehaviour
    {
        public XRRayInteractor InteractionRay;
        public XRInteractorLineVisual InteractionVisualization;

        public void EnableInteractions()
        {
            this.LogMessage("EnablingInteractions");
            InteractionRay.enabled = true;
            InteractionVisualization.enabled = true;
        }

        public void DisableInteractions()
        {
            this.LogMessage("DisablingInteractions");
            InteractionRay.enabled = false;
            InteractionVisualization.enabled = false;
        }
    }
}