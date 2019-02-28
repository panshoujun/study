using com.google.zxing;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Common
{
    public class QrCodeHelper
    {
        /// <summary>
        /// 构建 二维码图片
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="midImg">中心图</param>
        /// <returns></returns>
        public static Bitmap Encode(string content, int width = 430, int height = 430, Image midImg = null)
        {
            //构造二维码写码器
            var mutiWriter = new MultiFormatWriter();
            var hint = new Hashtable
                    {
                        {EncodeHintType.CHARACTER_SET, "UTF-8"},
                        {EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.H}
                    };
            //生成二维码
            var bm = mutiWriter.encode(content, BarcodeFormat.QR_CODE, width, height, hint);
            var img = bm.ToBitmap();
            if (midImg == null)
                return img;

            var middlImg = midImg;
            //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸）
            var realSize = mutiWriter.GetEncodeSize(content, BarcodeFormat.QR_CODE, width, height);
            //计算插入图片的大小和位置
            var middleImgW = Math.Min((int)(realSize.Width / 3.5), middlImg.Width);
            var middleImgH = Math.Min((int)(realSize.Height / 3.5), middlImg.Height);
            var middleImgL = (img.Width - middleImgW) / 2;
            var middleImgT = (img.Height - middleImgH) / 2;

            //将img转换成bmp格式，否则后面无法创建 Graphics对象
            var bmpimg = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(img, 0, 0);
            };

            //在二维码中插入图片
            var MyGraphic = Graphics.FromImage(bmpimg);
            //白底
            MyGraphic.FillRectangle(Brushes.White, middleImgL, middleImgT, middleImgW, middleImgH);
            MyGraphic.DrawImage(middlImg, middleImgL, middleImgT, middleImgW, middleImgH);

            return bmpimg;
        }

        /// <summary>
        /// 解析二维码
        /// </summary>
        /// <param name="img">二维码图片</param>
        /// <returns></returns>
        public static string Decode(Image img)
        {
            //构建解码器
            var mutiReader = new MultiFormatReader();
            var bitImg = (Bitmap)img;

            LuminanceSource ls = new RGBLuminanceSource(bitImg, bitImg.Width, bitImg.Height);
            var bb = new BinaryBitmap(new com.google.zxing.common.HybridBinarizer(ls));
            //注意  必须是Utf-8编码
            var hints = new Hashtable { { EncodeHintType.CHARACTER_SET, "UTF-8" } };
            var r = mutiReader.decode(bb, hints);
            return r.Text;
        }

        public static byte[] PhotoImageInsert(Image imgPhoto, ImageFormat Imgtype)
        {
            using (var mstream = new MemoryStream())
            {
                imgPhoto.Save(mstream, Imgtype);
                var byData = new Byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(byData, 0, byData.Length);
                return byData;
            }
        }
    }
}
