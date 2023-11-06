namespace DepersonalizationPersonalData
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            tsLabel = new ToolStripStatusLabel();
            tsLabelPermissions = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            msChangeUser = new ToolStripMenuItem();
            оПрограмеToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            tbPassword = new MaskedTextBox();
            btSignUp = new Button();
            label2 = new Label();
            label1 = new Label();
            tbLogin = new TextBox();
            rtbInfo = new RichTextBox();
            splitContainer3 = new SplitContainer();
            dgvPersonalizeData = new DataGridView();
            splitContainer4 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            tbLastName = new TextBox();
            label4 = new Label();
            tbFirstName = new TextBox();
            label5 = new Label();
            tbMiddleName = new TextBox();
            label6 = new Label();
            tbBirthday = new TextBox();
            label7 = new Label();
            tbCountry = new TextBox();
            label8 = new Label();
            tbArea = new TextBox();
            label9 = new Label();
            tbCity = new TextBox();
            label10 = new Label();
            tbStreet = new TextBox();
            label11 = new Label();
            tbHome = new TextBox();
            label12 = new Label();
            tbBuilding = new TextBox();
            label13 = new Label();
            tbFlat = new TextBox();
            label14 = new Label();
            tbPhone = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btDelete = new Button();
            btSave = new Button();
            btAdd = new Button();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonalizeData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsLabel, tsLabelPermissions });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1101, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsLabel
            // 
            tsLabel.Name = "tsLabel";
            tsLabel.Size = new Size(109, 17);
            tsLabel.Text = "Войдите в систему";
            // 
            // tsLabelPermissions
            // 
            tsLabelPermissions.Name = "tsLabelPermissions";
            tsLabelPermissions.Size = new Size(0, 17);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { настройкиToolStripMenuItem, оПрограмеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1101, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { msChangeUser });
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(79, 20);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // msChangeUser
            // 
            msChangeUser.Name = "msChangeUser";
            msChangeUser.Size = new Size(200, 22);
            msChangeUser.Text = "Сменить пользователя";
            msChangeUser.Click += msChangeUser_Click;
            // 
            // оПрограмеToolStripMenuItem
            // 
            оПрограмеToolStripMenuItem.Name = "оПрограмеToolStripMenuItem";
            оПрограмеToolStripMenuItem.Size = new Size(85, 20);
            оПрограмеToolStripMenuItem.Text = "О програме";
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer3);
            splitContainer1.Size = new Size(1101, 404);
            splitContainer1.SplitterDistance = 240;
            splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tbPassword);
            splitContainer2.Panel1.Controls.Add(btSignUp);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Controls.Add(tbLogin);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(rtbInfo);
            splitContainer2.Size = new Size(240, 404);
            splitContainer2.SplitterDistance = 180;
            splitContainer2.TabIndex = 0;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(12, 98);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '•';
            tbPassword.Size = new Size(216, 23);
            tbPassword.TabIndex = 1;
            // 
            // btSignUp
            // 
            btSignUp.Location = new Point(12, 141);
            btSignUp.Name = "btSignUp";
            btSignUp.Size = new Size(216, 23);
            btSignUp.TabIndex = 3;
            btSignUp.Text = "Войти";
            btSignUp.UseVisualStyleBackColor = true;
            btSignUp.Click += btSignUp_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 3;
            label2.Text = "Пароль";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 1;
            label1.Text = "Логин";
            // 
            // tbLogin
            // 
            tbLogin.Location = new Point(12, 45);
            tbLogin.Name = "tbLogin";
            tbLogin.Size = new Size(216, 23);
            tbLogin.TabIndex = 0;
            // 
            // rtbInfo
            // 
            rtbInfo.BackColor = SystemColors.Control;
            rtbInfo.Dock = DockStyle.Fill;
            rtbInfo.Location = new Point(0, 0);
            rtbInfo.Name = "rtbInfo";
            rtbInfo.ReadOnly = true;
            rtbInfo.Size = new Size(236, 216);
            rtbInfo.TabIndex = 0;
            rtbInfo.Text = "";
            // 
            // splitContainer3
            // 
            splitContainer3.BorderStyle = BorderStyle.Fixed3D;
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.FixedPanel = FixedPanel.Panel2;
            splitContainer3.IsSplitterFixed = true;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(dgvPersonalizeData);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer4);
            splitContainer3.Size = new Size(857, 404);
            splitContainer3.SplitterDistance = 579;
            splitContainer3.TabIndex = 2;
            // 
            // dgvPersonalizeData
            // 
            dgvPersonalizeData.AllowUserToAddRows = false;
            dgvPersonalizeData.AllowUserToDeleteRows = false;
            dgvPersonalizeData.BackgroundColor = Color.AliceBlue;
            dgvPersonalizeData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonalizeData.Dock = DockStyle.Fill;
            dgvPersonalizeData.Location = new Point(0, 0);
            dgvPersonalizeData.Name = "dgvPersonalizeData";
            dgvPersonalizeData.ReadOnly = true;
            dgvPersonalizeData.RowTemplate.Height = 25;
            dgvPersonalizeData.Size = new Size(575, 400);
            dgvPersonalizeData.TabIndex = 1;
            dgvPersonalizeData.CellClick += dgvPersonalizeData_CellClick;
            // 
            // splitContainer4
            // 
            splitContainer4.BorderStyle = BorderStyle.Fixed3D;
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.FixedPanel = FixedPanel.Panel2;
            splitContainer4.IsSplitterFixed = true;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer4.Size = new Size(274, 404);
            splitContainer4.SplitterDistance = 367;
            splitContainer4.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(tbLastName);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(tbFirstName);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(tbMiddleName);
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Controls.Add(tbBirthday);
            flowLayoutPanel1.Controls.Add(label7);
            flowLayoutPanel1.Controls.Add(tbCountry);
            flowLayoutPanel1.Controls.Add(label8);
            flowLayoutPanel1.Controls.Add(tbArea);
            flowLayoutPanel1.Controls.Add(label9);
            flowLayoutPanel1.Controls.Add(tbCity);
            flowLayoutPanel1.Controls.Add(label10);
            flowLayoutPanel1.Controls.Add(tbStreet);
            flowLayoutPanel1.Controls.Add(label11);
            flowLayoutPanel1.Controls.Add(tbHome);
            flowLayoutPanel1.Controls.Add(label12);
            flowLayoutPanel1.Controls.Add(tbBuilding);
            flowLayoutPanel1.Controls.Add(label13);
            flowLayoutPanel1.Controls.Add(tbFlat);
            flowLayoutPanel1.Controls.Add(label14);
            flowLayoutPanel1.Controls.Add(tbPhone);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(270, 363);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 4;
            label3.Text = "Фамилия";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(3, 23);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(247, 23);
            tbLastName.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 49);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 5;
            label4.Text = "Имя";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(3, 72);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(247, 23);
            tbFirstName.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 98);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 7;
            label5.Text = "Отчество";
            // 
            // tbMiddleName
            // 
            tbMiddleName.Location = new Point(3, 121);
            tbMiddleName.Name = "tbMiddleName";
            tbMiddleName.Size = new Size(247, 23);
            tbMiddleName.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 147);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 9;
            label6.Text = "Дата рождения";
            // 
            // tbBirthday
            // 
            tbBirthday.Location = new Point(3, 170);
            tbBirthday.Name = "tbBirthday";
            tbBirthday.PlaceholderText = "ДД.ММ.ГГГГ";
            tbBirthday.Size = new Size(247, 23);
            tbBirthday.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(3, 196);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 11;
            label7.Text = "Страна";
            // 
            // tbCountry
            // 
            tbCountry.Location = new Point(3, 219);
            tbCountry.Name = "tbCountry";
            tbCountry.Size = new Size(247, 23);
            tbCountry.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(3, 245);
            label8.Name = "label8";
            label8.Size = new Size(66, 20);
            label8.TabIndex = 13;
            label8.Text = "Область";
            // 
            // tbArea
            // 
            tbArea.Location = new Point(3, 268);
            tbArea.Name = "tbArea";
            tbArea.Size = new Size(247, 23);
            tbArea.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(3, 294);
            label9.Name = "label9";
            label9.Size = new Size(51, 20);
            label9.TabIndex = 15;
            label9.Text = "Город";
            // 
            // tbCity
            // 
            tbCity.Location = new Point(3, 317);
            tbCity.Name = "tbCity";
            tbCity.Size = new Size(247, 23);
            tbCity.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(3, 343);
            label10.Name = "label10";
            label10.Size = new Size(52, 20);
            label10.TabIndex = 17;
            label10.Text = "Улица";
            // 
            // tbStreet
            // 
            tbStreet.Location = new Point(3, 366);
            tbStreet.Name = "tbStreet";
            tbStreet.Size = new Size(247, 23);
            tbStreet.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(3, 392);
            label11.Name = "label11";
            label11.Size = new Size(39, 20);
            label11.TabIndex = 19;
            label11.Text = "Дом";
            // 
            // tbHome
            // 
            tbHome.Location = new Point(3, 415);
            tbHome.Name = "tbHome";
            tbHome.Size = new Size(247, 23);
            tbHome.TabIndex = 20;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(3, 441);
            label12.Name = "label12";
            label12.Size = new Size(59, 20);
            label12.TabIndex = 21;
            label12.Text = "Корпус";
            // 
            // tbBuilding
            // 
            tbBuilding.Location = new Point(3, 464);
            tbBuilding.Name = "tbBuilding";
            tbBuilding.Size = new Size(247, 23);
            tbBuilding.TabIndex = 22;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(3, 490);
            label13.Name = "label13";
            label13.Size = new Size(75, 20);
            label13.TabIndex = 23;
            label13.Text = "Квартира";
            // 
            // tbFlat
            // 
            tbFlat.Location = new Point(3, 513);
            tbFlat.Name = "tbFlat";
            tbFlat.Size = new Size(247, 23);
            tbFlat.TabIndex = 24;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(3, 539);
            label14.Name = "label14";
            label14.Size = new Size(69, 20);
            label14.TabIndex = 25;
            label14.Text = "Телефон";
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(3, 562);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(247, 23);
            tbPhone.TabIndex = 26;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(btDelete, 2, 0);
            tableLayoutPanel1.Controls.Add(btSave, 1, 0);
            tableLayoutPanel1.Controls.Add(btAdd, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(270, 29);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btDelete
            // 
            btDelete.Dock = DockStyle.Fill;
            btDelete.Location = new Point(183, 3);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(84, 23);
            btDelete.TabIndex = 2;
            btDelete.Text = "Удалить";
            btDelete.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            btSave.Dock = DockStyle.Fill;
            btSave.Location = new Point(93, 3);
            btSave.Name = "btSave";
            btSave.Size = new Size(84, 23);
            btSave.TabIndex = 1;
            btSave.Text = "Сохранить";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btAdd
            // 
            btAdd.Dock = DockStyle.Fill;
            btAdd.Location = new Point(3, 3);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(84, 23);
            btAdd.TabIndex = 0;
            btAdd.Text = "Добавить";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 450);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Обезличивание персональных данных";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPersonalizeData).EndInit();
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem войтиToolStripMenuItem;
        private ToolStripMenuItem msChangeUser;
        private ToolStripMenuItem оПрограмеToolStripMenuItem;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Button btSignUp;
        private Label label2;
        private Label label1;
        private TextBox tbLogin;
        private RichTextBox rtbInfo;
        private DataGridView dgvPersonalizeData;
        private MaskedTextBox tbPassword;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btDelete;
        private Button btSave;
        private Button btAdd;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private TextBox tbLastName;
        private Label label4;
        private TextBox tbFirstName;
        private Label label5;
        private TextBox tbMiddleName;
        private Label label6;
        private TextBox tbBirthday;
        private Label label7;
        private TextBox tbCountry;
        private Label label8;
        private TextBox tbArea;
        private Label label9;
        private TextBox tbCity;
        private Label label10;
        private TextBox tbStreet;
        private Label label11;
        private TextBox tbHome;
        private Label label12;
        private TextBox tbBuilding;
        private Label label13;
        private TextBox tbFlat;
        private Label label14;
        private TextBox tbPhone;
        private ToolStripStatusLabel tsLabelPermissions;
    }
}