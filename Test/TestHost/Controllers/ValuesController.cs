using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlToPdfConverter;
using HtmlToPdfConverter.Contracts;
using Microsoft.AspNetCore.Mvc;
using TestHost.PageSettings;

namespace TestHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IPdfConverter _pdfConverter;

        public ValuesController(IPdfConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var html = "<html><body><h1>It Works!</h1></body></html>";
            var result = await _pdfConverter.CreatePdfDocument(new PdfBuildModel("Testjeuh", html, false), new TestPdfSpecification());
            return File(result, System.Net.Mime.MediaTypeNames.Application.Pdf, "Test.pdf");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
