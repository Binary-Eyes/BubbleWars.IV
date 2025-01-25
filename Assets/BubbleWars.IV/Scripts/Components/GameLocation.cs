using BinaryEyes.Common;

namespace BubbleWarIV.Components
{
    public sealed class GameLocation
        : SingletonBehaviour<GameLocation>
    {
        public string LocationName => gameObject.scene.name;
    }
}