using System;
using System.Drawing;
using System.Windows.Forms;

namespace Store_X_s_Sales_Management_System.Forms.Shared
{
    public class FormConfirmPassword : Form
    {
        private Label lblMessage;
        private TextBox txtPassword;
        private Button btnOK;
        private Button btnCancel;
        public string Password { get; private set; }

        public FormConfirmPassword(string message = "Enter Admin Password to confirm:")
        {
            InitializeComponent(message);
        }

        private void InitializeComponent(string message)
        {
            this.lblMessage = new Label();
            this.txtPassword = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // Form settings
            this.Text = "Security Check";
            this.Size = new Size(350, 180);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label
            this.lblMessage.Text = message;
            this.lblMessage.Location = new Point(20, 20);
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // TextBox
            this.txtPassword.Location = new Point(20, 50);
            this.txtPassword.Size = new Size(290, 30);
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Font = new Font("Segoe UI", 10F);
            this.txtPassword.KeyDown += TxtPassword_KeyDown;

            // Button OK
            this.btnOK.Text = "Confirm";
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(140, 100);
            this.btnOK.Size = new Size(80, 30);
            this.btnOK.BackColor = Color.FromArgb(220, 53, 69); // Danger color
            this.btnOK.ForeColor = Color.White;
            this.btnOK.FlatStyle = FlatStyle.Flat;
            this.btnOK.Click += BtnOK_Click;

            // Button Cancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(230, 100);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.Click += (s, e) => this.Close();

            // Add controls
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                this.DialogResult = DialogResult.None; // Prevent closing
                return;
            }
            this.Password = txtPassword.Text; // Store password
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
