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
            tabControl1 = new TabControl();
            TPPokemonModel = new TabPage();
            CBIfReplaceBlank = new CheckBox();
            labelGameVersion = new Label();
            CBGameVersion = new ComboBox();
            TPTool = new TabPage();
            BTTXTToYML = new Button();
            tabControl1.SuspendLayout();
            TPPokemonModel.SuspendLayout();
            TPTool.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TPPokemonModel);
            tabControl1.Controls.Add(TPTool);
            tabControl1.Location = new Point(17, 15);
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(599, 360);
            tabControl1.TabIndex = 0;
            // 
            // TPPokemonModel
            // 
            TPPokemonModel.Controls.Add(CBIfReplaceBlank);
            TPPokemonModel.Controls.Add(labelGameVersion);
            TPPokemonModel.Controls.Add(CBGameVersion);
            TPPokemonModel.Location = new Point(4, 30);
            TPPokemonModel.Margin = new Padding(4);
            TPPokemonModel.Name = "TPPokemonModel";
            TPPokemonModel.Padding = new Padding(4);
            TPPokemonModel.Size = new Size(591, 326);
            TPPokemonModel.TabIndex = 0;
            TPPokemonModel.Text = "宝可梦模型";
            TPPokemonModel.UseVisualStyleBackColor = true;
            // 
            // CBIfReplaceBlank
            // 
            CBIfReplaceBlank.AutoSize = true;
            CBIfReplaceBlank.Location = new Point(61, 87);
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
            CBGameVersion.Items.AddRange(new object[] { "究极日月" });
            CBGameVersion.Location = new Point(104, 14);
            CBGameVersion.Margin = new Padding(4);
            CBGameVersion.Name = "CBGameVersion";
            CBGameVersion.Size = new Size(171, 29);
            CBGameVersion.TabIndex = 0;
            // 
            // TPTool
            // 
            TPTool.Controls.Add(BTTXTToYML);
            TPTool.Location = new Point(4, 26);
            TPTool.Name = "TPTool";
            TPTool.Padding = new Padding(3);
            TPTool.Size = new Size(588, 331);
            TPTool.TabIndex = 1;
            TPTool.Text = "工具";
            TPTool.UseVisualStyleBackColor = true;
            // 
            // BTTXTToYML
            // 
            BTTXTToYML.Location = new Point(26, 24);
            BTTXTToYML.Name = "BTTXTToYML";
            BTTXTToYML.Size = new Size(129, 48);
            BTTXTToYML.TabIndex = 0;
            BTTXTToYML.Text = "TXT转YML";
            BTTXTToYML.UseVisualStyleBackColor = true;
            BTTXTToYML.Click += BTTXTToYML_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 388);
            Controls.Add(tabControl1);
            Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "宝可梦bin文件整理工具";
            tabControl1.ResumeLayout(false);
            TPPokemonModel.ResumeLayout(false);
            TPPokemonModel.PerformLayout();
            TPTool.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TPPokemonModel;
        private ComboBox CBGameVersion;
        private Label labelGameVersion;
        private CheckBox CBIfReplaceBlank;
        private TabPage TPTool;
        private Button BTTXTToYML;
    }
}