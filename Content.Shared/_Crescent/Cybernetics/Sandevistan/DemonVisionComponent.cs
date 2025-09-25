using Robust.Shared.GameObjects;

namespace Content.Shared._Crescent.Overlays;

[RegisterComponent]
public sealed partial class DemonVisionOverlayComponent : Component
{
    [DataField] public string Shader = "DemonVision"; 
}
