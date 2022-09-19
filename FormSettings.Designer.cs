namespace Counter
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.edMinorTime = new System.Windows.Forms.NumericUpDown();
            this.edMajorTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.edMinorTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMajorTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Green time (min)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Red time (min)";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(34, 70);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(135, 70);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // edMinorTime
            // 
            this.edMinorTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Counter.Properties.Settings.Default, "MinorTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.edMinorTime.Location = new System.Drawing.Point(102, 39);
            this.edMinorTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edMinorTime.Name = "edMinorTime";
            this.edMinorTime.Size = new System.Drawing.Size(120, 20);
            this.edMinorTime.TabIndex = 2;
            this.edMinorTime.Value = global::Counter.Properties.Settings.Default.MinorTime;
            // 
            // edMajorTime
            // 
            this.edMajorTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Counter.Properties.Settings.Default, "MajorTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.edMajorTime.Location = new System.Drawing.Point(102, 11);
            this.edMajorTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edMajorTime.Name = "edMajorTime";
            this.edMajorTime.Size = new System.Drawing.Size(120, 20);
            this.edMajorTime.TabIndex = 1;
            this.edMajorTime.Value = global::Counter.Properties.Settings.Default.MajorTime;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(252, 105);
            this.Controls.Add(this.edMinorTime);
            this.Controls.Add(this.edMajorTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.edMinorTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMajorTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown edMajorTime;
        private System.Windows.Forms.NumericUpDown edMinorTime;
    }
}