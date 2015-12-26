﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace LukeDucaSEAssignment2Sit1.MyService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IServiceController", Namespace="http://tempuri.org/")]
    public partial class ServiceController : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback DoWorkOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoginOperationCompleted;
        
        private System.Threading.SendOrPostCallback RegisterOperationCompleted;
        
        private System.Threading.SendOrPostCallback SubmitNewArticleOperationCompleted;
        
        private System.Threading.SendOrPostCallback AcceptOrRejectArticleByReviewerOperationCompleted;
        
        private System.Threading.SendOrPostCallback AcceptOrRejectArticleByMediaManagerOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServiceController() {
            this.Url = global::LukeDucaSEAssignment2Sit1.Properties.Settings.Default.LukeDucaSEAssignment2Sit1_MyService_ServiceController;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event DoWorkCompletedEventHandler DoWorkCompleted;
        
        /// <remarks/>
        public event LoginCompletedEventHandler LoginCompleted;
        
        /// <remarks/>
        public event RegisterCompletedEventHandler RegisterCompleted;
        
        /// <remarks/>
        public event SubmitNewArticleCompletedEventHandler SubmitNewArticleCompleted;
        
        /// <remarks/>
        public event AcceptOrRejectArticleByReviewerCompletedEventHandler AcceptOrRejectArticleByReviewerCompleted;
        
        /// <remarks/>
        public event AcceptOrRejectArticleByMediaManagerCompletedEventHandler AcceptOrRejectArticleByMediaManagerCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceController/DoWork", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DoWork() {
            this.Invoke("DoWork", new object[0]);
        }
        
        /// <remarks/>
        public void DoWorkAsync() {
            this.DoWorkAsync(null);
        }
        
        /// <remarks/>
        public void DoWorkAsync(object userState) {
            if ((this.DoWorkOperationCompleted == null)) {
                this.DoWorkOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDoWorkOperationCompleted);
            }
            this.InvokeAsync("DoWork", new object[0], this.DoWorkOperationCompleted, userState);
        }
        
        private void OnDoWorkOperationCompleted(object arg) {
            if ((this.DoWorkCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DoWorkCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceController/Login", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Login(string uname, string pass) {
            object[] results = this.Invoke("Login", new object[] {
                        uname,
                        pass});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LoginAsync(string uname, string pass) {
            this.LoginAsync(uname, pass, null);
        }
        
        /// <remarks/>
        public void LoginAsync(string uname, string pass, object userState) {
            if ((this.LoginOperationCompleted == null)) {
                this.LoginOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoginOperationCompleted);
            }
            this.InvokeAsync("Login", new object[] {
                        uname,
                        pass}, this.LoginOperationCompleted, userState);
        }
        
        private void OnLoginOperationCompleted(object arg) {
            if ((this.LoginCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoginCompleted(this, new LoginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceController/Register", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Register(string firstName, string lastName, string username, string password, int roleId) {
            object[] results = this.Invoke("Register", new object[] {
                        firstName,
                        lastName,
                        username,
                        password,
                        roleId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterAsync(string firstName, string lastName, string username, string password, int roleId) {
            this.RegisterAsync(firstName, lastName, username, password, roleId, null);
        }
        
        /// <remarks/>
        public void RegisterAsync(string firstName, string lastName, string username, string password, int roleId, object userState) {
            if ((this.RegisterOperationCompleted == null)) {
                this.RegisterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterOperationCompleted);
            }
            this.InvokeAsync("Register", new object[] {
                        firstName,
                        lastName,
                        username,
                        password,
                        roleId}, this.RegisterOperationCompleted, userState);
        }
        
        private void OnRegisterOperationCompleted(object arg) {
            if ((this.RegisterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterCompleted(this, new RegisterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceController/SubmitNewArticle", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SubmitNewArticle(string articleName, string articleDescription, System.DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId) {
            this.Invoke("SubmitNewArticle", new object[] {
                        articleName,
                        articleDescription,
                        dateOfPublish,
                        userId,
                        mediaManagerId,
                        articleStatusId,
                        articleStateId,
                        articleCommentId});
        }
        
        /// <remarks/>
        public void SubmitNewArticleAsync(string articleName, string articleDescription, System.DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId) {
            this.SubmitNewArticleAsync(articleName, articleDescription, dateOfPublish, userId, mediaManagerId, articleStatusId, articleStateId, articleCommentId, null);
        }
        
        /// <remarks/>
        public void SubmitNewArticleAsync(string articleName, string articleDescription, System.DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId, object userState) {
            if ((this.SubmitNewArticleOperationCompleted == null)) {
                this.SubmitNewArticleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSubmitNewArticleOperationCompleted);
            }
            this.InvokeAsync("SubmitNewArticle", new object[] {
                        articleName,
                        articleDescription,
                        dateOfPublish,
                        userId,
                        mediaManagerId,
                        articleStatusId,
                        articleStateId,
                        articleCommentId}, this.SubmitNewArticleOperationCompleted, userState);
        }
        
        private void OnSubmitNewArticleOperationCompleted(object arg) {
            if ((this.SubmitNewArticleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SubmitNewArticleCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceController/AcceptOrRejectArticleByReviewer", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AcceptOrRejectArticleByReviewer(int artId, string articleName, string articleDescription, System.DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId) {
            this.Invoke("AcceptOrRejectArticleByReviewer", new object[] {
                        artId,
                        articleName,
                        articleDescription,
                        dateOfPublish,
                        userId,
                        mediaManagerId,
                        articleStatusId,
                        articleStateId,
                        commentContent,
                        articleCommentId});
        }
        
        /// <remarks/>
        public void AcceptOrRejectArticleByReviewerAsync(int artId, string articleName, string articleDescription, System.DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId) {
            this.AcceptOrRejectArticleByReviewerAsync(artId, articleName, articleDescription, dateOfPublish, userId, mediaManagerId, articleStatusId, articleStateId, commentContent, articleCommentId, null);
        }
        
        /// <remarks/>
        public void AcceptOrRejectArticleByReviewerAsync(int artId, string articleName, string articleDescription, System.DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId, object userState) {
            if ((this.AcceptOrRejectArticleByReviewerOperationCompleted == null)) {
                this.AcceptOrRejectArticleByReviewerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAcceptOrRejectArticleByReviewerOperationCompleted);
            }
            this.InvokeAsync("AcceptOrRejectArticleByReviewer", new object[] {
                        artId,
                        articleName,
                        articleDescription,
                        dateOfPublish,
                        userId,
                        mediaManagerId,
                        articleStatusId,
                        articleStateId,
                        commentContent,
                        articleCommentId}, this.AcceptOrRejectArticleByReviewerOperationCompleted, userState);
        }
        
        private void OnAcceptOrRejectArticleByReviewerOperationCompleted(object arg) {
            if ((this.AcceptOrRejectArticleByReviewerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AcceptOrRejectArticleByReviewerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IServiceController/AcceptOrRejectArticleByMediaManager", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AcceptOrRejectArticleByMediaManager(int artId, string articleName, string articleDescription, System.DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId) {
            this.Invoke("AcceptOrRejectArticleByMediaManager", new object[] {
                        artId,
                        articleName,
                        articleDescription,
                        dateOfPublish,
                        userId,
                        mediaManagerId,
                        articleStatusId,
                        articleStateId,
                        commentContent,
                        articleCommentId});
        }
        
        /// <remarks/>
        public void AcceptOrRejectArticleByMediaManagerAsync(int artId, string articleName, string articleDescription, System.DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId) {
            this.AcceptOrRejectArticleByMediaManagerAsync(artId, articleName, articleDescription, dateOfPublish, userId, mediaManagerId, articleStatusId, articleStateId, commentContent, articleCommentId, null);
        }
        
        /// <remarks/>
        public void AcceptOrRejectArticleByMediaManagerAsync(int artId, string articleName, string articleDescription, System.DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId, object userState) {
            if ((this.AcceptOrRejectArticleByMediaManagerOperationCompleted == null)) {
                this.AcceptOrRejectArticleByMediaManagerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAcceptOrRejectArticleByMediaManagerOperationCompleted);
            }
            this.InvokeAsync("AcceptOrRejectArticleByMediaManager", new object[] {
                        artId,
                        articleName,
                        articleDescription,
                        dateOfPublish,
                        userId,
                        mediaManagerId,
                        articleStatusId,
                        articleStateId,
                        commentContent,
                        articleCommentId}, this.AcceptOrRejectArticleByMediaManagerOperationCompleted, userState);
        }
        
        private void OnAcceptOrRejectArticleByMediaManagerOperationCompleted(object arg) {
            if ((this.AcceptOrRejectArticleByMediaManagerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AcceptOrRejectArticleByMediaManagerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void DoWorkCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void LoginCompletedEventHandler(object sender, LoginCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void RegisterCompletedEventHandler(object sender, RegisterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void SubmitNewArticleCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void AcceptOrRejectArticleByReviewerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void AcceptOrRejectArticleByMediaManagerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591