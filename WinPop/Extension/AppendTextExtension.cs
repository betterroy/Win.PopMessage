using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinPop.Extension
{
    static class AppendTextExtension
    {
        static Color black = Color.Black;

        public static void AppendTextColorful(this RichTextBox rtBox, string addtext, Color? color = null, bool IsaddNewLine=true)
        {
            if (IsaddNewLine)
            {
                addtext += Environment.NewLine;
            }
            rtBox.SelectionStart = rtBox.TextLength;
            rtBox.SelectionLength = 0;
            rtBox.SelectionColor = color ?? Color.Black;
            rtBox.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{addtext}");
            rtBox.SelectionColor = rtBox.ForeColor;
            rtBox.ScrollToCaret();
        }
    }

}
