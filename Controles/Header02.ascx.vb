
Partial Class Controles_Header02
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocar()
        End If
    End Sub


    Sub colocar()

        If Session("gUserProfileSession").nombre <> "" Then
            lblnombre.Text = Session("gUserProfileSession").nombre
            lnkmiportal.Visible = True
            lnkhome.Visible = False
            lnkSalir.Visible = True
            lnkMail.Visible = True

            If Session("gUserProfileSession").emailGoogle.ToString.ToLower.Contains("skolar.online") Then
                lnkMail.NavigateUrl = "http://skolar.oonline/"
            End If

        End If
        lblFecha.Text = Format(Date.Now, "ddd").ToUpper & " / " & Format(Date.Now, "MMM").ToUpper & " " & Format(Date.Now, "dd") & ", " & Date.Now.Year
        lblHora.Text = Format(Date.Now, "hh:mm")


        If Request("idSalonVirtual") <> "" Then
            lnkApunte.Visible = True
            lnkApunte.NavigateUrl = "~/sec/salonvirtual/apuntes.aspx?idSalonVirtual=" & Request("idSalonVirtual")

            lnkpregunta.Visible = True
            lnkpregunta.NavigateUrl = "~/sec/salonvirtual/preguntas.aspx?idSalonVirtual=" & Request("idSalonVirtual")
            lnkbb.NavigateUrl = "~/sec/salonvirtual/createBBB.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&bbb=1"
            lnkbb.Visible = True

            litscript.Text = getScript()

            Dim mysv As New Know.SalonVirtual(CInt(Request("idSalonVirtual")), False)
            lblNombreCurso.Text = mysv.nombre

        End If


      

    End Sub



    Public Function getScript() As String
        Dim cadena As New StringBuilder
      


        Dim localpath As String = System.Configuration.ConfigurationManager.AppSettings("carpetaVirtual")


        Dim imagen2 As String = localpath & "images/header/miportal2.png"

        cadena.AppendLine("<script type=""text/javascript"">")
        cadena.AppendLine("$(function() {")

        cadena.AppendLine("$(""#" & img1.ClientID & """).mouseover(function(event) {")
        cadena.AppendLine("resetImagenes();")
        cadena.AppendLine("cambiarImagen(this, """ & imagen2 & """);")
        cadena.AppendLine("colocarTabla($(""#datac1.submenu""), $(""#" & img1.ClientID & """), ""visible"", 200 ) ;")
        cadena.AppendLine("});")
        cadena.AppendLine("")

        cadena.AppendLine("$(""#datac1.submenu"").mouseleave(function(event) {")
        cadena.AppendLine("resetImagenes();")
        cadena.AppendLine("});")
        cadena.AppendLine("")




        cadena.AppendLine("}); ")
        cadena.AppendLine("")

        cadena.AppendLine("function colocarTabla(tabla, imagen, vis, ancho){")
        cadena.AppendLine("var pos = imagen.position(); ")
        cadena.AppendLine("var top = pos.top + 30;")
        cadena.AppendLine("tabla.css({""position"":""absolute""});")
        cadena.AppendLine("tabla.css({""z-index"":""99999""});")
        cadena.AppendLine("if (vis == ""hidden"") {")
        cadena.AppendLine("tabla.css({""visibility"":""hidden""});")
        cadena.AppendLine("}else{")
        cadena.AppendLine("tabla.css({""visibility"":""visible""});")
        cadena.AppendLine("}")
        cadena.AppendLine("tabla.css(""margin-left"",  pos.left   + ""px"");")
        cadena.AppendLine("tabla.css(""margin-top"",  top + ""px"");")
        cadena.AppendLine("tabla.width(ancho);")
        cadena.AppendLine("}")


        cadena.AppendLine("function cambiarImagen(obj, imagen){")
        cadena.AppendLine("obj.src = imagen;")
        cadena.AppendLine("}")

        cadena.AppendLine("function resetImagenes(){")
        cadena.AppendLine("$(""#" & lnkmiportal.ClientID & """).attr(""src"",""" & localpath & "images/header/miportal.png"");")
        cadena.AppendLine("$(""#datac1.submenu"").css({""visibility"":""hidden""});")
        cadena.AppendLine("")
        cadena.AppendLine("}")

        cadena.AppendLine("</script>")


        Return cadena.ToString
    End Function


End Class
