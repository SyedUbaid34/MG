using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.ServiceReference1;

namespace Test
{
    public partial class MsgTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = string.Empty;
                SendSaleSMS sendTestingSMS = new SendSaleSMS();
                sendTestingSMS.Recipients = txtRecipients.Text.Trim();
                sendTestingSMS.MessageCode = txtMessageCode.Text.Trim();
                sendTestingSMS.MessageType = rbnEnglish.Checked ? "N" : "U";
                sendTestingSMS.Firstname = txtEmailReference.Text.Trim();
                sendTestingSMS.ApplicationNum = txtAccountNumber.Text.Trim();
                sendTestingSMS.Gender = "ميرا";
                string strResult = string.Empty;
                IijaraMessagingGatewayClient Testing = new IijaraMessagingGatewayClient();
                Testing.Open();
                strResult = Testing.SendSaleSMS(sendTestingSMS);
                Testing.Close();

                lblStatus.Text = strResult;
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblStatus.Text = "Error in sending SMS: " + ex.Message.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }


        }

        // IjarahSADADGateway.IJARAHSADAD
        public string ConvertTextTohex(string message)
        {
            string text = "";
            for (int i = 0; i < message.Length; i++)
            {
                char c = message[i];
                int num = (int)c;
                string str = num.ToString("X4");
                text += str;
            }
            return text;
        }



        protected void btnSendEmail_Click(object sender, EventArgs e)
        {


            try
            {
                lblStatus.Text = string.Empty;
                SendSaleEmail sendTestingEmail = new SendSaleEmail();
                //SendSREmail sendTestingEmail = new SendSREmail();
                //SendMail sendTestingEmail = new SendMail();
                //SendMail
                sendTestingEmail.RecipientsTo = txtRecipientsTo.Text.Trim();
                sendTestingEmail.RecipientsCc = txtRecipientCc.Text.Trim();
                sendTestingEmail.EmailReference = "1-8KRSS3";
                sendTestingEmail.Firstname = txtEmailReference.Text.Trim();
                //sendTestingEmail.SadadReferenceNumber = txtAccountNumber.Text.Trim();
                //sendTestingEmail.AccountNumber = txtAccountNumber.Text.Trim();
                sendTestingEmail.ApplicationNum = txtAccountNumber.Text.Trim();
                sendTestingEmail.Totalamount = txtAmount.Text.Trim();
                //sendTestingEmail.Amount = txtAmount.Text.Trim();
                //sendTestingEmail.SubCategory = txtEmailReference.Text.Trim();
                //sendTestingEmail.Category = txtEmailReference.Text.Trim();
                //sendTestingEmail.DueDate = DateTime.Now.ToString("dd-MM-yyyy");
                sendTestingEmail.MessageCode = txtMessageCode.Text.Trim();
                sendTestingEmail.Gender = "ميرا";
                sendTestingEmail.MessageType = rbnEnglish.Checked ? "N" : "U";
                sendTestingEmail.PartnerCode = "IJARAH";

                IijaraMessagingGatewayClient Testing = new IijaraMessagingGatewayClient();
                Testing.Open();
                //Testing.SendEMail(sendTestingEmail);
                //Testing.SendSREmail(sendTestingEmail);
                Testing.SendSaleEmail(sendTestingEmail);
                Testing.Close();

                lblStatus.Text = "Mail send Successfuly";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblStatus.Text = "Error in sending email: " + ex.Message.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}