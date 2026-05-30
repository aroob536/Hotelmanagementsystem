namespace HMS.Forms
{
    partial class BillingForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel         pnlHeader;
        private Label         lblFormTitle;
        private Panel         pnlLeft;
        private Label         lblLeftHeader;
        private Label         lblBooking;
        private ComboBox      cmbBooking;
        private Label         lblRoomCharges;
        private TextBox       txtRoomCharges;
        private Label         lblExtraCharges;
        private TextBox       txtExtraCharges;
        private Label         lblDiscount;
        private TextBox       txtDiscount;
        private Label         lblCalcHdr;
        private Label         lblCalc;
        private Label         lblTotal2;
        private TextBox       txtTotal;
        private Label         lblPaidAmount;
        private TextBox       txtPaidAmount;
        private Label         lblPayment;
        private ComboBox      cmbPayment;
        private Button        btnGenerateBill;
        private Button        btnClear;
        private Panel         pnlRight;
        private Button        btnRefresh;
        private Button        btnViewBill;
        private Button        btnDeleteBill;
        private Label         lblBillCount;
        private Label         lblTotalRevenue;
        private DataGridView  dgvBills;
        private DataGridViewTextBoxColumn colBillId;
        private DataGridViewTextBoxColumn colBookingId;
        private DataGridViewTextBoxColumn colCustName;
        private DataGridViewTextBoxColumn colRoomNo;
        private DataGridViewTextBoxColumn colBillTotal;
        private DataGridViewTextBoxColumn colBillPaid;
        private DataGridViewTextBoxColumn colBillBalance;
        private DataGridViewTextBoxColumn colPayMethod;
        private DataGridViewTextBoxColumn colBillDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            colBillId     = new DataGridViewTextBoxColumn();
            colBookingId  = new DataGridViewTextBoxColumn();
            colCustName   = new DataGridViewTextBoxColumn();
            colRoomNo     = new DataGridViewTextBoxColumn();
            colBillTotal  = new DataGridViewTextBoxColumn();
            colBillPaid   = new DataGridViewTextBoxColumn();
            colBillBalance= new DataGridViewTextBoxColumn();
            colPayMethod  = new DataGridViewTextBoxColumn();
            colBillDate   = new DataGridViewTextBoxColumn();
            dgvBills      = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
            SuspendLayout();

            // ── HEADER ──────────────────────────────────────────────────────
            pnlHeader           = new Panel();
            pnlHeader.BackColor = Color.FromArgb(142, 68, 173);
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 50;

            lblFormTitle           = new Label();
            lblFormTitle.Text      = "Billing";
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFormTitle.Location  = new Point(15, 10);
            lblFormTitle.Size      = new Size(300, 30);
            lblFormTitle.AutoSize  = false;
            pnlHeader.Controls.Add(lblFormTitle);

            // ── LEFT PANEL ───────────────────────────────────────────────────
            pnlLeft           = new Panel();
            pnlLeft.BackColor = Color.White;
            pnlLeft.Dock      = DockStyle.Left;
            pnlLeft.Width     = 310;

            lblLeftHeader           = new Label();
            lblLeftHeader.Text      = "Generate New Bill";
            lblLeftHeader.ForeColor = Color.FromArgb(142, 68, 173);
            lblLeftHeader.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLeftHeader.Location  = new Point(14, 12);
            lblLeftHeader.Size      = new Size(280, 26);
            lblLeftHeader.AutoSize  = false;

            // Row 1 — Booking  y=46
            lblBooking          = L("Select Booking  *", 14, 46);
            cmbBooking          = new ComboBox();
            cmbBooking.Font     = new Font("Segoe UI", 9F);
            cmbBooking.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBooking.Location = new Point(14, 66);
            cmbBooking.Size     = new Size(280, 26);
            cmbBooking.SelectedIndexChanged += cmbBooking_SelectedIndexChanged;

            // Row 2 — Room Charges / Extra Charges  y=106
            lblRoomCharges           = new Label();
            lblRoomCharges.Text      = "Room Charges (Rs.)";
            lblRoomCharges.ForeColor = Color.FromArgb(60, 60, 80);
            lblRoomCharges.Font      = new Font("Segoe UI", 8.5F);
            lblRoomCharges.Location  = new Point(14, 106);
            lblRoomCharges.Size      = new Size(130, 18);
            lblRoomCharges.AutoSize  = false;

            txtRoomCharges             = new TextBox();
            txtRoomCharges.Font        = new Font("Segoe UI", 9.5F);
            txtRoomCharges.BorderStyle = BorderStyle.FixedSingle;
            txtRoomCharges.Location    = new Point(14, 126);
            txtRoomCharges.Size        = new Size(130, 26);
            txtRoomCharges.Text        = "0";
            txtRoomCharges.TextChanged += txtCharges_TextChanged;

            lblExtraCharges           = new Label();
            lblExtraCharges.Text      = "Extra Charges (Rs.)";
            lblExtraCharges.ForeColor = Color.FromArgb(60, 60, 80);
            lblExtraCharges.Font      = new Font("Segoe UI", 8.5F);
            lblExtraCharges.Location  = new Point(160, 106);
            lblExtraCharges.Size      = new Size(134, 18);
            lblExtraCharges.AutoSize  = false;

            txtExtraCharges             = new TextBox();
            txtExtraCharges.Font        = new Font("Segoe UI", 9.5F);
            txtExtraCharges.BorderStyle = BorderStyle.FixedSingle;
            txtExtraCharges.Location    = new Point(160, 126);
            txtExtraCharges.Size        = new Size(134, 26);
            txtExtraCharges.Text        = "0";
            txtExtraCharges.TextChanged += txtCharges_TextChanged;

            // Row 3 — Discount  y=166
            lblDiscount           = new Label();
            lblDiscount.Text      = "Discount (Rs.)";
            lblDiscount.ForeColor = Color.FromArgb(60, 60, 80);
            lblDiscount.Font      = new Font("Segoe UI", 8.5F);
            lblDiscount.Location  = new Point(14, 166);
            lblDiscount.Size      = new Size(130, 18);
            lblDiscount.AutoSize  = false;

            txtDiscount             = new TextBox();
            txtDiscount.Font        = new Font("Segoe UI", 9.5F);
            txtDiscount.BorderStyle = BorderStyle.FixedSingle;
            txtDiscount.Location    = new Point(14, 186);
            txtDiscount.Size        = new Size(130, 26);
            txtDiscount.Text        = "0";
            txtDiscount.TextChanged += txtCharges_TextChanged;

            var lblTaxNote           = new Label();
            lblTaxNote.Text          = "Tax: 10% (auto)";
            lblTaxNote.ForeColor     = Color.FromArgb(142, 68, 173);
            lblTaxNote.Font          = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblTaxNote.Location      = new Point(160, 190);
            lblTaxNote.Size          = new Size(134, 18);
            lblTaxNote.AutoSize      = false;

            // Breakdown label  y=226
            lblCalcHdr           = new Label();
            lblCalcHdr.Text      = "Breakdown:";
            lblCalcHdr.ForeColor = Color.FromArgb(100, 100, 100);
            lblCalcHdr.Font      = new Font("Segoe UI", 8F);
            lblCalcHdr.Location  = new Point(14, 226);
            lblCalcHdr.Size      = new Size(280, 16);
            lblCalcHdr.AutoSize  = false;

            lblCalc           = new Label();
            lblCalc.Text      = "Select a booking above";
            lblCalc.ForeColor = Color.FromArgb(142, 68, 173);
            lblCalc.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblCalc.Location  = new Point(14, 244);
            lblCalc.Size      = new Size(280, 18);
            lblCalc.AutoSize  = false;

            // Row 5 — Total  y=276
            lblTotal2           = new Label();
            lblTotal2.Text      = "Total Amount (Rs.)";
            lblTotal2.ForeColor = Color.FromArgb(60, 60, 80);
            lblTotal2.Font      = new Font("Segoe UI", 8.5F);
            lblTotal2.Location  = new Point(14, 276);
            lblTotal2.Size      = new Size(280, 18);
            lblTotal2.AutoSize  = false;

            txtTotal             = new TextBox();
            txtTotal.Font        = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtTotal.ForeColor   = Color.FromArgb(142, 68, 173);
            txtTotal.BackColor   = Color.FromArgb(248, 244, 252);
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.ReadOnly    = true;
            txtTotal.Location    = new Point(14, 296);
            txtTotal.Size        = new Size(280, 30);
            txtTotal.Text        = "0";

            // Row 6 — Paid / Payment  y=342
            lblPaidAmount           = new Label();
            lblPaidAmount.Text      = "Paid Amount (Rs.)  — type manually";
            lblPaidAmount.ForeColor = Color.FromArgb(60, 60, 80);
            lblPaidAmount.Font      = new Font("Segoe UI", 8.5F);
            lblPaidAmount.Location  = new Point(14, 342);
            lblPaidAmount.Size      = new Size(280, 18);
            lblPaidAmount.AutoSize  = false;

            txtPaidAmount             = new TextBox();
            txtPaidAmount.Font        = new Font("Segoe UI", 10F);
            txtPaidAmount.ForeColor   = Color.FromArgb(39, 174, 96);
            txtPaidAmount.BorderStyle = BorderStyle.FixedSingle;
            txtPaidAmount.Location    = new Point(14, 362);
            txtPaidAmount.Size        = new Size(130, 26);
            txtPaidAmount.Text        = "0";

            lblPayment           = new Label();
            lblPayment.Text      = "Payment Method";
            lblPayment.ForeColor = Color.FromArgb(60, 60, 80);
            lblPayment.Font      = new Font("Segoe UI", 8.5F);
            lblPayment.Location  = new Point(160, 342);
            lblPayment.Size      = new Size(134, 18);
            lblPayment.AutoSize  = false;

            cmbPayment               = new ComboBox();
            cmbPayment.Font          = new Font("Segoe UI", 9.5F);
            cmbPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPayment.Location      = new Point(160, 362);
            cmbPayment.Size          = new Size(134, 26);
            cmbPayment.Items.Add("Cash");
            cmbPayment.Items.Add("Card");
            cmbPayment.Items.Add("Bank Transfer");
            cmbPayment.Items.Add("Cheque");
            cmbPayment.Items.Add("Online");
            cmbPayment.SelectedIndex = 0;

            // Buttons  y=408
            btnGenerateBill = Btn("Generate Bill", Color.FromArgb(142,68,173), Color.White, 14, 408, 280, 40);
            btnClear        = Btn("Clear",         Color.FromArgb(127,140,141),Color.White, 14, 456, 134, 32);

            btnGenerateBill.Click += btnGenerateBill_Click;
            btnClear.Click        += btnClear_Click;

            pnlLeft.Controls.Add(lblLeftHeader);
            pnlLeft.Controls.Add(lblBooking);      pnlLeft.Controls.Add(cmbBooking);
            pnlLeft.Controls.Add(lblRoomCharges);  pnlLeft.Controls.Add(txtRoomCharges);
            pnlLeft.Controls.Add(lblExtraCharges); pnlLeft.Controls.Add(txtExtraCharges);
            pnlLeft.Controls.Add(lblDiscount);     pnlLeft.Controls.Add(txtDiscount);
            pnlLeft.Controls.Add(lblTaxNote);
            pnlLeft.Controls.Add(lblCalcHdr);      pnlLeft.Controls.Add(lblCalc);
            pnlLeft.Controls.Add(lblTotal2);        pnlLeft.Controls.Add(txtTotal);
            pnlLeft.Controls.Add(lblPaidAmount);   pnlLeft.Controls.Add(txtPaidAmount);
            pnlLeft.Controls.Add(lblPayment);      pnlLeft.Controls.Add(cmbPayment);
            pnlLeft.Controls.Add(btnGenerateBill); pnlLeft.Controls.Add(btnClear);

            // ── RIGHT PANEL ──────────────────────────────────────────────────
            pnlRight           = new Panel();
            pnlRight.BackColor = Color.FromArgb(245, 247, 250);
            pnlRight.Dock      = DockStyle.Fill;

            btnRefresh    = Btn("Refresh",    Color.FromArgb(52,152,219),  Color.White, 12,  10, 90, 28);
            btnViewBill   = Btn("View Bill",  Color.FromArgb(39,174,96),   Color.White, 110, 10, 90, 28);
            btnDeleteBill = Btn("Delete Bill",Color.FromArgb(192,57,43),   Color.White, 208, 10, 90, 28);
            btnRefresh.Click    += btnRefresh_Click;
            btnViewBill.Click   += btnViewBill_Click;
            btnDeleteBill.Click += btnDeleteBill_Click;

            lblBillCount           = new Label();
            lblBillCount.Text      = "Total Bills: 0";
            lblBillCount.ForeColor = Color.FromArgb(80, 80, 80);
            lblBillCount.Font      = new Font("Segoe UI", 9F);
            lblBillCount.Location  = new Point(308, 14);
            lblBillCount.Size      = new Size(160, 20);
            lblBillCount.AutoSize  = false;

            lblTotalRevenue           = new Label();
            lblTotalRevenue.Text      = "Revenue: Rs. 0";
            lblTotalRevenue.ForeColor = Color.FromArgb(142, 68, 173);
            lblTotalRevenue.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalRevenue.Location  = new Point(476, 12);
            lblTotalRevenue.Size      = new Size(300, 24);
            lblTotalRevenue.AutoSize  = false;

            // Grid columns
            colBillId.HeaderText      = "ID";          colBillId.Name      = "BillId";     colBillId.FillWeight      = 40;
            colBookingId.HeaderText   = "Booking#";    colBookingId.Name   = "BookingId";  colBookingId.FillWeight   = 70;
            colCustName.HeaderText    = "Customer";    colCustName.Name    = "CustName";   colCustName.FillWeight    = 160;
            colRoomNo.HeaderText      = "Room";        colRoomNo.Name      = "RoomNo";     colRoomNo.FillWeight      = 70;
            colBillTotal.HeaderText   = "Total";       colBillTotal.Name   = "BillTotal";  colBillTotal.FillWeight   = 100;
            colBillPaid.HeaderText    = "Paid";        colBillPaid.Name    = "BillPaid";   colBillPaid.FillWeight    = 100;
            colBillBalance.HeaderText = "Balance";     colBillBalance.Name = "BillBal";    colBillBalance.FillWeight = 100;
            colPayMethod.HeaderText   = "Payment";     colPayMethod.Name   = "PayMethod";  colPayMethod.FillWeight   = 90;
            colBillDate.HeaderText    = "Date";        colBillDate.Name    = "BillDate";   colBillDate.FillWeight    = 90;
            colBillBalance.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
            colBillTotal.DefaultCellStyle.Font        = new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvBills.Location = new Point(10, 46);
            dgvBills.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom
                              | AnchorStyles.Left | AnchorStyles.Right;
            dgvBills.Size     = new Size(840, 530);
            dgvBills.BackgroundColor = Color.White;
            dgvBills.BorderStyle     = BorderStyle.None;
            dgvBills.GridColor       = Color.FromArgb(220, 205, 235);
            dgvBills.ColumnHeadersHeight = 36;
            dgvBills.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(142, 68, 173);
            dgvBills.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBills.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvBills.EnableHeadersVisualStyles = false;
            dgvBills.DefaultCellStyle.Font     = new Font("Segoe UI", 9F);
            dgvBills.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 200, 235);
            dgvBills.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvBills.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 247, 253);
            dgvBills.RowHeadersVisible   = false;
            dgvBills.ReadOnly            = true;
            dgvBills.AllowUserToAddRows  = false;
            dgvBills.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.MultiSelect         = false;
            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBills.Columns.AddRange(new DataGridViewColumn[]
            {
                colBillId, colBookingId, colCustName, colRoomNo,
                colBillTotal, colBillPaid, colBillBalance, colPayMethod, colBillDate
            });
            dgvBills.Columns["BillId"].Visible = false;
            dgvBills.SelectionChanged += dgvBills_SelectionChanged;

            pnlRight.Controls.Add(btnRefresh);
            pnlRight.Controls.Add(btnViewBill);
            pnlRight.Controls.Add(btnDeleteBill);
            pnlRight.Controls.Add(lblBillCount);
            pnlRight.Controls.Add(lblTotalRevenue);
            pnlRight.Controls.Add(dgvBills);

            // ── FORM ────────────────────────────────────────────────────────
            BackColor     = Color.FromArgb(240, 245, 250);
            ClientSize    = new Size(1160, 660);
            Name          = "BillingForm";
            Text          = "Billing - HMS";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            ResumeLayout(false);
        }

        private Label L(string t, int x, int y) => new Label
        {
            Text=t, ForeColor=Color.FromArgb(60,60,80), Font=new Font("Segoe UI",8.5F),
            Location=new Point(x,y), Size=new Size(280,18), AutoSize=false
        };
        private Button Btn(string t, Color back, Color fore, int x, int y, int w, int h)
        {
            var b = new Button
            {
                Text=t, BackColor=back, ForeColor=fore, FlatStyle=FlatStyle.Flat,
                Font=new Font("Segoe UI",9F,FontStyle.Bold),
                Location=new Point(x,y), Size=new Size(w,h), Cursor=Cursors.Hand
            };
            b.FlatAppearance.BorderSize=0; return b;
        }
    }
}
