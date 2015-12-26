namespace System.Web.Mvc
{
    using Collections.Generic;
    using WebPages;
    using Text;

    public static class HtmlHelperExtensions
    {
        private const string _jSViewDataName = "RenderJavaScriptUrl";
        private const string _js = "RenderJavaScript";
        #region Script Url
        public static void AddJavaScriptUrl(this HtmlHelper htmlHelper, string scriptURL)
        {
            List<string> scriptList = htmlHelper.ViewContext.HttpContext
              .Items[_jSViewDataName] as List<string>;
            if (scriptList != null)
            {
                if (!scriptList.Contains(scriptURL))
                {
                    scriptList.Add(scriptURL);
                }
            }
            else
            {
                scriptList = new List<string>();
                scriptList.Add(scriptURL);
                htmlHelper.ViewContext.HttpContext
                  .Items.Add(_jSViewDataName, scriptList);
            }
        }
        public static MvcHtmlString RenderJavaScriptsUrl(this HtmlHelper HtmlHelper)
        {
            StringBuilder result = new StringBuilder();

            List<string> scriptList = HtmlHelper.ViewContext.HttpContext
              .Items[_jSViewDataName] as List<string>;
            if (scriptList != null)
            {
                foreach (string script in scriptList)
                {
                    result.AppendLine(string.Format(
                      "<script type=\"text/javascript\" src=\"{0}\"></script>",
                      script));
                }
            }

            return MvcHtmlString.Create(result.ToString());
        }

        #endregion
        #region Script
        public static void AddJavaScript(this HtmlHelper htmlHelper, Func<object, HelperResult> script)
        {
            List<string> scriptList = htmlHelper.ViewContext.HttpContext.Items[_js] as List<string>;
            if (scriptList != null)
            {
                if (!scriptList.Contains(script.ToString()))
                {
                    scriptList.Add(script.Invoke(null).ToString());
                }
            }
            else
            {
                scriptList = new List<string>();
                scriptList.Add(script.Invoke(null).ToString());
                htmlHelper.ViewContext.HttpContext.Items.Add(_js, scriptList);
            }
        }
        public static MvcHtmlString RenderJavaScripts(this HtmlHelper HtmlHelper)
        {
            StringBuilder result = new StringBuilder();

            List<string> scriptList = HtmlHelper.ViewContext.HttpContext.Items[_js] as List<string>;
            if (scriptList != null)
            {
                foreach (string itemScript in scriptList)
                {
                    result.AppendLine(itemScript);
                }
            }
            return MvcHtmlString.Create(result.ToString());
        }
        #endregion
    }
}