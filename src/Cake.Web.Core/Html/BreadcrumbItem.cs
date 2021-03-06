﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Cake.Web.Core.Html
{
    public class BreadcrumbItem : IBreadcrumbItem
    {
        public IHtmlString Text { get; }
        public Uri Uri { get; }

        public BreadcrumbItem(IHtmlString text)
            : this(text, null)
        {
        }

        public BreadcrumbItem(string text)
            : this(MvcHtmlString.Create(text), null)
        {
        }

        public BreadcrumbItem(string text, Uri uri)
            : this(MvcHtmlString.Create(text), uri)
        {
        }

        public BreadcrumbItem(IHtmlString text, Uri uri)
        {
            Text = text;
            Uri = uri;
        }

        public void Append(IBreadcrumbItem item)
        {
        }

        public void Render(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Li);
            {
                if (Uri == null)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.B);
                    writer.Write(Text);
                    writer.RenderEndTag();
                }
                else
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, Uri.OriginalString);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(Text);
                    writer.RenderEndTag();
                }
            }
            writer.RenderEndTag();
        }
    }
}
