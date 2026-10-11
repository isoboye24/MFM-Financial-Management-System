using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;
using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF;

namespace MFMFMS.Infrastructure.PDF
{
    public class MonthlyServiceReportDocument : IDocument
    {
        private readonly FinancialSummaryMonthlyReportPDFDTO _report;

        public MonthlyServiceReportDocument(FinancialSummaryMonthlyReportPDFDTO report)
        {
            _report = report;
        }

        public DocumentMetadata GetMetadata() => new()
        {
            Title = $"Service Report - {MonthName}",
            Author = "Mountain of Fire and Miracles Ministries",
            Subject = "Monthly Church Service and Financial Report"
        };

        public DocumentSettings GetSettings() => new();

        private string MonthName =>
            new DateTime(_report.Year, _report.Month, 1)
                .ToString("MMMM yyyy", CultureInfo.InvariantCulture);

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(22);
                page.DefaultTextStyle(x => x.FontSize(7));

                page.Header().Element(ComposeHeader);

                page.Content()
                    .PaddingTop(12)
                    .Column(column =>
                    {
                        column.Spacing(12);

                        column.Item().Element(ComposeServicesTable);
                        column.Item().Element(ComposeExpendituresTable);
                        column.Item().Element(ComposeFinancialSummary);
                        column.Item().Element(ComposeSignatures);
                    });

                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span("MFM Germany | ");
                    text.Span($"Service Report — {MonthName} | Page ");
                    text.CurrentPageNumber();
                    text.Span(" of ");
                    text.TotalPages();
                });
            });
        }

        private void ComposeHeader(IContainer container)
        {
            container.Column(column =>
            {
                column.Spacing(3);

                column.Item().AlignCenter().Text(
                    "MOUNTAIN OF FIRE AND MIRACLES MINISTRIES")
                    .Bold()
                    .FontSize(15);

                column.Item().AlignCenter().Text("GERMANY BRANCH")
                    .Bold()
                    .FontSize(10);

                column.Item().PaddingTop(5).AlignCenter()
                    .Text("MONTHLY SERVICE REPORT")
                    .Bold()
                    .FontSize(12);

                column.Item().AlignCenter()
                    .Text(MonthName)
                    .FontSize(10);
            });
        }

        private void ComposeServicesTable(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().PaddingBottom(4)
                    .Text("1. SERVICE ATTENDANCE AND INCOME")
                    .Bold()
                    .FontSize(9);

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(18);  // #
                        columns.ConstantColumn(29);  // Day
                        columns.ConstantColumn(49);  // Date
                        columns.RelativeColumn(2.2f); // Message
                        columns.RelativeColumn(1.5f); // Minister

                        columns.ConstantColumn(25);  // Male
                        columns.ConstantColumn(25);  // Female
                        columns.ConstantColumn(29);  // Children
                        columns.ConstantColumn(30);  // Attendance total

                        columns.RelativeColumn(1.1f); // Offering
                        columns.RelativeColumn(1.1f); // Tithe
                        columns.RelativeColumn(1.1f); // Seed
                        columns.RelativeColumn(1.1f); // Other
                        columns.RelativeColumn(1.2f); // Income total
                    });

                    table.Header(header =>
                    {
                        header.Cell().RowSpan(2).Element(HeaderCell).Text("#");
                        header.Cell().RowSpan(2).Element(HeaderCell).Text("Day");
                        header.Cell().RowSpan(2).Element(HeaderCell).Text("Date");
                        header.Cell().RowSpan(2).Element(HeaderCell).Text("Message");
                        header.Cell().RowSpan(2).Element(HeaderCell).Text("Minister");

                        header.Cell().ColumnSpan(4).Element(HeaderCell)
                            .Text("ATTENDANCE");

                        header.Cell().ColumnSpan(5).Element(HeaderCell)
                            .Text("INCOME (€)");

                        header.Cell().Element(SubHeaderCell).Text("Male");
                        header.Cell().Element(SubHeaderCell).Text("Female");
                        header.Cell().Element(SubHeaderCell).Text("Children");
                        header.Cell().Element(SubHeaderCell).Text("Total");

                        header.Cell().Element(SubHeaderCell).Text("Offering");
                        header.Cell().Element(SubHeaderCell).Text("Tithe");
                        header.Cell().Element(SubHeaderCell).Text("Seed");
                        header.Cell().Element(SubHeaderCell).Text("Other");
                        header.Cell().Element(SubHeaderCell).Text("Total");
                    });

                    foreach (var service in _report.Services.OrderBy(x => x.Date))
                    {
                        table.Cell().Element(BodyCell).Text(service.Number.ToString());
                        table.Cell().Element(BodyCell)
                            .Text(service.Date.ToString("ddd", CultureInfo.InvariantCulture));
                        table.Cell().Element(BodyCell)
                            .Text(service.Date.ToString("dd.MM.yyyy"));
                        table.Cell().Element(BodyCell).Text(service.Message);
                        table.Cell().Element(BodyCell).Text(service.Minister);

                        table.Cell().Element(NumberCell).Text(service.Male.ToString());
                        table.Cell().Element(NumberCell).Text(service.Female.ToString());
                        table.Cell().Element(NumberCell).Text(service.Children.ToString());
                        table.Cell().Element(NumberCell).Text(service.TotalAttendance.ToString());

                        table.Cell().Element(MoneyCell).Text(FormatMoney(service.Offering));
                        table.Cell().Element(MoneyCell).Text(FormatMoney(service.Tithe));
                        table.Cell().Element(MoneyCell).Text(FormatMoney(service.Seed));
                        table.Cell().Element(MoneyCell).Text(FormatMoney(service.OtherIncome));
                        table.Cell().Element(MoneyCell).Text(FormatMoney(service.TotalIncome));
                    }

                    if (_report.Services.Count == 0)
                    {
                        table.Cell().ColumnSpan(14).Element(BodyCell)
                            .AlignCenter()
                            .Text("No services recorded for this month.");
                    }
                });
            });
        }

        private void ComposeExpendituresTable(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().PaddingBottom(4)
                    .Text("2. MONTHLY EXPENDITURES")
                    .Bold()
                    .FontSize(9);

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(30);
                        columns.RelativeColumn(5);
                        columns.RelativeColumn(1.3f);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(HeaderCell).Text("#");
                        header.Cell().Element(HeaderCell).Text("Description");
                        header.Cell().Element(HeaderCell).AlignRight().Text("Amount (€)");
                    });

                    var number = 1;

                    foreach (var expenditure in _report.Expenditures)
                    {
                        table.Cell().Element(BodyCell).Text(number++.ToString());
                        table.Cell().Element(BodyCell).Text(expenditure.Summary);
                        table.Cell().Element(MoneyCell)
                            .AlignRight().Text(FormatMoney(expenditure.Amount));
                    }

                    if (_report.Expenditures.Count == 0)
                    {
                        table.Cell().ColumnSpan(3).Element(BodyCell)
                            .AlignCenter()
                            .Text("No expenditures recorded for this month.");
                    }

                    table.Cell().ColumnSpan(2).Element(TotalCell)
                        .AlignRight().Text("TOTAL EXPENDITURE");

                    table.Cell().Element(TotalCell)
                        .AlignRight().Text(FormatMoney(_report.TotalExpenditure));
                });
            });
        }

        private void ComposeFinancialSummary(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().PaddingBottom(4)
                    .Text("3. FINANCIAL SUMMARY")
                    .Bold()
                    .FontSize(9);

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(1.3f);
                    });

                    AddSummaryRow(table, "Opening balance brought forward",
                        _report.OpeningBalance);

                    AddSummaryRow(table, "Monthly income",
                        _report.TotalIncome);

                    AddSummaryRow(table, "Total available funds",
                        _report.OpeningBalance + _report.TotalIncome);

                    AddSummaryRow(table, "Total expenditure",
                        _report.TotalExpenditure);

                    table.Cell().Element(TotalCell)
                        .Text("CLOSING BALANCE");

                    table.Cell().Element(TotalCell)
                        .AlignRight()
                        .Text(FormatMoney(_report.ClosingBalance));
                });
            });
        }

        private void ComposeSignatures(IContainer container)
        {
            container.PaddingTop(18).Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().PaddingBottom(5)
                        .Text("_______________________________");

                    column.Item().Text("Pastor's Signature").Bold();
                    column.Item().Text("Name: ________________________");
                    column.Item().Text("Date: _________________________");
                });

                row.RelativeItem().Column(column =>
                {
                    column.Item().PaddingBottom(5)
                        .Text("_______________________________");

                    column.Item().Text("Finance / Admin Signature").Bold();
                    column.Item().Text("Name: ________________________");
                    column.Item().Text("Date: _________________________");
                });
            });
        }

        private static void AddSummaryRow(
            TableDescriptor table,
            string label,
            decimal amount)
        {
            table.Cell().Element(BodyCell).Text(label);
            table.Cell().Element(MoneyCell)
                .AlignRight().Text(FormatMoney(amount));
        }

        private static string FormatMoney(decimal amount) =>
            amount.ToString("#,##0.00", CultureInfo.GetCultureInfo("de-DE"));

        private static IContainer HeaderCell(IContainer container) =>
            container
                .Border(0.7f)
                .Background(Colors.Grey.Lighten3)
                .Padding(3)
                .AlignMiddle()
                .DefaultTextStyle(x => x.Bold().FontSize(6.5f));

        private static IContainer SubHeaderCell(IContainer container) =>
            container
                .Border(0.7f)
                .Background(Colors.Grey.Lighten4)
                .Padding(3)
                .AlignMiddle()
                .DefaultTextStyle(x => x.Bold().FontSize(6));

        private static IContainer BodyCell(IContainer container) =>
            container
                .Border(0.5f)
                .BorderColor(Colors.Grey.Lighten2)
                .Padding(3)
                .AlignMiddle();

        private static IContainer NumberCell(IContainer container) =>
            BodyCell(container).AlignCenter();

        private static IContainer MoneyCell(IContainer container) =>
            BodyCell(container).AlignRight();

        private static IContainer TotalCell(IContainer container) =>
            container
                .Border(0.7f)
                .Background(Colors.Grey.Lighten3)
                .Padding(4)
                .DefaultTextStyle(x => x.Bold());
    }
}
