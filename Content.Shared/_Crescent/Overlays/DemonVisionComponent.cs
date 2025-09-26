using Robust.Client.Graphics;


namespace Content.Shared._Crescent.Overlays;

public sealed class DemonVisionSystem : EntitySystem
{
    private class ColorTintOverlay : Overlay { }

    [Dependency] private readonly IOverlayManager _overlayMan = default!;
    private ColorTintOverlay? _overlay;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<DemonVisionComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<DemonVisionComponent, ComponentShutdown>(OnShutdown);
    }

    private void OnStartup(Entity<DemonVisionComponent> ent, ref ComponentStartup args)
    {
        if (_overlay != null)
            return;

        _overlay = new ColorTintOverlay
        {
            TintColor = new Robust.Shared.Maths.Vector3(1f, 0f, 0f), // red
            TintAmount = 0.25f
        };

        _overlayMan.AddOverlay(_overlay);
    }

    private void OnShutdown(Entity<DemonVisionComponent> ent, ref ComponentShutdown args)
    {
        if (_overlay == null)
            return;

        _overlayMan.RemoveOverlay(_overlay);
        _overlay = null;
    }
}
