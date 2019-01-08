namespace HtmlToPdfConverter.Contracts.PageSettingsAggregates
{
    using DinkToPdf;

    public abstract class BasePdfPageSpecification : IPdfPageSpecification
    {
        /// <summary>
        /// Base setup required for building pdf. No defaults are set, so inputs are required.
        /// </summary>
        /// <param name="colorMode"></param>
        /// <param name="pageMargins"></param>
        /// <param name="orientation"></param>
        /// <param name="paperSize"></param>
        public BasePdfPageSpecification(ColorMode colorMode, MarginSettings pageMargins, Orientation orientation, PaperKind paperSize)
        {
            this.PageColorMode = colorMode;
            this.PageMargins = pageMargins ?? new MarginSettings { Top = 20, Bottom = 20 };
            this.PageOrientation = orientation;
            this.PaperSize = paperSize;
        }

        /// <summary>
        /// DefaultEncoding of the document => default (utf-8)
        /// </summary>
        public string DefaultEncoding { get; private set; } = "utf-8";

        /// <summary>
        /// Font used on document => default (Arial)
        /// </summary>
        public string FontName { get; private set; } = "Arial";

        /// <summary>
        /// Fontsize of header and footer text => default (12)
        /// </summary>
        public int? FontSize { get; private set; }

        /// <summary>
        /// Colormode used for pdf (color or grayscale)
        /// </summary>
        public ColorMode PageColorMode { get; private set; }

        /// <summary>
        /// Page margins (Top, Bottom, Left, Right) => default (top 20, bottom 20)
        /// </summary>
        public MarginSettings PageMargins { get; private set; }

        /// <summary>
        /// Page orientation (portrait or landscape)
        /// </summary>
        public Orientation PageOrientation { get; private set; }

        /// <summary>
        /// Spacing used on header and footer => default 10
        /// </summary>
        public double PageSpacing { get; private set; } = 10;

        /// <summary>
        /// Papersize of the document
        /// </summary>
        public PaperKind PaperSize { get; private set; }

        /// <summary>
        ///  Uri of Stylesheet used on document => default ""
        /// </summary>
        public string UserStyleSheet { get; private set; } = string.Empty;

        /// <summary>
        /// Set the default encoding for the html content => default (utf-8)
        /// </summary>
        /// <param name="encoding"></param>
        protected virtual void SetDefaultEncoding(string encoding)
        {
            this.DefaultEncoding = encoding;
        }

        /// <summary>
        /// Set the font name to be used on document => default (Arial)
        /// </summary>
        /// <param name="fontName"></param>
        protected virtual void SetFontName(string fontName)
        {
            this.FontName = fontName;
        }

        /// <summary>
        /// Set the font size to be used on document => default (12)
        /// </summary>
        /// <param name="fontSize"></param>
        protected virtual void SetFontSize(int fontSize)
        {
            this.FontSize = fontSize;
        }

        /// <summary>
        /// Set the page spacing to be used on the document => default (10)
        /// </summary>
        /// <param name="pageSpacing"></param>
        protected virtual void SetPageSpacing(int pageSpacing)
        {
            this.PageSpacing = pageSpacing;
        }

        /// <summary>
        /// Set user style by css path
        /// </summary>
        /// <param name="userStyleSheetUri"></param>
        protected virtual void SetUserStyleSheet(string userStyleSheetUri)
        {
            this.UserStyleSheet = userStyleSheetUri;
        }
    }
}
