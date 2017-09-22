<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ObserverTest.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
 
<frameset rows="88,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="Top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset cols="187,*" frameborder="no" border="0" framespacing="0">
     <frame src="Content.aspx" name="rightFrame" id="rightFrame" title="rightFrame" />
  </frameset>
</frameset>
<noframes>
    <body>
    </body>
</noframes>
</html>
