#pragma checksum "C:\Users\16313\Desktop\C#\Exercises\QuoteGenerator\QuoteGenerator\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b15d2f8e4779fbccab4055de451155243eec466"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\16313\Desktop\C#\Exercises\QuoteGenerator\QuoteGenerator\Views\_ViewImports.cshtml"
using QuoteGenerator;

#line default
#line hidden
#line 2 "C:\Users\16313\Desktop\C#\Exercises\QuoteGenerator\QuoteGenerator\Views\_ViewImports.cshtml"
using QuoteGenerator.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b15d2f8e4779fbccab4055de451155243eec466", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d894bfb8a1e27aa9555475cd9f6e3828027b6a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 261, true);
            WriteLiteral(@"

<div class=""row row-no-gutters m-3"">
    <div class=""card col-sm-12 col-md-10 col-lg-6 mx-auto shadow"">
        <div class=""card-header"">
            <h4 class=""center m-0"">Get your FREE quote here!</h4>
        </div>
        <div class=""card-body"">
");
            EndContext();
#line 9 "C:\Users\16313\Desktop\C#\Exercises\QuoteGenerator\QuoteGenerator\Views\Home\Index.cshtml"
             using (Html.BeginForm("QuoteGenerator", "Home", FormMethod.Post))
            {

#line default
#line hidden
            BeginContext(356, 1953, true);
            WriteLiteral(@"                <div class=""row"">
                    <div class=""form-group col-md-5"">
                        <h6>*First Name: </h6>
                        <input name=""FirstName"" type=""text"" class=""form-control"" />
                        <h6>*Last Name: </h6>
                        <input name=""LastName"" type=""text"" class=""form-control"" />
                        <h6>*Email: </h6>
                        <input name=""EmailAddress"" type=""email"" class=""form-control"" />
                        <h6>*Date of Bith:</h6>
                        <input name=""DOB"" type=""date"" class=""form-control"" />
                        <h6>*Car Year: </h6>
                        <input name=""CarYear"" type=""number"" min=""1950"" max=""2021"" class=""form-control"" />
                        <h6>*Car Make: </h6>
                        <input name=""CarMake"" type=""text"" class=""form-control"" />
                        <h6>*Car Model: </h6>
                        <input name=""CarModel"" type=""text"" class=""form-control"" /");
            WriteLiteral(@">
                        
                        <h6>*How many tickets have you recieved? </h6>
                        <input name=""tickets"" type=""number"" min =""0"" class=""form-control"" />
                        
                        <h6>*Have you ever had a DUI? </h6>
                        <input type=""radio"" name=""DUI"" id=""Yes"" value=""1"">Yes
                        <input type=""radio"" name=""DUI"" id=""No"" value=""0"">No

                        <h6>*Would they like full coverage or liability?</h6>
                        <input type=""radio"" name=""Insurance"" id=""FullCoverage"" value=""0"">Full Coverage
                        <input type=""radio"" name=""Insurance"" id=""Liability"" value=""1"">Liability
                        <br>
                        <br>
                        <button type=""submit"" class=""btn btn-block btn-primary"">Submit</button>
                    </div>
                </div>
");
            EndContext();
#line 43 "C:\Users\16313\Desktop\C#\Exercises\QuoteGenerator\QuoteGenerator\Views\Home\Index.cshtml"
            }  

#line default
#line hidden
            BeginContext(2326, 34, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591