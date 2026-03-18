namespace it_company
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);

            bool exitProgram = false;
            while (!exitProgram)
            {
                using (var formLogin = new FormLogin()) 
                {
                    if (formLogin.ShowDialog() == DialogResult.OK)
                    {
                        using (var formorder = new FormOrder(
                            formLogin.CurrentUser,
                            formLogin.isGuest))
                        {
                            if (formorder.ShowDialog() == DialogResult.Cancel)
                            {
                                continue;
                            }
                            else
                            {
                                exitProgram = true;
                            }
                        }
                        ;

                    }
                    else
                    {
                        exitProgram = true;
                    }
                }
            }
        }
    }
}