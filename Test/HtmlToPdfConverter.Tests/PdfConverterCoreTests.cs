namespace HtmlToPdfConverter.Tests
{
    using DinkToPdf.Contracts;
    using HtmlToPdfConverter.Tests.Configurations;
    using Moq;
    using System;
    using System.Threading.Tasks;
    using TestHost.PdfBuildModels;
    using Xunit;

    public class PdfConverterCoreTests
    {
        [Fact]
        public async Task Should_Fail_On_CreatePdfDocument_WithDocumentTitleNullOrEmpty()
        {
            var buildModel = new DefaultBuildModel(string.Empty, "<html></html>");

            var mockConverter = new Mock<IConverter>();
            mockConverter.Setup(s => s.Convert(It.IsAny<IDocument>())).Returns(new byte[] { });

            IPdfConverter pdfConverterCore = new PdfConverter(mockConverter.Object);

            Exception exception = await Record.ExceptionAsync(async () => await pdfConverterCore.CreatePdfDocument(buildModel, new TestPdfSpecification()));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.NotNull(exception.InnerException);
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            buildModel = new DefaultBuildModel(null, "<html></html>");

            exception = await Record.ExceptionAsync(async () => await pdfConverterCore.CreatePdfDocument(buildModel, new TestPdfSpecification()));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.NotNull(exception.InnerException);
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            mockConverter.Verify(v => v.Convert(It.IsAny<IDocument>()), Times.Never);
        }

        [Fact]
        public async Task Should_Fail_On_CreatePdfDocument_WithHtmlContentNullOrEmpty()
        {
            var buildModel = new DefaultBuildModel("DocumentTitle", string.Empty);

            var mockConverter = new Mock<IConverter>();
            mockConverter.Setup(s => s.Convert(It.IsAny<IDocument>())).Returns(new byte[] { });

            IPdfConverter pdfConverterCore = new PdfConverter(mockConverter.Object);

            Exception exception = await Record.ExceptionAsync(async () => await pdfConverterCore.CreatePdfDocument(buildModel, new TestPdfSpecification()));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.NotNull(exception.InnerException);
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            buildModel = new DefaultBuildModel("DocumentTitle", null);

            exception = await Record.ExceptionAsync(async () => await pdfConverterCore.CreatePdfDocument(buildModel, new TestPdfSpecification()));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.NotNull(exception.InnerException);
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            mockConverter.Verify(v => v.Convert(It.IsAny<IDocument>()), Times.Never);
        }

        [Fact]
        public async Task Should_Return_ByteArray_On_CreatePdfDocument()
        {
            var buildModel = new DefaultBuildModel("DocumentTitle", "<html></html>");
            var mockConverter = new Mock<IConverter>();
            mockConverter.Setup(s => s.Convert(It.IsAny<IDocument>())).Returns(new byte[] { });

            IPdfConverter pdfConverterCore = new PdfConverter(mockConverter.Object);
            var result = await pdfConverterCore.CreatePdfDocument(buildModel, new TestPdfSpecification());

            Assert.NotNull(result);

            mockConverter.Verify(v => v.Convert(It.IsAny<IDocument>()), Times.Once);
        }
    }
}