using AutoFixture;
using DinkToPdf;
using DinkToPdf.Contracts;
using HtmlToPdfConverter.Abstractions;
using HtmlToPdfConverter.Abstractions.Contracts;
using HtmlToPdfConverter.Core;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HtmlToPdfConverter.Tests
{
    public class PdfConverterCoreTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public async Task Should_Fail_On_CreatePdfDocument_WithDocumentTitleNullOrEmpty()
        {
            var buildModel = _fixture.Create<ObjectSettingsBuildModel>();
            buildModel.DocumentTitle = string.Empty;

            var mockConverter = new Mock<IConverter>();
            mockConverter.Setup(s => s.Convert(It.IsAny<IDocument>())).Returns(new byte[] { });

            IPdfConverter pdfConverterCore = new PdfConverter(mockConverter.Object);

            Exception exception = await Record.ExceptionAsync(async () => await pdfConverterCore.CreatePdfDocument(buildModel)); 

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.NotNull(exception.InnerException);
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            buildModel.DocumentTitle = null;

            exception = await Record.ExceptionAsync(async () => await pdfConverterCore.CreatePdfDocument(buildModel));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.NotNull(exception.InnerException);
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            mockConverter.Verify(v => v.Convert(It.IsAny<IDocument>()), Times.Never);
        }

        [Fact]
        public void Should_fail_On_GetDefaultGlobalSettings_WithDocumentTitleNullOrEmpty()
        {
            var buildModel = _fixture.Create<ObjectSettingsBuildModel>();
            buildModel.DocumentTitle = string.Empty;

            IPdfConverter pdfConverterCore = new PdfConverter(null);

            Exception exception = Record.Exception(() => pdfConverterCore.GetGlobalSettings(buildModel).Exception);

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);

            buildModel.DocumentTitle = null;

            exception = Record.Exception(() => pdfConverterCore.GetGlobalSettings(buildModel).Exception);

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void Should_Fail_On_GetDefaultObjectSettings_WithHtmlContentNullOrEmpty()
        {
            var buildModel = _fixture.Create<ObjectSettingsBuildModel>();
            buildModel.HtmlContent = string.Empty;

            IPdfConverter pdfConverterCore = new PdfConverter(null);

            Exception exception = Record.Exception(() => pdfConverterCore.GetDefaultObjectSettings(buildModel).Exception);

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);

            buildModel.HtmlContent = null;

            exception = Record.Exception(() => pdfConverterCore.GetDefaultObjectSettings(buildModel).Exception);

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task Should_Return_ByteArray_On_CreatePdfDocument()
        {
            var buildModel = _fixture.Create<ObjectSettingsBuildModel>();
            var mockConverter = new Mock<IConverter>();
            mockConverter.Setup(s => s.Convert(It.IsAny<IDocument>())).Returns(new byte[] { });

            IPdfConverter pdfConverterCore = new PdfConverter(mockConverter.Object);
            var result = await pdfConverterCore.CreatePdfDocument(buildModel);

            Assert.NotNull(result);

            mockConverter.Verify(v => v.Convert(It.IsAny<IDocument>()), Times.Once);
        }

        [Fact]
        public async Task Should_Return_Default_GlobalSettings()
        {
            var buildModel = _fixture.Create<ObjectSettingsBuildModel>();
            var mockConverter = new Mock<IConverter>();

            IPdfConverter pdfConverterCore = new PdfConverter(mockConverter.Object);
            GlobalSettings result = await pdfConverterCore.GetGlobalSettings(buildModel);

            Assert.NotNull(result);
            Assert.Equal(buildModel.DocumentTitle, result.DocumentTitle);
        }

        [Fact]
        public async Task Should_Return_DefaultObjectSettings()
        {
            var buildModel = _fixture.Create<ObjectSettingsBuildModel>();

            IPdfConverter pdfConverterCore = new PdfConverter(null);
            ObjectSettings result = await pdfConverterCore.GetDefaultObjectSettings(buildModel);

            Assert.NotNull(result);
            Assert.Equal(buildModel.HtmlContent, result.HtmlContent);
            Assert.Equal(buildModel.UseHeaderLine, result.HeaderSettings.Line);
            Assert.Equal(buildModel.UseFooterLine, result.FooterSettings.Line);
            Assert.Equal(buildModel.UsePageCount, result.PagesCount);
        }
    }
}
