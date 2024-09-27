namespace Conversor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btcon = new Button();
            lblhex = new Label();
            lblie = new Label();
            tbtnum = new TextBox();
            tbtie = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btcon
            // 
            btcon.BackColor = Color.FromArgb(192, 0, 0);
            btcon.Cursor = Cursors.Hand;
            btcon.FlatStyle = FlatStyle.Flat;
            btcon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btcon.ForeColor = SystemColors.Control;
            btcon.Image = (Image)resources.GetObject("btcon.Image");
            btcon.ImageAlign = ContentAlignment.MiddleRight;
            btcon.Location = new Point(314, 290);
            btcon.Name = "btcon";
            btcon.Size = new Size(151, 50);
            btcon.TabIndex = 0;
            btcon.Text = "CONVERTIR";
            btcon.TextImageRelation = TextImageRelation.TextBeforeImage;
            btcon.UseVisualStyleBackColor = false;
            btcon.Click += btcon_Click;
            // 
            // lblhex
            // 
            lblhex.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblhex.Location = new Point(73, 157);
            lblhex.Name = "lblhex";
            lblhex.Size = new Size(154, 46);
            lblhex.TabIndex = 1;
            lblhex.Text = "Numero";
            lblhex.Click += label1_Click;
            // 
            // lblie
            // 
            lblie.AutoSize = true;
            lblie.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblie.Location = new Point(541, 160);
            lblie.Name = "lblie";
            lblie.Size = new Size(154, 46);
            lblie.TabIndex = 2;
            lblie.Text = "IEEE 754";
            // 
            // tbtnum
            // 
            tbtnum.Cursor = Cursors.IBeam;
            tbtnum.Location = new Point(73, 206);
            tbtnum.Name = "tbtnum";
            tbtnum.Size = new Size(154, 27);
            tbtnum.TabIndex = 3;
            // 
            // tbtie
            // 
            tbtie.Cursor = Cursors.IBeam;
            tbtie.Location = new Point(541, 209);
            tbtie.Name = "tbtie";
            tbtie.Size = new Size(154, 27);
            tbtie.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "HEXADECIMAL", "DECIMAL" });
            comboBox1.Location = new Point(314, 144);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(158, 31);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "8bits", "16bits", "32bits" });
            comboBox2.Location = new Point(314, 219);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(158, 31);
            comboBox2.TabIndex = 6;
            comboBox2.Visible = false;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(314, 118);
            label1.Name = "label1";
            label1.Size = new Size(158, 23);
            label1.TabIndex = 7;
            label1.Text = "Sistema numerico";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(372, 193);
            label2.Name = "label2";
            label2.Size = new Size(42, 23);
            label2.TabIndex = 8;
            label2.Text = "Bits";
            label2.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(761, 462);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(tbtie);
            Controls.Add(tbtnum);
            Controls.Add(lblie);
            Controls.Add(lblhex);
            Controls.Add(btcon);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conversor Punto Flotante";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btcon;
        private Label lblhex;
        private Label lblie;
        private TextBox tbtnum;
        private TextBox tbtie;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
    }
}
