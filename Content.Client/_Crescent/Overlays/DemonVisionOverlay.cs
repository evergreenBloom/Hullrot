using System.Numerics;
using Robust.Client.Graphics;
using Robust.Shared.Enums;


namespace Content.Client._Crescent.Overlays;

public sealed class DemonVisionOverlay : Robust.Client.Graphics.Overlay
{
    public override OverlaySpace Space => OverlaySpace.ScreenSpace;
    public override bool RequestScreenTexture => false;

    protected override void Draw(in OverlayDrawArgs args)
    {
        var handle = args.ScreenHandle;
        var viewport = args.ViewportBounds;

        // Draw a faint red tint overlay
        handle.SetTransform(Matrix3x2.Identity);
        handle.DrawRect(viewport, new Color(255, 40, 40, 60));
        // ↑ RGBA, with alpha=60 for transparency
    }
}
