namespace itacademy.gui.ProgressBar
{
	partial class ProgressBarForm
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
			if(disposing && (components != null))
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
			this._pnlContainer = new System.Windows.Forms.Panel();
			this._pnlLine = new System.Windows.Forms.Panel();
			this._lblText = new System.Windows.Forms.Label();
			this._progressBar = new System.Windows.Forms.ProgressBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this._btnCancel = new System.Windows.Forms.Button();
			this._pnlContainer.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _pnlContainer
			// 
			this._pnlContainer.BackColor = System.Drawing.SystemColors.Window;
			this._pnlContainer.Controls.Add(this._pnlLine);
			this._pnlContainer.Controls.Add(this._lblText);
			this._pnlContainer.Controls.Add(this._progressBar);
			this._pnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
			this._pnlContainer.Location = new System.Drawing.Point(0, 0);
			this._pnlContainer.Name = "_pnlContainer";
			this._pnlContainer.Size = new System.Drawing.Size(496, 65);
			this._pnlContainer.TabIndex = 9;
			// 
			// _pnlLine
			// 
			this._pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
			this._pnlLine.Location = new System.Drawing.Point(0, 64);
			this._pnlLine.Name = "_pnlLine";
			this._pnlLine.Size = new System.Drawing.Size(496, 1);
			this._pnlLine.TabIndex = 2;
			// 
			// _lblText
			// 
			this._lblText.AutoSize = true;
			this._lblText.Location = new System.Drawing.Point(10, 10);
			this._lblText.Name = "_lblText";
			this._lblText.Size = new System.Drawing.Size(48, 13);
			this._lblText.TabIndex = 1;
			this._lblText.Text = "<action>";
			// 
			// _progressBar
			// 
			this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._progressBar.Location = new System.Drawing.Point(12, 31);
			this._progressBar.Name = "_progressBar";
			this._progressBar.Size = new System.Drawing.Size(472, 18);
			this._progressBar.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this._btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 65);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(496, 40);
			this.panel1.TabIndex = 10;
			// 
			// _btnCancel
			// 
			this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._btnCancel.Location = new System.Drawing.Point(414, 9);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 3;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
			// 
			// ProgressBarForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(496, 105);
			this.ControlBox = false;
			this.Controls.Add(this._pnlContainer);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgressBarForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ProgressBarForm";
			this.Load += new System.EventHandler(this.ProgressBarForm_Load);
			this._pnlContainer.ResumeLayout(false);
			this._pnlContainer.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel _pnlContainer;
		private System.Windows.Forms.Panel _pnlLine;
		private System.Windows.Forms.Label _lblText;
		private System.Windows.Forms.ProgressBar _progressBar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button _btnCancel;
	}
}