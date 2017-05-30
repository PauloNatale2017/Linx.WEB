using IdentityServer3.Core.Models;
using Linx.Domain.Mapping.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Mapping.EntityViewModel
{
    public class ClientViewModel
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual bool Enabled { get; set; }

        [Required]
        [StringLength(200)]
        [Index(IsUnique = true)]
        public virtual string ClientId { get; set; }

        //public virtual ICollection<ClientSecret> ClientSecrets { get; set; }

        [Required]
        [StringLength(200)]
        public virtual string ClientName { get; set; }
        [StringLength(2000)]
        public virtual string ClientUri { get; set; }
        public virtual string LogoUri { get; set; }

        public virtual bool RequireConsent { get; set; }
        public virtual bool AllowRememberConsent { get; set; }
        public virtual bool AllowAccessTokensViaBrowser { get; set; }

        //public virtual Flows Flow { get; set; }
        public virtual bool AllowClientCredentialsOnly { get; set; }

        //public virtual ICollection<ClientRedirectUri> RedirectUris { get; set; }
        //public virtual ICollection<ClientPostLogoutRedirectUri> PostLogoutRedirectUris { get; set; }

        public virtual string LogoutUri { get; set; }
        public virtual bool LogoutSessionRequired { get; set; }
        public virtual bool RequireSignOutPrompt { get; set; }

        public virtual bool AllowAccessToAllScopes { get; set; }
        //public virtual ICollection<ClientScope> AllowedScopes { get; set; }

        // in seconds
        [Range(0, Int32.MaxValue)]
        public virtual int IdentityTokenLifetime { get; set; }
        [Range(0, Int32.MaxValue)]
        public virtual int AccessTokenLifetime { get; set; }
        [Range(0, Int32.MaxValue)]
        public virtual int AuthorizationCodeLifetime { get; set; }

        [Range(0, Int32.MaxValue)]
        public virtual int AbsoluteRefreshTokenLifetime { get; set; }
        [Range(0, Int32.MaxValue)]
        public virtual int SlidingRefreshTokenLifetime { get; set; }

        //public virtual TokenUsage RefreshTokenUsage { get; set; }
        public virtual bool UpdateAccessTokenOnRefresh { get; set; }

        //public virtual TokenExpiration RefreshTokenExpiration { get; set; }

        //public virtual AccessTokenType AccessTokenType { get; set; }

        public virtual bool EnableLocalLogin { get; set; }
        //public virtual ICollection<ClientIdPRestriction> IdentityProviderRestrictions { get; set; }

        public virtual bool IncludeJwtId { get; set; }

        //public virtual ICollection<ClientClaim> Claims { get; set; }
        public virtual bool AlwaysSendClientClaims { get; set; }
        public virtual bool PrefixClientClaims { get; set; }

        public virtual bool AllowAccessToAllGrantTypes { get; set; }

        //public virtual ICollection<ClientCustomGrantType> AllowedCustomGrantTypes { get; set; }
        //public virtual ICollection<ClientCorsOrigin> AllowedCorsOrigins { get; set; }

        //[Key]
        //public int Id { get; set; }
        //public bool Enabled { get; set; }
        //public string ClientId { get; set; }
        //[Required]
        //public string ClientName { get; set; }
        //[Required]
        //public string ClientUri { get; set; }
        //[Required]
        //public string LogoUri { get; set; }
        //[Required]
        //public bool RequireConsent { get; set; }
        //public bool AllowRememberConsent { get; set; }
        //public bool AllowAccessTokensViaBrowser { get; set; }
        //public int Flow { get; set; }
        //public int AllowClientCredentialsOnly { get; set; }
        //[Required]
        //public string LogoutUri { get; set; }
        //public int LogoutSessionRequired { get; set; }
        //public int RequireSignOutPrompt { get; set; }
        //public int AllowAccessToAllScopes { get; set; }
        //public int IdentityTokenLifetime { get; set; }
        //public int AccessTokenLifetime { get; set; }
        //public int AuthorizationCodeLifetime { get; set; }
        //public int AbsoluteRefreshTokenLifetime { get; set; }
        //public int SlidingRefreshTokenLifetime { get; set; }
        //public int RefreshTokenUsage { get; set; }
        //public int UpdateAccessTokenOnRefresh { get; set; }
        //public int RefreshTokenExpiration { get; set; }
        //public int AccessTokenType { get; set; }
        //public int EnableLocalLogin { get; set; }
        //public int IncludeJwtId { get; set; }
        //public int AlwaysSendClientClaims { get; set; }
        //public int PrefixClientClaims { get; set; }
        //public int AllowAccessToAllGrantTypes { get; set; }
    }
}
