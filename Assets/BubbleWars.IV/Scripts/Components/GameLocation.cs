using BinaryEyes.Common;

namespace BubbleWarEp4.Components
{
    public sealed class GameLocation
        : SingletonBehaviour<GameLocation>
    {
        public string LocationName => gameObject.scene.name;
    }
}