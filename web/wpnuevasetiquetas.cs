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
   public class wpnuevasetiquetas : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpnuevasetiquetas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpnuevasetiquetas( IGxContext context )
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
         cmbavGridsettingsrowsperpage_grid = new GXCombobox();
         cmbTrEtiquetas_Estado = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_68 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_68_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_68_idx = GetNextPar( );
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
               AV26Pgmname = GetNextPar( );
               AV15CurrentPage_Grid = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV26Pgmname, AV15CurrentPage_Grid) ;
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
         PA1Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1Z2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211744935", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpnuevasetiquetas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_68", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_68), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17RowsPerPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTRETIQUETAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TrEtiquetas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
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
            WE1Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1Z2( ) ;
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
         return formatLink("wpnuevasetiquetas.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WpNuevasEtiquetas" ;
      }

      public override String GetPgmdesc( )
      {
         return "Etiquetas" ;
      }

      protected void WB1Z0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Etiquetas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpNuevasEtiquetas.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_22_1Z2( true) ;
         }
         else
         {
            wb_table1_22_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_1Z2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_37_1Z2( true) ;
         }
         else
         {
            wb_table2_37_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table2_37_1Z2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"68\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( edtavActualizaretiqueta_action_Title) ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id Etiqueta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre de etiqueta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de creacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
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
               GridContainer.AddObjectProperty("Class", "Grid");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV23ActualizarEtiqueta_Action));
               GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavActualizaretiqueta_action_Title));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavActualizaretiqueta_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41TrEtiquetas_ID), 13, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A42TrEtiquetas_Nombre));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A43TrEtiquetas_FechaCreacion, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A45TrEtiquetas_Estado), 4, 0, ".", "")));
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
         if ( wbEnd == 68 )
         {
            wbEnd = 0;
            nRC_GXsfl_68 = (int)(nGXsfl_68_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_76_1Z2( true) ;
         }
         else
         {
            wb_table3_76_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table3_76_1Z2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_grid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            wb_table4_83_1Z2( true) ;
         }
         else
         {
            wb_table4_83_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table4_83_1Z2e( bool wbgen )
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
         if ( wbEnd == 68 )
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
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1Z2( )
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
            Form.Meta.addItem("description", "Etiquetas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1Z0( ) ;
      }

      protected void WS1Z2( )
      {
         START1Z2( ) ;
         EVT1Z2( ) ;
      }

      protected void EVT1Z2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_CREARETIQUETA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_CrearEtiqueta' */
                              E111Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGFIRST(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingFirst(Grid)' */
                              E121Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGLAST(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingLast(Grid)' */
                              E131Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGNEXT(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingNext(Grid)' */
                              E141Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGPREVIOUS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingPrevious(Grid)' */
                              E151Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid)' */
                              E161Z2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "'E_ACTUALIZARETIQUETA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "'E_ACTUALIZARETIQUETA'") == 0 ) )
                           {
                              nGXsfl_68_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
                              SubsflControlProps_682( ) ;
                              AV23ActualizarEtiqueta_Action = cgiGet( edtavActualizaretiqueta_action_Internalname);
                              AssignProp("", false, edtavActualizaretiqueta_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV23ActualizarEtiqueta_Action)) ? AV27Actualizaretiqueta_action_GXI : context.convertURL( context.PathToRelativeUrl( AV23ActualizarEtiqueta_Action))), !bGXsfl_68_Refreshing);
                              AssignProp("", false, edtavActualizaretiqueta_action_Internalname, "SrcSet", context.GetImageSrcSet( AV23ActualizarEtiqueta_Action), true);
                              A41TrEtiquetas_ID = (long)(context.localUtil.CToN( cgiGet( edtTrEtiquetas_ID_Internalname), ".", ","));
                              A42TrEtiquetas_Nombre = cgiGet( edtTrEtiquetas_Nombre_Internalname);
                              n42TrEtiquetas_Nombre = false;
                              A43TrEtiquetas_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrEtiquetas_FechaCreacion_Internalname), 0));
                              n43TrEtiquetas_FechaCreacion = false;
                              cmbTrEtiquetas_Estado.Name = cmbTrEtiquetas_Estado_Internalname;
                              cmbTrEtiquetas_Estado.CurrentValue = cgiGet( cmbTrEtiquetas_Estado_Internalname);
                              A45TrEtiquetas_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrEtiquetas_Estado_Internalname), "."));
                              n45TrEtiquetas_Estado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E181Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E191Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E201Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_ACTUALIZARETIQUETA'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_ActualizarEtiqueta' */
                                    E211Z2 ();
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

      protected void WE1Z2( )
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

      protected void PA1Z2( )
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
               GX_FocusControl = cmbavGridsettingsrowsperpage_grid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_682( ) ;
         while ( nGXsfl_68_idx <= nRC_GXsfl_68 )
         {
            sendrow_682( ) ;
            nGXsfl_68_idx = ((subGrid_Islastpage==1)&&(nGXsfl_68_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_682( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       String AV26Pgmname ,
                                       short AV15CurrentPage_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E181Z2 ();
         GRID_nCurrentRecord = 0;
         RF1Z2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRETIQUETAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A41TrEtiquetas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRETIQUETAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41TrEtiquetas_ID), 13, 0, ".", "")));
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
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV19GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV19GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E181Z2 ();
         RF1Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV26Pgmname = "WpNuevasEtiquetas";
         context.Gx_err = 0;
      }

      protected void RF1Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 68;
         E191Z2 ();
         nGXsfl_68_idx = 1;
         sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
         SubsflControlProps_682( ) ;
         bGXsfl_68_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "Grid");
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
            SubsflControlProps_682( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H001Z2 */
            pr_default.execute(0, new Object[] {GXPagingFrom2, GXPagingTo2});
            nGXsfl_68_idx = 1;
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_682( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A45TrEtiquetas_Estado = H001Z2_A45TrEtiquetas_Estado[0];
               n45TrEtiquetas_Estado = H001Z2_n45TrEtiquetas_Estado[0];
               A43TrEtiquetas_FechaCreacion = H001Z2_A43TrEtiquetas_FechaCreacion[0];
               n43TrEtiquetas_FechaCreacion = H001Z2_n43TrEtiquetas_FechaCreacion[0];
               A42TrEtiquetas_Nombre = H001Z2_A42TrEtiquetas_Nombre[0];
               n42TrEtiquetas_Nombre = H001Z2_n42TrEtiquetas_Nombre[0];
               A41TrEtiquetas_ID = H001Z2_A41TrEtiquetas_ID[0];
               E201Z2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 68;
            WB1Z0( ) ;
         }
         bGXsfl_68_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1Z2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TRETIQUETAS_ID"+"_"+sGXsfl_68_idx, GetSecureSignedToken( sGXsfl_68_idx, context.localUtil.Format( (decimal)(A41TrEtiquetas_ID), "ZZZZZZZZZZZZ9"), context));
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
         /* Using cursor H001Z3 */
         pr_default.execute(1);
         GRID_nRecordCount = H001Z3_AGRID_nRecordCount[0];
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV26Pgmname, AV15CurrentPage_Grid) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV26Pgmname, AV15CurrentPage_Grid) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV26Pgmname, AV15CurrentPage_Grid) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV26Pgmname, AV15CurrentPage_Grid) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV26Pgmname, AV15CurrentPage_Grid) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV26Pgmname = "WpNuevasEtiquetas";
         context.Gx_err = 0;
      }

      protected void STRUP1Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_68 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_68"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV19GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."));
            AssignAttri("", false, "AV19GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0));
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

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
         edtavActualizaretiqueta_action_Title = "Acciones";
         AssignProp("", false, edtavActualizaretiqueta_action_Internalname, "Title", edtavActualizaretiqueta_action_Title, !bGXsfl_68_Refreshing);
      }

      protected void S142( )
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
         E171Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171Z2( )
      {
         /* Start Routine */
         new k2bloadrowsperpage(context ).execute(  AV26Pgmname,  "Grid", out  AV17RowsPerPage_Grid, out  AV18RowsPerPageLoaded_Grid) ;
         AssignAttri("", false, "AV17RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV17RowsPerPage_Grid), 4, 0));
         if ( ! AV18RowsPerPageLoaded_Grid )
         {
            AV17RowsPerPage_Grid = 10;
            AssignAttri("", false, "AV17RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV17RowsPerPage_Grid), 4, 0));
         }
         AV19GridSettingsRowsPerPage_Grid = AV17RowsPerPage_Grid;
         AssignAttri("", false, "AV19GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0));
         subGrid_Rows = AV17RowsPerPage_Grid;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E181Z2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         if ( (0==AV15CurrentPage_Grid) )
         {
            AV15CurrentPage_Grid = 1;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
         }
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E111Z2( )
      {
         /* 'E_CrearEtiqueta' Routine */
         /* Execute user subroutine: 'U_CREARETIQUETA' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'U_CREARETIQUETA' Routine */
         context.PopUp(formatLink("wpcrearetiquetas.aspx") , new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void S192( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         AV22TrEtiquetas_ID = A41TrEtiquetas_ID;
         AssignAttri("", false, "AV22TrEtiquetas_ID", StringUtil.LTrimStr( (decimal)(AV22TrEtiquetas_ID), 13, 0));
      }

      protected void E121Z2( )
      {
         /* 'PagingFirst(Grid)' Routine */
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         AV20PageCount_Grid = (short)(subGrid_fnc_Pagecount( ));
         if ( AV15CurrentPage_Grid > AV20PageCount_Grid )
         {
            AV15CurrentPage_Grid = AV20PageCount_Grid;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
            subgrid_lastpage( ) ;
         }
         if ( AV20PageCount_Grid == 0 )
         {
            AV15CurrentPage_Grid = 0;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
         }
         else
         {
            AV15CurrentPage_Grid = (short)(subGrid_fnc_Currentpage( ));
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
         }
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_Grid-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_Grid), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_Grid+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_lastpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV20PageCount_Grid), 10, 0);
         AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_Internalname, "Caption", lblPaginationbar_lastpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV15CurrentPage_Grid) || ( AV15CurrentPage_Grid <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
            cellPaginationbar_firstpagecellgrid_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_firstpagecellgrid_Internalname, "Class", cellPaginationbar_firstpagecellgrid_Class, true);
            lblPaginationbar_firstpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
            cellPaginationbar_spacingleftcellgrid_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingleftcellgrid_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_Class, true);
            lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            cellPaginationbar_previouspagecellgrid_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_Internalname, "Class", cellPaginationbar_previouspagecellgrid_Class, true);
            lblPaginationbar_previouspagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_previouspagecellgrid_Class = "K2BToolsCell_PaginationPrevious";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_Internalname, "Class", cellPaginationbar_previouspagecellgrid_Class, true);
            lblPaginationbar_previouspagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
            if ( AV15CurrentPage_Grid == 2 )
            {
               cellPaginationbar_firstpagecellgrid_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_Internalname, "Class", cellPaginationbar_firstpagecellgrid_Class, true);
               lblPaginationbar_firstpagetextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               cellPaginationbar_spacingleftcellgrid_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingleftcellgrid_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_Class, true);
               lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_firstpagecellgrid_Class = "K2BToolsCell_PaginationLeft";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_Internalname, "Class", cellPaginationbar_firstpagecellgrid_Class, true);
               lblPaginationbar_firstpagetextblockgrid_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               if ( AV15CurrentPage_Grid == 3 )
               {
                  cellPaginationbar_spacingleftcellgrid_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingleftcellgrid_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( AV15CurrentPage_Grid == AV20PageCount_Grid )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
            cellPaginationbar_lastpagecellgrid_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_lastpagecellgrid_Internalname, "Class", cellPaginationbar_lastpagecellgrid_Class, true);
            lblPaginationbar_lastpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_Visible), 5, 0), true);
            cellPaginationbar_spacingrightcellgrid_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingrightcellgrid_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            cellPaginationbar_nextpagecellgrid_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_Internalname, "Class", cellPaginationbar_nextpagecellgrid_Class, true);
            lblPaginationbar_nextpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_nextpagecellgrid_Class = "K2BToolsCell_PaginationNext";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_Internalname, "Class", cellPaginationbar_nextpagecellgrid_Class, true);
            lblPaginationbar_nextpagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
            if ( AV15CurrentPage_Grid == AV20PageCount_Grid - 1 )
            {
               cellPaginationbar_lastpagecellgrid_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_Internalname, "Class", cellPaginationbar_lastpagecellgrid_Class, true);
               lblPaginationbar_lastpagetextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_Visible), 5, 0), true);
               cellPaginationbar_spacingrightcellgrid_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingrightcellgrid_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_Class, true);
               lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_lastpagecellgrid_Class = "K2BToolsCell_PaginationRight";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_Internalname, "Class", cellPaginationbar_lastpagecellgrid_Class, true);
               lblPaginationbar_lastpagetextblockgrid_Visible = 1;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_Visible), 5, 0), true);
               if ( AV15CurrentPage_Grid == AV20PageCount_Grid - 2 )
               {
                  cellPaginationbar_spacingrightcellgrid_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingrightcellgrid_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV15CurrentPage_Grid <= 1 ) && ( AV20PageCount_Grid <= 1 ) )
         {
            tblPaginationbar_pagingcontainertablegrid_Visible = 0;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_Visible), 5, 0), true);
         }
         else
         {
            tblPaginationbar_pagingcontainertablegrid_Visible = 1;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_Visible), 5, 0), true);
         }
      }

      protected void S182( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
      }

      protected void E191Z2( )
      {
         /* Grid_Refresh Routine */
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      private void E201Z2( )
      {
         /* Grid_Load Routine */
         tblI_noresultsfoundtablename_grid_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV23ActualizarEtiqueta_Action = context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( ));
         AssignAttri("", false, edtavActualizaretiqueta_action_Internalname, AV23ActualizarEtiqueta_Action);
         AV27Actualizaretiqueta_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( )));
         edtavActualizaretiqueta_action_Tooltiptext = "Actualizar Etiqueta";
         /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 68;
         }
         sendrow_682( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_68_Refreshing )
         {
            context.DoAjaxLoad(68, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         AV10GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV26Pgmname,  AV10GridStateKey, out  AV11GridState) ;
         AV20PageCount_Grid = (short)(subGrid_fnc_Pagecount( ));
         if ( ( AV11GridState.gxTpr_Currentpage > 0 ) && ( AV11GridState.gxTpr_Currentpage <= AV20PageCount_Grid ) )
         {
            AV15CurrentPage_Grid = AV11GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
            subgrid_gotopage( AV15CurrentPage_Grid) ;
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         AV10GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV26Pgmname,  AV10GridStateKey, out  AV11GridState) ;
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         AV11GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV26Pgmname,  AV10GridStateKey,  AV11GridState) ;
      }

      protected void E131Z2( )
      {
         /* 'PagingLast(Grid)' Routine */
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E141Z2( )
      {
         /* 'PagingNext(Grid)' Routine */
         subgrid_nextpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E151Z2( )
      {
         /* 'PagingPrevious(Grid)' Routine */
         subgrid_previouspage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E161Z2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         subGrid_Rows = AV19GridSettingsRowsPerPage_Grid;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         if ( AV17RowsPerPage_Grid != AV19GridSettingsRowsPerPage_Grid )
         {
            AV17RowsPerPage_Grid = AV19GridSettingsRowsPerPage_Grid;
            AssignAttri("", false, "AV17RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV17RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV26Pgmname,  "Grid",  AV17RowsPerPage_Grid) ;
            AV15CurrentPage_Grid = 1;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV26Pgmname, AV15CurrentPage_Grid) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E211Z2( )
      {
         /* 'E_ActualizarEtiqueta' Routine */
         /* Execute user subroutine: 'U_ACTUALIZARETIQUETA' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S202( )
      {
         /* 'U_ACTUALIZARETIQUETA' Routine */
         /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         context.PopUp(formatLink("wpactualizaretiqueta.aspx") + "?" + UrlEncode("" +AV22TrEtiquetas_ID), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void wb_table4_83_1Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblPaginationbar_pagingcontainertablegrid_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblPaginationbar_pagingcontainertablegrid_Internalname, tblPaginationbar_pagingcontainertablegrid_Internalname, "", "K2BToolsTable_PaginationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagebuttoncellgrid_Internalname+"\"  class='K2BToolsCell_PaginationFirst'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "&laquo;", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID)\\'."+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 5, "", 1, 1, 1, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_firstpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_firstpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGFIRST(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingleftcellgrid_Internalname+"\"  class='"+cellPaginationbar_spacingleftcellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagecellgrid_Internalname+"\"  class='"+cellPaginationbar_previouspagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_currentpagecellgrid_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_nextpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingrightcellgrid_Internalname+"\"  class='"+cellPaginationbar_spacingrightcellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_lastpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_lastpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_lastpagetextblockgrid_Internalname, lblPaginationbar_lastpagetextblockgrid_Caption, "", "", lblPaginationbar_lastpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGLAST(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_lastpagetextblockgrid_Visible, 1, 0, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagebuttoncellgrid_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "&raquo;", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID)\\'."+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 5, "", 1, 1, 1, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_83_1Z2e( true) ;
         }
         else
         {
            wb_table4_83_1Z2e( false) ;
         }
      }

      protected void wb_table3_76_1Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_Internalname, tblI_noresultsfoundtablename_grid_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No Existe datos", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_76_1Z2e( true) ;
         }
         else
         {
            wb_table3_76_1Z2e( false) ;
         }
      }

      protected void wb_table2_37_1Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_grid_Internalname, tblLayoutdefined_table7_grid_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltablegrid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_Internalname, "", "", "", lblGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e221z1_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WpNuevasEtiquetas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegrid_Internalname, divGridsettings_contentoutertablegrid_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table5_49_1Z2( true) ;
         }
         else
         {
            wb_table5_49_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table5_49_1Z2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(68), 2, 0)+","+"null"+");", "Guardar", bttGridsettings_savegrid_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpNuevasEtiquetas.htm");
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
            wb_table2_37_1Z2e( true) ;
         }
         else
         {
            wb_table2_37_1Z2e( false) ;
         }
      }

      protected void wb_table5_49_1Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_Internalname, tblGridsettings_tablecontentgrid_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_Internalname, "Filas por página", "", "", lblGridsettings_rowsperpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, "Grid Settings Rows Per Page_Grid", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_68_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Filas por página", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "", true, "HLP_WpNuevasEtiquetas.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_49_1Z2e( true) ;
         }
         else
         {
            wb_table5_49_1Z2e( false) ;
         }
      }

      protected void wb_table1_22_1Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "BtnAdd";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCrearetiqueta_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(68), 2, 0)+","+"null"+");", "Crear Etiqueta", bttCrearetiqueta_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CREARETIQUETA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpNuevasEtiquetas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_1Z2e( true) ;
         }
         else
         {
            wb_table1_22_1Z2e( false) ;
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
         PA1Z2( ) ;
         WS1Z2( ) ;
         WE1Z2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211745045", true, true);
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
         context.AddJavascriptSource("wpnuevasetiquetas.js", "?202210211745045", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_682( )
      {
         edtavActualizaretiqueta_action_Internalname = "vACTUALIZARETIQUETA_ACTION_"+sGXsfl_68_idx;
         edtTrEtiquetas_ID_Internalname = "TRETIQUETAS_ID_"+sGXsfl_68_idx;
         edtTrEtiquetas_Nombre_Internalname = "TRETIQUETAS_NOMBRE_"+sGXsfl_68_idx;
         edtTrEtiquetas_FechaCreacion_Internalname = "TRETIQUETAS_FECHACREACION_"+sGXsfl_68_idx;
         cmbTrEtiquetas_Estado_Internalname = "TRETIQUETAS_ESTADO_"+sGXsfl_68_idx;
      }

      protected void SubsflControlProps_fel_682( )
      {
         edtavActualizaretiqueta_action_Internalname = "vACTUALIZARETIQUETA_ACTION_"+sGXsfl_68_fel_idx;
         edtTrEtiquetas_ID_Internalname = "TRETIQUETAS_ID_"+sGXsfl_68_fel_idx;
         edtTrEtiquetas_Nombre_Internalname = "TRETIQUETAS_NOMBRE_"+sGXsfl_68_fel_idx;
         edtTrEtiquetas_FechaCreacion_Internalname = "TRETIQUETAS_FECHACREACION_"+sGXsfl_68_fel_idx;
         cmbTrEtiquetas_Estado_Internalname = "TRETIQUETAS_ESTADO_"+sGXsfl_68_fel_idx;
      }

      protected void sendrow_682( )
      {
         SubsflControlProps_682( ) ;
         WB1Z0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_68_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_68_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_68_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavActualizaretiqueta_action_Enabled!=0)&&(edtavActualizaretiqueta_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 69,'',false,'',68)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV23ActualizarEtiqueta_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV23ActualizarEtiqueta_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV27Actualizaretiqueta_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV23ActualizarEtiqueta_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV23ActualizarEtiqueta_Action)) ? AV27Actualizaretiqueta_action_GXI : context.PathToRelativeUrl( AV23ActualizarEtiqueta_Action));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavActualizaretiqueta_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Actualizar Etiqueta",(String)edtavActualizaretiqueta_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavActualizaretiqueta_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_ACTUALIZARETIQUETA\\'."+sGXsfl_68_idx+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV23ActualizarEtiqueta_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrEtiquetas_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41TrEtiquetas_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A41TrEtiquetas_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrEtiquetas_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrEtiquetas_Nombre_Internalname,StringUtil.RTrim( A42TrEtiquetas_Nombre),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrEtiquetas_Nombre_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)256,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrEtiquetas_FechaCreacion_Internalname,context.localUtil.Format(A43TrEtiquetas_FechaCreacion, "99/99/9999"),context.localUtil.Format( A43TrEtiquetas_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrEtiquetas_FechaCreacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTrEtiquetas_Estado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TRETIQUETAS_ESTADO_" + sGXsfl_68_idx;
               cmbTrEtiquetas_Estado.Name = GXCCtl;
               cmbTrEtiquetas_Estado.WebTags = "";
               cmbTrEtiquetas_Estado.addItem("1", "Nuevo", 0);
               cmbTrEtiquetas_Estado.addItem("2", "En Progreso", 0);
               cmbTrEtiquetas_Estado.addItem("3", "Completado", 0);
               cmbTrEtiquetas_Estado.addItem("4", "Detenido", 0);
               cmbTrEtiquetas_Estado.addItem("5", "Pendiente", 0);
               if ( cmbTrEtiquetas_Estado.ItemCount > 0 )
               {
                  A45TrEtiquetas_Estado = (short)(NumberUtil.Val( cmbTrEtiquetas_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0))), "."));
                  n45TrEtiquetas_Estado = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTrEtiquetas_Estado,(String)cmbTrEtiquetas_Estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0)),(short)1,(String)cmbTrEtiquetas_Estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute_Grid",(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbTrEtiquetas_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0));
            AssignProp("", false, cmbTrEtiquetas_Estado_Internalname, "Values", (String)(cmbTrEtiquetas_Estado.ToJavascriptSource()), !bGXsfl_68_Refreshing);
            send_integrity_lvl_hashes1Z2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_68_idx = ((subGrid_Islastpage==1)&&(nGXsfl_68_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_682( ) ;
         }
         /* End function sendrow_682 */
      }

      protected void init_web_controls( )
      {
         cmbavGridsettingsrowsperpage_grid.Name = "vGRIDSETTINGSROWSPERPAGE_GRID";
         cmbavGridsettingsrowsperpage_grid.WebTags = "";
         cmbavGridsettingsrowsperpage_grid.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV19GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV19GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0));
         }
         GXCCtl = "TRETIQUETAS_ESTADO_" + sGXsfl_68_idx;
         cmbTrEtiquetas_Estado.Name = GXCCtl;
         cmbTrEtiquetas_Estado.WebTags = "";
         cmbTrEtiquetas_Estado.addItem("1", "Nuevo", 0);
         cmbTrEtiquetas_Estado.addItem("2", "En Progreso", 0);
         cmbTrEtiquetas_Estado.addItem("3", "Completado", 0);
         cmbTrEtiquetas_Estado.addItem("4", "Detenido", 0);
         cmbTrEtiquetas_Estado.addItem("5", "Pendiente", 0);
         if ( cmbTrEtiquetas_Estado.ItemCount > 0 )
         {
            A45TrEtiquetas_Estado = (short)(NumberUtil.Val( cmbTrEtiquetas_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A45TrEtiquetas_Estado), 4, 0))), "."));
            n45TrEtiquetas_Estado = false;
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divSection2_Internalname = "SECTION2";
         divTable1_Internalname = "TABLE1";
         bttCrearetiqueta_Internalname = "CREARETIQUETA";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         lblGridsettings_labelgrid_Internalname = "GRIDSETTINGS_LABELGRID";
         lblGridsettings_rowsperpagetextblockgrid_Internalname = "GRIDSETTINGS_ROWSPERPAGETEXTBLOCKGRID";
         cmbavGridsettingsrowsperpage_grid_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID";
         tblGridsettings_tablecontentgrid_Internalname = "GRIDSETTINGS_TABLECONTENTGRID";
         bttGridsettings_savegrid_Internalname = "GRIDSETTINGS_SAVEGRID";
         divGridsettings_contentoutertablegrid_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID";
         divGridsettings_globaltablegrid_Internalname = "GRIDSETTINGS_GLOBALTABLEGRID";
         tblLayoutdefined_table7_grid_Internalname = "LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         edtavActualizaretiqueta_action_Internalname = "vACTUALIZARETIQUETA_ACTION";
         edtTrEtiquetas_ID_Internalname = "TRETIQUETAS_ID";
         edtTrEtiquetas_Nombre_Internalname = "TRETIQUETAS_NOMBRE";
         edtTrEtiquetas_FechaCreacion_Internalname = "TRETIQUETAS_FECHACREACION";
         cmbTrEtiquetas_Estado_Internalname = "TRETIQUETAS_ESTADO";
         lblI_noresultsfoundtextblock_grid_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = "MAINGRID_RESPONSIVETABLE_GRID";
         lblPaginationbar_previouspagebuttontextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID";
         cellPaginationbar_previouspagebuttoncellgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONCELLGRID";
         lblPaginationbar_firstpagetextblockgrid_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID";
         cellPaginationbar_firstpagecellgrid_Internalname = "PAGINATIONBAR_FIRSTPAGECELLGRID";
         lblPaginationbar_spacinglefttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID";
         cellPaginationbar_spacingleftcellgrid_Internalname = "PAGINATIONBAR_SPACINGLEFTCELLGRID";
         lblPaginationbar_previouspagetextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID";
         cellPaginationbar_previouspagecellgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGECELLGRID";
         lblPaginationbar_currentpagetextblockgrid_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID";
         cellPaginationbar_currentpagecellgrid_Internalname = "PAGINATIONBAR_CURRENTPAGECELLGRID";
         lblPaginationbar_nextpagetextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID";
         cellPaginationbar_nextpagecellgrid_Internalname = "PAGINATIONBAR_NEXTPAGECELLGRID";
         lblPaginationbar_spacingrighttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID";
         cellPaginationbar_spacingrightcellgrid_Internalname = "PAGINATIONBAR_SPACINGRIGHTCELLGRID";
         lblPaginationbar_lastpagetextblockgrid_Internalname = "PAGINATIONBAR_LASTPAGETEXTBLOCKGRID";
         cellPaginationbar_lastpagecellgrid_Internalname = "PAGINATIONBAR_LASTPAGECELLGRID";
         lblPaginationbar_nextpagebuttontextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID";
         cellPaginationbar_nextpagebuttoncellgrid_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONCELLGRID";
         tblPaginationbar_pagingcontainertablegrid_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLEGRID";
         divLayoutdefined_section8_grid_Internalname = "LAYOUTDEFINED_SECTION8_GRID";
         divLayoutdefined_table3_grid_Internalname = "LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = "GRIDCOMPONENTCONTENT_GRID";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         cmbTrEtiquetas_Estado_Jsonclick = "";
         edtTrEtiquetas_FechaCreacion_Jsonclick = "";
         edtTrEtiquetas_Nombre_Jsonclick = "";
         edtTrEtiquetas_ID_Jsonclick = "";
         edtavActualizaretiqueta_action_Jsonclick = "";
         edtavActualizaretiqueta_action_Visible = -1;
         edtavActualizaretiqueta_action_Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         lblPaginationbar_lastpagetextblockgrid_Visible = 1;
         lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_Visible = 1;
         lblPaginationbar_previouspagetextblockgrid_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_Visible = 1;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         tblPaginationbar_pagingcontainertablegrid_Visible = 1;
         cellPaginationbar_nextpagecellgrid_Class = "K2BToolsCell_PaginationNext";
         cellPaginationbar_spacingrightcellgrid_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
         cellPaginationbar_lastpagecellgrid_Class = "K2BToolsCell_PaginationRight";
         cellPaginationbar_previouspagecellgrid_Class = "K2BToolsCell_PaginationPrevious";
         cellPaginationbar_spacingleftcellgrid_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
         cellPaginationbar_firstpagecellgrid_Class = "K2BToolsCell_PaginationLeft";
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_lastpagetextblockgrid_Caption = "1";
         lblPaginationbar_nextpagetextblockgrid_Caption = "#";
         lblPaginationbar_currentpagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Caption = "#";
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavActualizaretiqueta_action_Tooltiptext = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavActualizaretiqueta_action_Title = "";
         subGrid_Class = "Grid";
         subGrid_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Etiquetas";
         subGrid_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'edtavActualizaretiqueta_action_Title',ctrl:'vACTUALIZARETIQUETA_ACTION',prop:'Title'}]}");
         setEventMetadata("'E_CREARETIQUETA'","{handler:'E111Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'E_CREARETIQUETA'",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'edtavActualizaretiqueta_action_Title',ctrl:'vACTUALIZARETIQUETA_ACTION',prop:'Title'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E121Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E191Z2',iparms:[{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E201Z2',iparms:[{av:'A41TrEtiquetas_ID',fld:'TRETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV23ActualizarEtiqueta_Action',fld:'vACTUALIZARETIQUETA_ACTION',pic:''},{av:'edtavActualizaretiqueta_action_Tooltiptext',ctrl:'vACTUALIZARETIQUETA_ACTION',prop:'Tooltiptext'},{av:'AV22TrEtiquetas_ID',fld:'vTRETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("'PAGINGLAST(GRID)'","{handler:'E131Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGLAST(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E141Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E151Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E221Z1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E161Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV19GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV17RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'edtavActualizaretiqueta_action_Title',ctrl:'vACTUALIZARETIQUETA_ACTION',prop:'Title'}]}");
         setEventMetadata("'E_ACTUALIZARETIQUETA'","{handler:'E211Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV22TrEtiquetas_ID',fld:'vTRETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A41TrEtiquetas_ID',fld:'TRETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_ACTUALIZARETIQUETA'",",oparms:[{av:'AV22TrEtiquetas_ID',fld:'vTRETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'edtavActualizaretiqueta_action_Title',ctrl:'vACTUALIZARETIQUETA_ACTION',prop:'Title'}]}");
         setEventMetadata("NULL","{handler:'Valid_Tretiquetas_estado',iparms:[]");
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
         AV26Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV23ActualizarEtiqueta_Action = "";
         A42TrEtiquetas_Nombre = "";
         A43TrEtiquetas_FechaCreacion = DateTime.MinValue;
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27Actualizaretiqueta_action_GXI = "";
         scmdbuf = "";
         H001Z2_A45TrEtiquetas_Estado = new short[1] ;
         H001Z2_n45TrEtiquetas_Estado = new bool[] {false} ;
         H001Z2_A43TrEtiquetas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H001Z2_n43TrEtiquetas_FechaCreacion = new bool[] {false} ;
         H001Z2_A42TrEtiquetas_Nombre = new String[] {""} ;
         H001Z2_n42TrEtiquetas_Nombre = new bool[] {false} ;
         H001Z2_A41TrEtiquetas_ID = new long[1] ;
         H001Z3_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV10GridStateKey = "";
         AV11GridState = new SdtK2BGridState(context);
         lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_Jsonclick = "";
         lblPaginationbar_lastpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick = "";
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         lblGridsettings_labelgrid_Jsonclick = "";
         TempTags = "";
         bttGridsettings_savegrid_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgrid_Jsonclick = "";
         bttCrearetiqueta_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpnuevasetiquetas__default(),
            new Object[][] {
                new Object[] {
               H001Z2_A45TrEtiquetas_Estado, H001Z2_n45TrEtiquetas_Estado, H001Z2_A43TrEtiquetas_FechaCreacion, H001Z2_n43TrEtiquetas_FechaCreacion, H001Z2_A42TrEtiquetas_Nombre, H001Z2_n42TrEtiquetas_Nombre, H001Z2_A41TrEtiquetas_ID
               }
               , new Object[] {
               H001Z3_AGRID_nRecordCount
               }
            }
         );
         AV26Pgmname = "WpNuevasEtiquetas";
         /* GeneXus formulas. */
         AV26Pgmname = "WpNuevasEtiquetas";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15CurrentPage_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV17RowsPerPage_Grid ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A45TrEtiquetas_Estado ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV19GridSettingsRowsPerPage_Grid ;
      private short AV20PageCount_Grid ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int divGridsettings_contentoutertablegrid_Visible ;
      private int nRC_GXsfl_68 ;
      private int nGXsfl_68_idx=1 ;
      private int subGrid_Rows ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_lastpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int tblPaginationbar_pagingcontainertablegrid_Visible ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavActualizaretiqueta_action_Enabled ;
      private int edtavActualizaretiqueta_action_Visible ;
      private long GRID_nFirstRecordOnPage ;
      private long AV22TrEtiquetas_ID ;
      private long A41TrEtiquetas_ID ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_68_idx="0001" ;
      private String AV26Pgmname ;
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
      private String divResponsivetable_containernode_actions_Internalname ;
      private String divGridcomponentcontent_grid_Internalname ;
      private String divLayoutdefined_grid_inner_grid_Internalname ;
      private String divLayoutdefined_table10_grid_Internalname ;
      private String divLayoutdefined_table3_grid_Internalname ;
      private String divMaingrid_responsivetable_grid_Internalname ;
      private String sStyleString ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String edtavActualizaretiqueta_action_Title ;
      private String subGrid_Header ;
      private String edtavActualizaretiqueta_action_Tooltiptext ;
      private String A42TrEtiquetas_Nombre ;
      private String divLayoutdefined_section8_grid_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavActualizaretiqueta_action_Internalname ;
      private String edtTrEtiquetas_ID_Internalname ;
      private String edtTrEtiquetas_Nombre_Internalname ;
      private String edtTrEtiquetas_FechaCreacion_Internalname ;
      private String cmbTrEtiquetas_Estado_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_Internalname ;
      private String scmdbuf ;
      private String divGridsettings_contentoutertablegrid_Internalname ;
      private String lblPaginationbar_firstpagetextblockgrid_Caption ;
      private String lblPaginationbar_firstpagetextblockgrid_Internalname ;
      private String lblPaginationbar_previouspagetextblockgrid_Caption ;
      private String lblPaginationbar_previouspagetextblockgrid_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_Caption ;
      private String lblPaginationbar_currentpagetextblockgrid_Internalname ;
      private String lblPaginationbar_nextpagetextblockgrid_Caption ;
      private String lblPaginationbar_nextpagetextblockgrid_Internalname ;
      private String lblPaginationbar_lastpagetextblockgrid_Caption ;
      private String lblPaginationbar_lastpagetextblockgrid_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_Class ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_Class ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_Internalname ;
      private String cellPaginationbar_firstpagecellgrid_Class ;
      private String cellPaginationbar_firstpagecellgrid_Internalname ;
      private String cellPaginationbar_spacingleftcellgrid_Class ;
      private String cellPaginationbar_spacingleftcellgrid_Internalname ;
      private String lblPaginationbar_spacinglefttextblockgrid_Internalname ;
      private String cellPaginationbar_previouspagecellgrid_Class ;
      private String cellPaginationbar_previouspagecellgrid_Internalname ;
      private String cellPaginationbar_lastpagecellgrid_Class ;
      private String cellPaginationbar_lastpagecellgrid_Internalname ;
      private String cellPaginationbar_spacingrightcellgrid_Class ;
      private String cellPaginationbar_spacingrightcellgrid_Internalname ;
      private String lblPaginationbar_spacingrighttextblockgrid_Internalname ;
      private String cellPaginationbar_nextpagecellgrid_Class ;
      private String cellPaginationbar_nextpagecellgrid_Internalname ;
      private String tblPaginationbar_pagingcontainertablegrid_Internalname ;
      private String tblI_noresultsfoundtablename_grid_Internalname ;
      private String cellPaginationbar_previouspagebuttoncellgrid_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick ;
      private String lblPaginationbar_firstpagetextblockgrid_Jsonclick ;
      private String lblPaginationbar_spacinglefttextblockgrid_Jsonclick ;
      private String lblPaginationbar_previouspagetextblockgrid_Jsonclick ;
      private String cellPaginationbar_currentpagecellgrid_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_Jsonclick ;
      private String lblPaginationbar_nextpagetextblockgrid_Jsonclick ;
      private String lblPaginationbar_spacingrighttextblockgrid_Jsonclick ;
      private String lblPaginationbar_lastpagetextblockgrid_Jsonclick ;
      private String cellPaginationbar_nextpagebuttoncellgrid_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick ;
      private String lblI_noresultsfoundtextblock_grid_Internalname ;
      private String lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private String tblLayoutdefined_table7_grid_Internalname ;
      private String divGridsettings_globaltablegrid_Internalname ;
      private String lblGridsettings_labelgrid_Internalname ;
      private String lblGridsettings_labelgrid_Jsonclick ;
      private String TempTags ;
      private String bttGridsettings_savegrid_Internalname ;
      private String bttGridsettings_savegrid_Jsonclick ;
      private String tblGridsettings_tablecontentgrid_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_Jsonclick ;
      private String cmbavGridsettingsrowsperpage_grid_Jsonclick ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String bttCrearetiqueta_Internalname ;
      private String bttCrearetiqueta_Jsonclick ;
      private String sGXsfl_68_fel_idx="0001" ;
      private String sImgUrl ;
      private String edtavActualizaretiqueta_action_Jsonclick ;
      private String ROClassString ;
      private String edtTrEtiquetas_ID_Jsonclick ;
      private String edtTrEtiquetas_Nombre_Jsonclick ;
      private String edtTrEtiquetas_FechaCreacion_Jsonclick ;
      private String GXCCtl ;
      private String cmbTrEtiquetas_Estado_Jsonclick ;
      private DateTime A43TrEtiquetas_FechaCreacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_68_Refreshing=false ;
      private bool n42TrEtiquetas_Nombre ;
      private bool n43TrEtiquetas_FechaCreacion ;
      private bool n45TrEtiquetas_Estado ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV23ActualizarEtiqueta_Action_IsBlob ;
      private String AV27Actualizaretiqueta_action_GXI ;
      private String AV10GridStateKey ;
      private String AV23ActualizarEtiqueta_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCombobox cmbTrEtiquetas_Estado ;
      private IDataStoreProvider pr_default ;
      private short[] H001Z2_A45TrEtiquetas_Estado ;
      private bool[] H001Z2_n45TrEtiquetas_Estado ;
      private DateTime[] H001Z2_A43TrEtiquetas_FechaCreacion ;
      private bool[] H001Z2_n43TrEtiquetas_FechaCreacion ;
      private String[] H001Z2_A42TrEtiquetas_Nombre ;
      private bool[] H001Z2_n42TrEtiquetas_Nombre ;
      private long[] H001Z2_A41TrEtiquetas_ID ;
      private long[] H001Z3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtK2BGridState AV11GridState ;
   }

   public class wpnuevasetiquetas__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH001Z2 ;
          prmH001Z2 = new Object[] {
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH001Z3 ;
          prmH001Z3 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("H001Z2", "SELECT [TrEtiquetas_Estado], [TrEtiquetas_FechaCreacion], [TrEtiquetas_Nombre], [TrEtiquetas_ID] FROM TABLERO.[TrEtiquetas] ORDER BY [TrEtiquetas_ID]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001Z3", "SELECT COUNT(*) FROM TABLERO.[TrEtiquetas] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((String[]) buf[4])[0] = rslt.getString(3, 256) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4) ;
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
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                return;
       }
    }

 }

}
