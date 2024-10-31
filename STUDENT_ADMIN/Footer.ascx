<!--ASPX page @1-F0C6DA13-->
    <%@ Control language="vb" CodeFile="Footer.ascx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Footer.FooterPage" %>
	
	<%@ Import namespace="DECV_PROD2007.Footer" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<p align="center"><strong>&copy; 2008-2019 DECV/VSV</strong></p>
<p align="center"><em>(last updated: 29-Mar-2009)</em></p>

<div class="wrapperbox">
<div class="info">This is a test message. Behold the Colours! <br>Eric</div>
<div class="success">This is a test message. <br>Eric</div>
<div class="warning">This is a test message. <br>Eric</div>
<div class="error">This is a test message. <br>Eric</div>
</div>

<style>
.wrapperbox { text-align: center;}
.info, .success, .warning, .error, .validation {
border: 1px solid;
padding:15px 10px 15px 50px;
background-repeat: no-repeat;
background-position: 10px center;
font-family:Arial, Helvetica, sans-serif; 
font-size:13px;
width: 50%;
text-align:center;
margin:0 auto 0 auto;
}
.info {
color: #00529B;
background-color: #BDE5F8;
background-image: url('images/info.png');
}
.success {
color: #4F8A10;
background-color: #DFF2BF;
background-image:url('images/success.png');
}
.warning {
color: #9F6000;
background-color: #FEEFB3;
background-image: url('images/warning.png');
}
.error {
color: #D8000C;
background-color: #FFBABA;
background-image: url('images/error.png');
}

</style>








<!--End ASPX page-->

