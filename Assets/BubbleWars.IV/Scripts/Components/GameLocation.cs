using BinaryEyes.Common;

namespace BubbleWarsEp4.Components
{
    public sealed class GameLocation
        : SingletonBehaviour<GameLocation>
    {
        public string LocationName => gameObject.scene.name;
    }
}