using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace CodeChallange.Core.Extensions
{
    public class Extensions
    {
        public static string GetAllParameters(Exception ex, IInvocation args)
        {
            var requestParameters = args.Arguments.Length > 0 ? args.Arguments[0] : string.Empty;

            return string.Format("Trace Service Exception : {0} in {1}.{2} invoked with arguments {3}",
                 ex.GetType().Name,
                 args.Method.DeclaringType.FullName,
                 args.Method.Name,
                 JsonConvert.SerializeObject(requestParameters));
        }
    }
}
