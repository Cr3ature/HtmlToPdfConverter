using DinkToPdf;

namespace HtmlToPdfConverter.Contracts.PageSettings
{
    public abstract class BasePdfPageSpecification : IBasePdfPageSpecification
    {
        // Summary:
        // DefaultEncoding of the document
        public string DefaultEncoding { get; private set; } = "utf-8";

        // Summary:
        // Font used on document
        public string FontName { get; private set; } = "Arial";

        // Summary:
        // Fontsize of header and footer text
        public int FontSize { get; private set; } = 9;

        // Summary:
        // Page margins (Top, Bottom, Left, Right)
        public MarginSettings PageMargins { get; private set; } = new MarginSettings { Top = 20, Bottom = 20 };

        // Summary:
        // Spacing used on header and footer
        public int PageSpacing { get; private set; } = 10;

        // Summary:
        // Uri of Stylesheet used on document
        public string UserStyleSheet { get; private set; } = string.Empty;

        protected virtual void SetDefaultEncoding(string encoding)
        {
            this.DefaultEncoding = encoding;
        }

        protected virtual void SetFontName(string fontName)
        {
            this.FontName = fontName;
        }

        protected virtual void SetFontSize(int fontSize)
        {
            this.FontSize = fontSize;
        }

        protected virtual void SetPageMargins(MarginSettings marginSettings)
        {
            this.PageMargins = marginSettings;
        }

        protected virtual void SetPageSpacing(int pageSpacing)
        {
            this.PageSpacing = pageSpacing;
        }

        protected virtual void SetUserStyleSheet(string userStyleSheetUri)
        {
            this.UserStyleSheet = userStyleSheetUri;
        }
    }
}
