namespace TestHost.Controllers
{
    using HtmlToPdfConverter;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TestHost.PageSettings;
    using TestHost.PdfBuildModels;

    [Route("api/[controller]")]
    [ApiController]
    public class HtmlToPdfController : ControllerBase
    {
        private readonly IPdfConverter _pdfConverter;

        public HtmlToPdfController(IPdfConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var html = "<html><body><h1>It Works!</h1></body></html>";
            var result = await _pdfConverter.CreatePdfDocument(new DefaultBuildModel("DocumentTitle", html), new TestPdfSpecification());
            return File(result, System.Net.Mime.MediaTypeNames.Application.Pdf, "Test.pdf");
        }
    }
}
