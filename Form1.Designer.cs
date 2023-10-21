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
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(TPPokemonModel);
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