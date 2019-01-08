# HtmlToPdfConverter 

HtmlToPdfConverter is a wrapper of the [DinkToPdf](https://github.com/rdvojmoc/DinkToPdf) by [Rok Dvojmoč](https://github.com/rdvojmoc).  

## Get it on nuget
Dotnet Core with DI integration
````
PM> Install-Package HtmlToPdfConverter.Core
````

## Supports
- Pdf generation using specifications
- The native libraries used in DinkToPdf (libwkhtmltox) are integrated and 
- Service extension for DI that imports appropriate library (by OS and Platform) into assembly

## Todo
- HtmlToPdfConverter as stand-alone nuget for use with other IOC solutions
- File save to directories with path checks and path builder cross OS

## Use

In order to use the service there are abstract classes made for configuration of the PDF result.

#### PageSettings

Base constructor contains required fields (color (color or grey), page margins, page orientation, pageSize)
Set methods are optional if you want to override the defaults.

````csharp


public class TestPdfSpecification : BasePdfPageSpecification
{
    public TestPdfSpecification()
        : base(
            ColorMode.Color, 
            new MarginSettings { Top = 20, Bottom = 20 }, 
            Orientation.Portrait, 
            PaperKind.A4)
    {
        SetDefaultEncoding("utf-8");
        SetFontName("Arial");
        SetFontSize(12);
        SetPageSpacing(10);
        SetUserStyleSheet(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "example.css"));
    }
}
````

#### BuildModel

Base constructor contains required fields (documentTitle and htmlContent) in order to work. 
All the other Set methods are optional if you want to override the defaults.

````csharp
public class DefaultBuildModel : BasePdfBuildModel
{
    public DefaultBuildModel(string documentTitle, string htmlContent)
        : base(documentTitle, htmlContent)
    {
        SetFooterCenterText(string.Empty);
        SetFooterLeftText(string.Empty);
        SetFooterLine();
        SetFooterRightText(string.Empty);
        SetHeaderCenterText(string.Empty);
        SetHeaderLeftText(string.Empty);
        SetHeaderLine();
        SetHeaderRightText("Page [page] of [toPage]");
        SetHtmlUri(string.Empty);
        SetPageCount();
    }
}
````