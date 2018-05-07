<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMessage.aspx.cs" Inherits="MessageSimulator.TestMessage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ACT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server" />
        <div>

            <table style="width: 30%;">
                <tr>

                    <td style="width: 50%;" align="center">

                        <table style="width: 100%; background-color: Silver;">
                            <tr>
                                <td style="width: 40%;"></td>
                                <td style="width: 60%;"></td>
                            </tr>
                            <tr>

                                <td colspan="2" style="background-color: Gray; text-align: center;">
                                    <asp:Label ID="lblHeading" Text="Send Email/SMS" runat="server" Font-Bold="true" Font-Size="Larger" ForeColor="white" Style="text-align: center"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">

                                    <asp:Label ID="lblRecipientsTo" runat="server" Text="Recipients To" Font-Bold="true" />

                                </td>
                                <td style="text-align: left;">


                                    <asp:TextBox ID="txtRecipientsTo" runat="server" Text="meera@kisltech.com"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvRecipientsToE" runat="server" ControlToValidate="txtRecipientsTo" ValidationGroup="email" ErrorMessage="Required" Display="None" />

                                    <ACT:ValidatorCalloutExtender ID="vceRecipientsToE" runat="server" TargetControlID="rfvRecipientsToE" />

                                </td>


                            </tr>

                            <tr>
                                <td style="text-align: left;">

                                    <asp:Label ID="lblRecipientsCc" runat="server" Text="Recipients Cc" Font-Bold="true" />

                                </td>

                                <td style="text-align: left;">


                                    <asp:TextBox ID="txtRecipientCc" runat="server" Text="v-meera@ijarah.sa"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvRecipientCc" runat="server" ControlToValidate="txtRecipientCc" ValidationGroup="email" ErrorMessage="Required" Display="None" />

                                    <ACT:ValidatorCalloutExtender ID="vceRecipientCc" runat="server" TargetControlID="rfvRecipientCc" />

                                </td>


                            </tr>

                              <tr>
                                <td style="text-align: left;">

                                    <asp:Label ID="lblCustomMessage" runat="server" Text="Custom Message" Font-Bold="true" />

                                </td>

                                <td style="text-align: left;">


                                    <asp:TextBox ID="txtCustomMessage" runat="server" TextMode="MultiLine"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRecipientCc" ValidationGroup="email" ErrorMessage="Required" Display="None" />

                                    <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvRecipientCc" />

                                </td>


                            </tr>
                            <tr>
                                <td style="text-align: left;">

                                    <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number" Font-Bold="true" />

                                </td>

                                <td style="text-align: left;">


                                    <asp:TextBox ID="txtAccountNumber" runat="server" Text="123456"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvAccountNumberE" runat="server" ControlToValidate="txtAccountNumber" ValidationGroup="email" ErrorMessage="Required" Display="None" />

                                    <asp:RequiredFieldValidator ID="rfvAccountNumberS" runat="server" ControlToValidate="txtAccountNumber" ValidationGroup="sms" ErrorMessage="Required" Display="None" />
                                    <ACT:ValidatorCalloutExtender ID="vceAccountNumberE" runat="server" TargetControlID="rfvAccountNumberE" />

                                    <ACT:ValidatorCalloutExtender ID="vceAccountNumberS" runat="server" TargetControlID="rfvAccountNumberS" />


                                </td>


                            </tr>

                            <tr>
                                <td style="text-align: left;">

                                    <asp:Label ID="lblEmailReference" runat="server" Text="First Name" Font-Bold="True" />


                                </td>

                                <td style="text-align: left;">

                                    <asp:TextBox ID="txtEmailReference" runat="server" Text="Meera Mohamed Ali"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvEmailReferenceE" runat="server" ControlToValidate="txtEmailReference" ValidationGroup="email" ErrorMessage="Required" Display="None" />

                                    <ACT:ValidatorCalloutExtender ID="vceEmailReferenceE" runat="server" TargetControlID="rfvEmailReferenceE" />



                                </td>

                            </tr>

                            <tr>
                                <td style="text-align: left;">

                                    <asp:Label ID="lblAmount" runat="server" Font-Bold="true" Text="Amount" />

                                </td>

                                <td style="text-align: left;">



                                    <asp:TextBox ID="txtAmount" runat="server" Text ="1,345.75"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvAmountE" runat="server" ControlToValidate="txtAmount" ValidationGroup="email" ErrorMessage="Required" Display="None" />

                                    <asp:RequiredFieldValidator ID="rfvAmountS" runat="server" ControlToValidate="txtAmount" ValidationGroup="sms" ErrorMessage="Required" Display="None" />


                                </td>


                            </tr>

                            <tr>
                                <td style="text-align: left;">

                                    <asp:Label ID="lblRecipients" runat="server" Font-Bold="True" Text="Mobile Number" />

                                </td>

                                <td style="text-align: left;">

                                    <asp:TextBox ID="txtRecipients" runat="server" Text="+966534694362"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvRecipientsS" runat="server" ControlToValidate="txtRecipients" ValidationGroup="sms" ErrorMessage="Required" Display="None" />

                                    <ACT:ValidatorCalloutExtender ID="vceRecipientsS" runat="server" TargetControlID="rfvRecipientsS" />

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: left;">

                                    <asp:Label ID="lblMessageCode" runat="server" Font-Bold="True" Text="Message Code" />

                                </td>

                                <td style="text-align: left;">

                                    <asp:TextBox ID="txtMessageCode" runat="server" Text="KISLTEST"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvMessageCode" runat="server" ControlToValidate="txtMessageCode" ValidationGroup="email" ErrorMessage="Required" Display="None" />
                                     <asp:RequiredFieldValidator ID="rfvMessageCodeS" runat="server" ControlToValidate="txtMessageCode" ValidationGroup="sms" ErrorMessage="Required" Display="None" />

                                    <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvMessageCode" />
                                    <ACT:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvMessageCodeS" />

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: left;">

                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Language" />

                                </td>

                                <td style="text-align: left;">

                                    <asp:RadioButton ID="rbnArabic" runat="server" GroupName="Lang" Checked="false"  Text="Arabic" />
                                    <asp:RadioButton ID="rbnEnglish" runat="server" GroupName="Lang" Checked="true" Text="English" />

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;" colspan="2">

                                    <asp:Button ID="btnSendSMS" runat="server" Text="Send SMS" ValidationGroup="sms" OnClick="btnSendSMS_Click" />

                                    <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" ValidationGroup="email" OnClick="btnSendEmail_Click" />

                                </td>

                            </tr>

                            <tr>
                                <td style="text-align: center;" colspan="2">

                                   <asp:Label ID ="lblStatus" Text ="" runat="server" ForeColor="Green"></asp:Label>

                                </td>

                            </tr>

                        </table>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>

