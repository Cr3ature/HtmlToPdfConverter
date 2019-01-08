namespace HtmlToPdfConverter.Tests.Configurations
{
    using DinkToPdf;
    using HtmlToPdfConverter.Contracts.PageSettingsAggregates;

    public class TestPdfSpecification : BasePdfPageSpecification
    {
        public TestPdfSpecification()
            : base(ColorMode.Color, new MarginSettings { Top = 20, Bottom = 20 }, Orientation.Portrait, PaperKind.A4)
        {
        }
    }
}
