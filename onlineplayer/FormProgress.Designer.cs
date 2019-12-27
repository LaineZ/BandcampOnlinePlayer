namespace onlineplayer
{
    partial class FormProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgress));
            this.labelProcessing = new System.Windows.Forms.Label();
            this.labelCurrentAction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProcessing
            // 
            this.labelProcessing.AutoSize = true;
            this.labelProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProcessing.Location = new System.Drawing.Point(9, 13);
            this.labelProcessing.Name = "labelProcessing";
            this.labelProcessing.Size = new System.Drawing.Size(81, 13);
            this.labelProcessing.TabIndex = 0;
            this.labelProcessing.Text = "Processing...";
            // 
            // labelCurrentAction
            // 
            this.labelCurrentAction.AutoSize = true;
            this.labelCurrentAction.Location = new System.Drawing.Point(9, 36);
            this.labelCurrentAction.Name = "labelCurrentAction";
            this.labelCurrentAction.Size = new System.Drawing.Size(150, 13);
            this.labelCurrentAction.TabIndex = 2;
            this.labelCurrentAction.Text = "Processing action, please wait";
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 90);
            this.Controls.Add(this.labelCurrentAction);
            this.Controls.Add(this.labelProcessing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProgress";
            this.Text = "Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProcessing;
        private System.Windows.Forms.Label labelCurrentAction;
    }
}