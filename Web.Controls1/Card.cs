using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Drawing.Text;



namespace Signature.Web.Controls
{
    
    [ToolboxData("<{0}:Card runat=server></{0}:Card>")]
    [Description("Card Design")]
    public class Card : WebControl
    {

        protected string tempPath = @"~\Cards\";
        private string _imageURL;

        private ArrayList Lines = new ArrayList();
        
        #region Overridden Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            
            Lines.Add("Jorge, Amelia, George and Andi."); //.ToUpper());
            Lines.Add("Merry Christmas and Happy New Year!!!"); //.ToUpper());
            Lines.Add("And very properous!!! ..."); //.ToUpper());
            Lines.Add("Extra line just in case!!! ..."); //.ToUpper());
            Lines.Add(DateTime.Now.ToLongTimeString());
        }

        protected void CreateBitmap()
        {
            Bitmap objBitmap;
            Graphics objGraphics;
            Int32 Height = 200;
            Int32 Width = 745;

            objBitmap = new Bitmap(Width, Height);
            objGraphics = Graphics.FromImage(objBitmap);

            objGraphics.Clear(Color.White);

            Pen p = new Pen(Color.Black, 2);
            
            objGraphics.DrawRectangle(p, new Rectangle(0,0,Width,Height));


            Font font = new Font("ShelleyAllegro BT", 25, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Blue);


            float top = Height / 2 - font.Height * Lines.Count / 2;
            foreach (String _text in Lines)
            {
                SizeF textSize = objGraphics.MeasureString(_text, font);
                float h_pos = (Width / 2) - (textSize.Width / 2);

                objGraphics.DrawString(_text, font, Brushes.Black, h_pos, top);
                top += (float)font.Height;
            }

            int j = 0;
            while (File.Exists(tempPath + @"graph" + j.ToString() + ".jpg"))
                j++;

            _imageURL = tempPath + @"graph" + j.ToString() + ".jpg";

            objBitmap.Save(Page.Server.MapPath(_imageURL), ImageFormat.Jpeg);


            //objBitmap.Save(Response.OutputStream, ImageFormat.Gif);
            //objBitmap.Save(Page.Server.MapPath(FileName), ImageFormat.Jpeg);

            objBitmap.Dispose();
            objGraphics.Dispose(); 
        }

        protected override void Render(HtmlTextWriter writer)
        {
            CreateBitmap();

            System.Web.UI.WebControls.Image imgGraph = new System.Web.UI.WebControls.Image();
            imgGraph.ImageUrl = _imageURL;
            imgGraph.RenderControl(writer);

            base.Render(writer);
        }
        #endregion

    }
}
