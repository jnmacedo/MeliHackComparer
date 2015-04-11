<%@ Control Language="C#" Inherits="MeliSample.ProductUserControl" CodeBehind="~/ProductUserControl.ascx.cs" %>
<%@ Import Namespace="System.Data" %>

<asp:UpdatePanel ID="UpdateResults" runat="server">
    <ContentTemplate>
        <asp:ScriptManager ID="UpdateResultsSM" runat="server"></asp:ScriptManager>
        <table class="ch-datagrid">
            <tbody>
                <asp:Repeater id="ProductSearchRepeater" runat="server" OnItemCommand="ItemCommand">

                    <HeaderTemplate>
                        <tr>
        	                <th scope="col"></th>
                            <th scope="col">Título</th>
                            <th scope="col">Condición</th>
                            <th scope="col">Precio</th>
                            <th scope="col">Fecha de fin</th>
                            <th scope="col">Lista de comparación</th>
                        </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
		            <tr>
			            <td><img src="<%#Eval("thumbnail")%>" alt="item image" /> </td> 
			
			            <td>
			              <a href="ProductDetails.aspx?productID=<%#Eval("id")%>"><%#Eval("title")%></a> 
			            </td>
			
			            <td> <%#Eval("condition")%> </td>
			
			            <%-- string curr = TransformCurrency(Eval("currency_id").ToString()); --%>
			            <td> <p><strong class="ch-price"> <%# TransformCurrency(Eval("currency_id").ToString()) %>  <%#Eval("price")%></strong></p> </td>
			
			            <%-- string endTime = TransformDate((string)Eval("stop_time")); --%> 
			            <td> <%# TransformDate((string)Eval("stop_time")) %></td>
			            <td>
                            <asp:LinkButton CommandName="ItemCommand" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server"><img src="img/compare.png" alt="compare" width="64" height="64"/></asp:LinkButton> 
                            <%--asp:LinkButton ID="AddToCompareListButton" runat="server" OnClick="AddToCompareList_Click"><img src="img/compare.png" alt="compare" width="64" height="64"/></asp:LinkButton--%>

			            </td>
            
		            </tr>
                    </ItemTemplate>

                </asp:Repeater>
	        </tbody>
        </table>

        There are <%= this.Results %> results of this item.  
    </ContentTemplate>
</asp:UpdatePanel>