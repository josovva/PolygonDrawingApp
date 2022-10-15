
namespace GK_polygon_draw.View
{
    partial class Drawer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.modeSelector = new System.Windows.Forms.GroupBox();
            this.movingMode = new System.Windows.Forms.RadioButton();
            this.deletingMode = new System.Windows.Forms.RadioButton();
            this.creatingMode = new System.Windows.Forms.RadioButton();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.modeSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.modeSelector, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(947, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 642);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // modeSelector
            // 
            this.modeSelector.Controls.Add(this.movingMode);
            this.modeSelector.Controls.Add(this.deletingMode);
            this.modeSelector.Controls.Add(this.creatingMode);
            this.modeSelector.Location = new System.Drawing.Point(3, 3);
            this.modeSelector.Name = "modeSelector";
            this.modeSelector.Size = new System.Drawing.Size(194, 208);
            this.modeSelector.TabIndex = 2;
            this.modeSelector.TabStop = false;
            this.modeSelector.Text = "Mode";
            // 
            // movingMode
            // 
            this.movingMode.AutoSize = true;
            this.movingMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.movingMode.Location = new System.Drawing.Point(3, 57);
            this.movingMode.Name = "movingMode";
            this.movingMode.Size = new System.Drawing.Size(188, 19);
            this.movingMode.TabIndex = 2;
            this.movingMode.TabStop = true;
            this.movingMode.Text = "Move";
            this.movingMode.UseVisualStyleBackColor = true;
            // 
            // deletingMode
            // 
            this.deletingMode.AutoSize = true;
            this.deletingMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.deletingMode.Location = new System.Drawing.Point(3, 38);
            this.deletingMode.Name = "deletingMode";
            this.deletingMode.Size = new System.Drawing.Size(188, 19);
            this.deletingMode.TabIndex = 1;
            this.deletingMode.TabStop = true;
            this.deletingMode.Text = "Deleting";
            this.deletingMode.UseVisualStyleBackColor = true;
            // 
            // creatingMode
            // 
            this.creatingMode.AutoSize = true;
            this.creatingMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.creatingMode.Location = new System.Drawing.Point(3, 19);
            this.creatingMode.Name = "creatingMode";
            this.creatingMode.Size = new System.Drawing.Size(188, 19);
            this.creatingMode.TabIndex = 0;
            this.creatingMode.TabStop = true;
            this.creatingMode.Text = "Create";
            this.creatingMode.UseVisualStyleBackColor = true;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(920, 618);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            // 
            // Drawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 642);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Drawer";
            this.Text = "Polygon Drawer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.modeSelector.ResumeLayout(false);
            this.modeSelector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox modeSelector;
        private System.Windows.Forms.RadioButton creatingMode;
        private System.Windows.Forms.RadioButton movingMode;
        private System.Windows.Forms.RadioButton deletingMode;
    }
}