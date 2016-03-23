using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVC.Helper
{
    public static class PhoneControlHelper
    {
        public static MvcHtmlString MyTextBoxFor<TModel, TProperty>(
             this HtmlHelper<TModel> helper,
             Expression<Func<TModel, TProperty>> expression)
        {
            return helper.TextBoxFor(expression, new { @class = "phonecontrol" });
        }
    }
}