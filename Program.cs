using Aibote4Sharp.sdk;

namespace Aibote4Sharp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Form1 form1 = new Form1();
            AndroidClientManager.getInstance().setForm(form1);
            Application.Run(form1);
        }
    }
}