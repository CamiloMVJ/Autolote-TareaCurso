namespace ProyectoSistemaAutos
{
    partial class frmLogIn
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pbGift = new PictureBox();
            pbLogo = new PictureBox();
            btnIngresar = new Button();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            label3 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbGift).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pbGift
            // 
            pbGift.Image = Properties.Resources.GiftFondo;
            pbGift.Location = new Point(152, 73);
            pbGift.Name = "pbGift";
            pbGift.Size = new Size(140, 142);
            pbGift.SizeMode = PictureBoxSizeMode.StretchImage;
            pbGift.TabIndex = 0;
            pbGift.TabStop = false;
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.LogoEmpresa;
            pbLogo.Location = new Point(157, 79);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(132, 133);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(12, 242, 199);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Gill Sans Ultra Bold Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnIngresar.ForeColor = SystemColors.ActiveCaptionText;
            btnIngresar.Location = new Point(126, 394);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(175, 34);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            txtUsuario.Location = new Point(97, 256);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(274, 17);
            txtUsuario.TabIndex = 5;
            txtUsuario.Text = "Usuario";
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            txtContraseña.Location = new Point(97, 324);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '•';
            txtContraseña.Size = new Size(281, 24);
            txtContraseña.TabIndex = 6;
            txtContraseña.Text = "Contraseña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Gill Sans Ultra Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(77, 23);
            label3.Name = "label3";
            label3.Size = new Size(244, 33);
            label3.TabIndex = 7;
            label3.Text = "Enterprise CHC";
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Location = new Point(39, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(13, 119);
            panel2.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Location = new Point(446, 378);
            panel3.Name = "panel3";
            panel3.Size = new Size(13, 119);
            panel3.TabIndex = 12;
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.Controls.Add(pictureBox2);
            guna2GradientPanel1.Controls.Add(pictureBox1);
            guna2GradientPanel1.Controls.Add(pbLogo);
            guna2GradientPanel1.Controls.Add(txtUsuario);
            guna2GradientPanel1.Controls.Add(btnIngresar);
            guna2GradientPanel1.Controls.Add(pbGift);
            guna2GradientPanel1.Controls.Add(txtContraseña);
            guna2GradientPanel1.Controls.Add(label3);
            guna2GradientPanel1.CustomizableEdges = customizableEdges1;
            guna2GradientPanel1.FillColor = Color.FromArgb(11, 80, 122);
            guna2GradientPanel1.FillColor2 = Color.Black;
            guna2GradientPanel1.Location = new Point(40, 22);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GradientPanel1.Size = new Size(415, 437);
            guna2GradientPanel1.TabIndex = 14;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.IconoUsuario;
            pictureBox2.Location = new Point(57, 249);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 38);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.IconoCandado;
            pictureBox1.Location = new Point(60, 320);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 34);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // frmLogIn
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(496, 508);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(guna2GradientPanel1);
            Name = "frmLogIn";
            Text = "Log In";
            ((System.ComponentModel.ISupportInitialize)pbGift).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbGift;
        private PictureBox pbLogo;
        private Button btnIngresar;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Label label3;
        private Panel panel2;
        private Panel panel3;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}