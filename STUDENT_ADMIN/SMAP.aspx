<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMAP.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">

<STYLE>
#table
{
    border-style:solid;
    border-width:1px;
    width:100%;
    font-family: Arial,Helvetica Neue,Helvetica,sans-serif; 
    font-size:12px;
}
.h
{
    border-style:solid;
    border-width:1px;
    font-weight:bold;
}
.t
{
    font-size:20px;
    font-weight:bold;
}
#page td {
   padding:0; margin:0;
}

#page {
   border-collapse: collapse;
}

.c { 
	border-bottom: 0px;
	border-collapse: collapse;
	background-color: White;
}
	
	
</STYLE>

</head>
<body>

    <form id="form1" runat="server">
    <div>

    </div>
    </form>
    <p align="center"><strong>&copy; 2008-2015 DECV</strong></p>
    <p align="center" onclick="document.getElementById('tester').style.display='block';"><em>(last updated: 12-Aug-2015 lnigro)</em></p>
    
    <div id="tester" style="display:none;">
    <form id="SetDate" name="Test" method="POST" action="SMAP.aspx">
        DATE <input name="Date" type="text"/>
        <input name="SetDateButton" type="submit" value="Set Current Date"/>
    </form>

    <form id="SetWarning" name="Test" method="POST" action="SMAP.aspx">
        DATE <input name="Date" type="text"/>
        SUBJECT_ID <input name="SUBJECT_ID" type="text"/>
        STUDENT_ID <input name="STUDENT_ID" type="text"/>
        <input name="SetWarningDateButton" type="submit" value="Set Current Date and Warning Sent Date"/>
    </form>

    <form id="SetCancellation" name="Test" method="POST" action="SMAP.aspx">
        DATE <input name="Date" type="text"/>
        SUBJECT_ID <input name="SUBJECT_ID" type="text"/>
        STUDENT_ID <input name="STUDENT_ID" type="text"/>
        <input name="SetCancellationButton" type="submit" value="Set Current Date and Cancellation Sent Date"/>
    </form>
    </div>
</body>
</html>
