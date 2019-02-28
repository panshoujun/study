using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Common
{
    public class ImageHelper
    {
        /// <summary>  
        /// 以逆时针为方向对图像进行旋转  
        /// </summary>  
        /// <param name="b">位图流</param>  
        /// <param name="angle">旋转角度[0,360](前台给的)</param>  
        /// <param name="savePath">旋转后保存位置</param>  
        /// <returns></returns>  
        public static Image RotateImg(Image b, int angle, string file,string savePath)
        {
            angle = angle % 360;
            //弧度转换  
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高  
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图  
            Bitmap dsImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //计算偏移量  
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域:让图像的中心与窗口的中心点一致  
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(angle);
            //恢复图像在水平和垂直方向的平移  
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换  
            g.ResetTransform();
            g.Save();
            g.Dispose();
            //保存旋转后的图片  
            dsImage.Save(savePath + "\\" + angle + ".png", System.Drawing.Imaging.ImageFormat.Png);
            return dsImage;
        }
        public static Image RotateImg(string filename, int angle, string file, string savePath)
        {
            return RotateImg(GetSourceImg(filename), angle, file,savePath);
        }
        public static Image GetSourceImg(string filename)
        {
            Image img;
            img = Bitmap.FromFile(filename);
            return img;
        }  
    }
}
