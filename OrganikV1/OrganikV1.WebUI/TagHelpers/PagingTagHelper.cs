using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace OrganikV1.WebUI.TagHelpers
{
    [HtmlTargetElement("pager")]
    public class PagingTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }

        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }

        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }

        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='pags'>");
            sb.Append("<li class='fa fa-chevron-left'><a href='"+ (CurrentPage-1)+ "'></a></li>");
            for (int i = 1; i <= PageCount; i++)
            {
                sb.AppendFormat("<li class='"+( i == CurrentPage ? "active" : "" )+ "'>");
                //sb.AppendFormat("<a href='/Home/Index/kat-{1}/sayfa-{0}'>{2}</a>", i, CurrentCategory, i);
                sb.AppendFormat("<a href='../{1}/{0}'>{2}</a>", i, CurrentCategory, i);
                sb.Append("</li>");
            }
            sb.Append("<li class='fa fa-chevron-right'><a href='"+ (CurrentPage + 1) + "'></a></li>");

            output.Content.SetHtmlContent(sb.ToString());
            base.Process(context, output);
        }
    }

}
