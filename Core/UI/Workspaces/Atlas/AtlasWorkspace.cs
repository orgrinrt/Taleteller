using System;
using Godot;
using Talesmith.Core.Viewports.Cameras;

namespace Talesmith.Core.UI.Pages.Atlas
{
    public class AtlasWorkspace : Workspace, ICycleableItem
    {
        public ICycleableItem NextItem => GetNextItem();
        public ICycleableItem PrevItem => GetPrevItem();
        
        public override void _Ready()
        {
            _workspaceEnum = WorkspaceEnum.Atlas;
            SetFocusMode(FocusModeEnum.All);
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
                        GetAtlas2D().Show();
                    }
                    else
                    {
                        GetAtlas2D().Hide();
                    }
                    break;
                case NotificationMouseEnter:
                    GrabFocus();
                    GetFreeCamera().SetPanningLocked(false);
                    break;
                case NotificationMouseExit:
                    GetFreeCamera().SetPanningLocked(true);
                    break;
            }
        }

        public FreeCamera GetFreeCamera()
        {
            return GetNode<FreeCamera>("../../../Atlas2D/FreeCam");
        }
        
        private Node2D GetAtlas2D()
        {
            return GetNode<Node2D>("../../../Atlas2D");
        }

        public ICycleableItem GetNextItem()
        {
            throw new NotImplementedException();
        }

        public ICycleableItem GetPrevItem()
        {
            throw new NotImplementedException();
        }
    }
}