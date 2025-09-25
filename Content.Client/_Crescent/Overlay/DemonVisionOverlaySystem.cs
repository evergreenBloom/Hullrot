using System.Numerics;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.Prototypes;


namespace Content.Client._Crescent.Overlay;

public sealed class DemonVisionScreenOverlay : Robust.Client.Graphics.Overlay
{
    private readonly ShaderInstance _shader;
    public float Intensity = 1f;

    public DemonVisionScreenOverlay(string shaderId)
    {
        IoCManager.InjectDependencies(this);
        var prototype = IoCManager.Resolve<IPrototypeManager>().Index<ShaderPrototype>(shaderId);
        _shader = prototype.InstanceUnique();
    }

    public override bool RequestScreenTexture => true;
    public override OverlaySpace Space => OverlaySpace.WorldSpaceBelowFOV;

    protected override bool BeforeDraw(in OverlayDrawArgs args) => true; // always draw when active

    protected override void Draw(in OverlayDrawArgs args)
    {
        if (ScreenTexture is null)
            return;

        _shader.SetParameter("SCREEN_TEXTURE", ScreenTexture);
        _shader.SetParameter("intensity", Intensity);

        var worldHandle = args.WorldHandle;
        var viewport = args.WorldBounds;
        worldHandle.SetTransform(Matrix3x2.Identity);
        worldHandle.UseShader(_shader);
        worldHandle.DrawRect(viewport, Color.White);
        worldHandle.UseShader(null);
    }
}


