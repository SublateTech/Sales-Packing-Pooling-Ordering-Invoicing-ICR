<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="Signature.Web.PatternClass" %>

<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls" TagPrefix="cc1" %>
    		
    		<tr>
    		   <td >
                        <cc1:Box ID="Box2" runat="server">
         
                            <h1>This is the base Class</h1>
                            <h2>This is the base Class</h2>
                            <h3>This is the base Class</h3>
                            <h4>This is the base Class</h4>
                            
                            <p>Base Class</p>
                            
                            <cc1:Box ID="Box3" runat="server">
                            
                            </cc1:Box>
                            
                            
                        </cc1:Box>
                   <cc1:Box ID="Box1" runat="server">
                        <asp:label ID="Label1" runat="server" text="Label1"></asp:label>
                       
                   </cc1:Box>
                        
               </td>
			</tr>
