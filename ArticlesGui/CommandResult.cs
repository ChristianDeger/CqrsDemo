using System.Web.Mvc;

namespace ArticlesGui
{
    public static class CommandResult
    {
        public static JsonResult Success
        {
            get
            {
                return new JsonResult();
            }
        }

        public static JsonResult Error(string message)
        {
            return new JsonResult{ Data = new { error = message }};
        }
    }
}