using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace HanoiTowerShow
{
    class BitmapGenerator
    {
        public static Bitmap GenerateHanoiTower(int[] a, int[] b, int[] c, Dictionary<int,Brush> pallete)
        {
            int width = 500;
            int height = 300;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            Pen pen = Pens.Black;
            int diff = (int)Math.Ceiling(pen.Width);
            int oneFive = width / 5 - (10 - diff) / 5;

            g.DrawRectangle(pen, new Rectangle(0, height - 10, width - diff, 10 - diff));
            DrawStack(oneFive, 100, 10 - diff, height - 110, "A", a, pallete, ref g);
            DrawStack(width / 2 - (10 - diff) / 2, 100, 10 - diff, height - 110, "B", b, pallete, ref g);
            DrawStack(width - (oneFive + (10 - diff) / 2), 100, 10 - diff, height - 110, "C", c, pallete, ref g);
            g.Dispose();
            return bitmap;
        }

        private static void DrawStack(int x, int y, int width, int height,string name, int[] stack,Dictionary<int,Brush> pallete, ref Graphics g)
        {
            Pen pen = Pens.Black;
            int diff = (int)Math.Ceiling(pen.Width);
            g.DrawRectangle(pen, new Rectangle(x, y, width, height));
            g.DrawString(name,  SystemFonts.MenuFont, Brushes.Black, new PointF(x, y - 30));
            int p = 1;
            for (int i = stack.Length - 1; i >= 0;i-- )
            {
                g.FillRectangle(pallete[stack[i]], new Rectangle(x + 5 - (stack[i] / 2), y + height - p * 15, stack[i], 10));
                p++;
            }
        }

        public static Bitmap GenerateNumberImage(int width, int height, int number)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            string s = number.ToString();
            SizeF layoutArea = new SizeF(width, height);
            SizeF current = new SizeF(), last = new SizeF();
            int fontSize = 0;
            do
            {
                fontSize++;
                last = current;
                current = g.MeasureString(s, new Font(FontFamily.GenericSerif, fontSize));
            } while (current.Width <= layoutArea.Width && current.Height <= layoutArea.Height);
            if (fontSize == 1)
                throw new Exception("Imposible draw string");
            else
            {
                fontSize--;
                Font f = new Font(FontFamily.GenericSerif, fontSize);
                PointF textPos = new PointF((layoutArea.Width - last.Width) / 2, (layoutArea.Height - last.Height) / 2);
                g.DrawString(s, f, Brushes.Black, textPos);
                f.Dispose();
                g.Dispose();
                return bitmap;
            }
        }
    }
}
