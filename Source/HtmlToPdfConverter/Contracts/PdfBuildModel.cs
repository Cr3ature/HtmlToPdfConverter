namespace HtmlToPdfConverter.Contracts
{
    public class PdfBuildModel
    {
        //
        // Summary:
        //     The title of the PDF document. Default = ""
        public string DocumentTitle { get; set; } = string.Empty;

        public string FooterCenterText { get; set; } = string.Empty;

        public string FooterLeftText { get; set; } = string.Empty;

        public string FooterRightText { get; set; } = string.Empty;

        public string HeaderCenterText { get; set; } = string.Empty;

        public string HeaderLeftText { get; set; } = string.Empty;

        public string HeaderRightText { get; set; } = string.Empty;

        public string HtmlContent { get; set; } = string.Empty;

        public string HtmlUri { get; set; } = string.Empty;

        public bool UseFooterLine { get; set; } = false;

        public bool UseHeaderLine { get; set; } = false;

        public bool UsePageCount { get; set; } = false;
    }
}
