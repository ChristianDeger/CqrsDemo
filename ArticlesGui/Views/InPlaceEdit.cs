using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HtmlTags;

namespace ArticlesGui.Views
{
    public static class InPlaceEdit
    {
        public static MvcHtmlString InPlaceEditFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string postTo, object htmlAttributes)
        {
            var value = expression.Compile().Invoke(htmlHelper.ViewData.Model).ToString();
            var textBox = htmlHelper.TextBoxFor(expression, htmlAttributes);

            var inPlaceText = new HtmlTag("span", x =>
            {
                x.AddClass("in-place-text");
                x.Data("post-to", postTo);
            })
                .Append(
                    new HtmlTag("span").AddClass("in-place-view")
                        .Append(
                            new HtmlTag("span").AddClass("detailsText").Text(value)
                        )
                        .Append(
                            new HtmlTag("img", y =>
                            {
                                y.Attr("src", "/Content/pencil_icon.gif");
                                y.Attr("alt", "Edit");
                                y.AddClass("action-image");
                            })
                       )
                )
                .Append(
                    new HtmlTag("span").AddClass("in-place-edit")
                        .AppendHtml(textBox.ToString())
                        .Append(
                            new HtmlTag("img", y =>
                            {
                                y.Attr("src", "/Content/save-icon-32.png");
                                y.Attr("alt", "Edit");
                                y.AddClass("action-image");
                            })
                        )
                );

            return new MvcHtmlString(inPlaceText.ToHtmlString());
        }
    }
}