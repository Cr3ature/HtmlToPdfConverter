namespace HtmlToPdfConverter
{
    using System.Threading.Tasks;

    public interface IPdfConverter
    {
        Task<byte[]> CreatePdfDocument(IPdfBuildModel buildModel, IPdfPageSpecification pdfPageSpecification);
    }
}