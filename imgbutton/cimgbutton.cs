using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace imgbutton
{
    public partial class CImgButton : UserControl
    {
        
        float[][] tmatrix = { 
                  new float[] {1,  0, 0,0,0},
                  new float[] {0,  1, 0, 0,0},
                  new float[] { 0,  0, 1, 0,0},
                  new float[] {0, 0, 0, 1, 0},
                  new float[] {0, 0, 0, 0, 1}
        };
        float[][] bmatrix = { 
                  new float[] {1, 0, 0,0,0},
                  new float[] {0, 1,0, 0,0},
                  new float[] {0,  0, 1, 0,0},
                  new float[] {0, 0, 0, 1, 0},
                  new float[] {0, 0, 0, 0,1}
        };

        Boolean mon = false;
        Bitmap  _fimage;
        String _tiptxt = "";
        int _bkal = 0;
        float _matrixR = 1;
        float _matrixG = 1;
        float _matrixB = 1;
        Boolean _enmatrix = true;


        public CImgButton()
        {
            InitializeComponent();
        }

        public void repar()
        {
            this.Parent.Invalidate(new Rectangle(Left, Top,Width,Height),true);
        }

        public int bkal
        {
            get
            {
                return _bkal;
            }
            set
            {
                _bkal = value;
                repar();

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
                repar();

            }
        }

        public float matrixR
        {
            get
            {
                return _matrixR;
            }
            set
            {
                _matrixR = value;
                bmatrix[0][0] = value;
            }
        }

        public float matrixG
        {
            get
            {
                return _matrixG;
            }
            set
            {
                _matrixG = value;
                bmatrix[1][1] = value;

            }
        }

        public Boolean matrixen
        {
            get
            {
                return _enmatrix;
            }
            set
            {
                _enmatrix = value;

            }
        }

        public float matrixB
        {
            get
            {
                return _matrixB;
            }
            set
            {
                _matrixB = value;
                bmatrix[2][2] = value;

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
                if (_bkal>0)
                {
                    SolidBrush br = new SolidBrush(Color.FromArgb(_bkal, BackColor));
                    e.Graphics.FillRectangle(br, 0, 0, Width, Height);
                    br.Dispose();
                }
                 matrix = new ColorMatrix(tmatrix);
            }
            else
            {
                 matrix = new ColorMatrix(bmatrix);
            }
            
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);    
            e.Graphics.DrawImage(_fimage, new Rectangle(0, 0, Width,Height), 0, 0, _fimage.Width, _fimage.Height, GraphicsUnit.Pixel, attributes);


            // e.Graphics.DrawString(_title, fo, so, new Rectangle(0, Height-20, Width, Height));
        
  
        
        }

        private void UserControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_enmatrix) return;
            if (mon != true)
            {
                mon = true;
                repar(); ;
                //Invalidate();
            }
            
        }

        private void UserControl1_MouseLeave(object sender, EventArgs e)
        {
            if (!_enmatrix) return;
            //pictureBox1.Visible = false;
            mon = false;
            repar();

        }
    }
}
