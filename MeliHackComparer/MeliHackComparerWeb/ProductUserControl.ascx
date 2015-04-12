<%@ Control Language="C#" Inherits="MeliSample.ProductUserControl" CodeBehind="~/ProductUserControl.ascx.cs" %>
<%@ Import Namespace="System.Data" %>

<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdateResults" DisplayAfter="0">
    <ProgressTemplate>
        <div class="overlay-box">

        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdateResults" runat="server">
    <ContentTemplate>
        <asp:ScriptManager ID="UpdateResultsSM" runat="server"></asp:ScriptManager>

        <div id="PreSelected" class="pre-selected">
            <span class="glyphicon glyphicon-align-left" aria-hidden="true"></span>
            <a id="PreSelectedLink" runat="server" href="PreSelectedList.aspx"></a>
        </div>
        <table class="ch-datagrid">
            <tbody>
                <asp:Repeater id="ProductSearchRepeater" runat="server" OnItemCommand="ItemCommand" OnItemCreated="ProductSearchRepeater_ItemCreated">

                    <HeaderTemplate>
                        <tr>
        	                <th scope="col"></th>
                            <th scope="col">T&iacute;tulo</th>
                            <th scope="col">Precio</th>
                            <th scope="col">Fecha de fin</th>
                            <th scope="col">Pre-selecci&oacute;n</th>
                        </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
		            <tr>
			            <td><img src="<%#Eval("thumbnail")%>" alt="item image" /> </td> 
			
			            <td>
			              <a href="ProductDetails.aspx?productID=<%#Eval("id")%>"><%#Eval("title")%></a> 
			            </td>
			            
			            <%-- string curr = TransformCurrency(Eval("currency_id").ToString()); --%>
			            <td> <p><strong class="ch-price"> <%# TransformCurrency(Eval("currency_id").ToString()) %>  <%#Eval("price")%></strong></p> </td>
			
			            <%-- string endTime = TransformDate((string)Eval("stop_time")); --%> 
			            <td> <%# TransformDate((string)Eval("stop_time")) %></td>
			            <td>
                            <asp:LinkButton ID="AddToListButton" CommandName="ItemCommand" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")+","+DataBinder.Eval(Container.DataItem, "in_whishlist") %>' runat="server"><img src="<%#Eval("src_wl_image")%>" alt="compare" width="32" height="32"/></asp:LinkButton> 
                            <%--asp:LinkButton ID="AddToCompareListButton" runat="server" OnClick="AddToCompareList_Click"><img src="img/compare.png" alt="compare" width="64" height="64"/></asp:LinkButton--%>

			            </td>
            
		            </tr>
                    </ItemTemplate>

                </asp:Repeater>
	        </tbody>
        </table>
        <div id="resultsDiv" runat="server">
            <%= this.Results %> resultados encontrados.
        </div>
    </ContentTemplate>
</asp:UpdatePanel>