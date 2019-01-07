using HtmlToPdfConverter.Contracts;
using HtmlToPdfConverter.Contracts.PageSettings;
using System.Threading.Tasks;

namespace HtmlToPdfConverter
{
    public interface IPdfConverter
    {
        Task<byte[]> CreatePdfDocument(PdfBuildModel buildModel, IBasePdfPageSpecification pdfPageSpecification);
    }
}
