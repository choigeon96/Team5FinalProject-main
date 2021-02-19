using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Mvc.DAC
{
    public class EmailSettings
    {
        public static string ServerName = "smtp.gmail.com";
        public static int ServerPort = 587;
        public static bool UseSsl = true;
        public static string UserName = "ihlee@anyform.co.kr";
        public static string Password = "1234567";
        public static string MailFromAddress = "danawa@gudi.co.kr";
    }

    public class EmailProcessor
    {
        public void ProcessorOrder(ShipInfo ship, Cart cart)
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = EmailSettings.UseSsl;
                client.Host = EmailSettings.ServerName;
                client.Port = EmailSettings.ServerPort;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(EmailSettings.UserName, EmailSettings.Password);

                //메일 본문을 작성
                /*
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("신규 주문 처리가 완료되었습니다.");
                sb.AppendLine("------------------------------");
                sb.AppendLine("Items :");

                foreach(CartLine line in cart.Lines)
                {
                    sb.AppendFormat("        - {0} * {1} (subtotal:{2:c}", line.Product.Name, line.Qty, line.Product.Price * line.Qty);
                    sb.AppendLine();
                }
                sb.AppendLine("------------------------------");
                sb.AppendLine($"Total 주문금액 : {cart.CalcTotalValue().ToString("c")}");

                sb.AppendLine("------------------------------");
                sb.AppendLine("배송지 정보");
                sb.AppendLine(ship.Name);
                sb.AppendLine(ship.Addr1);
                sb.AppendLine(ship.Addr2 ?? "");
                sb.AppendLine(ship.Email ?? "");
                sb.AppendLine(ship.Message ?? "");
                sb.AppendLine("------------------------------");
                */
                //물리적인 전체경로를 적용
                string path = ConfigurationManager.AppSettings["html"];
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                string tempStr = sr.ReadToEnd();
                tempStr = tempStr.Replace("$업체명", ship.Name);
                tempStr = tempStr.Replace("$이메일", ship.Email);
                tempStr = tempStr.Replace("$주소", ship.Addr1);

                MailMessage mail = new MailMessage(EmailSettings.MailFromAddress, "inhee73@hanmail.net");
                mail.Subject = "신규 주문 완료";
                //mail.Body = sb.ToString();
                mail.Body = tempStr;
                mail.IsBodyHtml = true;
                client.Send(mail);
            }
        }
    }
}