using System.Runtime.InteropServices;
namespace MouseMoving
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Opacity = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MoveMous(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
        }
        private void MoveMous(int screenWidth, int screenHeight)
        {
            POINT p= new POINT();
            Random r = new Random();
            int c = 0;
            while(true)
            {
                p.x = Convert.ToInt16(r.Next(screenWidth));
                p.y = Convert.ToInt16(r.Next(screenHeight));
                ClientToScreen(Handle, ref p);
                SetCursorPos(p.x, p.y);
                c++;
                Thread.Sleep(300);
                if (c == 500) break;
            }
        }
        [DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWhd, ref POINT point);
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
    }
}
