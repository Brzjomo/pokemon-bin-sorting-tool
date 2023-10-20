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
            tabControl1.SuspendLayout();
            TPPokemonModel.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TPPokemonModel);
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
    }
}