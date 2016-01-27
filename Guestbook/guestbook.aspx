<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guestbook.aspx.cs" Inherits="Guestbook.guestbook" %>

<%@ Import Namespace="System.ComponentModel" %>
<%@ Import Namespace="DAL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Guestbook</title>
    <link href="MainStyle.css" rel="stylesheet" />
    <link href='https://fonts.googleapis.com/css?family=Amatic+SC:400,700' rel='stylesheet' type='text/css' />
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,100,700' rel='stylesheet' type='text/css' />
    <link href='https://fonts.googleapis.com/css?family=Shadows+Into+Light+Two' rel='stylesheet' type='text/css/'>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <header>
                <h1>Welcome to 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h1>
            </header>
            <div class="main-img">
                <img id="vodoogirl" src="img/voodoogirl1.gif" />
            </div>

            <div class="comments-field">
                <div class="pagination">
                    <asp:LinkButton CssClass="pag-before" ID="NextPaginationLink" OnClick="PastOrFuture" runat="server"> </asp:LinkButton>
                    <asp:LinkButton CssClass="pag-next" ID="PreviusPaginationLink" OnClick="PastOrFuture" runat="server"> </asp:LinkButton>
                </div>
                <asp:Repeater ID="CommentsRepeater" runat="server">
                    <ItemTemplate>
                        <div class="comment">
                            <p class="userinfo">
                                <a href="mailto:<%# DataBinder.Eval(Container.DataItem, "Email") %>?Subject=Guestbook%20Comment%20from%20<%# DataBinder.Eval(Container.DataItem, "Nickname") %>">
                                    <%# DataBinder.Eval(Container.DataItem, "Nickname") %></a> | 
                             <%# DataBinder.Eval(Container.DataItem, "TimeOfComment") %>
                                <span id="deletebutton">
                                    <asp:LinkButton OnClick="Delete_Comment" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' runat="server">Delete</asp:LinkButton></span>
                            </p>
                            <p class="usermessage"><%# DataBinder.Eval(Container.DataItem, "Content") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="new-comment">
                <div>
                    <h2 id="send-me-a-comment">Share me something!</h2>
                </div>
                <form2>
                <div class="comment-input">
                    <asp:Label ID="NicknameLabel" CssClass="label" runat="server" Text="Nickname: " /><br />
                    <asp:TextBox ID="NicknameInput" CssClass="textbox" runat="server"></asp:TextBox>
                </div>
                <div class="comment-input">
                    <asp:Label ID="EmailLabel" CssClass="label" runat="server" Text="Email: " /><br />
                    <asp:TextBox ID="EmailInput" CssClass="textbox" runat="server"></asp:TextBox>
                </div>
                <div class="comment-input">
                    <asp:Label ID="ContentLabel" CssClass="label" runat="server" Text="Message: " /><br />
                    <asp:TextBox ID="ContentInput" CssClass="textbox-large" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <asp:Button ID="Button1" runat="server" CssClass="LeaveACommentButton" Text="Say it like you mean it!" OnClick="Button_Click" />
                <asp:Label ID="ValidateForNullOrWhitespace" CssClass="label" runat="server" Text="There's no need for silence ..." />
                <asp:Label ID="ValidateForHacks" CssClass="label" runat="server" Text="What the fuck are you trying to do?!" />
        
                </form2>

            </div>
        </div>
    </form>
</body>
</html>
