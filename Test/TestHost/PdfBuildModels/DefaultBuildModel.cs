namespace TestHost.PdfBuildModels
{
    using HtmlToPdfConverter;

    public class DefaultBuildModel : BasePdfBuildModel
    {
        public DefaultBuildModel(string documentTitle, string htmlContent)
            : base(documentTitle, htmlContent)
        {
            SetFooterCenterText(string.Empty);
            SetFooterLeftText(string.Empty);
            SetFooterLine();
            SetFooterRightText(string.Empty);
            SetHeaderCenterText(string.Empty);
            SetHeaderLeftText(string.Empty);
            SetHeaderLine();
            SetHeaderRightText("Page [page] of [toPage]");
            SetHtmlUri(string.Empty);
            SetPageCount();
        }
    }
}