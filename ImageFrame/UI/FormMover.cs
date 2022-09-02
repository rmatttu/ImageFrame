using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ImageFrame.UI
{
    internal class FormMover
    {
        public Window MoveTarget { get; init; }
        public MouseButton MoveButton { get; init; }

        bool IsMouseDraging = false;
        System.Windows.Point LastMouseLocation;


        public FormMover(Window moveTarget, MouseButton moveButton)
        {
            MoveTarget = moveTarget;
            MoveButton = moveButton;
            MoveTarget.MouseDown += MoveTarget_MouseDown;
            MoveTarget.MouseMove += MoveTarget_MouseMove;
            MoveTarget.MouseUp += MoveTarget_MouseUp;
        }

        private void MoveTarget_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LastMouseLocation = e.GetPosition(MoveTarget);
            IsMouseDraging = true;
        }

        private void MoveTarget_MouseMove(object sender, MouseEventArgs e)
        {
            var current = e.GetPosition(MoveTarget);
            System.Diagnostics.Debug.WriteLine(current.ToString());
            if (!IsMouseDraging) return;
            var delta = new System.Windows.Point(current.X - LastMouseLocation.X, current.Y - LastMouseLocation.Y);
            Move(delta);
            LastMouseLocation = current;
        }

        private void MoveTarget_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsMouseDraging = false;
        }

        private void Move(System.Windows.Point delta)
        {
            MoveTarget.Left = MoveTarget.Left + delta.X;
            MoveTarget.Top = MoveTarget.Top + delta.Y;
        }

    }
}
