﻿/*
 * Copyright 2014 Dominick Baier, Brock Allen
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Owin;
using System;
using System.Web.Http;

namespace IdentityManager.Configuration
{
    public abstract class SecurityConfiguration
    {
        public string AdminRoleName { get; set; }
        public string HostAuthenticationType { get; set; }

        internal SecurityConfiguration()
        {
            AdminRoleName = Constants.AdminRoleName;
        }

        internal virtual void Validate()
        {
            if (String.IsNullOrWhiteSpace(AdminRoleName))
            {
                throw new Exception("AdminRoleName is required.");
            }
            if (String.IsNullOrWhiteSpace(HostAuthenticationType))
            {
                throw new Exception("HostAuthenticationType is required.");
            }
        }

        public abstract void Configure(IAppBuilder app);
        public virtual void Configure(HttpConfiguration config)
        {
        }
    }
}
