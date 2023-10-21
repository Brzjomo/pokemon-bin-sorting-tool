namespace pokemon_bin_sorting_tool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            TPPokemonModel = new TabPage();
            CBIfOutputYML = new CheckBox();
            BTRun = new Button();
            CBIfReplaceBlank = new CheckBox();
            labelGameVersion = new Label();
            CBGameVersion = new ComboBox();
            TPIndexGen = new TabPage();
            NUDStringWidth = new NumericUpDown();
            LBStringWidth = new Label();
            BTGen = new Button();
            NUDEndIndex = new NumericUpDown();
            LBEndIndex = new Label();
            NUDFileCount = new NumericUpDown();
            LBFileCount = new Label();
            NUDStartIndex = new NumericUpDown();
            LBStartIndex = new Label();
            tabControl1.SuspendLayout();
            TPPokemonModel.SuspendLayout();
            TPIndexGen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUDStringWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDEndIndex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDFileCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDStartIndex).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(TPPokemonModel);
            tabControl1.Controls.Add(TPIndexGen);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // TPPokemonModel
            // 
            resources.ApplyResources(TPPokemonModel, "TPPokemonModel");
            TPPokemonModel.Controls.Add(CBIfOutputYML);
            TPPokemonModel.Controls.Add(BTRun);
            TPPokemonModel.Controls.Add(CBIfReplaceBlank);
            TPPokemonModel.Controls.Add(labelGameVersion);
            TPPokemonModel.Controls.Add(CBGameVersion);
            TPPokemonModel.Name = "TPPokemonModel";
            TPPokemonModel.UseVisualStyleBackColor = true;
            // 
            // CBIfOutputYML
            // 
            resources.ApplyResources(CBIfOutputYML, "CBIfOutputYML");
            CBIfOutputYML.Name = "CBIfOutputYML";
            CBIfOutputYML.TabStop = false;
            CBIfOutputYML.UseVisualStyleBackColor = true;
            // 
            // BTRun
            // 
            resources.ApplyResources(BTRun, "BTRun");
            BTRun.Name = "BTRun";
            BTRun.UseVisualStyleBackColor = true;
            BTRun.Click += BTRun_Click;
            // 
            // CBIfReplaceBlank
            // 
            resources.ApplyResources(CBIfReplaceBlank, "CBIfReplaceBlank");
            CBIfReplaceBlank.Checked = true;
            CBIfReplaceBlank.CheckState = CheckState.Checked;
            CBIfReplaceBlank.Name = "CBIfReplaceBlank";
            CBIfReplaceBlank.TabStop = false;
            CBIfReplaceBlank.UseVisualStyleBackColor = true;
            // 
            // labelGameVersion
            // 
            resources.ApplyResources(labelGameVersion, "labelGameVersion");
            labelGameVersion.Name = "labelGameVersion";
            // 
            // CBGameVersion
            // 
            resources.ApplyResources(CBGameVersion, "CBGameVersion");
            CBGameVersion.FormattingEnabled = true;
            CBGameVersion.Items.AddRange(new object[] { resources.GetString("CBGameVersion.Items") });
            CBGameVersion.Name = "CBGameVersion";
            // 
            // TPIndexGen
            // 
            resources.ApplyResources(TPIndexGen, "TPIndexGen");
            TPIndexGen.Controls.Add(NUDStringWidth);
            TPIndexGen.Controls.Add(LBStringWidth);
            TPIndexGen.Controls.Add(BTGen);
            TPIndexGen.Controls.Add(NUDEndIndex);
            TPIndexGen.Controls.Add(LBEndIndex);
            TPIndexGen.Controls.Add(NUDFileCount);
            TPIndexGen.Controls.Add(LBFileCount);
            TPIndexGen.Controls.Add(NUDStartIndex);
            TPIndexGen.Controls.Add(LBStartIndex);
            TPIndexGen.Name = "TPIndexGen";
            TPIndexGen.UseVisualStyleBackColor = true;
            // 
            // NUDStringWidth
            // 
            resources.ApplyResources(NUDStringWidth, "NUDStringWidth");
            NUDStringWidth.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            NUDStringWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUDStringWidth.Name = "NUDStringWidth";
            NUDStringWidth.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // LBStringWidth
            // 
            resources.ApplyResources(LBStringWidth, "LBStringWidth");
            LBStringWidth.Name = "LBStringWidth";
            // 
            // BTGen
            // 
            resources.ApplyResources(BTGen, "BTGen");
            BTGen.Name = "BTGen";
            BTGen.UseVisualStyleBackColor = true;
            BTGen.Click += BTGen_Click;
            // 
            // NUDEndIndex
            // 
            resources.ApplyResources(NUDEndIndex, "NUDEndIndex");
            NUDEndIndex.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NUDEndIndex.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUDEndIndex.Name = "NUDEndIndex";
            NUDEndIndex.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // LBEndIndex
            // 
            resources.ApplyResources(LBEndIndex, "LBEndIndex");
            LBEndIndex.Name = "LBEndIndex";
            // 
            // NUDFileCount
            // 
            resources.ApplyResources(NUDFileCount, "NUDFileCount");
            NUDFileCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            NUDFileCount.Name = "NUDFileCount";
            NUDFileCount.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // LBFileCount
            // 
            resources.ApplyResources(LBFileCount, "LBFileCount");
            LBFileCount.Name = "LBFileCount";
            // 
            // NUDStartIndex
            // 
            resources.ApplyResources(NUDStartIndex, "NUDStartIndex");
            NUDStartIndex.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NUDStartIndex.Name = "NUDStartIndex";
            NUDStartIndex.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // LBStartIndex
            // 
            resources.ApplyResources(LBStartIndex, "LBStartIndex");
            LBStartIndex.Name = "LBStartIndex";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            MaximizeBox = false;
            Name = "Form1";
            tabControl1.ResumeLayout(false);
            TPPokemonModel.ResumeLayout(false);
            TPPokemonModel.PerformLayout();
            TPIndexGen.ResumeLayout(false);
            TPIndexGen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUDStringWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDEndIndex).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDFileCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDStartIndex).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TPPokemonModel;
        private ComboBox CBGameVersion;
        private Label labelGameVersion;
        private CheckBox CBIfReplaceBlank;
        private Button BTRun;
        private CheckBox CBIfOutputYML;
        private TabPage TPIndexGen;
        private NumericUpDown NUDFileCount;
        private Label LBFileCount;
        private NumericUpDown NUDStartIndex;
        private Label LBStartIndex;
        private Button BTGen;
        private NumericUpDown NUDEndIndex;
        private Label LBEndIndex;
        private NumericUpDown NUDStringWidth;
        private Label LBStringWidth;
    }
}