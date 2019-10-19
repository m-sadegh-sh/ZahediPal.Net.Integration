<%@ Page Title="درخواست" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ZahediPal.Net.Integration.WebForms.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="Message"></div>
    <div class="row">
        <div class="col-md-7">
            <table class="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>تراکنش</th>
                        <th>مبلغ</th>
                        <th>بانک</th>
                        <th>توضیحات</th>
                        <th>وضعیت</th>
                    </tr>
                </thead>
                <tbody runat="server" ID="Transactions"></tbody>
            </table>
        </div>
        <div class="col-md-5">
            <div class="form-horizontal">
                <div class="form-group clearfix">
                    <label for="<%= AmountTextBox.ClientID %>" class="col-sm-2 control-label">مبلغ</label>
                    <div class="col-sm-10">
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="AmountTextBox" CssClass="form-control" placeholder="مبلغ" />
                            <div class="input-group-addon">تومان</div>
                        </div>
                    </div>
                </div>
                <div class="form-group clearfix">
                    <label for="<%= DescriptionTextBox.ClientID %>" class="col-sm-2 control-label">درگاه</label>
                    <div class="col-sm-10">
                        <asp:DropDownList runat="server" ID="BankTypeDropDownList" CssClass="form-control">
                            <Items>
                                <asp:ListItem Value="Mellat">ملت</asp:ListItem>
                                <asp:ListItem Value="Saman">سامان</asp:ListItem>
                                <asp:ListItem Value="IranKish">ایران کیش</asp:ListItem>
                                <asp:ListItem Value="Pasargad">پاسارگاد</asp:ListItem>
                                <asp:ListItem Value="Parsian">پارسیان</asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group clearfix">
                    <label for="<%= DescriptionTextBox.ClientID %>" class="col-sm-2 control-label">توضیحات</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="DescriptionTextBox" CssClass="form-control" placeholder="توضیحات..." TextMode="MultiLine" />
                    </div>
                </div>
                <div class="form-group clearfix">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button runat="server" ID="InitiateRequestButton" Text="ارسال درخواست" CssClass="btn btn-primary btn-lg" OnClick="InitiateRequestButtonOnClick" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
