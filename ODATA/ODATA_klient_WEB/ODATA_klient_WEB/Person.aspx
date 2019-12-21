<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="ODATA_klient_WEB.Person" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Person</title>
</head>
<body>
  <form id="formul" runat="server">
   <div>
        <h2 id="LIST">All Persons in PersonList</h2>
        <asp:BulletedList ID="persons" runat="server"></asp:BulletedList>
    </div>
    <div>
        <h2>Get by ID</h2>
        <asp:TextBox ID="GetID" runat="server" Height="16px" Width="179px"></asp:TextBox>
        <asp:Button ID="GetByID" OnClick="GETBYID" runat="server" Text="GetById" Height="22px" style="margin-top: 0px" />
        <asp:BulletedList ID="personget" runat="server"></asp:BulletedList>
    </div>
    <div>
        <h2>Search by Last Name</h2>
         <asp:TextBox ID="SearchName" runat="server" Height="16px" Width="179px"></asp:TextBox>
         <asp:Button ID="SearchButton" OnClick="SEARCHBYNAME" runat="server" Text="SearchByLastName" Height="22px" style="margin-top: 0px" />
         <asp:BulletedList ID="personsearch" runat="server"></asp:BulletedList>
    </div>
    <div>
        <h2>Create Person</h2>
        <asp:TextBox ID="Id_cr" runat="server" Height="16px" Width="179px"></asp:TextBox>
        <asp:TextBox ID="FirstName_cr" runat="server" Height="16px" Width="179px"></asp:TextBox>
        <asp:TextBox ID="LastName_cr" runat="server" Height="16px" Width="179px"></asp:TextBox>
        <asp:Button ID="CreateBut" OnClick="CREATE" runat="server" Text="Create" Height="22px" style="margin-top: 0px" />
        <asp:Button ID="UpdateBut" OnClick="UPDATE" runat="server" Text="Update" Height="22px" style="margin-top: 0px" />
        <asp:BulletedList ID="CrUpList" runat="server"></asp:BulletedList>
    </div>
    <div>
        <h2>Delete Person</h2>
        <asp:TextBox ID="DelInput" runat="server" Height="16px" Width="179px"></asp:TextBox>
        <asp:Button ID="DeletBut" OnClick="DELETE" runat="server" Text="Delete" Height="22px" style="margin-top: 0px" />
        <asp:BulletedList ID="DelList" runat="server"></asp:BulletedList>
    </div>
      <div>
      <h2>Messages</h2>
      <asp:BulletedList ID="message" runat="server"></asp:BulletedList>
      </div>
  </form>
</body>
</html>
