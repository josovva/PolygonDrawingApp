
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
            this.setLgthButton = new System.Windows.Forms.RadioButton();
            this.insertMode = new System.Windows.Forms.RadioButton();
            this.movingMode = new System.Windows.Forms.RadioButton();
            this.deletingMode = new System.Windows.Forms.RadioButton();
            this.creatingMode = new System.Windows.Forms.RadioButton();
            this.DrawingAlgorithm = new System.Windows.Forms.GroupBox();
            this.bresenhamNo = new System.Windows.Forms.RadioButton();
            this.bresenhamYes = new System.Windows.Forms.RadioButton();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.perpendicularButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.modeSelector.SuspendLayout();
            this.DrawingAlgorithm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.Controls.Add(this.modeSelector, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DrawingAlgorithm, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1138, 61);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // modeSelector
            // 
            this.modeSelector.Controls.Add(this.perpendicularButton);
            this.modeSelector.Controls.Add(this.setLgthButton);
            this.modeSelector.Controls.Add(this.insertMode);
            this.modeSelector.Controls.Add(this.movingMode);
            this.modeSelector.Controls.Add(this.deletingMode);
            this.modeSelector.Controls.Add(this.creatingMode);
            this.modeSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modeSelector.Location = new System.Drawing.Point(3, 3);
            this.modeSelector.Name = "modeSelector";
            this.modeSelector.Size = new System.Drawing.Size(499, 55);
            this.modeSelector.TabIndex = 2;
            this.modeSelector.TabStop = false;
            this.modeSelector.Text = "Mode";
            // 
            // setLgthButton
            // 
            this.setLgthButton.AutoSize = true;
            this.setLgthButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.setLgthButton.Location = new System.Drawing.Point(271, 19);
            this.setLgthButton.Name = "setLgthButton";
            this.setLgthButton.Size = new System.Drawing.Size(81, 33);
            this.setLgthButton.TabIndex = 4;
            this.setLgthButton.TabStop = true;
            this.setLgthButton.Text = "Set Length";
            this.setLgthButton.UseVisualStyleBackColor = true;
            // 
            // insertMode
            // 
            this.insertMode.AutoSize = true;
            this.insertMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.insertMode.Location = new System.Drawing.Point(186, 19);
            this.insertMode.Name = "insertMode";
            this.insertMode.Size = new System.Drawing.Size(85, 33);
            this.insertMode.TabIndex = 3;
            this.insertMode.TabStop = true;
            this.insertMode.Text = "Insert Point";
            this.insertMode.UseVisualStyleBackColor = true;
            // 
            // movingMode
            // 
            this.movingMode.AutoSize = true;
            this.movingMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.movingMode.Location = new System.Drawing.Point(131, 19);
            this.movingMode.Name = "movingMode";
            this.movingMode.Size = new System.Drawing.Size(55, 33);
            this.movingMode.TabIndex = 2;
            this.movingMode.TabStop = true;
            this.movingMode.Text = "Move";
            this.movingMode.UseVisualStyleBackColor = true;
            // 
            // deletingMode
            // 
            this.deletingMode.AutoSize = true;
            this.deletingMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.deletingMode.Location = new System.Drawing.Point(62, 19);
            this.deletingMode.Name = "deletingMode";
            this.deletingMode.Size = new System.Drawing.Size(69, 33);
            this.deletingMode.TabIndex = 1;
            this.deletingMode.TabStop = true;
            this.deletingMode.Text = "Deleting";
            this.deletingMode.UseVisualStyleBackColor = true;
            // 
            // creatingMode
            // 
            this.creatingMode.AutoSize = true;
            this.creatingMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.creatingMode.Location = new System.Drawing.Point(3, 19);
            this.creatingMode.Name = "creatingMode";
            this.creatingMode.Size = new System.Drawing.Size(59, 33);
            this.creatingMode.TabIndex = 0;
            this.creatingMode.TabStop = true;
            this.creatingMode.Text = "Create";
            this.creatingMode.UseVisualStyleBackColor = true;
            // 
            // DrawingAlgorithm
            // 
            this.DrawingAlgorithm.Controls.Add(this.bresenhamNo);
            this.DrawingAlgorithm.Controls.Add(this.bresenhamYes);
            this.DrawingAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingAlgorithm.Location = new System.Drawing.Point(508, 3);
            this.DrawingAlgorithm.Name = "DrawingAlgorithm";
            this.DrawingAlgorithm.Size = new System.Drawing.Size(627, 55);
            this.DrawingAlgorithm.TabIndex = 3;
            this.DrawingAlgorithm.TabStop = false;
            this.DrawingAlgorithm.Text = "Use Bresenham Algorithm?";
            // 
            // bresenhamNo
            // 
            this.bresenhamNo.AutoSize = true;
            this.bresenhamNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.bresenhamNo.Location = new System.Drawing.Point(45, 19);
            this.bresenhamNo.Name = "bresenhamNo";
            this.bresenhamNo.Size = new System.Drawing.Size(41, 33);
            this.bresenhamNo.TabIndex = 1;
            this.bresenhamNo.TabStop = true;
            this.bresenhamNo.Text = "No";
            this.bresenhamNo.UseVisualStyleBackColor = true;
            // 
            // bresenhamYes
            // 
            this.bresenhamYes.AutoSize = true;
            this.bresenhamYes.Dock = System.Windows.Forms.DockStyle.Left;
            this.bresenhamYes.Location = new System.Drawing.Point(3, 19);
            this.bresenhamYes.Name = "bresenhamYes";
            this.bresenhamYes.Size = new System.Drawing.Size(42, 33);
            this.bresenhamYes.TabIndex = 0;
            this.bresenhamYes.TabStop = true;
            this.bresenhamYes.Text = "Yes";
            this.bresenhamYes.UseVisualStyleBackColor = true;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Location = new System.Drawing.Point(6, 67);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1125, 648);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            // 
            // perpendicularButton
            // 
            this.perpendicularButton.AutoSize = true;
            this.perpendicularButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.perpendicularButton.Location = new System.Drawing.Point(352, 19);
            this.perpendicularButton.Name = "perpendicularButton";
            this.perpendicularButton.Size = new System.Drawing.Size(130, 33);
            this.perpendicularButton.TabIndex = 5;
            this.perpendicularButton.TabStop = true;
            this.perpendicularButton.Text = "Make Perpendicular";
            this.perpendicularButton.UseVisualStyleBackColor = true;
            // 
            // Drawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 721);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Drawer";
            this.Text = "Polygon Drawer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.modeSelector.ResumeLayout(false);
            this.modeSelector.PerformLayout();
            this.DrawingAlgorithm.ResumeLayout(false);
            this.DrawingAlgorithm.PerformLayout();
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
        private System.Windows.Forms.GroupBox DrawingAlgorithm;
        private System.Windows.Forms.RadioButton bresenhamNo;
        private System.Windows.Forms.RadioButton bresenhamYes;
        private System.Windows.Forms.RadioButton insertMode;
        private System.Windows.Forms.RadioButton setLgthButton;
        private System.Windows.Forms.RadioButton perpendicularButton;
    }
}