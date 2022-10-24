
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
            this.fullLayout = new System.Windows.Forms.TableLayoutPanel();
            this.optionsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.modeSelector = new System.Windows.Forms.GroupBox();
            this.modifyConstraint = new System.Windows.Forms.RadioButton();
            this.perpendicularButton = new System.Windows.Forms.RadioButton();
            this.setLgthButton = new System.Windows.Forms.RadioButton();
            this.insertMode = new System.Windows.Forms.RadioButton();
            this.movingMode = new System.Windows.Forms.RadioButton();
            this.deletingMode = new System.Windows.Forms.RadioButton();
            this.creatingMode = new System.Windows.Forms.RadioButton();
            this.secondaryOptionsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DrawingAlgorithm = new System.Windows.Forms.GroupBox();
            this.bresenhamNo = new System.Windows.Forms.RadioButton();
            this.bresenhamYes = new System.Windows.Forms.RadioButton();
            this.modifyConstraintsBox = new System.Windows.Forms.GroupBox();
            this.perpConstraint = new System.Windows.Forms.RadioButton();
            this.lgthConstraints = new System.Windows.Forms.RadioButton();
            this.constraintBox = new System.Windows.Forms.GroupBox();
            this.constraintsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.constraintsList = new System.Windows.Forms.ListBox();
            this.deleteButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.delConstraintButton = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.fullLayout.SuspendLayout();
            this.optionsLayout.SuspendLayout();
            this.modeSelector.SuspendLayout();
            this.secondaryOptionsLayout.SuspendLayout();
            this.DrawingAlgorithm.SuspendLayout();
            this.modifyConstraintsBox.SuspendLayout();
            this.constraintBox.SuspendLayout();
            this.constraintsLayout.SuspendLayout();
            this.deleteButtonLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // fullLayout
            // 
            this.fullLayout.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fullLayout.ColumnCount = 2;
            this.fullLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.94149F));
            this.fullLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.0481F));
            this.fullLayout.Controls.Add(this.optionsLayout, 0, 0);
            this.fullLayout.Controls.Add(this.constraintBox, 1, 0);
            this.fullLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullLayout.Location = new System.Drawing.Point(0, 0);
            this.fullLayout.Name = "fullLayout";
            this.fullLayout.RowCount = 1;
            this.fullLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fullLayout.Size = new System.Drawing.Size(1138, 121);
            this.fullLayout.TabIndex = 0;
            // 
            // optionsLayout
            // 
            this.optionsLayout.ColumnCount = 1;
            this.optionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsLayout.Controls.Add(this.modeSelector, 0, 0);
            this.optionsLayout.Controls.Add(this.secondaryOptionsLayout, 0, 1);
            this.optionsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsLayout.Location = new System.Drawing.Point(3, 3);
            this.optionsLayout.Name = "optionsLayout";
            this.optionsLayout.RowCount = 2;
            this.optionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsLayout.Size = new System.Drawing.Size(673, 115);
            this.optionsLayout.TabIndex = 5;
            // 
            // modeSelector
            // 
            this.modeSelector.Controls.Add(this.modifyConstraint);
            this.modeSelector.Controls.Add(this.perpendicularButton);
            this.modeSelector.Controls.Add(this.setLgthButton);
            this.modeSelector.Controls.Add(this.insertMode);
            this.modeSelector.Controls.Add(this.movingMode);
            this.modeSelector.Controls.Add(this.deletingMode);
            this.modeSelector.Controls.Add(this.creatingMode);
            this.modeSelector.Location = new System.Drawing.Point(3, 3);
            this.modeSelector.Name = "modeSelector";
            this.modeSelector.Size = new System.Drawing.Size(601, 43);
            this.modeSelector.TabIndex = 2;
            this.modeSelector.TabStop = false;
            this.modeSelector.Text = "Mode";
            // 
            // modifyConstraint
            // 
            this.modifyConstraint.AutoSize = true;
            this.modifyConstraint.Dock = System.Windows.Forms.DockStyle.Left;
            this.modifyConstraint.Location = new System.Drawing.Point(471, 19);
            this.modifyConstraint.Name = "modifyConstraint";
            this.modifyConstraint.Size = new System.Drawing.Size(126, 21);
            this.modifyConstraint.TabIndex = 6;
            this.modifyConstraint.TabStop = true;
            this.modifyConstraint.Text = "Modify Constraints";
            this.modifyConstraint.UseVisualStyleBackColor = true;
            // 
            // perpendicularButton
            // 
            this.perpendicularButton.AutoSize = true;
            this.perpendicularButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.perpendicularButton.Location = new System.Drawing.Point(341, 19);
            this.perpendicularButton.Name = "perpendicularButton";
            this.perpendicularButton.Size = new System.Drawing.Size(130, 21);
            this.perpendicularButton.TabIndex = 5;
            this.perpendicularButton.TabStop = true;
            this.perpendicularButton.Text = "Make Perpendicular";
            this.perpendicularButton.UseVisualStyleBackColor = true;
            // 
            // setLgthButton
            // 
            this.setLgthButton.AutoSize = true;
            this.setLgthButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.setLgthButton.Location = new System.Drawing.Point(260, 19);
            this.setLgthButton.Name = "setLgthButton";
            this.setLgthButton.Size = new System.Drawing.Size(81, 21);
            this.setLgthButton.TabIndex = 4;
            this.setLgthButton.TabStop = true;
            this.setLgthButton.Text = "Set Length";
            this.setLgthButton.UseVisualStyleBackColor = true;
            // 
            // insertMode
            // 
            this.insertMode.AutoSize = true;
            this.insertMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.insertMode.Location = new System.Drawing.Point(175, 19);
            this.insertMode.Name = "insertMode";
            this.insertMode.Size = new System.Drawing.Size(85, 21);
            this.insertMode.TabIndex = 3;
            this.insertMode.TabStop = true;
            this.insertMode.Text = "Insert Point";
            this.insertMode.UseVisualStyleBackColor = true;
            // 
            // movingMode
            // 
            this.movingMode.AutoSize = true;
            this.movingMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.movingMode.Location = new System.Drawing.Point(120, 19);
            this.movingMode.Name = "movingMode";
            this.movingMode.Size = new System.Drawing.Size(55, 21);
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
            this.deletingMode.Size = new System.Drawing.Size(58, 21);
            this.deletingMode.TabIndex = 1;
            this.deletingMode.TabStop = true;
            this.deletingMode.Text = "Delete";
            this.deletingMode.UseVisualStyleBackColor = true;
            // 
            // creatingMode
            // 
            this.creatingMode.AutoSize = true;
            this.creatingMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.creatingMode.Location = new System.Drawing.Point(3, 19);
            this.creatingMode.Name = "creatingMode";
            this.creatingMode.Size = new System.Drawing.Size(59, 21);
            this.creatingMode.TabIndex = 0;
            this.creatingMode.TabStop = true;
            this.creatingMode.Text = "Create";
            this.creatingMode.UseVisualStyleBackColor = true;
            // 
            // secondaryOptionsLayout
            // 
            this.secondaryOptionsLayout.ColumnCount = 2;
            this.secondaryOptionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secondaryOptionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secondaryOptionsLayout.Controls.Add(this.DrawingAlgorithm, 0, 0);
            this.secondaryOptionsLayout.Controls.Add(this.modifyConstraintsBox, 1, 0);
            this.secondaryOptionsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryOptionsLayout.Location = new System.Drawing.Point(3, 60);
            this.secondaryOptionsLayout.Name = "secondaryOptionsLayout";
            this.secondaryOptionsLayout.RowCount = 1;
            this.secondaryOptionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secondaryOptionsLayout.Size = new System.Drawing.Size(667, 52);
            this.secondaryOptionsLayout.TabIndex = 3;
            // 
            // DrawingAlgorithm
            // 
            this.DrawingAlgorithm.Controls.Add(this.bresenhamNo);
            this.DrawingAlgorithm.Controls.Add(this.bresenhamYes);
            this.DrawingAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingAlgorithm.Location = new System.Drawing.Point(3, 3);
            this.DrawingAlgorithm.Name = "DrawingAlgorithm";
            this.DrawingAlgorithm.Size = new System.Drawing.Size(327, 46);
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
            this.bresenhamNo.Size = new System.Drawing.Size(41, 24);
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
            this.bresenhamYes.Size = new System.Drawing.Size(42, 24);
            this.bresenhamYes.TabIndex = 0;
            this.bresenhamYes.TabStop = true;
            this.bresenhamYes.Text = "Yes";
            this.bresenhamYes.UseVisualStyleBackColor = true;
            // 
            // modifyConstraintsBox
            // 
            this.modifyConstraintsBox.Controls.Add(this.perpConstraint);
            this.modifyConstraintsBox.Controls.Add(this.lgthConstraints);
            this.modifyConstraintsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modifyConstraintsBox.Location = new System.Drawing.Point(336, 3);
            this.modifyConstraintsBox.Name = "modifyConstraintsBox";
            this.modifyConstraintsBox.Size = new System.Drawing.Size(328, 46);
            this.modifyConstraintsBox.TabIndex = 4;
            this.modifyConstraintsBox.TabStop = false;
            this.modifyConstraintsBox.Text = "Show Constraints";
            // 
            // perpConstraint
            // 
            this.perpConstraint.AutoSize = true;
            this.perpConstraint.Dock = System.Windows.Forms.DockStyle.Left;
            this.perpConstraint.Location = new System.Drawing.Point(65, 19);
            this.perpConstraint.Name = "perpConstraint";
            this.perpConstraint.Size = new System.Drawing.Size(98, 24);
            this.perpConstraint.TabIndex = 5;
            this.perpConstraint.TabStop = true;
            this.perpConstraint.Text = "Perpendicular";
            this.perpConstraint.UseVisualStyleBackColor = true;
            // 
            // lgthConstraints
            // 
            this.lgthConstraints.AutoSize = true;
            this.lgthConstraints.Dock = System.Windows.Forms.DockStyle.Left;
            this.lgthConstraints.Location = new System.Drawing.Point(3, 19);
            this.lgthConstraints.Name = "lgthConstraints";
            this.lgthConstraints.Size = new System.Drawing.Size(62, 24);
            this.lgthConstraints.TabIndex = 4;
            this.lgthConstraints.TabStop = true;
            this.lgthConstraints.Text = "Length";
            this.lgthConstraints.UseVisualStyleBackColor = true;
            // 
            // constraintBox
            // 
            this.constraintBox.Controls.Add(this.constraintsLayout);
            this.constraintBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constraintBox.Location = new System.Drawing.Point(682, 3);
            this.constraintBox.Name = "constraintBox";
            this.constraintBox.Size = new System.Drawing.Size(453, 115);
            this.constraintBox.TabIndex = 6;
            this.constraintBox.TabStop = false;
            this.constraintBox.Text = "List Of Constraints";
            // 
            // constraintsLayout
            // 
            this.constraintsLayout.ColumnCount = 2;
            this.constraintsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.constraintsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.constraintsLayout.Controls.Add(this.constraintsList, 0, 0);
            this.constraintsLayout.Controls.Add(this.deleteButtonLayout, 1, 0);
            this.constraintsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constraintsLayout.Location = new System.Drawing.Point(3, 19);
            this.constraintsLayout.Name = "constraintsLayout";
            this.constraintsLayout.RowCount = 1;
            this.constraintsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.constraintsLayout.Size = new System.Drawing.Size(447, 93);
            this.constraintsLayout.TabIndex = 8;
            // 
            // constraintsList
            // 
            this.constraintsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constraintsList.FormattingEnabled = true;
            this.constraintsList.ItemHeight = 15;
            this.constraintsList.Location = new System.Drawing.Point(3, 3);
            this.constraintsList.Name = "constraintsList";
            this.constraintsList.Size = new System.Drawing.Size(329, 87);
            this.constraintsList.TabIndex = 0;
            // 
            // deleteButtonLayout
            // 
            this.deleteButtonLayout.ColumnCount = 1;
            this.deleteButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.deleteButtonLayout.Controls.Add(this.delConstraintButton, 0, 1);
            this.deleteButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButtonLayout.Location = new System.Drawing.Point(338, 3);
            this.deleteButtonLayout.Name = "deleteButtonLayout";
            this.deleteButtonLayout.RowCount = 3;
            this.deleteButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.64002F));
            this.deleteButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.71995F));
            this.deleteButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.64003F));
            this.deleteButtonLayout.Size = new System.Drawing.Size(106, 87);
            this.deleteButtonLayout.TabIndex = 7;
            // 
            // delConstraintButton
            // 
            this.delConstraintButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delConstraintButton.Location = new System.Drawing.Point(3, 26);
            this.delConstraintButton.Name = "delConstraintButton";
            this.delConstraintButton.Size = new System.Drawing.Size(100, 34);
            this.delConstraintButton.TabIndex = 0;
            this.delConstraintButton.Text = "Delete";
            this.delConstraintButton.UseVisualStyleBackColor = true;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Location = new System.Drawing.Point(6, 124);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1125, 607);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            // 
            // Drawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 739);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.fullLayout);
            this.Name = "Drawer";
            this.Text = "Polygon Drawer";
            this.fullLayout.ResumeLayout(false);
            this.optionsLayout.ResumeLayout(false);
            this.modeSelector.ResumeLayout(false);
            this.modeSelector.PerformLayout();
            this.secondaryOptionsLayout.ResumeLayout(false);
            this.DrawingAlgorithm.ResumeLayout(false);
            this.DrawingAlgorithm.PerformLayout();
            this.modifyConstraintsBox.ResumeLayout(false);
            this.modifyConstraintsBox.PerformLayout();
            this.constraintBox.ResumeLayout(false);
            this.constraintsLayout.ResumeLayout(false);
            this.deleteButtonLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel fullLayout;
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
        private System.Windows.Forms.RadioButton modifyConstraint;
        private System.Windows.Forms.TableLayoutPanel optionsLayout;
        private System.Windows.Forms.TableLayoutPanel secondaryOptionsLayout;
        private System.Windows.Forms.GroupBox modifyConstraintsBox;
        private System.Windows.Forms.RadioButton perpConstraint;
        private System.Windows.Forms.RadioButton lgthConstraints;
        private System.Windows.Forms.GroupBox constraintBox;
        private System.Windows.Forms.ListBox constraintsList;
        private System.Windows.Forms.TableLayoutPanel deleteButtonLayout;
        private System.Windows.Forms.Button delConstraintButton;
        private System.Windows.Forms.TableLayoutPanel constraintsLayout;
    }
}