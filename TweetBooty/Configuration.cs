//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TweetBooty
{
    using System;
    using System.Collections.Generic;
    
    public partial class Configuration
    {
        public int id { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public int Minutes { get; set; }
        public int RTCount { get; set; }
        public int TweetLimit { get; set; }
        public int FavLimit { get; set; }
        public int FollowLimit { get; set; }
        public int ImageCounter { get; set; }
        public int FavCounter { get; set; }
        public int FollowCounter { get; set; }
        public int TweetCounter { get; set; }
        public string AccountName { get; set; }
        public Nullable<System.DateTime> LastUse { get; set; }
    }
}
