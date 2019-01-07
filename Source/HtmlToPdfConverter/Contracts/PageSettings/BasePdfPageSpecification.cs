using DinkToPdf;

namespace HtmlToPdfConverter.Contracts.PageSettings
{
    public abstract class BasePdfPageSpecification : IBasePdfPageSpecification
    {
        public BasePdfPageSpecification(ColorMode colorMode, MarginSettings pageMargins, Orientation orientation, PaperKind paperSize)
        {
            this.PageColorMode = colorMode;
            this.PageMargins = pageMargins ?? new MarginSettings { Top = 20, Bottom = 20 };
            this.PageOrientation = orientation;
            this.PaperSize = paperSize;
        }

        // Summary:
        // DefaultEncoding of the document => default (utf-8)
        public string DefaultEncoding { get; private set; } = "utf-8";

        // Summary:
        // Font used on document => default (Arial)
        public string FontName { get; private set; } = "Arial";

        // Summary:
        // Fontsize of header and footer text => default (12)
        public int? FontSize { get; private set; }

        // Summary:
        // Colormode used for pdf (color or grayscale)
        public ColorMode PageColorMode { get; private set; }

        // Summary:
        // Page margins (Top, Bottom, Left, Right) => default (top 20, bottom 20)
        public MarginSettings PageMargins { get; private set; }

        // Summary:
        // Page orientation (portrait or landscape)
        public Orientation PageOrientation { get; private set; }

        // Summary:
        // Spacing used on header and footer => default 10
        public double PageSpacing { get; private set; } = 10;

        // Summary:
        // Papersize of the document
        public PaperKind PaperSize { get; private set; }

        // Summary:
        // Uri of Stylesheet used on document => default ""
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
