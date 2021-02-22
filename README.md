# HtmlToPdfConverter 
[![Build Status](https://dev.azure.com/DavidVanderheyden/HtmlToPdfConverter/_apis/build/status/HtmlToPdfConverter-CI?branchName=master)](https://dev.azure.com/DavidVanderheyden/HtmlToPdfConverter/_build/latest?definitionId=8&branchName=master)

HtmlToPdfConverter is a wrapper of the [DinkToPdf](https://github.com/rdvojmoc/DinkToPdf) by [Rok Dvojmoč](https://github.com/rdvojmoc) for use within with support for .NET 5.  

## Get it on nuget
Dotnet Core with DI integration
````
PM> Install-Package HtmlToPdfConverter
````

## Supports
- Pdf generation using specifications
- The native libraries used in DinkToPdf (libwkhtmltox) are integrated 
- Service extension for DI that imports the appropriate library (by OS and Platform) into assembly

## Todo
- File save to directories with path checks and path builder cross OS

## Use

In order to use the service there are abstract classes made for configuration of the PDF result.

Abstract classes
- BasePdfPageSpecification
- 

#### Setup the wrapper

Setup DI registrations and bootstrap DinkToPdf

````csharp

// Inside startup.cs

 using HtmlToPdfConverter;

 public void ConfigureServices(IServiceCollection services)
        {
            services.AddHtmlToPdfConverter();
        }
````

#### PageSettings

Base constructor contains required fields (color (color or grey), page margins, page orientation, pageSize)
Set methods are optional if you want to override the defaults.


Bootstrap your pdf specification for a colormode, setting margins, oritentation and paperkind. It is possible to set variables with new values this happens with specific virtual methods to keep the model as sealed as possible.

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
        // Set the default encoding for the html content => default (utf-8)
        SetDefaultEncoding("utf-8");

        // Set the font name to be used on document => default (Arial)
        SetFontName("Arial");

        // Set the font size to be used on document => default (12)
        SetFontSize(12);
        
        // Set the page spacing to be used on the document => default (10)
        SetPageSpacing(10);

        // Set user style by css path
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
