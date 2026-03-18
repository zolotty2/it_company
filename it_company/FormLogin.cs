namespace it_company
{
    public partial class FormLogin : Form
    {
        public User CurrentUser;
        public bool isGuest = false;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
        private void BtnLogin_click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(LoginTxt.Text) || String.IsNullOrEmpty(PasswordTxt.Text))
            {
                MessageBox.Show("¬ведите логин или пароль", "ќшибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (var db = new ItComContext())
                {
                    var user = db.Users.Where(w => w.Email == LoginTxt.Text && w.Password == PasswordTxt.Text).FirstOrDefault();

                    if (user != null)
                    {
                        CurrentUser = user;

                        isGuest = false;

                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
            }
        }

        private void GuestBtn_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            isGuest = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
