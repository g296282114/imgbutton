using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace imgbutton
{
    public partial class cimgbutton : UserControl
    {
        float[][] tmatrix = { 
                  new float[] {1,  0, 0,0,0},
                  new float[] {0,  1, 0, 0,0},
                  new float[] { 0,  0, 1, 0,0},
                  new float[] {0, 0, 0, 1, 0},
                  new float[] {0, 0, 0, 0, 1}
        };
        float[][] _bmatrix = { 
                  new float[] {0.9F, 0, 0,0,0},
                  new float[] {0, 0.9F,0, 0,0},
                  new float[] {0,  0, 0.9F, 0,0},
                  new float[] {0, 0, 0, 1, 0},
                  new float[] {0, 0, 0, 0,1}
        };

        Boolean mon = false;
        Bitmap  _fimage;
        String _tiptxt = "";
        Boolean _enbk = false;


        public cimgbutton()
        {
            InitializeComponent();
        }

        public Boolean enbk
        {
            get
            {
                return _enbk;
            }
            set
            {
                _enbk = value;
                Invalidate();

            }
        }


        public Bitmap fimage
        {
            get
            {
                return _fimage;
            }
            set
            {
                _fimage = value;
                Invalidate();

            }
        }

        public float[][] bmatrix
        {
            get
            {
                return _bmatrix;
            }
            set
            {
                _bmatrix = value;
                Invalidate();

            }
        }

        public String tiptxt
        {
            get
            {
                return _tiptxt;
            }
            set
            {
                _tiptxt = value;
                if(value != "")
                toolTip1.SetToolTip(this,_tiptxt);
                Invalidate();

            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Do not paint background
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {

            
         
            if (_fimage == null) return;
            ColorMatrix matrix;
            if (mon)
            {
                if (enbk)
                {

                        e.Graphics.Clear(BackColor);
                        //SolidBrush br = new SolidBrush(Color.FromArgb(_bkc, BackColor.R, BackColor.G, BackColor.B));
                        //e.Graphics.FillRectangle(br, 0, 0, Width, Height);

                }
                 matrix = new ColorMatrix(tmatrix);
            }
            else
            {
                 matrix = new ColorMatrix(bmatrix);
            }
            
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //g.DrawImage(srcImage, new Rectangle(0, 0, srcImage.Width, srcImage.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, attributes);
            //(Bitmap)Properties.Resources.ResourceManager.GetObject("btn" + ((int)tpc.Tag))




            e.Graphics.DrawImage(_fimage, new Rectangle((Width - _fimage.Width) / 2, (Height - _fimage.Height) / 2, _fimage.Width, _fimage.Height), 0, 0, _fimage.Width, _fimage.Height, GraphicsUnit.Pixel, attributes);



            // e.Graphics.DrawString(_title, fo, so, new Rectangle(0, Height-20, Width, Height));
        
  
        
        }

        private void UserControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mon != true)
            {
                mon = true;
                Invalidate();
            }
            
        }

        private void UserControl1_MouseLeave(object sender, EventArgs e)
        {
            mon = false;
            Invalidate();
        }

     

        

    }
}
