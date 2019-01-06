namespace HtmlToPdfConverter.Abstractions.Contracts
{
    public class DefaultSettings
    {
        public int FontSize { get; private set; } = 9;

        public string DefaultEncoding { get; private set; } = "utf-8";

        public string FontName { get; private set; } = "Arial";

        public int PageSpacing { get; private set; } = 10;

        public int MarginTop { get; private set; } = 20;

        public int MarginBottom { get; private set; } = 20;

        protected virtual void SetFontSize(int fontSize)
        {
            this.FontSize = fontSize;
        }

        protected virtual void SetDefaultEncoding(string encoding)
        {
            this.DefaultEncoding = encoding;
        }

        protected virtual void SetFontName(string fontName)
        {
            this.FontName = fontName;
        }

        protected virtual void SetPageSpacing(int pageSpacing)
        {
            this.PageSpacing = pageSpacing;
        }

        protected virtual void SetMarginTop(int marginTop)
        {
            this.MarginTop = marginTop;
        }

        protected virtual void SetMarginBottom(int marginBottom)
        {
            this.MarginBottom = marginBottom;
        }
    }
}
