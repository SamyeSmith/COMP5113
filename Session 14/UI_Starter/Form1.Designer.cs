

namespace UI_Starter
{

    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            terrainGridControl = new TerrainGridControl();
            Load_Map = new Button();
            SuspendLayout();
            // 
            // terrainGridControl
            // 
            terrainGridControl.Location = new Point(168, -1);
            terrainGridControl.Name = "terrainGridControl";
            terrainGridControl.Size = new Size(454, 452);
            terrainGridControl.TabIndex = 0;
            terrainGridControl.Text = "terrainGridControl1";
            // 
            // Load_Map
            // 
            Load_Map.Location = new Point(42, 61);
            Load_Map.Name = "Load_Map";
            Load_Map.Size = new Size(112, 34);
            Load_Map.TabIndex = 1;
            Load_Map.Text = "button1";
            Load_Map.UseVisualStyleBackColor = true;
            Load_Map.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 455);
            Controls.Add(Load_Map);
            Controls.Add(terrainGridControl);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private TerrainGridControl terrainGridControl;
        private Button Load_Map;
    }
}
