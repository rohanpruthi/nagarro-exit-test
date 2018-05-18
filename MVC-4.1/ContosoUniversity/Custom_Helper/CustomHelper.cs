using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ContosoUniversity.Custom_Helper
{
    public static class CustomHelper
    {
        //public static IHtmlString Pager(this HtmlHelper html, int rowsPerPage, int totalRows, List<T> list)
        //{
        //    return 
        //}

        private static TagBuilder WrapInListItem(string text)

        {

            var li = new TagBuilder("li");

            li.SetInnerText(text);

            return li;

        }



        private static TagBuilder WrapInListItem(TagBuilder inner, PagedListRenderOptions options, params string[] classes)

        {

            var li = new TagBuilder("li");

            foreach (var @class in classes)

                li.AddCssClass(@class);

            if (options.FunctionToTransformEachPageLink != null)

                return options.FunctionToTransformEachPageLink(li, inner);

            li.InnerHtml = inner.ToString();

            return li;

        }



        private static TagBuilder First(IPagedList list, Func<int, string> generatePageUrl, PagedListRenderOptions options)

        {

            const int targetPageNumber = 1;

            var first = new TagBuilder("a")

            {

                InnerHtml = string.Format(options.LinkToFirstPageFormat, targetPageNumber)

            };



            if (list.IsFirstPage)

                return WrapInListItem(first, options, "PagedList-skipToFirst", "disabled");



            first.Attributes["href"] = generatePageUrl(targetPageNumber);

            return WrapInListItem(first, options, "PagedList-skipToFirst");

        }



        private static TagBuilder Previous(IPagedList list, Func<int, string> generatePageUrl, PagedListRenderOptions options)

        {

            var targetPageNumber = list.PageNumber - 1;

            var previous = new TagBuilder("a")

            {

                InnerHtml = string.Format(options.LinkToPreviousPageFormat, targetPageNumber)

            };

            previous.Attributes["rel"] = "prev";



            if (!list.HasPreviousPage)

                return WrapInListItem(previous, options, "PagedList-skipToPrevious", "disabled");



            previous.Attributes["href"] = generatePageUrl(targetPageNumber);

            return WrapInListItem(previous, options, "PagedList-skipToPrevious");

        }



        private static TagBuilder Page(int i, IPagedList list, Func<int, string> generatePageUrl, PagedListRenderOptions options)

        {

            var format = options.FunctionToDisplayEachPageNumber

                ?? (pageNumber => string.Format(options.LinkToIndividualPageFormat, pageNumber));

            var targetPageNumber = i;

            var page = new TagBuilder("a");

            page.SetInnerText(format(targetPageNumber));



            if (i == list.PageNumber)

                return WrapInListItem(page, options, "active");



            page.Attributes["href"] = generatePageUrl(targetPageNumber);

            return WrapInListItem(page, options);

        }



        private static TagBuilder Next(IPagedList list, Func<int, string> generatePageUrl, PagedListRenderOptions options)

        {

            var targetPageNumber = list.PageNumber + 1;

            var next = new TagBuilder("a")

            {

                InnerHtml = string.Format(options.LinkToNextPageFormat, targetPageNumber)

            };

            next.Attributes["rel"] = "next";



            if (!list.HasNextPage)

                return WrapInListItem(next, options, "PagedList-skipToNext", "disabled");



            next.Attributes["href"] = generatePageUrl(targetPageNumber);

            return WrapInListItem(next, options, "PagedList-skipToNext");

        }



        private static TagBuilder Last(IPagedList list, Func<int, string> generatePageUrl, PagedListRenderOptions options)

        {

            var targetPageNumber = list.PageCount;

            var last = new TagBuilder("a")

            {

                InnerHtml = string.Format(options.LinkToLastPageFormat, targetPageNumber)

            };



            if (list.IsLastPage)

                return WrapInListItem(last, options, "PagedList-skipToLast", "disabled");



            last.Attributes["href"] = generatePageUrl(targetPageNumber);

            return WrapInListItem(last, options, "PagedList-skipToLast");

        }



        private static TagBuilder PageCountAndLocationText(IPagedList list, PagedListRenderOptions options)

        {

            var text = new TagBuilder("a");

            text.SetInnerText(string.Format(options.PageCountAndCurrentLocationFormat, list.PageNumber, list.PageCount));



            return WrapInListItem(text, options, "PagedList-pageCountAndLocation", "disabled");

        }



        private static TagBuilder ItemSliceAndTotalText(IPagedList list, PagedListRenderOptions options)

        {

            var text = new TagBuilder("a");

            text.SetInnerText(string.Format(options.ItemSliceAndTotalFormat, list.FirstItemOnPage, list.LastItemOnPage, list.TotalItemCount));



            return WrapInListItem(text, options, "PagedList-pageCountAndLocation", "disabled");

        }



        private static TagBuilder Ellipses(PagedListRenderOptions options)

        {

            var a = new TagBuilder("a")

            {

                InnerHtml = options.EllipsesFormat

            };



            return WrapInListItem(a, options, "PagedList-ellipses", "disabled");

        }




        public static MvcHtmlString newPagedListPager(this System.Web.Mvc.HtmlHelper html,

                                                   IPagedList list,

                                                   Func<int, string> generatePageUrl)

        {

            return newPagedListPager(html, list, generatePageUrl, new PagedListRenderOptions());

        }


        public static MvcHtmlString newPagedListPager(this System.Web.Mvc.HtmlHelper html,

                                                   IPagedList list,

                                                   Func<int, string> generatePageUrl,

                                                   PagedListRenderOptions options)

        {

            if (options.Display == PagedListDisplayMode.Never || (options.Display == PagedListDisplayMode.IfNeeded && list.PageCount <= 1))

                return null;



            var listItemLinks = new List<TagBuilder>();



            //calculate start and end of range of page numbers

            var firstPageToDisplay = 1;

            var lastPageToDisplay = list.PageCount;

            var pageNumbersToDisplay = lastPageToDisplay;

            if (options.MaximumPageNumbersToDisplay.HasValue && list.PageCount > options.MaximumPageNumbersToDisplay)

            {

                // cannot fit all pages into pager

                var maxPageNumbersToDisplay = options.MaximumPageNumbersToDisplay.Value;

                firstPageToDisplay = list.PageNumber - maxPageNumbersToDisplay / 2;

                if (firstPageToDisplay < 1)

                    firstPageToDisplay = 1;

                pageNumbersToDisplay = maxPageNumbersToDisplay;

                lastPageToDisplay = firstPageToDisplay + pageNumbersToDisplay - 1;

                if (lastPageToDisplay > list.PageCount)

                    firstPageToDisplay = list.PageCount - maxPageNumbersToDisplay + 1;

            }



            //first

            if (options.DisplayLinkToFirstPage == PagedListDisplayMode.Always || (options.DisplayLinkToFirstPage == PagedListDisplayMode.IfNeeded && firstPageToDisplay > 1))

                listItemLinks.Add(First(list, generatePageUrl, options));



            //previous

            if (options.DisplayLinkToPreviousPage == PagedListDisplayMode.Always || (options.DisplayLinkToPreviousPage == PagedListDisplayMode.IfNeeded && !list.IsFirstPage))

                listItemLinks.Add(Previous(list, generatePageUrl, options));



            //text

            if (options.DisplayPageCountAndCurrentLocation)

                listItemLinks.Add(PageCountAndLocationText(list, options));



            //text

            if (options.DisplayItemSliceAndTotal)

                listItemLinks.Add(ItemSliceAndTotalText(list, options));



            //page

            if (options.DisplayLinkToIndividualPages)

            {

                //if there are previous page numbers not displayed, show an ellipsis

                if (options.DisplayEllipsesWhenNotShowingAllPageNumbers && firstPageToDisplay > 1)

                    listItemLinks.Add(Ellipses(options));



                foreach (var i in Enumerable.Range(firstPageToDisplay, pageNumbersToDisplay))

                {

                    //show delimiter between page numbers

                    if (i > firstPageToDisplay && !string.IsNullOrWhiteSpace(options.DelimiterBetweenPageNumbers))

                        listItemLinks.Add(WrapInListItem(options.DelimiterBetweenPageNumbers));



                    //show page number link

                    listItemLinks.Add(Page(i, list, generatePageUrl, options));

                }



                //if there are subsequent page numbers not displayed, show an ellipsis

                if (options.DisplayEllipsesWhenNotShowingAllPageNumbers && (firstPageToDisplay + pageNumbersToDisplay - 1) < list.PageCount)

                    listItemLinks.Add(Ellipses(options));

            }



            //next

            if (options.DisplayLinkToNextPage == PagedListDisplayMode.Always || (options.DisplayLinkToNextPage == PagedListDisplayMode.IfNeeded && !list.IsLastPage))

                listItemLinks.Add(Next(list, generatePageUrl, options));



            //last

            if (options.DisplayLinkToLastPage == PagedListDisplayMode.Always || (options.DisplayLinkToLastPage == PagedListDisplayMode.IfNeeded && lastPageToDisplay < list.PageCount))

                listItemLinks.Add(Last(list, generatePageUrl, options));



            if (listItemLinks.Any())

            {

                //append class to first item in list?

                if (!string.IsNullOrWhiteSpace(options.ClassToApplyToFirstListItemInPager))

                    listItemLinks.First().AddCssClass(options.ClassToApplyToFirstListItemInPager);



                //append class to last item in list?

                if (!string.IsNullOrWhiteSpace(options.ClassToApplyToLastListItemInPager))

                    listItemLinks.Last().AddCssClass(options.ClassToApplyToLastListItemInPager);



                //append classes to all list item links

                foreach (var li in listItemLinks)

                    foreach (var c in options.LiElementClasses ?? Enumerable.Empty<string>())

                        li.AddCssClass(c);

            }



            //collapse all of the list items into one big string

            var listItemLinksString = listItemLinks.Aggregate(

                new StringBuilder(),

                (sb, listItem) => sb.Append(listItem.ToString()),

                sb => sb.ToString()

                );



            var ul = new TagBuilder("ul")

            {

                InnerHtml = listItemLinksString

            };

            foreach (var c in options.UlElementClasses ?? Enumerable.Empty<string>())

                ul.AddCssClass(c);



            var outerDiv = new TagBuilder("div");

            foreach (var c in options.ContainerDivClasses ?? Enumerable.Empty<string>())

                outerDiv.AddCssClass(c);

            outerDiv.InnerHtml = ul.ToString();



            return new MvcHtmlString(outerDiv.ToString());

        }


                
        public static MvcHtmlString PagedListGoToPageForm(this System.Web.Mvc.HtmlHelper html,

                                                          IPagedList list,

                                                          string formAction)

        {

            return PagedListGoToPageForm(html, list, formAction, "page");

        }



        
        public static MvcHtmlString PagedListGoToPageForm(this System.Web.Mvc.HtmlHelper html,

                                                          IPagedList list,

                                                          string formAction,

                                                          string inputFieldName)

        {

            return PagedListGoToPageForm(html, list, formAction, new GoToFormRenderOptions(inputFieldName));

        }


            

        public static MvcHtmlString PagedListGoToPageForm(this System.Web.Mvc.HtmlHelper html,

                                                 IPagedList list,

                                                 string formAction,

                                                 GoToFormRenderOptions options)

        {

            var form = new TagBuilder("form");

            form.AddCssClass("PagedList-goToPage");

            form.Attributes.Add("action", formAction);

            form.Attributes.Add("method", "get");



            var fieldset = new TagBuilder("fieldset");



            var label = new TagBuilder("label");

            label.Attributes.Add("for", options.InputFieldName);

            label.SetInnerText(options.LabelFormat);



            var input = new TagBuilder("input");

            input.Attributes.Add("type", options.InputFieldType);

            input.Attributes.Add("name", options.InputFieldName);

            input.Attributes.Add("value", list.PageNumber.ToString());



            var submit = new TagBuilder("input");

            submit.Attributes.Add("type", "submit");

            submit.Attributes.Add("value", options.SubmitButtonFormat);



            fieldset.InnerHtml = label.ToString();

            fieldset.InnerHtml += input.ToString(TagRenderMode.SelfClosing);

            fieldset.InnerHtml += submit.ToString(TagRenderMode.SelfClosing);

            form.InnerHtml = fieldset.ToString();

            return new MvcHtmlString(form.ToString());

        }



    }

}