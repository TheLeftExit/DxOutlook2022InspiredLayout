using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T1081268 {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();

            flyoutPanel1.OwnerControl = accordionControl1;
            flyoutPanel1.ParentForm = this;
            flyoutPanel1.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Left;
            
            accordionControlElement2.Click += AccordionControlElement2_Click;
        }

        private void AccordionControlElement2_Click(object sender, EventArgs e) {
            var element = sender as AccordionControlElement;
            // Optional: position the beak form near the clicked element.
            var beakPosition = GetElementBeakPosition(element);
            flyoutPanel1.ShowBeakForm(beakPosition);
            // Or simply align it with the accordion control.
            //flyoutPanel1.ShowBeakForm();
        }

        private Point GetElementBeakPosition(AccordionControlElement element) {
            var control = element.AccordionControl;
            var viewInfo = control.GetViewInfo() as AccordionControlViewInfo;
            var elementInfo = viewInfo.ElementsInfo.Single(x => x.Element == element);
            var beakX = elementInfo.HeaderBounds.Right + viewInfo.ScaleInteger(5);
            var beakY = elementInfo.HeaderBounds.Y + elementInfo.HeaderBounds.Height / 2;
            return control.PointToScreen(new Point(beakX, beakY));
        }
    }
}
