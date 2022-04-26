<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayEstadisticasCotenidos.ascx.vb" Inherits="Sec_SalonVirtual_Controles_DisplayEstadisticasCotenidos" %>



<div class="row">

   <div class="col-lg-12">

        <div class="panel">
            <div class="panel-heading">
                <h3 class="panel-title"> <asp:Label ID="Label1" runat="server" Text="Gráfica de accesos "></asp:Label></h3>

            </div>
             <div class="panel-body">



        <!--Morris Area Chart placeholder-->
		<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
		<div id="graficaContenidos-morris-area" style="height:212px"></div>
		<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->


        <asp:Literal ID="litScript" runat="server"></asp:Literal>

                 <asp:GridView ID="GridView1" runat="server" GridLines="None" CssClass="table table-hover table-striped" Width="100%" AutoGenerateColumns="true"></asp:GridView>



                Gráfica de acceso a contenido dentro del periodo activo del curso.
            </div>
        </div>

    </div>


</div>

<div class="row">

   <div class="col-sm-12 col-lg-6">

        <div class="panel">
            <div class="panel-heading">
                <h3 class="panel-title"> <asp:Label ID="Label4" runat="server" Text="Acceso de usuarios"></asp:Label></h3>

            </div>
             <div class="panel-body">

                 <asp:GridView ID="gvEstadisticas" runat="server" GridLines="None" CssClass="table table-hover table-striped" Width="100%" AutoGenerateColumns="false">

                     <Columns>

                         <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="text-left"  />
                         <asp:BoundField HeaderText="Accesos" DataField="Accesos"  ItemStyle-Width="100px" ItemStyle-CssClass="text-center" />
                     </Columns>

                 </asp:GridView>
            </div>
        </div>

    </div>

    <div class="col-sm-12 col-lg-6">

    </div>

</div>