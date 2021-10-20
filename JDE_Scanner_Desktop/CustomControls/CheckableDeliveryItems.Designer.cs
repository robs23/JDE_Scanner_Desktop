
namespace JDE_Scanner_Desktop.CustomControls
{
    partial class CheckableDeliveryItems
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlannedDelivery = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblSuppliersOrderNumber = new System.Windows.Forms.Label();
            this.lblCreatedOn = new System.Windows.Forms.Label();
            this.tlpParts = new System.Windows.Forms.TableLayoutPanel();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.tlpHeader, 0, 0);
            this.tlpMain.Controls.Add(this.tlpParts, 0, 1);
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(787, 144);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpHeader
            // 
            this.tlpHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpHeader.ColumnCount = 6;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.Controls.Add(this.lblPlannedDelivery, 2, 0);
            this.tlpHeader.Controls.Add(this.lblSupplier, 3, 0);
            this.tlpHeader.Controls.Add(this.lblSuppliersOrderNumber, 4, 0);
            this.tlpHeader.Controls.Add(this.lblCreatedOn, 5, 0);
            this.tlpHeader.Controls.Add(this.lblOrderNumber, 1, 0);
            this.tlpHeader.Location = new System.Drawing.Point(3, 3);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Size = new System.Drawing.Size(781, 44);
            this.tlpHeader.TabIndex = 0;
            // 
            // lblPlannedDelivery
            // 
            this.lblPlannedDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlannedDelivery.AutoSize = true;
            this.lblPlannedDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPlannedDelivery.Location = new System.Drawing.Point(183, 14);
            this.lblPlannedDelivery.Name = "lblPlannedDelivery";
            this.lblPlannedDelivery.Size = new System.Drawing.Size(144, 15);
            this.lblPlannedDelivery.TabIndex = 1;
            this.lblPlannedDelivery.Text = "Planowana dostawa";
            this.lblPlannedDelivery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSupplier.Location = new System.Drawing.Point(333, 14);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(144, 15);
            this.lblSupplier.TabIndex = 2;
            this.lblSupplier.Text = "Dostawca";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSuppliersOrderNumber
            // 
            this.lblSuppliersOrderNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuppliersOrderNumber.AutoSize = true;
            this.lblSuppliersOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSuppliersOrderNumber.Location = new System.Drawing.Point(483, 7);
            this.lblSuppliersOrderNumber.Name = "lblSuppliersOrderNumber";
            this.lblSuppliersOrderNumber.Size = new System.Drawing.Size(144, 30);
            this.lblSuppliersOrderNumber.TabIndex = 3;
            this.lblSuppliersOrderNumber.Text = "Numer zamówienia dostawcy";
            this.lblSuppliersOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedOn.AutoSize = true;
            this.lblCreatedOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCreatedOn.Location = new System.Drawing.Point(633, 14);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(145, 15);
            this.lblCreatedOn.TabIndex = 4;
            this.lblCreatedOn.Text = "Data zamówienia";
            this.lblCreatedOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpParts
            // 
            this.tlpParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpParts.ColumnCount = 6;
            this.tlpParts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpParts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpParts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpParts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpParts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpParts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpParts.Location = new System.Drawing.Point(3, 53);
            this.tlpParts.Name = "tlpParts";
            this.tlpParts.RowCount = 1;
            this.tlpParts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParts.Size = new System.Drawing.Size(781, 88);
            this.tlpParts.TabIndex = 1;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOrderNumber.Location = new System.Drawing.Point(33, 14);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(144, 15);
            this.lblOrderNumber.TabIndex = 5;
            this.lblOrderNumber.Text = "Numer zamówienia";
            // 
            // CheckableDeliveryItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "CheckableDeliveryItems";
            this.Size = new System.Drawing.Size(793, 150);
            this.tlpMain.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            this.tlpHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Label lblPlannedDelivery;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblSuppliersOrderNumber;
        private System.Windows.Forms.Label lblCreatedOn;
        private System.Windows.Forms.TableLayoutPanel tlpParts;
        private System.Windows.Forms.Label lblOrderNumber;
    }
}
