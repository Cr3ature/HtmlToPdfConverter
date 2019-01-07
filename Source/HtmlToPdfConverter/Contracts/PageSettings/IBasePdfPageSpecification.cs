using DinkToPdf;

namespace HtmlToPdfConverter.Contracts.PageSettings
{
    public interface IBasePdfPageSpecification
    {
        // Summary:
        // DefaultEncoding of the document
        string DefaultEncoding { get; }

        // Summary:
        // Font used on document
        string FontName { get; }

        // Summary:
        // Fontsize of header and footer text
        int FontSize { get; }

        // Summary:
        // Page margins (Top, Bottom, Left, Right)
        MarginSettings PageMargins { get; }

        // Summary:
        // Spacing used on header and footer
        int PageSpacing { get; }

        // Summary:
        // Uri of Stylesheet used on document
        string UserStyleSheet { get; }
    }
}
