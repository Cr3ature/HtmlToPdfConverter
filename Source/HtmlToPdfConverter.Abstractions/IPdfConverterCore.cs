using DinkToPdf;
using HtmlToPdfConverter.Abstractions.Contracts;
using System.Threading.Tasks;

namespace HtmlToPdfConverter.Abstractions
{
    public interface IPdfConverterCore
    {
        Task<HtmlToPdfDocument> ConvertToPdf(GlobalSettings globalSettings, ObjectSettings objectSettings);

        Task<byte[]> CreatePdfDocument(ObjectSettingsBuildModel buildModel);

        Task<ObjectSettings> GetDefaultObjectSettings(ObjectSettingsBuildModel buildModel);

        Task<GlobalSettings> GetGlobalSettings(ObjectSettingsBuildModel buildModel);

        Task<byte[]> SavePdfDocumentToFilePath(ObjectSettingsBuildModel buildModel, string filePath);
    }
}
