using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public static class StyleDevxpressGridControl
    {
        // Design by Linh Nguyen
        public static void styleGridControl(DevExpress.XtraGrid.GridControl gc, DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            gc.LookAndFeel.UseDefaultLookAndFeel = false;
            gc.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            gv.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;

            gv.Appearance.HeaderPanel.BackColor = Color.FromArgb(30, 160, 86);
            gv.Appearance.HeaderPanel.Font = new System.Drawing.Font(gv.Appearance.HeaderPanel.Font, FontStyle.Bold);
            gv.ColumnPanelRowHeight = 21;
            gv.Appearance.HeaderPanel.Font = new Font("Arial", 12, FontStyle.Bold);
            gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gv.Appearance.HeaderPanel.Options.UseBackColor = true;

            gv.Appearance.Row.Font = new Font("Arial", 9, FontStyle.Bold);
            gv.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public static void styleTextBoxVND(DevExpress.XtraEditors.TextEdit text)
        {
            text.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            text.Properties.DisplayFormat.FormatString = "{0:#,##0.00} VNĐ";
            //text.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        }
    }
}
