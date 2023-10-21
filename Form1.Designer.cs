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
            NUDLoopCount = new NumericUpDown();
            LBLoopCount = new Label();
            NUDFileCount = new NumericUpDown();
            LBFileCount = new Label();
            NUDStartIndex = new NumericUpDown();
            LBStartIndex = new Label();
            tabControl1.SuspendLayout();
            TPPokemonModel.SuspendLayout();
            TPIndexGen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUDStringWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDLoopCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDFileCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDStartIndex).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TPPokemonModel);
            tabControl1.Controls.Add(TPIndexGen);
            tabControl1.Location = new Point(13, 15);
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(488, 131);
            tabControl1.TabIndex = 0;
            // 
            // TPPokemonModel
            // 
            TPPokemonModel.Controls.Add(CBIfOutputYML);
            TPPokemonModel.Controls.Add(BTRun);
            TPPokemonModel.Controls.Add(CBIfReplaceBlank);
            TPPokemonModel.Controls.Add(labelGameVersion);
            TPPokemonModel.Controls.Add(CBGameVersion);
            TPPokemonModel.Location = new Point(4, 30);
            TPPokemonModel.Margin = new Padding(4);
            TPPokemonModel.Name = "TPPokemonModel";
            TPPokemonModel.Padding = new Padding(4);
            TPPokemonModel.Size = new Size(480, 97);
            TPPokemonModel.TabIndex = 0;
            TPPokemonModel.Text = "宝可梦模型";
            TPPokemonModel.UseVisualStyleBackColor = true;
            // 
            // CBIfOutputYML
            // 
            CBIfOutputYML.AutoSize = true;
            CBIfOutputYML.Location = new Point(165, 54);
            CBIfOutputYML.Name = "CBIfOutputYML";
            CBIfOutputYML.Size = new Size(127, 25);
            CBIfOutputYML.TabIndex = 4;
            CBIfOutputYML.Text = "是否输出YML";
            CBIfOutputYML.UseVisualStyleBackColor = true;
            // 
            // BTRun
            // 
            BTRun.Location = new Point(315, 14);
            BTRun.Name = "BTRun";
            BTRun.Size = new Size(144, 65);
            BTRun.TabIndex = 3;
            BTRun.Text = "运行";
            BTRun.UseVisualStyleBackColor = true;
            BTRun.Click += BTRun_Click;
            // 
            // CBIfReplaceBlank
            // 
            CBIfReplaceBlank.AutoSize = true;
            CBIfReplaceBlank.Checked = true;
            CBIfReplaceBlank.CheckState = CheckState.Checked;
            CBIfReplaceBlank.Location = new Point(23, 54);
            CBIfReplaceBlank.Name = "CBIfReplaceBlank";
            CBIfReplaceBlank.Size = new Size(125, 25);
            CBIfReplaceBlank.TabIndex = 2;
            CBIfReplaceBlank.Text = "是否替换空格";
            CBIfReplaceBlank.UseVisualStyleBackColor = true;
            // 
            // labelGameVersion
            // 
            labelGameVersion.AutoSize = true;
            labelGameVersion.Location = new Point(23, 18);
            labelGameVersion.Margin = new Padding(4, 0, 4, 0);
            labelGameVersion.Name = "labelGameVersion";
            labelGameVersion.Size = new Size(78, 21);
            labelGameVersion.TabIndex = 1;
            labelGameVersion.Text = "游戏版本:";
            // 
            // CBGameVersion
            // 
            CBGameVersion.FormattingEnabled = true;
            CBGameVersion.Items.AddRange(new object[] { "USUM" });
            CBGameVersion.Location = new Point(109, 14);
            CBGameVersion.Margin = new Padding(4);
            CBGameVersion.Name = "CBGameVersion";
            CBGameVersion.Size = new Size(183, 29);
            CBGameVersion.TabIndex = 0;
            CBGameVersion.Text = "USUM";
            // 
            // TPIndexGen
            // 
            TPIndexGen.Controls.Add(NUDStringWidth);
            TPIndexGen.Controls.Add(LBStringWidth);
            TPIndexGen.Controls.Add(BTGen);
            TPIndexGen.Controls.Add(NUDLoopCount);
            TPIndexGen.Controls.Add(LBLoopCount);
            TPIndexGen.Controls.Add(NUDFileCount);
            TPIndexGen.Controls.Add(LBFileCount);
            TPIndexGen.Controls.Add(NUDStartIndex);
            TPIndexGen.Controls.Add(LBStartIndex);
            TPIndexGen.Location = new Point(4, 30);
            TPIndexGen.Name = "TPIndexGen";
            TPIndexGen.Size = new Size(480, 97);
            TPIndexGen.TabIndex = 1;
            TPIndexGen.Text = "序号生成";
            TPIndexGen.UseVisualStyleBackColor = true;
            // 
            // NUDStringWidth
            // 
            NUDStringWidth.Location = new Point(263, 56);
            NUDStringWidth.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NUDStringWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUDStringWidth.Name = "NUDStringWidth";
            NUDStringWidth.Size = new Size(70, 28);
            NUDStringWidth.TabIndex = 7;
            NUDStringWidth.TextAlign = HorizontalAlignment.Center;
            NUDStringWidth.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // LBStringWidth
            // 
            LBStringWidth.AutoSize = true;
            LBStringWidth.Location = new Point(182, 60);
            LBStringWidth.Name = "LBStringWidth";
            LBStringWidth.Size = new Size(78, 21);
            LBStringWidth.TabIndex = 8;
            LBStringWidth.Text = "字符宽度:";
            // 
            // BTGen
            // 
            BTGen.Location = new Point(354, 13);
            BTGen.Name = "BTGen";
            BTGen.Size = new Size(110, 71);
            BTGen.TabIndex = 0;
            BTGen.Text = "生成";
            BTGen.UseVisualStyleBackColor = true;
            BTGen.Click += BTGen_Click;
            // 
            // NUDLoopCount
            // 
            NUDLoopCount.Location = new Point(263, 13);
            NUDLoopCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            NUDLoopCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUDLoopCount.Name = "NUDLoopCount";
            NUDLoopCount.Size = new Size(70, 28);
            NUDLoopCount.TabIndex = 1;
            NUDLoopCount.TextAlign = HorizontalAlignment.Center;
            NUDLoopCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // LBLoopCount
            // 
            LBLoopCount.AutoSize = true;
            LBLoopCount.Location = new Point(182, 17);
            LBLoopCount.Name = "LBLoopCount";
            LBLoopCount.Size = new Size(78, 21);
            LBLoopCount.TabIndex = 2;
            LBLoopCount.Text = "循环次数:";
            // 
            // NUDFileCount
            // 
            NUDFileCount.Location = new Point(96, 56);
            NUDFileCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            NUDFileCount.Name = "NUDFileCount";
            NUDFileCount.Size = new Size(70, 28);
            NUDFileCount.TabIndex = 3;
            NUDFileCount.TextAlign = HorizontalAlignment.Center;
            NUDFileCount.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // LBFileCount
            // 
            LBFileCount.AutoSize = true;
            LBFileCount.Location = new Point(15, 60);
            LBFileCount.Name = "LBFileCount";
            LBFileCount.Size = new Size(78, 21);
            LBFileCount.TabIndex = 4;
            LBFileCount.Text = "文件计数:";
            // 
            // NUDStartIndex
            // 
            NUDStartIndex.Location = new Point(96, 13);
            NUDStartIndex.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NUDStartIndex.Name = "NUDStartIndex";
            NUDStartIndex.Size = new Size(70, 28);
            NUDStartIndex.TabIndex = 5;
            NUDStartIndex.TextAlign = HorizontalAlignment.Center;
            NUDStartIndex.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // LBStartIndex
            // 
            LBStartIndex.AutoSize = true;
            LBStartIndex.Location = new Point(15, 17);
            LBStartIndex.Name = "LBStartIndex";
            LBStartIndex.Size = new Size(78, 21);
            LBStartIndex.TabIndex = 6;
            LBStartIndex.Text = "开始序号:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 159);
            Controls.Add(tabControl1);
            Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "宝可梦bin文件整理工具";
            tabControl1.ResumeLayout(false);
            TPPokemonModel.ResumeLayout(false);
            TPPokemonModel.PerformLayout();
            TPIndexGen.ResumeLayout(false);
            TPIndexGen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUDStringWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDLoopCount).EndInit();
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
        private NumericUpDown NUDLoopCount;
        private Label LBLoopCount;
        private NumericUpDown NUDStringWidth;
        private Label LBStringWidth;
    }
}