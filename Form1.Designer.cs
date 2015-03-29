namespace Jane
{
    partial class panel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(panel));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showJaneTool = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTool = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.context.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // context
            // 
            this.context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showJaneTool,
            this.exitTool});
            this.context.Name = "context";
            resources.ApplyResources(this.context, "context");
            this.context.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showJaneTool
            // 
            this.showJaneTool.Name = "showJaneTool";
            resources.ApplyResources(this.showJaneTool, "showJaneTool");
            this.showJaneTool.Click += new System.EventHandler(this.showJaneTool_Click);
            // 
            // exitTool
            // 
            this.exitTool.Name = "exitTool";
            resources.ApplyResources(this.exitTool, "exitTool");
            this.exitTool.Click += new System.EventHandler(this.exitTool_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.context;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // panel
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "panel";
            this.Load += new System.EventHandler(this.panel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.context.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ContextMenuStrip context;
        private System.Windows.Forms.ToolStripMenuItem showJaneTool;
        private System.Windows.Forms.ToolStripMenuItem exitTool;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

