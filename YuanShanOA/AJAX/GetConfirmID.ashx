<%@ WebHandler Language="C#" Class="GetConfirmID" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Drawing;
/// <summary>
/// 创建验证码
/// </summary>
public class GetConfirmID : IHttpHandler,IRequiresSessionState
{
    //要实现IRequiresSessionState接口，才能使用session变量
    public void ProcessRequest (HttpContext context)
    {
        int number;
        //得到随机生成的单个字符
        char code;
        //保存生成的字符串
        string stringCode = string.Empty;
        //表示伪随机数生成器，一种能够产生满足某些随机性统计要求的数字序列的设备。
        Random rand = new Random();
        for (int i = 0; i < 4; i++)
        {
            //返回非负随机数。
            number = rand.Next();
            if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
            else
                code = (char)('A' + (char)(number % 26));
            stringCode += code;
        }
        //保存验证码
        
        context.Session["code"] = stringCode;
        //创建一个内存位图
        Bitmap image = new Bitmap((int)(Math.Ceiling(stringCode.Length * 12.5)),22);
        Graphics g = Graphics.FromImage(image);
        //填充背景色
        try
        {
            g.Clear(Color.White);
            //添加干扰线条
            for (int i = 0; i < 4; i++)
            {
                int x1 = rand.Next(image.Width);
                int y1 = rand.Next(image.Height);
                int x2 = rand.Next(image.Width);
                int y2 = rand.Next(image.Height);
                g.DrawLine(new Pen(Brushes.Green), x1, y1, x2, y2);
            }
            //新建一个图片字体
            Font font = new Font("Arial", 12, FontStyle.Bold);
            //添加字体到图片中
            g.DrawString(stringCode, font, Brushes.Blue, 2, 2);

            //添加图片前背景干扰
            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(image.Width);
                int y = rand.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(rand.Next()));
            }
            //画图片的边框
            g.DrawRectangle(new Pen(Brushes.Yellow), 0, 0, image.Width - 1, image.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            context.Response.ContentType = "image/png";
            context.Response.BinaryWrite(ms.ToArray());
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            g.Dispose();
            image.Dispose(); 
        }
        
    }


    public bool IsReusable
    {
        get {
            return false;
        }
    }

}