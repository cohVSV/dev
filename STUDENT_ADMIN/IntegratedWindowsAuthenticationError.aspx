<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IntegratedWindowsAuthenticationError.aspx.vb" Inherits="IntegratedWindowsAuthenticationError" %>

<html lang="en-au">
<head>
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta charset="utf-8" />
   <meta name="viewport" content="width=device-width, initial-scale=1.0" />

   <title>Virtual School Victoria Student Database</title>

   <link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">

   <style type="text/css">
      .warning
      {
         color: #9F6000;
         background-color: #FEEFB3;
         background-image: url('images/warning.png');
         border: 1px solid;
         padding: 15px 10px 15px 50px;
         background-repeat: no-repeat;
         background-position: 10px center;
         font-family: Arial, Helvetica, sans-serif;
         font-size: 13px;
         width: 50%;
         margin: 0 auto 0 auto;
      }
   </style>
</head>
<body>
   <form runat="server">
      <div>
         <img id="ImageLogo" border="0" alt="VSV Logo" src="images/logosm.gif" style="display: block; margin-left: auto; margin-right: auto; margin-bottom: 50px;">
      </div>

      <div class="warning">
         Something went wrong while trying to sign you into the Virtual School Victoria Student Database:<br /><br />
         <asp:Literal runat="server" ID="litErrorMessage"></asp:Literal><br /><br />
         If this issue persists, please submit a <a href="http://service_desk/" target="_blank">VSV Service Desk Incident</a>
         with the incident tagged as "Database" and quoting the error message above.
      </div>
   </form>
</body>
</html>
