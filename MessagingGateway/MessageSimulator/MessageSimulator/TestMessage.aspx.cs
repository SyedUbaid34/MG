using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessageSimulator.ServiceReference1;

namespace MessageSimulator
{
    public partial class TestMessage : System.Web.UI.Page
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
                //SendSRSms sendTestingSMS = new SendSRSms();
                sendTestingSMS.Recipients = txtRecipients.Text.Trim();
                sendTestingSMS.MessageCode = txtMessageCode.Text.Trim();
                sendTestingSMS.MessageType = rbnEnglish.Checked ? "N" : "U";
                sendTestingSMS.CustomMessage = txtCustomMessage.Text;
                //sendTestingSMS.SadadReferenceNumber = txtAccountNumber.Text.Trim();
                sendTestingSMS.VirtualAccntNum = txtAccountNumber.Text.Trim();
                //sendTestingSMS.Firstname = txtEmailReference.Text.Trim();
                //sendTestingSMS.ApplicationNum = txtAccountNumber.Text.Trim();
                //sendTestingSMS.Gender = "ميرا";
                //sendTestingSMS.Category = txtEmailReference.Text.Trim();
                //sendTestingSMS.Amount = txtAmount.Text.Trim();
                sendTestingSMS.SMSReference = txtEmailReference.Text.Trim();
                string strResult = string.Empty;

                MessageSimulator.ServiceReference1.IijaraMessagingGatewayClient Testing = new ServiceReference1.IijaraMessagingGatewayClient();
                Testing.Open();
                strResult = Testing.SendSaleSMS(sendTestingSMS);
                //strResult = Testing.SendSRSms(sendTestingSMS);
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
                //SendBulkEmail sendTestingEmail = new SendBulkEmail();
                SendSREmail sendTestingEmail = new SendSREmail();
                //SendMail sendTestingEmail = new SendMail();
                //SendMail
                // sendTestingEmail = new SendEMail();
                sendTestingEmail.RecipientsTo = txtRecipientsTo.Text.Trim();
                sendTestingEmail.RecipientsCc = txtRecipientCc.Text.Trim();
                //sendTestingEmail.EmailReference = "1-8KRSS3";
                //sendTestingEmail.Firstname = txtEmailReference.Text.Trim();
                sendTestingEmail.SadadReferenceNumber = txtAccountNumber.Text.Trim();
                ////sendTestingEmail.AccountNumber = txtAccountNumber.Text.Trim();
                //sendTestingEmail.ApplicationNum = txtAccountNumber.Text.Trim();
                //sendTestingEmail.Totalamount = txtAmount.Text.Trim();
                //sendTestingEmail.PartnerCode = "IJARAH";
                //sendTestingEmail.Amount = txtAmount.Text.Trim();
                //sendTestingEmail.SubCategory = txtEmailReference.Text.Trim();
                //sendTestingEmail.Category = txtEmailReference.Text.Trim();
                sendTestingEmail.DueDate = DateTime.Now.ToString("dd-MM-yyyy");
                sendTestingEmail.MessageCode = txtMessageCode.Text.Trim();
                sendTestingEmail.CustomerName = txtEmailReference.Text.Trim();
                //sendTestingEmail.Gender = "ميرا";
                sendTestingEmail.MessageType = rbnEnglish.Checked ? "N" : "U";
                //sendTestingEmail.PartnerCode = "IJARAH";
                sendTestingEmail.OpportunityNumber = "1170400004";
                sendTestingEmail.Category = "5165215";
                sendTestingEmail.CustomerIBAN = "742489498";
                sendTestingEmail.CustomerBankName = "Riyadh";
                sendTestingEmail.VirtualAccount = "12323424";
                sendTestingEmail.EmailReference = "1010101010";
                sendTestingEmail.Amount = "10000";

                MessageSimulator.ServiceReference1.IijaraMessagingGatewayClient Testing = new ServiceReference1.IijaraMessagingGatewayClient();
                Testing.Open();
                //Testing.SendEMail(sendTestingEmail);
                Testing.SendSREmail(sendTestingEmail);
                //Testing.SendBulkEmail(sendTestingEmail);
                //Testing.SendSaleEmail(sendTestingEmail);
                //Testing.SendSaleEmail(sendTestingEmail);
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