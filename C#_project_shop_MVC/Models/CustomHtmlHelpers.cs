using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

public static class CustomHtmlHelpers
{
    public static IHtmlContent BootstrapButtonWithIcon(this IHtmlHelper helper, string buttonText, string iconClass, string buttonClass = "btn-primary")
    {
        var content = new HtmlContentBuilder();

        content.AppendHtml($"<button class='btn {buttonClass}'><i class='{iconClass}'></i> {buttonText}</button>");

        return content;
    }

    public static IHtmlContent DisplayShoeMessage(this IHtmlHelper htmlHelper, int totalShoes)
    {
        var message = totalShoes switch
        {
            0 => "No items available in the store.",
            1 => "One item available in the store.",
            _ => $"{totalShoes} items available in the store."
        };

        return new HtmlString($"<p>{message}</p>");
    }

    public static IHtmlContent DisplaySalesMessage(this IHtmlHelper htmlHelper, int totalSales)
    {
        var message = totalSales switch
        {
            0 => "No sales available in the store.",
            1 => "One sale available in the store.",
            _ => $"{totalSales} sales available in the store."
        };

        return new HtmlString($"<p>{message}</p>");
    }

    public static IHtmlContent DisplayShoesSeasonMessage(this IHtmlHelper htmlHelper, int totalShoes, string season)
    {
        var message = totalShoes switch
        {
            0 => $"No shoes available for the {season} season.",
            1 => $"One shoe available for the {season} season.",
            _ => $"{totalShoes} shoes available for the {season} season."
        };

        return new HtmlString($"<p>{message}</p>");
    }
}