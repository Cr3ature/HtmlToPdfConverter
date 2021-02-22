namespace HtmlToPdfConverter
{
    using DinkToPdf;
    using DinkToPdf.Contracts;
    using HtmlToPdfConverter.Validator;
    using System;
    using System.Threading.Tasks;

    internal class PdfConverter : IPdfConverter
    {
        private readonly IConverter _converter;

        public PdfConverter(IConverter converter)
        {
            _converter = converter;
        }

        public async Task<byte[]> CreatePdfDocument(IPdfBuildModel buildModel, IPdfPageSpecification pdfPageSpecification)
        {
            try
            {
                if (!buildModel.IsValid()) throw new ArgumentNullException(nameof(buildModel));

                GlobalSettings globalSettings = await GetGlobalSettings(buildModel, pdfPageSpecification);
                ObjectSettings objectSettings = await GetDefaultObjectSettings(buildModel, pdfPageSpecification);

                HtmlToPdfDocument pdfDocument = await ConvertToPdf(globalSettings, objectSettings);

                return _converter.Convert(pdfDocument);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(CreatePdfDocument), ex);
            }
        }

        private static FooterSettings BuildDefaultFooterSettings(IPdfBuildModel buildModel, IPdfPageSpecification pdfPageSpecification)
            => new FooterSettings
            {
                FontName = pdfPageSpecification.FontName,
                FontSize = pdfPageSpecification.FontSize,
                Line = buildModel.UseFooterLine,
                Left = buildModel.FooterLeftText ?? string.Empty,
                Center = buildModel.FooterCenterText ?? string.Empty,
                Right = buildModel.FooterRightText ?? string.Empty,
                Spacing = pdfPageSpecification.PageSpacing,
                HtmUrl = buildModel.HtmlUri ?? string.Empty
            };

        private static HeaderSettings BuildDefaultHeaderSettings(IPdfBuildModel buildModel, IPdfPageSpecification pdfPageSpecification)
            => new HeaderSettings
            {
                FontName = pdfPageSpecification.FontName,
                FontSize = pdfPageSpecification.FontSize,
                Line = buildModel.UseHeaderLine,
                Left = buildModel.HeaderLeftText ?? string.Empty,
                Center = buildModel.HeaderCenterText ?? string.Empty,
                Right = buildModel.HeaderRightText ?? string.Empty,
                Spacing = pdfPageSpecification.PageSpacing
            };

        private static WebSettings BuildDefaultWebSettings(IPdfPageSpecification pdfPageSpecification)
            => new WebSettings
            {
                DefaultEncoding = pdfPageSpecification.DefaultEncoding,
                UserStyleSheet = pdfPageSpecification.UserStyleSheet,
            };

        private Task<HtmlToPdfDocument> ConvertToPdf(GlobalSettings globalSettings, ObjectSettings objectSettings)
        {
            if (globalSettings == null || objectSettings == null)
            {
                throw new ArgumentNullException(nameof(ConvertToPdf));
            }

            var htmlToPdfDocument = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return Task.FromResult(htmlToPdfDocument);
        }

        private Task<ObjectSettings> GetDefaultObjectSettings(IPdfBuildModel buildModel, IPdfPageSpecification pdfPageSpecification)
        {
            if (string.IsNullOrWhiteSpace(buildModel.HtmlContent))
                throw new ArgumentNullException(nameof(GetDefaultObjectSettings));

            var objectSettings = new ObjectSettings
            {
                FooterSettings = BuildDefaultFooterSettings(buildModel, pdfPageSpecification),
                HeaderSettings = BuildDefaultHeaderSettings(buildModel, pdfPageSpecification),
                HtmlContent = buildModel.HtmlContent,
                PagesCount = buildModel.UsePageCount,
                WebSettings = BuildDefaultWebSettings(pdfPageSpecification),
            };

            // Issue with libwkhtmltox if false is used
            if (objectSettings.PagesCount.HasValue && objectSettings.PagesCount.Value.Equals(false))
            {
                objectSettings.PagesCount = null;
            }

            return Task.FromResult(objectSettings);
        }

        private Task<GlobalSettings> GetGlobalSettings(IPdfBuildModel buildModel, IPdfPageSpecification pdfPageSpecification)
        {
            if (!buildModel.IsValid())
                throw new ArgumentNullException(nameof(BuildDefaultWebSettings));

            var globalSettings = new GlobalSettings
            {
                ColorMode = pdfPageSpecification.PageColorMode,
                Orientation = pdfPageSpecification.PageOrientation,
                PaperSize = pdfPageSpecification.PaperSize,
                Margins = pdfPageSpecification.PageMargins,
                DocumentTitle = buildModel.DocumentTitle,
            };

            return Task.FromResult(globalSettings);
        }
    }
}