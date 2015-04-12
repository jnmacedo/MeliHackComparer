<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MeliSample.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <div class="headerdummy">
        <div class="ml-header-inner">        
            <a href="#">
                <h1 class="ml-logo"></h1>
            </a>
            <div class="page-title-dummy">
                Lorem-Ipsum
            </div>
        </div>  
    </div>
    <form id="form1" runat="server">
        <div class="row spot_margin">
            <div class="col-sm-12">
            <div class="col-sm-6">
                <figure class="figure-home">
                    <asp:LinkButton runat="server" ID="btnAutos" OnClick="btnAutos_Click" Text="">
                        <img src="img/CAMARO_ROJO.jpg" />
                    </asp:LinkButton>
                    <div class="figure-caption">
                        Autos o Camionetas
                    </div>
                </figure>
            </div>

            <div class="col-sm-6">
                <figure class="figure-home">
                    <asp:LinkButton runat="server" ID="btnCasas" OnClick="btnCasas_Click" Text="">
                        <img src="img/apartamento_piscina.jpg" />
                    </asp:LinkButton>
                    <div class="figure-caption">
                        Inmuebles (Casas y Apartamentos) 
                    </div>
                </figure>
            </div>
            </div>
        </div>
        <div class="buttons-dummys">
            
            
        </div>
    </form>


</body>
</html>
