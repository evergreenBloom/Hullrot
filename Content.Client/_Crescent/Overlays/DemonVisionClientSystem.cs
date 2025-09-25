using Robust.Client.Graphics;
using Content.Shared._Crescent.Cybernetics.Sandevistan;


namespace Content.Client._Crescent.Overlays
{
    public sealed class DemonVisionClientSystem : EntitySystem
    {
        private DemonVisionScreenOverlay? _overlay;

        public override void Initialize()
        {
            base.Initialize();
            SubscribeNetworkEvent<DemonVisionToggleEvent>(OnToggleVision);
        }

        private void OnToggleVision(DemonVisionToggleEvent args)
        {
            var overlayMan = IoCManager.Resolve<IOverlayManager>();

            if (args.Enabled)
            {
                if (_overlay == null)
                {
                    _overlay = new DemonVisionScreenOverlay("DemonVision");
                    overlayMan.AddOverlay(_overlay);
                }
            }
            else
            {
                if (_overlay != null)
                {
                    overlayMan.RemoveOverlay(_overlay);
                    _overlay = null;
                }
            }
        }
    }
}
