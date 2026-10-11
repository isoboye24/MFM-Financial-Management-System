using MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Queries.GetFinancialSummaryMonthlyReportPDF;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;

namespace MFMFMS.Infrastructure.PDF;

public sealed class MonthlyServiceReportDocument : IDocument
{
    private readonly FinancialSummaryMonthlyReportPDFDTO _report;

    private const float BorderWidth = 0.6f;
    private const float BodyFontSize = 7f;
    private const float HeaderFontSize = 7f;

    private static readonly CultureInfo GermanCulture =
        CultureInfo.GetCultureInfo("de-DE");

    public MonthlyServiceReportDocument(
        FinancialSummaryMonthlyReportPDFDTO report)
    {
        ArgumentNullException.ThrowIfNull(report);
        _report = report;
    }

    private string MonthName =>
        new DateTime(_report.Year, _report.Month, 1)
            .ToString("MMMM yyyy", CultureInfo.InvariantCulture);

    public DocumentMetadata GetMetadata() => new()
    {
        Title = $"Service Report - {MonthName}",
        Author = "Mountain of Fire and Miracles Ministries",
        Subject = "Monthly Church Service and Financial Report"
    };

    public DocumentSettings GetSettings() => new();

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4.Landscape());
            page.MarginHorizontal(20);
            page.MarginTop(28);
            page.MarginBottom(24);

            page.DefaultTextStyle(style => style
                .FontFamily("Lato")
                .FontSize(BodyFontSize)
                .FontColor(Colors.Black));

            page.Header().Element(ComposeHeader);

            page.Content()
                .PaddingTop(12)
                .Element(ComposeReportTable);

            page.Footer()
                .AlignCenter()
                .Text(text =>
                {
                    text.Span("MFM Germany | Service Report — ");
                    text.Span(MonthName);
                    text.Span(" | Page ");
                    text.CurrentPageNumber();
                    text.Span(" of ");
                    text.TotalPages();
                });
        });
    }


    private void ComposeHeader(IContainer container)
    {
        container
            .PaddingLeft(50)
            .Column(column =>
        {
            column.Spacing(8);

            // Church name: large, bold, serif, left-aligned.
            column.Item()
                .AlignLeft()
                .Text("MOUNTAIN OF FIRE AND MIRACLES MINISTRIES")
                .FontFamily("Lato")
                .FontSize(16)
                .Bold();

            // Country and branch on the same line.
            column.Item().Row(row =>
            {
                row.RelativeItem(1)
                    .AlignLeft()
                    .Text("GERMANY.")
                    .FontFamily("Lato")
                    .FontSize(9)
                    .Bold();

                row.RelativeItem(2)
                    .AlignLeft()
                    .Text("BRANCH: Kassel Germany 2024.................................")
                    .FontFamily("Lato")
                    .FontSize(9)
                    .Bold();
            });

            // Report title and month on the same line.
            column.Item().Row(row =>
            {
                row.RelativeItem(1)
                    .AlignLeft()
                    .Text("SERVICE REPORT")
                    .FontFamily("Lato")
                    .FontSize(9)
                    .Bold();

                row.RelativeItem(1)
                    .AlignLeft()
                    .Text($"MONTH: {MonthName}")
                    .FontFamily("Lato")
                    .FontSize(9)
                    .Bold();
            });
        });
    }


    private void ComposeReportTable(IContainer container)
    {
        var services = _report.Services
            .OrderBy(service => service.Date)
            .ToList();

        var expenditures = _report.Expenditures;

        container.Table(table =>
        {
            // 14 columns:
            // #, Day, Date, Message, Minister,
            // Male, Female, Children, Attendance Total,
            // Offering, Tithe, Sp prog, Income Total,
            // Expenditure description and amount.
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(17);      // #
                columns.ConstantColumn(28);      // Day
                columns.ConstantColumn(48);      // Date
                columns.RelativeColumn(2.0f);    // Message
                columns.RelativeColumn(1.35f);   // Minister

                columns.ConstantColumn(26);      // Male
                columns.ConstantColumn(28);      // Female
                columns.ConstantColumn(31);      // Children
                columns.ConstantColumn(32);      // Attendance total

                columns.RelativeColumn(1.0f);    // Offering
                columns.RelativeColumn(0.9f);    // Tithe
                columns.RelativeColumn(0.95f);   // Sp prog
                columns.RelativeColumn(1.0f);    // Income total

                columns.RelativeColumn(1.8f);    // Expenditure
            });

            // Grouped, two-row header.
            table.Header(header =>
            {
                header.Cell().RowSpan(2).Element(HeaderCell).Text("#");
                header.Cell().RowSpan(2).Element(HeaderCell).Text("DAY");
                header.Cell().RowSpan(2).Element(HeaderCell).Text("DATE");
                header.Cell().RowSpan(2).Element(HeaderCell).Text("MESSAGE");
                header.Cell().RowSpan(2).Element(HeaderCell).Text("MINISTER");

                header.Cell().ColumnSpan(4)
                    .Element(HeaderCell)
                    .Text("ATTENDANCE");

                header.Cell().ColumnSpan(4)
                    .Element(HeaderCell)
                    .Text("INCOME");

                header.Cell().RowSpan(2)
                    .Element(HeaderCell)
                    .AlignCenter()
                    .Text("EXPENDITURE");

                header.Cell().Element(SubHeaderCell).Text("Male");
                header.Cell().Element(SubHeaderCell).Text("Female");
                header.Cell().Element(SubHeaderCell).Text("Children");
                header.Cell().Element(SubHeaderCell).Text("TOTAL");

                header.Cell().Element(SubHeaderCell).Text("Offering");
                header.Cell().Element(SubHeaderCell).Text("Tithe");
                header.Cell().Element(SubHeaderCell).Text("Sp prog");
                header.Cell().Element(SubHeaderCell).Text("TOTAL");
            });

            // Actual service rows only.
            foreach (var service in services)
            {
                table.Cell().Element(BodyCell)
                    .Text(service.Number.ToString());

                table.Cell().Element(BodyCell)
                    .Text(service.Date.ToString(
                        "ddd", CultureInfo.InvariantCulture));

                table.Cell().Element(BodyCell)
                    .Text(service.Date.ToString("dd.MM.yyyy"));

                table.Cell().Element(BodyCell)
                    .Text(service.Message);

                table.Cell().Element(BodyCell)
                    .Text(service.Minister);

                table.Cell().Element(NumberCell)
                    .Text(service.Male.ToString());

                table.Cell().Element(NumberCell)
                    .Text(service.Female.ToString());

                table.Cell().Element(NumberCell)
                    .Text(service.Children.ToString());

                table.Cell().Element(NumberCell)
                    .Text(service.TotalAttendance.ToString());

                table.Cell().Element(MoneyCell)
                    .Text(FormatMoney(service.Offering));

                table.Cell().Element(MoneyCell)
                    .Text(FormatMoney(service.Tithe));

                // OtherIncome is displayed in the Sp prog column.
                table.Cell().Element(MoneyCell)
                    .Text(FormatMoney(service.OtherIncome));

                table.Cell().Element(MoneyCell)
                    .Text(FormatMoney(service.TotalIncome));

                // Expenditures are monthly records, not service-linked.
                // Leave the service expenditure cell empty.
                table.Cell().Element(BodyCell).Text("");
            }

            // If there are no services, retain a single descriptive row.
            if (services.Count == 0)
            {
                table.Cell().ColumnSpan(14)
                    .Element(BodyCell)
                    .AlignCenter()
                    .Text("No services recorded for this month.");
            }

            // Monthly expenditure rows are included in the same table.
            foreach (var expenditure in expenditures)
            {
                table.Cell().ColumnSpan(13)
                    .Element(BodyCell)
                    .Text("");

                table.Cell().Element(BodyCell)
                    .Text($"{expenditure.Summary} — {FormatMoney(expenditure.Amount)}");
            }

            // Monthly financial summary.
            AddSummaryRow(
                table,
                "Cash at hand: Balance brought forward from last month:",
                _report.OpeningBalance);

            AddSummaryRow(
                table,
                "Total income for this month:",
                _report.TotalIncome);

            AddSummaryRow(
                table,
                "Total income (Balance + this month):",
                _report.OpeningBalance + _report.TotalIncome);

            AddSummaryRow(
                table,
                "Total Expenditure for this month:",
                _report.TotalExpenditure);

            // Closing balance.
            table.Cell().ColumnSpan(12)
                .Element(ClosingLabelCell)
                .AlignRight()
                .Text("Balance:");

            table.Cell().Element(ClosingAmountCell)
                .AlignRight()
                .Text(FormatMoney(_report.ClosingBalance));

            table.Cell().Element(ClosingAmountCell).Text("");

            // Pastor's signature.
            table.Cell().ColumnSpan(5)
                .Element(SignatureCell)
                .Text("Prepared by Finance/Admin's name and signature and Date:")
                .Italic()
                .Bold();

            table.Cell().ColumnSpan(8)
                .Element(SignatureCell)
                .Text("Pastor's Name, Signature and date");

            table.Cell().Element(SignatureCell).Text("");
        });
    }

    private static void AddSummaryRow(
        TableDescriptor table,
        string label,
        decimal amount)
    {
        table.Cell().ColumnSpan(9)
            .Element(BodyCell)
            .Text("");

        table.Cell().ColumnSpan(3)
            .Element(BodyCell)
            .Text(label);

        table.Cell().Element(MoneyCell)
            .Text(FormatMoney(amount));

        table.Cell().Element(BodyCell).Text("");
    }

    private static string FormatMoney(decimal amount) =>
        amount.ToString("#,##0.00", GermanCulture) + " €";

    private static IContainer HeaderCell(IContainer container) =>
        container
            .Border(BorderWidth)
            .BorderColor(Colors.Black)
            .Padding(3)
            .AlignMiddle()
            .DefaultTextStyle(style => style
                .FontFamily("Lato")
                .FontSize(HeaderFontSize)
                .Bold());

    private static IContainer SubHeaderCell(IContainer container) =>
        container
            .Border(BorderWidth)
            .BorderColor(Colors.Black)
            .Padding(3)
            .AlignMiddle()
            .DefaultTextStyle(style => style
                .FontFamily("Lato")
                .FontSize(6.5f)
                .Bold());

    private static IContainer BodyCell(IContainer container) =>
        container
            .Border(BorderWidth)
            .BorderColor(Colors.Black)
            .PaddingHorizontal(3)
            .PaddingVertical(2)
            .AlignMiddle()
            .DefaultTextStyle(style => style
                .FontFamily("Lato")
                .FontSize(BodyFontSize));

    private static IContainer NumberCell(IContainer container) =>
        BodyCell(container).AlignCenter();

    private static IContainer MoneyCell(IContainer container) =>
        BodyCell(container).AlignRight();

    private static IContainer ClosingLabelCell(IContainer container) =>
        container
            .Border(BorderWidth)
            .BorderColor(Colors.Black)
            .Padding(3)
            .DefaultTextStyle(style => style
                .FontFamily("Lato")
                .FontSize(BodyFontSize)
                .Bold());

    private static IContainer ClosingAmountCell(IContainer container) =>
        container
            .Border(BorderWidth)
            .BorderColor(Colors.Black)
            .Padding(3)
            .AlignRight()
            .DefaultTextStyle(style => style
                .FontFamily("Lato")
                .FontSize(BodyFontSize)
                .Bold());

    private static IContainer SignatureCell(IContainer container) =>
        container
            .Border(BorderWidth)
            .BorderColor(Colors.Black)
            .Padding(4)
            .AlignMiddle()
            .DefaultTextStyle(style => style
                .FontFamily("Lato")
                .FontSize(7));
}
