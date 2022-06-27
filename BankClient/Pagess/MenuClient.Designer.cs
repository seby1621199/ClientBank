namespace BankClient.Pagess
{
    partial class MenuClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_menu_buttons = new System.Windows.Forms.Panel();
            this.button_Withdraw = new Guna.UI2.WinForms.Guna2Button();
            this.button_Deposit = new Guna.UI2.WinForms.Guna2Button();
            this.button_Transfer = new Guna.UI2.WinForms.Guna2Button();
            this.Button_Menu = new Guna.UI2.WinForms.Guna2Button();
            this.panel_menu_info = new System.Windows.Forms.Panel();
            this.menu_username = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_content = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel_menu_buttons.SuspendLayout();
            this.panel_menu_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.panel_menu_buttons);
            this.panel1.Controls.Add(this.panel_menu_info);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 426);
            this.panel1.TabIndex = 0;
            // 
            // panel_menu_buttons
            // 
            this.panel_menu_buttons.Controls.Add(this.button_Withdraw);
            this.panel_menu_buttons.Controls.Add(this.button_Deposit);
            this.panel_menu_buttons.Controls.Add(this.button_Transfer);
            this.panel_menu_buttons.Controls.Add(this.Button_Menu);
            this.panel_menu_buttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_menu_buttons.Location = new System.Drawing.Point(0, 93);
            this.panel_menu_buttons.Name = "panel_menu_buttons";
            this.panel_menu_buttons.Size = new System.Drawing.Size(176, 343);
            this.panel_menu_buttons.TabIndex = 1;
            // 
            // button_Withdraw
            // 
            this.button_Withdraw.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_Withdraw.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_Withdraw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_Withdraw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_Withdraw.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Withdraw.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button_Withdraw.ForeColor = System.Drawing.Color.White;
            this.button_Withdraw.Location = new System.Drawing.Point(0, 162);
            this.button_Withdraw.Name = "button_Withdraw";
            this.button_Withdraw.Size = new System.Drawing.Size(176, 54);
            this.button_Withdraw.TabIndex = 3;
            this.button_Withdraw.Text = "Withdraw";
            // 
            // button_Deposit
            // 
            this.button_Deposit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_Deposit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_Deposit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_Deposit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_Deposit.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Deposit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button_Deposit.ForeColor = System.Drawing.Color.White;
            this.button_Deposit.Location = new System.Drawing.Point(0, 108);
            this.button_Deposit.Name = "button_Deposit";
            this.button_Deposit.Size = new System.Drawing.Size(176, 54);
            this.button_Deposit.TabIndex = 2;
            this.button_Deposit.Text = "Deposit";
            // 
            // button_Transfer
            // 
            this.button_Transfer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_Transfer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_Transfer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_Transfer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_Transfer.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Transfer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button_Transfer.ForeColor = System.Drawing.Color.White;
            this.button_Transfer.Location = new System.Drawing.Point(0, 54);
            this.button_Transfer.Name = "button_Transfer";
            this.button_Transfer.Size = new System.Drawing.Size(176, 54);
            this.button_Transfer.TabIndex = 1;
            this.button_Transfer.Text = "Transfer";
            this.button_Transfer.Click += new System.EventHandler(this.but_Click);
            // 
            // Button_Menu
            // 
            this.Button_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Menu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_Menu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_Menu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_Menu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_Menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Menu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Button_Menu.ForeColor = System.Drawing.Color.White;
            this.Button_Menu.Location = new System.Drawing.Point(0, 0);
            this.Button_Menu.Name = "Button_Menu";
            this.Button_Menu.Size = new System.Drawing.Size(176, 54);
            this.Button_Menu.TabIndex = 0;
            this.Button_Menu.Text = "Home";
            this.Button_Menu.CheckedChanged += new System.EventHandler(this.Button_Menu_CheckedChanged);
            this.Button_Menu.Click += new System.EventHandler(this.Button_Menu_Click);
            // 
            // panel_menu_info
            // 
            this.panel_menu_info.Controls.Add(this.menu_username);
            this.panel_menu_info.Controls.Add(this.label1);
            this.panel_menu_info.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_menu_info.Location = new System.Drawing.Point(0, 0);
            this.panel_menu_info.Name = "panel_menu_info";
            this.panel_menu_info.Size = new System.Drawing.Size(176, 93);
            this.panel_menu_info.TabIndex = 0;
            // 
            // menu_username
            // 
            this.menu_username.Dock = System.Windows.Forms.DockStyle.Top;
            this.menu_username.Font = new System.Drawing.Font("Microsoft Uighur", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_username.Location = new System.Drawing.Point(0, 48);
            this.menu_username.Name = "menu_username";
            this.menu_username.Size = new System.Drawing.Size(176, 42);
            this.menu_username.TabIndex = 1;
            this.menu_username.Text = "user";
            this.menu_username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(176, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(790, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 450);
            this.panel2.TabIndex = 1;
            // 
            // panel_content
            // 
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_content.Location = new System.Drawing.Point(197, 0);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(593, 450);
            this.panel_content.TabIndex = 2;
            // 
            // MenuClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_content);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuClient";
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.panel_menu_buttons.ResumeLayout(false);
            this.panel_menu_info.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_menu_buttons;
        private Guna.UI2.WinForms.Guna2Button Button_Menu;
        private System.Windows.Forms.Panel panel_menu_info;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button button_Withdraw;
        private Guna.UI2.WinForms.Guna2Button button_Deposit;
        private Guna.UI2.WinForms.Guna2Button button_Transfer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label menu_username;
        private System.Windows.Forms.Panel panel_content;
    }
}