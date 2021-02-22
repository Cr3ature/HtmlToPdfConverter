namespace HtmlToPdfConverter.Validator
{
    using HtmlToPdfConverter;

    public static class ObjectSettingsBuildModelValidator
    {
        public static bool IsValid(this IPdfBuildModel buildModel)
        {
            if (buildModel == null) return false;

            if (string.IsNullOrWhiteSpace(buildModel.DocumentTitle)) return false;

            if (string.IsNullOrWhiteSpace(buildModel.HtmlContent)) return false;

            if (buildModel.UsePageCount &&
                string.IsNullOrWhiteSpace(buildModel.HeaderCenterText) &&
                string.IsNullOrWhiteSpace(buildModel.HeaderLeftText) &&
                string.IsNullOrWhiteSpace(buildModel.HeaderRightText) &&
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