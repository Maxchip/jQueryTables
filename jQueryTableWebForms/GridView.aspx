<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="jQueryTableWebForms.GridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function fillTable() {

            $.ajax({
                url: "HandlerQuery.ashx",
                type: "POST",
                data: {},
                dataType: "json",
                success: function (data) {

                    for (var i = 0; i < data.length; i++) {
                        $("#gvData").append(
                            "<tr><td>" + data[i].IdDoc +
                            "</td><td>" + data[i].NumeroDoc +
                            "</td><td>" + data[i].DataCadastro +
                            "</td><td>" + data[i].NomeTipoDoc +
                            "</td></tr>");
                    }
                },
                failure: function (data) {
                    alert("Erro");
                }
            });
        }

    </script>


    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>GridView</small>
                </h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>

        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">

                    <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="form-group">
                            <div>Date Start</div>
                            <input type="text" class="form-control" name="dateStart" id="dateStart" placeholder="dd/mm/yyyy" />
                        </div>
                    </div>

                    <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="form-group">
                            <div>Date End</div>
                            <input type="text" class="form-control" name="dateEnd" id="dateEnd" placeholder="dd/mm/yyyy" />
                        </div>
                    </div>

                    <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="form-group">
                            <div>IdDoc</div>
                            <input type="text" class="form-control" name="textIdDoc" id="textIdDoc" />
                        </div>
                    </div>

                    <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="form-group">
                            <div>NumeroDoc</div>
                            <input type="text" class="form-control" name="textNumeroDoc" id="textNumeroDoc" />
                        </div>
                    </div>

                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <div class="form-group">
                            <div>NomeEmpresa</div>
                            <select id="selectNomeEmpresa" name="selectNomeEmpresa" class="form-control">
                                <option value="0"></option>
                                <option value="1">NomeEmpresa 1</option>
                                <option value="2">NomeEmpresa 2</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="form-group">
                            <div>NomeContato</div>
                            <input type="text" class="form-control" name="textNomeContato" id="textNomeContato" />
                        </div>
                    </div>

                    <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="form-group">
                            <div>NomeTipoDoc</div>
                            <select id="selectNomeTipoDoc" name="selectNomeTipoDoc" class="form-control">
                                <option value="0"></option>
                                <option value="1">NomeTipoDoc 1</option>
                                <option value="2">NomeTipoDoc 2</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="form-group">
                            <div>NomeSituacaoDoc</div>
                            <select id="selectNomeSituacaoDoc" name="selectNomeSituacaoDoc" class="form-control">
                                <option value="0"></option>
                                <option value="1">NomeSituacaoDoc 1</option>
                                <option value="2">NomeSituacaoDoc 2</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-sm-1 col-md-1 col-lg-1">
                        <div>&nbsp;</div>
                        <div class="form-group">
                            <button class="form-control btn btn-primary" type="submit" onclick="javascript:fillTable()">OK</button>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">

                    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="true" Width="100%">
                    </asp:GridView>

                </div>
            </div>
        </div>

    </div>
</asp:Content>

