using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hola_mundo.shaders;
//openTK
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Hola_mundo.models
{
    public class Game : GameWindow
    {    
        /*
        private float[] vertices = {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
             0.5f, -0.5f, 0.0f, //Bottom-right vertex
             0.0f,  0.5f, 0.0f  //Top vertex
        };
        int VertexBufferObject; // id VertexBufferObject
        int VertexArrayObject; //      VAO
        */
        // shaders
        Shader shader;
        Triangle t1;
        Triangle t2;
        Triangle t3;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            Run(60.0);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            base.OnUpdateFrame(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            t1 = new Triangle(new Point(0.5f, 0.5f, 0.5f), 0.5f, 0.5f, 0.5f, 1f);
            t2 = new Triangle(new Point(-0.5f, -0.5f, 0.5f), 0.5f, 0.5f, 0.5f, 0.5f);
            t3 = new Triangle(new Point(-0.5f, 0.5f, 0.5f), 0.5f, 0.5f, 0.5f, 0.7f);
            /*
            VertexBufferObject = GL.GenBuffer();
            shader = new Shader("shader.vert", "shader.frag");
            VertexArrayObject = GL.GenVertexArray();
            
            // 1. bind Vertex Array Object
            GL.BindVertexArray(VertexArrayObject);
            // 2. copy our vertices array in a buffer for OpenGL to use
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            // 3. then set our vertex attributes pointers
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            */
            base.OnLoad(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Code goes here.
            //shader.Use();
            this.t1.draw();
            this.t2.draw();
            this.t3.draw();
            /*
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3); */
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
        protected override void OnUnload(EventArgs e)
        {   //clear buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            //shader.Dispose();
            base.OnUnload(e);
        }
    }
}
