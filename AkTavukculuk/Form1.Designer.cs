namespace AkTavukculuk
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_kadi = new System.Windows.Forms.TextBox();
            this.txt_ksifre = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_giris = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txttc = new System.Windows.Forms.TextBox();
            this.lbltc = new MaterialSkin.Controls.MaterialLabel();
            this.txtyenisif = new System.Windows.Forms.TextBox();
            this.lblyenisif = new MaterialSkin.Controls.MaterialLabel();
            this.btndegis = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(56, 190);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(40, 19);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Şifre";
            // 
            // txt_kadi
            // 
            this.txt_kadi.Location = new System.Drawing.Point(183, 145);
            this.txt_kadi.Name = "txt_kadi";
            this.txt_kadi.Size = new System.Drawing.Size(177, 20);
            this.txt_kadi.TabIndex = 1;
            // 
            // txt_ksifre
            // 
            this.txt_ksifre.Location = new System.Drawing.Point(183, 189);
            this.txt_ksifre.Name = "txt_ksifre";
            this.txt_ksifre.PasswordChar = '*';
            this.txt_ksifre.Size = new System.Drawing.Size(177, 20);
            this.txt_ksifre.TabIndex = 3;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(56, 146);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(92, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Kullanıcı Adı";
            // 
            // btn_giris
            // 
            this.btn_giris.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_giris.Location = new System.Drawing.Point(183, 236);
            this.btn_giris.Name = "btn_giris";
            this.btn_giris.Size = new System.Drawing.Size(177, 35);
            this.btn_giris.TabIndex = 4;
            this.btn_giris.Text = "GİRİŞ";
            this.btn_giris.UseVisualStyleBackColor = true;
            this.btn_giris.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(180, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kullanıcı Adı veya Şifre Hatalı ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(180, 288);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(106, 19);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Şifremi Unuttum";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txttc
            // 
            this.txttc.Location = new System.Drawing.Point(183, 320);
            this.txttc.Name = "txttc";
            this.txttc.Size = new System.Drawing.Size(177, 20);
            this.txttc.TabIndex = 8;
            this.txttc.Visible = false;
            // 
            // lbltc
            // 
            this.lbltc.AutoSize = true;
            this.lbltc.Depth = 0;
            this.lbltc.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbltc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbltc.Location = new System.Drawing.Point(56, 321);
            this.lbltc.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbltc.Name = "lbltc";
            this.lbltc.Size = new System.Drawing.Size(28, 19);
            this.lbltc.TabIndex = 7;
            this.lbltc.Text = "TC";
            this.lbltc.Visible = false;
            // 
            // txtyenisif
            // 
            this.txtyenisif.Location = new System.Drawing.Point(183, 363);
            this.txtyenisif.Name = "txtyenisif";
            this.txtyenisif.Size = new System.Drawing.Size(177, 20);
            this.txtyenisif.TabIndex = 10;
            this.txtyenisif.Visible = false;
            // 
            // lblyenisif
            // 
            this.lblyenisif.AutoSize = true;
            this.lblyenisif.Depth = 0;
            this.lblyenisif.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblyenisif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblyenisif.Location = new System.Drawing.Point(56, 364);
            this.lblyenisif.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblyenisif.Name = "lblyenisif";
            this.lblyenisif.Size = new System.Drawing.Size(73, 19);
            this.lblyenisif.TabIndex = 9;
            this.lblyenisif.Text = "Yeni Şifre";
            this.lblyenisif.Visible = false;
            // 
            // btndegis
            // 
            this.btndegis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btndegis.Location = new System.Drawing.Point(183, 392);
            this.btndegis.Name = "btndegis";
            this.btndegis.Size = new System.Drawing.Size(177, 35);
            this.btndegis.TabIndex = 11;
            this.btndegis.Text = "Şifreyi Değiştir";
            this.btndegis.UseVisualStyleBackColor = true;
            this.btndegis.Visible = false;
            this.btndegis.Click += new System.EventHandler(this.btndegis_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(181, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(181, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 451);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btndegis);
            this.Controls.Add(this.txtyenisif);
            this.Controls.Add(this.lblyenisif);
            this.Controls.Add(this.txttc);
            this.Controls.Add(this.lbltc);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_giris);
            this.Controls.Add(this.txt_kadi);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.txt_ksifre);
            this.Name = "Form1";
            this.Text = "Kullanıcı Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TextBox txt_kadi;
        private System.Windows.Forms.TextBox txt_ksifre;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Button btn_giris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txttc;
        private MaterialSkin.Controls.MaterialLabel lbltc;
        private System.Windows.Forms.TextBox txtyenisif;
        private MaterialSkin.Controls.MaterialLabel lblyenisif;
        private System.Windows.Forms.Button btndegis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

