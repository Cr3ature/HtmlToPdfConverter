using DinkToPdf;
using HtmlToPdfConverter.Contracts.PageSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestHost.PageSettings
{
    public class TestPdfSpecification: BasePdfPageSpecification
    {
        public TestPdfSpecification()
            :base(ColorMode.Color, new MarginSettings { Top = 20, Bottom = 20}, Orientation.Portrait, PaperKind.A4)
        {
        }
    }
}
