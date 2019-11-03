using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LithologyLog.Web.Helper
{
    /// <summary>
    /// Provides programmatic configuration for DataAnnotations localization in the MVC framework.
    /// </summary>
    public class MvcDataAnnotationsLocalizationOptions
    {
        /// <summary>
        /// The delegate to invoke for creating <see cref="IStringLocalizer"/>.
        /// </summary>
        public Func<Type, IStringLocalizerFactory, IStringLocalizer> DataAnnotationLocalizerProvider;
    }
}
