namespace WindowsFormsApp1
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
            this.parentView = new System.Windows.Forms.DataGridView();
            this.childView = new System.Windows.Forms.DataGridView();
            this.updateDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.parentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childView)).BeginInit();
            this.SuspendLayout();
            // 
            // parentView
            // 
            this.parentView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parentView.Location = new System.Drawing.Point(73, 39);
            this.parentView.Name = "parentView";
            this.parentView.Size = new System.Drawing.Size(456, 358);
            this.parentView.TabIndex = 0;
            // 
            // childView
            // 
            this.childView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.childView.Location = new System.Drawing.Point(598, 39);
            this.childView.Name = "childView";
            this.childView.Size = new System.Drawing.Size(417, 358);
            this.childView.TabIndex = 1;
            // 
            // updateDb
            // 
            this.updateDb.Location = new System.Drawing.Point(542, 534);
            this.updateDb.Name = "updateDb";
            this.updateDb.Size = new System.Drawing.Size(75, 23);
            this.updateDb.TabIndex = 2;
            this.updateDb.Text = "update";
            this.updateDb.UseVisualStyleBackColor = true;
            this.updateDb.Click += new System.EventHandler(this.updateDb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 615);
            this.Controls.Add(this.updateDb);
            this.Controls.Add(this.childView);
            this.Controls.Add(this.parentView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.parentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView parentView;
        private System.Windows.Forms.DataGridView childView;
        private System.Windows.Forms.Button updateDb;
    }
}

