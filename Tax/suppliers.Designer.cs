namespace Tax
{
    partial class suppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(suppliers));
            this.supcd = new System.Windows.Forms.TextBox();
            this.supnm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panbutt_Nav = new System.Windows.Forms.Panel();
            this.prv = new System.Windows.Forms.Button();
            this.frst = new System.Windows.Forms.Button();
            this.panButt = new System.Windows.Forms.Panel();
            this.useradd = new System.Windows.Forms.Button();
            this.useredit = new System.Windows.Forms.Button();
            this.userdelete = new System.Windows.Forms.Button();
            this.userfind = new System.Windows.Forms.Button();
            this.nxt = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.lst = new System.Windows.Forms.Button();
            this.panSav = new System.Windows.Forms.Panel();
            this.save = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.taxknd = new System.Windows.Forms.ComboBox();
            this.taxcd = new System.Windows.Forms.TextBox();
            this.rprt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.taxfileNo = new System.Windows.Forms.MaskedTextBox();
            this.taxrecNo = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltxdep = new System.Windows.Forms.Label();
            this.cbBxtxdp = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panbutt_Nav.SuspendLayout();
            this.panButt.SuspendLayout();
            this.panSav.SuspendLayout();
            this.SuspendLayout();
            // 
            // supcd
            // 
            this.supcd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.supcd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supcd.Location = new System.Drawing.Point(135, 14);
            this.supcd.MaxLength = 5;
            this.supcd.Name = "supcd";
            this.supcd.ReadOnly = true;
            this.supcd.Size = new System.Drawing.Size(106, 26);
            this.supcd.TabIndex = 0;
            this.supcd.Validated += new System.EventHandler(this.supcd_Validated);
            // 
            // supnm
            // 
            this.supnm.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.supnm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supnm.Location = new System.Drawing.Point(135, 45);
            this.supnm.Name = "supnm";
            this.supnm.ReadOnly = true;
            this.supnm.Size = new System.Drawing.Size(365, 26);
            this.supnm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "كود المورد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "اسم المورد";
            // 
            // panbutt_Nav
            // 
            this.panbutt_Nav.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panbutt_Nav.Controls.Add(this.prv);
            this.panbutt_Nav.Controls.Add(this.frst);
            this.panbutt_Nav.Controls.Add(this.panButt);
            this.panbutt_Nav.Controls.Add(this.nxt);
            this.panbutt_Nav.Controls.Add(this.exit);
            this.panbutt_Nav.Controls.Add(this.lst);
            this.panbutt_Nav.Location = new System.Drawing.Point(2, 216);
            this.panbutt_Nav.Name = "panbutt_Nav";
            this.panbutt_Nav.Size = new System.Drawing.Size(679, 60);
            this.panbutt_Nav.TabIndex = 4;
            // 
            // prv
            // 
            this.prv.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prv.Image = ((System.Drawing.Image)(resources.GetObject("prv.Image")));
            this.prv.Location = new System.Drawing.Point(141, 5);
            this.prv.Name = "prv";
            this.prv.Size = new System.Drawing.Size(69, 50);
            this.prv.TabIndex = 15;
            this.prv.UseVisualStyleBackColor = true;
            this.prv.Click += new System.EventHandler(this.prv_Click);
            // 
            // frst
            // 
            this.frst.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frst.Image = ((System.Drawing.Image)(resources.GetObject("frst.Image")));
            this.frst.Location = new System.Drawing.Point(214, 6);
            this.frst.Name = "frst";
            this.frst.Size = new System.Drawing.Size(69, 50);
            this.frst.TabIndex = 14;
            this.frst.UseVisualStyleBackColor = true;
            this.frst.Click += new System.EventHandler(this.frst_Click);
            // 
            // panButt
            // 
            this.panButt.Controls.Add(this.useradd);
            this.panButt.Controls.Add(this.useredit);
            this.panButt.Controls.Add(this.userdelete);
            this.panButt.Controls.Add(this.userfind);
            this.panButt.Location = new System.Drawing.Point(398, 3);
            this.panButt.Name = "panButt";
            this.panButt.Size = new System.Drawing.Size(281, 58);
            this.panButt.TabIndex = 20;
            // 
            // useradd
            // 
            this.useradd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useradd.Image = ((System.Drawing.Image)(resources.GetObject("useradd.Image")));
            this.useradd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.useradd.Location = new System.Drawing.Point(208, 2);
            this.useradd.Name = "useradd";
            this.useradd.Size = new System.Drawing.Size(69, 50);
            this.useradd.TabIndex = 9;
            this.useradd.Text = "إضافة";
            this.useradd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.useradd.UseVisualStyleBackColor = true;
            this.useradd.Click += new System.EventHandler(this.useradd_Click);
            // 
            // useredit
            // 
            this.useredit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useredit.Image = ((System.Drawing.Image)(resources.GetObject("useredit.Image")));
            this.useredit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.useredit.Location = new System.Drawing.Point(138, 2);
            this.useredit.Name = "useredit";
            this.useredit.Size = new System.Drawing.Size(69, 50);
            this.useredit.TabIndex = 10;
            this.useredit.Text = "تعديل";
            this.useredit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.useredit.UseVisualStyleBackColor = true;
            this.useredit.Click += new System.EventHandler(this.useredit_Click);
            // 
            // userdelete
            // 
            this.userdelete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userdelete.Image = ((System.Drawing.Image)(resources.GetObject("userdelete.Image")));
            this.userdelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.userdelete.Location = new System.Drawing.Point(69, 2);
            this.userdelete.Name = "userdelete";
            this.userdelete.Size = new System.Drawing.Size(69, 50);
            this.userdelete.TabIndex = 11;
            this.userdelete.Text = "حذف";
            this.userdelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.userdelete.UseVisualStyleBackColor = true;
            this.userdelete.Click += new System.EventHandler(this.userdelete_Click);
            // 
            // userfind
            // 
            this.userfind.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userfind.Image = ((System.Drawing.Image)(resources.GetObject("userfind.Image")));
            this.userfind.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.userfind.Location = new System.Drawing.Point(-1, 2);
            this.userfind.Name = "userfind";
            this.userfind.Size = new System.Drawing.Size(69, 50);
            this.userfind.TabIndex = 12;
            this.userfind.Text = "بحث F10";
            this.userfind.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.userfind.UseVisualStyleBackColor = true;
            this.userfind.Click += new System.EventHandler(this.userfind_Click);
            // 
            // nxt
            // 
            this.nxt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nxt.Image = ((System.Drawing.Image)(resources.GetObject("nxt.Image")));
            this.nxt.Location = new System.Drawing.Point(72, 5);
            this.nxt.Name = "nxt";
            this.nxt.Size = new System.Drawing.Size(69, 50);
            this.nxt.TabIndex = 16;
            this.nxt.UseVisualStyleBackColor = true;
            this.nxt.Click += new System.EventHandler(this.nxt_Click);
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Image = ((System.Drawing.Image)(resources.GetObject("exit.Image")));
            this.exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exit.Location = new System.Drawing.Point(328, 6);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(69, 50);
            this.exit.TabIndex = 13;
            this.exit.Text = "خروج";
            this.exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // lst
            // 
            this.lst.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst.Image = ((System.Drawing.Image)(resources.GetObject("lst.Image")));
            this.lst.Location = new System.Drawing.Point(3, 6);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(68, 50);
            this.lst.TabIndex = 17;
            this.lst.UseVisualStyleBackColor = true;
            this.lst.Click += new System.EventHandler(this.lst_Click);
            // 
            // panSav
            // 
            this.panSav.BackColor = System.Drawing.Color.Firebrick;
            this.panSav.Controls.Add(this.save);
            this.panSav.Controls.Add(this.back);
            this.panSav.Location = new System.Drawing.Point(258, 218);
            this.panSav.Name = "panSav";
            this.panSav.Size = new System.Drawing.Size(169, 53);
            this.panSav.TabIndex = 24;
            this.panSav.Visible = false;
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save.Location = new System.Drawing.Point(87, 3);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(73, 40);
            this.save.TabIndex = 73;
            this.save.Text = "حفظ";
            this.save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.back.Location = new System.Drawing.Point(8, 3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(73, 40);
            this.back.TabIndex = 74;
            this.back.Text = "الغاء";
            this.back.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 19);
            this.label14.TabIndex = 27;
            this.label14.Text = "نوع الضريبة";
            // 
            // taxknd
            // 
            this.taxknd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.taxknd.Enabled = false;
            this.taxknd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taxknd.FormattingEnabled = true;
            this.taxknd.Location = new System.Drawing.Point(135, 79);
            this.taxknd.Name = "taxknd";
            this.taxknd.Size = new System.Drawing.Size(177, 27);
            this.taxknd.TabIndex = 2;
            this.taxknd.SelectedIndexChanged += new System.EventHandler(this.taxknd_SelectedIndexChanged);
            // 
            // taxcd
            // 
            this.taxcd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.taxcd.Enabled = false;
            this.taxcd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taxcd.Location = new System.Drawing.Point(150, 80);
            this.taxcd.MaxLength = 3;
            this.taxcd.Name = "taxcd";
            this.taxcd.ReadOnly = true;
            this.taxcd.Size = new System.Drawing.Size(36, 26);
            this.taxcd.TabIndex = 28;
            this.taxcd.TabStop = false;
            this.taxcd.TextChanged += new System.EventHandler(this.taxcd_TextChanged);
            // 
            // rprt
            // 
            this.rprt.BackColor = System.Drawing.Color.DarkTurquoise;
            this.rprt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rprt.Location = new System.Drawing.Point(506, 40);
            this.rprt.Name = "rprt";
            this.rprt.Size = new System.Drawing.Size(172, 33);
            this.rprt.TabIndex = 29;
            this.rprt.Text = "البيانات الاساسية للمولين";
            this.rprt.UseVisualStyleBackColor = false;
            this.rprt.Click += new System.EventHandler(this.rprt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = " رقم الملف الضريبي";
            // 
            // taxfileNo
            // 
            this.taxfileNo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.taxfileNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taxfileNo.Location = new System.Drawing.Point(135, 112);
            this.taxfileNo.Name = "taxfileNo";
            this.taxfileNo.ReadOnly = true;
            this.taxfileNo.Size = new System.Drawing.Size(177, 26);
            this.taxfileNo.TabIndex = 3;
            this.taxfileNo.Validated += new System.EventHandler(this.taxfileNo_Validated);
            // 
            // taxrecNo
            // 
            this.taxrecNo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.taxrecNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taxrecNo.Location = new System.Drawing.Point(135, 146);
            this.taxrecNo.Name = "taxrecNo";
            this.taxrecNo.ReadOnly = true;
            this.taxrecNo.Size = new System.Drawing.Size(177, 26);
            this.taxrecNo.TabIndex = 4;
            this.taxrecNo.Validated += new System.EventHandler(this.taxrecNo_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 19);
            this.label4.TabIndex = 33;
            this.label4.Text = " رقم التسجيل الضريبي";
            // 
            // lbltxdep
            // 
            this.lbltxdep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltxdep.AutoSize = true;
            this.lbltxdep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltxdep.Location = new System.Drawing.Point(6, 181);
            this.lbltxdep.Name = "lbltxdep";
            this.lbltxdep.Size = new System.Drawing.Size(110, 19);
            this.lbltxdep.TabIndex = 35;
            this.lbltxdep.Text = "المأمورية الضريبية";
            this.lbltxdep.Click += new System.EventHandler(this.label5_Click);
            // 
            // cbBxtxdp
            // 
            this.cbBxtxdp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbBxtxdp.Enabled = false;
            this.cbBxtxdp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBxtxdp.FormattingEnabled = true;
            this.cbBxtxdp.Location = new System.Drawing.Point(135, 180);
            this.cbBxtxdp.Name = "cbBxtxdp";
            this.cbBxtxdp.Size = new System.Drawing.Size(235, 27);
            this.cbBxtxdp.TabIndex = 5;
            this.cbBxtxdp.Leave += new System.EventHandler(this.cbBxtxdp_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(150, 181);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(36, 26);
            this.textBox1.TabIndex = 36;
            this.textBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(506, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 33);
            this.button1.TabIndex = 37;
            this.button1.Text = "نوع الضريبة للمولين";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(333, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(207, 29);
            this.button2.TabIndex = 13;
            this.button2.Text = "بحث برقم الملف الضريبي ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(333, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 29);
            this.button3.TabIndex = 38;
            this.button3.Text = "بحث برقم التسجيل الضريبي ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 286);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbltxdep);
            this.Controls.Add(this.cbBxtxdp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.taxrecNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.taxfileNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rprt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.taxknd);
            this.Controls.Add(this.panbutt_Nav);
            this.Controls.Add(this.panSav);
            this.Controls.Add(this.supcd);
            this.Controls.Add(this.supnm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.taxcd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "suppliers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الموردين";
            this.Load += new System.EventHandler(this.suppliers_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suppliers_KeyDown);
            this.panbutt_Nav.ResumeLayout(false);
            this.panButt.ResumeLayout(false);
            this.panSav.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox supcd;
        private System.Windows.Forms.TextBox supnm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panbutt_Nav;
        public System.Windows.Forms.Button prv;
        public System.Windows.Forms.Button frst;
        public System.Windows.Forms.Panel panButt;
        public System.Windows.Forms.Button useradd;
        public System.Windows.Forms.Button useredit;
        public System.Windows.Forms.Button userdelete;
        public System.Windows.Forms.Button userfind;
        public System.Windows.Forms.Button nxt;
        public System.Windows.Forms.Button exit;
        public System.Windows.Forms.Button lst;
        public System.Windows.Forms.Panel panSav;
        public System.Windows.Forms.Button save;
        public System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox taxknd;
        private System.Windows.Forms.TextBox taxcd;
        private System.Windows.Forms.Button rprt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox taxfileNo;
        private System.Windows.Forms.MaskedTextBox taxrecNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltxdep;
        private System.Windows.Forms.ComboBox cbBxtxdp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;

    }
}