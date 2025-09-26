using Content.Shared._Crescent.Overlays;
using Robust.Client.Graphics;

namespace Content.Client._Crescent.Overlays;

public sealed class DemonVisionClientSystem : EntitySystem
{
    private DemonVisionOverlay? _overlay;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<DemonVisionComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<DemonVisionComponent, ComponentShutdown>(OnShutdown);
    }

    private void OnStartup(EntityUid uid, DemonVisionComponent comp, ComponentStartup args)
    {
        if (_overlay == null)
        {
            _overlay = new DemonVisionOverlay();
            IoCManager.Resolve<IOverlayManager>().AddOverlay(_overlay);
        }
    }

    private void OnShutdown(EntityUid uid, DemonVisionComponent comp, ComponentShutdown args)
    {
        if (_overlay != null)
        {
            IoCManager.Resolve<IOverlayManager>().RemoveOverlay(_overlay);
            _overlay = null;
        }
    }
}
