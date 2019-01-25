using System;
using Godot;
using Talesmith.Core.Viewports.Cameras;

namespace Talesmith.Core.UI.Workspaces.Atlas
{
    public class AtlasWorkspace : Workspace
    {
        public override void _Ready()
        {
            base._Ready();
            
            GetAtlasViewport().Size = RectSize;
        }
        
        // NOTE: We might want to only process FreeCamera input whenever mouse is over this page
        // One way to do this would be to have flag on this page whenever mouse is over and check that whenever processing input in Freecam

        public override void _Notification(int what)
        {
            base._Notification(what);

            switch (what)
            {
                case NotificationVisibilityChanged:
                    if (Visible)
                    {
                        GetAtlasViewportContainer().Show();
                    }
                    else
                    {
                        GetAtlasViewportContainer().Hide();
                    }
                    break;
                case NotificationMouseEnter:
                    GrabFocus();
                    GetFreeCamera().SetPanningLocked(false);
                    break;
                case NotificationMouseExit:
                    GetFreeCamera().SetPanningLocked(true);
                    break;
                case NotificationResized:
                    GetAtlasViewport().Size = RectSize;
                    break;
            }
        }

        public FreeCamera GetFreeCamera()
        {
            return GetAtlasViewport().GetNode<FreeCamera>("./FreeCam");
        }
        
        private ViewportContainer GetAtlasViewportContainer()
        {
            return GetNode<ViewportContainer>("./Atlas2D");
        }

        private Viewport GetAtlasViewport()
        {
            return GetAtlasViewportContainer().GetNode<Viewport>("./Viewport");
        }
        
        public override ICycleableItem GetNextItem()
        {
            return App.Self.Workspaces.Aetas;
        }

        public override ICycleableItem GetPrevItem()
        {
            return App.Self.Workspaces.Studia;
        }
    }
}
