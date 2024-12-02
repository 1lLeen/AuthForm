using AuthForm.Application.EmailHelper;
using AuthForm.Infrastucture.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Application.EmailHelper
{
    public class EmailSendler
    {
        public static async Task SendConfirmationEmail(UserModel user)
        {
            MailAddress from = new MailAddress("***********", "**********");
            MailAddress to = new MailAddress(user.Email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Регистрация";
            m.Body = $"{user.EmailCode}";
            m.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("************", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("******************", "**************");

            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }

        internal static async Task SendResetPasswordEmail(UserModel user)
        {
            MailAddress from = new MailAddress("(******************", "******************");
            MailAddress to = new MailAddress(user.Email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Сброс пароля в ITPControl";
            m.Body = $"{user.EmailCode}";
            m.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("***********", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("*********************", "******************");

            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }

    }
}