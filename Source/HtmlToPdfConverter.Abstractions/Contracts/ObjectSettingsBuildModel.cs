namespace HtmlToPdfConverter.Abstractions.Contracts
{
    public class ObjectSettingsBuildModel
    {
        public string DocumentTitle { get; set; }

        public string FooterCenterText { get; set; }

        public string FooterLeftText { get; set; }

        public string FooterRightText { get; set; }

        public string HeaderCenterText { get; set; }

        public string HeaderLeftText { get; set; }

        public string HeaderRightText { get; set; }

        public string HtmlContent { get; set; }

        public bool UseFooterLine { get; set; }

        public bool UseHeaderLine { get; set; }

        public bool UsePageCount { get; set; }
    }
}
