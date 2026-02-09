using BarcodeStandard;
using OutPost.Application.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace OutPost.Application.LabelGenerator;

public class LabelService
{
    public byte[] GenerateParcelLabel(ParcelDto parcel)
    {
        Barcode barcode = new Barcode();
        barcode.IncludeLabel = false;
        var image = barcode.Encode(BarcodeStandard.Type.Code128, parcel.TrackingNumber, SKColors.Black, SKColors.White, 300, 100);
        var b_data = image.Encode(SKEncodedImageFormat.Png, 100).ToArray();

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A6);
                page.Margin(1, Unit.Centimetre);
                page.PageColor(Colors.White);

                page.Header().Text("OutPost").FontSize(20).Bold().FontColor(Colors.Blue.Medium);

                page.Content().Column(col =>
                {
                    col.Item().LineHorizontal(1);
                    col.Item().Text("");

                    col.Item().Text("Nadawca:").Bold();
                    col.Item().Text($"{parcel.s_Name}");
                    col.Item().Text($"{parcel.s_Address}");
                    col.Item().Text($"{parcel.s_Email}");
                    col.Item().Text($"{parcel.s_Phone_number}");
                    col.Item().Text("");

                    col.Item().Text($"Odbiorca:").Bold();
                    col.Item().Text($"{parcel.r_Name}");
                    col.Item().Text($"{parcel.r_Address}");
                    col.Item().Text($"{parcel.r_Email}");
                    col.Item().Text($"{parcel.r_Phone_number}");
                });

                page.Footer().AlignCenter().Column(footerCol =>
                {
                    footerCol.Item().Image(b_data);
                    footerCol.Item().AlignCenter().Text(parcel.TrackingNumber)
                        .FontSize(12)
                        .LetterSpacing(0.2f)
                        .FontColor(Colors.Black);
                });
            });
        });

        return document.GeneratePdf();
    }
}