using Microsoft.Extensions.Configuration;

namespace DepersonalizationPersonalData
{
    public partial class MainForm : Form
    {
        private readonly IConfiguration _cfg;
        private readonly CurrentSession _currentSession;

        public MainForm(IConfiguration cfg, CurrentSession currentSession)
        {
            InitializeComponent();
            _cfg = cfg;
            _currentSession = currentSession;
            splitContainer3.Panel2Collapsed = true;
        }

        private async void btSignUp_Click(object sender, EventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text.Trim();
            (bool isSuccess, string message) = await _currentSession.ActivateSession(login, password);
            if (isSuccess)
            {
                ChangeStatus(true);
                ShowHideLoginPanel();
            }
            else
                rtbInfo.Text = message;
        }

        private void ShowHideLoginPanel(bool show = false)
        {
            if (show)
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();
                splitContainer3.Panel2Collapsed = true;
                splitContainer3.Panel2.Hide();
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel1.Hide();
                splitContainer3.Panel2Collapsed = false;
                splitContainer3.Panel2.Show();
            }
        }

        private void ChangeStatus(bool signedUp)
        {
            if (signedUp)
            {
                this.Text += " | " + _currentSession!.CurrentUser!.Login;
                tsLabel.Text = _currentSession!.CurrentUser!.Name;
            }
            else
            {
                this.Text = "Обезличивание персональных данных";
                tsLabel.Text = "Войдите в систему";
            }
        }

        private void msChangeUser_Click(object sender, EventArgs e)
        {
            _currentSession.DeActivateSession();
            tbPassword.Text = string.Empty;
            ChangeStatus(false);
            ShowHideLoginPanel(true);
        }
    }
}