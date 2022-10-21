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
   public class trgestiontablerostrgestiontareaswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public trgestiontablerostrgestiontareaswc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
      }

      public trgestiontablerostrgestiontareaswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( Guid aP0_TrGestionTareas_IDTablero )
      {
         this.AV6TrGestionTareas_IDTablero = aP0_TrGestionTareas_IDTablero;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( String sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkavAtt_trgestiontareas_id_visible = new GXCheckbox();
         chkavAtt_trgestiontareas_nombre_visible = new GXCheckbox();
         chkavAtt_trgestiontareas_descripcion_visible = new GXCheckbox();
         chkavAtt_trgestiontareas_fechainicio_visible = new GXCheckbox();
         chkavAtt_trgestiontareas_fechafin_visible = new GXCheckbox();
         chkavAtt_trgestiontareas_fechacreacion_visible = new GXCheckbox();
         chkavAtt_trgestiontareas_fechamodificacion_visible = new GXCheckbox();
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetNextPar( );
                  sSFPrefix = GetNextPar( );
                  AV6TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
                  AssignAttri(sPrefix, false, "AV6TrGestionTareas_IDTablero", AV6TrGestionTareas_IDTablero.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(Guid)AV6TrGestionTareas_IDTablero});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_106 = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  nGXsfl_106_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  sGXsfl_106_idx = GetNextPar( );
                  sPrefix = GetNextPar( );
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGrid_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  subGrid_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AV6TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
                  AV41OrderedBy = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  AV9CurrentPage = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AV53Pgmname = GetNextPar( );
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridColumns);
                  AV13Att_TrGestionTareas_ID_Visible = StringUtil.StrToBool( GetNextPar( ));
                  AV14Att_TrGestionTareas_Nombre_Visible = StringUtil.StrToBool( GetNextPar( ));
                  AV15Att_TrGestionTareas_Descripcion_Visible = StringUtil.StrToBool( GetNextPar( ));
                  AV16Att_TrGestionTareas_FechaInicio_Visible = StringUtil.StrToBool( GetNextPar( ));
                  AV17Att_TrGestionTareas_FechaFin_Visible = StringUtil.StrToBool( GetNextPar( ));
                  AV18Att_TrGestionTareas_FechaCreacion_Visible = StringUtil.StrToBool( GetNextPar( ));
                  AV19Att_TrGestionTareas_FechaModificacion_Visible = StringUtil.StrToBool( GetNextPar( ));
                  sPrefix = GetNextPar( );
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV6TrGestionTareas_IDTablero, AV41OrderedBy, AV9CurrentPage, AV53Pgmname, AV11GridColumns, AV13Att_TrGestionTareas_ID_Visible, AV14Att_TrGestionTareas_Nombre_Visible, AV15Att_TrGestionTareas_Descripcion_Visible, AV16Att_TrGestionTareas_FechaInicio_Visible, AV17Att_TrGestionTareas_FechaFin_Visible, AV18Att_TrGestionTareas_FechaCreacion_Visible, AV19Att_TrGestionTareas_FechaModificacion_Visible, sPrefix) ;
                  AddString( context.getJSONResponse( )) ;
                  return  ;
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
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA1T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV53Pgmname = "TrGestionTablerosTrGestionTareasWC";
               context.Gx_err = 0;
               WS1T2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Tr Gestion Tareas") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2022102010595410", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trgestiontablerostrgestiontareaswc.aspx") + "?" + UrlEncode(AV6TrGestionTareas_IDTablero.ToString())+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( ) ;
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_106", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_106), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDORDERS", AV42GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDORDERS", AV42GridOrders);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6TrGestionTareas_IDTablero", wcpOAV6TrGestionTareas_IDTablero.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTRGESTIONTAREAS_IDTABLERO", AV6TrGestionTareas_IDTablero.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDCOLUMNS", AV11GridColumns);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDCOLUMNS", AV11GridColumns);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BORDERBYUSERCONTROL_Gridcontrolname", StringUtil.RTrim( K2borderbyusercontrol_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, sPrefix+"REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm1T2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("trgestiontablerostrgestiontareaswc.js", "?2022102010595416", false, true);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", "notset");
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override String GetPgmname( )
      {
         return "TrGestionTablerosTrGestionTareasWC" ;
      }

      public override String GetPgmdesc( )
      {
         return "Tr Gestion Tareas" ;
      }

      protected void WB1T0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trgestiontablerostrgestiontareaswc.aspx");
               context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SubWorkWithContentTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable10_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_18_1T2( true) ;
         }
         else
         {
            wb_table1_18_1T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_18_1T2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, divGlobalgridtable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingridcontainergrid_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"106\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(127), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTareas_ID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Gestion Tareas_ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTareas_Nombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Gestion Tareas_Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTareas_Descripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Gestion Tareas_Descripcion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTareas_FechaInicio_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Tareas_Fecha Inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTareas_FechaFin_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Tareas_Fecha Fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTareas_FechaCreacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Tareas_Fecha Creacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTareas_FechaModificacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Tareas_Fecha Modificacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "Grid_WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", sPrefix);
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTareas_ID_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A13TrGestionTareas_Nombre));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTareas_Nombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A14TrGestionTareas_Descripcion);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTareas_Descripcion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTareas_FechaInicio_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTareas_FechaFin_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A17TrGestionTareas_FechaCreacion, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTareas_FechaCreacion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A18TrGestionTareas_FechaModificacion, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTareas_FechaModificacion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 106 )
         {
            wbEnd = 0;
            nRC_GXsfl_106 = (int)(nGXsfl_106_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_116_1T2( true) ;
         }
         else
         {
            wb_table2_116_1T2( false) ;
         }
         return  ;
      }

      protected void wb_table2_116_1T2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection8_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            wb_table3_126_1T2( true) ;
         }
         else
         {
            wb_table3_126_1T2( false) ;
         }
         return  ;
      }

      protected void wb_table3_126_1T2e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolsabstracthiddenitemsgrid_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV42GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV44UC_OrderedBy);
            ucK2borderbyusercontrol.Render(context, "k2borderby", K2borderbyusercontrol_Internalname, sPrefix+"K2BORDERBYUSERCONTROLContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 106 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1T2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
               }
               Form.Meta.addItem("description", "Tr Gestion Tareas", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP1T0( ) ;
            }
         }
      }

      protected void WS1T2( )
      {
         START1T2( ) ;
         EVT1T2( ) ;
      }

      protected void EVT1T2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E111T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E121T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings' */
                                    E131T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFirst' */
                                    E141T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrevious' */
                                    E151T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E161T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoLast' */
                                    E171T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavAtt_trgestiontareas_id_visible_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1T0( ) ;
                              }
                              nGXsfl_106_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
                              SubsflControlProps_1062( ) ;
                              A12TrGestionTareas_ID = (long)(context.localUtil.CToN( cgiGet( edtTrGestionTareas_ID_Internalname), ".", ","));
                              A13TrGestionTareas_Nombre = cgiGet( edtTrGestionTareas_Nombre_Internalname);
                              n13TrGestionTareas_Nombre = false;
                              A14TrGestionTareas_Descripcion = cgiGet( edtTrGestionTareas_Descripcion_Internalname);
                              n14TrGestionTareas_Descripcion = false;
                              A15TrGestionTareas_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTareas_FechaInicio_Internalname), 0));
                              n15TrGestionTareas_FechaInicio = false;
                              A16TrGestionTareas_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTareas_FechaFin_Internalname), 0));
                              n16TrGestionTareas_FechaFin = false;
                              A17TrGestionTareas_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTareas_FechaCreacion_Internalname), 0));
                              n17TrGestionTareas_FechaCreacion = false;
                              A18TrGestionTareas_FechaModificacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTareas_FechaModificacion_Internalname), 0));
                              n18TrGestionTareas_FechaModificacion = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavAtt_trgestiontareas_id_visible_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E181T2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavAtt_trgestiontareas_id_visible_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E191T2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavAtt_trgestiontareas_id_visible_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E201T2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavAtt_trgestiontareas_id_visible_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E211T2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP1T0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavAtt_trgestiontareas_id_visible_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1T2( ) ;
            }
         }
      }

      protected void PA1T2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1062( ) ;
         while ( nGXsfl_106_idx <= nRC_GXsfl_106 )
         {
            sendrow_1062( ) ;
            nGXsfl_106_idx = ((subGrid_Islastpage==1)&&(nGXsfl_106_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_idx+1);
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1062( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       Guid AV6TrGestionTareas_IDTablero ,
                                       short AV41OrderedBy ,
                                       int AV9CurrentPage ,
                                       String AV53Pgmname ,
                                       GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV11GridColumns ,
                                       bool AV13Att_TrGestionTareas_ID_Visible ,
                                       bool AV14Att_TrGestionTareas_Nombre_Visible ,
                                       bool AV15Att_TrGestionTareas_Descripcion_Visible ,
                                       bool AV16Att_TrGestionTareas_FechaInicio_Visible ,
                                       bool AV17Att_TrGestionTareas_FechaFin_Visible ,
                                       bool AV18Att_TrGestionTareas_FechaCreacion_Visible ,
                                       bool AV19Att_TrGestionTareas_FechaModificacion_Visible ,
                                       String sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E191T2 ();
         GRID_nCurrentRecord = 0;
         RF1T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         AV13Att_TrGestionTareas_ID_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV13Att_TrGestionTareas_ID_Visible));
         AssignAttri(sPrefix, false, "AV13Att_TrGestionTareas_ID_Visible", AV13Att_TrGestionTareas_ID_Visible);
         AV14Att_TrGestionTareas_Nombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_TrGestionTareas_Nombre_Visible));
         AssignAttri(sPrefix, false, "AV14Att_TrGestionTareas_Nombre_Visible", AV14Att_TrGestionTareas_Nombre_Visible);
         AV15Att_TrGestionTareas_Descripcion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_TrGestionTareas_Descripcion_Visible));
         AssignAttri(sPrefix, false, "AV15Att_TrGestionTareas_Descripcion_Visible", AV15Att_TrGestionTareas_Descripcion_Visible);
         AV16Att_TrGestionTareas_FechaInicio_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_TrGestionTareas_FechaInicio_Visible));
         AssignAttri(sPrefix, false, "AV16Att_TrGestionTareas_FechaInicio_Visible", AV16Att_TrGestionTareas_FechaInicio_Visible);
         AV17Att_TrGestionTareas_FechaFin_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_TrGestionTareas_FechaFin_Visible));
         AssignAttri(sPrefix, false, "AV17Att_TrGestionTareas_FechaFin_Visible", AV17Att_TrGestionTareas_FechaFin_Visible);
         AV18Att_TrGestionTareas_FechaCreacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_TrGestionTareas_FechaCreacion_Visible));
         AssignAttri(sPrefix, false, "AV18Att_TrGestionTareas_FechaCreacion_Visible", AV18Att_TrGestionTareas_FechaCreacion_Visible);
         AV19Att_TrGestionTareas_FechaModificacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_TrGestionTareas_FechaModificacion_Visible));
         AssignAttri(sPrefix, false, "AV19Att_TrGestionTareas_FechaModificacion_Visible", AV19Att_TrGestionTareas_FechaModificacion_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV20GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri(sPrefix, false, "AV20GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV20GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E191T2 ();
         RF1T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV53Pgmname = "TrGestionTablerosTrGestionTareasWC";
         context.Gx_err = 0;
      }

      protected void RF1T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 106;
         E201T2 ();
         nGXsfl_106_idx = 1;
         sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
         SubsflControlProps_1062( ) ;
         bGXsfl_106_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "Grid_WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1062( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV41OrderedBy ,
                                                 AV6TrGestionTareas_IDTablero ,
                                                 A11TrGestionTareas_IDTablero } ,
                                                 new int[]{
                                                 TypeConstants.SHORT
                                                 }
            } ) ;
            /* Using cursor H001T2 */
            pr_default.execute(0, new Object[] {AV6TrGestionTareas_IDTablero, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_106_idx = 1;
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1062( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A11TrGestionTareas_IDTablero = (Guid)((Guid)(H001T2_A11TrGestionTareas_IDTablero[0]));
               A18TrGestionTareas_FechaModificacion = H001T2_A18TrGestionTareas_FechaModificacion[0];
               n18TrGestionTareas_FechaModificacion = H001T2_n18TrGestionTareas_FechaModificacion[0];
               A17TrGestionTareas_FechaCreacion = H001T2_A17TrGestionTareas_FechaCreacion[0];
               n17TrGestionTareas_FechaCreacion = H001T2_n17TrGestionTareas_FechaCreacion[0];
               A16TrGestionTareas_FechaFin = H001T2_A16TrGestionTareas_FechaFin[0];
               n16TrGestionTareas_FechaFin = H001T2_n16TrGestionTareas_FechaFin[0];
               A15TrGestionTareas_FechaInicio = H001T2_A15TrGestionTareas_FechaInicio[0];
               n15TrGestionTareas_FechaInicio = H001T2_n15TrGestionTareas_FechaInicio[0];
               A14TrGestionTareas_Descripcion = H001T2_A14TrGestionTareas_Descripcion[0];
               n14TrGestionTareas_Descripcion = H001T2_n14TrGestionTareas_Descripcion[0];
               A13TrGestionTareas_Nombre = H001T2_A13TrGestionTareas_Nombre[0];
               n13TrGestionTareas_Nombre = H001T2_n13TrGestionTareas_Nombre[0];
               A12TrGestionTareas_ID = H001T2_A12TrGestionTareas_ID[0];
               E211T2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 106;
            WB1T0( ) ;
         }
         bGXsfl_106_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1T2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV41OrderedBy ,
                                              AV6TrGestionTareas_IDTablero ,
                                              A11TrGestionTareas_IDTablero } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         } ) ;
         /* Using cursor H001T3 */
         pr_default.execute(1, new Object[] {AV6TrGestionTareas_IDTablero});
         GRID_nRecordCount = H001T3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6TrGestionTareas_IDTablero, AV41OrderedBy, AV9CurrentPage, AV53Pgmname, AV11GridColumns, AV13Att_TrGestionTareas_ID_Visible, AV14Att_TrGestionTareas_Nombre_Visible, AV15Att_TrGestionTareas_Descripcion_Visible, AV16Att_TrGestionTareas_FechaInicio_Visible, AV17Att_TrGestionTareas_FechaFin_Visible, AV18Att_TrGestionTareas_FechaCreacion_Visible, AV19Att_TrGestionTareas_FechaModificacion_Visible, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6TrGestionTareas_IDTablero, AV41OrderedBy, AV9CurrentPage, AV53Pgmname, AV11GridColumns, AV13Att_TrGestionTareas_ID_Visible, AV14Att_TrGestionTareas_Nombre_Visible, AV15Att_TrGestionTareas_Descripcion_Visible, AV16Att_TrGestionTareas_FechaInicio_Visible, AV17Att_TrGestionTareas_FechaFin_Visible, AV18Att_TrGestionTareas_FechaCreacion_Visible, AV19Att_TrGestionTareas_FechaModificacion_Visible, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6TrGestionTareas_IDTablero, AV41OrderedBy, AV9CurrentPage, AV53Pgmname, AV11GridColumns, AV13Att_TrGestionTareas_ID_Visible, AV14Att_TrGestionTareas_Nombre_Visible, AV15Att_TrGestionTareas_Descripcion_Visible, AV16Att_TrGestionTareas_FechaInicio_Visible, AV17Att_TrGestionTareas_FechaFin_Visible, AV18Att_TrGestionTareas_FechaCreacion_Visible, AV19Att_TrGestionTareas_FechaModificacion_Visible, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6TrGestionTareas_IDTablero, AV41OrderedBy, AV9CurrentPage, AV53Pgmname, AV11GridColumns, AV13Att_TrGestionTareas_ID_Visible, AV14Att_TrGestionTareas_Nombre_Visible, AV15Att_TrGestionTareas_Descripcion_Visible, AV16Att_TrGestionTareas_FechaInicio_Visible, AV17Att_TrGestionTareas_FechaFin_Visible, AV18Att_TrGestionTareas_FechaCreacion_Visible, AV19Att_TrGestionTareas_FechaModificacion_Visible, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6TrGestionTareas_IDTablero, AV41OrderedBy, AV9CurrentPage, AV53Pgmname, AV11GridColumns, AV13Att_TrGestionTareas_ID_Visible, AV14Att_TrGestionTareas_Nombre_Visible, AV15Att_TrGestionTareas_Descripcion_Visible, AV16Att_TrGestionTareas_FechaInicio_Visible, AV17Att_TrGestionTareas_FechaFin_Visible, AV18Att_TrGestionTareas_FechaCreacion_Visible, AV19Att_TrGestionTareas_FechaModificacion_Visible, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV53Pgmname = "TrGestionTablerosTrGestionTareasWC";
         context.Gx_err = 0;
      }

      protected void STRUP1T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E181T2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vGRIDORDERS"), AV42GridOrders);
            /* Read saved values. */
            nRC_GXsfl_106 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_106"), ".", ","));
            AV44UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vUC_ORDEREDBY"), ".", ","));
            wcpOAV6TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV6TrGestionTareas_IDTablero")));
            AV41OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vORDEREDBY"), ".", ","));
            AV6TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( sPrefix+"vTRGESTIONTAREAS_IDTABLERO")));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            K2borderbyusercontrol_Gridcontrolname = cgiGet( sPrefix+"K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"EXPORT_Visible"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV13Att_TrGestionTareas_ID_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontareas_id_visible_Internalname));
            AssignAttri(sPrefix, false, "AV13Att_TrGestionTareas_ID_Visible", AV13Att_TrGestionTareas_ID_Visible);
            AV14Att_TrGestionTareas_Nombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontareas_nombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV14Att_TrGestionTareas_Nombre_Visible", AV14Att_TrGestionTareas_Nombre_Visible);
            AV15Att_TrGestionTareas_Descripcion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontareas_descripcion_visible_Internalname));
            AssignAttri(sPrefix, false, "AV15Att_TrGestionTareas_Descripcion_Visible", AV15Att_TrGestionTareas_Descripcion_Visible);
            AV16Att_TrGestionTareas_FechaInicio_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontareas_fechainicio_visible_Internalname));
            AssignAttri(sPrefix, false, "AV16Att_TrGestionTareas_FechaInicio_Visible", AV16Att_TrGestionTareas_FechaInicio_Visible);
            AV17Att_TrGestionTareas_FechaFin_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontareas_fechafin_visible_Internalname));
            AssignAttri(sPrefix, false, "AV17Att_TrGestionTareas_FechaFin_Visible", AV17Att_TrGestionTareas_FechaFin_Visible);
            AV18Att_TrGestionTareas_FechaCreacion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontareas_fechacreacion_visible_Internalname));
            AssignAttri(sPrefix, false, "AV18Att_TrGestionTareas_FechaCreacion_Visible", AV18Att_TrGestionTareas_FechaCreacion_Visible);
            AV19Att_TrGestionTareas_FechaModificacion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontareas_fechamodificacion_visible_Internalname));
            AssignAttri(sPrefix, false, "AV19Att_TrGestionTareas_FechaModificacion_Visible", AV19Att_TrGestionTareas_FechaModificacion_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV20GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri(sPrefix, false, "AV20GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV20GridSettingsRowsPerPageVariable), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E181T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E181T2( )
      {
         /* Start Routine */
         divDownloadactionstable_Visible = 0;
         AssignProp(sPrefix, false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         new k2bloadrowsperpage(context ).execute(  AV53Pgmname,  "Grid", out  AV21RowsPerPageVariable, out  AV22RowsPerPageLoaded) ;
         if ( ! AV22RowsPerPageLoaded )
         {
            AV21RowsPerPageVariable = 20;
         }
         AV20GridSettingsRowsPerPageVariable = AV21RowsPerPageVariable;
         AssignAttri(sPrefix, false, "AV20GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV20GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV21RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         K2borderbyusercontrol_Gridcontrolname = subGrid_Internalname;
         ucK2borderbyusercontrol.SendProperty(context, sPrefix, false, K2borderbyusercontrol_Internalname, "GridControlName", K2borderbyusercontrol_Gridcontrolname);
         AV42GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "TABLEROS_WEB");
         AV43GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV43GridOrder.gxTpr_Ascendingorder = 0;
         AV43GridOrder.gxTpr_Descendingorder = 1;
         AV43GridOrder.gxTpr_Gridcolumnindex = 1;
         AV42GridOrders.Add(AV43GridOrder, 0);
         AV43GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV43GridOrder.gxTpr_Ascendingorder = 2;
         AV43GridOrder.gxTpr_Descendingorder = 3;
         AV43GridOrder.gxTpr_Gridcolumnindex = 2;
         AV42GridOrders.Add(AV43GridOrder, 0);
      }

      protected void E191T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         GXt_objcol_SdtMessages_Message1 = AV45Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV45Messages = GXt_objcol_SdtMessages_Message1;
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV45Messages.Count )
         {
            AV46Message = ((SdtMessages_Message)AV45Messages.Item(AV54GXV1));
            GX_msglist.addItem(AV46Message.gxTpr_Description);
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV49ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV50ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTareas";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTareas";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV53Pgmname;
         AV49ActivityList.Add(AV50ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV49ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV49ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV49ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)) + "," + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV49ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)) + "," + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV49ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)) + "," + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV49ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)) + "," + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV49ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         bttReport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridColumns", AV11GridColumns);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            AV23GridStateKey = AV6TrGestionTareas_IDTablero.ToString();
            new k2bloadgridstate(context ).execute(  AV53Pgmname,  AV23GridStateKey, out  AV24GridState) ;
            AV41OrderedBy = AV24GridState.gxTpr_Orderedby;
            AssignAttri(sPrefix, false, "AV41OrderedBy", StringUtil.LTrimStr( (decimal)(AV41OrderedBy), 4, 0));
            AV44UC_OrderedBy = AV24GridState.gxTpr_Orderedby;
            AssignAttri(sPrefix, false, "AV44UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV44UC_OrderedBy), 4, 0));
            if ( ( AV24GridState.gxTpr_Currentpage > 0 ) && ( AV24GridState.gxTpr_Currentpage <= subGrid_fnc_Pagecount( ) ) )
            {
               AV9CurrentPage = AV24GridState.gxTpr_Currentpage;
               AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
               subgrid_gotopage( AV9CurrentPage) ;
            }
         }
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         AV23GridStateKey = AV6TrGestionTareas_IDTablero.ToString();
         new k2bloadgridstate(context ).execute(  AV53Pgmname,  AV23GridStateKey, out  AV24GridState) ;
         AV24GridState.gxTpr_Currentpage = (short)(AV9CurrentPage);
         AV24GridState.gxTpr_Orderedby = AV41OrderedBy;
         AV24GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV53Pgmname,  AV23GridStateKey,  AV24GridState) ;
      }

      protected void S182( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV47TrnContext = new SdtK2BTrnContext(context);
         AV47TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV47TrnContext.gxTpr_Returnmode = "Stack";
         AV47TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV47TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV47TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV47TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV47TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV47TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         AV48TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV48TrnContextAtt.gxTpr_Attributename = "TrGestionTareas_IDTablero";
         AV48TrnContextAtt.gxTpr_Attributevalue = AV6TrGestionTareas_IDTablero.ToString();
         AV47TrnContext.gxTpr_Attributes.Add(AV48TrnContextAtt, 0);
         new k2bsettrncontextbyname(context ).execute(  "TrGestionTareas",  AV47TrnContext) ;
      }

      protected void E111T2( )
      {
         /* 'DoExport' Routine */
         CallWebObject(formatLink("exporttrgestiontablerostrgestiontareaswc.aspx") + "?" + UrlEncode(AV6TrGestionTareas_IDTablero.ToString()) + "," + UrlEncode("" +AV41OrderedBy));
         context.wjLocDisableFrm = 2;
      }

      protected void S152( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridcolumns(context ).execute(  AV53Pgmname,  "Grid", ref  AV11GridColumns) ;
         edtTrGestionTareas_ID_Visible = 1;
         AssignProp(sPrefix, false, edtTrGestionTareas_ID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_ID_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV13Att_TrGestionTareas_ID_Visible = true;
         AssignAttri(sPrefix, false, "AV13Att_TrGestionTareas_ID_Visible", AV13Att_TrGestionTareas_ID_Visible);
         edtTrGestionTareas_Nombre_Visible = 1;
         AssignProp(sPrefix, false, edtTrGestionTareas_Nombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_Nombre_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV14Att_TrGestionTareas_Nombre_Visible = true;
         AssignAttri(sPrefix, false, "AV14Att_TrGestionTareas_Nombre_Visible", AV14Att_TrGestionTareas_Nombre_Visible);
         edtTrGestionTareas_Descripcion_Visible = 1;
         AssignProp(sPrefix, false, edtTrGestionTareas_Descripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_Descripcion_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV15Att_TrGestionTareas_Descripcion_Visible = true;
         AssignAttri(sPrefix, false, "AV15Att_TrGestionTareas_Descripcion_Visible", AV15Att_TrGestionTareas_Descripcion_Visible);
         edtTrGestionTareas_FechaInicio_Visible = 1;
         AssignProp(sPrefix, false, edtTrGestionTareas_FechaInicio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaInicio_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV16Att_TrGestionTareas_FechaInicio_Visible = true;
         AssignAttri(sPrefix, false, "AV16Att_TrGestionTareas_FechaInicio_Visible", AV16Att_TrGestionTareas_FechaInicio_Visible);
         edtTrGestionTareas_FechaFin_Visible = 1;
         AssignProp(sPrefix, false, edtTrGestionTareas_FechaFin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaFin_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV17Att_TrGestionTareas_FechaFin_Visible = true;
         AssignAttri(sPrefix, false, "AV17Att_TrGestionTareas_FechaFin_Visible", AV17Att_TrGestionTareas_FechaFin_Visible);
         edtTrGestionTareas_FechaCreacion_Visible = 1;
         AssignProp(sPrefix, false, edtTrGestionTareas_FechaCreacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaCreacion_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV18Att_TrGestionTareas_FechaCreacion_Visible = true;
         AssignAttri(sPrefix, false, "AV18Att_TrGestionTareas_FechaCreacion_Visible", AV18Att_TrGestionTareas_FechaCreacion_Visible);
         edtTrGestionTareas_FechaModificacion_Visible = 1;
         AssignProp(sPrefix, false, edtTrGestionTareas_FechaModificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaModificacion_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV19Att_TrGestionTareas_FechaModificacion_Visible = true;
         AssignAttri(sPrefix, false, "AV19Att_TrGestionTareas_FechaModificacion_Visible", AV19Att_TrGestionTareas_FechaModificacion_Visible);
         new k2bsavegridcolumns(context ).execute(  AV53Pgmname,  "Grid",  AV11GridColumns,  false) ;
         AV55GXV2 = 1;
         while ( AV55GXV2 <= AV11GridColumns.Count )
         {
            AV12GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridColumns.Item(AV55GXV2));
            if ( ! AV12GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_ID") == 0 )
               {
                  edtTrGestionTareas_ID_Visible = 0;
                  AssignProp(sPrefix, false, edtTrGestionTareas_ID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_ID_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV13Att_TrGestionTareas_ID_Visible = false;
                  AssignAttri(sPrefix, false, "AV13Att_TrGestionTareas_ID_Visible", AV13Att_TrGestionTareas_ID_Visible);
               }
               else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_Nombre") == 0 )
               {
                  edtTrGestionTareas_Nombre_Visible = 0;
                  AssignProp(sPrefix, false, edtTrGestionTareas_Nombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_Nombre_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV14Att_TrGestionTareas_Nombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV14Att_TrGestionTareas_Nombre_Visible", AV14Att_TrGestionTareas_Nombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_Descripcion") == 0 )
               {
                  edtTrGestionTareas_Descripcion_Visible = 0;
                  AssignProp(sPrefix, false, edtTrGestionTareas_Descripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_Descripcion_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV15Att_TrGestionTareas_Descripcion_Visible = false;
                  AssignAttri(sPrefix, false, "AV15Att_TrGestionTareas_Descripcion_Visible", AV15Att_TrGestionTareas_Descripcion_Visible);
               }
               else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaInicio") == 0 )
               {
                  edtTrGestionTareas_FechaInicio_Visible = 0;
                  AssignProp(sPrefix, false, edtTrGestionTareas_FechaInicio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaInicio_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV16Att_TrGestionTareas_FechaInicio_Visible = false;
                  AssignAttri(sPrefix, false, "AV16Att_TrGestionTareas_FechaInicio_Visible", AV16Att_TrGestionTareas_FechaInicio_Visible);
               }
               else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaFin") == 0 )
               {
                  edtTrGestionTareas_FechaFin_Visible = 0;
                  AssignProp(sPrefix, false, edtTrGestionTareas_FechaFin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaFin_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV17Att_TrGestionTareas_FechaFin_Visible = false;
                  AssignAttri(sPrefix, false, "AV17Att_TrGestionTareas_FechaFin_Visible", AV17Att_TrGestionTareas_FechaFin_Visible);
               }
               else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaCreacion") == 0 )
               {
                  edtTrGestionTareas_FechaCreacion_Visible = 0;
                  AssignProp(sPrefix, false, edtTrGestionTareas_FechaCreacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaCreacion_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV18Att_TrGestionTareas_FechaCreacion_Visible = false;
                  AssignAttri(sPrefix, false, "AV18Att_TrGestionTareas_FechaCreacion_Visible", AV18Att_TrGestionTareas_FechaCreacion_Visible);
               }
               else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaModificacion") == 0 )
               {
                  edtTrGestionTareas_FechaModificacion_Visible = 0;
                  AssignProp(sPrefix, false, edtTrGestionTareas_FechaModificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTareas_FechaModificacion_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV19Att_TrGestionTareas_FechaModificacion_Visible = false;
                  AssignAttri(sPrefix, false, "AV19Att_TrGestionTareas_FechaModificacion_Visible", AV19Att_TrGestionTareas_FechaModificacion_Visible);
               }
            }
            AV55GXV2 = (int)(AV55GXV2+1);
         }
      }

      protected void S172( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         AV11GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB");
         AV12GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumn.gxTpr_Attributename = "TrGestionTareas_ID";
         AV12GridColumn.gxTpr_Columntitle = "Gestion Tareas_ID";
         AV12GridColumn.gxTpr_Showattribute = true;
         AV11GridColumns.Add(AV12GridColumn, 0);
         AV12GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumn.gxTpr_Attributename = "TrGestionTareas_Nombre";
         AV12GridColumn.gxTpr_Columntitle = "Gestion Tareas_Nombre";
         AV12GridColumn.gxTpr_Showattribute = true;
         AV11GridColumns.Add(AV12GridColumn, 0);
         AV12GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumn.gxTpr_Attributename = "TrGestionTareas_Descripcion";
         AV12GridColumn.gxTpr_Columntitle = "Gestion Tareas_Descripcion";
         AV12GridColumn.gxTpr_Showattribute = true;
         AV11GridColumns.Add(AV12GridColumn, 0);
         AV12GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumn.gxTpr_Attributename = "TrGestionTareas_FechaInicio";
         AV12GridColumn.gxTpr_Columntitle = "Tareas_Fecha Inicio";
         AV12GridColumn.gxTpr_Showattribute = true;
         AV11GridColumns.Add(AV12GridColumn, 0);
         AV12GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumn.gxTpr_Attributename = "TrGestionTareas_FechaFin";
         AV12GridColumn.gxTpr_Columntitle = "Tareas_Fecha Fin";
         AV12GridColumn.gxTpr_Showattribute = true;
         AV11GridColumns.Add(AV12GridColumn, 0);
         AV12GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumn.gxTpr_Attributename = "TrGestionTareas_FechaCreacion";
         AV12GridColumn.gxTpr_Columntitle = "Tareas_Fecha Creacion";
         AV12GridColumn.gxTpr_Showattribute = true;
         AV11GridColumns.Add(AV12GridColumn, 0);
         AV12GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumn.gxTpr_Attributename = "TrGestionTareas_FechaModificacion";
         AV12GridColumn.gxTpr_Columntitle = "Tareas_Fecha Modificacion";
         AV12GridColumn.gxTpr_Showattribute = true;
         AV11GridColumns.Add(AV12GridColumn, 0);
      }

      protected void S132( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS' Routine */
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S192( )
      {
         /* 'DISPLAYPERSISTENTACTIONS' Routine */
         AV49ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV50ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTareas";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTareas";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportTrGestionTablerosTrGestionTareasWC";
         AV49ActivityList.Add(AV50ActivityListItem, 0);
         AV50ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTareas";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTareas";
         AV50ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportTrGestionTablerosTrGestionTareasWC";
         AV49ActivityList.Add(AV50ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV49ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV49ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV49ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' Routine */
         if ( ( bttReport_Visible == 1 ) || ( bttExport_Visible == 1 ) )
         {
            divDownloadsactionssectioncontainer_Visible = 1;
            AssignProp(sPrefix, false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
         else
         {
            divDownloadsactionssectioncontainer_Visible = 0;
            AssignProp(sPrefix, false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
      }

      protected void E201T2( )
      {
         /* Grid_Refresh Routine */
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblNoresultsfoundtable_Visible = 1;
         AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV44UC_OrderedBy = AV41OrderedBy;
         AssignAttri(sPrefix, false, "AV44UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV44UC_OrderedBy), 4, 0));
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridColumns", AV11GridColumns);
      }

      private void E211T2( )
      {
         /* Grid_Load Routine */
         tblNoresultsfoundtable_Visible = 0;
         AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 106;
         }
         sendrow_1062( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_106_Refreshing )
         {
            context.DoAjaxLoad(106, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E121T2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         AV41OrderedBy = AV44UC_OrderedBy;
         AssignAttri(sPrefix, false, "AV41OrderedBy", StringUtil.LTrimStr( (decimal)(AV41OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV6TrGestionTareas_IDTablero, AV41OrderedBy, AV9CurrentPage, AV53Pgmname, AV11GridColumns, AV13Att_TrGestionTareas_ID_Visible, AV14Att_TrGestionTareas_Nombre_Visible, AV15Att_TrGestionTareas_Descripcion_Visible, AV16Att_TrGestionTareas_FechaInicio_Visible, AV17Att_TrGestionTareas_FechaFin_Visible, AV18Att_TrGestionTareas_FechaCreacion_Visible, AV19Att_TrGestionTareas_FechaModificacion_Visible, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridColumns", AV11GridColumns);
      }

      protected void E131T2( )
      {
         /* 'SaveGridSettings' Routine */
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridcolumns(context ).execute(  AV53Pgmname,  "Grid", ref  AV11GridColumns) ;
         AV56GXV3 = 1;
         while ( AV56GXV3 <= AV11GridColumns.Count )
         {
            AV12GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridColumns.Item(AV56GXV3));
            if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_ID") == 0 )
            {
               AV12GridColumn.gxTpr_Showattribute = AV13Att_TrGestionTareas_ID_Visible;
            }
            else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_Nombre") == 0 )
            {
               AV12GridColumn.gxTpr_Showattribute = AV14Att_TrGestionTareas_Nombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_Descripcion") == 0 )
            {
               AV12GridColumn.gxTpr_Showattribute = AV15Att_TrGestionTareas_Descripcion_Visible;
            }
            else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaInicio") == 0 )
            {
               AV12GridColumn.gxTpr_Showattribute = AV16Att_TrGestionTareas_FechaInicio_Visible;
            }
            else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaFin") == 0 )
            {
               AV12GridColumn.gxTpr_Showattribute = AV17Att_TrGestionTareas_FechaFin_Visible;
            }
            else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaCreacion") == 0 )
            {
               AV12GridColumn.gxTpr_Showattribute = AV18Att_TrGestionTareas_FechaCreacion_Visible;
            }
            else if ( StringUtil.StrCmp(AV12GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaModificacion") == 0 )
            {
               AV12GridColumn.gxTpr_Showattribute = AV19Att_TrGestionTareas_FechaModificacion_Visible;
            }
            AV56GXV3 = (int)(AV56GXV3+1);
         }
         new k2bsavegridcolumns(context ).execute(  AV53Pgmname,  "Grid",  AV11GridColumns,  true) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV44UC_OrderedBy = AV41OrderedBy;
         AssignAttri(sPrefix, false, "AV44UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV44UC_OrderedBy), 4, 0));
         if ( subGrid_Rows != AV20GridSettingsRowsPerPageVariable )
         {
            AV21RowsPerPageVariable = AV20GridSettingsRowsPerPageVariable;
            subGrid_Rows = AV21RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV53Pgmname,  "Grid",  AV21RowsPerPageVariable) ;
            AV9CurrentPage = 1;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV6TrGestionTareas_IDTablero, AV41OrderedBy, AV9CurrentPage, AV53Pgmname, AV11GridColumns, AV13Att_TrGestionTareas_ID_Visible, AV14Att_TrGestionTareas_Nombre_Visible, AV15Att_TrGestionTareas_Descripcion_Visible, AV16Att_TrGestionTareas_FechaInicio_Visible, AV17Att_TrGestionTareas_FechaFin_Visible, AV18Att_TrGestionTareas_FechaCreacion_Visible, AV19Att_TrGestionTareas_FechaModificacion_Visible, sPrefix) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridColumns", AV11GridColumns);
      }

      protected void S162( )
      {
         /* 'DISPLAYPAGINGBUTTONS' Routine */
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( AV9CurrentPage > AV10K2BMaxPages )
         {
            AV9CurrentPage = AV10K2BMaxPages;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_lastpage( ) ;
            context.DoAjaxRefreshCmp(sPrefix);
         }
         if ( AV10K2BMaxPages == 0 )
         {
            AV9CurrentPage = 0;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         }
         else
         {
            AV9CurrentPage = subGrid_fnc_Currentpage( );
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         }
         lblFirstpagetextblock_Caption = "1";
         AssignProp(sPrefix, false, lblFirstpagetextblock_Internalname, "Caption", lblFirstpagetextblock_Caption, true);
         lblPreviouspagetextblock_Caption = StringUtil.Str( (decimal)(AV9CurrentPage-1), 10, 0);
         AssignProp(sPrefix, false, lblPreviouspagetextblock_Internalname, "Caption", lblPreviouspagetextblock_Caption, true);
         lblCurrentpagetextblock_Caption = StringUtil.Str( (decimal)(AV9CurrentPage), 5, 0);
         AssignProp(sPrefix, false, lblCurrentpagetextblock_Internalname, "Caption", lblCurrentpagetextblock_Caption, true);
         lblNextpagetextblock_Caption = StringUtil.Str( (decimal)(AV9CurrentPage+1), 10, 0);
         AssignProp(sPrefix, false, lblNextpagetextblock_Internalname, "Caption", lblNextpagetextblock_Caption, true);
         lblLastpagetextblock_Caption = StringUtil.Str( (decimal)(AV10K2BMaxPages), 6, 0);
         AssignProp(sPrefix, false, lblLastpagetextblock_Internalname, "Caption", lblLastpagetextblock_Caption, true);
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
         if ( (0==AV9CurrentPage) || ( AV9CurrentPage <= 1 ) )
         {
            cellFirstpagecell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp(sPrefix, false, cellFirstpagecell_Internalname, "Class", cellFirstpagecell_Class, true);
            lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp(sPrefix, false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
            lblFirstpagetextblock_Visible = 0;
            AssignProp(sPrefix, false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
            cellSpacingleftcell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp(sPrefix, false, cellSpacingleftcell_Internalname, "Class", cellSpacingleftcell_Class, true);
            lblSpacinglefttextblock_Visible = 0;
            AssignProp(sPrefix, false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            cellPreviouspagecell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp(sPrefix, false, cellPreviouspagecell_Internalname, "Class", cellPreviouspagecell_Class, true);
            lblPreviouspagetextblock_Visible = 0;
            AssignProp(sPrefix, false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
         }
         else
         {
            cellPreviouspagecell_Class = "K2BToolsCell_PaginationPrevious";
            AssignProp(sPrefix, false, cellPreviouspagecell_Internalname, "Class", cellPreviouspagecell_Class, true);
            lblPreviouspagetextblock_Visible = 1;
            AssignProp(sPrefix, false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
            if ( AV9CurrentPage == 2 )
            {
               cellFirstpagecell_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp(sPrefix, false, cellFirstpagecell_Internalname, "Class", cellFirstpagecell_Class, true);
               lblFirstpagetextblock_Visible = 0;
               AssignProp(sPrefix, false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               cellSpacingleftcell_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp(sPrefix, false, cellSpacingleftcell_Internalname, "Class", cellSpacingleftcell_Class, true);
               lblSpacinglefttextblock_Visible = 0;
               AssignProp(sPrefix, false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            }
            else
            {
               cellFirstpagecell_Class = "K2BToolsCell_PaginationLeft";
               AssignProp(sPrefix, false, cellFirstpagecell_Internalname, "Class", cellFirstpagecell_Class, true);
               lblFirstpagetextblock_Visible = 1;
               AssignProp(sPrefix, false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               if ( AV9CurrentPage == 3 )
               {
                  cellSpacingleftcell_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp(sPrefix, false, cellSpacingleftcell_Internalname, "Class", cellSpacingleftcell_Class, true);
                  lblSpacinglefttextblock_Visible = 0;
                  AssignProp(sPrefix, false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
               else
               {
                  cellSpacingleftcell_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
                  AssignProp(sPrefix, false, cellSpacingleftcell_Internalname, "Class", cellSpacingleftcell_Class, true);
                  lblSpacinglefttextblock_Visible = 1;
                  AssignProp(sPrefix, false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( AV9CurrentPage == AV10K2BMaxPages )
         {
            cellLastpagecell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp(sPrefix, false, cellLastpagecell_Internalname, "Class", cellLastpagecell_Class, true);
            lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp(sPrefix, false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
            lblLastpagetextblock_Visible = 0;
            AssignProp(sPrefix, false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
            cellSpacingrightcell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp(sPrefix, false, cellSpacingrightcell_Internalname, "Class", cellSpacingrightcell_Class, true);
            lblSpacingrighttextblock_Visible = 0;
            AssignProp(sPrefix, false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            cellNextpagecell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp(sPrefix, false, cellNextpagecell_Internalname, "Class", cellNextpagecell_Class, true);
            lblNextpagetextblock_Visible = 0;
            AssignProp(sPrefix, false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
         }
         else
         {
            cellNextpagecell_Class = "K2BToolsCell_PaginationNext";
            AssignProp(sPrefix, false, cellNextpagecell_Internalname, "Class", cellNextpagecell_Class, true);
            lblNextpagetextblock_Visible = 1;
            AssignProp(sPrefix, false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
            if ( AV9CurrentPage == AV10K2BMaxPages - 1 )
            {
               cellLastpagecell_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp(sPrefix, false, cellLastpagecell_Internalname, "Class", cellLastpagecell_Class, true);
               lblLastpagetextblock_Visible = 0;
               AssignProp(sPrefix, false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               cellSpacingrightcell_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp(sPrefix, false, cellSpacingrightcell_Internalname, "Class", cellSpacingrightcell_Class, true);
               lblSpacingrighttextblock_Visible = 0;
               AssignProp(sPrefix, false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            }
            else
            {
               cellLastpagecell_Class = "K2BToolsCell_PaginationRight";
               AssignProp(sPrefix, false, cellLastpagecell_Internalname, "Class", cellLastpagecell_Class, true);
               lblLastpagetextblock_Visible = 1;
               AssignProp(sPrefix, false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               if ( AV9CurrentPage == AV10K2BMaxPages - 2 )
               {
                  cellSpacingrightcell_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp(sPrefix, false, cellSpacingrightcell_Internalname, "Class", cellSpacingrightcell_Class, true);
                  lblSpacingrighttextblock_Visible = 0;
                  AssignProp(sPrefix, false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
               else
               {
                  cellSpacingrightcell_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
                  AssignProp(sPrefix, false, cellSpacingrightcell_Internalname, "Class", cellSpacingrightcell_Class, true);
                  lblSpacingrighttextblock_Visible = 1;
                  AssignProp(sPrefix, false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV9CurrentPage <= 1 ) && ( AV10K2BMaxPages <= 1 ) )
         {
            tblK2btoolspagingcontainertable_Visible = 0;
            AssignProp(sPrefix, false, tblK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
         else
         {
            tblK2btoolspagingcontainertable_Visible = 1;
            AssignProp(sPrefix, false, tblK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
      }

      protected void E141T2( )
      {
         /* 'DoFirst' Routine */
         AV9CurrentPage = 1;
         AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridColumns", AV11GridColumns);
      }

      protected void E151T2( )
      {
         /* 'DoPrevious' Routine */
         if ( AV9CurrentPage > 1 )
         {
            AV9CurrentPage = (int)(AV9CurrentPage-1);
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_previouspage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridColumns", AV11GridColumns);
      }

      protected void E161T2( )
      {
         /* 'DoNext' Routine */
         if ( AV9CurrentPage != subGrid_fnc_Pagecount( ) )
         {
            AV9CurrentPage = (int)(AV9CurrentPage+1);
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_nextpage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridColumns", AV11GridColumns);
      }

      protected void E171T2( )
      {
         /* 'DoLast' Routine */
         AV9CurrentPage = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridColumns", AV11GridColumns);
      }

      protected void wb_table3_126_1T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblK2btoolspagingcontainertable_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblK2btoolspagingcontainertable_Internalname, tblK2btoolspagingcontainertable_Internalname, "", "K2BToolsTable_PaginationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellPreviouspagebuttoncell_Internalname+"\"  class='K2BToolsCell_PaginationFirst'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "&laquo;", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 1, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFirstpagecell_Internalname+"\"  class='"+cellFirstpagecell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellSpacingleftcell_Internalname+"\"  class='"+cellSpacingleftcell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPreviouspagecell_Internalname+"\"  class='"+cellPreviouspagecell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellCurrentpagecell_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellNextpagecell_Internalname+"\"  class='"+cellNextpagecell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellSpacingrightcell_Internalname+"\"  class='"+cellSpacingrightcell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellLastpagecell_Internalname+"\"  class='"+cellLastpagecell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellNextpagebuttoncell_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "&raquo;", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 1, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_126_1T2e( true) ;
         }
         else
         {
            wb_table3_126_1T2e( false) ;
         }
      }

      protected void wb_table2_116_1T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblNoresultsfoundtable_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblNoresultsfoundtable_Internalname, tblNoresultsfoundtable_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No results found", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_116_1T2e( true) ;
         }
         else
         {
            wb_table2_116_1T2e( false) ;
         }
      }

      protected void wb_table1_18_1T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable7_Internalname, tblTable7_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingstable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblK2bgridsettingslabel_Internalname, "", "", "", lblK2bgridsettingslabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e221t1_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingscontentoutertable_Internalname, divK2bgridsettingscontentoutertable_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table4_30_1T2( true) ;
         }
         else
         {
            wb_table4_30_1T2( false) ;
         }
         return  ;
      }

      protected void wb_table4_30_1T2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(106), 3, 0)+","+"null"+");", "Save", bttK2bgridsettingssave_Jsonclick, 5, "Save", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadsactionssectioncontainer_Internalname, divDownloadsactionssectioncontainer_Visible, 0, "px", 0, "px", "K2BToolsTable_DownloadActionsContainer ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e231t1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadactionstable_Internalname, divDownloadactionstable_Visible, 0, "px", 0, "px", "K2BToolsDownloadActionsTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table5_92_1T2( true) ;
         }
         else
         {
            wb_table5_92_1T2( false) ;
         }
         return  ;
      }

      protected void wb_table5_92_1T2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_18_1T2e( true) ;
         }
         else
         {
            wb_table1_18_1T2e( false) ;
         }
      }

      protected void wb_table5_92_1T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(106), 3, 0)+","+"null"+");", "Report", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e241t1_client"+"'", TempTags, "", 2, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(106), 3, 0)+","+"null"+");", "Export", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_92_1T2e( true) ;
         }
         else
         {
            wb_table5_92_1T2e( false) ;
         }
      }

      protected void wb_table4_30_1T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettingstable_content_Internalname, tblGridsettingstable_content_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_idruntimecolumnatt_Internalname, "Gestion Tareas_ID", "", "", lblTrgestiontareas_idruntimecolumnatt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontareas_id_visible_Internalname, "Gestion Tareas_ID", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontareas_id_visible_Internalname, StringUtil.BoolToStr( AV13Att_TrGestionTareas_ID_Visible), "", "Gestion Tareas_ID", 1, chkavAtt_trgestiontareas_id_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_nombreruntimecolumnatt_Internalname, "Gestion Tareas_Nombre", "", "", lblTrgestiontareas_nombreruntimecolumnatt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontareas_nombre_visible_Internalname, "Gestion Tareas_Nombre", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontareas_nombre_visible_Internalname, StringUtil.BoolToStr( AV14Att_TrGestionTareas_Nombre_Visible), "", "Gestion Tareas_Nombre", 1, chkavAtt_trgestiontareas_nombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(42, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,42);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_descripcionruntimecolumnatt_Internalname, "Gestion Tareas_Descripcion", "", "", lblTrgestiontareas_descripcionruntimecolumnatt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontareas_descripcion_visible_Internalname, "Gestion Tareas_Descripcion", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontareas_descripcion_visible_Internalname, StringUtil.BoolToStr( AV15Att_TrGestionTareas_Descripcion_Visible), "", "Gestion Tareas_Descripcion", 1, chkavAtt_trgestiontareas_descripcion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(48, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,48);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechainicioruntimecolumnatt_Internalname, "Tareas_Fecha Inicio", "", "", lblTrgestiontareas_fechainicioruntimecolumnatt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontareas_fechainicio_visible_Internalname, "Tareas_Fecha Inicio", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontareas_fechainicio_visible_Internalname, StringUtil.BoolToStr( AV16Att_TrGestionTareas_FechaInicio_Visible), "", "Tareas_Fecha Inicio", 1, chkavAtt_trgestiontareas_fechainicio_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechafinruntimecolumnatt_Internalname, "Tareas_Fecha Fin", "", "", lblTrgestiontareas_fechafinruntimecolumnatt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontareas_fechafin_visible_Internalname, "Tareas_Fecha Fin", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontareas_fechafin_visible_Internalname, StringUtil.BoolToStr( AV17Att_TrGestionTareas_FechaFin_Visible), "", "Tareas_Fecha Fin", 1, chkavAtt_trgestiontareas_fechafin_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(60, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,60);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechacreacionruntimecolumnatt_Internalname, "Tareas_Fecha Creacion", "", "", lblTrgestiontareas_fechacreacionruntimecolumnatt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontareas_fechacreacion_visible_Internalname, "Tareas_Fecha Creacion", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontareas_fechacreacion_visible_Internalname, StringUtil.BoolToStr( AV18Att_TrGestionTareas_FechaCreacion_Visible), "", "Tareas_Fecha Creacion", 1, chkavAtt_trgestiontareas_fechacreacion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(66, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechamodificacionruntimecolumnatt_Internalname, "Tareas_Fecha Modificacion", "", "", lblTrgestiontareas_fechamodificacionruntimecolumnatt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontareas_fechamodificacion_visible_Internalname, "Tareas_Fecha Modificacion", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontareas_fechamodificacion_visible_Internalname, StringUtil.BoolToStr( AV19Att_TrGestionTareas_FechaModificacion_Visible), "", "Tareas_Fecha Modificacion", 1, chkavAtt_trgestiontareas_fechamodificacion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(72, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,72);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRowsperpagegrid_Internalname, "Rows per page", "", "", lblRowsperpagegrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpagevariable_Internalname, "GridSettingsRowsPerPageVariable", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "Rows per page", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, "HLP_TrGestionTablerosTrGestionTareasWC.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", (String)(cmbavGridsettingsrowsperpagevariable.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_30_1T2e( true) ;
         }
         else
         {
            wb_table4_30_1T2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6TrGestionTareas_IDTablero = (Guid)((Guid)getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6TrGestionTareas_IDTablero", AV6TrGestionTareas_IDTablero.ToString());
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
         PA1T2( ) ;
         WS1T2( ) ;
         WE1T2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6TrGestionTareas_IDTablero = (String)((String)getParm(obj,0));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA1T2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trgestiontablerostrgestiontareaswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA1T2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6TrGestionTareas_IDTablero = (Guid)((Guid)getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6TrGestionTareas_IDTablero", AV6TrGestionTareas_IDTablero.ToString());
         }
         wcpOAV6TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV6TrGestionTareas_IDTablero")));
         if ( ! GetJustCreated( ) && ( ( AV6TrGestionTareas_IDTablero != wcpOAV6TrGestionTareas_IDTablero ) ) )
         {
            setjustcreated();
         }
         wcpOAV6TrGestionTareas_IDTablero = (Guid)(AV6TrGestionTareas_IDTablero);
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6TrGestionTareas_IDTablero = cgiGet( sPrefix+"AV6TrGestionTareas_IDTablero_CTRL");
         if ( StringUtil.Len( sCtrlAV6TrGestionTareas_IDTablero) > 0 )
         {
            AV6TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( sCtrlAV6TrGestionTareas_IDTablero)));
            AssignAttri(sPrefix, false, "AV6TrGestionTareas_IDTablero", AV6TrGestionTareas_IDTablero.ToString());
         }
         else
         {
            AV6TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( sPrefix+"AV6TrGestionTareas_IDTablero_PARM")));
         }
      }

      public override void componentprocess( String sPPrefix ,
                                             String sPSFPrefix ,
                                             String sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA1T2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS1T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS1T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6TrGestionTareas_IDTablero_PARM", AV6TrGestionTareas_IDTablero.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6TrGestionTareas_IDTablero)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6TrGestionTareas_IDTablero_CTRL", StringUtil.RTrim( sCtrlAV6TrGestionTareas_IDTablero));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE1T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override String getstring( String sGXControl )
      {
         String sCtrlName ;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?2022102010595588", true, true);
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
         context.AddJavascriptSource("trgestiontablerostrgestiontareaswc.js", "?2022102010595588", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1062( )
      {
         edtTrGestionTareas_ID_Internalname = sPrefix+"TRGESTIONTAREAS_ID_"+sGXsfl_106_idx;
         edtTrGestionTareas_Nombre_Internalname = sPrefix+"TRGESTIONTAREAS_NOMBRE_"+sGXsfl_106_idx;
         edtTrGestionTareas_Descripcion_Internalname = sPrefix+"TRGESTIONTAREAS_DESCRIPCION_"+sGXsfl_106_idx;
         edtTrGestionTareas_FechaInicio_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAINICIO_"+sGXsfl_106_idx;
         edtTrGestionTareas_FechaFin_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAFIN_"+sGXsfl_106_idx;
         edtTrGestionTareas_FechaCreacion_Internalname = sPrefix+"TRGESTIONTAREAS_FECHACREACION_"+sGXsfl_106_idx;
         edtTrGestionTareas_FechaModificacion_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAMODIFICACION_"+sGXsfl_106_idx;
      }

      protected void SubsflControlProps_fel_1062( )
      {
         edtTrGestionTareas_ID_Internalname = sPrefix+"TRGESTIONTAREAS_ID_"+sGXsfl_106_fel_idx;
         edtTrGestionTareas_Nombre_Internalname = sPrefix+"TRGESTIONTAREAS_NOMBRE_"+sGXsfl_106_fel_idx;
         edtTrGestionTareas_Descripcion_Internalname = sPrefix+"TRGESTIONTAREAS_DESCRIPCION_"+sGXsfl_106_fel_idx;
         edtTrGestionTareas_FechaInicio_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAINICIO_"+sGXsfl_106_fel_idx;
         edtTrGestionTareas_FechaFin_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAFIN_"+sGXsfl_106_fel_idx;
         edtTrGestionTareas_FechaCreacion_Internalname = sPrefix+"TRGESTIONTAREAS_FECHACREACION_"+sGXsfl_106_fel_idx;
         edtTrGestionTareas_FechaModificacion_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAMODIFICACION_"+sGXsfl_106_fel_idx;
      }

      protected void sendrow_1062( )
      {
         SubsflControlProps_1062( ) ;
         WB1T0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_106_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_106_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"Grid_WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_106_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTareas_ID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A12TrGestionTareas_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTareas_ID_Visible,(short)0,(short)0,(String)"number",(String)"1",(short)127,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtTrGestionTareas_Nombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_Nombre_Internalname,StringUtil.RTrim( A13TrGestionTareas_Nombre),(String)"",(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_Nombre_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn K2BToolsSortableColumn",(String)"",(int)edtTrGestionTareas_Nombre_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtTrGestionTareas_Descripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_Descripcion_Internalname,(String)A14TrGestionTareas_Descripcion,(String)A14TrGestionTareas_Descripcion,(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_Descripcion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTareas_Descripcion_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)106,(short)1,(short)0,(short)-1,(bool)true,(String)"",(String)"left",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTareas_FechaInicio_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_FechaInicio_Internalname,context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"),context.localUtil.Format( A15TrGestionTareas_FechaInicio, "99/99/9999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_FechaInicio_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTareas_FechaInicio_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTareas_FechaFin_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_FechaFin_Internalname,context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"),context.localUtil.Format( A16TrGestionTareas_FechaFin, "99/99/9999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_FechaFin_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTareas_FechaFin_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTareas_FechaCreacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_FechaCreacion_Internalname,context.localUtil.Format(A17TrGestionTareas_FechaCreacion, "99/99/9999"),context.localUtil.Format( A17TrGestionTareas_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_FechaCreacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTareas_FechaCreacion_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTareas_FechaModificacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_FechaModificacion_Internalname,context.localUtil.Format(A18TrGestionTareas_FechaModificacion, "99/99/9999"),context.localUtil.Format( A18TrGestionTareas_FechaModificacion, "99/99/9999"),(String)"",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_FechaModificacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTareas_FechaModificacion_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes1T2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_106_idx = ((subGrid_Islastpage==1)&&(nGXsfl_106_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_idx+1);
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1062( ) ;
         }
         /* End function sendrow_1062 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_trgestiontareas_id_visible.Name = "vATT_TRGESTIONTAREAS_ID_VISIBLE";
         chkavAtt_trgestiontareas_id_visible.WebTags = "";
         chkavAtt_trgestiontareas_id_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_trgestiontareas_id_visible_Internalname, "TitleCaption", chkavAtt_trgestiontareas_id_visible.Caption, true);
         chkavAtt_trgestiontareas_id_visible.CheckedValue = "false";
         chkavAtt_trgestiontareas_nombre_visible.Name = "vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE";
         chkavAtt_trgestiontareas_nombre_visible.WebTags = "";
         chkavAtt_trgestiontareas_nombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_trgestiontareas_nombre_visible_Internalname, "TitleCaption", chkavAtt_trgestiontareas_nombre_visible.Caption, true);
         chkavAtt_trgestiontareas_nombre_visible.CheckedValue = "false";
         chkavAtt_trgestiontareas_descripcion_visible.Name = "vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE";
         chkavAtt_trgestiontareas_descripcion_visible.WebTags = "";
         chkavAtt_trgestiontareas_descripcion_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_trgestiontareas_descripcion_visible_Internalname, "TitleCaption", chkavAtt_trgestiontareas_descripcion_visible.Caption, true);
         chkavAtt_trgestiontareas_descripcion_visible.CheckedValue = "false";
         chkavAtt_trgestiontareas_fechainicio_visible.Name = "vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE";
         chkavAtt_trgestiontareas_fechainicio_visible.WebTags = "";
         chkavAtt_trgestiontareas_fechainicio_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_trgestiontareas_fechainicio_visible_Internalname, "TitleCaption", chkavAtt_trgestiontareas_fechainicio_visible.Caption, true);
         chkavAtt_trgestiontareas_fechainicio_visible.CheckedValue = "false";
         chkavAtt_trgestiontareas_fechafin_visible.Name = "vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE";
         chkavAtt_trgestiontareas_fechafin_visible.WebTags = "";
         chkavAtt_trgestiontareas_fechafin_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_trgestiontareas_fechafin_visible_Internalname, "TitleCaption", chkavAtt_trgestiontareas_fechafin_visible.Caption, true);
         chkavAtt_trgestiontareas_fechafin_visible.CheckedValue = "false";
         chkavAtt_trgestiontareas_fechacreacion_visible.Name = "vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE";
         chkavAtt_trgestiontareas_fechacreacion_visible.WebTags = "";
         chkavAtt_trgestiontareas_fechacreacion_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_trgestiontareas_fechacreacion_visible_Internalname, "TitleCaption", chkavAtt_trgestiontareas_fechacreacion_visible.Caption, true);
         chkavAtt_trgestiontareas_fechacreacion_visible.CheckedValue = "false";
         chkavAtt_trgestiontareas_fechamodificacion_visible.Name = "vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE";
         chkavAtt_trgestiontareas_fechamodificacion_visible.WebTags = "";
         chkavAtt_trgestiontareas_fechamodificacion_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_trgestiontareas_fechamodificacion_visible_Internalname, "TitleCaption", chkavAtt_trgestiontareas_fechamodificacion_visible.Caption, true);
         chkavAtt_trgestiontareas_fechamodificacion_visible.CheckedValue = "false";
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblK2bgridsettingslabel_Internalname = sPrefix+"K2BGRIDSETTINGSLABEL";
         lblTrgestiontareas_idruntimecolumnatt_Internalname = sPrefix+"TRGESTIONTAREAS_IDRUNTIMECOLUMNATT";
         chkavAtt_trgestiontareas_id_visible_Internalname = sPrefix+"vATT_TRGESTIONTAREAS_ID_VISIBLE";
         lblTrgestiontareas_nombreruntimecolumnatt_Internalname = sPrefix+"TRGESTIONTAREAS_NOMBRERUNTIMECOLUMNATT";
         chkavAtt_trgestiontareas_nombre_visible_Internalname = sPrefix+"vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE";
         lblTrgestiontareas_descripcionruntimecolumnatt_Internalname = sPrefix+"TRGESTIONTAREAS_DESCRIPCIONRUNTIMECOLUMNATT";
         chkavAtt_trgestiontareas_descripcion_visible_Internalname = sPrefix+"vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE";
         lblTrgestiontareas_fechainicioruntimecolumnatt_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAINICIORUNTIMECOLUMNATT";
         chkavAtt_trgestiontareas_fechainicio_visible_Internalname = sPrefix+"vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE";
         lblTrgestiontareas_fechafinruntimecolumnatt_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAFINRUNTIMECOLUMNATT";
         chkavAtt_trgestiontareas_fechafin_visible_Internalname = sPrefix+"vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE";
         lblTrgestiontareas_fechacreacionruntimecolumnatt_Internalname = sPrefix+"TRGESTIONTAREAS_FECHACREACIONRUNTIMECOLUMNATT";
         chkavAtt_trgestiontareas_fechacreacion_visible_Internalname = sPrefix+"vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE";
         lblTrgestiontareas_fechamodificacionruntimecolumnatt_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAMODIFICACIONRUNTIMECOLUMNATT";
         chkavAtt_trgestiontareas_fechamodificacion_visible_Internalname = sPrefix+"vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE";
         lblRowsperpagegrid_Internalname = sPrefix+"ROWSPERPAGEGRID";
         cmbavGridsettingsrowsperpagevariable_Internalname = sPrefix+"vGRIDSETTINGSROWSPERPAGEVARIABLE";
         tblGridsettingstable_content_Internalname = sPrefix+"GRIDSETTINGSTABLE_CONTENT";
         bttK2bgridsettingssave_Internalname = sPrefix+"K2BGRIDSETTINGSSAVE";
         divK2bgridsettingscontentoutertable_Internalname = sPrefix+"K2BGRIDSETTINGSCONTENTOUTERTABLE";
         divK2bgridsettingstable_Internalname = sPrefix+"K2BGRIDSETTINGSTABLE";
         imgImage1_Internalname = sPrefix+"IMAGE1";
         bttReport_Internalname = sPrefix+"REPORT";
         bttExport_Internalname = sPrefix+"EXPORT";
         tblK2btabledownloadssectioncontainer_Internalname = sPrefix+"K2BTABLEDOWNLOADSSECTIONCONTAINER";
         divDownloadactionstable_Internalname = sPrefix+"DOWNLOADACTIONSTABLE";
         divDownloadsactionssectioncontainer_Internalname = sPrefix+"DOWNLOADSACTIONSSECTIONCONTAINER";
         tblTable7_Internalname = sPrefix+"TABLE7";
         divTable10_Internalname = sPrefix+"TABLE10";
         edtTrGestionTareas_ID_Internalname = sPrefix+"TRGESTIONTAREAS_ID";
         edtTrGestionTareas_Nombre_Internalname = sPrefix+"TRGESTIONTAREAS_NOMBRE";
         edtTrGestionTareas_Descripcion_Internalname = sPrefix+"TRGESTIONTAREAS_DESCRIPCION";
         edtTrGestionTareas_FechaInicio_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAINICIO";
         edtTrGestionTareas_FechaFin_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAFIN";
         edtTrGestionTareas_FechaCreacion_Internalname = sPrefix+"TRGESTIONTAREAS_FECHACREACION";
         edtTrGestionTareas_FechaModificacion_Internalname = sPrefix+"TRGESTIONTAREAS_FECHAMODIFICACION";
         lblNoresultsfoundtextblock_Internalname = sPrefix+"NORESULTSFOUNDTEXTBLOCK";
         tblNoresultsfoundtable_Internalname = sPrefix+"NORESULTSFOUNDTABLE";
         divMaingridcontainergrid_Internalname = sPrefix+"MAINGRIDCONTAINERGRID";
         lblPreviouspagebuttontextblock_Internalname = sPrefix+"PREVIOUSPAGEBUTTONTEXTBLOCK";
         cellPreviouspagebuttoncell_Internalname = sPrefix+"PREVIOUSPAGEBUTTONCELL";
         lblFirstpagetextblock_Internalname = sPrefix+"FIRSTPAGETEXTBLOCK";
         cellFirstpagecell_Internalname = sPrefix+"FIRSTPAGECELL";
         lblSpacinglefttextblock_Internalname = sPrefix+"SPACINGLEFTTEXTBLOCK";
         cellSpacingleftcell_Internalname = sPrefix+"SPACINGLEFTCELL";
         lblPreviouspagetextblock_Internalname = sPrefix+"PREVIOUSPAGETEXTBLOCK";
         cellPreviouspagecell_Internalname = sPrefix+"PREVIOUSPAGECELL";
         lblCurrentpagetextblock_Internalname = sPrefix+"CURRENTPAGETEXTBLOCK";
         cellCurrentpagecell_Internalname = sPrefix+"CURRENTPAGECELL";
         lblNextpagetextblock_Internalname = sPrefix+"NEXTPAGETEXTBLOCK";
         cellNextpagecell_Internalname = sPrefix+"NEXTPAGECELL";
         lblSpacingrighttextblock_Internalname = sPrefix+"SPACINGRIGHTTEXTBLOCK";
         cellSpacingrightcell_Internalname = sPrefix+"SPACINGRIGHTCELL";
         lblLastpagetextblock_Internalname = sPrefix+"LASTPAGETEXTBLOCK";
         cellLastpagecell_Internalname = sPrefix+"LASTPAGECELL";
         lblNextpagebuttontextblock_Internalname = sPrefix+"NEXTPAGEBUTTONTEXTBLOCK";
         cellNextpagebuttoncell_Internalname = sPrefix+"NEXTPAGEBUTTONCELL";
         tblK2btoolspagingcontainertable_Internalname = sPrefix+"K2BTOOLSPAGINGCONTAINERTABLE";
         divSection8_Internalname = sPrefix+"SECTION8";
         divTable4_Internalname = sPrefix+"TABLE4";
         divGlobalgridtable_Internalname = sPrefix+"GLOBALGRIDTABLE";
         divTable6_Internalname = sPrefix+"TABLE6";
         divTable2_Internalname = sPrefix+"TABLE2";
         K2borderbyusercontrol_Internalname = sPrefix+"K2BORDERBYUSERCONTROL";
         divK2btoolsabstracthiddenitemsgrid_Internalname = sPrefix+"K2BTOOLSABSTRACTHIDDENITEMSGRID";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         chkavAtt_trgestiontareas_fechamodificacion_visible.Caption = "Tareas_Fecha Modificacion";
         chkavAtt_trgestiontareas_fechacreacion_visible.Caption = "Tareas_Fecha Creacion";
         chkavAtt_trgestiontareas_fechafin_visible.Caption = "Tareas_Fecha Fin";
         chkavAtt_trgestiontareas_fechainicio_visible.Caption = "Tareas_Fecha Inicio";
         chkavAtt_trgestiontareas_descripcion_visible.Caption = "Gestion Tareas_Descripcion";
         chkavAtt_trgestiontareas_nombre_visible.Caption = "Gestion Tareas_Nombre";
         chkavAtt_trgestiontareas_id_visible.Caption = "Gestion Tareas_ID";
         edtTrGestionTareas_FechaModificacion_Jsonclick = "";
         edtTrGestionTareas_FechaCreacion_Jsonclick = "";
         edtTrGestionTareas_FechaFin_Jsonclick = "";
         edtTrGestionTareas_FechaInicio_Jsonclick = "";
         edtTrGestionTareas_Descripcion_Jsonclick = "";
         edtTrGestionTareas_Nombre_Jsonclick = "";
         edtTrGestionTareas_ID_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_trgestiontareas_fechamodificacion_visible.Enabled = 1;
         chkavAtt_trgestiontareas_fechacreacion_visible.Enabled = 1;
         chkavAtt_trgestiontareas_fechafin_visible.Enabled = 1;
         chkavAtt_trgestiontareas_fechainicio_visible.Enabled = 1;
         chkavAtt_trgestiontareas_descripcion_visible.Enabled = 1;
         chkavAtt_trgestiontareas_nombre_visible.Enabled = 1;
         chkavAtt_trgestiontareas_id_visible.Enabled = 1;
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         divK2bgridsettingscontentoutertable_Visible = 1;
         lblLastpagetextblock_Visible = 1;
         lblSpacingrighttextblock_Visible = 1;
         lblNextpagetextblock_Visible = 1;
         lblPreviouspagetextblock_Visible = 1;
         lblSpacinglefttextblock_Visible = 1;
         lblFirstpagetextblock_Visible = 1;
         tblK2btoolspagingcontainertable_Visible = 1;
         cellNextpagecell_Class = "K2BToolsCell_PaginationNext";
         cellSpacingrightcell_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
         cellLastpagecell_Class = "K2BToolsCell_PaginationRight";
         cellPreviouspagecell_Class = "K2BToolsCell_PaginationPrevious";
         cellSpacingleftcell_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
         cellFirstpagecell_Class = "K2BToolsCell_PaginationLeft";
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         lblLastpagetextblock_Caption = "1";
         lblNextpagetextblock_Caption = "#";
         lblCurrentpagetextblock_Caption = "#";
         lblPreviouspagetextblock_Caption = "#";
         lblFirstpagetextblock_Caption = "1";
         tblNoresultsfoundtable_Visible = 1;
         bttExport_Tooltiptext = "";
         bttReport_Tooltiptext = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtTrGestionTareas_FechaModificacion_Visible = -1;
         edtTrGestionTareas_FechaCreacion_Visible = -1;
         edtTrGestionTareas_FechaFin_Visible = -1;
         edtTrGestionTareas_FechaInicio_Visible = -1;
         edtTrGestionTareas_Descripcion_Visible = -1;
         edtTrGestionTareas_Nombre_Visible = -1;
         edtTrGestionTareas_ID_Visible = -1;
         subGrid_Class = "Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'sPrefix'},{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTareas_ID_Visible',ctrl:'TRGESTIONTAREAS_ID',prop:'Visible'},{av:'edtTrGestionTareas_Nombre_Visible',ctrl:'TRGESTIONTAREAS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTareas_Descripcion_Visible',ctrl:'TRGESTIONTAREAS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTareas_FechaInicio_Visible',ctrl:'TRGESTIONTAREAS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTareas_FechaFin_Visible',ctrl:'TRGESTIONTAREAS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTareas_FechaCreacion_Visible',ctrl:'TRGESTIONTAREAS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTareas_FechaModificacion_Visible',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACION',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E111T2',iparms:[{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E241T1',iparms:[{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E201T2',iparms:[{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'sPrefix'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV44UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTareas_ID_Visible',ctrl:'TRGESTIONTAREAS_ID',prop:'Visible'},{av:'edtTrGestionTareas_Nombre_Visible',ctrl:'TRGESTIONTAREAS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTareas_Descripcion_Visible',ctrl:'TRGESTIONTAREAS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTareas_FechaInicio_Visible',ctrl:'TRGESTIONTAREAS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTareas_FechaFin_Visible',ctrl:'TRGESTIONTAREAS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTareas_FechaCreacion_Visible',ctrl:'TRGESTIONTAREAS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTareas_FechaModificacion_Visible',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACION',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E211T2',iparms:[{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E121T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'sPrefix'},{av:'AV44UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTareas_ID_Visible',ctrl:'TRGESTIONTAREAS_ID',prop:'Visible'},{av:'edtTrGestionTareas_Nombre_Visible',ctrl:'TRGESTIONTAREAS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTareas_Descripcion_Visible',ctrl:'TRGESTIONTAREAS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTareas_FechaInicio_Visible',ctrl:'TRGESTIONTAREAS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTareas_FechaFin_Visible',ctrl:'TRGESTIONTAREAS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTareas_FechaCreacion_Visible',ctrl:'TRGESTIONTAREAS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTareas_FechaModificacion_Visible',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACION',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E221T1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E131T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'sPrefix'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV20GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV44UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'edtTrGestionTareas_ID_Visible',ctrl:'TRGESTIONTAREAS_ID',prop:'Visible'},{av:'edtTrGestionTareas_Nombre_Visible',ctrl:'TRGESTIONTAREAS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTareas_Descripcion_Visible',ctrl:'TRGESTIONTAREAS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTareas_FechaInicio_Visible',ctrl:'TRGESTIONTAREAS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTareas_FechaFin_Visible',ctrl:'TRGESTIONTAREAS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTareas_FechaCreacion_Visible',ctrl:'TRGESTIONTAREAS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTareas_FechaModificacion_Visible',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACION',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E141T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTareas_ID_Visible',ctrl:'TRGESTIONTAREAS_ID',prop:'Visible'},{av:'edtTrGestionTareas_Nombre_Visible',ctrl:'TRGESTIONTAREAS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTareas_Descripcion_Visible',ctrl:'TRGESTIONTAREAS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTareas_FechaInicio_Visible',ctrl:'TRGESTIONTAREAS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTareas_FechaFin_Visible',ctrl:'TRGESTIONTAREAS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTareas_FechaCreacion_Visible',ctrl:'TRGESTIONTAREAS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTareas_FechaModificacion_Visible',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACION',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E151T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTareas_ID_Visible',ctrl:'TRGESTIONTAREAS_ID',prop:'Visible'},{av:'edtTrGestionTareas_Nombre_Visible',ctrl:'TRGESTIONTAREAS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTareas_Descripcion_Visible',ctrl:'TRGESTIONTAREAS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTareas_FechaInicio_Visible',ctrl:'TRGESTIONTAREAS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTareas_FechaFin_Visible',ctrl:'TRGESTIONTAREAS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTareas_FechaCreacion_Visible',ctrl:'TRGESTIONTAREAS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTareas_FechaModificacion_Visible',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACION',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E161T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTareas_ID_Visible',ctrl:'TRGESTIONTAREAS_ID',prop:'Visible'},{av:'edtTrGestionTareas_Nombre_Visible',ctrl:'TRGESTIONTAREAS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTareas_Descripcion_Visible',ctrl:'TRGESTIONTAREAS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTareas_FechaInicio_Visible',ctrl:'TRGESTIONTAREAS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTareas_FechaFin_Visible',ctrl:'TRGESTIONTAREAS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTareas_FechaCreacion_Visible',ctrl:'TRGESTIONTAREAS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTareas_FechaModificacion_Visible',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACION',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E171T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV41OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTareas_ID_Visible',ctrl:'TRGESTIONTAREAS_ID',prop:'Visible'},{av:'edtTrGestionTareas_Nombre_Visible',ctrl:'TRGESTIONTAREAS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTareas_Descripcion_Visible',ctrl:'TRGESTIONTAREAS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTareas_FechaInicio_Visible',ctrl:'TRGESTIONTAREAS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTareas_FechaFin_Visible',ctrl:'TRGESTIONTAREAS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTareas_FechaCreacion_Visible',ctrl:'TRGESTIONTAREAS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTareas_FechaModificacion_Visible',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACION',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E231T1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Trgestiontareas_fechamodificacion',iparms:[{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV13Att_TrGestionTareas_ID_Visible',fld:'vATT_TRGESTIONTAREAS_ID_VISIBLE',pic:''},{av:'AV14Att_TrGestionTareas_Nombre_Visible',fld:'vATT_TRGESTIONTAREAS_NOMBRE_VISIBLE',pic:''},{av:'AV15Att_TrGestionTareas_Descripcion_Visible',fld:'vATT_TRGESTIONTAREAS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTareas_FechaInicio_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAINICIO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTareas_FechaFin_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAFIN_VISIBLE',pic:''},{av:'AV18Att_TrGestionTareas_FechaCreacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHACREACION_VISIBLE',pic:''},{av:'AV19Att_TrGestionTareas_FechaModificacion_Visible',fld:'vATT_TRGESTIONTAREAS_FECHAMODIFICACION_VISIBLE',pic:''}]}");
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
         wcpOAV6TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV53Pgmname = "";
         AV11GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV42GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "TABLEROS_WEB");
         K2borderbyusercontrol_Gridcontrolname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A13TrGestionTareas_Nombre = "";
         A14TrGestionTareas_Descripcion = "";
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
         A17TrGestionTareas_FechaCreacion = DateTime.MinValue;
         A18TrGestionTareas_FechaModificacion = DateTime.MinValue;
         ucK2borderbyusercontrol = new GXUserControl();
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         H001T2_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         H001T2_A18TrGestionTareas_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         H001T2_n18TrGestionTareas_FechaModificacion = new bool[] {false} ;
         H001T2_A17TrGestionTareas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H001T2_n17TrGestionTareas_FechaCreacion = new bool[] {false} ;
         H001T2_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H001T2_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         H001T2_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H001T2_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         H001T2_A14TrGestionTareas_Descripcion = new String[] {""} ;
         H001T2_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         H001T2_A13TrGestionTareas_Nombre = new String[] {""} ;
         H001T2_n13TrGestionTareas_Nombre = new bool[] {false} ;
         H001T2_A12TrGestionTareas_ID = new long[1] ;
         H001T3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV43GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV45Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV46Message = new SdtMessages_Message(context);
         AV49ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV50ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV23GridStateKey = "";
         AV24GridState = new SdtK2BGridState(context);
         AV47TrnContext = new SdtK2BTrnContext(context);
         AV48TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV12GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         GridRow = new GXWebRow();
         lblPreviouspagebuttontextblock_Jsonclick = "";
         lblFirstpagetextblock_Jsonclick = "";
         lblSpacinglefttextblock_Jsonclick = "";
         lblPreviouspagetextblock_Jsonclick = "";
         lblCurrentpagetextblock_Jsonclick = "";
         lblNextpagetextblock_Jsonclick = "";
         lblSpacingrighttextblock_Jsonclick = "";
         lblLastpagetextblock_Jsonclick = "";
         lblNextpagebuttontextblock_Jsonclick = "";
         lblNoresultsfoundtextblock_Jsonclick = "";
         lblK2bgridsettingslabel_Jsonclick = "";
         TempTags = "";
         bttK2bgridsettingssave_Jsonclick = "";
         sImgUrl = "";
         imgImage1_Jsonclick = "";
         bttReport_Jsonclick = "";
         bttExport_Jsonclick = "";
         lblTrgestiontareas_idruntimecolumnatt_Jsonclick = "";
         lblTrgestiontareas_nombreruntimecolumnatt_Jsonclick = "";
         lblTrgestiontareas_descripcionruntimecolumnatt_Jsonclick = "";
         lblTrgestiontareas_fechainicioruntimecolumnatt_Jsonclick = "";
         lblTrgestiontareas_fechafinruntimecolumnatt_Jsonclick = "";
         lblTrgestiontareas_fechacreacionruntimecolumnatt_Jsonclick = "";
         lblTrgestiontareas_fechamodificacionruntimecolumnatt_Jsonclick = "";
         lblRowsperpagegrid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6TrGestionTareas_IDTablero = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trgestiontablerostrgestiontareaswc__default(),
            new Object[][] {
                new Object[] {
               H001T2_A11TrGestionTareas_IDTablero, H001T2_A18TrGestionTareas_FechaModificacion, H001T2_n18TrGestionTareas_FechaModificacion, H001T2_A17TrGestionTareas_FechaCreacion, H001T2_n17TrGestionTareas_FechaCreacion, H001T2_A16TrGestionTareas_FechaFin, H001T2_n16TrGestionTareas_FechaFin, H001T2_A15TrGestionTareas_FechaInicio, H001T2_n15TrGestionTareas_FechaInicio, H001T2_A14TrGestionTareas_Descripcion,
               H001T2_n14TrGestionTareas_Descripcion, H001T2_A13TrGestionTareas_Nombre, H001T2_n13TrGestionTareas_Nombre, H001T2_A12TrGestionTareas_ID
               }
               , new Object[] {
               H001T3_AGRID_nRecordCount
               }
            }
         );
         AV53Pgmname = "TrGestionTablerosTrGestionTareasWC";
         /* GeneXus formulas. */
         AV53Pgmname = "TrGestionTablerosTrGestionTareasWC";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV41OrderedBy ;
      private short initialized ;
      private short AV44UC_OrderedBy ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV20GridSettingsRowsPerPageVariable ;
      private short AV21RowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int subGrid_Rows ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_106 ;
      private int nGXsfl_106_idx=1 ;
      private int AV9CurrentPage ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtTrGestionTareas_ID_Visible ;
      private int edtTrGestionTareas_Nombre_Visible ;
      private int edtTrGestionTareas_Descripcion_Visible ;
      private int edtTrGestionTareas_FechaInicio_Visible ;
      private int edtTrGestionTareas_FechaFin_Visible ;
      private int edtTrGestionTareas_FechaCreacion_Visible ;
      private int edtTrGestionTareas_FechaModificacion_Visible ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV54GXV1 ;
      private int AV55GXV2 ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV56GXV3 ;
      private int AV10K2BMaxPages ;
      private int lblFirstpagetextblock_Visible ;
      private int lblSpacinglefttextblock_Visible ;
      private int lblPreviouspagetextblock_Visible ;
      private int lblLastpagetextblock_Visible ;
      private int lblSpacingrighttextblock_Visible ;
      private int lblNextpagetextblock_Visible ;
      private int tblK2btoolspagingcontainertable_Visible ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A12TrGestionTareas_ID ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sGXsfl_106_idx="0001" ;
      private String AV53Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String K2borderbyusercontrol_Gridcontrolname ;
      private String GX_FocusControl ;
      private String divMaintable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String divTable2_Internalname ;
      private String divTable6_Internalname ;
      private String divTable10_Internalname ;
      private String divGlobalgridtable_Internalname ;
      private String divMaingridcontainergrid_Internalname ;
      private String sStyleString ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String subGrid_Header ;
      private String A13TrGestionTareas_Nombre ;
      private String divTable4_Internalname ;
      private String divSection8_Internalname ;
      private String divK2btoolsabstracthiddenitemsgrid_Internalname ;
      private String K2borderbyusercontrol_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String chkavAtt_trgestiontareas_id_visible_Internalname ;
      private String edtTrGestionTareas_ID_Internalname ;
      private String edtTrGestionTareas_Nombre_Internalname ;
      private String edtTrGestionTareas_Descripcion_Internalname ;
      private String edtTrGestionTareas_FechaInicio_Internalname ;
      private String edtTrGestionTareas_FechaFin_Internalname ;
      private String edtTrGestionTareas_FechaCreacion_Internalname ;
      private String edtTrGestionTareas_FechaModificacion_Internalname ;
      private String cmbavGridsettingsrowsperpagevariable_Internalname ;
      private String scmdbuf ;
      private String chkavAtt_trgestiontareas_nombre_visible_Internalname ;
      private String chkavAtt_trgestiontareas_descripcion_visible_Internalname ;
      private String chkavAtt_trgestiontareas_fechainicio_visible_Internalname ;
      private String chkavAtt_trgestiontareas_fechafin_visible_Internalname ;
      private String chkavAtt_trgestiontareas_fechacreacion_visible_Internalname ;
      private String chkavAtt_trgestiontareas_fechamodificacion_visible_Internalname ;
      private String divDownloadactionstable_Internalname ;
      private String bttReport_Tooltiptext ;
      private String bttReport_Internalname ;
      private String bttExport_Tooltiptext ;
      private String bttExport_Internalname ;
      private String divK2bgridsettingscontentoutertable_Internalname ;
      private String divDownloadsactionssectioncontainer_Internalname ;
      private String tblNoresultsfoundtable_Internalname ;
      private String lblFirstpagetextblock_Caption ;
      private String lblFirstpagetextblock_Internalname ;
      private String lblPreviouspagetextblock_Caption ;
      private String lblPreviouspagetextblock_Internalname ;
      private String lblCurrentpagetextblock_Caption ;
      private String lblCurrentpagetextblock_Internalname ;
      private String lblNextpagetextblock_Caption ;
      private String lblNextpagetextblock_Internalname ;
      private String lblLastpagetextblock_Caption ;
      private String lblLastpagetextblock_Internalname ;
      private String lblPreviouspagebuttontextblock_Class ;
      private String lblPreviouspagebuttontextblock_Internalname ;
      private String lblNextpagebuttontextblock_Class ;
      private String lblNextpagebuttontextblock_Internalname ;
      private String cellFirstpagecell_Class ;
      private String cellFirstpagecell_Internalname ;
      private String cellSpacingleftcell_Class ;
      private String cellSpacingleftcell_Internalname ;
      private String lblSpacinglefttextblock_Internalname ;
      private String cellPreviouspagecell_Class ;
      private String cellPreviouspagecell_Internalname ;
      private String cellLastpagecell_Class ;
      private String cellLastpagecell_Internalname ;
      private String cellSpacingrightcell_Class ;
      private String cellSpacingrightcell_Internalname ;
      private String lblSpacingrighttextblock_Internalname ;
      private String cellNextpagecell_Class ;
      private String cellNextpagecell_Internalname ;
      private String tblK2btoolspagingcontainertable_Internalname ;
      private String cellPreviouspagebuttoncell_Internalname ;
      private String lblPreviouspagebuttontextblock_Jsonclick ;
      private String lblFirstpagetextblock_Jsonclick ;
      private String lblSpacinglefttextblock_Jsonclick ;
      private String lblPreviouspagetextblock_Jsonclick ;
      private String cellCurrentpagecell_Internalname ;
      private String lblCurrentpagetextblock_Jsonclick ;
      private String lblNextpagetextblock_Jsonclick ;
      private String lblSpacingrighttextblock_Jsonclick ;
      private String lblLastpagetextblock_Jsonclick ;
      private String cellNextpagebuttoncell_Internalname ;
      private String lblNextpagebuttontextblock_Jsonclick ;
      private String lblNoresultsfoundtextblock_Internalname ;
      private String lblNoresultsfoundtextblock_Jsonclick ;
      private String tblTable7_Internalname ;
      private String divK2bgridsettingstable_Internalname ;
      private String lblK2bgridsettingslabel_Internalname ;
      private String lblK2bgridsettingslabel_Jsonclick ;
      private String TempTags ;
      private String bttK2bgridsettingssave_Internalname ;
      private String bttK2bgridsettingssave_Jsonclick ;
      private String sImgUrl ;
      private String imgImage1_Internalname ;
      private String imgImage1_Jsonclick ;
      private String tblK2btabledownloadssectioncontainer_Internalname ;
      private String bttReport_Jsonclick ;
      private String bttExport_Jsonclick ;
      private String tblGridsettingstable_content_Internalname ;
      private String lblTrgestiontareas_idruntimecolumnatt_Internalname ;
      private String lblTrgestiontareas_idruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontareas_nombreruntimecolumnatt_Internalname ;
      private String lblTrgestiontareas_nombreruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontareas_descripcionruntimecolumnatt_Internalname ;
      private String lblTrgestiontareas_descripcionruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontareas_fechainicioruntimecolumnatt_Internalname ;
      private String lblTrgestiontareas_fechainicioruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontareas_fechafinruntimecolumnatt_Internalname ;
      private String lblTrgestiontareas_fechafinruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontareas_fechacreacionruntimecolumnatt_Internalname ;
      private String lblTrgestiontareas_fechacreacionruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontareas_fechamodificacionruntimecolumnatt_Internalname ;
      private String lblTrgestiontareas_fechamodificacionruntimecolumnatt_Jsonclick ;
      private String lblRowsperpagegrid_Internalname ;
      private String lblRowsperpagegrid_Jsonclick ;
      private String cmbavGridsettingsrowsperpagevariable_Jsonclick ;
      private String sCtrlAV6TrGestionTareas_IDTablero ;
      private String sGXsfl_106_fel_idx="0001" ;
      private String ROClassString ;
      private String edtTrGestionTareas_ID_Jsonclick ;
      private String edtTrGestionTareas_Nombre_Jsonclick ;
      private String edtTrGestionTareas_Descripcion_Jsonclick ;
      private String edtTrGestionTareas_FechaInicio_Jsonclick ;
      private String edtTrGestionTareas_FechaFin_Jsonclick ;
      private String edtTrGestionTareas_FechaCreacion_Jsonclick ;
      private String edtTrGestionTareas_FechaModificacion_Jsonclick ;
      private DateTime A15TrGestionTareas_FechaInicio ;
      private DateTime A16TrGestionTareas_FechaFin ;
      private DateTime A17TrGestionTareas_FechaCreacion ;
      private DateTime A18TrGestionTareas_FechaModificacion ;
      private bool entryPointCalled ;
      private bool AV13Att_TrGestionTareas_ID_Visible ;
      private bool AV14Att_TrGestionTareas_Nombre_Visible ;
      private bool AV15Att_TrGestionTareas_Descripcion_Visible ;
      private bool AV16Att_TrGestionTareas_FechaInicio_Visible ;
      private bool AV17Att_TrGestionTareas_FechaFin_Visible ;
      private bool AV18Att_TrGestionTareas_FechaCreacion_Visible ;
      private bool AV19Att_TrGestionTareas_FechaModificacion_Visible ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n13TrGestionTareas_Nombre ;
      private bool n14TrGestionTareas_Descripcion ;
      private bool n15TrGestionTareas_FechaInicio ;
      private bool n16TrGestionTareas_FechaFin ;
      private bool n17TrGestionTareas_FechaCreacion ;
      private bool n18TrGestionTareas_FechaModificacion ;
      private bool bGXsfl_106_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV22RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private String A14TrGestionTareas_Descripcion ;
      private String AV23GridStateKey ;
      private Guid AV6TrGestionTareas_IDTablero ;
      private Guid wcpOAV6TrGestionTareas_IDTablero ;
      private Guid A11TrGestionTareas_IDTablero ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_trgestiontareas_id_visible ;
      private GXCheckbox chkavAtt_trgestiontareas_nombre_visible ;
      private GXCheckbox chkavAtt_trgestiontareas_descripcion_visible ;
      private GXCheckbox chkavAtt_trgestiontareas_fechainicio_visible ;
      private GXCheckbox chkavAtt_trgestiontareas_fechafin_visible ;
      private GXCheckbox chkavAtt_trgestiontareas_fechacreacion_visible ;
      private GXCheckbox chkavAtt_trgestiontareas_fechamodificacion_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private IDataStoreProvider pr_default ;
      private Guid[] H001T2_A11TrGestionTareas_IDTablero ;
      private DateTime[] H001T2_A18TrGestionTareas_FechaModificacion ;
      private bool[] H001T2_n18TrGestionTareas_FechaModificacion ;
      private DateTime[] H001T2_A17TrGestionTareas_FechaCreacion ;
      private bool[] H001T2_n17TrGestionTareas_FechaCreacion ;
      private DateTime[] H001T2_A16TrGestionTareas_FechaFin ;
      private bool[] H001T2_n16TrGestionTareas_FechaFin ;
      private DateTime[] H001T2_A15TrGestionTareas_FechaInicio ;
      private bool[] H001T2_n15TrGestionTareas_FechaInicio ;
      private String[] H001T2_A14TrGestionTareas_Descripcion ;
      private bool[] H001T2_n14TrGestionTareas_Descripcion ;
      private String[] H001T2_A13TrGestionTareas_Nombre ;
      private bool[] H001T2_n13TrGestionTareas_Nombre ;
      private long[] H001T2_A12TrGestionTareas_ID ;
      private long[] H001T3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV11GridColumns ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV42GridOrders ;
      private GXBaseCollection<SdtMessages_Message> AV45Messages ;
      private GXBaseCollection<SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV49ActivityList ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV12GridColumn ;
      private SdtK2BGridState AV24GridState ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV43GridOrder ;
      private SdtMessages_Message AV46Message ;
      private SdtK2BTrnContext AV47TrnContext ;
      private SdtK2BTrnContext_Attribute AV48TrnContextAtt ;
      private SdtK2BActivityList_K2BActivityListItem AV50ActivityListItem ;
   }

   public class trgestiontablerostrgestiontareaswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001T2( IGxContext context ,
                                             short AV41OrderedBy ,
                                             Guid AV6TrGestionTareas_IDTablero ,
                                             Guid A11TrGestionTareas_IDTablero )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int2 ;
         GXv_int2 = new short [4] ;
         Object[] GXv_Object3 ;
         GXv_Object3 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [TrGestionTareas_IDTablero], [TrGestionTareas_FechaModificacion], [TrGestionTareas_FechaCreacion], [TrGestionTareas_FechaFin], [TrGestionTareas_FechaInicio], [TrGestionTareas_Descripcion], [TrGestionTareas_Nombre], [TrGestionTareas_ID]";
         sFromString = " FROM TABLERO.[TrGestionTareas]";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE ([TrGestionTareas_IDTablero] = @AV6TrGestionTareas_IDTablero)";
         if ( AV41OrderedBy == 0 )
         {
            sOrderString = sOrderString + " ORDER BY [TrGestionTareas_ID]";
         }
         else if ( AV41OrderedBy == 1 )
         {
            sOrderString = sOrderString + " ORDER BY [TrGestionTareas_ID] DESC";
         }
         else if ( AV41OrderedBy == 2 )
         {
            sOrderString = sOrderString + " ORDER BY [TrGestionTareas_Nombre]";
         }
         else if ( AV41OrderedBy == 3 )
         {
            sOrderString = sOrderString + " ORDER BY [TrGestionTareas_Nombre] DESC";
         }
         else if ( true )
         {
            sOrderString = sOrderString + " ORDER BY [TrGestionTareas_ID]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H001T3( IGxContext context ,
                                             short AV41OrderedBy ,
                                             Guid AV6TrGestionTareas_IDTablero ,
                                             Guid A11TrGestionTareas_IDTablero )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int4 ;
         GXv_int4 = new short [1] ;
         Object[] GXv_Object5 ;
         GXv_Object5 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM TABLERO.[TrGestionTareas]";
         scmdbuf = scmdbuf + " WHERE ([TrGestionTareas_IDTablero] = @AV6TrGestionTareas_IDTablero)";
         if ( AV41OrderedBy == 0 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( AV41OrderedBy == 1 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( AV41OrderedBy == 2 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( AV41OrderedBy == 3 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( true )
         {
            scmdbuf = scmdbuf + "";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001T2(context, (short)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] );
               case 1 :
                     return conditional_H001T3(context, (short)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001T2 ;
          prmH001T2 = new Object[] {
          new Object[] {"@AV6TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH001T3 ;
          prmH001T3 = new Object[] {
          new Object[] {"@AV6TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001T2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001T3,1, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((String[]) buf[9])[0] = rslt.getLongVarchar(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((String[]) buf[11])[0] = rslt.getString(7, 100) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((long[]) buf[13])[0] = rslt.getLong(8) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (Guid)parms[4]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[5]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[6]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[7]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (Guid)parms[1]);
                }
                return;
       }
    }

 }

}
