using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Data;
using System.Windows.Forms;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Repo;
using System.Linq;

namespace TicketTracker
{
    public partial class frmMain : Form
    {       
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                var repo = new SeasonRepository();
                var seasons = repo.GetAll();
                
                cboSeason.DisplayMember = "Description";
                cboSeason.ValueMember = "SeasonId";
                cboSeason.DataSource = seasons;

                if (seasons.Count > 0)
                {
                    cboSeason.SelectedValue = seasons[0].SeasonId;
                    cboSeason_SelectedIndexChanged(cboSeason, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customize = new frmCustomize();
            customize.ShowDialog();
        }

        private void cboSeason_SelectedIndexChanged(object sender, EventArgs e)
        {           
            int seasonId;
            if (cboSeason.SelectedValue.GetType() == typeof(DataRowView))
            {
                seasonId = 0;
            }
            else
            {
                seasonId = Convert.ToInt32(cboSeason.SelectedValue);
            }            
            
            try
            {
                var performanceRepo = new PerformanceRepository();
                var showRepo = new ShowRepository();

                var shows = showRepo.GetList(s => s.SeasonId == seasonId, s => s.ShowType, s => s.Season);

                lstShows.Items.Clear();
                foreach (var show in shows)
                {
                    var performances = performanceRepo.GetList(p => p.ShowId == show.ShowId, p => p.Tickets);

                    var item = new ListViewItem(show.Title);
                    item.SubItems.Add(show.ShowType.Name);
                    item.SubItems.Add(show.ShowId.ToString());
                    item.SubItems.Add(show.Season.Description);
                    item.SubItems.Add(performances.Sum(p => p.Tickets.Sum(t => t.AmountSold.GetValueOrDefault())).ToString());
                    item.SubItems.Add(performances.Sum(p => p.Tickets.Sum(t => t.AmountSold.GetValueOrDefault() * t.Price.GetValueOrDefault())).ToString());

                    lstShows.Items.Add(item);
                }

                lstShows.View = View.Details;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
        }

        private void lstShows_DoubleClick(object sender, EventArgs e)
        {
            var showDetails = new frmShowDetails(((ListView)sender).FocusedItem, false);
            showDetails.SaveButtonClicked += new EventHandler(evtSaveButtonClicked);
            showDetails.ShowDialog();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var showDetails = new frmShowDetails(null, true);
            showDetails.SaveButtonClicked += new EventHandler(evtSaveButtonClicked);
            showDetails.ShowDialog();
        }

        void evtSaveButtonClicked(object sender, EventArgs e)
        {
            cboSeason_SelectedIndexChanged(cboSeason, new EventArgs());
        }

        private void btnDeleteShow_Click(object sender, EventArgs e)
        {
            if (lstShows.FocusedItem == null)
            {
                MessageBox.Show("You must choose a Show to Delete", "No Show Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("You are about to delete this show.  If you do, all details will be removed." + Environment.NewLine + Environment.NewLine + "Are you sure you still want to continue?", "Really Delete Show?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                var showId = Convert.ToInt32(lstShows.FocusedItem.SubItems[2].Text);

                try
                {
                    var showRepository = new ShowRepository();
                    showRepository.DeleteShow(showId);

                    cboSeason_SelectedIndexChanged(cboSeason, new EventArgs());
                }
                catch (Exception ex)
                {
                    Helper.LogError(ex);
                    throw;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            var showRepo = new ShowRepository();
            var performanceRepo = new PerformanceRepository();

            if (lstShows.FocusedItem == null)
            {
                MessageBox.Show("You must choose a Show to create a PDF for", "No Show Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var showId = Convert.ToInt32(lstShows.FocusedItem.SubItems[2].Text);
                var showInfo = showRepo.GetAllShowInformation(showId);

                var dest = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + lstShows.FocusedItem.SubItems[0].Text + ".pdf";

                using (var pdfWriter = new PdfWriter(dest))
                {
                    using (var pdfDocument = new PdfDocument(pdfWriter))
                    {
                        using (var document = new Document(pdfDocument, PageSize.LETTER.Rotate()))
                        {
                            document.SetTopMargin(10);
                            document.SetBottomMargin(10);

                            //912 - Total width
                            float[] columnWidths = { 138, 133, 137, 130, 130, 107, 137 };
                            
                            var table = new Table(columnWidths);
                            table.SetWidthPercent(100);
                        
                            PdfFontFactory.Register(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Fonts\\" + "calibri.ttf", "calibri");
                            PdfFontFactory.Register(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Fonts\\" + "calibrib.ttf", "calibri-bold");

                            var cellHeight = 12f;
                            var fontSize = 8f;
                            var font = PdfFontFactory.CreateRegisteredFont("calibri");
                            var fontBold = PdfFontFactory.CreateRegisteredFont("calibri-bold");

                            // Render the show details
                            RenderShowDetails(table, font, fontBold, showInfo, cellHeight, fontSize);

                            // Render the Cash/Check section
                            RenderCashCheckDetails(table, font, fontBold, showInfo, cellHeight, fontSize);

                            // Render the Credit Card section
                            RenderCreditCardDetails(table, font, fontBold, showInfo, cellHeight, fontSize);

                            // Render the Fees section
                            RenderFeesAndMisc(table, font, fontBold, showInfo, cellHeight, fontSize);

                            // Render the Show Totals section
                            RenderShowTotals(table, font, fontBold, showInfo, cellHeight, fontSize);

                            // Render Ticket and Vouchers section
                            RenderTicketSection(table, font, fontBold, showInfo, cellHeight, fontSize);

                            // Render Summary section
                            RenderSummarySection(table, font, fontBold, showInfo, cellHeight, fontSize);

                            document.Add(table);
                            document.Close();

                            MessageBox.Show("Document generation complete!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        pdfDocument.Close();
                    }

                    pdfWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex);
                throw;
            }            
        }

        private void RenderSummarySection(Table table, PdfFont regularFont, PdfFont boldFont, ShowDto showDto, float cellHeight, float fontSize)
        {
            // Title
            var titleCell1 = new Cell(1, 1);
            titleCell1.SetHeight(cellHeight);
            titleCell1.Add(new Paragraph("Summary"));
            titleCell1.SetFont(boldFont);
            titleCell1.SetFontSize(fontSize);
            titleCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(titleCell1);

            var titleCell2 = new Cell(1, 5);
            titleCell2.SetHeight(cellHeight);
            titleCell2.Add(new Paragraph("Who Gets It"));
            titleCell2.SetFont(boldFont);
            titleCell2.SetFontSize(fontSize);
            titleCell2.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(titleCell2);

            var titleCell3 = new Cell(1, 1);
            titleCell3.SetHeight(cellHeight);
            titleCell3.Add(new Paragraph("Amount"));
            titleCell3.SetFont(boldFont);
            titleCell3.SetFontSize(fontSize);
            titleCell3.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(titleCell3);

            // Cash
            var cashCell1 = new Cell(1, 1);
            cashCell1.SetHeight(cellHeight);
            cashCell1.Add(new Paragraph("Tickets (Cash/Check)"));
            cashCell1.SetFont(regularFont);
            cashCell1.SetFontSize(fontSize);
            cashCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(cashCell1);

            var cashCell2 = new Cell(1, 5);
            cashCell2.SetHeight(cellHeight);
            cashCell2.Add(new Paragraph("School"));
            cashCell2.SetFont(regularFont);
            cashCell2.SetFontSize(fontSize);
            cashCell2.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(cashCell2);

            var cashCell3 = new Cell(1, 1);
            cashCell3.SetHeight(cellHeight);

            var totalCash = showDto.Performances.Sum(p => p.ChangeCollected.GetValueOrDefault() + p.OnesCollected.GetValueOrDefault() + p.FivesCollected.GetValueOrDefault() +
                    p.TensCollected.GetValueOrDefault() + p.TwentiesCollected.GetValueOrDefault() + p.FiftiesCollected.GetValueOrDefault() +
                    p.HundredsCollected.GetValueOrDefault()) + showDto.Performances.Sum(p => p.CheckAmount.GetValueOrDefault());

            cashCell3.Add(new Paragraph(totalCash.ToString("0.00")));
            cashCell3.SetFont(regularFont);
            cashCell3.SetFontSize(fontSize);
            cashCell3.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(cashCell3);

            // Credit Card
            var creditCardCell1 = new Cell(1, 1);
            creditCardCell1.SetHeight(cellHeight);
            creditCardCell1.Add(new Paragraph("Tickets (Credit Card)"));
            creditCardCell1.SetFont(regularFont);
            creditCardCell1.SetFontSize(fontSize);
            creditCardCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(creditCardCell1);

            var creditCardCell2 = new Cell(1, 5);
            creditCardCell2.SetHeight(cellHeight);
            creditCardCell2.Add(new Paragraph("Parent account pays to school"));
            creditCardCell2.SetFont(regularFont);
            creditCardCell2.SetFontSize(fontSize);
            creditCardCell2.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(creditCardCell2);

            var creditCardCell3 = new Cell(1, 1);
            creditCardCell3.SetHeight(cellHeight);

            var totalCreditCards = showDto.Performances.Sum(p => p.CreditCardAmount.GetValueOrDefault());

            creditCardCell3.Add(new Paragraph(totalCreditCards.ToString("0.00")));
            creditCardCell3.SetFont(regularFont);
            creditCardCell3.SetFontSize(fontSize);
            creditCardCell3.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(creditCardCell3);

            // Star Vouchers
            var starVouchersCell1 = new Cell(1, 1);
            starVouchersCell1.SetHeight(cellHeight);
            starVouchersCell1.Add(new Paragraph("Star Vouchers"));
            starVouchersCell1.SetFont(regularFont);
            starVouchersCell1.SetFontSize(fontSize);
            starVouchersCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(starVouchersCell1);

            var starVouchersCell2 = new Cell(1, 5);
            starVouchersCell2.SetHeight(cellHeight);
            starVouchersCell2.Add(new Paragraph("Stays in Parent account"));
            starVouchersCell2.SetFont(regularFont);
            starVouchersCell2.SetFontSize(fontSize);
            starVouchersCell2.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(starVouchersCell2);

            var starVouchersCell3 = new Cell(1, 1);
            starVouchersCell3.SetHeight(cellHeight);

            var totalStarVouchers = showDto.Performances.Sum(p => p.StarVoucherAmount.GetValueOrDefault());

            starVouchersCell3.Add(new Paragraph(totalStarVouchers.ToString("0.00")));
            starVouchersCell3.SetFont(regularFont);
            starVouchersCell3.SetFontSize(fontSize);
            starVouchersCell3.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(starVouchersCell3);

            // Concession Vouchers
            var concessionVouchersCell1 = new Cell(1, 1);
            concessionVouchersCell1.SetHeight(cellHeight);
            concessionVouchersCell1.Add(new Paragraph("Concession Vouchers"));
            concessionVouchersCell1.SetFont(regularFont);
            concessionVouchersCell1.SetFontSize(fontSize);
            concessionVouchersCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(concessionVouchersCell1);

            var concessionsVouchersCell2 = new Cell(1, 5);
            concessionsVouchersCell2.SetHeight(cellHeight);
            concessionsVouchersCell2.Add(new Paragraph("Stays in Parent account"));
            concessionsVouchersCell2.SetFont(regularFont);
            concessionsVouchersCell2.SetFontSize(fontSize);
            concessionsVouchersCell2.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(concessionsVouchersCell2);

            var concessionVouchersCell3 = new Cell(1, 1);
            concessionVouchersCell3.SetHeight(cellHeight);

            var totalConcessionVouchers = showDto.Performances.Sum(p => p.ConcessionVoucherAmount.GetValueOrDefault());

            concessionVouchersCell3.Add(new Paragraph(totalConcessionVouchers.ToString("0.00")));
            concessionVouchersCell3.SetFont(regularFont);
            concessionVouchersCell3.SetFontSize(fontSize);
            concessionVouchersCell3.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(concessionVouchersCell3);

            // Donations and Misc
            var donationsCell1 = new Cell(1, 1);
            donationsCell1.SetHeight(cellHeight);
            donationsCell1.Add(new Paragraph("Donations & Misc"));
            donationsCell1.SetFont(regularFont);
            donationsCell1.SetFontSize(fontSize);
            donationsCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(donationsCell1);

            var donationsCell2 = new Cell(1, 5);
            donationsCell2.SetHeight(cellHeight);
            donationsCell2.Add(new Paragraph("Stays in Parent account"));
            donationsCell2.SetFont(regularFont);
            donationsCell2.SetFontSize(fontSize);
            donationsCell2.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(donationsCell2);

            var donationsCell3 = new Cell(1, 1);
            donationsCell3.SetHeight(cellHeight);

            var totalDonations = showDto.Performances.Sum(p => p.Donations.GetValueOrDefault() + p.Miscellaneous.GetValueOrDefault());

            donationsCell3.Add(new Paragraph(totalDonations.ToString("0.00")));
            donationsCell3.SetFont(regularFont);
            donationsCell3.SetFontSize(fontSize);
            donationsCell3.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(donationsCell3);

            // Square Fees
            var squareFeesCell1 = new Cell(1, 1);
            squareFeesCell1.SetHeight(cellHeight);
            squareFeesCell1.Add(new Paragraph("Square Fees"));
            squareFeesCell1.SetFont(regularFont);
            squareFeesCell1.SetFontSize(fontSize);
            squareFeesCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(squareFeesCell1);

            var squareFeesCell2 = new Cell(1, 5);
            squareFeesCell2.SetHeight(cellHeight);
            squareFeesCell2.Add(new Paragraph("Square (2.75% per card swipe)"));
            squareFeesCell2.SetFont(regularFont);
            squareFeesCell2.SetFontSize(fontSize);
            squareFeesCell2.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(squareFeesCell2);

            var squareFeesCell3 = new Cell(1, 1);
            squareFeesCell3.SetHeight(cellHeight);

            var totalSquareFees = showDto.Performances.Sum(p => p.CreditCardFees.GetValueOrDefault());

            squareFeesCell3.Add(new Paragraph(totalSquareFees.ToString("0.00")));
            squareFeesCell3.SetFont(regularFont);
            squareFeesCell3.SetFontSize(fontSize);
            squareFeesCell3.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(squareFeesCell3);

            // Grand Totals
            var grandTotalsCell1 = new Cell(1, 1);
            grandTotalsCell1.SetHeight(cellHeight);
            grandTotalsCell1.Add(new Paragraph("Grand Total"));
            grandTotalsCell1.SetFont(boldFont);
            grandTotalsCell1.SetFontSize(fontSize);
            grandTotalsCell1.SetBorderTop(new DoubleBorder(3));
            grandTotalsCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(grandTotalsCell1);

            var grandTotalsCell2 = new Cell(1, 5);
            grandTotalsCell2.SetHeight(cellHeight);
            grandTotalsCell2.Add(new Paragraph(string.Empty));
            grandTotalsCell2.SetFont(regularFont);
            grandTotalsCell2.SetFontSize(fontSize);
            grandTotalsCell2.SetBorderTop(new DoubleBorder(3));
            grandTotalsCell2.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(grandTotalsCell2);

            var grandTotalsCell3 = new Cell(1, 1);
            grandTotalsCell3.SetHeight(cellHeight);

            var grandTotals = totalCash + totalCreditCards + totalStarVouchers + totalConcessionVouchers + totalDonations + totalSquareFees;

            grandTotalsCell3.Add(new Paragraph(grandTotals.ToString("0.00")));
            grandTotalsCell3.SetFont(regularFont);
            grandTotalsCell3.SetFontSize(fontSize);
            grandTotalsCell3.SetBorderTop(new DoubleBorder(3));
            grandTotalsCell3.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(grandTotalsCell3);
        }

        private void RenderShowTotals(Table table, PdfFont regularFont, PdfFont boldFont, ShowDto showDto, float cellHeight, float fontSize)
        {
            var numberOfPerformances = showDto.Performances.Count;

            // Title
            var titleCell = new Cell(1, 7);
            titleCell.SetHeight(cellHeight);
            titleCell.Add(new Paragraph("Show Totals"));
            titleCell.SetFont(boldFont);
            titleCell.SetFontSize(fontSize);
            titleCell.SetTextAlignment(TextAlignment.CENTER);
            table.AddCell(titleCell);

            // Grand totals
            var grandTotalsCell1 = new Cell();
            grandTotalsCell1.SetHeight(cellHeight);
            grandTotalsCell1.Add(new Paragraph("Grand Total"));
            grandTotalsCell1.SetFont(boldFont);
            grandTotalsCell1.SetFontSize(fontSize);
            grandTotalsCell1.SetTextAlignment(TextAlignment.LEFT);
            grandTotalsCell1.SetBorderTop(new DoubleBorder(3));
            table.AddCell(grandTotalsCell1);

            foreach (var performance in showDto.Performances)
            {
                var grandTotalCell = new Cell();
                grandTotalCell.SetHeight(cellHeight);

                var total = performance.ChangeCollected.GetValueOrDefault() + performance.OnesCollected.GetValueOrDefault() + performance.FivesCollected.GetValueOrDefault() +
                    performance.TensCollected.GetValueOrDefault() + performance.TwentiesCollected.GetValueOrDefault() + performance.FiftiesCollected.GetValueOrDefault() +
                    performance.HundredsCollected.GetValueOrDefault() + performance.CheckAmount.GetValueOrDefault() + performance.CreditCardAmount.GetValueOrDefault() +
                    performance.StarVoucherAmount.GetValueOrDefault() + performance.ConcessionVoucherAmount.GetValueOrDefault() + performance.CreditCardFees.GetValueOrDefault() +
                    performance.Donations.GetValueOrDefault() + performance.Miscellaneous.GetValueOrDefault();

                grandTotalCell.Add(total.ToString("0.00"));
                grandTotalCell.SetFont(regularFont);
                grandTotalCell.SetFontSize(fontSize);
                grandTotalCell.SetTextAlignment(TextAlignment.RIGHT);
                grandTotalCell.SetBorderTop(new DoubleBorder(3));
                table.AddCell(grandTotalCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var grandTotalCell = new Cell();
                grandTotalCell.SetHeight(cellHeight);
                grandTotalCell.Add(new Paragraph(string.Empty));
                grandTotalCell.SetTextAlignment(TextAlignment.CENTER);
                grandTotalCell.SetBorderTop(new DoubleBorder(3));
                table.AddCell(grandTotalCell);
            }

            var grandTotalCell7 = new Cell();
            grandTotalCell7.SetHeight(cellHeight);

            var grandTotalFees = showDto.Performances.Sum(p => p.ChangeCollected.GetValueOrDefault() + p.OnesCollected.GetValueOrDefault() + p.FivesCollected.GetValueOrDefault() +
                    p.TensCollected.GetValueOrDefault() + p.TwentiesCollected.GetValueOrDefault() + p.FiftiesCollected.GetValueOrDefault() +
                    p.HundredsCollected.GetValueOrDefault() + p.CheckAmount.GetValueOrDefault() + p.CreditCardAmount.GetValueOrDefault() +
                    p.StarVoucherAmount.GetValueOrDefault() + p.ConcessionVoucherAmount.GetValueOrDefault() + p.CreditCardFees.GetValueOrDefault() +
                    p.Donations.GetValueOrDefault() + p.Miscellaneous.GetValueOrDefault());

            grandTotalCell7.Add(new Paragraph(grandTotalFees.ToString("0.00")));
            grandTotalCell7.SetFont(regularFont);
            grandTotalCell7.SetFontSize(fontSize);
            grandTotalCell7.SetTextAlignment(TextAlignment.RIGHT);
            grandTotalCell7.SetBorderTop(new DoubleBorder(3));
            table.AddCell(grandTotalCell7);

            // Blank row
            var blankRow = new Cell(1, 7);
            blankRow.SetHeight(cellHeight);
            blankRow.Add(new Paragraph("Blank"));
            blankRow.SetFontColor(Color.WHITE);
            blankRow.SetFont(regularFont);
            blankRow.SetTextAlignment(TextAlignment.CENTER);
            blankRow.SetBorder(null);
            table.AddCell(blankRow);
        }

        private void RenderTicketSection(Table table, PdfFont regularFont, PdfFont boldFont, ShowDto showDto, float cellHeight, float fontSize)
        {
            var numberOfPerformances = showDto.Performances.Count;

            // Title
            var titleCell = new Cell(1, 7);
            titleCell.SetHeight(cellHeight);
            titleCell.Add(new Paragraph("Tickets, Passes and Vouchers"));
            titleCell.SetFont(boldFont);
            titleCell.SetFontSize(fontSize);
            titleCell.SetTextAlignment(TextAlignment.CENTER);
            table.AddCell(titleCell);

            // Tickets Sold
            var ticketsSoldLineCell1 = new Cell();
            ticketsSoldLineCell1.SetHeight(cellHeight);
            ticketsSoldLineCell1.Add(new Paragraph("Tickets Sold"));
            ticketsSoldLineCell1.SetFont(boldFont);
            ticketsSoldLineCell1.SetFontSize(fontSize);
            ticketsSoldLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(ticketsSoldLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var ticketsSoldLineCell = new Cell();
                ticketsSoldLineCell.SetHeight(cellHeight);
                var ticketsSold = performance.Tickets.Sum(t => t.AmountSold.GetValueOrDefault());
                ticketsSoldLineCell.Add(new Paragraph(ticketsSold.ToString("0")));
                ticketsSoldLineCell.SetFont(regularFont);
                ticketsSoldLineCell.SetFontSize(fontSize);
                ticketsSoldLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(ticketsSoldLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var ticketsSoldLineCell = new Cell();
                ticketsSoldLineCell.SetHeight(cellHeight);
                ticketsSoldLineCell.Add(new Paragraph(string.Empty));
                ticketsSoldLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(ticketsSoldLineCell);
            }

            var ticketsSoldLineCell7 = new Cell();
            ticketsSoldLineCell7.SetHeight(cellHeight);
            ticketsSoldLineCell7.Add(new Paragraph(showDto.Performances.Sum(s => s.Tickets.Sum(t => t.AmountSold.GetValueOrDefault())).ToString("0")));
            ticketsSoldLineCell7.SetFont(regularFont);
            ticketsSoldLineCell7.SetFontSize(fontSize);
            ticketsSoldLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(ticketsSoldLineCell7);

            // Class Passes
            var classPassesLineCell1 = new Cell();
            classPassesLineCell1.SetHeight(cellHeight);
            classPassesLineCell1.Add(new Paragraph("Class Passes"));
            classPassesLineCell1.SetFont(boldFont);
            classPassesLineCell1.SetFontSize(fontSize);
            classPassesLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(classPassesLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var classPassesLineCell = new Cell();
                classPassesLineCell.SetHeight(cellHeight);
                var classPasses = performance.ClassPasses.GetValueOrDefault();
                classPassesLineCell.Add(new Paragraph(classPasses.ToString("0")));
                classPassesLineCell.SetFont(regularFont);
                classPassesLineCell.SetFontSize(fontSize);
                classPassesLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(classPassesLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var ticketsSoldLineCell = new Cell();
                ticketsSoldLineCell.SetHeight(cellHeight);
                ticketsSoldLineCell.Add(new Paragraph(string.Empty));
                ticketsSoldLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(ticketsSoldLineCell);
            }

            var classPassesLineCell7 = new Cell();
            classPassesLineCell7.SetHeight(cellHeight);
            classPassesLineCell7.Add(new Paragraph(showDto.Performances.Sum(p => p.ClassPasses.GetValueOrDefault()).ToString("0")));
            classPassesLineCell7.SetFont(regularFont);
            classPassesLineCell7.SetFontSize(fontSize);
            classPassesLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(classPassesLineCell7);

            // Season Passes
            var seasonPassesLineCell1 = new Cell();
            seasonPassesLineCell1.SetHeight(cellHeight);
            seasonPassesLineCell1.Add(new Paragraph("Season Passes"));
            seasonPassesLineCell1.SetFont(boldFont);
            seasonPassesLineCell1.SetFontSize(fontSize);
            seasonPassesLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(seasonPassesLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var seasonPassesLineCell = new Cell();
                seasonPassesLineCell.SetHeight(cellHeight);
                var seasonPasses = performance.SeasonPasses.GetValueOrDefault();
                seasonPassesLineCell.Add(new Paragraph(seasonPasses.ToString("0")));
                seasonPassesLineCell.SetFont(regularFont);
                seasonPassesLineCell.SetFontSize(fontSize);
                seasonPassesLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(seasonPassesLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var seasonPassesLineCell = new Cell();
                seasonPassesLineCell.SetHeight(cellHeight);
                seasonPassesLineCell.Add(new Paragraph(string.Empty));
                seasonPassesLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(seasonPassesLineCell);
            }

            var seasonPassesLineCell7 = new Cell();
            seasonPassesLineCell7.SetHeight(cellHeight);
            seasonPassesLineCell7.Add(new Paragraph(showDto.Performances.Sum(p => p.SeasonPasses.GetValueOrDefault()).ToString("0")));
            seasonPassesLineCell7.SetFont(regularFont);
            seasonPassesLineCell7.SetFontSize(fontSize);
            seasonPassesLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(seasonPassesLineCell7);

            // Blank row
            var blankRow = new Cell(1, 7);
            blankRow.SetHeight(cellHeight);
            blankRow.Add(new Paragraph("Blank"));
            blankRow.SetFontColor(Color.WHITE);
            blankRow.SetFont(regularFont);
            blankRow.SetTextAlignment(TextAlignment.CENTER);
            blankRow.SetBorder(null);
            table.AddCell(blankRow);
        }

        private void RenderFeesAndMisc(Table table, PdfFont regularFont, PdfFont boldFont, ShowDto showDto, float cellHeight, float fontSize)
        {
            var numberOfPerformances = showDto.Performances.Count;

            // Title
            var titleCell = new Cell(1, 7);
            titleCell.SetHeight(cellHeight);
            titleCell.Add(new Paragraph("Donations & Misc"));
            titleCell.SetFont(boldFont);
            titleCell.SetFontSize(fontSize);
            titleCell.SetTextAlignment(TextAlignment.CENTER);
            table.AddCell(titleCell);

            // Donations
            var donationsLineCell1 = new Cell();
            donationsLineCell1.SetHeight(cellHeight);
            donationsLineCell1.Add(new Paragraph("Donations"));
            donationsLineCell1.SetFont(boldFont);
            donationsLineCell1.SetFontSize(fontSize);
            donationsLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(donationsLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var donationsLineCell = new Cell();
                donationsLineCell.SetHeight(cellHeight);
                var donationsCollected = performance.Donations.GetValueOrDefault();
                donationsLineCell.Add(new Paragraph(donationsCollected.ToString("0.00")));
                donationsLineCell.SetFont(regularFont);
                donationsLineCell.SetFontSize(fontSize);
                donationsLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(donationsLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var donationsLineCell = new Cell();
                donationsLineCell.SetHeight(cellHeight);
                donationsLineCell.Add(new Paragraph(string.Empty));
                donationsLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(donationsLineCell);
            }

            var donationsLineCell7 = new Cell();
            donationsLineCell7.SetHeight(cellHeight);
            donationsLineCell7.Add(new Paragraph(showDto.Performances.Sum(s => s.Donations.GetValueOrDefault()).ToString("0.00")));
            donationsLineCell7.SetFont(regularFont);
            donationsLineCell7.SetFontSize(fontSize);
            donationsLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(donationsLineCell7);

            // Misc
            var miscLineCell1 = new Cell();
            miscLineCell1.SetHeight(cellHeight);
            miscLineCell1.Add(new Paragraph("Misc"));
            miscLineCell1.SetFont(boldFont);
            miscLineCell1.SetFontSize(fontSize);
            miscLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(miscLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var miscLineCell = new Cell();
                miscLineCell.SetHeight(cellHeight);
                var miscCollected = performance.Miscellaneous.GetValueOrDefault();
                miscLineCell.Add(new Paragraph(miscCollected.ToString("0.00")));
                miscLineCell.SetFont(regularFont);
                miscLineCell.SetFontSize(fontSize);
                miscLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(miscLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var miscLineCell = new Cell();
                miscLineCell.SetHeight(cellHeight);
                miscLineCell.Add(new Paragraph(string.Empty));
                miscLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(miscLineCell);
            }

            var miscLineCell7 = new Cell();
            miscLineCell7.SetHeight(cellHeight);
            miscLineCell7.Add(new Paragraph(showDto.Performances.Sum(s => s.Miscellaneous.GetValueOrDefault()).ToString("0.00")));
            miscLineCell7.SetFont(regularFont);
            miscLineCell7.SetFontSize(fontSize);
            miscLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(miscLineCell7);

            // Grand totals
            var grandTotalsCell1 = new Cell();
            grandTotalsCell1.SetHeight(cellHeight);
            grandTotalsCell1.Add(new Paragraph("Total Donations / Misc"));
            grandTotalsCell1.SetFont(boldFont);
            grandTotalsCell1.SetFontSize(fontSize);
            grandTotalsCell1.SetTextAlignment(TextAlignment.LEFT);
            grandTotalsCell1.SetBorderTop(new DoubleBorder(3));
            table.AddCell(grandTotalsCell1);

            foreach (var performance in showDto.Performances)
            {
                var grandTotalCell = new Cell();
                grandTotalCell.SetHeight(cellHeight);

                var total = performance.Donations.GetValueOrDefault() + performance.Miscellaneous.GetValueOrDefault();

                grandTotalCell.Add(total.ToString("0.00"));
                grandTotalCell.SetFont(regularFont);
                grandTotalCell.SetFontSize(fontSize);
                grandTotalCell.SetTextAlignment(TextAlignment.RIGHT);
                grandTotalCell.SetBorderTop(new DoubleBorder(3));
                table.AddCell(grandTotalCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var grandTotalCell = new Cell();
                grandTotalCell.SetHeight(cellHeight);
                grandTotalCell.Add(new Paragraph(string.Empty));
                grandTotalCell.SetTextAlignment(TextAlignment.CENTER);
                grandTotalCell.SetBorderTop(new DoubleBorder(3));
                table.AddCell(grandTotalCell);
            }

            var grandTotalCell7 = new Cell();
            grandTotalCell7.SetHeight(cellHeight);

            var grandTotalFees = showDto.Performances.Sum(p => p.Donations.GetValueOrDefault() + p.Miscellaneous.GetValueOrDefault());

            grandTotalCell7.Add(new Paragraph(grandTotalFees.ToString("0.00")));
            grandTotalCell7.SetFont(regularFont);
            grandTotalCell7.SetFontSize(fontSize);
            grandTotalCell7.SetTextAlignment(TextAlignment.RIGHT);
            grandTotalCell7.SetBorderTop(new DoubleBorder(3));
            table.AddCell(grandTotalCell7);

            // Blank row
            //var blankRow = new Cell(1, 7);
            //blankRow.SetHeight(cellHeight);
            //blankRow.Add(new Paragraph("Blank"));
            //blankRow.SetFontColor(Color.WHITE);
            //blankRow.SetFont(regularFont);
            //blankRow.SetTextAlignment(TextAlignment.CENTER);
            //blankRow.SetBorder(null);
            //table.AddCell(blankRow);
        }

        private void RenderCreditCardDetails(Table table, PdfFont regularFont, PdfFont boldFont, ShowDto showDto, float cellHeight, float fontSize)
        {
            var numberOfPerformances = showDto.Performances.Count;

            // Title
            var titleCell = new Cell(1, 7);
            titleCell.SetHeight(cellHeight);
            titleCell.Add(new Paragraph("Credit Card Info"));
            titleCell.SetFont(boldFont);
            titleCell.SetFontSize(fontSize);
            titleCell.SetTextAlignment(TextAlignment.CENTER);
            table.AddCell(titleCell);

            // Credit Card
            var creditCardLineCell1 = new Cell();
            creditCardLineCell1.SetHeight(cellHeight);
            creditCardLineCell1.Add(new Paragraph("Credit Card Payments"));
            creditCardLineCell1.SetFont(boldFont);
            creditCardLineCell1.SetFontSize(fontSize);
            creditCardLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(creditCardLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var creditCardLineCell = new Cell();
                creditCardLineCell.SetHeight(cellHeight);
                var creditCardsCollected = performance.CreditCardAmount.GetValueOrDefault(); 
                creditCardLineCell.Add(new Paragraph(creditCardsCollected.ToString("0.00")));
                creditCardLineCell.SetFont(regularFont);
                creditCardLineCell.SetFontSize(fontSize);
                creditCardLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(creditCardLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var creditCardLineCell = new Cell();
                creditCardLineCell.SetHeight(cellHeight);
                creditCardLineCell.Add(new Paragraph(string.Empty));
                creditCardLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(creditCardLineCell);
            }

            var creditCardLineCell7 = new Cell();
            creditCardLineCell7.SetHeight(cellHeight);
            creditCardLineCell7.Add(new Paragraph(showDto.Performances.Sum(s => s.CreditCardAmount.GetValueOrDefault()).ToString("0.00")));
            creditCardLineCell7.SetFont(regularFont);
            creditCardLineCell7.SetFontSize(fontSize);
            creditCardLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(creditCardLineCell7);

            // Star Voucher
            var starVoucherLineCell1 = new Cell();
            starVoucherLineCell1.SetHeight(cellHeight);
            starVoucherLineCell1.Add(new Paragraph("Star Vouchers"));
            starVoucherLineCell1.SetFont(boldFont);
            starVoucherLineCell1.SetFontSize(fontSize);
            starVoucherLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(starVoucherLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var starVoucherLineCell = new Cell();
                starVoucherLineCell.SetHeight(cellHeight);
                var starVouchersCollected = performance.StarVoucherAmount.GetValueOrDefault();
                starVoucherLineCell.Add(new Paragraph(starVouchersCollected.ToString("0.00")));
                starVoucherLineCell.SetFont(regularFont);
                starVoucherLineCell.SetFontSize(fontSize);
                starVoucherLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(starVoucherLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var starVoucherLineCell = new Cell();
                starVoucherLineCell.SetHeight(cellHeight);
                starVoucherLineCell.Add(new Paragraph(string.Empty));
                starVoucherLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(starVoucherLineCell);
            }

            var starVoucherLineCell7 = new Cell();
            starVoucherLineCell7.SetHeight(cellHeight);
            starVoucherLineCell7.Add(new Paragraph(showDto.Performances.Sum(s => s.StarVoucherAmount.GetValueOrDefault()).ToString("0.00")));
            starVoucherLineCell7.SetFont(regularFont);
            starVoucherLineCell7.SetFontSize(fontSize);
            starVoucherLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(starVoucherLineCell7);

            // Concession Vouchers
            var concessionVoucherLineCell1 = new Cell();
            concessionVoucherLineCell1.SetHeight(cellHeight);
            concessionVoucherLineCell1.Add(new Paragraph("Concession Vouchers"));
            concessionVoucherLineCell1.SetFont(boldFont);
            concessionVoucherLineCell1.SetFontSize(fontSize);
            concessionVoucherLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(concessionVoucherLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var concessionVoucherLineCell = new Cell();
                concessionVoucherLineCell.SetHeight(cellHeight);
                var concessionVouchersCollected = performance.ConcessionVoucherAmount.GetValueOrDefault();
                concessionVoucherLineCell.Add(new Paragraph(concessionVouchersCollected.ToString("0.00")));
                concessionVoucherLineCell.SetFont(regularFont);
                concessionVoucherLineCell.SetFontSize(fontSize);
                concessionVoucherLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(concessionVoucherLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var concessionVoucherLineCell = new Cell();
                concessionVoucherLineCell.SetHeight(cellHeight);
                concessionVoucherLineCell.Add(new Paragraph(string.Empty));
                concessionVoucherLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(concessionVoucherLineCell);
            }

            var concessionVoucherLineCell7 = new Cell();
            concessionVoucherLineCell7.SetHeight(cellHeight);
            concessionVoucherLineCell7.Add(new Paragraph(showDto.Performances.Sum(s => s.ConcessionVoucherAmount.GetValueOrDefault()).ToString("0.00")));
            concessionVoucherLineCell7.SetFont(regularFont);
            concessionVoucherLineCell7.SetFontSize(fontSize);
            concessionVoucherLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(concessionVoucherLineCell7);

            // Square Fees
            var squareFeesLineCell1 = new Cell();
            squareFeesLineCell1.SetHeight(cellHeight);
            squareFeesLineCell1.Add(new Paragraph("Square Fees"));
            squareFeesLineCell1.SetFont(boldFont);
            squareFeesLineCell1.SetFontSize(fontSize);
            squareFeesLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(squareFeesLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var squareFeesLineCell = new Cell();
                squareFeesLineCell.SetHeight(cellHeight);
                var concessionVouchersCollected = performance.CreditCardFees.GetValueOrDefault();
                squareFeesLineCell.Add(new Paragraph(concessionVouchersCollected.ToString("0.00")));
                squareFeesLineCell.SetFont(regularFont);
                squareFeesLineCell.SetFontSize(fontSize);
                squareFeesLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(squareFeesLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var squareFeesLineCell = new Cell();
                squareFeesLineCell.SetHeight(cellHeight);
                squareFeesLineCell.Add(new Paragraph(string.Empty));
                squareFeesLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(squareFeesLineCell);
            }

            var squareFeesLineCell7 = new Cell();
            squareFeesLineCell7.SetHeight(cellHeight);
            squareFeesLineCell7.Add(new Paragraph(showDto.Performances.Sum(s => s.CreditCardFees.GetValueOrDefault()).ToString("0.00")));
            squareFeesLineCell7.SetFont(regularFont);
            squareFeesLineCell7.SetFontSize(fontSize);
            squareFeesLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(squareFeesLineCell7);

            // Grand totals
            var grandTotalsCell1 = new Cell();
            grandTotalsCell1.SetHeight(cellHeight);
            grandTotalsCell1.Add(new Paragraph("Total Credit Cards"));
            grandTotalsCell1.SetFont(boldFont);
            grandTotalsCell1.SetFontSize(fontSize);
            grandTotalsCell1.SetTextAlignment(TextAlignment.LEFT);
            grandTotalsCell1.SetBorderTop(new DoubleBorder(3));
            table.AddCell(grandTotalsCell1);

            foreach (var performance in showDto.Performances)
            {
                var grandTotalCell = new Cell();
                grandTotalCell.SetHeight(cellHeight);

                var total = performance.CreditCardAmount.GetValueOrDefault() + performance.StarVoucherAmount.GetValueOrDefault() + 
                    performance.ConcessionVoucherAmount.GetValueOrDefault() + performance.CreditCardFees.GetValueOrDefault();

                grandTotalCell.Add(total.ToString("0.00"));
                grandTotalCell.SetFont(regularFont);
                grandTotalCell.SetFontSize(fontSize);
                grandTotalCell.SetTextAlignment(TextAlignment.RIGHT);
                grandTotalCell.SetBorderTop(new DoubleBorder(3));
                table.AddCell(grandTotalCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var grandTotalCell = new Cell();
                grandTotalCell.SetHeight(cellHeight);
                grandTotalCell.Add(new Paragraph(string.Empty));
                grandTotalCell.SetTextAlignment(TextAlignment.CENTER);
                grandTotalCell.SetBorderTop(new DoubleBorder(3));
                table.AddCell(grandTotalCell);
            }

            var grandTotalCell7 = new Cell();
            grandTotalCell7.SetHeight(cellHeight);

            var grandTotalCreditCards = showDto.Performances.Sum(p => p.CreditCardAmount.GetValueOrDefault() + p.StarVoucherAmount.GetValueOrDefault() + 
                p.ConcessionVoucherAmount.GetValueOrDefault() +  p.CreditCardFees.GetValueOrDefault());

            grandTotalCell7.Add(new Paragraph(grandTotalCreditCards.ToString("0.00")));
            grandTotalCell7.SetFont(regularFont);
            grandTotalCell7.SetFontSize(fontSize);
            grandTotalCell7.SetTextAlignment(TextAlignment.RIGHT);
            grandTotalCell7.SetBorderTop(new DoubleBorder(3));
            table.AddCell(grandTotalCell7);

            // Blank row
            var blankRow = new Cell(1, 7);
            blankRow.SetHeight(cellHeight);
            blankRow.Add(new Paragraph("Blank"));
            blankRow.SetFontColor(Color.WHITE);
            blankRow.SetFont(regularFont);
            blankRow.SetTextAlignment(TextAlignment.CENTER);
            blankRow.SetBorder(null);
            table.AddCell(blankRow);
        }

        private void RenderShowDetails(Table table, PdfFont regularFont, PdfFont boldFont, ShowDto showDto, float cellHeight, float fontSize)
        {
            // Show Title
            var titleCell = new Cell(1, 7);
            titleCell.SetHeight(cellHeight);
            titleCell.Add(new Paragraph(showDto.Title));
            titleCell.SetFont(boldFont);
            titleCell.SetFontSize(fontSize);
            titleCell.SetTextAlignment(TextAlignment.CENTER);
            titleCell.SetBorder(null);
            table.AddCell(titleCell);

            string dateRangeText;
            if (showDto.Performances != null)
            {
                if (showDto.Performances.Count != 0)
                {
                    if (showDto.Performances.Count == 1)
                    {
                        dateRangeText = showDto.Performances[0].Date.GetValueOrDefault().ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        dateRangeText = showDto.Performances[0].Date.GetValueOrDefault().ToString("MM/dd/yyyy") + " - " + showDto.Performances[showDto.Performances.Count - 1].Date.GetValueOrDefault().ToString("MM/dd/yyyy");
                    }
                }
                else
                {
                    dateRangeText = string.Empty;
                }
            }
            else
            {
                dateRangeText = string.Empty;
            }

            // Date Range
            var dateRangeCell = new Cell(1, 7);
            dateRangeCell.SetHeight(cellHeight);
            dateRangeCell.Add(new Paragraph(dateRangeText));
            dateRangeCell.SetFont(boldFont);
            dateRangeCell.SetFontSize(fontSize);
            dateRangeCell.SetTextAlignment(TextAlignment.CENTER);
            dateRangeCell.SetBorder(null);
            table.AddCell(dateRangeCell);

            // Date Detail Line
            var numberOfPerformances = showDto.Performances.Count;
            var dateDetailCell1 = new Cell();
            dateDetailCell1.SetHeight(cellHeight);
            dateDetailCell1.Add(new Paragraph(string.Empty));
            dateDetailCell1.SetTextAlignment(TextAlignment.CENTER);
            table.AddCell(dateDetailCell1);

            foreach (var performance in showDto.Performances)
            {
                var dateDetailCell = new Cell();
                dateDetailCell.SetHeight(cellHeight);
                dateDetailCell.Add(new Paragraph(performance.Date.GetValueOrDefault().ToString("ddd " + "@ " + "hh:mm tt")));
                dateDetailCell.SetFont(boldFont);
                dateDetailCell.SetFontSize(fontSize);
                dateDetailCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(dateDetailCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var dateDetailCell = new Cell();
                dateDetailCell.SetHeight(cellHeight);
                dateDetailCell.Add(new Paragraph(string.Empty));
                dateDetailCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(dateDetailCell);
            }

            var dateDetailCell7 = new Cell();
            dateDetailCell7.SetHeight(cellHeight);
            dateDetailCell7.Add(new Paragraph("Item Totals"));
            dateDetailCell7.SetFont(boldFont);
            dateDetailCell7.SetFontSize(fontSize);
            dateDetailCell7.SetTextAlignment(TextAlignment.CENTER);
            table.AddCell(dateDetailCell7);
        }

        private void RenderCashCheckDetails(Table table, PdfFont regularFont, PdfFont boldFont, ShowDto showDto, float cellHeight, float fontSize)
        {
            // Check / Cash
            var numberOfPerformances = showDto.Performances.Count;
            var checkCashHeader = new Cell(1, 7);
            checkCashHeader.SetHeight(cellHeight);
            checkCashHeader.Add(new Paragraph("Check / Cash Info"));
            checkCashHeader.SetFont(boldFont);
            checkCashHeader.SetFontSize(fontSize);
            checkCashHeader.SetTextAlignment(TextAlignment.CENTER);
            table.AddCell(checkCashHeader);

            // Cash
            var cashLineCell1 = new Cell();
            cashLineCell1.SetHeight(cellHeight);
            cashLineCell1.Add(new Paragraph("Cash Collected"));
            cashLineCell1.SetFont(boldFont);
            cashLineCell1.SetFontSize(fontSize);
            cashLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(cashLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var cashLineCell = new Cell();
                cashLineCell.SetHeight(cellHeight);

                var cashCollected = performance.ChangeCollected.GetValueOrDefault() + performance.OnesCollected.GetValueOrDefault() + performance.FivesCollected.GetValueOrDefault() +
                        performance.TensCollected.GetValueOrDefault() + performance.TwentiesCollected.GetValueOrDefault() + performance.FiftiesCollected.GetValueOrDefault() +
                        performance.HundredsCollected.GetValueOrDefault();

                cashLineCell.Add(new Paragraph(cashCollected.ToString("0.00")));
                cashLineCell.SetFont(regularFont);
                cashLineCell.SetFontSize(fontSize);
                cashLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(cashLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var cashLineCell = new Cell();
                cashLineCell.SetHeight(cellHeight);
                cashLineCell.Add(new Paragraph(string.Empty));
                cashLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(cashLineCell);
            }

            var cashLineCell7 = new Cell();
            cashLineCell7.SetHeight(cellHeight);

            cashLineCell7.Add(new Paragraph(showDto.Performances.Sum(p => p.ChangeCollected.GetValueOrDefault() + p.OnesCollected.GetValueOrDefault() + p.FivesCollected.GetValueOrDefault() +
                    p.TensCollected.GetValueOrDefault() + p.TwentiesCollected.GetValueOrDefault() + p.FiftiesCollected.GetValueOrDefault() +
                    p.HundredsCollected.GetValueOrDefault()).ToString("0.00")));

            cashLineCell7.SetFont(regularFont);
            cashLineCell7.SetFontSize(fontSize);
            cashLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(cashLineCell7);

            // Check
            var checkLineCell1 = new Cell();
            checkLineCell1.SetHeight(cellHeight);
            checkLineCell1.Add(new Paragraph("Checks Collected"));
            checkLineCell1.SetFont(boldFont);
            checkLineCell1.SetFontSize(fontSize);
            checkLineCell1.SetTextAlignment(TextAlignment.LEFT);
            table.AddCell(checkLineCell1);

            foreach (var performance in showDto.Performances)
            {
                var checkLineCell = new Cell();
                checkLineCell.SetHeight(cellHeight);
                checkLineCell.Add(new Paragraph(performance.CheckAmount.GetValueOrDefault().ToString("0.00")));
                checkLineCell.SetFont(regularFont);
                checkLineCell.SetFontSize(fontSize);
                checkLineCell.SetTextAlignment(TextAlignment.RIGHT);
                table.AddCell(checkLineCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var checkLineCell = new Cell();
                checkLineCell.SetHeight(cellHeight);
                checkLineCell.Add(new Paragraph(string.Empty));
                checkLineCell.SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(checkLineCell);
            }

            var checkLineCell7 = new Cell();
            checkLineCell7.SetHeight(cellHeight);
            checkLineCell7.Add(new Paragraph(showDto.Performances.Sum(p => p.CheckAmount.GetValueOrDefault()).ToString("0.00")));
            checkLineCell7.SetFont(regularFont);
            checkLineCell7.SetFontSize(fontSize);
            checkLineCell7.SetTextAlignment(TextAlignment.RIGHT);
            table.AddCell(checkLineCell7);

            // Grand Totals
            var grandTotalsCell1 = new Cell();
            grandTotalsCell1.SetHeight(cellHeight);
            grandTotalsCell1.Add(new Paragraph("Total Cash / Checks"));
            grandTotalsCell1.SetFont(boldFont);
            grandTotalsCell1.SetFontSize(fontSize);
            grandTotalsCell1.SetTextAlignment(TextAlignment.LEFT);
            grandTotalsCell1.SetBorderTop(new DoubleBorder(3));
            table.AddCell(grandTotalsCell1);

            // Grand Total Details
            foreach (var performance in showDto.Performances)
            {
                var grandTotalCell = new Cell();
                grandTotalCell.SetHeight(cellHeight);

                var total = performance.ChangeCollected.GetValueOrDefault() + performance.OnesCollected.GetValueOrDefault() + performance.FivesCollected.GetValueOrDefault() +
                        performance.TensCollected.GetValueOrDefault() + performance.TwentiesCollected.GetValueOrDefault() + performance.FiftiesCollected.GetValueOrDefault() +
                        performance.HundredsCollected.GetValueOrDefault() + performance.CheckAmount.GetValueOrDefault();

                grandTotalCell.Add(total.ToString("0.00"));
                grandTotalCell.SetFont(regularFont);
                grandTotalCell.SetFontSize(fontSize);
                grandTotalCell.SetTextAlignment(TextAlignment.RIGHT);
                grandTotalCell.SetBorderTop(new DoubleBorder(3));
                table.AddCell(grandTotalCell);
            }

            for (int i = numberOfPerformances + 1; i < 6; i++)
            {
                var grandTotalCell = new Cell();
                grandTotalCell.SetHeight(cellHeight);
                grandTotalCell.Add(new Paragraph(string.Empty));
                grandTotalCell.SetTextAlignment(TextAlignment.CENTER);
                grandTotalCell.SetBorderTop(new DoubleBorder(3));
                table.AddCell(grandTotalCell);
            }

            var grandTotalCell7 = new Cell();
            grandTotalCell7.SetHeight(cellHeight);

            var grandTotalCashChecks = showDto.Performances.Sum(p => p.ChangeCollected.GetValueOrDefault() + p.OnesCollected.GetValueOrDefault() + p.FivesCollected.GetValueOrDefault() +
                    p.TensCollected.GetValueOrDefault() + p.TwentiesCollected.GetValueOrDefault() + p.FiftiesCollected.GetValueOrDefault() +
                    p.HundredsCollected.GetValueOrDefault()) + showDto.Performances.Sum(p => p.CheckAmount.GetValueOrDefault());

            grandTotalCell7.Add(new Paragraph(grandTotalCashChecks.ToString("0.00")));
            grandTotalCell7.SetFont(regularFont);
            grandTotalCell7.SetFontSize(fontSize);
            grandTotalCell7.SetTextAlignment(TextAlignment.RIGHT);
            grandTotalCell7.SetBorderTop(new DoubleBorder(3));
            table.AddCell(grandTotalCell7);

            // Blank row
            var blankRow = new Cell(1, 7);
            blankRow.SetHeight(cellHeight);
            blankRow.Add(new Paragraph("Blank"));
            blankRow.SetFontColor(Color.WHITE);
            blankRow.SetFont(regularFont);
            blankRow.SetTextAlignment(TextAlignment.CENTER);
            blankRow.SetBorder(null);
            table.AddCell(blankRow);
        }
    }
}
