namespace TestHost.PageSettings
{
    using DinkToPdf;
    using HtmlToPdfConverter;
    using System.IO;

    public class TestPdfSpecification : BasePdfPageSpecification
    {
        public TestPdfSpecification()
            : base(ColorMode.Color, new MarginSettings { Top = 20, Bottom = 20 }, Orientation.Portrait, PaperKind.A4)
        {
            SetDefaultEncoding("utf-8");
            SetFontName("Arial");
            SetFontSize(12);
            SetPageSpacing(10);
            SetUserStyleSheet(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "example.css"));
        }
    }
}