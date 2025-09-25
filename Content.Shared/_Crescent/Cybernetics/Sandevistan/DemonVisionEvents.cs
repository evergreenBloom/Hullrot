using Robust.Shared.Serialization;

namespace Content.Shared._Crescent.Cybernetics.Sandevistan
{
    [Serializable, NetSerializable,]
    public sealed class DemonVisionToggleEvent : EntityEventArgs
    {
        public bool Enabled;

        public DemonVisionToggleEvent(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
