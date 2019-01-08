namespace HtmlToPdfConverter.Contracts.PdfBuildModelAggregates
{
    public interface IPdfBuildModel
    {
        // Summary:
        // PDF Document Title => default ("")
        string DocumentTitle { get; }

        // Summary:
        // String placed in center of footer => default ("")
        string FooterCenterText { get; }

        // Summary:
        // String placed on left side of footer => default ("")
        string FooterLeftText { get; }

        // Summary:
        // String placed on right side of footer => default ("")
        string FooterRightText { get; }

        // Summary:
        // String placed in center of header => default ("")
        string HeaderCenterText { get; }

        // Summary:
        // String placed on left side of header => default ("")
        string HeaderLeftText { get; }

        // Summary:
        // String placed on right side of header => default ("")
        string HeaderRightText { get; }

        // Summary:
        // Html used for creating pdf content => default ("")
        string HtmlContent { get; }

        // Summary:
        // Uri used to display link on pdf => default ("")
        string HtmlUri { get; }

        // Summary:
        // Places line between content and footer => default (false)
        bool UseFooterLine { get; }

        // Summary:
        // Places line between content and header => default (false)
        bool UseHeaderLine { get; }

        // Summary:
        // Sets page numbering active => default (false)
        bool UsePageCount { get; }
    }
}
