using System.Numerics;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.Prototypes;

namespace Content.Client._Crescent.Overlays
{
    public sealed class DemonVisionScreenOverlay : Robust.Client.Graphics.Overlay
    {
        private readonly ShaderInstance _shader;

        public DemonVisionScreenOverlay(string shader)
        {
            _shader = IoCManager.Resolve<IPrototypeManager>()
                .Index<ShaderPrototype>(shader)
                .InstanceUnique();
        }

        // Apply shader to the full screen
        public bool RequestScreenTexture => true;
        public OverlaySpace Space => OverlaySpace.ScreenSpace;

        protected override void Draw(in OverlayDrawArgs args)
        {
            if (ScreenTexture == null)
                return;

            _shader.SetParameter("SCREEN_TEXTURE", ScreenTexture);

            var handle = args.ScreenHandle;
            var viewport = args.ViewportBounds;

            handle.SetTransform(Matrix3x2.Identity);
            handle.UseShader(_shader);
            handle.DrawRect(viewport, Color.White);
            handle.UseShader(null);
        }
    }
}


