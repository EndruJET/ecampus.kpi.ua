﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using NLog;

namespace Core
{
    public class SitePage : Page
    {
        private CampusClient _campusClient;

        public CampusClient CampusClient
        {
            get { return _campusClient ?? (_campusClient = new CampusClient()); }
        }

        public Dictionary<string, Permission> Permissions
        {
            get
            {
                if (Session["UserPremissions"] == null)
                {
                    Session["UserPremissions"] = new Dictionary<string, Permission>();
                }

                return Session["UserPremissions"] as Dictionary<string, Permission>;
            }
            set
            {
                Session["UserPremissions"] = value;
            }
        }

        public Campus.Common.User CurrentUser
        {
            get
            {
                var user = Session["current-user"] as Campus.Common.User;

                if (user == null)
                {
                    user = CampusClient.GetUser(SessionId);
                    Session["current-user"] = user;
                }

                return user;
            }
        }

        public String SessionId
        {
            get { return Session["UserData"] == null ? null : Session["UserData"].ToString(); }
            set { Session["UserData"] = value; }
        }

        public String UserLogin
        {
            get { return Session["UserLogin"] == null ? null : Session["UserLogin"].ToString(); }
            set { Session["UserLogin"] = value; }
        }

        public String UserPassword
        {
            get { return Session["UserPassword"] == null ? null : Session["UserPassword"].ToString(); }
            set { Session["UserPassword"] = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (String.IsNullOrEmpty(SessionId) || !Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/login");
            }
        }

    }
}
