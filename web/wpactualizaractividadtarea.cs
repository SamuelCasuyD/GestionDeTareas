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
   public class wpactualizaractividadtarea : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpactualizaractividadtarea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpactualizaractividadtarea( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_TrActividades_ID ,
                           long aP1_TrActividades_IDTarea )
      {
         this.AV12TrActividades_ID = aP0_TrActividades_ID;
         this.AV13TrActividades_IDTarea = aP1_TrActividades_IDTarea;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTractividades_estado = new GXCombobox();
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
               AV12TrActividades_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV12TrActividades_ID", StringUtil.LTrimStr( (decimal)(AV12TrActividades_ID), 13, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13TrActividades_IDTarea = (long)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "AV13TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV13TrActividades_IDTarea), 13, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_IDTAREA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9"), context));
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
         PA2C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2C2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211744980", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 947160), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpactualizaractividadtarea.aspx") + "?" + UrlEncode("" +AV12TrActividades_ID) + "," + UrlEncode("" +AV13TrActividades_IDTarea)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_IDTAREA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_IDTAREA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TrActividades_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_NOMBRE", StringUtil.RTrim( A27TrActividades_Nombre));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_DESCRIPCION", A28TrActividades_Descripcion);
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_FECHAFIN", context.localUtil.DToC( A30TrActividades_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_FECHAINICIO", context.localUtil.DToC( A29TrActividades_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33TrActividades_Estado), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONACTIVIDADES_SDT", AV19GestionActividades_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONACTIVIDADES_SDT", AV19GestionActividades_SDT);
         }
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
            WE2C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2C2( ) ;
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
         return formatLink("wpactualizaractividadtarea.aspx") + "?" + UrlEncode("" +AV12TrActividades_ID) + "," + UrlEncode("" +AV13TrActividades_IDTarea) ;
      }

      public override String GetPgmname( )
      {
         return "WpActualizarActividadTarea" ;
      }

      public override String GetPgmdesc( )
      {
         return "Actualizar Actividad" ;
      }

      protected void WB2C0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Editar actividad", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpActualizarActividadTarea.htm");
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Ingrese los datos solicitados", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpActualizarActividadTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tractividades_id_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTractividades_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12TrActividades_ID), 13, 0, ".", "")), ((edtavTractividades_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_id_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavTractividades_id_Visible, edtavTractividades_id_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Nímero de tarea : ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_idtarea_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTractividades_idtarea_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13TrActividades_IDTarea), 13, 0, ".", "")), ((edtavTractividades_idtarea_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_idtarea_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTractividades_idtarea_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_Internalname, "Nombre de la actividad : ", "", "", lblTextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_nombre_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTractividades_nombre_Internalname, StringUtil.RTrim( AV14TrActividades_Nombre), StringUtil.RTrim( context.localUtil.Format( AV14TrActividades_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTractividades_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Descripción", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_descripcion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTractividades_descripcion_Internalname, AV15TrActividades_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", 0, 1, edtavTractividades_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_fechainicio_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_fechainiciofieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_fechainicio_var_lefttext_Internalname, "Fecha de Inicio : ", "", "", lblTractividades_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarActividadTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTractividades_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTractividades_fechainicio_Internalname, context.localUtil.Format(AV16TrActividades_FechaInicio, "99/99/9999"), context.localUtil.Format( AV16TrActividades_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTractividades_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTractividades_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTractividades_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarActividadTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTractividades_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarActividadTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTractividades_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTractividades_fechafin_Internalname, context.localUtil.Format(AV17TrActividades_FechaFin, "99/99/9999"), context.localUtil.Format( AV17TrActividades_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTractividades_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTractividades_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTractividades_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarActividadTarea.htm");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Estado de la actividad : ", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, "HLP_WpActualizarActividadTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_estado_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTractividades_estado, cmbavTractividades_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0)), 1, cmbavTractividades_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTractividades_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, "HLP_WpActualizarActividadTarea.htm");
            cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
            AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", (String)(cmbavTractividades_estado.ToJavascriptSource()), true);
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
            wb_table1_79_2C2( true) ;
         }
         else
         {
            wb_table1_79_2C2( false) ;
         }
         return  ;
      }

      protected void wb_table1_79_2C2e( bool wbgen )
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

      protected void START2C2( )
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
            Form.Meta.addItem("description", "Actualizar Actividad", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2C0( ) ;
      }

      protected void WS2C2( )
      {
         START2C2( ) ;
         EVT2C2( ) ;
      }

      protected void EVT2C2( )
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
                              E112C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E122C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ACTUALIZARACTIVIDAD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_ActualizarActividad' */
                              E132C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E142C2 ();
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

      protected void WE2C2( )
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

      protected void PA2C2( )
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
               GX_FocusControl = edtavTractividades_nombre_Internalname;
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
         if ( cmbavTractividades_estado.ItemCount > 0 )
         {
            AV18TrActividades_Estado = (short)(NumberUtil.Val( cmbavTractividades_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV18TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV18TrActividades_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
            AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF2C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E122C2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E142C2 ();
            WB2C0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2C2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP2C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV14TrActividades_Nombre = cgiGet( edtavTractividades_nombre_Internalname);
            AssignAttri("", false, "AV14TrActividades_Nombre", AV14TrActividades_Nombre);
            AV15TrActividades_Descripcion = cgiGet( edtavTractividades_descripcion_Internalname);
            AssignAttri("", false, "AV15TrActividades_Descripcion", AV15TrActividades_Descripcion);
            if ( context.localUtil.VCDate( cgiGet( edtavTractividades_fechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Inicio"}), 1, "vTRACTIVIDADES_FECHAINICIO");
               GX_FocusControl = edtavTractividades_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16TrActividades_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV16TrActividades_FechaInicio", context.localUtil.Format(AV16TrActividades_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV16TrActividades_FechaInicio = context.localUtil.CToD( cgiGet( edtavTractividades_fechainicio_Internalname), 2);
               AssignAttri("", false, "AV16TrActividades_FechaInicio", context.localUtil.Format(AV16TrActividades_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTractividades_fechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Fin"}), 1, "vTRACTIVIDADES_FECHAFIN");
               GX_FocusControl = edtavTractividades_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17TrActividades_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV17TrActividades_FechaFin", context.localUtil.Format(AV17TrActividades_FechaFin, "99/99/9999"));
            }
            else
            {
               AV17TrActividades_FechaFin = context.localUtil.CToD( cgiGet( edtavTractividades_fechafin_Internalname), 2);
               AssignAttri("", false, "AV17TrActividades_FechaFin", context.localUtil.Format(AV17TrActividades_FechaFin, "99/99/9999"));
            }
            cmbavTractividades_estado.CurrentValue = cgiGet( cmbavTractividades_estado_Internalname);
            AV18TrActividades_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTractividades_estado_Internalname), "."));
            AssignAttri("", false, "AV18TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV18TrActividades_Estado), 4, 0));
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
         /* Using cursor H002C2 */
         pr_default.execute(0, new Object[] {AV12TrActividades_ID, AV13TrActividades_IDTarea});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A25TrActividades_IDTarea = H002C2_A25TrActividades_IDTarea[0];
            n25TrActividades_IDTarea = H002C2_n25TrActividades_IDTarea[0];
            A26TrActividades_ID = H002C2_A26TrActividades_ID[0];
            A27TrActividades_Nombre = H002C2_A27TrActividades_Nombre[0];
            n27TrActividades_Nombre = H002C2_n27TrActividades_Nombre[0];
            A28TrActividades_Descripcion = H002C2_A28TrActividades_Descripcion[0];
            n28TrActividades_Descripcion = H002C2_n28TrActividades_Descripcion[0];
            A30TrActividades_FechaFin = H002C2_A30TrActividades_FechaFin[0];
            n30TrActividades_FechaFin = H002C2_n30TrActividades_FechaFin[0];
            A29TrActividades_FechaInicio = H002C2_A29TrActividades_FechaInicio[0];
            n29TrActividades_FechaInicio = H002C2_n29TrActividades_FechaInicio[0];
            A33TrActividades_Estado = H002C2_A33TrActividades_Estado[0];
            n33TrActividades_Estado = H002C2_n33TrActividades_Estado[0];
            AV14TrActividades_Nombre = A27TrActividades_Nombre;
            AssignAttri("", false, "AV14TrActividades_Nombre", AV14TrActividades_Nombre);
            AV15TrActividades_Descripcion = A28TrActividades_Descripcion;
            AssignAttri("", false, "AV15TrActividades_Descripcion", AV15TrActividades_Descripcion);
            AV17TrActividades_FechaFin = A30TrActividades_FechaFin;
            AssignAttri("", false, "AV17TrActividades_FechaFin", context.localUtil.Format(AV17TrActividades_FechaFin, "99/99/9999"));
            AV16TrActividades_FechaInicio = A29TrActividades_FechaInicio;
            AssignAttri("", false, "AV16TrActividades_FechaInicio", context.localUtil.Format(AV16TrActividades_FechaInicio, "99/99/9999"));
            AV18TrActividades_Estado = A33TrActividades_Estado;
            AssignAttri("", false, "AV18TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV18TrActividades_Estado), 4, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
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
         E112C2 ();
         if (returnInSub) return;
      }

      protected void E112C2( )
      {
         /* Start Routine */
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E122C2( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         edtavTractividades_id_Visible = 0;
         AssignProp("", false, edtavTractividades_id_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTractividades_id_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
         AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
      }

      protected void E132C2( )
      {
         /* 'E_ActualizarActividad' Routine */
         /* Execute user subroutine: 'U_ACTUALIZARACTIVIDAD' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19GestionActividades_SDT", AV19GestionActividades_SDT);
      }

      protected void S142( )
      {
         /* 'U_ACTUALIZARACTIVIDAD' Routine */
         AV19GestionActividades_SDT.gxTpr_Tractividades_id = AV12TrActividades_ID;
         AV19GestionActividades_SDT.gxTpr_Tractividades_idtarea = AV13TrActividades_IDTarea;
         AV19GestionActividades_SDT.gxTpr_Tractividades_nombre = AV14TrActividades_Nombre;
         AV19GestionActividades_SDT.gxTpr_Tractividades_descripcion = AV15TrActividades_Descripcion;
         AV19GestionActividades_SDT.gxTpr_Tractividades_fechafin = AV17TrActividades_FechaFin;
         AV19GestionActividades_SDT.gxTpr_Tractividades_fechainicio = AV16TrActividades_FechaInicio;
         AV19GestionActividades_SDT.gxTpr_Tractividades_estado = AV18TrActividades_Estado;
         new prgestionaractividades(context ).execute(  AV19GestionActividades_SDT,  "UDP") ;
      }

      protected void nextLoad( )
      {
      }

      protected void E142C2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_79_2C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttActualizaractividad_Internalname, "", "Actualizar Actividad", bttActualizaractividad_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_ACTUALIZARACTIVIDAD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpActualizarActividadTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_79_2C2e( true) ;
         }
         else
         {
            wb_table1_79_2C2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12TrActividades_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12TrActividades_ID", StringUtil.LTrimStr( (decimal)(AV12TrActividades_ID), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
         AV13TrActividades_IDTarea = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV13TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV13TrActividades_IDTarea), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_IDTAREA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9"), context));
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
         PA2C2( ) ;
         WS2C2( ) ;
         WE2C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211745027", true, true);
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
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wpactualizaractividadtarea.js", "?202210211745027", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavTractividades_estado.Name = "vTRACTIVIDADES_ESTADO";
         cmbavTractividades_estado.WebTags = "";
         cmbavTractividades_estado.addItem("1", "Nuevo", 0);
         cmbavTractividades_estado.addItem("2", "En Progreso", 0);
         cmbavTractividades_estado.addItem("3", "Completado", 0);
         cmbavTractividades_estado.addItem("4", "Detenido", 0);
         cmbavTractividades_estado.addItem("5", "Pendiente", 0);
         if ( cmbavTractividades_estado.ItemCount > 0 )
         {
            AV18TrActividades_Estado = (short)(NumberUtil.Val( cmbavTractividades_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV18TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV18TrActividades_Estado), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divSection2_Internalname = "SECTION2";
         divTable1_Internalname = "TABLE1";
         edtavTractividades_id_Internalname = "vTRACTIVIDADES_ID";
         divTable_container_tractividades_id_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_ID";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtavTractividades_idtarea_Internalname = "vTRACTIVIDADES_IDTAREA";
         divTable_container_tractividades_idtarea_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_IDTAREA";
         lblTextblock_Internalname = "TEXTBLOCK";
         edtavTractividades_nombre_Internalname = "vTRACTIVIDADES_NOMBRE";
         divTable_container_tractividades_nombre_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_NOMBRE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavTractividades_descripcion_Internalname = "vTRACTIVIDADES_DESCRIPCION";
         divTable_container_tractividades_descripcion_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_DESCRIPCION";
         lblTractividades_fechainicio_var_lefttext_Internalname = "TRACTIVIDADES_FECHAINICIO_VAR_LEFTTEXT";
         edtavTractividades_fechainicio_Internalname = "vTRACTIVIDADES_FECHAINICIO";
         lblTractividades_fechafin_var_lefttext_Internalname = "TRACTIVIDADES_FECHAFIN_VAR_LEFTTEXT";
         edtavTractividades_fechafin_Internalname = "vTRACTIVIDADES_FECHAFIN";
         divTable_container_tractividades_fechainiciofieldcontainer_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_FECHAINICIOFIELDCONTAINER";
         divTable_container_tractividades_fechainicio_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_FECHAINICIO";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbavTractividades_estado_Internalname = "vTRACTIVIDADES_ESTADO";
         divTable_container_tractividades_estado_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_ESTADO";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         bttActualizaractividad_Internalname = "ACTUALIZARACTIVIDAD";
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
         cmbavTractividades_estado_Jsonclick = "";
         cmbavTractividades_estado.Enabled = 1;
         edtavTractividades_fechafin_Jsonclick = "";
         edtavTractividades_fechafin_Enabled = 1;
         edtavTractividades_fechainicio_Jsonclick = "";
         edtavTractividades_fechainicio_Enabled = 1;
         edtavTractividades_descripcion_Enabled = 1;
         edtavTractividades_nombre_Jsonclick = "";
         edtavTractividades_nombre_Enabled = 1;
         edtavTractividades_idtarea_Jsonclick = "";
         edtavTractividades_idtarea_Enabled = 0;
         edtavTractividades_id_Jsonclick = "";
         edtavTractividades_id_Enabled = 0;
         edtavTractividades_id_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Actualizar Actividad";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavTractividades_id_Visible',ctrl:'vTRACTIVIDADES_ID',prop:'Visible'},{av:'AV14TrActividades_Nombre',fld:'vTRACTIVIDADES_NOMBRE',pic:''},{av:'AV15TrActividades_Descripcion',fld:'vTRACTIVIDADES_DESCRIPCION',pic:''},{av:'AV17TrActividades_FechaFin',fld:'vTRACTIVIDADES_FECHAFIN',pic:''},{av:'AV16TrActividades_FechaInicio',fld:'vTRACTIVIDADES_FECHAINICIO',pic:''},{av:'cmbavTractividades_estado'},{av:'AV18TrActividades_Estado',fld:'vTRACTIVIDADES_ESTADO',pic:'ZZZ9'}]}");
         setEventMetadata("'E_ACTUALIZARACTIVIDAD'","{handler:'E132C2',iparms:[{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV19GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV14TrActividades_Nombre',fld:'vTRACTIVIDADES_NOMBRE',pic:''},{av:'AV15TrActividades_Descripcion',fld:'vTRACTIVIDADES_DESCRIPCION',pic:''},{av:'AV17TrActividades_FechaFin',fld:'vTRACTIVIDADES_FECHAFIN',pic:''},{av:'AV16TrActividades_FechaInicio',fld:'vTRACTIVIDADES_FECHAINICIO',pic:''},{av:'cmbavTractividades_estado'},{av:'AV18TrActividades_Estado',fld:'vTRACTIVIDADES_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("'E_ACTUALIZARACTIVIDAD'",",oparms:[{av:'AV19GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''}]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_ID","{handler:'Validv_Tractividades_id',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_ID",",oparms:[]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAINICIO","{handler:'Validv_Tractividades_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAFIN","{handler:'Validv_Tractividades_fechafin',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_ESTADO","{handler:'Validv_Tractividades_estado',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_ESTADO",",oparms:[]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A27TrActividades_Nombre = "";
         A28TrActividades_Descripcion = "";
         A30TrActividades_FechaFin = DateTime.MinValue;
         A29TrActividades_FechaInicio = DateTime.MinValue;
         AV19GestionActividades_SDT = new SdtGestionActividades_SDT(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock_Jsonclick = "";
         TempTags = "";
         AV14TrActividades_Nombre = "";
         lblTextblock1_Jsonclick = "";
         AV15TrActividades_Descripcion = "";
         lblTractividades_fechainicio_var_lefttext_Jsonclick = "";
         AV16TrActividades_FechaInicio = DateTime.MinValue;
         lblTractividades_fechafin_var_lefttext_Jsonclick = "";
         AV17TrActividades_FechaFin = DateTime.MinValue;
         lblTextblock3_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H002C2_A25TrActividades_IDTarea = new long[1] ;
         H002C2_n25TrActividades_IDTarea = new bool[] {false} ;
         H002C2_A26TrActividades_ID = new long[1] ;
         H002C2_A27TrActividades_Nombre = new String[] {""} ;
         H002C2_n27TrActividades_Nombre = new bool[] {false} ;
         H002C2_A28TrActividades_Descripcion = new String[] {""} ;
         H002C2_n28TrActividades_Descripcion = new bool[] {false} ;
         H002C2_A30TrActividades_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H002C2_n30TrActividades_FechaFin = new bool[] {false} ;
         H002C2_A29TrActividades_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H002C2_n29TrActividades_FechaInicio = new bool[] {false} ;
         H002C2_A33TrActividades_Estado = new short[1] ;
         H002C2_n33TrActividades_Estado = new bool[] {false} ;
         sStyleString = "";
         bttActualizaractividad_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpactualizaractividadtarea__default(),
            new Object[][] {
                new Object[] {
               H002C2_A25TrActividades_IDTarea, H002C2_n25TrActividades_IDTarea, H002C2_A26TrActividades_ID, H002C2_A27TrActividades_Nombre, H002C2_n27TrActividades_Nombre, H002C2_A28TrActividades_Descripcion, H002C2_n28TrActividades_Descripcion, H002C2_A30TrActividades_FechaFin, H002C2_n30TrActividades_FechaFin, H002C2_A29TrActividades_FechaInicio,
               H002C2_n29TrActividades_FechaInicio, H002C2_A33TrActividades_Estado, H002C2_n33TrActividades_Estado
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A33TrActividades_Estado ;
      private short wbEnd ;
      private short wbStart ;
      private short AV18TrActividades_Estado ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTractividades_id_Enabled ;
      private int edtavTractividades_id_Visible ;
      private int edtavTractividades_idtarea_Enabled ;
      private int edtavTractividades_nombre_Enabled ;
      private int edtavTractividades_descripcion_Enabled ;
      private int edtavTractividades_fechainicio_Enabled ;
      private int edtavTractividades_fechafin_Enabled ;
      private int idxLst ;
      private long AV12TrActividades_ID ;
      private long AV13TrActividades_IDTarea ;
      private long wcpOAV12TrActividades_ID ;
      private long wcpOAV13TrActividades_IDTarea ;
      private long A26TrActividades_ID ;
      private long A25TrActividades_IDTarea ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String A27TrActividades_Nombre ;
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
      private String divTable_container_tractividades_id_Internalname ;
      private String edtavTractividades_id_Internalname ;
      private String edtavTractividades_id_Jsonclick ;
      private String lblTextblock2_Internalname ;
      private String lblTextblock2_Jsonclick ;
      private String divTable_container_tractividades_idtarea_Internalname ;
      private String edtavTractividades_idtarea_Internalname ;
      private String edtavTractividades_idtarea_Jsonclick ;
      private String lblTextblock_Internalname ;
      private String lblTextblock_Jsonclick ;
      private String divTable_container_tractividades_nombre_Internalname ;
      private String TempTags ;
      private String edtavTractividades_nombre_Internalname ;
      private String AV14TrActividades_Nombre ;
      private String edtavTractividades_nombre_Jsonclick ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String divTable_container_tractividades_descripcion_Internalname ;
      private String edtavTractividades_descripcion_Internalname ;
      private String divTable_container_tractividades_fechainicio_Internalname ;
      private String divTable_container_tractividades_fechainiciofieldcontainer_Internalname ;
      private String lblTractividades_fechainicio_var_lefttext_Internalname ;
      private String lblTractividades_fechainicio_var_lefttext_Jsonclick ;
      private String edtavTractividades_fechainicio_Internalname ;
      private String edtavTractividades_fechainicio_Jsonclick ;
      private String lblTractividades_fechafin_var_lefttext_Internalname ;
      private String lblTractividades_fechafin_var_lefttext_Jsonclick ;
      private String edtavTractividades_fechafin_Internalname ;
      private String edtavTractividades_fechafin_Jsonclick ;
      private String lblTextblock3_Internalname ;
      private String lblTextblock3_Jsonclick ;
      private String divTable_container_tractividades_estado_Internalname ;
      private String cmbavTractividades_estado_Internalname ;
      private String cmbavTractividades_estado_Jsonclick ;
      private String divResponsivetable_containernode_actions_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String sStyleString ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String bttActualizaractividad_Internalname ;
      private String bttActualizaractividad_Jsonclick ;
      private DateTime A30TrActividades_FechaFin ;
      private DateTime A29TrActividades_FechaInicio ;
      private DateTime AV16TrActividades_FechaInicio ;
      private DateTime AV17TrActividades_FechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n25TrActividades_IDTarea ;
      private bool n27TrActividades_Nombre ;
      private bool n28TrActividades_Descripcion ;
      private bool n30TrActividades_FechaFin ;
      private bool n29TrActividades_FechaInicio ;
      private bool n33TrActividades_Estado ;
      private bool returnInSub ;
      private String A28TrActividades_Descripcion ;
      private String AV15TrActividades_Descripcion ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTractividades_estado ;
      private IDataStoreProvider pr_default ;
      private long[] H002C2_A25TrActividades_IDTarea ;
      private bool[] H002C2_n25TrActividades_IDTarea ;
      private long[] H002C2_A26TrActividades_ID ;
      private String[] H002C2_A27TrActividades_Nombre ;
      private bool[] H002C2_n27TrActividades_Nombre ;
      private String[] H002C2_A28TrActividades_Descripcion ;
      private bool[] H002C2_n28TrActividades_Descripcion ;
      private DateTime[] H002C2_A30TrActividades_FechaFin ;
      private bool[] H002C2_n30TrActividades_FechaFin ;
      private DateTime[] H002C2_A29TrActividades_FechaInicio ;
      private bool[] H002C2_n29TrActividades_FechaInicio ;
      private short[] H002C2_A33TrActividades_Estado ;
      private bool[] H002C2_n33TrActividades_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtGestionActividades_SDT AV19GestionActividades_SDT ;
   }

   public class wpactualizaractividadtarea__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002C2 ;
          prmH002C2 = new Object[] {
          new Object[] {"@AV12TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV13TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002C2", "SELECT [TrActividades_IDTarea], [TrActividades_ID], [TrActividades_Nombre], [TrActividades_Descripcion], [TrActividades_FechaFin], [TrActividades_FechaInicio], [TrActividades_Estado] FROM TABLERO.[TrActividades] WHERE ([TrActividades_ID] = @AV12TrActividades_ID) AND ([TrActividades_IDTarea] = @AV13TrActividades_IDTarea) ORDER BY [TrActividades_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002C2,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2) ;
                ((String[]) buf[3])[0] = rslt.getString(3, 100) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                return;
       }
    }

 }

}
