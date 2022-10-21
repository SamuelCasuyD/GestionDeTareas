using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wptablerocreartarea : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wptablerocreartarea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wptablerocreartarea( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( Guid aP0_TrGestionTableros_ID ,
                           String aP1_TrGestionTableros_Nombre ,
                           DateTime aP2_TrGestionTableros_FechaInicio ,
                           DateTime aP3_TrGestionTableros_FechaFin )
      {
         this.AV15TrGestionTableros_ID = aP0_TrGestionTableros_ID;
         this.AV35TrGestionTableros_Nombre = aP1_TrGestionTableros_Nombre;
         this.AV36TrGestionTableros_FechaInicio = aP2_TrGestionTableros_FechaInicio;
         this.AV37TrGestionTableros_FechaFin = aP3_TrGestionTableros_FechaFin;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV15TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( gxfirstwebparm));
               AssignAttri("", false, "AV15TrGestionTableros_ID", AV15TrGestionTableros_ID.ToString());
               GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV15TrGestionTableros_ID, context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV35TrGestionTableros_Nombre = GetNextPar( );
                  AssignAttri("", false, "AV35TrGestionTableros_Nombre", AV35TrGestionTableros_Nombre);
                  AV36TrGestionTableros_FechaInicio = context.localUtil.ParseDateParm( GetNextPar( ));
                  AssignAttri("", false, "AV36TrGestionTableros_FechaInicio", context.localUtil.Format(AV36TrGestionTableros_FechaInicio, "99/99/9999"));
                  AV37TrGestionTableros_FechaFin = context.localUtil.ParseDateParm( GetNextPar( ));
                  AssignAttri("", false, "AV37TrGestionTableros_FechaFin", context.localUtil.Format(AV37TrGestionTableros_FechaFin, "99/99/9999"));
               }
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("masterpage", "GeneXus.Programs.masterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA1W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1W2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2022102021352036", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wptablerocreartarea.aspx") + "?" + UrlEncode(AV15TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV35TrGestionTableros_Nombre)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV36TrGestionTableros_FechaInicio)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV37TrGestionTableros_FechaFin))+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vTRCOMENTARIOTAREA_SDT", GetSecureSignedToken( "", AV41TrComentarioTarea_SDT, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV15TrGestionTableros_ID, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONTAREAS_SDT", AV40GestionTareas_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONTAREAS_SDT", AV40GestionTareas_SDT);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRCOMENTARIOTAREA_SDT", AV41TrComentarioTarea_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRCOMENTARIOTAREA_SDT", AV41TrComentarioTarea_SDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRCOMENTARIOTAREA_SDT", GetSecureSignedToken( "", AV41TrComentarioTarea_SDT, context));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((String)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE1W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1W2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("wptablerocreartarea.aspx") + "?" + UrlEncode(AV15TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV35TrGestionTableros_Nombre)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV36TrGestionTableros_FechaInicio)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV37TrGestionTableros_FechaFin)) ;
      }

      public override String GetPgmname( )
      {
         return "WpTableroCrearTarea" ;
      }

      public override String GetPgmdesc( )
      {
         return "Tareas del tablero" ;
      }

      protected void WB1W0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Gestión de tarea", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpTableroCrearTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "h1");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WebPanelDesignerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Crear nueva tarea", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_group_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_attributes_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TabularContentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_id_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_idfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_id_var_lefttext_Internalname, "ID : ", "", "", lblTrgestiontableros_id_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_id_Internalname, AV15TrGestionTableros_ID.ToString(), AV15TrGestionTableros_ID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_id_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontableros_id_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_WpTableroCrearTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_nombre_var_lefttext_Internalname, "Nombre de tablero : ", "", "", lblTrgestiontableros_nombre_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_nombre_Internalname, StringUtil.RTrim( AV35TrGestionTableros_Nombre), StringUtil.RTrim( context.localUtil.Format( AV35TrGestionTableros_Nombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontableros_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpTableroCrearTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_fechainicio_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_fechainiciofieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_fechainicio_var_lefttext_Internalname, "Fecha de inicio : ", "", "", lblTrgestiontableros_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontableros_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechainicio_Internalname, context.localUtil.Format(AV36TrGestionTableros_FechaInicio, "99/99/9999"), context.localUtil.Format( AV36TrGestionTableros_FechaInicio, "99/99/9999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpTableroCrearTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpTableroCrearTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTrgestiontableros_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontableros_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechafin_Internalname, context.localUtil.Format(AV37TrGestionTableros_FechaFin, "99/99/9999"), context.localUtil.Format( AV37TrGestionTableros_FechaFin, "99/99/9999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpTableroCrearTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpTableroCrearTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroup1_Internalname, "Ingresar datos", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_group1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_attributes1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TabularContentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_nombre_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_nombrefieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_nombre_var_lefttext_Internalname, "Nombre de tarea : ", "", "", lblTrgestiontareas_nombre_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_nombre_Internalname, StringUtil.RTrim( AV32TrGestionTareas_Nombre), StringUtil.RTrim( context.localUtil.Format( AV32TrGestionTareas_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontareas_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpTableroCrearTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_descripcion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_descripcionfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_descripcion_var_lefttext_Internalname, "Descripcion : ", "", "", lblTrgestiontareas_descripcion_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTrgestiontareas_descripcion_Internalname, AV34TrGestionTareas_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", 0, 1, edtavTrgestiontareas_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpTableroCrearTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_fechainicio_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_fechainiciofieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechainicio_var_lefttext_Internalname, "Fecha de inicio : ", "", "", lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontareas_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_fechainicio_Internalname, context.localUtil.Format(AV38TrGestionTareas_FechaInicio, "99/99/9999"), context.localUtil.Format( AV38TrGestionTareas_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontareas_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpTableroCrearTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontareas_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontareas_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpTableroCrearTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_fechafin_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_fechafinfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTrgestiontareas_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpTableroCrearTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontareas_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_fechafin_Internalname, context.localUtil.Format(AV39TrGestionTareas_FechaFin, "99/99/9999"), context.localUtil.Format( AV39TrGestionTareas_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontareas_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpTableroCrearTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontareas_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontareas_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpTableroCrearTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_90_1W2( true) ;
         }
         else
         {
            wb_table1_90_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table1_90_1W2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1W2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
            }
            Form.Meta.addItem("description", "Tareas del tablero", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1W0( ) ;
      }

      protected void WS1W2( )
      {
         START1W2( ) ;
         EVT1W2( ) ;
      }

      protected void EVT1W2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E111W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E121W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CREARTAREA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_CrearTarea' */
                              E131W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E141W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1W2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA1W2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavTrgestiontareas_nombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTrgestiontableros_id_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_id_Enabled), 5, 0), true);
         edtavTrgestiontableros_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_nombre_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechainicio_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechafin_Enabled), 5, 0), true);
      }

      protected void RF1W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E121W2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E141W2 ();
            WB1W0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1W2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRCOMENTARIOTAREA_SDT", AV41TrComentarioTarea_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRCOMENTARIOTAREA_SDT", AV41TrComentarioTarea_SDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRCOMENTARIOTAREA_SDT", GetSecureSignedToken( "", AV41TrComentarioTarea_SDT, context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavTrgestiontableros_id_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_id_Enabled), 5, 0), true);
         edtavTrgestiontableros_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_nombre_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechainicio_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechafin_Enabled), 5, 0), true);
      }

      protected void STRUP1W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV32TrGestionTareas_Nombre = cgiGet( edtavTrgestiontareas_nombre_Internalname);
            AssignAttri("", false, "AV32TrGestionTareas_Nombre", AV32TrGestionTareas_Nombre);
            AV34TrGestionTareas_Descripcion = cgiGet( edtavTrgestiontareas_descripcion_Internalname);
            AssignAttri("", false, "AV34TrGestionTareas_Descripcion", AV34TrGestionTareas_Descripcion);
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Inicio"}), 1, "vTRGESTIONTAREAS_FECHAINICIO");
               GX_FocusControl = edtavTrgestiontareas_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV38TrGestionTareas_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV38TrGestionTareas_FechaInicio", context.localUtil.Format(AV38TrGestionTareas_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV38TrGestionTareas_FechaInicio = context.localUtil.CToD( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 1);
               AssignAttri("", false, "AV38TrGestionTareas_FechaInicio", context.localUtil.Format(AV38TrGestionTareas_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Fin"}), 1, "vTRGESTIONTAREAS_FECHAFIN");
               GX_FocusControl = edtavTrgestiontareas_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39TrGestionTareas_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV39TrGestionTareas_FechaFin", context.localUtil.Format(AV39TrGestionTareas_FechaFin, "99/99/9999"));
            }
            else
            {
               AV39TrGestionTareas_FechaFin = context.localUtil.CToD( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 1);
               AssignAttri("", false, "AV39TrGestionTareas_FechaFin", context.localUtil.Format(AV39TrGestionTareas_FechaFin, "99/99/9999"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E111W2 ();
         if (returnInSub) return;
      }

      protected void E111W2( )
      {
         /* Start Routine */
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E121W2( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E131W2( )
      {
         /* 'E_CrearTarea' Routine */
         /* Execute user subroutine: 'U_CREARTAREA' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40GestionTareas_SDT", AV40GestionTareas_SDT);
      }

      protected void S142( )
      {
         /* 'U_CREARTAREA' Routine */
         AV40GestionTareas_SDT.gxTpr_Trgestiontareas_idtablero = (Guid)(AV15TrGestionTableros_ID);
         AV40GestionTareas_SDT.gxTpr_Trgestiontareas_nombre = AV32TrGestionTareas_Nombre;
         AV40GestionTareas_SDT.gxTpr_Trgestiontareas_descripcion = AV34TrGestionTareas_Descripcion;
         AV40GestionTareas_SDT.gxTpr_Trgestiontareas_fechainicio = AV38TrGestionTareas_FechaInicio;
         AV40GestionTareas_SDT.gxTpr_Trgestiontareas_fechafin = AV39TrGestionTareas_FechaFin;
         new prgestionesdetareas(context ).execute(  AV40GestionTareas_SDT,  AV41TrComentarioTarea_SDT,  "INS") ;
      }

      protected void nextLoad( )
      {
      }

      protected void E141W2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_90_1W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreartarea_Internalname, "", "Crear Tarea", bttCreartarea_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CREARTAREA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpTableroCrearTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_90_1W2e( true) ;
         }
         else
         {
            wb_table1_90_1W2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15TrGestionTableros_ID = (Guid)((Guid)getParm(obj,0));
         AssignAttri("", false, "AV15TrGestionTableros_ID", AV15TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV15TrGestionTableros_ID, context));
         AV35TrGestionTableros_Nombre = (String)getParm(obj,1);
         AssignAttri("", false, "AV35TrGestionTableros_Nombre", AV35TrGestionTableros_Nombre);
         AV36TrGestionTableros_FechaInicio = (DateTime)getParm(obj,2);
         AssignAttri("", false, "AV36TrGestionTableros_FechaInicio", context.localUtil.Format(AV36TrGestionTableros_FechaInicio, "99/99/9999"));
         AV37TrGestionTableros_FechaFin = (DateTime)getParm(obj,3);
         AssignAttri("", false, "AV37TrGestionTableros_FechaFin", context.localUtil.Format(AV37TrGestionTableros_FechaFin, "99/99/9999"));
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA1W2( ) ;
         WS1W2( ) ;
         WE1W2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("K2BControlBeautify/montrezorro-bootstrap-checkbox/css/bootstrap-checkbox.css", "");
         AddStyleSheetFile("K2BControlBeautify/silviomoreto-bootstrap-select/dist/css/bootstrap-select.css", "");
         AddStyleSheetFile("K2BControlBeautify/toastr-master/toastr.min.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?2022102021352069", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wptablerocreartarea.js", "?2022102021352069", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divSection2_Internalname = "SECTION2";
         divTable1_Internalname = "TABLE1";
         lblTrgestiontableros_id_var_lefttext_Internalname = "TRGESTIONTABLEROS_ID_VAR_LEFTTEXT";
         edtavTrgestiontableros_id_Internalname = "vTRGESTIONTABLEROS_ID";
         lblTrgestiontableros_nombre_var_lefttext_Internalname = "TRGESTIONTABLEROS_NOMBRE_VAR_LEFTTEXT";
         edtavTrgestiontableros_nombre_Internalname = "vTRGESTIONTABLEROS_NOMBRE";
         divTable_container_trgestiontableros_idfieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_IDFIELDCONTAINER";
         divTable_container_trgestiontableros_id_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_ID";
         lblTrgestiontableros_fechainicio_var_lefttext_Internalname = "TRGESTIONTABLEROS_FECHAINICIO_VAR_LEFTTEXT";
         edtavTrgestiontableros_fechainicio_Internalname = "vTRGESTIONTABLEROS_FECHAINICIO";
         lblTrgestiontableros_fechafin_var_lefttext_Internalname = "TRGESTIONTABLEROS_FECHAFIN_VAR_LEFTTEXT";
         edtavTrgestiontableros_fechafin_Internalname = "vTRGESTIONTABLEROS_FECHAFIN";
         divTable_container_trgestiontableros_fechainiciofieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_FECHAINICIOFIELDCONTAINER";
         divTable_container_trgestiontableros_fechainicio_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_FECHAINICIO";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         lblTrgestiontareas_nombre_var_lefttext_Internalname = "TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT";
         edtavTrgestiontareas_nombre_Internalname = "vTRGESTIONTAREAS_NOMBRE";
         divTable_container_trgestiontareas_nombrefieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_NOMBREFIELDCONTAINER";
         divTable_container_trgestiontareas_nombre_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_NOMBRE";
         lblTrgestiontareas_descripcion_var_lefttext_Internalname = "TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT";
         edtavTrgestiontareas_descripcion_Internalname = "vTRGESTIONTAREAS_DESCRIPCION";
         divTable_container_trgestiontareas_descripcionfieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_DESCRIPCIONFIELDCONTAINER";
         divTable_container_trgestiontareas_descripcion_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_DESCRIPCION";
         lblTrgestiontareas_fechainicio_var_lefttext_Internalname = "TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT";
         edtavTrgestiontareas_fechainicio_Internalname = "vTRGESTIONTAREAS_FECHAINICIO";
         divTable_container_trgestiontareas_fechainiciofieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAINICIOFIELDCONTAINER";
         divTable_container_trgestiontareas_fechainicio_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAINICIO";
         lblTrgestiontareas_fechafin_var_lefttext_Internalname = "TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT";
         edtavTrgestiontareas_fechafin_Internalname = "vTRGESTIONTAREAS_FECHAFIN";
         divTable_container_trgestiontareas_fechafinfieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAFINFIELDCONTAINER";
         divTable_container_trgestiontareas_fechafin_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAFIN";
         divAttributescontainertable_attributes1_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES1";
         divResponsivetable_mainattributes_attributes1_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1";
         divMaingroupresponsivetable_group1_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP1";
         grpGroup1_Internalname = "GROUP1";
         bttCreartarea_Internalname = "CREARTAREA";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavTrgestiontareas_fechafin_Jsonclick = "";
         edtavTrgestiontareas_fechafin_Enabled = 1;
         edtavTrgestiontareas_fechainicio_Jsonclick = "";
         edtavTrgestiontareas_fechainicio_Enabled = 1;
         edtavTrgestiontareas_descripcion_Enabled = 1;
         edtavTrgestiontareas_nombre_Jsonclick = "";
         edtavTrgestiontareas_nombre_Enabled = 1;
         edtavTrgestiontableros_fechafin_Jsonclick = "";
         edtavTrgestiontableros_fechafin_Enabled = 0;
         edtavTrgestiontableros_fechainicio_Jsonclick = "";
         edtavTrgestiontableros_fechainicio_Enabled = 0;
         edtavTrgestiontableros_nombre_Jsonclick = "";
         edtavTrgestiontableros_nombre_Enabled = 0;
         edtavTrgestiontableros_id_Jsonclick = "";
         edtavTrgestiontableros_id_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Tareas del tablero";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV41TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true},{av:'AV15TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'E_CREARTAREA'","{handler:'E131W2',iparms:[{av:'AV15TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'AV40GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV32TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV34TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV38TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV39TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'AV41TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'E_CREARTAREA'",",oparms:[{av:'AV40GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''}]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAINICIO","{handler:'Validv_Trgestiontareas_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAFIN","{handler:'Validv_Trgestiontareas_fechafin',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAFIN",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         wcpOAV15TrGestionTableros_ID = (Guid)(Guid.Empty);
         wcpOAV35TrGestionTableros_Nombre = "";
         wcpOAV36TrGestionTableros_FechaInicio = DateTime.MinValue;
         wcpOAV37TrGestionTableros_FechaFin = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV41TrComentarioTarea_SDT = new SdtTrComentarioTarea_SDT(context);
         GXKey = "";
         AV40GestionTareas_SDT = new SdtGestionTareas_SDT(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTrgestiontableros_id_var_lefttext_Jsonclick = "";
         lblTrgestiontableros_nombre_var_lefttext_Jsonclick = "";
         lblTrgestiontableros_fechainicio_var_lefttext_Jsonclick = "";
         lblTrgestiontableros_fechafin_var_lefttext_Jsonclick = "";
         lblTrgestiontareas_nombre_var_lefttext_Jsonclick = "";
         TempTags = "";
         AV32TrGestionTareas_Nombre = "";
         lblTrgestiontareas_descripcion_var_lefttext_Jsonclick = "";
         AV34TrGestionTareas_Descripcion = "";
         lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick = "";
         AV38TrGestionTareas_FechaInicio = DateTime.MinValue;
         lblTrgestiontareas_fechafin_var_lefttext_Jsonclick = "";
         AV39TrGestionTareas_FechaFin = DateTime.MinValue;
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         sStyleString = "";
         bttCreartarea_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTrgestiontableros_id_Enabled = 0;
         edtavTrgestiontableros_nombre_Enabled = 0;
         edtavTrgestiontableros_fechainicio_Enabled = 0;
         edtavTrgestiontableros_fechafin_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTrgestiontableros_id_Enabled ;
      private int edtavTrgestiontableros_nombre_Enabled ;
      private int edtavTrgestiontableros_fechainicio_Enabled ;
      private int edtavTrgestiontableros_fechafin_Enabled ;
      private int edtavTrgestiontareas_nombre_Enabled ;
      private int edtavTrgestiontareas_descripcion_Enabled ;
      private int edtavTrgestiontareas_fechainicio_Enabled ;
      private int edtavTrgestiontareas_fechafin_Enabled ;
      private int idxLst ;
      private String AV35TrGestionTableros_Nombre ;
      private String wcpOAV35TrGestionTableros_Nombre ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String divSection2_Internalname ;
      private String lblTitle_Internalname ;
      private String lblTitle_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String divContenttable_Internalname ;
      private String grpGroup_Internalname ;
      private String divMaingroupresponsivetable_group_Internalname ;
      private String divResponsivetable_mainattributes_attributes_Internalname ;
      private String divAttributescontainertable_attributes_Internalname ;
      private String divTable_container_trgestiontableros_id_Internalname ;
      private String divTable_container_trgestiontableros_idfieldcontainer_Internalname ;
      private String lblTrgestiontableros_id_var_lefttext_Internalname ;
      private String lblTrgestiontableros_id_var_lefttext_Jsonclick ;
      private String edtavTrgestiontableros_id_Internalname ;
      private String edtavTrgestiontableros_id_Jsonclick ;
      private String lblTrgestiontableros_nombre_var_lefttext_Internalname ;
      private String lblTrgestiontableros_nombre_var_lefttext_Jsonclick ;
      private String edtavTrgestiontableros_nombre_Internalname ;
      private String edtavTrgestiontableros_nombre_Jsonclick ;
      private String divTable_container_trgestiontableros_fechainicio_Internalname ;
      private String divTable_container_trgestiontableros_fechainiciofieldcontainer_Internalname ;
      private String lblTrgestiontableros_fechainicio_var_lefttext_Internalname ;
      private String lblTrgestiontableros_fechainicio_var_lefttext_Jsonclick ;
      private String edtavTrgestiontableros_fechainicio_Internalname ;
      private String edtavTrgestiontableros_fechainicio_Jsonclick ;
      private String lblTrgestiontableros_fechafin_var_lefttext_Internalname ;
      private String lblTrgestiontableros_fechafin_var_lefttext_Jsonclick ;
      private String edtavTrgestiontableros_fechafin_Internalname ;
      private String edtavTrgestiontableros_fechafin_Jsonclick ;
      private String grpGroup1_Internalname ;
      private String divMaingroupresponsivetable_group1_Internalname ;
      private String divResponsivetable_mainattributes_attributes1_Internalname ;
      private String divAttributescontainertable_attributes1_Internalname ;
      private String divTable_container_trgestiontareas_nombre_Internalname ;
      private String divTable_container_trgestiontareas_nombrefieldcontainer_Internalname ;
      private String lblTrgestiontareas_nombre_var_lefttext_Internalname ;
      private String lblTrgestiontareas_nombre_var_lefttext_Jsonclick ;
      private String TempTags ;
      private String edtavTrgestiontareas_nombre_Internalname ;
      private String AV32TrGestionTareas_Nombre ;
      private String edtavTrgestiontareas_nombre_Jsonclick ;
      private String divTable_container_trgestiontareas_descripcion_Internalname ;
      private String divTable_container_trgestiontareas_descripcionfieldcontainer_Internalname ;
      private String lblTrgestiontareas_descripcion_var_lefttext_Internalname ;
      private String lblTrgestiontareas_descripcion_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_descripcion_Internalname ;
      private String divTable_container_trgestiontareas_fechainicio_Internalname ;
      private String divTable_container_trgestiontareas_fechainiciofieldcontainer_Internalname ;
      private String lblTrgestiontareas_fechainicio_var_lefttext_Internalname ;
      private String lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_fechainicio_Internalname ;
      private String edtavTrgestiontareas_fechainicio_Jsonclick ;
      private String divTable_container_trgestiontareas_fechafin_Internalname ;
      private String divTable_container_trgestiontareas_fechafinfieldcontainer_Internalname ;
      private String lblTrgestiontareas_fechafin_var_lefttext_Internalname ;
      private String lblTrgestiontareas_fechafin_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_fechafin_Internalname ;
      private String edtavTrgestiontareas_fechafin_Jsonclick ;
      private String divResponsivetable_containernode_actions_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sStyleString ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String bttCreartarea_Internalname ;
      private String bttCreartarea_Jsonclick ;
      private DateTime AV36TrGestionTableros_FechaInicio ;
      private DateTime AV37TrGestionTableros_FechaFin ;
      private DateTime wcpOAV36TrGestionTableros_FechaInicio ;
      private DateTime wcpOAV37TrGestionTableros_FechaFin ;
      private DateTime AV38TrGestionTareas_FechaInicio ;
      private DateTime AV39TrGestionTareas_FechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV34TrGestionTareas_Descripcion ;
      private Guid AV15TrGestionTableros_ID ;
      private Guid wcpOAV15TrGestionTableros_ID ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtGestionTareas_SDT AV40GestionTareas_SDT ;
      private SdtTrComentarioTarea_SDT AV41TrComentarioTarea_SDT ;
   }

}
