namespace HtmlToPdfConverter
{
    using DinkToPdf;

    public interface IPdfPageSpecification
    {
        // Summary:
        // DefaultEncoding of the document
        string DefaultEncoding { get; }

        // Summary:
        // Font used on document
        string FontName { get; }

        // Summary:
        // Fontsize of header and footer text
        int? FontSize { get; }

        // Summary:
        // Colormode used for pdf (color or grayscale)
        ColorMode PageColorMode { get; }

        // Summary:
        // Page margins (Top, Bottom, Left, Right)
        MarginSettings PageMargins { get; }

        // Summary:
        // Page orientation (portrait or landscape)
        Orientation PageOrientation { get; }

        // Summary:
        // Spacing used on header and footer
        double PageSpacing { get; }

        // Summary:
        // Papersize of the document
        PaperKind PaperSize { get; }

        // Summary:
        // Uri of Stylesheet used on document
        string UserStyleSheet { get; }
    }
}
