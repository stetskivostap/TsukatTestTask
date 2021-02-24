using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Helpers
{
    public class TokenManagement
    {
        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int AccessLifetimeMinutes { get; set; }

        public string Salt { get; set; }
    }
}
