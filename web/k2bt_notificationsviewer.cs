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
   public class k2bt_notificationsviewer : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public k2bt_notificationsviewer( )
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

      public k2bt_notificationsviewer( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
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
         chkavNotificationisread = new GXCheckbox();
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
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Notificationsgrid") == 0 )
               {
                  nRC_GXsfl_51 = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  nGXsfl_51_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  sGXsfl_51_idx = GetNextPar( );
                  sPrefix = GetNextPar( );
                  AV20MarkAsRead_Action = GetNextPar( );
                  edtavMarkasread_action_Tooltiptext = GetNextPar( );
                  AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Tooltiptext", edtavMarkasread_action_Tooltiptext, !bGXsfl_51_Refreshing);
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrNotificationsgrid_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Notificationsgrid") == 0 )
               {
                  AV20MarkAsRead_Action = GetNextPar( );
                  edtavMarkasread_action_Tooltiptext = GetNextPar( );
                  AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Tooltiptext", edtavMarkasread_action_Tooltiptext, !bGXsfl_51_Refreshing);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV9DP_SDT_ITEM_NotificationsGrid);
                  AV27NotificationIsRead = StringUtil.StrToBool( GetNextPar( ));
                  sPrefix = GetNextPar( );
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrNotificationsgrid_refresh( AV20MarkAsRead_Action, AV9DP_SDT_ITEM_NotificationsGrid, AV27NotificationIsRead, sPrefix) ;
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
            PA0Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavViewall_action_Enabled = 0;
               AssignProp(sPrefix, false, edtavViewall_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavViewall_action_Enabled), 5, 0), true);
               edtavRefresh_action_Enabled = 0;
               AssignProp(sPrefix, false, edtavRefresh_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRefresh_action_Enabled), 5, 0), true);
               WS0Y2( ) ;
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
            context.SendWebValue( "K2 BT_Notifications Viewer") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210202185024", false, true);
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bt_notificationsviewer.aspx") +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDP_SDT_ITEM_NOTIFICATIONSGRID", GetSecureSignedToken( sPrefix, AV9DP_SDT_ITEM_NotificationsGrid, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_51", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_51), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV9DP_SDT_ITEM_NotificationsGrid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV9DP_SDT_ITEM_NotificationsGrid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDP_SDT_ITEM_NOTIFICATIONSGRID", GetSecureSignedToken( sPrefix, AV9DP_SDT_ITEM_NotificationsGrid, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTIFICATIONINFO", AV26NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTIFICATIONINFO", AV26NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMARKASREAD_ACTION_Tooltiptext", StringUtil.RTrim( edtavMarkasread_action_Tooltiptext));
      }

      protected void RenderHtmlCloseForm0Y2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("k2bt_notificationsviewer.js", "?202210202185028", false, true);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "K2BT_NotificationsViewer" ;
      }

      public override String GetPgmdesc( )
      {
         return "K2 BT_Notifications Viewer" ;
      }

      protected void WB0Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bt_notificationsviewer.aspx");
               context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", divContenttable_Class, "left", "top", "", "", "div");
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
            wb_table1_15_0Y2( true) ;
         }
         else
         {
            wb_table1_15_0Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_0Y2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_notificationsgrid_Internalname, divGridcomponentcontent_notificationsgrid_Visible, 0, "px", 0, "px", divGridcomponentcontent_notificationsgrid_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section1_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section7_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatLeft", "left", "top", "", "", "div");
            wb_table2_32_0Y2( true) ;
         }
         else
         {
            wb_table2_32_0Y2( false) ;
         }
         return  ;
      }

      protected void wb_table2_32_0Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section3_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatRight", "left", "top", "", "", "div");
            wb_table3_38_0Y2( true) ;
         }
         else
         {
            wb_table3_38_0Y2( false) ;
         }
         return  ;
      }

      protected void wb_table3_38_0Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutcontent_userregion_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            NotificationsgridContainer.SetIsFreestyle(true);
            NotificationsgridContainer.SetWrapped(nGXWrapped);
            if ( NotificationsgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"NotificationsgridContainer"+"DivS\" data-gxgridid=\"51\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subNotificationsgrid_Internalname, subNotificationsgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               NotificationsgridContainer.AddObjectProperty("GridName", "Notificationsgrid");
            }
            else
            {
               NotificationsgridContainer.AddObjectProperty("GridName", "Notificationsgrid");
               NotificationsgridContainer.AddObjectProperty("Header", subNotificationsgrid_Header);
               NotificationsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               NotificationsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
               NotificationsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Backcolorstyle), 1, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("CmpContext", sPrefix);
               NotificationsgridContainer.AddObjectProperty("InMasterPage", "false");
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", context.convertURL( AV24NotificationIcon));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", lblNotificationsgrid_notificationtexttb_Caption);
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", context.convertURL( AV20MarkAsRead_Action));
               NotificationsgridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavMarkasread_action_Tooltiptext));
               NotificationsgridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMarkasread_action_Visible), 5, 0, ".", "")));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", lblNotificationsgrid_notificationtexttb_Caption);
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", AV28NotificationText);
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", context.localUtil.TToC( AV11EventCreationDateTime, 10, 12, 1, 2, "/", ":", " "));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV27NotificationIsRead));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25NotificationId), 15, 0, ".", "")));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", AV12EventTargetUrl);
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Selectedindex), 4, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Allowselection), 1, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Selectioncolor), 9, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Allowhovering), 1, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Hoveringcolor), 9, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Allowcollapsing), 1, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 51 )
         {
            wbEnd = 0;
            nRC_GXsfl_51 = (int)(nGXsfl_51_idx-1);
            if ( NotificationsgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"NotificationsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Notificationsgrid", NotificationsgridContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData", NotificationsgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData"+"V", NotificationsgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"NotificationsgridContainerData"+"V"+"\" value='"+NotificationsgridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table4_85_0Y2( true) ;
         }
         else
         {
            wb_table4_85_0Y2( false) ;
         }
         return  ;
      }

      protected void wb_table4_85_0Y2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
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
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 51 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( NotificationsgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"NotificationsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Notificationsgrid", NotificationsgridContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData", NotificationsgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData"+"V", NotificationsgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"NotificationsgridContainerData"+"V"+"\" value='"+NotificationsgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Y2( )
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
               Form.Meta.addItem("description", "K2 BT_Notifications Viewer", 0) ;
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
               STRUP0Y0( ) ;
            }
         }
      }

      protected void WS0Y2( )
      {
         START0Y2( ) ;
         EVT0Y2( ) ;
      }

      protected void EVT0Y2( )
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
                                 STRUP0Y0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_VIEWNOTIFICATION'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_ViewNotification' */
                                    E110Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavNotificationtext_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "NOTIFICATIONSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "VMARKASREAD_ACTION.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'E_VIEWNOTIFICATION'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "VMARKASREAD_ACTION.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              nGXsfl_51_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
                              SubsflControlProps_512( ) ;
                              AV24NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                              AssignProp(sPrefix, false, edtavNotificationicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24NotificationIcon)) ? AV38Notificationicon_GXI : context.convertURL( context.PathToRelativeUrl( AV24NotificationIcon))), !bGXsfl_51_Refreshing);
                              AssignProp(sPrefix, false, edtavNotificationicon_Internalname, "SrcSet", context.GetImageSrcSet( AV24NotificationIcon), true);
                              AV20MarkAsRead_Action = cgiGet( edtavMarkasread_action_Internalname);
                              AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20MarkAsRead_Action)) ? AV36Markasread_action_GXI : context.convertURL( context.PathToRelativeUrl( AV20MarkAsRead_Action))), !bGXsfl_51_Refreshing);
                              AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "SrcSet", context.GetImageSrcSet( AV20MarkAsRead_Action), true);
                              AV28NotificationText = cgiGet( edtavNotificationtext_Internalname);
                              AssignAttri(sPrefix, false, edtavNotificationtext_Internalname, AV28NotificationText);
                              if ( context.localUtil.VCDateTime( cgiGet( edtavEventcreationdatetime_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Event Creation Date Time"}), 1, "vEVENTCREATIONDATETIME");
                                 GX_FocusControl = edtavEventcreationdatetime_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV11EventCreationDateTime = (DateTime)(DateTime.MinValue);
                                 AssignAttri(sPrefix, false, edtavEventcreationdatetime_Internalname, context.localUtil.TToC( AV11EventCreationDateTime, 8, 12, 1, 2, "/", ":", " "));
                              }
                              else
                              {
                                 AV11EventCreationDateTime = context.localUtil.CToT( cgiGet( edtavEventcreationdatetime_Internalname), 0);
                                 AssignAttri(sPrefix, false, edtavEventcreationdatetime_Internalname, context.localUtil.TToC( AV11EventCreationDateTime, 8, 12, 1, 2, "/", ":", " "));
                              }
                              AV27NotificationIsRead = StringUtil.StrToBool( cgiGet( chkavNotificationisread_Internalname));
                              AssignAttri(sPrefix, false, chkavNotificationisread_Internalname, AV27NotificationIsRead);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNOTIFICATIONID");
                                 GX_FocusControl = edtavNotificationid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV25NotificationId = 0;
                                 AssignAttri(sPrefix, false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV25NotificationId), 15, 0));
                              }
                              else
                              {
                                 AV25NotificationId = (long)(context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ","));
                                 AssignAttri(sPrefix, false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV25NotificationId), 15, 0));
                              }
                              AV12EventTargetUrl = cgiGet( edtavEventtargeturl_Internalname);
                              AssignAttri(sPrefix, false, edtavEventtargeturl_Internalname, AV12EventTargetUrl);
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
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E120Y2 ();
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
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E130Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "NOTIFICATIONSGRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E140Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMARKASREAD_ACTION.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E150Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_VIEWNOTIFICATION'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_ViewNotification' */
                                          E110Y2 ();
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
                                       STRUP0Y0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
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

      protected void WE0Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0Y2( ) ;
            }
         }
      }

      protected void PA0Y2( )
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavViewall_action_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrNotificationsgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_512( ) ;
         while ( nGXsfl_51_idx <= nRC_GXsfl_51 )
         {
            sendrow_512( ) ;
            nGXsfl_51_idx = ((subNotificationsgrid_Islastpage==1)&&(nGXsfl_51_idx+1>subNotificationsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_51_idx+1);
            sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
            SubsflControlProps_512( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( NotificationsgridContainer)) ;
         /* End function gxnrNotificationsgrid_newrow */
      }

      protected void gxgrNotificationsgrid_refresh( String AV20MarkAsRead_Action ,
                                                    GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV9DP_SDT_ITEM_NotificationsGrid ,
                                                    bool AV27NotificationIsRead ,
                                                    String sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E130Y2 ();
         NOTIFICATIONSGRID_nCurrentRecord = 0;
         RF0Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrNotificationsgrid_refresh */
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
         RF0Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavViewall_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavViewall_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavViewall_action_Enabled), 5, 0), true);
         edtavRefresh_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavRefresh_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRefresh_action_Enabled), 5, 0), true);
      }

      protected void RF0Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            NotificationsgridContainer.ClearRows();
         }
         wbStart = 51;
         /* Execute user event: Refresh */
         E130Y2 ();
         nGXsfl_51_idx = 1;
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_512( ) ;
         bGXsfl_51_Refreshing = true;
         NotificationsgridContainer.AddObjectProperty("GridName", "Notificationsgrid");
         NotificationsgridContainer.AddObjectProperty("CmpContext", sPrefix);
         NotificationsgridContainer.AddObjectProperty("InMasterPage", "false");
         NotificationsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         NotificationsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         NotificationsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         NotificationsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         NotificationsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Backcolorstyle), 1, 0, ".", "")));
         NotificationsgridContainer.PageSize = subNotificationsgrid_fnc_Recordsperpage( );
         if ( subNotificationsgrid_Islastpage != 0 )
         {
            NOTIFICATIONSGRID_nFirstRecordOnPage = (long)(subNotificationsgrid_fnc_Recordcount( )-subNotificationsgrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"NOTIFICATIONSGRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(NOTIFICATIONSGRID_nFirstRecordOnPage), 15, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("NOTIFICATIONSGRID_nFirstRecordOnPage", NOTIFICATIONSGRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_512( ) ;
            E140Y2 ();
            wbEnd = 51;
            WB0Y0( ) ;
         }
         bGXsfl_51_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Y2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV9DP_SDT_ITEM_NotificationsGrid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV9DP_SDT_ITEM_NotificationsGrid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDP_SDT_ITEM_NOTIFICATIONSGRID", GetSecureSignedToken( sPrefix, AV9DP_SDT_ITEM_NotificationsGrid, context));
      }

      protected int subNotificationsgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subNotificationsgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subNotificationsgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subNotificationsgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavViewall_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavViewall_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavViewall_action_Enabled), 5, 0), true);
         edtavRefresh_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavRefresh_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRefresh_action_Enabled), 5, 0), true);
      }

      protected void STRUP0Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vNOTIFICATIONINFO"), AV26NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_51 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_51"), ".", ","));
            /* Read variables values. */
            AV31ViewAll_Action = cgiGet( edtavViewall_action_Internalname);
            AssignAttri(sPrefix, false, "AV31ViewAll_Action", AV31ViewAll_Action);
            AV29Refresh_Action = cgiGet( edtavRefresh_action_Internalname);
            AssignAttri(sPrefix, false, "AV29Refresh_Action", AV29Refresh_Action);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E120Y2 ();
         if (returnInSub) return;
      }

      protected void E120Y2( )
      {
         /* Start Routine */
         subNotificationsgrid_Backcolorstyle = 3;
         if ( (0==AV8CurrentPage_NotificationsGrid) )
         {
            AV8CurrentPage_NotificationsGrid = 1;
            AssignAttri(sPrefix, false, "AV8CurrentPage_NotificationsGrid", StringUtil.LTrimStr( (decimal)(AV8CurrentPage_NotificationsGrid), 4, 0));
         }
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(NOTIFICATIONSGRID)' */
         S112 ();
         if (returnInSub) return;
         imgTogglenotifications_Bitmap = context.GetImagePath( "1942f1bc-1f65-4fa8-8c23-b53fd3aa4826", "", context.GetTheme( ));
         AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgTogglenotifications_Bitmap)), true);
         AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "SrcSet", context.GetImageSrcSet( imgTogglenotifications_Bitmap), true);
         AV20MarkAsRead_Action = context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20MarkAsRead_Action)) ? AV36Markasread_action_GXI : context.convertURL( context.PathToRelativeUrl( AV20MarkAsRead_Action))), !bGXsfl_51_Refreshing);
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "SrcSet", context.GetImageSrcSet( AV20MarkAsRead_Action), true);
         AV36Markasread_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20MarkAsRead_Action)) ? AV36Markasread_action_GXI : context.convertURL( context.PathToRelativeUrl( AV20MarkAsRead_Action))), !bGXsfl_51_Refreshing);
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "SrcSet", context.GetImageSrcSet( AV20MarkAsRead_Action), true);
         edtavMarkasread_action_Tooltiptext = "Mark As Read";
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Tooltiptext", edtavMarkasread_action_Tooltiptext, !bGXsfl_51_Refreshing);
         if ( StringUtil.StrCmp(AV14HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'U_OPENPAGE' */
            S122 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'U_STARTPAGE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E130Y2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S122( )
      {
         /* 'U_OPENPAGE' Routine */
         divGridcomponentcontent_notificationsgrid_Class = "ControlBeautify_CollapsableTable"+" "+"K2BT_NotificationsTableContainer";
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Class", divGridcomponentcontent_notificationsgrid_Class, true);
         divContenttable_Class = "ControlBeautify_ParentCollapsableTable";
         AssignProp(sPrefix, false, divContenttable_Internalname, "Class", divContenttable_Class, true);
         divGridcomponentcontent_notificationsgrid_Visible = 0;
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
      }

      protected void S142( )
      {
         /* 'U_REFRESHPAGE' Routine */
      }

      protected void S152( )
      {
         /* 'U_TOGGLENOTIFICATIONS' Routine */
         divGridcomponentcontent_notificationsgrid_Visible = (!((divGridcomponentcontent_notificationsgrid_Visible==1)) ? 1 : 0);
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0), true);
      }

      private void E140Y2( )
      {
         /* Notificationsgrid_Load Routine */
         AV15I_LoadCount_NotificationsGrid = 0;
         GXt_objcol_SdtWebNotificationSDT_Notification1 = AV10DP_SDT_NotificationsGrid;
         new GeneXus.Programs.k2btools.integrationprocedures.getlatestnotificationsforcurrentuser(context ).execute( out  GXt_objcol_SdtWebNotificationSDT_Notification1) ;
         AV10DP_SDT_NotificationsGrid = GXt_objcol_SdtWebNotificationSDT_Notification1;
         if ( AV10DP_SDT_NotificationsGrid.Count == 0 )
         {
            tblI_noresultsfoundtablename_notificationsgrid_Visible = 1;
            AssignProp(sPrefix, false, tblI_noresultsfoundtablename_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_notificationsgrid_Visible), 5, 0), true);
         }
         else
         {
            tblI_noresultsfoundtablename_notificationsgrid_Visible = 0;
            AssignProp(sPrefix, false, tblI_noresultsfoundtablename_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_notificationsgrid_Visible), 5, 0), true);
         }
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV10DP_SDT_NotificationsGrid.Count )
         {
            AV9DP_SDT_ITEM_NotificationsGrid = ((GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification)AV10DP_SDT_NotificationsGrid.Item(AV37GXV1));
            AV15I_LoadCount_NotificationsGrid = (short)(AV15I_LoadCount_NotificationsGrid+1);
            AV19LoadRow_NotificationsGrid = true;
            AV24NotificationIcon = AV9DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationicon;
            AssignAttri(sPrefix, false, edtavNotificationicon_Internalname, AV24NotificationIcon);
            AV38Notificationicon_GXI = AV9DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationicon_gxi;
            AV28NotificationText = AV9DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationtext;
            AssignAttri(sPrefix, false, edtavNotificationtext_Internalname, AV28NotificationText);
            AV11EventCreationDateTime = AV9DP_SDT_ITEM_NotificationsGrid.gxTpr_Eventcreationdatetime;
            AssignAttri(sPrefix, false, edtavEventcreationdatetime_Internalname, context.localUtil.TToC( AV11EventCreationDateTime, 8, 12, 1, 2, "/", ":", " "));
            AV27NotificationIsRead = AV9DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationisread;
            AssignAttri(sPrefix, false, chkavNotificationisread_Internalname, AV27NotificationIsRead);
            AV25NotificationId = AV9DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationid;
            AssignAttri(sPrefix, false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV25NotificationId), 15, 0));
            AV12EventTargetUrl = AV9DP_SDT_ITEM_NotificationsGrid.gxTpr_Eventtargeturl;
            AssignAttri(sPrefix, false, edtavEventtargeturl_Internalname, AV12EventTargetUrl);
            AV20MarkAsRead_Action = context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavMarkasread_action_Internalname, AV20MarkAsRead_Action);
            AV36Markasread_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( )));
            edtavMarkasread_action_Tooltiptext = "Mark As Read";
            lblNotificationsgrid_notificationtexttb_Caption = AV28NotificationText;
            GXt_char2 = "";
            new getdatefriendlystring(context ).execute(  AV11EventCreationDateTime, out  GXt_char2) ;
            lblNotificationsgrid_notificationdatetb_Caption = GXt_char2;
            if ( AV27NotificationIsRead )
            {
               edtavMarkasread_action_Visible = 0;
               divNotificationsgrid_notificationcontainer_Class = "K2BT_NotificationContainer";
               AssignProp(sPrefix, false, divNotificationsgrid_notificationcontainer_Internalname, "Class", divNotificationsgrid_notificationcontainer_Class, !bGXsfl_51_Refreshing);
            }
            else
            {
               edtavMarkasread_action_Visible = 1;
               divNotificationsgrid_notificationcontainer_Class = "K2BT_NotificationContainer"+" "+"K2BT_UnreadNotificationContainer";
               AssignProp(sPrefix, false, divNotificationsgrid_notificationcontainer_Internalname, "Class", divNotificationsgrid_notificationcontainer_Class, !bGXsfl_51_Refreshing);
            }
            /* Execute user subroutine: 'U_LOADROWVARS(NOTIFICATIONSGRID)' */
            S162 ();
            if (returnInSub) return;
            if ( AV19LoadRow_NotificationsGrid )
            {
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 51;
               }
               sendrow_512( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_51_Refreshing )
               {
                  context.DoAjaxLoad(51, NotificationsgridRow);
               }
            }
            else
            {
               AV15I_LoadCount_NotificationsGrid = (short)(AV15I_LoadCount_NotificationsGrid-1);
            }
            AV37GXV1 = (int)(AV37GXV1+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9DP_SDT_ITEM_NotificationsGrid", AV9DP_SDT_ITEM_NotificationsGrid);
      }

      protected void S162( )
      {
         /* 'U_LOADROWVARS(NOTIFICATIONSGRID)' Routine */
         bttViewnotification_Caption = AV9DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationactioncaption;
         AssignProp(sPrefix, false, bttViewnotification_Internalname, "Caption", bttViewnotification_Caption, !bGXsfl_51_Refreshing);
         if ( ! AV27NotificationIsRead )
         {
            imgTogglenotifications_Bitmap = context.GetImagePath( "f26a7e3e-7126-48a2-8f29-3aaa280b1932", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgTogglenotifications_Bitmap)), true);
            AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "SrcSet", context.GetImageSrcSet( imgTogglenotifications_Bitmap), true);
         }
      }

      protected void E150Y2( )
      {
         /* Markasread_action_Click Routine */
         /* Execute user subroutine: 'U_MARKASREAD' */
         S172 ();
         if (returnInSub) return;
      }

      protected void S172( )
      {
         /* 'U_MARKASREAD' Routine */
         GXt_int3 = (short)(Convert.ToInt16(AV30Success));
         new GeneXus.Programs.k2btools.integrationprocedures.markwebnotificationasread(context ).execute(  (short)(AV25NotificationId), out  GXt_int3, out  AV22Messages) ;
         AV30Success = (bool)(Convert.ToBoolean(GXt_int3));
         if ( AV30Success )
         {
            context.CommitDataStores("k2bt_notificationsviewer",pr_default);
         }
         else
         {
            AV39GXV2 = 1;
            while ( AV39GXV2 <= AV22Messages.Count )
            {
               AV21Message = ((SdtMessages_Message)AV22Messages.Item(AV39GXV2));
               GX_msglist.addItem(AV21Message.gxTpr_Description);
               AV39GXV2 = (int)(AV39GXV2+1);
            }
         }
         gxgrNotificationsgrid_refresh( AV20MarkAsRead_Action, AV9DP_SDT_ITEM_NotificationsGrid, AV27NotificationIsRead, sPrefix) ;
      }

      protected void E110Y2( )
      {
         /* 'E_ViewNotification' Routine */
         /* Execute user subroutine: 'U_VIEWNOTIFICATION' */
         S182 ();
         if (returnInSub) return;
      }

      protected void S182( )
      {
         /* 'U_VIEWNOTIFICATION' Routine */
         AV5Url = AV12EventTargetUrl;
         /* Execute user subroutine: 'U_MARKASREAD' */
         S172 ();
         if (returnInSub) return;
         CallWebObject(formatLink(AV5Url) );
         context.wjLocDisableFrm = 0;
      }

      protected void S112( )
      {
         /* 'REFRESHGRIDACTIONS(NOTIFICATIONSGRID)' Routine */
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(NOTIFICATIONSGRID)' */
         S212 ();
         if (returnInSub) return;
      }

      protected void S212( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(NOTIFICATIONSGRID)' Routine */
         edtavViewall_action_Visible = 1;
         AssignProp(sPrefix, false, edtavViewall_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavViewall_action_Visible), 5, 0), true);
         AV31ViewAll_Action = "View All";
         AssignAttri(sPrefix, false, "AV31ViewAll_Action", AV31ViewAll_Action);
         edtavRefresh_action_Visible = 1;
         AssignProp(sPrefix, false, edtavRefresh_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRefresh_action_Visible), 5, 0), true);
         AV29Refresh_Action = "Refresh";
         AssignAttri(sPrefix, false, "AV29Refresh_Action", AV29Refresh_Action);
      }

      protected void S192( )
      {
         /* 'U_VIEWALL' Routine */
         CallWebObject(formatLink("k2bt_viewallnotifications.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S202( )
      {
         /* 'U_REFRESH' Routine */
         gxgrNotificationsgrid_refresh( AV20MarkAsRead_Action, AV9DP_SDT_ITEM_NotificationsGrid, AV27NotificationIsRead, sPrefix) ;
      }

      protected void wb_table4_85_0Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_notificationsgrid_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_notificationsgrid_Internalname, tblI_noresultsfoundtablename_notificationsgrid_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_notificationsgrid_Internalname, "No notifications", "", "", lblI_noresultsfoundtextblock_notificationsgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_K2BT_NotificationsViewer.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_85_0Y2e( true) ;
         }
         else
         {
            wb_table4_85_0Y2e( false) ;
         }
      }

      protected void wb_table3_38_0Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_notificationsgrid_gridassociatedright_Internalname, tblActions_notificationsgrid_gridassociatedright_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRefresh_action_Internalname, StringUtil.RTrim( AV29Refresh_Action), StringUtil.RTrim( context.localUtil.Format( AV29Refresh_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+"e160y1_client"+"'", "", "", "", "", edtavRefresh_action_Jsonclick, 7, "Attribute", "", "", "", "", edtavRefresh_action_Visible, edtavRefresh_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BT_NotificationsViewer.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_38_0Y2e( true) ;
         }
         else
         {
            wb_table3_38_0Y2e( false) ;
         }
      }

      protected void wb_table2_32_0Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_notificationsgrid_gridassociatedleft_Internalname, tblActions_notificationsgrid_gridassociatedleft_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavViewall_action_Internalname, StringUtil.RTrim( AV31ViewAll_Action), StringUtil.RTrim( context.localUtil.Format( AV31ViewAll_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+"e170y1_client"+"'", "", "", "", "", edtavViewall_action_Jsonclick, 7, "Attribute", "", "", "", "", edtavViewall_action_Visible, edtavViewall_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BT_NotificationsViewer.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_32_0Y2e( true) ;
         }
         else
         {
            wb_table2_32_0Y2e( false) ;
         }
      }

      protected void wb_table1_15_0Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = imgTogglenotifications_Bitmap;
            GxWebStd.gx_bitmap( context, imgTogglenotifications_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "Toggle Notifications", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgTogglenotifications_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e180y1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BT_NotificationsViewer.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_0Y2e( true) ;
         }
         else
         {
            wb_table1_15_0Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA0Y2( ) ;
         WS0Y2( ) ;
         WE0Y2( ) ;
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
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bt_notificationsviewer", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA0Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0Y2( ) ;
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
         WS0Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE0Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210202185098", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("k2bt_notificationsviewer.js", "?202210202185099", false, true);
            context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_512( )
      {
         edtavNotificationicon_Internalname = sPrefix+"vNOTIFICATIONICON_"+sGXsfl_51_idx;
         lblNotificationsgrid_notificationtexttb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONTEXTTB_"+sGXsfl_51_idx;
         edtavMarkasread_action_Internalname = sPrefix+"vMARKASREAD_ACTION_"+sGXsfl_51_idx;
         lblNotificationsgrid_notificationdatetb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONDATETB_"+sGXsfl_51_idx;
         edtavNotificationtext_Internalname = sPrefix+"vNOTIFICATIONTEXT_"+sGXsfl_51_idx;
         edtavEventcreationdatetime_Internalname = sPrefix+"vEVENTCREATIONDATETIME_"+sGXsfl_51_idx;
         chkavNotificationisread_Internalname = sPrefix+"vNOTIFICATIONISREAD_"+sGXsfl_51_idx;
         edtavNotificationid_Internalname = sPrefix+"vNOTIFICATIONID_"+sGXsfl_51_idx;
         edtavEventtargeturl_Internalname = sPrefix+"vEVENTTARGETURL_"+sGXsfl_51_idx;
      }

      protected void SubsflControlProps_fel_512( )
      {
         edtavNotificationicon_Internalname = sPrefix+"vNOTIFICATIONICON_"+sGXsfl_51_fel_idx;
         lblNotificationsgrid_notificationtexttb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONTEXTTB_"+sGXsfl_51_fel_idx;
         edtavMarkasread_action_Internalname = sPrefix+"vMARKASREAD_ACTION_"+sGXsfl_51_fel_idx;
         lblNotificationsgrid_notificationdatetb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONDATETB_"+sGXsfl_51_fel_idx;
         edtavNotificationtext_Internalname = sPrefix+"vNOTIFICATIONTEXT_"+sGXsfl_51_fel_idx;
         edtavEventcreationdatetime_Internalname = sPrefix+"vEVENTCREATIONDATETIME_"+sGXsfl_51_fel_idx;
         chkavNotificationisread_Internalname = sPrefix+"vNOTIFICATIONISREAD_"+sGXsfl_51_fel_idx;
         edtavNotificationid_Internalname = sPrefix+"vNOTIFICATIONID_"+sGXsfl_51_fel_idx;
         edtavEventtargeturl_Internalname = sPrefix+"vEVENTTARGETURL_"+sGXsfl_51_fel_idx;
      }

      protected void sendrow_512( )
      {
         SubsflControlProps_512( ) ;
         WB0Y0( ) ;
         NotificationsgridRow = GXWebRow.GetNew(context,NotificationsgridContainer);
         if ( subNotificationsgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subNotificationsgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
            {
               subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Odd";
            }
         }
         else if ( subNotificationsgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subNotificationsgrid_Backstyle = 0;
            subNotificationsgrid_Backcolor = subNotificationsgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
            {
               subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Uniform";
            }
         }
         else if ( subNotificationsgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subNotificationsgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
            {
               subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Odd";
            }
            subNotificationsgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subNotificationsgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subNotificationsgrid_Backstyle = 1;
            if ( ((int)((nGXsfl_51_idx) % (2))) == 0 )
            {
               subNotificationsgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
               {
                  subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Even";
               }
            }
            else
            {
               subNotificationsgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
               {
                  subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( NotificationsgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subNotificationsgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_51_idx+"\">") ;
         }
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divNotificationsgrid_notificationsgridtable1_Internalname+"_"+sGXsfl_51_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"K2BToolsSection_HoverActionContainer",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divNotificationsgrid_notificationcontainer_Internalname+"_"+sGXsfl_51_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)divNotificationsgrid_notificationcontainer_Class,(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)" gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Static Bitmap Variable */
         ClassString = "K2BT_NotificationIcon";
         StyleString = "";
         AV24NotificationIcon_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV24NotificationIcon))&&String.IsNullOrEmpty(StringUtil.RTrim( AV38Notificationicon_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV24NotificationIcon)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV24NotificationIcon)) ? AV38Notificationicon_GXI : context.PathToRelativeUrl( AV24NotificationIcon));
         NotificationsgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavNotificationicon_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)1,(short)0,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"",(short)0,(String)"",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV24NotificationIcon_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divNotificationsgrid_section1_Internalname+"_"+sGXsfl_51_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"K2BT_NotificationContentContainer",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divNotificationsgrid_section2_Internalname+"_"+sGXsfl_51_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"Section",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Text block */
         NotificationsgridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(String)lblNotificationsgrid_notificationtexttb_Internalname,(String)lblNotificationsgrid_notificationtexttb_Caption,(String)"",(String)"",(String)lblNotificationsgrid_notificationtexttb_Jsonclick,(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"K2BT_NotificationMessage",(short)0,(String)"",(short)1,(short)1,(short)0});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)" gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"MarkAsRead",(String)"gx-form-item Image_ActionLabel Image_Action_OnSectionHoverLabel K2BT_NotificationMarkAsReadLabel",(short)0,(bool)true,(String)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavMarkasread_action_Enabled!=0)&&(edtavMarkasread_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 62,'"+sPrefix+"',false,'',51)\"" : " ");
         ClassString = "Image_Action Image_Action_OnSectionHover K2BT_NotificationMarkAsRead";
         StyleString = "";
         AV20MarkAsRead_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV20MarkAsRead_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV36Markasread_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV20MarkAsRead_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20MarkAsRead_Action)) ? AV36Markasread_action_GXI : context.PathToRelativeUrl( AV20MarkAsRead_Action));
         NotificationsgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavMarkasread_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(int)edtavMarkasread_action_Visible,(short)1,(String)"",(String)edtavMarkasread_action_Tooltiptext,(short)0,(short)-1,(short)0,(String)"",(short)0,(String)"",(short)0,(short)0,(short)5,(String)edtavMarkasread_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVMARKASREAD_ACTION.CLICK."+sGXsfl_51_idx+"'",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV20MarkAsRead_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Text block */
         NotificationsgridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(String)lblNotificationsgrid_notificationdatetb_Internalname,(String)lblNotificationsgrid_notificationdatetb_Caption,(String)"",(String)"",(String)lblNotificationsgrid_notificationdatetb_Jsonclick,(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"K2BT_NotificationDate",(short)0,(String)"",(short)1,(short)1,(short)0});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MinimalAction";
         StyleString = "";
         NotificationsgridRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(String)bttViewnotification_Internalname+"_"+sGXsfl_51_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(51), 2, 0)+","+"null"+");",(String)bttViewnotification_Caption,(String)bttViewnotification_Jsonclick,(short)5,(String)"",(String)"",(String)StyleString,(String)ClassString,(short)1,(short)1,(String)"standard","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_VIEWNOTIFICATION\\'."+"'",(String)TempTags,(String)"",context.GetButtonType( )});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divLayoutcontent_invisiblecontrolssection_Internalname+"_"+sGXsfl_51_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"Section_Invisible",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group gx-label-top",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtavNotificationtext_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavNotificationtext_Internalname,(String)"Notification Text",(String)"gx-form-item AttributeLabel",(short)1,(bool)true,(String)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)100,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Multiple line edit */
         TempTags = " " + ((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 70,'"+sPrefix+"',false,'"+sGXsfl_51_idx+"',51)\"" : " ");
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         NotificationsgridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(String)edtavNotificationtext_Internalname,(String)AV28NotificationText,(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,70);\"" : " "),(short)0,(short)1,(short)1,(short)0,(short)80,(String)"chr",(short)10,(String)"row",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"10000",(short)-1,(short)0,(String)"",(String)"",(short)-1,(bool)true,(String)"K2BTools\\K2BT_NotificationMessage",(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group gx-label-top",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtavEventcreationdatetime_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavEventcreationdatetime_Internalname,(String)"Event Creation Date Time",(String)"gx-form-item AttributeLabel",(short)1,(bool)true,(String)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)100,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavEventcreationdatetime_Enabled!=0)&&(edtavEventcreationdatetime_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 73,'"+sPrefix+"',false,'"+sGXsfl_51_idx+"',51)\"" : " ");
         ROClassString = "Attribute";
         NotificationsgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavEventcreationdatetime_Internalname,context.localUtil.TToC( AV11EventCreationDateTime, 10, 12, 1, 2, "/", ":", " "),context.localUtil.Format( AV11EventCreationDateTime, "99/99/99 99:99:99.999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+((edtavEventcreationdatetime_Enabled!=0)&&(edtavEventcreationdatetime_Visible!=0) ? " onblur=\""+"gx.date.valid_date(this, 8,'MDY',12,12,'eng',false,0);"+";gx.evt.onblur(this,73);\"" : " "),(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavEventcreationdatetime_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(short)1,(short)0,(String)"text",(String)"",(short)24,(String)"chr",(short)1,(String)"row",(short)24,(short)0,(short)0,(short)51,(short)1,(short)-1,(short)0,(bool)true,(String)"K2BTools\\K2BT_DatetimeWithMilliseconds",(String)"right",(bool)false,(String)""});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group gx-label-top",(String)"left",(String)"top",(String)""+" data-gx-for=\""+chkavNotificationisread_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)chkavNotificationisread_Internalname,(String)"Notification Is Read",(String)"gx-form-item AttributeLabel",(short)1,(bool)true,(String)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)100,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Check box */
         TempTags = " " + ((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 76,'"+sPrefix+"',false,'"+sGXsfl_51_idx+"',51)\"" : " ");
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_51_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp(sPrefix, false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_51_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         NotificationsgridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(String)chkavNotificationisread_Internalname,StringUtil.BoolToStr( AV27NotificationIsRead),(String)"",(String)"Notification Is Read",(short)1,(short)1,(String)"true",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,76);\"" : " ")});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group gx-label-top",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtavNotificationid_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavNotificationid_Internalname,(String)"Notification Id",(String)"gx-form-item AttributeLabel",(short)1,(bool)true,(String)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)100,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 79,'"+sPrefix+"',false,'"+sGXsfl_51_idx+"',51)\"" : " ");
         ROClassString = "Attribute";
         NotificationsgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavNotificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25NotificationId), 15, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV25NotificationId), "ZZZZZZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"" : " "),(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavNotificationid_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(short)1,(short)0,(String)"number",(String)"1",(short)15,(String)"chr",(short)1,(String)"row",(short)15,(short)0,(short)0,(short)51,(short)1,(short)-1,(short)0,(bool)true,(String)"K2BTools\\K2BT_LargeId",(String)"right",(bool)false,(String)""});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"form-group gx-form-group gx-default-form-group gx-label-top",(String)"left",(String)"top",(String)""+" data-gx-for=\""+edtavEventtargeturl_Internalname+"\"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavEventtargeturl_Internalname,(String)"Event Target Url",(String)"gx-form-item AttributeLabel",(short)1,(bool)true,(String)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)100,(String)"%",(short)0,(String)"px",(String)"gx-form-item gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 82,'"+sPrefix+"',false,'"+sGXsfl_51_idx+"',51)\"" : " ");
         ROClassString = "Attribute";
         NotificationsgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavEventtargeturl_Internalname,(String)AV12EventTargetUrl,(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,82);\"" : " "),(String)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(String)AV12EventTargetUrl,(String)"_blank",(String)"",(String)"",(String)edtavEventtargeturl_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(short)1,(short)0,(String)"url",(String)"",(short)80,(String)"chr",(short)1,(String)"row",(short)1000,(short)0,(short)0,(short)51,(short)1,(short)-1,(short)0,(bool)true,(String)"GeneXus\\Url",(String)"left",(bool)true,(String)""});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         send_integrity_lvl_hashes0Y2( ) ;
         /* End of Columns property logic. */
         NotificationsgridContainer.AddRow(NotificationsgridRow);
         nGXsfl_51_idx = ((subNotificationsgrid_Islastpage==1)&&(nGXsfl_51_idx+1>subNotificationsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_51_idx+1);
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_512( ) ;
         /* End function sendrow_512 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_51_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp(sPrefix, false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_51_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgTogglenotifications_Internalname = sPrefix+"TOGGLENOTIFICATIONS";
         tblActionscontainertableleft_actions_Internalname = sPrefix+"ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = sPrefix+"RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         edtavViewall_action_Internalname = sPrefix+"vVIEWALL_ACTION";
         tblActions_notificationsgrid_gridassociatedleft_Internalname = sPrefix+"ACTIONS_NOTIFICATIONSGRID_GRIDASSOCIATEDLEFT";
         divLayoutdefined_section7_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION7_NOTIFICATIONSGRID";
         edtavRefresh_action_Internalname = sPrefix+"vREFRESH_ACTION";
         tblActions_notificationsgrid_gridassociatedright_Internalname = sPrefix+"ACTIONS_NOTIFICATIONSGRID_GRIDASSOCIATEDRIGHT";
         divLayoutdefined_section3_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION3_NOTIFICATIONSGRID";
         divLayoutdefined_section1_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION1_NOTIFICATIONSGRID";
         edtavNotificationicon_Internalname = sPrefix+"vNOTIFICATIONICON";
         lblNotificationsgrid_notificationtexttb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONTEXTTB";
         edtavMarkasread_action_Internalname = sPrefix+"vMARKASREAD_ACTION";
         divNotificationsgrid_section2_Internalname = sPrefix+"NOTIFICATIONSGRID_SECTION2";
         lblNotificationsgrid_notificationdatetb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONDATETB";
         bttViewnotification_Internalname = sPrefix+"VIEWNOTIFICATION";
         divNotificationsgrid_section1_Internalname = sPrefix+"NOTIFICATIONSGRID_SECTION1";
         divNotificationsgrid_notificationcontainer_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONCONTAINER";
         edtavNotificationtext_Internalname = sPrefix+"vNOTIFICATIONTEXT";
         edtavEventcreationdatetime_Internalname = sPrefix+"vEVENTCREATIONDATETIME";
         chkavNotificationisread_Internalname = sPrefix+"vNOTIFICATIONISREAD";
         edtavNotificationid_Internalname = sPrefix+"vNOTIFICATIONID";
         edtavEventtargeturl_Internalname = sPrefix+"vEVENTTARGETURL";
         divLayoutcontent_invisiblecontrolssection_Internalname = sPrefix+"LAYOUTCONTENT_INVISIBLECONTROLSSECTION";
         divNotificationsgrid_notificationsgridtable1_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONSGRIDTABLE1";
         divLayoutcontent_userregion_Internalname = sPrefix+"LAYOUTCONTENT_USERREGION";
         lblI_noresultsfoundtextblock_notificationsgrid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_NOTIFICATIONSGRID";
         tblI_noresultsfoundtablename_notificationsgrid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_NOTIFICATIONSGRID";
         divMaingrid_responsivetable_notificationsgrid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_NOTIFICATIONSGRID";
         divLayoutdefined_section8_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION8_NOTIFICATIONSGRID";
         divLayoutdefined_table3_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_NOTIFICATIONSGRID";
         divLayoutdefined_grid_inner_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_NOTIFICATIONSGRID";
         divGridcomponentcontent_notificationsgrid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subNotificationsgrid_Internalname = sPrefix+"NOTIFICATIONSGRID";
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
         edtavEventtargeturl_Jsonclick = "";
         edtavEventtargeturl_Visible = 1;
         edtavEventtargeturl_Enabled = 1;
         edtavNotificationid_Jsonclick = "";
         edtavNotificationid_Visible = 1;
         edtavNotificationid_Enabled = 1;
         chkavNotificationisread.Caption = "Notification Is Read";
         chkavNotificationisread.Visible = 1;
         chkavNotificationisread.Enabled = 1;
         edtavEventcreationdatetime_Jsonclick = "";
         edtavEventcreationdatetime_Visible = 1;
         edtavEventcreationdatetime_Enabled = 1;
         edtavNotificationtext_Visible = 1;
         edtavNotificationtext_Enabled = 1;
         lblNotificationsgrid_notificationdatetb_Caption = "";
         edtavMarkasread_action_Jsonclick = "";
         edtavMarkasread_action_Enabled = 1;
         lblNotificationsgrid_notificationtexttb_Caption = "";
         subNotificationsgrid_Class = "FreeStyleGrid";
         imgTogglenotifications_Bitmap = (String)(context.GetImagePath( "1942f1bc-1f65-4fa8-8c23-b53fd3aa4826", "", context.GetTheme( )));
         edtavViewall_action_Jsonclick = "";
         edtavViewall_action_Enabled = 1;
         edtavRefresh_action_Jsonclick = "";
         edtavRefresh_action_Enabled = 1;
         edtavRefresh_action_Visible = 1;
         edtavViewall_action_Visible = 1;
         bttViewnotification_Caption = "View Notification";
         divNotificationsgrid_notificationcontainer_Class = "K2BT_NotificationContainer K2BT_UnreadNotificationContainer";
         tblI_noresultsfoundtablename_notificationsgrid_Visible = 1;
         subNotificationsgrid_Allowcollapsing = 0;
         edtavMarkasread_action_Visible = 1;
         lblNotificationsgrid_notificationtexttb_Caption = "";
         subNotificationsgrid_Backcolorstyle = 0;
         divGridcomponentcontent_notificationsgrid_Class = "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer";
         divGridcomponentcontent_notificationsgrid_Visible = 1;
         divContenttable_Class = "K2BToolsTable_WebPanelDesignerContent";
         edtavMarkasread_action_Tooltiptext = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV20MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV27NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'sPrefix'},{av:'AV9DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'E_TOGGLENOTIFICATIONS'","{handler:'E180Y1',iparms:[{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]");
         setEventMetadata("'E_TOGGLENOTIFICATIONS'",",oparms:[{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]}");
         setEventMetadata("NOTIFICATIONSGRID.LOAD","{handler:'E140Y2',iparms:[{av:'AV9DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV27NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("NOTIFICATIONSGRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_notificationsgrid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_NOTIFICATIONSGRID',prop:'Visible'},{av:'AV9DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV24NotificationIcon',fld:'vNOTIFICATIONICON',pic:''},{av:'AV28NotificationText',fld:'vNOTIFICATIONTEXT',pic:''},{av:'AV11EventCreationDateTime',fld:'vEVENTCREATIONDATETIME',pic:'99/99/99 99:99:99.999'},{av:'AV27NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'AV25NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'},{av:'AV12EventTargetUrl',fld:'vEVENTTARGETURL',pic:''},{av:'AV20MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'lblNotificationsgrid_notificationtexttb_Caption',ctrl:'NOTIFICATIONSGRID_NOTIFICATIONTEXTTB',prop:'Caption'},{av:'lblNotificationsgrid_notificationdatetb_Caption',ctrl:'NOTIFICATIONSGRID_NOTIFICATIONDATETB',prop:'Caption'},{av:'edtavMarkasread_action_Visible',ctrl:'vMARKASREAD_ACTION',prop:'Visible'},{av:'divNotificationsgrid_notificationcontainer_Class',ctrl:'NOTIFICATIONSGRID_NOTIFICATIONCONTAINER',prop:'Class'},{ctrl:'VIEWNOTIFICATION',prop:'Caption'}]}");
         setEventMetadata("VMARKASREAD_ACTION.CLICK","{handler:'E150Y2',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV20MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV9DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV27NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'sPrefix'},{av:'AV25NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'}]");
         setEventMetadata("VMARKASREAD_ACTION.CLICK",",oparms:[]}");
         setEventMetadata("'E_VIEWNOTIFICATION'","{handler:'E110Y2',iparms:[{av:'AV12EventTargetUrl',fld:'vEVENTTARGETURL',pic:''},{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV20MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV9DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV27NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'sPrefix'},{av:'AV25NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_VIEWNOTIFICATION'",",oparms:[]}");
         setEventMetadata("'E_VIEWALL'","{handler:'E170Y1',iparms:[]");
         setEventMetadata("'E_VIEWALL'",",oparms:[]}");
         setEventMetadata("'E_REFRESH'","{handler:'E160Y1',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV20MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV9DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV27NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_REFRESH'",",oparms:[]}");
         setEventMetadata("VALIDV_EVENTCREATIONDATETIME","{handler:'Validv_Eventcreationdatetime',iparms:[]");
         setEventMetadata("VALIDV_EVENTCREATIONDATETIME",",oparms:[]}");
         setEventMetadata("VALIDV_EVENTTARGETURL","{handler:'Validv_Eventtargeturl',iparms:[]");
         setEventMetadata("VALIDV_EVENTTARGETURL",",oparms:[]}");
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
         sPrefix = "";
         AV20MarkAsRead_Action = "";
         AV9DP_SDT_ITEM_NotificationsGrid = new GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV26NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         NotificationsgridContainer = new GXWebGrid( context);
         sStyleString = "";
         subNotificationsgrid_Header = "";
         NotificationsgridColumn = new GXWebColumn();
         AV24NotificationIcon = "";
         AV28NotificationText = "";
         AV11EventCreationDateTime = (DateTime)(DateTime.MinValue);
         AV12EventTargetUrl = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV38Notificationicon_GXI = "";
         AV36Markasread_action_GXI = "";
         AV31ViewAll_Action = "";
         AV29Refresh_Action = "";
         AV14HttpRequest = new GxHttpRequest( context);
         AV10DP_SDT_NotificationsGrid = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "TABLEROS_WEB");
         GXt_objcol_SdtWebNotificationSDT_Notification1 = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "TABLEROS_WEB");
         GXt_char2 = "";
         NotificationsgridRow = new GXWebRow();
         AV22Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV21Message = new SdtMessages_Message(context);
         AV5Url = "";
         lblI_noresultsfoundtextblock_notificationsgrid_Jsonclick = "";
         TempTags = "";
         sImgUrl = "";
         imgTogglenotifications_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subNotificationsgrid_Linesclass = "";
         lblNotificationsgrid_notificationtexttb_Jsonclick = "";
         lblNotificationsgrid_notificationdatetb_Jsonclick = "";
         bttViewnotification_Jsonclick = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bt_notificationsviewer__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavViewall_action_Enabled = 0;
         edtavRefresh_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subNotificationsgrid_Backcolorstyle ;
      private short subNotificationsgrid_Allowselection ;
      private short subNotificationsgrid_Allowhovering ;
      private short subNotificationsgrid_Allowcollapsing ;
      private short subNotificationsgrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV8CurrentPage_NotificationsGrid ;
      private short NOTIFICATIONSGRID_nEOF ;
      private short AV15I_LoadCount_NotificationsGrid ;
      private short GXt_int3 ;
      private short subNotificationsgrid_Backstyle ;
      private int divGridcomponentcontent_notificationsgrid_Visible ;
      private int nRC_GXsfl_51 ;
      private int nGXsfl_51_idx=1 ;
      private int edtavViewall_action_Enabled ;
      private int edtavRefresh_action_Enabled ;
      private int edtavMarkasread_action_Visible ;
      private int subNotificationsgrid_Selectedindex ;
      private int subNotificationsgrid_Selectioncolor ;
      private int subNotificationsgrid_Hoveringcolor ;
      private int subNotificationsgrid_Islastpage ;
      private int tblI_noresultsfoundtablename_notificationsgrid_Visible ;
      private int AV37GXV1 ;
      private int AV39GXV2 ;
      private int edtavViewall_action_Visible ;
      private int edtavRefresh_action_Visible ;
      private int idxLst ;
      private int subNotificationsgrid_Backcolor ;
      private int subNotificationsgrid_Allbackcolor ;
      private int edtavMarkasread_action_Enabled ;
      private int edtavNotificationtext_Enabled ;
      private int edtavNotificationtext_Visible ;
      private int edtavEventcreationdatetime_Enabled ;
      private int edtavEventcreationdatetime_Visible ;
      private int edtavNotificationid_Enabled ;
      private int edtavNotificationid_Visible ;
      private int edtavEventtargeturl_Enabled ;
      private int edtavEventtargeturl_Visible ;
      private long AV25NotificationId ;
      private long NOTIFICATIONSGRID_nCurrentRecord ;
      private long NOTIFICATIONSGRID_nFirstRecordOnPage ;
      private String edtavMarkasread_action_Tooltiptext ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sGXsfl_51_idx="0001" ;
      private String edtavMarkasread_action_Internalname ;
      private String edtavViewall_action_Internalname ;
      private String edtavRefresh_action_Internalname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String divMaintable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String divContenttable_Internalname ;
      private String divContenttable_Class ;
      private String divResponsivetable_containernode_actions_Internalname ;
      private String divGridcomponentcontent_notificationsgrid_Internalname ;
      private String divGridcomponentcontent_notificationsgrid_Class ;
      private String divLayoutdefined_grid_inner_notificationsgrid_Internalname ;
      private String divLayoutdefined_table3_notificationsgrid_Internalname ;
      private String divLayoutdefined_section1_notificationsgrid_Internalname ;
      private String divLayoutdefined_section7_notificationsgrid_Internalname ;
      private String divLayoutdefined_section3_notificationsgrid_Internalname ;
      private String divMaingrid_responsivetable_notificationsgrid_Internalname ;
      private String divLayoutcontent_userregion_Internalname ;
      private String sStyleString ;
      private String subNotificationsgrid_Internalname ;
      private String subNotificationsgrid_Header ;
      private String lblNotificationsgrid_notificationtexttb_Caption ;
      private String divLayoutdefined_section8_notificationsgrid_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavNotificationtext_Internalname ;
      private String edtavNotificationicon_Internalname ;
      private String edtavEventcreationdatetime_Internalname ;
      private String chkavNotificationisread_Internalname ;
      private String edtavNotificationid_Internalname ;
      private String edtavEventtargeturl_Internalname ;
      private String AV31ViewAll_Action ;
      private String AV29Refresh_Action ;
      private String imgTogglenotifications_Internalname ;
      private String tblI_noresultsfoundtablename_notificationsgrid_Internalname ;
      private String lblNotificationsgrid_notificationdatetb_Caption ;
      private String GXt_char2 ;
      private String divNotificationsgrid_notificationcontainer_Class ;
      private String divNotificationsgrid_notificationcontainer_Internalname ;
      private String bttViewnotification_Caption ;
      private String bttViewnotification_Internalname ;
      private String lblI_noresultsfoundtextblock_notificationsgrid_Internalname ;
      private String lblI_noresultsfoundtextblock_notificationsgrid_Jsonclick ;
      private String tblActions_notificationsgrid_gridassociatedright_Internalname ;
      private String TempTags ;
      private String edtavRefresh_action_Jsonclick ;
      private String tblActions_notificationsgrid_gridassociatedleft_Internalname ;
      private String edtavViewall_action_Jsonclick ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String sImgUrl ;
      private String imgTogglenotifications_Jsonclick ;
      private String lblNotificationsgrid_notificationtexttb_Internalname ;
      private String lblNotificationsgrid_notificationdatetb_Internalname ;
      private String sGXsfl_51_fel_idx="0001" ;
      private String subNotificationsgrid_Class ;
      private String subNotificationsgrid_Linesclass ;
      private String divNotificationsgrid_notificationsgridtable1_Internalname ;
      private String divNotificationsgrid_section1_Internalname ;
      private String divNotificationsgrid_section2_Internalname ;
      private String lblNotificationsgrid_notificationtexttb_Jsonclick ;
      private String edtavMarkasread_action_Jsonclick ;
      private String lblNotificationsgrid_notificationdatetb_Jsonclick ;
      private String bttViewnotification_Jsonclick ;
      private String divLayoutcontent_invisiblecontrolssection_Internalname ;
      private String ROClassString ;
      private String edtavEventcreationdatetime_Jsonclick ;
      private String GXCCtl ;
      private String edtavNotificationid_Jsonclick ;
      private String edtavEventtargeturl_Jsonclick ;
      private DateTime AV11EventCreationDateTime ;
      private bool entryPointCalled ;
      private bool bGXsfl_51_Refreshing=false ;
      private bool AV27NotificationIsRead ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV19LoadRow_NotificationsGrid ;
      private bool AV30Success ;
      private bool AV24NotificationIcon_IsBlob ;
      private bool AV20MarkAsRead_Action_IsBlob ;
      private String AV28NotificationText ;
      private String AV12EventTargetUrl ;
      private String AV38Notificationicon_GXI ;
      private String AV36Markasread_action_GXI ;
      private String AV5Url ;
      private String AV20MarkAsRead_Action ;
      private String AV24NotificationIcon ;
      private String imgTogglenotifications_Bitmap ;
      private GXWebGrid NotificationsgridContainer ;
      private GXWebRow NotificationsgridRow ;
      private GXWebColumn NotificationsgridColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavNotificationisread ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV14HttpRequest ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> AV10DP_SDT_NotificationsGrid ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> GXt_objcol_SdtWebNotificationSDT_Notification1 ;
      private GXBaseCollection<SdtMessages_Message> AV22Messages ;
      private GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV9DP_SDT_ITEM_NotificationsGrid ;
      private SdtMessages_Message AV21Message ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV26NotificationInfo ;
   }

   public class k2bt_notificationsviewer__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

 }

}
