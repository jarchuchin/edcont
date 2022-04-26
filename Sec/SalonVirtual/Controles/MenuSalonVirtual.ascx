<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MenuSalonVirtual.ascx.vb" Inherits="Sec_SalonVirtual_Controles_MenuSalonVirtual" %>




<div class="panel">
 
    <div class="panel-body">
                   
<div class="mar-btm">
	
	<div class="list-group bg-trans">
        <asp:Panel ID="panelGenerales" runat="server" Visible="false" >
        <asp:HyperLink ID="lnkSalon2" runat="server" NavigateUrl="~/Sec/SalonVirtual/Default.aspx" CssClass="list-group-item">
             <span class="badge badge-purple badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal2" runat="server" Text="Muro" ></asp:Literal>
        </asp:HyperLink>
        <asp:HyperLink ID="lnkVerContenido2" runat="server"  NavigateUrl="~/Sec/SalonVirtual/vercarpeta.aspx" CssClass="list-group-item">
            <span class="badge badge-info badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal3" runat="server" Text="Contenido" ></asp:Literal>
        </asp:HyperLink>

        <asp:HyperLink ID="lnkCalendario2" runat="server" text="Agenda" NavigateUrl="~/Sec/SalonVirtual/Calendario.aspx" CssClass="list-group-item">
                <span class="badge badge-warning badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal4" runat="server" Text="Agenda" ></asp:Literal>
        </asp:HyperLink>


        <asp:HyperLink ID="lnkPreguntas2" runat="server"  CssClass="list-group-item">
             <span class="badge badge-pink badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal5" runat="server" Text="Preguntas" ></asp:Literal>
        </asp:HyperLink>

        <asp:HyperLink ID="lnkbb2" runat="server"   CssClass="list-group-item">
             <span class="badge badge-success badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal6" runat="server" Text="Sala Virtual" ></asp:Literal>
        </asp:HyperLink>

            
        </asp:Panel>

<asp:Panel ID="panelAlumno" runat="server" Visible="false" >


        <asp:HyperLink ID="lnkEvalAlumnos1" runat="server"  NavigateUrl="~/Sec/SalonVirtual/EsquemaEvaluacionAlumno.aspx" CssClass="list-group-item">
             <span class="badge badge-success badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal1" runat="server" Text="Evaluación" ></asp:Literal>
        </asp:HyperLink>

    <asp:HyperLink ID="lnkAvance" runat="server"  NavigateUrl="~/Sec/SalonVirtual/EsquemaEvaluacionAlumno.aspx" CssClass="list-group-item">
             <span class="badge badge-info badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal15" runat="server" Text="Avance general" ></asp:Literal>
        </asp:HyperLink>


        <asp:HyperLink ID="lnkAsistenciaAlumno2" runat="server" NavigateUrl="~/Sec/SalonVirtual/AsistenciaSalonVirtualAlumno.aspx" CssClass="list-group-item">
                <span class="badge badge-warning badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal7" runat="server" Text="Asistencia" ></asp:Literal>
        </asp:HyperLink>


</asp:Panel>

        


<asp:Panel ID="panelMaestro" runat="server" Visible="false" >


    <asp:Panel ID="panelDatosGenerales" runat="server">
            
      
                <asp:HyperLink ID="lnkdatosgenerales2" runat="server"  NavigateUrl="~/Sec/SalonVirtual/AddSalonVirtual.aspx" CssClass="list-group-item">

                     <span class="badge badge-alert badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal8" runat="server"  text="Datos generales"></asp:Literal>
                </asp:HyperLink>

    </asp:Panel>


        <asp:Panel ID="panelActividadesEnviadas" runat="server">
            
           <asp:HyperLink ID="lnkActividadeEnviadas2" runat="server"  NavigateUrl="~/Sec/SalonVirtual/TareasRecibidas.aspx" CssClass="list-group-item">
                 <span class="badge badge-warning badge-icon badge-fw pull-left"></span><asp:Literal ID="litActividades" runat="server"  text="Actividades"></asp:Literal>
           </asp:HyperLink>

            
        </asp:Panel>


        <asp:Panel ID="panelEsquemaEvaluacion" runat="server">


      <asp:HyperLink ID="lnkEsquemaEvaluacionMaestro2" runat="server"  NavigateUrl="~/Sec/SalonVirtual/AddEsquemadeEvaluacion.aspx" CssClass="list-group-item">
            <span class="badge badge-pink badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal10" runat="server"  text="Esquema de evaluación"></asp:Literal>
      </asp:HyperLink>

        </asp:Panel>

        <asp:Panel ID="panelAsistencia" runat="server">
   
        <asp:HyperLink ID="lnkAsistencia2" runat="server"  NavigateUrl="~/Sec/SalonVirtual/AsistenciaSalonVirtual.aspx" CssClass="list-group-item">
              <span class="badge badge-info badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal11" runat="server"  text="Asistencia"></asp:Literal>
        </asp:HyperLink>

        </asp:Panel>



        <asp:Panel ID="panelListaAlumnos" runat="server">
  
        <asp:HyperLink ID="lnkListaAlumnos2" runat="server"  NavigateUrl="~/Sec/SalonVirtual/ListaAlumnos.aspx" CssClass="list-group-item">
              <span class="badge badge-blue badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal12" runat="server"  text="Lista de alumnos"></asp:Literal>
        </asp:HyperLink>


            <asp:HyperLink ID="lnkListaSeguimiento" runat="server"  NavigateUrl="~/Sec/SalonVirtual/ListaSeguimiento.aspx" CssClass="list-group-item">
              <span class="badge badge-success badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal9" runat="server"  text="Seguimiento de alumnos"></asp:Literal>
        </asp:HyperLink>

        </asp:Panel>



        <asp:Panel ID="panelPermisos" runat="server">
  
            <asp:HyperLink ID="lnkPermisos2" runat="server"  NavigateUrl="~/Sec/SalonVirtual/Permisos.aspx" CssClass="list-group-item">
                  <span class="badge badge-primary badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal13" runat="server"  text="Permisos"></asp:Literal>
            </asp:HyperLink>

        </asp:Panel>
        
        
<%--     <asp:Panel ID="panelSincronizacion" runat="server">

<asp:HyperLink ID="lnkSincronizacion2" runat="server"  NavigateUrl="~/Sec/SalonVirtual/Sincronizacion.aspx" CssClass="list-group-item">
    <span class="badge badge-danger badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal14" runat="server"  text="Sincronización"></asp:Literal>
</asp:HyperLink>
           
        </asp:Panel>--%>


</asp:Panel>






    </div>
</div>




    </div>
</div>


