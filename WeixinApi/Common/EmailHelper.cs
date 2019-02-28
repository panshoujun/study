using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Common
{
    public class EmailHelper
    {
        private volatile static SmtpClient _instance = null;
        private static readonly object lockHelper = new object();

        #region
        ///// <summary>
        ///// 创建发邮件对象(其他)
        ///// </summary>
        ///// <returns></returns>
        //protected static SmtpClient SmtpClientBuilder()
        //{
        //    SmtpClient smtp = new SmtpClient()
        //    {
        //        DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
        //        Host = EmailConfig.SmtpServerAddress,
        //        UseDefaultCredentials = true,
        //        Credentials = new System.Net.NetworkCredential(EmailConfig.SmtpServerUserName, EmailConfig.SmtpServerPassword)
        //    };

        //    return smtp;
        //}

        /// <summary>
        /// 创建发邮件对象(qq 1设置-账户下设置的-STMP(要开通权限) 2密码是授权码)
        /// </summary>
        /// <returns></returns>
        protected static SmtpClient SmtpClientBuilder()
        {
            SmtpClient smtp = new SmtpClient()
            {
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Host = EmailConfig.SmtpServerAddress,
                EnableSsl = true,
                UseDefaultCredentials = false,
                //UseDefaultCredentials = true,
                Credentials = new System.Net.NetworkCredential(EmailConfig.SmtpServerUserName, EmailConfig.SmtpServerPassword)
            };

            return smtp;
        }
        #endregion

        /// <summary>
        /// 获取发邮件对象（单利模式 线程安全）
        /// </summary>
        /// <returns></returns>
        public static SmtpClient GetSmtpClientInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = SmtpClientBuilder();
                }
            }
            return _instance;
        }

        /// <summary>
        /// 创建电子邮件信息类
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="toAddress">收件地址</param>
        /// <param name="isHtml">是否是html</param>
        /// <returns></returns>
        public static MailMessage MailMessageBuilder(string subject, string body, string[] toAddress, bool isHtml = true)
        {

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage
            {
                From = new System.Net.Mail.MailAddress(EmailConfig.FromAddress),
                Subject = subject,
                Body = body,
                 
                IsBodyHtml = isHtml,
                Priority = System.Net.Mail.MailPriority.High
            };
            //delegate(string e)
            toAddress.ToList<string>().ForEach(e=>
            {
                message.To.Add(e);
            });
            return message;
        }

        /// <summary>
        /// 创建电子邮件信息类
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="toAddress">收件地址</param>
        /// <param name="isHtml">是否是html</param>
        /// <returns></returns>
        public static MailMessage MailMessageBuilder(string subject, string body, string toAddress, bool isHtml = true)
        {
            return MailMessageBuilder(subject, body, new string[] { toAddress }, isHtml);
        }

        /// <summary>
        /// 发邮件(异步)
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="toAddress">收件地址</param>
        /// <param name="isHtml">是否是html</param>
        public static void SendMailAsync(string subject, string body, string toAddress, bool isHtml = true)
        {
            try
            {
                SendMailAsync(subject, body, new string[] { toAddress }, isHtml);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 发邮件(异步)
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="toAddress">收件地址</param>
        /// <param name="isHtml">是否是html</param>
        public static void SendMailAsync(string subject, string body, string[] toAddress, bool isHtml = true)
        {
            try
            {
                //(string smtpserver, string userName, string pwd, string strfrom, string strto, string subj, string bodys, bool isHtml = true)
                //new System.Net.Mail.SmtpClient
                //{
                //    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                //    Host = smtpserver,
                //    UseDefaultCredentials = true,
                //    Credentials = new System.Net.NetworkCredential(userName, pwd)
                //}.SendAsync(new System.Net.Mail.MailMessage(strfrom, strto)
                //{
                //    Subject = subj,
                //    Body = bodys,
                //    BodyEncoding = System.Text.Encoding.Default,
                //    IsBodyHtml = isHtml,
                //    Priority = System.Net.Mail.MailPriority.High
                //}, null);

                GetSmtpClientInstance().SendAsync(MailMessageBuilder(subject, body, toAddress, isHtml), null);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 发邮件(同步)
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="toAddress">收件地址</param>
        /// <param name="isHtml">是否是html</param>
        public static void SendMail(string subject, string body, string toAddress, bool isHtml = true)
        {
            try
            {
                SendMail(subject, body, new string[] { toAddress }, isHtml);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 发邮件(同步)
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="toAddress">收件地址</param>
        /// <param name="isHtml">是否是html</param>
        public static void SendMail(string subject, string body, string[] toAddress, bool isHtml = true)
        {
            try
            {
                GetSmtpClientInstance().Send(MailMessageBuilder(subject, body, toAddress, isHtml));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    /// <summary>
    /// 发件箱服务器配置
    /// </summary>
    public sealed class EmailConfig
    {
        private static readonly string _smtpServerAddress = null;

        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        public static string SmtpServerAddress
        {
            get { return _smtpServerAddress; }
        }


        private static readonly string _smtpServerUserName = null;

        /// <summary>
        /// 发件箱地址（账号）
        /// </summary>
        public static string SmtpServerUserName
        {
            get { return _smtpServerUserName; }
        }


        private static readonly string _smtpServerPassword = null;

        /// <summary>
        /// 发件箱密码
        /// </summary>
        public static string SmtpServerPassword
        {
            get { return _smtpServerPassword; }
        }


        private static readonly int _port = 25;


        /// <summary>
        /// SMTP 主机上的端口号。默认值为 25。
        /// </summary>
        public static int Port
        {
            get { return _port; }
        }

        /// <summary>
        /// 发件箱地址（账号）
        /// </summary>
        private static readonly string _fromAddress = null;

        public static string FromAddress
        {
            get { return _fromAddress; }
        }


        private static readonly string _templateFilePath = null;

        static EmailConfig()
        {
            _smtpServerAddress = ConfigurationManager.AppSettings["stmpServer"];
            _smtpServerUserName = ConfigurationManager.AppSettings["UserName"];
            _smtpServerPassword = ConfigurationManager.AppSettings["Password"];
            _fromAddress = ConfigurationManager.AppSettings["FromAddress"];
        }
    }


}
