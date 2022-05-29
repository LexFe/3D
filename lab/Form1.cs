using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;


namespace lab
{
    public partial class Form1 : Form
    {
        double xrot, yrot, zrot;
        double eyeX, eyeY, eyeZ, atX, atY, atZ;

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClearColor(0.8f, 0.8f, 0.8f, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            //Glu.gluLookAt(5, 4, 5, 0, 0, 0, 0, 1, 0);
            Glu.gluLookAt(eyeX, eyeY, eyeZ, atX, atY, atZ, 0, 1, 0);

            Gl.glPushMatrix();
            Gl.glRotated(xrot, 1, 0, 0);
            Gl.glRotated(yrot, 0, 1, 0);
            Gl.glRotated(zrot, 0, 0, 1);

            Gl.glBegin(Gl.GL_LINES);
            //X axis
            Gl.glColor3f(1, 0, 0);
            Gl.glVertex3f(-6, 0, 0);
            Gl.glVertex3f(6, 0, 0);
            //Y axis
            Gl.glColor3f(0, 1, 0);
            Gl.glVertex3f(0, -6, 0);
            Gl.glVertex3f(0, 6, 0);
            //z axis
            Gl.glColor3f(0, 0, 1);
            Gl.glVertex3f(0, 0, -6);
            Gl.glVertex3f(0, 0, 6);
            Gl.glEnd();

            cube();






            Gl.glPopMatrix();

        }

        private void simpleOpenGlControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'i')
            {
                eyeX -= 0.8;
                eyeZ -= 0.8;
            }

            if (e.KeyChar == 'o')
            {
                eyeX += 0.8;
                eyeZ += 0.8;
            }

            if (e.KeyChar == 'x')
                xrot += 15;
            if (e.KeyChar == 'y')
                yrot += 15;
            if (e.KeyChar == 'z')
                zrot += 15;

            simpleOpenGlControl1.Invalidate();

        }

        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            int w = simpleOpenGlControl1.Width;
            int h = simpleOpenGlControl1.Height;
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45.0f, (double)w / h, 0.1f, 5000.0f);
            xrot = yrot = zrot = 0;
            atX = atY = 0; atZ = -1;
            eyeX = eyeZ = 7; eyeY = 4;

        }
        private void cube()
        {
            Gl.glBegin(Gl.GL_POLYGON);
            
            Gl.glColor3f(0.0f, 0.0f, 1.0f);            
            Gl.glVertex3f(3.0f, 3.0f, 3.0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);            
            Gl.glVertex3f(3.0f, -3.0f, 3.0f);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);             
            Gl.glVertex3f(-3.0f, -3.0f, 3.0f);
            Gl.glColor3f(1.0f, 0.0f, 1.0f);     
                                                
            Gl.glVertex3f(-3.0f, 3.0f, 3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.50f, 0.50f, 1.0f);        
            Gl.glVertex3f(3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, -3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);         
            Gl.glVertex3f(3.0f, 3.0f, 3.0f);
            Gl.glVertex3f(3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(3.0f, -3.0f, 3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.50f, 1.0f, 0.50f);
            Gl.glVertex3f(-3.0f, 3.0f, 3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, 3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, -3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(3.0f, 3.0f, 3.0f);
            Gl.glVertex3f(3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, 3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1.0f, 0.50f, 0.50f);
            Gl.glVertex3f(3.0f, -3.0f, 3.0f);
            Gl.glVertex3f(3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, 3.0f);
            Gl.glEnd();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
