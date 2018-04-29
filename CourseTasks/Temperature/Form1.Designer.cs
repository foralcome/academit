namespace Temperature
{
    partial class Form1
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
            this.valueSourceTemp = new System.Windows.Forms.TextBox();
            this.nameSourceTemp = new System.Windows.Forms.ComboBox();
            this.nameDestinationTemp = new System.Windows.Forms.ComboBox();
            this.valueDestinationTemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StartConvertor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // valueSourceTemp
            // 
            this.valueSourceTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueSourceTemp.Location = new System.Drawing.Point(213, 13);
            this.valueSourceTemp.MaxLength = 5;
            this.valueSourceTemp.Name = "valueSourceTemp";
            this.valueSourceTemp.Size = new System.Drawing.Size(81, 32);
            this.valueSourceTemp.TabIndex = 0;
            this.valueSourceTemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valueSourceTemp_KeyPress);
            // 
            // nameSourceTemp
            // 
            this.nameSourceTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameSourceTemp.FormattingEnabled = true;
            this.nameSourceTemp.Location = new System.Drawing.Point(308, 12);
            this.nameSourceTemp.Name = "nameSourceTemp";
            this.nameSourceTemp.Size = new System.Drawing.Size(168, 33);
            this.nameSourceTemp.TabIndex = 1;
            this.nameSourceTemp.SelectedIndexChanged += new System.EventHandler(this.nameSourceTemp_SelectedIndexChanged);
            // 
            // nameDestinationTemp
            // 
            this.nameDestinationTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameDestinationTemp.FormattingEnabled = true;
            this.nameDestinationTemp.Location = new System.Drawing.Point(308, 53);
            this.nameDestinationTemp.Name = "nameDestinationTemp";
            this.nameDestinationTemp.Size = new System.Drawing.Size(168, 33);
            this.nameDestinationTemp.TabIndex = 2;
            this.nameDestinationTemp.SelectedIndexChanged += new System.EventHandler(this.nameDestinationTemp_SelectedIndexChanged);
            // 
            // valueDestinationTemp
            // 
            this.valueDestinationTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueDestinationTemp.Location = new System.Drawing.Point(213, 54);
            this.valueDestinationTemp.MaxLength = 5;
            this.valueDestinationTemp.Name = "valueDestinationTemp";
            this.valueDestinationTemp.ReadOnly = true;
            this.valueDestinationTemp.Size = new System.Drawing.Size(81, 32);
            this.valueDestinationTemp.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(62, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Температура";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(62, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Температура";
            // 
            // StartConvertor
            // 
            this.StartConvertor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartConvertor.Location = new System.Drawing.Point(489, 12);
            this.StartConvertor.Name = "StartConvertor";
            this.StartConvertor.Size = new System.Drawing.Size(164, 74);
            this.StartConvertor.TabIndex = 8;
            this.StartConvertor.Text = "ПЕРЕВЕСТИ";
            this.StartConvertor.UseVisualStyleBackColor = true;
            this.StartConvertor.Click += new System.EventHandler(this.StartConvertor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 110);
            this.Controls.Add(this.StartConvertor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.valueDestinationTemp);
            this.Controls.Add(this.nameDestinationTemp);
            this.Controls.Add(this.nameSourceTemp);
            this.Controls.Add(this.valueSourceTemp);
            this.Name = "Form1";
            this.Text = "Перевод температур";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox valueSourceTemp;
        private System.Windows.Forms.ComboBox nameSourceTemp;
        private System.Windows.Forms.ComboBox nameDestinationTemp;
        private System.Windows.Forms.TextBox valueDestinationTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartConvertor;
    }
}

