<%@ Page Language="C#" Inherits="MeliSample.PreSelectedList" CodeBehind="~/PreSelectedList.aspx.cs"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html>
<head runat="server">
	<title>Pre-Seleccionados</title>
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Básico de Boostrap -->
    <link href="css/bootstrap.css" rel="stylesheet">
   
    
    <!-- Css Chipsafer -->
    <link href="css/custom.css" rel="stylesheet">    
    
    <!-- Soporte para IE -->
    <!--[if lt IE 9]><script src="boostrap/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="js/ie-emulation-modes-warning.js"></script>

   <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Es indicado mejor en el orden -->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    
    <!-- JS Chipsafer --->
    <script src="js/custom.js"></script>
    
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="js/ie10-viewport-bug-workaround.js"></script>

    <link rel="stylesheet" href="~/css/chico-0.12.2.css" />
	<link rel="stylesheet" href="~/css/chico-mesh.css" />
</head>
<body class="lorem-ipsum">
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdateResults">
        <ProgressTemplate>
            <div class="overlay-box">

            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
        <div class="headerdummy">
        <div class="ml-header-inner">        
            <a href="/Home.aspx">
                <h1 class="ml-logo"></h1>
            </a>
            <div class="page-title-dummy">
                Pre-selecci&oacute;n - Art&iacute;culos
            </div>
        </div>  
    </div>
	<form id="form1" runat="server">
    <asp:UpdatePanel ID="UpdateResults" runat="server" UpdateMode="Always">
    
        <ContentTemplate>
            <asp:ScriptManager ID="UpdateResultsSM" runat="server"></asp:ScriptManager>
            
            <div id="PreSelected" class="pre-selected back">
                <span class="glyphicon glyphicon-circle-arrow-left" aria-hidden="true"></span>
                <a id="PreSelectedLink" runat="server" href="Default.aspx">Volver a la b&uacute;squeda de art&iacute;culos</a>
            </div>

            <!-- activated -->
            <section>       
                <div id="divThumbs" runat="server" class="row thumbs-all">
       		
				    <asp:Repeater ID="productsRepeater" runat="server" OnItemCommand="productsRepeater_ItemCommand" OnItemCreated="productsRepeater_ItemCreated">
					    <ItemTemplate>
       		                <div class="col-sm-3">
                                <asp:LinkButton ID="DeleteButton" CommandName="ItemCommand" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")+",eliminar" %>' runat="server">
                                    <div class="close-item">
                                       <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                    </div>
                                </asp:LinkButton>
            	                <figure class="image-generic">
                	                <img src="<%#((System.Collections.Generic.List<MeliSample.Models.Picture>)Eval("pictures")).ToArray()[0].url%>" alt="Mercado Libre"/>
                                </figure>
                
                                <asp:LinkButton ID="LeftButton" CommandName="ItemCommand" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")+",izquierda" %>' runat="server" CssClass="btn-primary col-sm-6 fleft">
                                    Izquierda
                                </asp:LinkButton> 
                                <asp:LinkButton ID="RightButton" CommandName="ItemCommand" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")+",derecha" %>' runat="server" CssClass="col-sm-6 btn-primary fright">
                                    Derecha
                                </asp:LinkButton> 
                                <%--a href="#" class="btn-primary col-sm-6 fleft">
                	                Izquierda
                                </a>
                                <a href="#" class=" col-sm-6 btn-primary fright">
                	                Derecha
                                </a--%>
                                <div class="clear"></div>
                            </div>
					    </ItemTemplate>
				    </asp:Repeater>
                </div>
       
            </section>
    
            <section>
       	        <div id="comparison" runat="server" class="row">
        	        <div class="item-compare-image">
                        <div class="col-sm-2 fleft">
                            
                        </div>
                        <div class="col-sm-5 fleft">
                	        <a id="leftImageUrl" runat="server" href="#">
                                <div class="figure fleft">
                                    <img id="leftImage" runat="server" alt="Mercado Libre">
                                </div>           
                            </a>
                        </div>
                        <div class="col-sm-5 fright">
                            <div class="figure fleft">
                    	        <a id="rightImageUrl" runat="server" href="#" title="Mercado Libre">
                    		        <img id="rightImage" runat="server" alt="Mercado Libre">
                                </a>
                            </div>
                        </div>
                        <div class="clear"></div>            
                    </div>

                    
                    <div class="item-compare">
                        <div class="col-sm-2 fleft">
                            <div class="compare-item-title">Reputaci&oacute;n</div> 
                        </div>
                        <div id="leftUserInfo" runat="server" class="col-sm-5 fleft">
                            <div class="compare-item-value user-left">
                                <ol class="reputation-thermometer">
		                            <li id="leftRep1" runat="server" class="reputation-thermometer-1">Rojo</li>
		                            <li id="leftRep2" runat="server" class="reputation-thermometer-2">Naranja</li>
		                            <li id="leftRep3" runat="server" class="reputation-thermometer-3">Amarillo</li>
		                            <li id="leftRep4" runat="server" class="reputation-thermometer-4">Verde claro</li>
		                            <li id="leftRep5" runat="server" class="reputation-thermometer-5">Verde</li>
	                            </ol>
                            </div>           
                        </div>
                        <div id="rightUserInfo" runat="server" class="col-sm-5 fright">
                            <div class="compare-item-value user-right">
                                <ol class="reputation-thermometer">
		                            <li id="rightRep1" runat="server" class="reputation-thermometer-1">Rojo</li>
		                            <li id="rightRep2" runat="server" class="reputation-thermometer-2">Naranja</li>
		                            <li id="rightRep3" runat="server" class="reputation-thermometer-3">Amarillo</li>
		                            <li id="rightRep4" runat="server" class="reputation-thermometer-4">Verde claro</li>
		                            <li id="rightRep5" runat="server" class="reputation-thermometer-5">Verde</li>
	                            </ol>
                            </div>
                        </div>
                        <div class="clear"></div>
        	        </div> 
                       
                    <div class="item-compare">
                        <div class="col-sm-2 fleft">
                            <div class="compare-item-title">Precio</div> 
                        </div>
                        <div class="col-sm-5 fleft">
                            <div class="compare-item-value user-left">
                                <strong id="leftPrecio" runat="server" class="ch-price"></strong>
                            </div>           
                        </div>
                        <div class="col-sm-5 fright">
                            <div class="compare-item-value user-right">
                                <strong id="rightPrecio" runat="server" class="ch-price"></strong>
                            </div>
                        </div>
                        <div class="clear"></div>
        	        </div>
                    
				    <asp:Repeater ID="compareRepeater" runat="server">
					    <ItemTemplate>
                            <div class="item-compare ">
                                <div class="col-sm-2 fleft">
                                    <div class="compare-item-title"><%# Eval("Name") %></div> 
                                </div>
                                <div class="col-sm-5 fleft">
                                    <div class="compare-item-value"><%# Eval("LeftValue") %></div>           
                                </div>
                                <div class="col-sm-5 fright">
                                    <div class="compare-item-value"><%# Eval("RightValue") %></div>
                                </div>
                                <div class="clear"></div>
        	                </div> 
					    </ItemTemplate>
				    </asp:Repeater>
            
                </div>
    
            </section>
    
	
		    <%-- div class="ch-g2-3">
			    <div class="ch-box ch-leftcolumn">	
				    <!-- pictures -->
				    <div id="example" class="ch-carousel">
			
					    <ul>
						    <asp:Repeater ID="customersRepeater" runat="server">
							    <ItemTemplate>
						            <li>
						            </li>
						        </ItemTemplate>
						    </asp:Repeater>
					    </ul>
				
				    </div>
			    </div>
		    </div>

		    <div class="ch-g1-3">
			    <div class="ch-box ch-rightcolumn">
				
		
			    </div>
		    </div--%>
        </ContentTemplate>
    </asp:UpdatePanel>
	</form>
</body>
</html>