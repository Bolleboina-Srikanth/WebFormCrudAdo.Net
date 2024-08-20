<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeListView.aspx.cs" Inherits="EmployeesListWebForms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees List</title>
    <style>
        .div-container {
            width: 100vw;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: orange;
            margin: 0;
            padding: 0;
        }

        #LinkButton1, #LinkButton2{
            text-decoration:none
        }
    </style>
</head>
<body>
    <div class="div-container">
        <form id="form1" runat="server">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="txtEName" runat="server" Text="Name:"></asp:Label>&nbsp;
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="txtSalary" runat="server" Text="salary:"></asp:Label>&nbsp;
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="txtDepartment" runat="server" Text="Department:"></asp:Label>&nbsp;
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ColumnSpan="2">
                    <asp:TableCell>
                        <asp:Button ID="btnAdd" runat="server" Text="Add New Employee" OnClick="addnewEmployee" />
                        <asp:Button ID="Button4" runat="server" Text="Update changes" OnClick="UpdateEmployee" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="EmId" HeaderText="Employee ID" ReadOnly="true" />
                    <asp:BoundField DataField="EName" HeaderText="Name" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnUpdate_click">
                                <%--<asp:Button ID="Button1" runat="server" Text="Update" />--%>
                                Update
                            </asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btndelete_click">
                                <%--<asp:Button ID="Button2" runat="server" Text="Delete" />--%>
                                Delete
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </form>


    </div>

</body>
</html>
