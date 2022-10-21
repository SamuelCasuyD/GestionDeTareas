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
   public class k2bt_viewallnotifications : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public k2bt_viewallnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bt_viewallnotifications( IGxContext context )
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

      protected override void createObjects( )
      {
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp = new GXCombobox();
         chkavNotificationisread = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridgetlatestnotificationsforcurrentuserdp") == 0 )
            {
               nRC_GXsfl_57 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_57_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_57_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridgetlatestnotificationsforcurrentuserdp_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridgetlatestnotificationsforcurrentuserdp") == 0 )
            {
               AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( GetNextPar( ), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
               AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP = StringUtil.StrToBool( GetNextPar( ));
               AV29Pgmname = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridgetlatestnotificationsforcurrentuserdp_refresh( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP, AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP, AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, AV29Pgmname) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("k2bwwmasterpageorion", "GeneXus.Programs.k2bwwmasterpageorion", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA1L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1L2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210202185751", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bt_viewallnotifications.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_57", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_57), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV29Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE1L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1L2( ) ;
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
         return formatLink("k2bt_viewallnotifications.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "K2BT_ViewAllNotifications" ;
      }

      public override String GetPgmdesc( )
      {
         return "K2 BT_View All Notifications" ;
      }

      protected void WB1L0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponentcontent_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_21_1L2( true) ;
         }
         else
         {
            wb_table1_21_1L2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_1L2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section1_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section7_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatLeft", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section3_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatRight", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridgetlatestnotificationsforcurrentuserdpContainer.SetWrapped(nGXWrapped);
            if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridgetlatestnotificationsforcurrentuserdpContainer"+"DivS\" data-gxgridid=\"57\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridgetlatestnotificationsforcurrentuserdp_Internalname, subGridgetlatestnotificationsforcurrentuserdp_Internalname, "", "Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 0 )
               {
                  subGridgetlatestnotificationsforcurrentuserdp_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGridgetlatestnotificationsforcurrentuserdp_Class) > 0 )
                  {
                     subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Title";
                  }
               }
               else
               {
                  subGridgetlatestnotificationsforcurrentuserdp_Titlebackstyle = 1;
                  if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 1 )
                  {
                     subGridgetlatestnotificationsforcurrentuserdp_Titlebackcolor = subGridgetlatestnotificationsforcurrentuserdp_Allbackcolor;
                     if ( StringUtil.Len( subGridgetlatestnotificationsforcurrentuserdp_Class) > 0 )
                     {
                        subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridgetlatestnotificationsforcurrentuserdp_Class) > 0 )
                     {
                        subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Notification Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Notification text") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Event Target Url") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Is read?") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("GridName", "Gridgetlatestnotificationsforcurrentuserdp");
            }
            else
            {
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("GridName", "Gridgetlatestnotificationsforcurrentuserdp");
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Header", subGridgetlatestnotificationsforcurrentuserdp_Header);
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Class", "Grid_WorkWith");
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Sortable), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("CmpContext", "");
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("InMasterPage", "false");
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18NotificationId), 15, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationid_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", AV20NotificationText);
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationtext_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", AV10EventTargetUrl);
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEventtargeturl_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV19NotificationIsRead));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavNotificationisread.Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", StringUtil.RTrim( AV21Open_Action));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOpen_action_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", StringUtil.RTrim( AV15MarkAsRead_Action));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMarkasread_action_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Selectedindex), 4, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Allowselection), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Selectioncolor), 9, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Allowhovering), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Hoveringcolor), 9, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Allowcollapsing), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 57 )
         {
            wbEnd = 0;
            nRC_GXsfl_57 = (int)(nGXsfl_57_idx-1);
            if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridgetlatestnotificationsforcurrentuserdpContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridgetlatestnotificationsforcurrentuserdp", GridgetlatestnotificationsforcurrentuserdpContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridgetlatestnotificationsforcurrentuserdpContainerData", GridgetlatestnotificationsforcurrentuserdpContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridgetlatestnotificationsforcurrentuserdpContainerData"+"V", GridgetlatestnotificationsforcurrentuserdpContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridgetlatestnotificationsforcurrentuserdpContainerData"+"V"+"\" value='"+GridgetlatestnotificationsforcurrentuserdpContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_66_1L2( true) ;
         }
         else
         {
            wb_table2_66_1L2( false) ;
         }
         return  ;
      }

      protected void wb_table2_66_1L2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            wb_table3_73_1L2( true) ;
         }
         else
         {
            wb_table3_73_1L2( false) ;
         }
         return  ;
      }

      protected void wb_table3_73_1L2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 57 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridgetlatestnotificationsforcurrentuserdpContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridgetlatestnotificationsforcurrentuserdp", GridgetlatestnotificationsforcurrentuserdpContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridgetlatestnotificationsforcurrentuserdpContainerData", GridgetlatestnotificationsforcurrentuserdpContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridgetlatestnotificationsforcurrentuserdpContainerData"+"V", GridgetlatestnotificationsforcurrentuserdpContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridgetlatestnotificationsforcurrentuserdpContainerData"+"V"+"\" value='"+GridgetlatestnotificationsforcurrentuserdpContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1L2( )
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
            Form.Meta.addItem("description", "K2 BT_View All Notifications", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1L0( ) ;
      }

      protected void WS1L2( )
      {
         START1L2( ) ;
         EVT1L2( ) ;
      }

      protected void EVT1L2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(GridGetLatestNotificationsForCurrentUserDP)' */
                              E111L2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 47), "GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_OPEN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'E_MARKASREAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_OPEN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'E_MARKASREAD'") == 0 ) )
                           {
                              nGXsfl_57_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
                              SubsflControlProps_572( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNOTIFICATIONID");
                                 GX_FocusControl = edtavNotificationid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV18NotificationId = 0;
                                 AssignAttri("", false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV18NotificationId), 15, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV18NotificationId = (long)(context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ","));
                                 AssignAttri("", false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV18NotificationId), 15, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
                              }
                              AV20NotificationText = cgiGet( edtavNotificationtext_Internalname);
                              AssignAttri("", false, edtavNotificationtext_Internalname, AV20NotificationText);
                              AV10EventTargetUrl = cgiGet( edtavEventtargeturl_Internalname);
                              AssignAttri("", false, edtavEventtargeturl_Internalname, AV10EventTargetUrl);
                              GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV10EventTargetUrl, "")), context));
                              AV19NotificationIsRead = StringUtil.StrToBool( cgiGet( chkavNotificationisread_Internalname));
                              AssignAttri("", false, chkavNotificationisread_Internalname, AV19NotificationIsRead);
                              AV21Open_Action = cgiGet( edtavOpen_action_Internalname);
                              AssignAttri("", false, edtavOpen_action_Internalname, AV21Open_Action);
                              AV15MarkAsRead_Action = cgiGet( edtavMarkasread_action_Internalname);
                              AssignAttri("", false, edtavMarkasread_action_Internalname, AV15MarkAsRead_Action);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E121L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E131L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E141L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_OPEN'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Open' */
                                    E151L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_MARKASREAD'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_MarkAsRead' */
                                    E161L2 ();
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

      protected void WE1L2( )
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

      protected void PA1L2( )
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
               GX_FocusControl = cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridgetlatestnotificationsforcurrentuserdp_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_572( ) ;
         while ( nGXsfl_57_idx <= nRC_GXsfl_57 )
         {
            sendrow_572( ) ;
            nGXsfl_57_idx = ((subGridgetlatestnotificationsforcurrentuserdp_Islastpage==1)&&(nGXsfl_57_idx+1>subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridgetlatestnotificationsforcurrentuserdpContainer)) ;
         /* End function gxnrGridgetlatestnotificationsforcurrentuserdp_newrow */
      }

      protected void gxgrGridgetlatestnotificationsforcurrentuserdp_refresh( short AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP ,
                                                                             short AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP ,
                                                                             GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP ,
                                                                             bool AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP ,
                                                                             String AV29Pgmname )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E131L2 ();
         GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nCurrentRecord = 0;
         RF1L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridgetlatestnotificationsforcurrentuserdp_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10EventTargetUrl, "")), context));
         GxWebStd.gx_hidden_field( context, "vEVENTTARGETURL", AV10EventTargetUrl);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18NotificationId), 15, 0, ".", "")));
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
         if ( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.ItemCount > 0 )
         {
            AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0))), "."));
            AssignAttri("", false, "AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Values", cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV29Pgmname = "K2BT_ViewAllNotifications";
         context.Gx_err = 0;
         edtavNotificationid_Enabled = 0;
         AssignProp("", false, edtavNotificationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationid_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavNotificationtext_Enabled = 0;
         AssignProp("", false, edtavNotificationtext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationtext_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavEventtargeturl_Enabled = 0;
         AssignProp("", false, edtavEventtargeturl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEventtargeturl_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         chkavNotificationisread.Enabled = 0;
         AssignProp("", false, chkavNotificationisread_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavNotificationisread.Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavOpen_action_Enabled = 0;
         AssignProp("", false, edtavOpen_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOpen_action_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavMarkasread_action_Enabled = 0;
         AssignProp("", false, edtavMarkasread_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMarkasread_action_Enabled), 5, 0), !bGXsfl_57_Refreshing);
      }

      protected void RF1L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridgetlatestnotificationsforcurrentuserdpContainer.ClearRows();
         }
         wbStart = 57;
         /* Execute user event: Refresh */
         E131L2 ();
         nGXsfl_57_idx = 1;
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         bGXsfl_57_Refreshing = true;
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("GridName", "Gridgetlatestnotificationsforcurrentuserdp");
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("CmpContext", "");
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("InMasterPage", "false");
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Class", "Grid_WorkWith");
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle), 1, 0, ".", "")));
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Sortable), 1, 0, ".", "")));
         GridgetlatestnotificationsforcurrentuserdpContainer.PageSize = subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( );
         if ( subGridgetlatestnotificationsforcurrentuserdp_Islastpage != 0 )
         {
            GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage = (long)(subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordcount( )-subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage), 15, 0, ".", "")));
            GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage", GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_572( ) ;
            E141L2 ();
            wbEnd = 57;
            WB1L0( ) ;
         }
         bGXsfl_57_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1L2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV29Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV10EventTargetUrl, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
      }

      protected int subGridgetlatestnotificationsforcurrentuserdp_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridgetlatestnotificationsforcurrentuserdp_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV29Pgmname = "K2BT_ViewAllNotifications";
         context.Gx_err = 0;
         edtavNotificationid_Enabled = 0;
         AssignProp("", false, edtavNotificationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationid_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavNotificationtext_Enabled = 0;
         AssignProp("", false, edtavNotificationtext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationtext_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavEventtargeturl_Enabled = 0;
         AssignProp("", false, edtavEventtargeturl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEventtargeturl_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         chkavNotificationisread.Enabled = 0;
         AssignProp("", false, chkavNotificationisread_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavNotificationisread.Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavOpen_action_Enabled = 0;
         AssignProp("", false, edtavOpen_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOpen_action_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavMarkasread_action_Enabled = 0;
         AssignProp("", false, edtavMarkasread_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMarkasread_action_Enabled), 5, 0), !bGXsfl_57_Refreshing);
      }

      protected void STRUP1L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E121L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_57 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_57"), ".", ","));
            AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP"), ".", ","));
            AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP = (short)(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP"), ".", ","));
            /* Read variables values. */
            cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.Name = cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname;
            cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname);
            AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname), "."));
            AssignAttri("", false, "AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
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
         E121L2 ();
         if (returnInSub) return;
      }

      protected void E121L2( )
      {
         /* Start Routine */
         subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle = 3;
         divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         if ( (0==AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP) )
         {
            AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP = 1;
            AssignAttri("", false, "AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
         }
         if ( StringUtil.StrCmp(AV13HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'U_OPENPAGE' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E131L2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
      }

      private void E141L2( )
      {
         /* Gridgetlatestnotificationsforcurrentuserdp_Load Routine */
         AV14I_LoadCount_GridGetLatestNotificationsForCurrentUserDP = 0;
         GXt_objcol_SdtWebNotificationSDT_Notification1 = AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP;
         new GeneXus.Programs.k2btools.integrationprocedures.getallnotificationsforcurrentuserdp(context ).execute(  AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP,  (AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP-1)*(AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP), out  GXt_objcol_SdtWebNotificationSDT_Notification1) ;
         AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP = GXt_objcol_SdtWebNotificationSDT_Notification1;
         if ( AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Count == 0 )
         {
            tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         if ( ( AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Count == 0 ) || ( AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Count < AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP ) )
         {
            AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP = false;
            AssignAttri("", false, "AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP);
            GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         }
         else
         {
            AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP = true;
            AssignAttri("", false, "AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP);
            GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         }
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Count )
         {
            AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP = ((GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification)AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Item(AV28GXV1));
            AV14I_LoadCount_GridGetLatestNotificationsForCurrentUserDP = (short)(AV14I_LoadCount_GridGetLatestNotificationsForCurrentUserDP+1);
            AV18NotificationId = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Notificationid;
            AssignAttri("", false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV18NotificationId), 15, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
            AV20NotificationText = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Notificationtext;
            AssignAttri("", false, edtavNotificationtext_Internalname, AV20NotificationText);
            AV10EventTargetUrl = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Eventtargeturl;
            AssignAttri("", false, edtavEventtargeturl_Internalname, AV10EventTargetUrl);
            GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV10EventTargetUrl, "")), context));
            AV19NotificationIsRead = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Notificationisread;
            AssignAttri("", false, chkavNotificationisread_Internalname, AV19NotificationIsRead);
            AV21Open_Action = "Open";
            AssignAttri("", false, edtavOpen_action_Internalname, AV21Open_Action);
            AV15MarkAsRead_Action = "Mark as read";
            AssignAttri("", false, edtavMarkasread_action_Internalname, AV15MarkAsRead_Action);
            /* Execute user subroutine: 'U_LOADROWVARS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)' */
            S142 ();
            if (returnInSub) return;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 57;
            }
            sendrow_572( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_57_Refreshing )
            {
               context.DoAjaxLoad(57, GridgetlatestnotificationsforcurrentuserdpRow);
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
      }

      protected void S142( )
      {
         /* 'U_LOADROWVARS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)' Routine */
         AV21Open_Action = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Notificationactioncaption;
         AssignAttri("", false, edtavOpen_action_Internalname, AV21Open_Action);
      }

      protected void S172( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)' Routine */
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = StringUtil.Str( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = StringUtil.Str( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = StringUtil.Str( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, true);
         lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, true);
         if ( (0==AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP) || ( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, true);
            cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationPrevious";
            AssignProp("", false, cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            if ( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP == 2 )
            {
               cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class, true);
               lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
               cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class, true);
               lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationLeft";
               AssignProp("", false, cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class, true);
               lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
               if ( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP == 3 )
               {
                  cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class, true);
                  lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class, true);
                  lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP )
         {
            lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, true);
            cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationNext";
            AssignProp("", false, cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
            AssignProp("", false, cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         if ( ( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP <= 1 ) && ! AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP )
         {
            tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
      }

      protected void E111L2( )
      {
         /* 'SaveGridSettings(GridGetLatestNotificationsForCurrentUserDP)' Routine */
         if ( AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP != AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP )
         {
            AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP = AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP;
            AssignAttri("", false, "AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV29Pgmname,  "GridGetLatestNotificationsForCurrentUserDP",  AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP) ;
            AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP = 1;
            AssignAttri("", false, "AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
         }
         gxgrGridgetlatestnotificationsforcurrentuserdp_refresh( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP, AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP, AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, AV29Pgmname) ;
         divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E151L2( )
      {
         /* 'E_Open' Routine */
         /* Execute user subroutine: 'U_OPEN' */
         S152 ();
         if (returnInSub) return;
      }

      protected void S152( )
      {
         /* 'U_OPEN' Routine */
         /* Execute user subroutine: 'U_MARKASREAD' */
         S162 ();
         if (returnInSub) return;
         CallWebObject(formatLink(AV10EventTargetUrl) );
         context.wjLocDisableFrm = 0;
      }

      protected void E161L2( )
      {
         /* 'E_MarkAsRead' Routine */
         /* Execute user subroutine: 'U_MARKASREAD' */
         S162 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'U_MARKASREAD' Routine */
         GXt_int2 = (short)(Convert.ToInt16(AV24Success));
         new GeneXus.Programs.k2btools.integrationprocedures.markwebnotificationasread(context ).execute(  (short)(AV18NotificationId), out  GXt_int2, out  AV17Messages) ;
         AV24Success = (bool)(Convert.ToBoolean(GXt_int2));
         if ( AV24Success )
         {
            context.CommitDataStores("k2bt_viewallnotifications",pr_default);
         }
         else
         {
            AV30GXV2 = 1;
            while ( AV30GXV2 <= AV17Messages.Count )
            {
               AV16Message = ((SdtMessages_Message)AV17Messages.Item(AV30GXV2));
               new GeneXus.Core.genexus.common.SdtLog(context).error("Error marking notification as read: "+AV16Message.gxTpr_Id+" - "+AV16Message.gxTpr_Description, "K2BTools.Notifications.ViewAllNotifications") ;
               AV30GXV2 = (int)(AV30GXV2+1);
            }
            context.RollbackDataStores("k2bt_viewallnotifications",pr_default);
         }
      }

      protected void wb_table3_73_1L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname, tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname, "", "K2BToolsTable_PaginationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagebuttoncellgridgetlatestnotificationsforcurrentuserdp_Internalname+"\"  class='K2BToolsCell_PaginationFirst'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "&laquo;", "", "", lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e171l1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, 7, "", 1, 1, 1, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname+"\"  class='"+cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e181l1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Internalname+"\"  class='"+cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Internalname+"\"  class='"+cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e171l1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_currentpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname+"\"  class='"+cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e191l1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Internalname+"\"  class='"+cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagebuttoncellgridgetlatestnotificationsforcurrentuserdp_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "&raquo;", "", "", lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e191l1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, 7, "", 1, 1, 1, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_73_1L2e( true) ;
         }
         else
         {
            wb_table3_73_1L2e( false) ;
         }
      }

      protected void wb_table2_66_1L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname, tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_66_1L2e( true) ;
         }
         else
         {
            wb_table2_66_1L2e( false) ;
         }
      }

      protected void wb_table1_21_1L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_gridgetlatestnotificationsforcurrentuserdp_Internalname, tblLayoutdefined_table7_gridgetlatestnotificationsforcurrentuserdp_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltablegridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Internalname, "", "", "", lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e201l1_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_K2BT_ViewAllNotifications.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname, divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table4_33_1L2( true) ;
         }
         else
         {
            wb_table4_33_1L2( false) ;
         }
         return  ;
      }

      protected void wb_table4_33_1L2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", "Save", bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Jsonclick, 5, "Save", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BT_ViewAllNotifications.htm");
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
            wb_table1_21_1L2e( true) ;
         }
         else
         {
            wb_table1_21_1L2e( false) ;
         }
      }

      protected void wb_table4_33_1L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgridgetlatestnotificationsforcurrentuserdp_Internalname, tblGridsettings_tablecontentgridgetlatestnotificationsforcurrentuserdp_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Rows per page", "", "", lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Grid Settings Rows Per Page_Grid Get Latest Notifications For Current User DP", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0)), 1, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Rows per page", 1, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, "HLP_K2BT_ViewAllNotifications.htm");
            cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_33_1L2e( true) ;
         }
         else
         {
            wb_table4_33_1L2e( false) ;
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
         PA1L2( ) ;
         WS1L2( ) ;
         WE1L2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210202185845", true, true);
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
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("k2bt_viewallnotifications.js", "?202210202185845", false, true);
            context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_572( )
      {
         edtavNotificationid_Internalname = "vNOTIFICATIONID_"+sGXsfl_57_idx;
         edtavNotificationtext_Internalname = "vNOTIFICATIONTEXT_"+sGXsfl_57_idx;
         edtavEventtargeturl_Internalname = "vEVENTTARGETURL_"+sGXsfl_57_idx;
         chkavNotificationisread_Internalname = "vNOTIFICATIONISREAD_"+sGXsfl_57_idx;
         edtavOpen_action_Internalname = "vOPEN_ACTION_"+sGXsfl_57_idx;
         edtavMarkasread_action_Internalname = "vMARKASREAD_ACTION_"+sGXsfl_57_idx;
      }

      protected void SubsflControlProps_fel_572( )
      {
         edtavNotificationid_Internalname = "vNOTIFICATIONID_"+sGXsfl_57_fel_idx;
         edtavNotificationtext_Internalname = "vNOTIFICATIONTEXT_"+sGXsfl_57_fel_idx;
         edtavEventtargeturl_Internalname = "vEVENTTARGETURL_"+sGXsfl_57_fel_idx;
         chkavNotificationisread_Internalname = "vNOTIFICATIONISREAD_"+sGXsfl_57_fel_idx;
         edtavOpen_action_Internalname = "vOPEN_ACTION_"+sGXsfl_57_fel_idx;
         edtavMarkasread_action_Internalname = "vMARKASREAD_ACTION_"+sGXsfl_57_fel_idx;
      }

      protected void sendrow_572( )
      {
         SubsflControlProps_572( ) ;
         WB1L0( ) ;
         GridgetlatestnotificationsforcurrentuserdpRow = GXWebRow.GetNew(context,GridgetlatestnotificationsforcurrentuserdpContainer);
         if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridgetlatestnotificationsforcurrentuserdp_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
            {
               subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Odd";
            }
         }
         else if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridgetlatestnotificationsforcurrentuserdp_Backstyle = 0;
            subGridgetlatestnotificationsforcurrentuserdp_Backcolor = subGridgetlatestnotificationsforcurrentuserdp_Allbackcolor;
            if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
            {
               subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Uniform";
            }
         }
         else if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridgetlatestnotificationsforcurrentuserdp_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
            {
               subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Odd";
            }
            subGridgetlatestnotificationsforcurrentuserdp_Backcolor = (int)(0x0);
         }
         else if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridgetlatestnotificationsforcurrentuserdp_Backstyle = 1;
            if ( ((int)((nGXsfl_57_idx) % (2))) == 0 )
            {
               subGridgetlatestnotificationsforcurrentuserdp_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
               {
                  subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Even";
               }
            }
            else
            {
               subGridgetlatestnotificationsforcurrentuserdp_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
               {
                  subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Odd";
               }
            }
         }
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_57_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 58,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavNotificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18NotificationId), 15, 0, ".", "")),((edtavNotificationid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavNotificationid_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn",(String)"",(short)0,(int)edtavNotificationid_Enabled,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)15,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)0,(bool)true,(String)"K2BTools\\K2BT_LargeId",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 59,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavNotificationtext_Internalname,(String)AV20NotificationText,(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,59);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavNotificationtext_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn",(String)"",(short)-1,(int)edtavNotificationtext_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)10000,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(String)"K2BTools\\K2BT_NotificationMessage",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 60,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavEventtargeturl_Internalname,(String)AV10EventTargetUrl,(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,60);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)AV10EventTargetUrl,(String)"_blank",(String)"",(String)"",(String)edtavEventtargeturl_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)0,(int)edtavEventtargeturl_Enabled,(short)0,(String)"url",(String)"",(short)570,(String)"px",(short)17,(String)"px",(short)1000,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)0,(bool)true,(String)"GeneXus\\Url",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 61,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ClassString = "Attribute_Grid";
         StyleString = "";
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_57_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp("", false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_57_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         AV19NotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( AV19NotificationIsRead));
         AssignAttri("", false, chkavNotificationisread_Internalname, AV19NotificationIsRead);
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(String)chkavNotificationisread_Internalname,StringUtil.BoolToStr( AV19NotificationIsRead),(String)"",(String)"",(short)-1,chkavNotificationisread.Enabled,(String)"true",(String)"",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(61, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,61);\"" : " ")});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavOpen_action_Enabled!=0)&&(edtavOpen_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 62,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavOpen_action_Internalname,StringUtil.RTrim( AV21Open_Action),(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavOpen_action_Enabled!=0)&&(edtavOpen_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,62);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_OPEN\\'."+sGXsfl_57_idx+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavOpen_action_Jsonclick,(short)5,(String)"Attribute",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(short)-1,(int)edtavOpen_action_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMarkasread_action_Enabled!=0)&&(edtavMarkasread_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 63,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavMarkasread_action_Internalname,StringUtil.RTrim( AV15MarkAsRead_Action),(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavMarkasread_action_Enabled!=0)&&(edtavMarkasread_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,63);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_MARKASREAD\\'."+sGXsfl_57_idx+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavMarkasread_action_Jsonclick,(short)5,(String)"Attribute",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(short)-1,(int)edtavMarkasread_action_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         send_integrity_lvl_hashes1L2( ) ;
         GridgetlatestnotificationsforcurrentuserdpContainer.AddRow(GridgetlatestnotificationsforcurrentuserdpRow);
         nGXsfl_57_idx = ((subGridgetlatestnotificationsforcurrentuserdp_Islastpage==1)&&(nGXsfl_57_idx+1>subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         /* End function sendrow_572 */
      }

      protected void init_web_controls( )
      {
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.Name = "vGRIDSETTINGSROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.WebTags = "";
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.ItemCount > 0 )
         {
            AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0))), "."));
            AssignAttri("", false, "AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
         }
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_57_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp("", false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_57_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         AV19NotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( AV19NotificationIsRead));
         AssignAttri("", false, chkavNotificationisread_Internalname, AV19NotificationIsRead);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_LABELGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_ROWSPERPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         tblGridsettings_tablecontentgridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_TABLECONTENTGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_SAVEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divGridsettings_globaltablegridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_GLOBALTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         tblLayoutdefined_table7_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_TABLE7_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_table10_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_TABLE10_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_section7_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_SECTION7_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_section3_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_SECTION3_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_section1_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_SECTION1_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         edtavNotificationid_Internalname = "vNOTIFICATIONID";
         edtavNotificationtext_Internalname = "vNOTIFICATIONTEXT";
         edtavEventtargeturl_Internalname = "vEVENTTARGETURL";
         chkavNotificationisread_Internalname = "vNOTIFICATIONISREAD";
         edtavOpen_action_Internalname = "vOPEN_ACTION";
         edtavMarkasread_action_Internalname = "vMARKASREAD_ACTION";
         lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname = "I_NORESULTSFOUNDTABLENAME_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divMaingrid_responsivetable_gridgetlatestnotificationsforcurrentuserdp_Internalname = "MAINGRID_RESPONSIVETABLE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cellPaginationbar_previouspagebuttoncellgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONCELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_FIRSTPAGECELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_SPACINGLEFTCELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PREVIOUSPAGECELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cellPaginationbar_currentpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_CURRENTPAGECELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_NEXTPAGECELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_SPACINGRIGHTCELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cellPaginationbar_nextpagebuttoncellgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONCELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_section8_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_SECTION8_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_table3_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_TABLE3_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_grid_inner_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_GRID_INNER_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divGridcomponentcontent_gridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDCOMPONENTCONTENT_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavMarkasread_action_Jsonclick = "";
         edtavMarkasread_action_Visible = -1;
         edtavOpen_action_Jsonclick = "";
         edtavOpen_action_Visible = -1;
         chkavNotificationisread.Caption = "";
         chkavNotificationisread.Visible = -1;
         edtavEventtargeturl_Jsonclick = "";
         edtavEventtargeturl_Visible = 0;
         edtavNotificationtext_Jsonclick = "";
         edtavNotificationtext_Visible = -1;
         edtavNotificationid_Jsonclick = "";
         edtavNotificationid_Visible = 0;
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.Enabled = 1;
         divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationNext";
         cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
         cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationPrevious";
         cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
         cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsCell_PaginationLeft";
         lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "#";
         lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "#";
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "#";
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "1";
         tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         subGridgetlatestnotificationsforcurrentuserdp_Allowcollapsing = 0;
         subGridgetlatestnotificationsforcurrentuserdp_Allowselection = 0;
         subGridgetlatestnotificationsforcurrentuserdp_Sortable = 0;
         subGridgetlatestnotificationsforcurrentuserdp_Header = "";
         edtavMarkasread_action_Enabled = 1;
         edtavOpen_action_Enabled = 1;
         chkavNotificationisread.Enabled = 1;
         edtavEventtargeturl_Enabled = 1;
         edtavNotificationtext_Enabled = 1;
         edtavNotificationid_Enabled = 1;
         subGridgetlatestnotificationsforcurrentuserdp_Class = "Grid_WorkWith";
         subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "K2 BT_View All Notifications";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV29Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP.LOAD","{handler:'E141L2',iparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true}]");
         setEventMetadata("GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV18NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9',hsh:true},{av:'AV20NotificationText',fld:'vNOTIFICATIONTEXT',pic:''},{av:'AV10EventTargetUrl',fld:'vEVENTTARGETURL',pic:'',hsh:true},{av:'AV19NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'AV21Open_Action',fld:'vOPEN_ACTION',pic:''},{av:'AV15MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E181L1',iparms:[]");
         setEventMetadata("'PAGINGFIRST(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E171L1',iparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]}");
         setEventMetadata("'PAGINGNEXT(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E191L1',iparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E201L1',iparms:[{av:'divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp'},{av:'AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vGRIDSETTINGSROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E111L2',iparms:[{av:'GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV29Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp'},{av:'AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vGRIDSETTINGSROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'}]}");
         setEventMetadata("'E_OPEN'","{handler:'E151L2',iparms:[{av:'AV10EventTargetUrl',fld:'vEVENTTARGETURL',pic:'',hsh:true},{av:'AV18NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_OPEN'",",oparms:[]}");
         setEventMetadata("'E_MARKASREAD'","{handler:'E161L2',iparms:[{av:'AV18NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_MARKASREAD'",",oparms:[]}");
         setEventMetadata("VALIDV_EVENTTARGETURL","{handler:'Validv_Eventtargeturl',iparms:[]");
         setEventMetadata("VALIDV_EVENTTARGETURL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Markasread_action',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP = new GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification(context);
         AV29Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         GridgetlatestnotificationsforcurrentuserdpContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridgetlatestnotificationsforcurrentuserdp_Linesclass = "";
         GridgetlatestnotificationsforcurrentuserdpColumn = new GXWebColumn();
         AV20NotificationText = "";
         AV10EventTargetUrl = "";
         AV21Open_Action = "";
         AV15MarkAsRead_Action = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13HttpRequest = new GxHttpRequest( context);
         AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "TABLEROS_WEB");
         GXt_objcol_SdtWebNotificationSDT_Notification1 = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "TABLEROS_WEB");
         GridgetlatestnotificationsforcurrentuserdpRow = new GXWebRow();
         AV17Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Message = new SdtMessages_Message(context);
         lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         TempTags = "";
         bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bt_viewallnotifications__default(),
            new Object[][] {
            }
         );
         AV29Pgmname = "K2BT_ViewAllNotifications";
         /* GeneXus formulas. */
         AV29Pgmname = "K2BT_ViewAllNotifications";
         context.Gx_err = 0;
         edtavNotificationid_Enabled = 0;
         edtavNotificationtext_Enabled = 0;
         edtavEventtargeturl_Enabled = 0;
         chkavNotificationisread.Enabled = 0;
         edtavOpen_action_Enabled = 0;
         edtavMarkasread_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP ;
      private short AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Titlebackstyle ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Sortable ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Allowselection ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Allowhovering ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Allowcollapsing ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP ;
      private short GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nEOF ;
      private short AV14I_LoadCount_GridGetLatestNotificationsForCurrentUserDP ;
      private short GXt_int2 ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Backstyle ;
      private int divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int nRC_GXsfl_57 ;
      private int nGXsfl_57_idx=1 ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Titlebackcolor ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Allbackcolor ;
      private int edtavNotificationid_Enabled ;
      private int edtavNotificationtext_Enabled ;
      private int edtavEventtargeturl_Enabled ;
      private int edtavOpen_action_Enabled ;
      private int edtavMarkasread_action_Enabled ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Selectedindex ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Selectioncolor ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Hoveringcolor ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Islastpage ;
      private int tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int AV28GXV1 ;
      private int lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int AV30GXV2 ;
      private int idxLst ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Backcolor ;
      private int edtavNotificationid_Visible ;
      private int edtavNotificationtext_Visible ;
      private int edtavEventtargeturl_Visible ;
      private int edtavOpen_action_Visible ;
      private int edtavMarkasread_action_Visible ;
      private long AV18NotificationId ;
      private long GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nCurrentRecord ;
      private long GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_57_idx="0001" ;
      private String AV29Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String divContenttable_Internalname ;
      private String divGridcomponentcontent_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String divLayoutdefined_grid_inner_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String divLayoutdefined_table10_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String divLayoutdefined_table3_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String divLayoutdefined_section1_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String divLayoutdefined_section7_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String divLayoutdefined_section3_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String divMaingrid_responsivetable_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String sStyleString ;
      private String subGridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String subGridgetlatestnotificationsforcurrentuserdp_Class ;
      private String subGridgetlatestnotificationsforcurrentuserdp_Linesclass ;
      private String subGridgetlatestnotificationsforcurrentuserdp_Header ;
      private String AV21Open_Action ;
      private String AV15MarkAsRead_Action ;
      private String divLayoutdefined_section8_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavNotificationid_Internalname ;
      private String edtavNotificationtext_Internalname ;
      private String edtavEventtargeturl_Internalname ;
      private String chkavNotificationisread_Internalname ;
      private String edtavOpen_action_Internalname ;
      private String edtavMarkasread_action_Internalname ;
      private String cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption ;
      private String lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption ;
      private String lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption ;
      private String lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption ;
      private String lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class ;
      private String lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class ;
      private String lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Class ;
      private String cellPaginationbar_firstpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Class ;
      private String cellPaginationbar_spacingleftcellgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Class ;
      private String cellPaginationbar_previouspagecellgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Class ;
      private String cellPaginationbar_spacingrightcellgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Class ;
      private String cellPaginationbar_nextpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String tblPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String cellPaginationbar_previouspagebuttoncellgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String cellPaginationbar_currentpagecellgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String cellPaginationbar_nextpagebuttoncellgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String tblLayoutdefined_table7_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String divGridsettings_globaltablegridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String TempTags ;
      private String bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String tblGridsettings_tablecontentgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private String sGXsfl_57_fel_idx="0001" ;
      private String ROClassString ;
      private String edtavNotificationid_Jsonclick ;
      private String edtavNotificationtext_Jsonclick ;
      private String edtavEventtargeturl_Jsonclick ;
      private String GXCCtl ;
      private String edtavOpen_action_Jsonclick ;
      private String edtavMarkasread_action_Jsonclick ;
      private bool entryPointCalled ;
      private bool AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool AV19NotificationIsRead ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_57_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV24Success ;
      private String AV20NotificationText ;
      private String AV10EventTargetUrl ;
      private GXWebGrid GridgetlatestnotificationsforcurrentuserdpContainer ;
      private GXWebRow GridgetlatestnotificationsforcurrentuserdpRow ;
      private GXWebColumn GridgetlatestnotificationsforcurrentuserdpColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp ;
      private GXCheckbox chkavNotificationisread ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV13HttpRequest ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> GXt_objcol_SdtWebNotificationSDT_Notification1 ;
      private GXBaseCollection<SdtMessages_Message> AV17Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP ;
      private SdtMessages_Message AV16Message ;
   }

   public class k2bt_viewallnotifications__default : DataStoreHelperBase, IDataStoreHelper
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
