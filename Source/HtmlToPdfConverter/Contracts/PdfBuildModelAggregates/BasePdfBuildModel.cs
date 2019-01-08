namespace HtmlToPdfConverter.Contracts.PdfBuildModelAggregates
{
    public abstract class BasePdfBuildModel : IPdfBuildModel
    {
        public BasePdfBuildModel(string documentTitle, string htmlContent)
        {
            DocumentTitle = documentTitle;
            HtmlContent = htmlContent;
        }

        /// <summary>
        /// PDF Document Title => default (string.empty)
        /// </summary>
        public string DocumentTitle { get; private set; }

        /// <summary>
        /// String placed in center of footer => default (string.empty)
        /// </summary>
        public string FooterCenterText { get; private set; }

        /// <summary>
        /// String placed on left side of footer => default (string.empty)
        /// </summary>
        public string FooterLeftText { get; private set; }

        /// <summary>
        /// String placed on right side of footer => default (string.empty)
        /// </summary>
        public string FooterRightText { get; private set; }

        /// <summary>
        /// String placed in center of header => default (string.empty)
        /// </summary>
        public string HeaderCenterText { get; private set; }

        /// <summary>
        /// String placed on left side of header => default (string.empty)
        /// </summary>
        public string HeaderLeftText { get; private set; }

        /// <summary>
        /// String placed on right side of header => default (string.empty)
        /// </summary>
        public string HeaderRightText { get; private set; }

        /// <summary>
        /// Html used for creating pdf content => default (string.empty)
        /// </summary>
        public string HtmlContent { get; private set; }

        /// <summary>
        /// Uri used to display link on pdf => default (string.empty)
        /// </summary>
        public string HtmlUri { get; private set; }

        /// <summary>
        /// Places line between content and footer => default (false)
        /// </summary>
        public bool UseFooterLine { get; private set; } = false;

        /// <summary>
        /// Places line between content and header => default (false)
        /// </summary>
        public bool UseHeaderLine { get; private set; } = false;

        /// <summary>
        /// Sets page numbering active => default (false)
        /// </summary>
        public bool UsePageCount { get; private set; } = false;


        /// <summary>
        /// Text is placed in center of a 3 column footer
        /// </summary>
        /// <param name="centerFooterText"></param>
        protected virtual void SetFooterCenterText(string centerFooterText)
        {
            FooterCenterText = centerFooterText;
        }

        /// <summary>
        /// Text is placed on left column of a 3 column footer
        /// </summary>
        /// <param name="leftFooterText"></param>
        protected virtual void SetFooterLeftText(string leftFooterText)
        {
            FooterLeftText = leftFooterText;
        }
        /// <summary>
        /// A line is added between document content and footer
        /// </summary>
        protected virtual void SetFooterLine()
        {
            UseFooterLine = true;
        }

        /// <summary>
        /// Text is placed on right column of a 3 column footer
        /// </summary>
        protected virtual void SetFooterRightText(string rightFooterText)
        {
            FooterRightText = rightFooterText;
        }

        /// <summary>
        /// Text is placed on center column of a 3 column header
        /// </summary>
        /// <param name="centerHeaderText"></param>
        protected virtual void SetHeaderCenterText(string centerHeaderText)
        {
            HeaderCenterText = centerHeaderText;
        }

        /// <summary>
        /// Text is placed on left column of a 3 column header
        /// </summary>
        /// <param name="leftHeaderText"></param>
        protected virtual void SetHeaderLeftText(string leftHeaderText)
        {
            HeaderLeftText = leftHeaderText;
        }

        /// <summary>
        /// A line is added between document content and header
        /// </summary>
        protected virtual void SetHeaderLine()
        {
            UseHeaderLine = true;
        }

        /// <summary>
        /// Text is placed on right column of a 3 column header
        /// </summary>
        /// <param name="rightHeaderText"></param>
        protected virtual void SetHeaderRightText(string rightHeaderText)
        {
            HeaderRightText = rightHeaderText;
        }

        /// <summary>
        /// Html uri is placed at the bottom of the page
        /// </summary>
        /// <param name="htmlUri"></param>
        protected virtual void SetHtmlUri(string htmlUri)
        {
            HtmlUri = htmlUri;
        }

        /// <summary>
        /// Activate the use of pagecount. IMPORTANT! In order to display the pagecount you should add "Page [page] of [toPage]" to 1 of the header or footer text columns.
        /// </summary>
        protected virtual void SetPageCount()
        {
            UsePageCount = true;
        }
    }
}
