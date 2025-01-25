using BinaryEyes.Common;

namespace BubbleWarEpIV.Components
{
    public sealed class GameLocation
        : SingletonBehaviour<GameLocation>
    {
        public string LocationName => gameObject.scene.name;
    }
}