using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Domain_User_Edit
{
    public partial class Form1 : Form
    {
        private string LDAPDomainName = string.Empty;
        private string username = string.Empty;
        private DirectoryEntry user;
        private string bottomMessage = string.Empty;
        private string fullname = String.Empty;
        //IntPtr accessToken = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();

            //Tools.Network.Impersonator impersonate = new Tools.Network.Impersonator();
            //impersonate.Impersonate("diablo666", "INTERNET.LOCAL", "diablo666**", Tools.Network.LogonType.LOGON32_LOGON_NEW_CREDENTIALS, Tools.Network.LogonProvider.LOGON32_PROVIDER_WINNT50);

            if (!CheckIfInDomain())
            {
                MessageBox.Show("You are not part of a domain.\nThis application will now terminate.");
                Environment.Exit(1);
            }

            LDAPDomainName = GetDomainDN(IPGlobalProperties.GetIPGlobalProperties().DomainName);

            lblUser.Text = string.Empty;
            lblIsLocked.Text = string.Empty;
            tssMain.Text = String.Empty;
        }

        public bool CheckIfInDomain()
        {
            bool isInDomain = true;

            try
            {
                Domain.GetComputerDomain();
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                isInDomain = false;
            }

            return isInDomain;
        }

        private string GetDomainDN(string domain)
        {
            DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain, domain);
            Domain d = Domain.GetDomain(context);
            DirectoryEntry de = d.GetDirectoryEntry();
            return de.Properties["DistinguishedName"].Value.ToString();
        }

        private void btnGetUser_Click(object sender, EventArgs e)
        {
            GetUser();
        }

        private void GetUser()
        {
            tssMain.Text = string.Empty;

            if (UserExists(txtUsername.Text))
            {
                username = txtUsername.Text;

                user = GetUser(username);

                fullname = String.Format("{0} {1}", user.Properties["givenName"].Value.ToString(), user.Properties["sn"].Value.ToString());
                lblUser.Text = fullname;
                chkbxUnlock.Enabled = true;
                txtNewPassword.Enabled = true;
                btnReset.Enabled = true;
                txtNewPassword.Focus();
                IsUserLocked();
            }
            else
            {
                lblUser.Text = string.Empty;
                SetMessage("User doesn't exist.");
                chkbxUnlock.Enabled = false;
                txtNewPassword.Enabled = false;
                txtNewPassword.Text = string.Empty;
                btnReset.Enabled = false;
                lblIsLocked.Text = string.Empty;
            }
        }

        public DirectoryEntry GetUser(string userName)
        {
            DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + LDAPDomainName);
            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
            directorySearcher.Filter = "(&(objectCategory=person)(sAMAccountName=" + userName + "))";
            DirectoryEntry result = directorySearcher.FindOne().GetDirectoryEntry();
            return result;
        }

        public static bool UserExists(string userName)
        {
            using (var pc = new PrincipalContext(ContextType.Domain))
            using (var p = Principal.FindByIdentity(pc, IdentityType.SamAccountName, userName))
            {
                return p != null;
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ChangeUser();
        }
        private void SetMessage(string message)
        {
            tssMain.Text = message;
        }
        private void ChangeUser()
        {
            tssMain.Text = string.Empty;
            bool error = false;

            if (chkbxUnlock.Checked)
                user.Properties["LockOutTime"].Value = 0;
            
            if (txtNewPassword.Text != string.Empty)
                error = ChangePassword();

            try
            {
                user.CommitChanges();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have sufficient permissions to do this");
                this.Close();
                Application.Exit();
                throw;
            }

            IsUserLocked();

            if (!error)
            {
                txtUsername.Focus();
                txtUsername.SelectAll();
            }
        }

        private bool ChangePassword()
        {
            int counter = 0;
            bool error = true;
            bool nameError = false;
            string newPassword = txtNewPassword.Text;

            Regex hasCapitalLetter = new Regex("[A-Z]");
            Regex hasSmallLetter = new Regex("[a-z]");
            Regex hasNumber = new Regex("[0-9]");
            Regex hasSpecialChar = new Regex(@"[\W]");

            if (hasCapitalLetter.IsMatch(newPassword)) { counter++; }
            if (hasSmallLetter.IsMatch(newPassword)) { counter++; }
            if (hasNumber.IsMatch(newPassword)) { counter++; }
            if (hasSpecialChar.IsMatch(newPassword)) { counter++; }

            foreach (string part in fullname.Split(' '))
            {
                if (newPassword.ToLower().Contains(part.ToLower()))
                    nameError = true;
            }

            if (newPassword.Length < 8)
                SetMessage("Password must be at least 8 characters");
            else if (nameError)
                SetMessage("Password can't contain parts of the name");
            else
            {
                if (counter >= 3)
                {
                    user.Invoke("SetPassword", new object[] { newPassword });
                    user.Properties["pwdLastSet"].Value = 0;

                    SetMessage("Password changed");

                    error = false;
                }
                else
                    SetMessage("The password doesn't meet the policy");
            }

            return error;
        }

        public void IsUserLocked()
        {
            lblIsLocked.Text = Convert.ToBoolean(user.InvokeGet("IsAccountLocked")) ? "Locked" : "Unlocked";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                if (txtUsername.Focused)
                    GetUser();
                else if (txtNewPassword.Focused)
                    ChangeUser();

                return true;
            }

            if (keyData == Keys.F1)
                ShowHelp();

            if (keyData == Keys.F2)
            {
                txtUsername.Focus();
                txtUsername.SelectAll();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowHelp()
        {
            MessageBox.Show("Made by Stiig Gade\nF1 shows help (this)\nF2 goes to username-box\nEsc closes\nVersion " + ProductVersion);
        }

        private void lnklblHelp_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }
    }
}