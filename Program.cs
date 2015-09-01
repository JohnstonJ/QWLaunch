using System;
using System.Reflection;
using System.Windows.Media;

// Don't allow WPF to declare us DPI aware
[assembly: DisableDpiAwareness]

namespace QWLaunch {
	class Program {
		// Avoid initializing any system libraries like WPF or WinForms by using Win32 API directly...
		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);
		[STAThread]
		public static int Main(string[] args) {
			try {
				Assembly asm = Assembly.Load("qw");
				Type t = asm.GetType("QuickenWindow.Program");
				MethodInfo m = t.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Static);
				m.Invoke(null, null);
				return 0;
			} catch (Exception ex) {
				MessageBox(IntPtr.Zero, ex.ToString(), "QWLaunch error", 0);
				return 1;
			}
		}
	}
}
