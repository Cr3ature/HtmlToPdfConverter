using DinkToPdf;
using DinkToPdf.Contracts;
using HtmlToPdfConverter.Abstractions;
using HtmlToPdfConverter.Abstractions.Contracts;
using HtmlToPdfConverter.Core.Validator;
using System;
using System.Threading.Tasks;

namespace HtmlToPdfConverter.Core
{
    public class PdfConverterCore : IPdfConverterCore
    {
        private static readonly DefaultSettings _defaultSettings = new DefaultSettings();
        private readonly IConverter _converter;

        public PdfConverterCore(IConverter converter)
        {
            _converter = converter;
        }

        public Task<HtmlToPdfDocument> ConvertToPdf(GlobalSettings globalSettings, ObjectSettings objectSettings)
        {
            if (globalSettings == null || objectSettings == null)
            {
                throw new ArgumentNullException(nameof(ConvertToPdf));
            }

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return Task.FromResult(pdf);
        }

        public async Task<byte[]> CreatePdfDocument(ObjectSettingsBuildModel buildModel)
        {
            try
            {
                if (!buildModel.IsValid()) throw new ArgumentNullException(nameof(buildModel));

                GlobalSettings globalSettings = await GetGlobalSettings(buildModel);
                ObjectSettings objectSettings = await GetDefaultObjectSettings(buildModel);

                HtmlToPdfDocument pdfDocument = await ConvertToPdf(globalSettings, objectSettings);

                return _converter.Convert(pdfDocument);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(CreatePdfDocument), ex);
            }
        }

        public Task<ObjectSettings> GetDefaultObjectSettings(ObjectSettingsBuildModel buildModel)
        {
            if (string.IsNullOrWhiteSpace(buildModel.HtmlContent))
            {
                throw new ArgumentNullException(nameof(GetDefaultObjectSettings));
            }

            var result = new ObjectSettings
            {
                FooterSettings = BuildDefaultFooterSettings(buildModel),
                HeaderSettings = BuildDefaultHeaderSettings(buildModel),
                HtmlContent = buildModel.HtmlContent,
                PagesCount = buildModel.UsePageCount,
                WebSettings = BuildDefaultWebSettings(buildModel),
            };

            return Task.FromResult(result);
        }

        public Task<GlobalSettings> GetGlobalSettings(ObjectSettingsBuildModel buildModel)
        {
            if (!buildModel.IsValid()) throw new ArgumentNullException(nameof(BuildDefaultWebSettings));

            var result = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 20, Bottom = 20 },
                DocumentTitle = buildModel.DocumentTitle,
            };

            return Task.FromResult(result);
        }

        public async Task<byte[]> SavePdfDocumentToFilePath(ObjectSettingsBuildModel buildModel, string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath) || !buildModel.IsValid()) throw new ArgumentNullException(nameof(SavePdfDocumentToFilePath));

                GlobalSettings globalSettings = await GetGlobalSettings(buildModel);
                ObjectSettings objectSettings = await GetDefaultObjectSettings(buildModel);

                HtmlToPdfDocument pdfDocument = await ConvertToPdf(globalSettings, objectSettings);
                pdfDocument.GlobalSettings.Out = filePath;

                return _converter.Convert(pdfDocument);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(CreatePdfDocument), ex);
            }
        }

        private static FooterSettings BuildDefaultFooterSettings(ObjectSettingsBuildModel buildModel)
        {
            return new FooterSettings
            {
                FontName = _defaultSettings.FontName,
                FontSize = _defaultSettings.FontSize,
                Line = buildModel.UseFooterLine,
                Left = buildModel.FooterLeftText ?? string.Empty,
                Center = buildModel.FooterCenterText ?? string.Empty,
                Right = buildModel.FooterRightText ?? string.Empty,
                Spacing = _defaultSettings.PageSpacing,
            };
        }

        private static HeaderSettings BuildDefaultHeaderSettings(ObjectSettingsBuildModel buildModel)
        {
            return new HeaderSettings
            {
                FontName = _defaultSettings.FontName,
                FontSize = _defaultSettings.FontSize,
                Line = buildModel.UseHeaderLine,
                Left = buildModel.HeaderLeftText ?? string.Empty,
                Center = buildModel.HeaderCenterText ?? string.Empty,
                Right = buildModel.HeaderRightText ?? string.Empty,
                Spacing = _defaultSettings.PageSpacing
            };
        }

        private static WebSettings BuildDefaultWebSettings(ObjectSettingsBuildModel buildModel)
        {
            return new WebSettings
            {
                DefaultEncoding = _defaultSettings.DefaultEncoding,
                UserStyleSheet = null,
            };
        }
    }
}
