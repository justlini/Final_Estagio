using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;

namespace CS_RFID3_Host_Sample2
{
    public partial class LoginForm : Form
    {
        private AppForm m_AppForm;

        public LoginForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
        }

        public void clearPassword()
        {
            password_TB.Clear();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            readerType_CB.SelectedIndex = 1;
            hostname_TB.Text = m_AppForm.m_ConnectionForm.hostname_TB.Text;
            forceLogin_CB.Checked = true;
        }

        private void loginApplyButton_Click(object sender, EventArgs e)
        {
            bool closeForm = false;
            try
            {
                if (loginButton.Text == "Login")
                {
                    LoginInfo info = new LoginInfo();
                    info.HostName = hostname_TB.Text;
                    info.UserName = username_TB.Text;
                    info.Password = password_TB.Text;
                    info.SecureMode = SECURE_MODE.HTTP;
                    info.ForceLogin = forceLogin_CB.Checked;
                    m_AppForm.m_ReaderMgmt.Login(info, (READER_TYPE)readerType_CB.SelectedIndex);

                    if (null != this.m_AppForm.m_FirmwareUpdateForm)
                    {
                        this.m_AppForm.m_FirmwareUpdateForm.Reset();
                    }
                    m_AppForm.functionCallStatusLabel.Text = "Login Succeded";
                    m_AppForm.m_ReaderType = (READER_TYPE)readerType_CB.SelectedIndex;
                    loginButton.Text = "Logout";
                    closeForm = true;
                }
                else if (loginButton.Text == "Logout")
                {
                    loginButton.Text = "Login";
                    closeForm = true;
                    m_AppForm.m_ReaderMgmt.Logout();
                    m_AppForm.functionCallStatusLabel.Text = "Logout Succeded";
                }
            }
            catch (OperationFailureException ofe)
            {
                m_AppForm.functionCallStatusLabel.Text = loginButton.Text + " : " + ofe.StatusDescription;
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = loginButton.Text + " : " + ex.Message;
            }
            hostname_TB.Enabled = username_TB.Enabled = password_TB.Enabled =
                readerType_CB.Enabled = (loginButton.Text == "Login");
            m_AppForm.configureMenuItemsUponLoginLogout();
            if (closeForm)
                this.Close();
        }

        private void readerType_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isMCType = ((READER_TYPE)readerType_CB.SelectedIndex == READER_TYPE.MC);
            username_TB.Enabled = !isMCType;
            password_TB.Enabled = !isMCType;
            forceLogin_CB.Enabled = ((READER_TYPE)readerType_CB.SelectedIndex == READER_TYPE.FX);
        }

        private void forceLogin_CB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}