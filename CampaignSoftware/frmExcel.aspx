﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="frmExcel.aspx.cs" Inherits="Signature.Campaign.frmExcel" %>


<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls"
    TagPrefix="cc1" %>

<form id="form1" runat="server">
        <cc1:Header ID="Header1" runat="server" MenuType= "CampaigneMenu" /> 
           <tr>
                <td>
                    <div>
                        
                    </div>
                    <cc1:Box ID="Box1" runat="server" Width="100%">        
            <table cellpadding="2" cellspacing="1">
            <tr>
                <td colspan="3" align="center">
                    <strong><span style="color: #339933">
                    Upload Excel File Teacher/Student </span></strong>
                </td>
            </tr>
            <tr>
                <td>
                    Browse File
                </td>
                <td>
                    <asp:FileUpload ID="fpFile" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan ="3" align ="center">
                    <asp:GridView ID="GridView1" runat="server" Width="356px">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan ="3" align ="center">
                    &nbsp;</td>
            </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Label ID="txtOutput" runat="server"></asp:Label>
                    </td>
                </tr>
        </table>
    
</cc1:Box>
                </td>
            </tr>
        <cc1:Footer ID="Footer1" runat="server" />
    </form>
    