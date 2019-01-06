using HtmlToPdfConverter.Abstractions.Contracts;

namespace HtmlToPdfConverter.Core.Validator
{
    public static class ObjectSettingsBuildModelValidator
    {
        public static bool IsValid(this ObjectSettingsBuildModel buildModel)
        {
            if (buildModel == null) return false;

            if (string.IsNullOrWhiteSpace(buildModel.DocumentTitle)) return false;

            if (string.IsNullOrWhiteSpace(buildModel.HtmlContent)) return false;

            if (buildModel.UseHeaderLine &&
                string.IsNullOrWhiteSpace(buildModel.HeaderCenterText) &&
                string.IsNullOrWhiteSpace(buildModel.HeaderLeftText) &&
                string.IsNullOrWhiteSpace(buildModel.HeaderRightText))
            {
                return false;
            }

            if (buildModel.UseFooterLine &&
                string.IsNullOrWhiteSpace(buildModel.FooterCenterText) &&
                string.IsNullOrWhiteSpace(buildModel.FooterLeftText) &&
                string.IsNullOrWhiteSpace(buildModel.FooterRightText))
            {
                return false;
            }

            return true;
        }
    }
}
