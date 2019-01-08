namespace HtmlToPdfConverter
{
    using HtmlToPdfConverter.Contracts.PageSettingsAggregates;
    using HtmlToPdfConverter.Contracts.PdfBuildModelAggregates;
    using System.Threading.Tasks;

    public interface IPdfConverter
    {
        Task<byte[]> CreatePdfDocument(IPdfBuildModel buildModel, IPdfPageSpecification pdfPageSpecification);
    }
}
