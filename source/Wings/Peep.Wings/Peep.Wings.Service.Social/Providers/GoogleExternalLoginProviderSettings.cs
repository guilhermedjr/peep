using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peep.Wings.Service.Social.Providers
{
    public class GoogleExternalLoginProviderSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UserInfoEndpoint { get; set; }
    }
}
