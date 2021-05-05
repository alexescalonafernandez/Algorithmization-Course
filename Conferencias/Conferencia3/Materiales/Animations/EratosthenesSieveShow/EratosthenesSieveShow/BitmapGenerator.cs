using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace EratosthenesSieveShow
{
    class BitmapGenerator
    {
        /*public static Bitmap GenerateChessCellBoardImage(bool backGroundColor, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(backGroundColor ? Color.White : Color.Black);
            g.Dispose();
            return bitmap;
        }*/

        public static Bitmap GenerateDiasbleChessCellBoardImage(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(SystemColors.Control);
            g.Dispose();
            return bitmap;
        }

        public static Bitmap GenerateNumberImage(int width, int height, int number,int pixels, Color background,Pen pen, bool drawRectangle)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(background);
            if (drawRectangle)
            {
                g.DrawRectangle(pen, new Rectangle(pixels / 2, pixels / 2, width - pixels * 3, height - pixels * 3));
            }
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
                PointF textPos = new PointF((layoutArea.Width - last.Width) / 2-pixels, (layoutArea.Height - last.Height) / 2);
                g.DrawString(s, f, Brushes.Black, textPos);
                f.Dispose();
                g.Dispose();
                return bitmap;
            }
        }

        /*public static Bitmap GenerateBishopCellImage(int width, int height, bool backGroundColor)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(backGroundColor ? Color.White : Color.Black);
            Image img = global::BishopShow.Properties.Resources.AlfilB;
            Point p = new Point((width - img.Width) / 2, (height - img.Height) / 2);
            g.DrawImage(img, p);
            img.Dispose();
            g.Dispose();
            return bitmap;
        }*/

        /*public static Bitmap GenerateXImage(int width, int height, bool backGroundColor)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(backGroundColor ? Color.White : Color.Black);

            Brush BrickBrush = new HatchBrush(HatchStyle.DiagonalCross, Color.DarkGoldenrod, Color.Cyan);
            Pen BrickWidePen = new Pen(BrickBrush, 5);


            BrickWidePen.StartCap = BrickWidePen.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(BrickWidePen, new Point(width / 4, 5), new Point(width / 4 * 3, height - 5));
            g.DrawLine(BrickWidePen, new Point(width / 4, height - 5), new Point(width / 4 * 3, 5));
            g.Dispose();
            return bitmap;
        }*/
    }
}
