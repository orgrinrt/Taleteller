using GDMechanic.Wiring;

namespace Talesmith.Core.UI.Inspector.InspectorContentPages
{
    public class Home : InspectorContentPage
    {
        public override void _Ready()
        {
            this.Wire();
        }   
    }
}