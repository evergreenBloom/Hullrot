using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Shared._Crescent.Overlays
{
    [RegisterComponent, NetworkedComponent]
    public sealed partial class DemonVisionComponent : Component
    {
        [DataField]
        public string Shader = "DemonVision";
    }

    [Serializable, NetSerializable]
    public sealed class ToggleDemonVisionEvent : EntityEventArgs
    {
        public bool Enabled;
        public ToggleDemonVisionEvent(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
