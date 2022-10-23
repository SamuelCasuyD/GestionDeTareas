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
   public class inicio : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public inicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public inicio( IGxContext context )
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
               nRC_GXsfl_110 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_110_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_110_idx = GetNextPar( );
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
               AV38GenericFilter_Grid = GetNextPar( );
               AV39TrGestionTableros_Nombre_Filter = GetNextPar( );
               AV40TrGestionTableros_FechaCreacion_Filter = context.localUtil.ParseDateParm( GetNextPar( ));
               AV43Pgmname = GetNextPar( );
               AV15CurrentPage_Grid = (short)(NumberUtil.Val( GetNextPar( ), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV24CrearTablero_SDT);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV38GenericFilter_Grid, AV39TrGestionTableros_Nombre_Filter, AV40TrGestionTableros_FechaCreacion_Filter, AV43Pgmname, AV15CurrentPage_Grid, AV24CrearTablero_SDT) ;
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
         PA1N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1N2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211857798", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("inicio.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vGENERICFILTER_GRID", StringUtil.RTrim( AV38GenericFilter_Grid));
         GxWebStd.gx_hidden_field( context, "GXH_vTRGESTIONTABLEROS_NOMBRE_FILTER", StringUtil.RTrim( AV39TrGestionTableros_Nombre_Filter));
         GxWebStd.gx_hidden_field( context, "GXH_vTRGESTIONTABLEROS_FECHACREACION_FILTER", context.localUtil.Format(AV40TrGestionTableros_FechaCreacion_Filter, "99/99/9999"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_110", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_110), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV43Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCREARTABLERO_SDT", AV24CrearTablero_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCREARTABLERO_SDT", AV24CrearTablero_SDT);
         }
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17RowsPerPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCONFIRMATIONREQUIRED", AV26ConfirmationRequired);
         GxWebStd.gx_hidden_field( context, "vCONFIRMATIONSUBID", StringUtil.RTrim( AV27ConfirmationSubId));
         GxWebStd.gx_hidden_field( context, "vGRIDKEY_TRGESTIONTABLEROS_ID", AV28GridKey_TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "vTABLEROS_ID", AV32Tableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTABLEROS_NOMBRE", StringUtil.RTrim( AV33TrGestionTableros_Nombre));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTABLEROS_FECHAINICIO", context.localUtil.DToC( AV34TrGestionTableros_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTABLEROS_FECHAFIN", context.localUtil.DToC( AV35TrGestionTableros_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0, ".", "")));
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
            WE1N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1N2( ) ;
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
         return formatLink("inicio.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "Inicio" ;
      }

      public override String GetPgmdesc( )
      {
         return "Inicio" ;
      }

      protected void WB1N0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Gestión de tableros", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_Inicio.htm");
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
            wb_table1_22_1N2( true) ;
         }
         else
         {
            wb_table1_22_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_1N2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponent_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_31_1N2( true) ;
         }
         else
         {
            wb_table2_31_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table2_31_1N2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            wb_table3_46_1N2( true) ;
         }
         else
         {
            wb_table3_46_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table3_46_1N2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_combinedfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section4_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_CombinedFilters", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGenericfilter_grid_Internalname, "Generic Filter_Grid", "gx-form-item K2BTools_SearchCriteriaLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_grid_Internalname, StringUtil.RTrim( AV38GenericFilter_Grid), StringUtil.RTrim( context.localUtil.Format( AV38GenericFilter_Grid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavGenericfilter_grid_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavGenericfilter_grid_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Inicio.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgLayoutdefined_filtertoggle_combined_grid_Bitmap;
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_combined_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filtertoggle_combined_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Inicio.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLayoutdefined_filtersummary_combined_grid_Internalname, lblLayoutdefined_filtersummary_combined_grid_Caption, "", "", lblLayoutdefined_filtersummary_combined_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_FilterSummary", 0, "", 1, 1, 0, "HLP_Inicio.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, divLayoutdefined_filtercollapsiblesection_combined_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filterclose_combined_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filterclose_combined_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Inicio.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMainfilterresponsivetable_filters_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercontainertable_filters_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_nombre_filter_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavTrgestiontableros_nombre_filter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrgestiontableros_nombre_filter_Internalname, "Nombre del tablero", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_nombre_filter_Internalname, StringUtil.RTrim( AV39TrGestionTableros_Nombre_Filter), StringUtil.RTrim( context.localUtil.Format( AV39TrGestionTableros_Nombre_Filter, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_nombre_filter_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavTrgestiontableros_nombre_filter_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Inicio.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trgestiontableros_fechacreacion_filter_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavTrgestiontableros_fechacreacion_filter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrgestiontableros_fechacreacion_filter_Internalname, "Fecha de creación", "gx-form-item Attribute_FilterDateLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_110_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontableros_fechacreacion_filter_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechacreacion_filter_Internalname, context.localUtil.Format(AV40TrGestionTableros_FechaCreacion_Filter, "99/99/9999"), context.localUtil.Format( AV40TrGestionTableros_FechaCreacion_Filter, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechacreacion_filter_Jsonclick, 0, "Attribute_FilterDate", "", "", "", "", 1, edtavTrgestiontableros_fechacreacion_filter_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Inicio.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechacreacion_filter_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechacreacion_filter_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Inicio.htm");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"110\">") ;
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
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "gestión tablero") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre del tablero") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de creación") ;
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
               GridColumn.AddObjectProperty("Value", context.convertURL( AV22EliminarTablero_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavEliminartablero_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV29ListaTareas_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavListatareas_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV30CrearTareas_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavCreartareas_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1TrGestionTableros_ID.ToString());
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A2TrGestionTableros_Nombre));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTrGestionTableros_Nombre_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
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
         if ( wbEnd == 110 )
         {
            wbEnd = 0;
            nRC_GXsfl_110 = (int)(nGXsfl_110_idx-1);
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
            wb_table4_121_1N2( true) ;
         }
         else
         {
            wb_table4_121_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table4_121_1N2e( bool wbgen )
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
            wb_table5_128_1N2( true) ;
         }
         else
         {
            wb_table5_128_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table5_128_1N2e( bool wbgen )
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table6_151_1N2( true) ;
         }
         else
         {
            wb_table6_151_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table6_151_1N2e( bool wbgen )
      {
         if ( wbgen )
         {
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
         if ( wbEnd == 110 )
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

      protected void START1N2( )
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
            Form.Meta.addItem("description", "Inicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1N0( ) ;
      }

      protected void WS1N2( )
      {
         START1N2( ) ;
         EVT1N2( ) ;
      }

      protected void EVT1N2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGFIRST(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingFirst(Grid)' */
                              E111N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGLAST(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingLast(Grid)' */
                              E121N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGNEXT(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingNext(Grid)' */
                              E131N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGPREVIOUS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingPrevious(Grid)' */
                              E141N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid)' */
                              E151N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CREARTABLERO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_CrearTablero' */
                              E161N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMYES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmYes' */
                              E171N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E181N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E191N2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "'E_ELIMINARTABLERO'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "'E_CREARTAREAS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "'E_ELIMINARTABLERO'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "'E_CREARTAREAS'") == 0 ) )
                           {
                              nGXsfl_110_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
                              SubsflControlProps_1102( ) ;
                              AV22EliminarTablero_Action = cgiGet( edtavEliminartablero_action_Internalname);
                              AssignProp("", false, edtavEliminartablero_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV22EliminarTablero_Action)) ? AV44Eliminartablero_action_GXI : context.convertURL( context.PathToRelativeUrl( AV22EliminarTablero_Action))), !bGXsfl_110_Refreshing);
                              AssignProp("", false, edtavEliminartablero_action_Internalname, "SrcSet", context.GetImageSrcSet( AV22EliminarTablero_Action), true);
                              AV29ListaTareas_Action = cgiGet( edtavListatareas_action_Internalname);
                              AssignProp("", false, edtavListatareas_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV29ListaTareas_Action)) ? AV45Listatareas_action_GXI : context.convertURL( context.PathToRelativeUrl( AV29ListaTareas_Action))), !bGXsfl_110_Refreshing);
                              AssignProp("", false, edtavListatareas_action_Internalname, "SrcSet", context.GetImageSrcSet( AV29ListaTareas_Action), true);
                              AV30CrearTareas_Action = cgiGet( edtavCreartareas_action_Internalname);
                              AssignProp("", false, edtavCreartareas_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV30CrearTareas_Action)) ? AV46Creartareas_action_GXI : context.convertURL( context.PathToRelativeUrl( AV30CrearTareas_Action))), !bGXsfl_110_Refreshing);
                              AssignProp("", false, edtavCreartareas_action_Internalname, "SrcSet", context.GetImageSrcSet( AV30CrearTareas_Action), true);
                              A1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrGestionTableros_ID_Internalname)));
                              A2TrGestionTableros_Nombre = cgiGet( edtTrGestionTableros_Nombre_Internalname);
                              n2TrGestionTableros_Nombre = false;
                              A3TrGestionTableros_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaInicio_Internalname), 0));
                              n3TrGestionTableros_FechaInicio = false;
                              A4TrGestionTableros_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaFin_Internalname), 0));
                              n4TrGestionTableros_FechaFin = false;
                              A7TrGestionTableros_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaCreacion_Internalname), 0));
                              n7TrGestionTableros_FechaCreacion = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E201N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E211N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E221N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E231N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_ELIMINARTABLERO'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_EliminarTablero' */
                                    E241N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_CREARTAREAS'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_CrearTareas' */
                                    E251N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Genericfilter_grid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vGENERICFILTER_GRID"), AV38GenericFilter_Grid) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Trgestiontableros_nombre_filter Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTRGESTIONTABLEROS_NOMBRE_FILTER"), AV39TrGestionTableros_Nombre_Filter) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Trgestiontableros_fechacreacion_filter Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTRGESTIONTABLEROS_FECHACREACION_FILTER"), 0) != AV40TrGestionTableros_FechaCreacion_Filter )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE1N2( )
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

      protected void PA1N2( )
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
         SubsflControlProps_1102( ) ;
         while ( nGXsfl_110_idx <= nRC_GXsfl_110 )
         {
            sendrow_1102( ) ;
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       String AV38GenericFilter_Grid ,
                                       String AV39TrGestionTableros_Nombre_Filter ,
                                       DateTime AV40TrGestionTableros_FechaCreacion_Filter ,
                                       String AV43Pgmname ,
                                       short AV15CurrentPage_Grid ,
                                       SdtCrearTablero_SDT AV24CrearTablero_SDT )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E211N2 ();
         GRID_nCurrentRecord = 0;
         RF1N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_ID", GetSecureSignedToken( "", A1TrGestionTableros_ID, context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_ID", A1TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_NOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A2TrGestionTableros_Nombre, "")), context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_NOMBRE", StringUtil.RTrim( A2TrGestionTableros_Nombre));
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_FECHAINICIO", GetSecureSignedToken( "", A3TrGestionTableros_FechaInicio, context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHAINICIO", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_FECHAFIN", GetSecureSignedToken( "", A4TrGestionTableros_FechaFin, context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_FECHAFIN", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
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
         E211N2 ();
         RF1N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV43Pgmname = "Inicio";
         context.Gx_err = 0;
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void RF1N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         E221N2 ();
         nGXsfl_110_idx = 1;
         sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
         SubsflControlProps_1102( ) ;
         bGXsfl_110_Refreshing = true;
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
            SubsflControlProps_1102( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV39TrGestionTableros_Nombre_Filter ,
                                                 AV40TrGestionTableros_FechaCreacion_Filter ,
                                                 AV38GenericFilter_Grid ,
                                                 A2TrGestionTableros_Nombre ,
                                                 A7TrGestionTableros_FechaCreacion } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.DATE, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                                 }
            } ) ;
            lV39TrGestionTableros_Nombre_Filter = StringUtil.PadR( StringUtil.RTrim( AV39TrGestionTableros_Nombre_Filter), 100, "%");
            lV38GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV38GenericFilter_Grid), 100, "%");
            /* Using cursor H001N2 */
            pr_default.execute(0, new Object[] {lV39TrGestionTableros_Nombre_Filter, AV40TrGestionTableros_FechaCreacion_Filter, lV38GenericFilter_Grid, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A7TrGestionTableros_FechaCreacion = H001N2_A7TrGestionTableros_FechaCreacion[0];
               n7TrGestionTableros_FechaCreacion = H001N2_n7TrGestionTableros_FechaCreacion[0];
               A4TrGestionTableros_FechaFin = H001N2_A4TrGestionTableros_FechaFin[0];
               n4TrGestionTableros_FechaFin = H001N2_n4TrGestionTableros_FechaFin[0];
               A3TrGestionTableros_FechaInicio = H001N2_A3TrGestionTableros_FechaInicio[0];
               n3TrGestionTableros_FechaInicio = H001N2_n3TrGestionTableros_FechaInicio[0];
               A2TrGestionTableros_Nombre = H001N2_A2TrGestionTableros_Nombre[0];
               n2TrGestionTableros_Nombre = H001N2_n2TrGestionTableros_Nombre[0];
               A1TrGestionTableros_ID = (Guid)((Guid)(H001N2_A1TrGestionTableros_ID[0]));
               E231N2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 110;
            WB1N0( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1N2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV43Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_ID"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, A1TrGestionTableros_ID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_NOMBRE"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, StringUtil.RTrim( context.localUtil.Format( A2TrGestionTableros_Nombre, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_FECHAINICIO"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, A3TrGestionTableros_FechaInicio, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_FECHAFIN"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, A4TrGestionTableros_FechaFin, context));
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
                                              AV39TrGestionTableros_Nombre_Filter ,
                                              AV40TrGestionTableros_FechaCreacion_Filter ,
                                              AV38GenericFilter_Grid ,
                                              A2TrGestionTableros_Nombre ,
                                              A7TrGestionTableros_FechaCreacion } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.DATE, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         } ) ;
         lV39TrGestionTableros_Nombre_Filter = StringUtil.PadR( StringUtil.RTrim( AV39TrGestionTableros_Nombre_Filter), 100, "%");
         lV38GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV38GenericFilter_Grid), 100, "%");
         /* Using cursor H001N3 */
         pr_default.execute(1, new Object[] {lV39TrGestionTableros_Nombre_Filter, AV40TrGestionTableros_FechaCreacion_Filter, lV38GenericFilter_Grid});
         GRID_nRecordCount = H001N3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV38GenericFilter_Grid, AV39TrGestionTableros_Nombre_Filter, AV40TrGestionTableros_FechaCreacion_Filter, AV43Pgmname, AV15CurrentPage_Grid, AV24CrearTablero_SDT) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV38GenericFilter_Grid, AV39TrGestionTableros_Nombre_Filter, AV40TrGestionTableros_FechaCreacion_Filter, AV43Pgmname, AV15CurrentPage_Grid, AV24CrearTablero_SDT) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV38GenericFilter_Grid, AV39TrGestionTableros_Nombre_Filter, AV40TrGestionTableros_FechaCreacion_Filter, AV43Pgmname, AV15CurrentPage_Grid, AV24CrearTablero_SDT) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV38GenericFilter_Grid, AV39TrGestionTableros_Nombre_Filter, AV40TrGestionTableros_FechaCreacion_Filter, AV43Pgmname, AV15CurrentPage_Grid, AV24CrearTablero_SDT) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV38GenericFilter_Grid, AV39TrGestionTableros_Nombre_Filter, AV40TrGestionTableros_FechaCreacion_Filter, AV43Pgmname, AV15CurrentPage_Grid, AV24CrearTablero_SDT) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV43Pgmname = "Inicio";
         context.Gx_err = 0;
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void STRUP1N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E201N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vCREARTABLERO_SDT"), AV24CrearTablero_SDT);
            /* Read saved values. */
            nRC_GXsfl_110 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ".", ","));
            AV35TrGestionTableros_FechaFin = context.localUtil.CToD( cgiGet( "vTRGESTIONTABLEROS_FECHAFIN"), 0);
            AV34TrGestionTableros_FechaInicio = context.localUtil.CToD( cgiGet( "vTRGESTIONTABLEROS_FECHAINICIO"), 0);
            AV33TrGestionTableros_Nombre = cgiGet( "vTRGESTIONTABLEROS_NOMBRE");
            AV32Tableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( "vTABLEROS_ID")));
            AV27ConfirmationSubId = cgiGet( "vCONFIRMATIONSUBID");
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = (int)(context.localUtil.CToN( cgiGet( "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID_Visible"), ".", ","));
            /* Read variables values. */
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV19GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."));
            AssignAttri("", false, "AV19GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0));
            AV38GenericFilter_Grid = cgiGet( edtavGenericfilter_grid_Internalname);
            AssignAttri("", false, "AV38GenericFilter_Grid", AV38GenericFilter_Grid);
            AV39TrGestionTableros_Nombre_Filter = cgiGet( edtavTrgestiontableros_nombre_filter_Internalname);
            AssignAttri("", false, "AV39TrGestionTableros_Nombre_Filter", AV39TrGestionTableros_Nombre_Filter);
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontableros_fechacreacion_filter_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Creacion del tablero"}), 1, "vTRGESTIONTABLEROS_FECHACREACION_FILTER");
               GX_FocusControl = edtavTrgestiontableros_fechacreacion_filter_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40TrGestionTableros_FechaCreacion_Filter = DateTime.MinValue;
               AssignAttri("", false, "AV40TrGestionTableros_FechaCreacion_Filter", context.localUtil.Format(AV40TrGestionTableros_FechaCreacion_Filter, "99/99/9999"));
            }
            else
            {
               AV40TrGestionTableros_FechaCreacion_Filter = context.localUtil.CToD( cgiGet( edtavTrgestiontableros_fechacreacion_filter_Internalname), 2);
               AssignAttri("", false, "AV40TrGestionTableros_FechaCreacion_Filter", context.localUtil.Format(AV40TrGestionTableros_FechaCreacion_Filter, "99/99/9999"));
            }
            AV25ConfirmMessage = cgiGet( edtavConfirmmessage_Internalname);
            AssignAttri("", false, "AV25ConfirmMessage", AV25ConfirmMessage);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vGENERICFILTER_GRID"), AV38GenericFilter_Grid) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTRGESTIONTABLEROS_NOMBRE_FILTER"), AV39TrGestionTableros_Nombre_Filter) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vTRGESTIONTABLEROS_FECHACREACION_FILTER"), 2) != AV40TrGestionTableros_FechaCreacion_Filter )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S142( )
      {
         /* 'U_STARTPAGE' Routine */
      }

      protected void S152( )
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
         E201N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E201N2( )
      {
         /* Start Routine */
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV43Pgmname,  "Grid", out  AV17RowsPerPage_Grid, out  AV18RowsPerPageLoaded_Grid) ;
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
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
      }

      protected void E211N2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26ConfirmationRequired = false;
         AssignAttri("", false, "AV26ConfirmationRequired", AV26ConfirmationRequired);
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         if ( (0==AV15CurrentPage_Grid) )
         {
            AV15CurrentPage_Grid = 1;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
         }
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         edtTrGestionTableros_Nombre_Link = formatLink("wpactualizartablero.aspx") + "?" + UrlEncode(A1TrGestionTableros_ID.ToString());
         AssignProp("", false, edtTrGestionTableros_Nombre_Internalname, "Link", edtTrGestionTableros_Nombre_Link, !bGXsfl_110_Refreshing);
         AV24CrearTablero_SDT.gxTpr_Trgestiontableros_id = (Guid)(A1TrGestionTableros_ID);
         AV32Tableros_ID = (Guid)(A1TrGestionTableros_ID);
         AssignAttri("", false, "AV32Tableros_ID", AV32Tableros_ID.ToString());
         AV33TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
         AssignAttri("", false, "AV33TrGestionTableros_Nombre", AV33TrGestionTableros_Nombre);
         AV34TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
         AssignAttri("", false, "AV34TrGestionTableros_FechaInicio", context.localUtil.Format(AV34TrGestionTableros_FechaInicio, "99/99/9999"));
         AV35TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
         AssignAttri("", false, "AV35TrGestionTableros_FechaFin", context.localUtil.Format(AV35TrGestionTableros_FechaFin, "99/99/9999"));
      }

      protected void E111N2( )
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

      protected void E221N2( )
      {
         /* Grid_Refresh Routine */
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
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

      private void E231N2( )
      {
         /* Grid_Load Routine */
         tblI_noresultsfoundtablename_grid_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV22EliminarTablero_Action = context.GetImagePath( "4cb13b83-cf55-4682-9d11-58cce2b11e48", "", context.GetTheme( ));
         AssignAttri("", false, edtavEliminartablero_action_Internalname, AV22EliminarTablero_Action);
         AV44Eliminartablero_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "4cb13b83-cf55-4682-9d11-58cce2b11e48", "", context.GetTheme( )));
         edtavEliminartablero_action_Tooltiptext = "Eliminar Tablero";
         AV29ListaTareas_Action = context.GetImagePath( "2f3769f5-8338-4d4d-977a-358584c21168", "", context.GetTheme( ));
         AssignAttri("", false, edtavListatareas_action_Internalname, AV29ListaTareas_Action);
         AV45Listatareas_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2f3769f5-8338-4d4d-977a-358584c21168", "", context.GetTheme( )));
         edtavListatareas_action_Tooltiptext = "Gestión de tareas";
         AV30CrearTareas_Action = context.GetImagePath( "f69c9f60-b03c-44e8-b258-8e031d7b2972", "", context.GetTheme( ));
         AssignAttri("", false, edtavCreartareas_action_Internalname, AV30CrearTareas_Action);
         AV46Creartareas_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f69c9f60-b03c-44e8-b258-8e031d7b2972", "", context.GetTheme( )));
         edtavCreartareas_action_Tooltiptext = "Crear Tareas";
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
            wbStart = 110;
         }
         sendrow_1102( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_110_Refreshing )
         {
            context.DoAjaxLoad(110, GridRow);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24CrearTablero_SDT", AV24CrearTablero_SDT);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         AV12GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV43Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "TrGestionTableros_Nombre_Filter") == 0 )
            {
               AV39TrGestionTableros_Nombre_Filter = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TrGestionTableros_Nombre_Filter", AV39TrGestionTableros_Nombre_Filter);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "TrGestionTableros_FechaCreacion_Filter") == 0 )
            {
               AV40TrGestionTableros_FechaCreacion_Filter = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV40TrGestionTableros_FechaCreacion_Filter", context.localUtil.Format(AV40TrGestionTableros_FechaCreacion_Filter, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "GenericFilter_Grid") == 0 )
            {
               AV38GenericFilter_Grid = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38GenericFilter_Grid", AV38GenericFilter_Grid);
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         AV20PageCount_Grid = (short)(subGrid_fnc_Pagecount( ));
         if ( ( AV13GridState.gxTpr_Currentpage > 0 ) && ( AV13GridState.gxTpr_Currentpage <= AV20PageCount_Grid ) )
         {
            AV15CurrentPage_Grid = AV13GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
            subgrid_gotopage( AV15CurrentPage_Grid) ;
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         AV12GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV43Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         AV13GridState.gxTpr_Filtervalues.Clear();
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "TrGestionTableros_Nombre_Filter";
         AV14GridStateFilterValue.gxTpr_Value = AV39TrGestionTableros_Nombre_Filter;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "TrGestionTableros_FechaCreacion_Filter";
         AV14GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV40TrGestionTableros_FechaCreacion_Filter, "99/99/9999");
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "GenericFilter_Grid";
         AV14GridStateFilterValue.gxTpr_Value = AV38GenericFilter_Grid;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV43Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void E121N2( )
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

      protected void E131N2( )
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

      protected void E141N2( )
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

      protected void E151N2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         subGrid_Rows = AV19GridSettingsRowsPerPage_Grid;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         if ( AV17RowsPerPage_Grid != AV19GridSettingsRowsPerPage_Grid )
         {
            AV17RowsPerPage_Grid = AV19GridSettingsRowsPerPage_Grid;
            AssignAttri("", false, "AV17RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV17RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV43Pgmname,  "Grid",  AV17RowsPerPage_Grid) ;
            AV15CurrentPage_Grid = 1;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV38GenericFilter_Grid, AV39TrGestionTableros_Nombre_Filter, AV40TrGestionTableros_FechaCreacion_Filter, AV43Pgmname, AV15CurrentPage_Grid, AV24CrearTablero_SDT) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E161N2( )
      {
         /* 'E_CrearTablero' Routine */
         /* Execute user subroutine: 'U_CREARTABLERO' */
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
         /* 'U_CREARTABLERO' Routine */
         context.PopUp(formatLink("wpcreartableros.aspx") , new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void E241N2( )
      {
         /* 'E_EliminarTablero' Routine */
         AV25ConfirmMessage = "¿Está seguro?";
         AssignAttri("", false, "AV25ConfirmMessage", AV25ConfirmMessage);
         /* Execute user subroutine: 'U_CONFIRMATIONREQUIRED(ELIMINARTABLERO)' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV26ConfirmationRequired )
         {
            AV27ConfirmationSubId = "'U_EliminarTablero'";
            AssignAttri("", false, "AV27ConfirmationSubId", AV27ConfirmationSubId);
            AV28GridKey_TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
            AssignAttri("", false, "AV28GridKey_TrGestionTableros_ID", AV28GridKey_TrGestionTableros_ID.ToString());
            tblTableconditionalconfirm_Visible = 1;
            AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         }
         else
         {
            /* Execute user subroutine: 'U_ELIMINARTABLERO' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24CrearTablero_SDT", AV24CrearTablero_SDT);
      }

      protected void S222( )
      {
         /* 'U_ELIMINARTABLERO' Routine */
         /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new tpcreartablero(context ).execute(  AV24CrearTablero_SDT,  "DEL") ;
         context.DoAjaxRefresh();
      }

      protected void E171N2( )
      {
         /* 'ConfirmYes' Routine */
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV27ConfirmationSubId, "'U_EliminarTablero'") == 0 )
         {
            /* Execute user subroutine: 'E_SETROWPOSITION(ELIMINARTABLERO)' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24CrearTablero_SDT", AV24CrearTablero_SDT);
      }

      protected void S212( )
      {
         /* 'U_CONFIRMATIONREQUIRED(ELIMINARTABLERO)' Routine */
         AV26ConfirmationRequired = true;
         AssignAttri("", false, "AV26ConfirmationRequired", AV26ConfirmationRequired);
      }

      protected void S232( )
      {
         /* 'E_SETROWPOSITION(ELIMINARTABLERO)' Routine */
         /* Start For Each Line in Grid */
         nRC_GXsfl_110 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ".", ","));
         nGXsfl_110_fel_idx = 0;
         while ( nGXsfl_110_fel_idx < nRC_GXsfl_110 )
         {
            nGXsfl_110_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_fel_idx+1);
            sGXsfl_110_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1102( ) ;
            AV22EliminarTablero_Action = cgiGet( edtavEliminartablero_action_Internalname);
            AV29ListaTareas_Action = cgiGet( edtavListatareas_action_Internalname);
            AV30CrearTareas_Action = cgiGet( edtavCreartareas_action_Internalname);
            A1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrGestionTableros_ID_Internalname)));
            A2TrGestionTableros_Nombre = cgiGet( edtTrGestionTableros_Nombre_Internalname);
            n2TrGestionTableros_Nombre = false;
            A3TrGestionTableros_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaInicio_Internalname), 0));
            n3TrGestionTableros_FechaInicio = false;
            A4TrGestionTableros_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaFin_Internalname), 0));
            n4TrGestionTableros_FechaFin = false;
            A7TrGestionTableros_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaCreacion_Internalname), 0));
            n7TrGestionTableros_FechaCreacion = false;
            if ( A1TrGestionTableros_ID == AV28GridKey_TrGestionTableros_ID )
            {
               /* Execute user subroutine: 'U_ELIMINARTABLERO' */
               S222 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            /* End For Each Line */
         }
         if ( nGXsfl_110_fel_idx == 0 )
         {
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         nGXsfl_110_fel_idx = 1;
      }

      protected void S242( )
      {
         /* 'U_LISTATAREAS' Routine */
         /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         CallWebObject(formatLink("wplistadotareasportablero.aspx") + "?" + UrlEncode(AV32Tableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV33TrGestionTableros_Nombre)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV34TrGestionTableros_FechaInicio)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV35TrGestionTableros_FechaFin)));
         context.wjLocDisableFrm = 1;
      }

      protected void E251N2( )
      {
         /* 'E_CrearTareas' Routine */
         /* Execute user subroutine: 'U_CREARTAREAS' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24CrearTablero_SDT", AV24CrearTablero_SDT);
      }

      protected void S252( )
      {
         /* 'U_CREARTAREAS' Routine */
         /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         CallWebObject(formatLink("wptablerocreartarea.aspx") + "?" + UrlEncode(AV32Tableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV33TrGestionTableros_Nombre)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV34TrGestionTableros_FechaInicio)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV35TrGestionTableros_FechaFin)));
         context.wjLocDisableFrm = 1;
         context.DoAjaxRefresh();
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         AV36K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "TABLEROS_WEB");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TrGestionTableros_Nombre_Filter)) )
         {
            AV37K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "TrGestionTableros_Nombre_Filter";
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Nombre del tablero";
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV39TrGestionTableros_Nombre_Filter;
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV39TrGestionTableros_Nombre_Filter;
            AV36K2BFilterValuesSDT_WebForm.Add(AV37K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! (DateTime.MinValue==AV40TrGestionTableros_FechaCreacion_Filter) )
         {
            AV37K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "TrGestionTableros_FechaCreacion_Filter";
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Fecha de creación";
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Value = context.localUtil.DToC( AV40TrGestionTableros_FechaCreacion_Filter, 2, "/");
            AV37K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = context.localUtil.DToC( AV40TrGestionTableros_FechaCreacion_Filter, 2, "/");
            AV36K2BFilterValuesSDT_WebForm.Add(AV37K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( AV36K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_char1 = "";
            new k2bgetfilterssummary(context ).execute(  AV43Pgmname,  "Grid",  AV36K2BFilterValuesSDT_WebForm, out  GXt_char1) ;
            lblLayoutdefined_filtersummary_combined_grid_Caption = GXt_char1;
            AssignProp("", false, lblLayoutdefined_filtersummary_combined_grid_Internalname, "Caption", lblLayoutdefined_filtersummary_combined_grid_Caption, true);
         }
         else
         {
            lblLayoutdefined_filtersummary_combined_grid_Caption = "No hay filtros aplicados";
            AssignProp("", false, lblLayoutdefined_filtersummary_combined_grid_Internalname, "Caption", lblLayoutdefined_filtersummary_combined_grid_Caption, true);
         }
      }

      protected void E181N2( )
      {
         /* Layoutdefined_filtertoggle_combined_grid_Click Routine */
         if ( divLayoutdefined_filtercollapsiblesection_combined_grid_Visible != 0 )
         {
            divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_grid_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_grid_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_grid_Bitmap), true);
         }
         else
         {
            divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 1;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_grid_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_grid_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_grid_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E191N2( )
      {
         /* Layoutdefined_filterclose_combined_grid_Click Routine */
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
         imgLayoutdefined_filtertoggle_combined_grid_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_grid_Bitmap)), true);
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_grid_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void wb_table6_151_1N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTableconditionalconfirm_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTableconditionalconfirm_Internalname, tblTableconditionalconfirm_Internalname, "", "Table_ConditionalConfirm", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table7_154_1N2( true) ;
         }
         else
         {
            wb_table7_154_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table7_154_1N2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_151_1N2e( true) ;
         }
         else
         {
            wb_table6_151_1N2e( false) ;
         }
      }

      protected void wb_table7_154_1N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSection_condconf_dialog_Internalname, tblSection_condconf_dialog_Internalname, "", "Section_CondConf_Dialog", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table8_157_1N2( true) ;
         }
         else
         {
            wb_table8_157_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table8_157_1N2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_154_1N2e( true) ;
         }
         else
         {
            wb_table7_154_1N2e( false) ;
         }
      }

      protected void wb_table8_157_1N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSection_condconf_dialog_inner_Internalname, tblSection_condconf_dialog_inner_Internalname, "", "Section_CondConf_DialogInner", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfirmmessage_Internalname, "Confirm Message", "gx-form-item Attribute_ConditionalConfirmLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfirmmessage_Internalname, StringUtil.RTrim( AV25ConfirmMessage), StringUtil.RTrim( context.localUtil.Format( AV25ConfirmMessage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfirmmessage_Jsonclick, 0, "Attribute_ConditionalConfirm", "", "", "", "", 1, edtavConfirmmessage_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Inicio.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table9_164_1N2( true) ;
         }
         else
         {
            wb_table9_164_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table9_164_1N2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_157_1N2e( true) ;
         }
         else
         {
            wb_table8_157_1N2e( false) ;
         }
      }

      protected void wb_table9_164_1N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblConfirm_hidden_actionstable_Internalname, tblConfirm_hidden_actionstable_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction_Confirm";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmyes_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Aceptar", bttI_buttonconfirmyes_Jsonclick, 5, "Aceptar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMYES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmno_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Cancelar", bttI_buttonconfirmno_Jsonclick, 7, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e261n1_client"+"'", TempTags, "", 2, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_164_1N2e( true) ;
         }
         else
         {
            wb_table9_164_1N2e( false) ;
         }
      }

      protected void wb_table5_128_1N2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "&laquo;", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID)\\'."+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 5, "", 1, 1, 1, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_firstpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_firstpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGFIRST(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingleftcellgrid_Internalname+"\"  class='"+cellPaginationbar_spacingleftcellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagecellgrid_Internalname+"\"  class='"+cellPaginationbar_previouspagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_currentpagecellgrid_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_nextpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingrightcellgrid_Internalname+"\"  class='"+cellPaginationbar_spacingrightcellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_lastpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_lastpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_lastpagetextblockgrid_Internalname, lblPaginationbar_lastpagetextblockgrid_Caption, "", "", lblPaginationbar_lastpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGLAST(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_lastpagetextblockgrid_Visible, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagebuttoncellgrid_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "&raquo;", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID)\\'."+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 5, "", 1, 1, 1, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_128_1N2e( true) ;
         }
         else
         {
            wb_table5_128_1N2e( false) ;
         }
      }

      protected void wb_table4_121_1N2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_121_1N2e( true) ;
         }
         else
         {
            wb_table4_121_1N2e( false) ;
         }
      }

      protected void wb_table3_46_1N2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_Internalname, "", "", "", lblGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e271n1_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_Inicio.htm");
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
            wb_table10_58_1N2( true) ;
         }
         else
         {
            wb_table10_58_1N2( false) ;
         }
         return  ;
      }

      protected void wb_table10_58_1N2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Guardar", bttGridsettings_savegrid_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inicio.htm");
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
            wb_table3_46_1N2e( true) ;
         }
         else
         {
            wb_table3_46_1N2e( false) ;
         }
      }

      protected void wb_table10_58_1N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_Internalname, tblGridsettings_tablecontentgrid_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_Internalname, "Filas por página", "", "", lblGridsettings_rowsperpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, "Grid Settings Rows Per Page_Grid", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Filas por página", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, "HLP_Inicio.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_58_1N2e( true) ;
         }
         else
         {
            wb_table10_58_1N2e( false) ;
         }
      }

      protected void wb_table2_31_1N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridtitlecontainertable_grid_Internalname, tblGridtitlecontainertable_grid_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridtitle_grid_Internalname, "Lista de tableros", "", "", lblGridtitle_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_31_1N2e( true) ;
         }
         else
         {
            wb_table2_31_1N2e( false) ;
         }
      }

      protected void wb_table1_22_1N2( bool wbgen )
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
            GxWebStd.gx_button_ctrl( context, bttCreartablero_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Crear Tablero", bttCreartablero_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CREARTABLERO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inicio.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_1N2e( true) ;
         }
         else
         {
            wb_table1_22_1N2e( false) ;
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
         PA1N2( ) ;
         WS1N2( ) ;
         WE1N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211857972", true, true);
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
         context.AddJavascriptSource("inicio.js", "?202210211857973", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1102( )
      {
         edtavEliminartablero_action_Internalname = "vELIMINARTABLERO_ACTION_"+sGXsfl_110_idx;
         edtavListatareas_action_Internalname = "vLISTATAREAS_ACTION_"+sGXsfl_110_idx;
         edtavCreartareas_action_Internalname = "vCREARTAREAS_ACTION_"+sGXsfl_110_idx;
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID_"+sGXsfl_110_idx;
         edtTrGestionTableros_Nombre_Internalname = "TRGESTIONTABLEROS_NOMBRE_"+sGXsfl_110_idx;
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO_"+sGXsfl_110_idx;
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN_"+sGXsfl_110_idx;
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         edtavEliminartablero_action_Internalname = "vELIMINARTABLERO_ACTION_"+sGXsfl_110_fel_idx;
         edtavListatareas_action_Internalname = "vLISTATAREAS_ACTION_"+sGXsfl_110_fel_idx;
         edtavCreartareas_action_Internalname = "vCREARTAREAS_ACTION_"+sGXsfl_110_fel_idx;
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID_"+sGXsfl_110_fel_idx;
         edtTrGestionTableros_Nombre_Internalname = "TRGESTIONTABLEROS_NOMBRE_"+sGXsfl_110_fel_idx;
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO_"+sGXsfl_110_fel_idx;
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN_"+sGXsfl_110_fel_idx;
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         SubsflControlProps_1102( ) ;
         WB1N0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_110_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_110_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_110_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavEliminartablero_action_Enabled!=0)&&(edtavEliminartablero_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 111,'',false,'',110)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV22EliminarTablero_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV22EliminarTablero_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV44Eliminartablero_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV22EliminarTablero_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV22EliminarTablero_Action)) ? AV44Eliminartablero_action_GXI : context.PathToRelativeUrl( AV22EliminarTablero_Action));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavEliminartablero_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Eliminar Tablero",(String)edtavEliminartablero_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavEliminartablero_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_ELIMINARTABLERO\\'."+sGXsfl_110_idx+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV22EliminarTablero_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavListatareas_action_Enabled!=0)&&(edtavListatareas_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 112,'',false,'',110)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV29ListaTareas_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV29ListaTareas_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV45Listatareas_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV29ListaTareas_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV29ListaTareas_Action)) ? AV45Listatareas_action_GXI : context.PathToRelativeUrl( AV29ListaTareas_Action));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavListatareas_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Gestión de tareas",(String)edtavListatareas_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)7,(String)edtavListatareas_action_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+"e281n2_client"+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV29ListaTareas_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavCreartareas_action_Enabled!=0)&&(edtavCreartareas_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 113,'',false,'',110)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV30CrearTareas_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV30CrearTareas_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV46Creartareas_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV30CrearTareas_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV30CrearTareas_Action)) ? AV46Creartareas_action_GXI : context.PathToRelativeUrl( AV30CrearTareas_Action));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavCreartareas_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Crear Tareas",(String)edtavCreartareas_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavCreartareas_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_CREARTAREAS\\'."+sGXsfl_110_idx+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV30CrearTareas_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_ID_Internalname,A1TrGestionTableros_ID.ToString(),A1TrGestionTableros_ID.ToString(),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)0,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)36,(short)0,(short)0,(short)110,(short)1,(short)0,(short)0,(bool)true,(String)"",(String)"",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_Nombre_Internalname,StringUtil.RTrim( A2TrGestionTableros_Nombre),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)edtTrGestionTableros_Nombre_Link,(String)"",(String)"",(String)"",(String)edtTrGestionTableros_Nombre_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaInicio_Internalname,context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"),context.localUtil.Format( A3TrGestionTableros_FechaInicio, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaInicio_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaFin_Internalname,context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"),context.localUtil.Format( A4TrGestionTableros_FechaFin, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaFin_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaCreacion_Internalname,context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"),context.localUtil.Format( A7TrGestionTableros_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaCreacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes1N2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         /* End function sendrow_1102 */
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
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divSection2_Internalname = "SECTION2";
         divTable1_Internalname = "TABLE1";
         bttCreartablero_Internalname = "CREARTABLERO";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         lblGridtitle_grid_Internalname = "GRIDTITLE_GRID";
         tblGridtitlecontainertable_grid_Internalname = "GRIDTITLECONTAINERTABLE_GRID";
         lblGridsettings_labelgrid_Internalname = "GRIDSETTINGS_LABELGRID";
         lblGridsettings_rowsperpagetextblockgrid_Internalname = "GRIDSETTINGS_ROWSPERPAGETEXTBLOCKGRID";
         cmbavGridsettingsrowsperpage_grid_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID";
         tblGridsettings_tablecontentgrid_Internalname = "GRIDSETTINGS_TABLECONTENTGRID";
         bttGridsettings_savegrid_Internalname = "GRIDSETTINGS_SAVEGRID";
         divGridsettings_contentoutertablegrid_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID";
         divGridsettings_globaltablegrid_Internalname = "GRIDSETTINGS_GLOBALTABLEGRID";
         tblLayoutdefined_table7_grid_Internalname = "LAYOUTDEFINED_TABLE7_GRID";
         edtavGenericfilter_grid_Internalname = "vGENERICFILTER_GRID";
         imgLayoutdefined_filtertoggle_combined_grid_Internalname = "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID";
         lblLayoutdefined_filtersummary_combined_grid_Internalname = "LAYOUTDEFINED_FILTERSUMMARY_COMBINED_GRID";
         divLayoutdefined_section4_grid_Internalname = "LAYOUTDEFINED_SECTION4_GRID";
         imgLayoutdefined_filterclose_combined_grid_Internalname = "LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID";
         edtavTrgestiontableros_nombre_filter_Internalname = "vTRGESTIONTABLEROS_NOMBRE_FILTER";
         divTable_container_trgestiontableros_nombre_filter_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_NOMBRE_FILTER";
         edtavTrgestiontableros_fechacreacion_filter_Internalname = "vTRGESTIONTABLEROS_FECHACREACION_FILTER";
         divTable_container_trgestiontableros_fechacreacion_filter_Internalname = "TABLE_CONTAINER_TRGESTIONTABLEROS_FECHACREACION_FILTER";
         divFiltercontainertable_filters_Internalname = "FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = "MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname = "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID";
         divLayoutdefined_combinedfilterlayout_grid_Internalname = "LAYOUTDEFINED_COMBINEDFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         edtavEliminartablero_action_Internalname = "vELIMINARTABLERO_ACTION";
         edtavListatareas_action_Internalname = "vLISTATAREAS_ACTION";
         edtavCreartareas_action_Internalname = "vCREARTAREAS_ACTION";
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID";
         edtTrGestionTableros_Nombre_Internalname = "TRGESTIONTABLEROS_NOMBRE";
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO";
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN";
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION";
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
         divGridcomponent_grid_Internalname = "GRIDCOMPONENT_GRID";
         divContenttable_Internalname = "CONTENTTABLE";
         edtavConfirmmessage_Internalname = "vCONFIRMMESSAGE";
         bttI_buttonconfirmyes_Internalname = "I_BUTTONCONFIRMYES";
         bttI_buttonconfirmno_Internalname = "I_BUTTONCONFIRMNO";
         tblConfirm_hidden_actionstable_Internalname = "CONFIRM_HIDDEN_ACTIONSTABLE";
         tblSection_condconf_dialog_inner_Internalname = "SECTION_CONDCONF_DIALOG_INNER";
         tblSection_condconf_dialog_Internalname = "SECTION_CONDCONF_DIALOG";
         tblTableconditionalconfirm_Internalname = "TABLECONDITIONALCONFIRM";
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
         edtTrGestionTableros_FechaCreacion_Jsonclick = "";
         edtTrGestionTableros_FechaFin_Jsonclick = "";
         edtTrGestionTableros_FechaInicio_Jsonclick = "";
         edtTrGestionTableros_Nombre_Jsonclick = "";
         edtTrGestionTableros_ID_Jsonclick = "";
         edtavCreartareas_action_Jsonclick = "";
         edtavCreartareas_action_Visible = -1;
         edtavCreartareas_action_Enabled = 1;
         edtavListatareas_action_Jsonclick = "";
         edtavListatareas_action_Visible = -1;
         edtavListatareas_action_Enabled = 1;
         edtavEliminartablero_action_Jsonclick = "";
         edtavEliminartablero_action_Visible = -1;
         edtavEliminartablero_action_Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         lblPaginationbar_lastpagetextblockgrid_Visible = 1;
         lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_Visible = 1;
         lblPaginationbar_previouspagetextblockgrid_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_Visible = 1;
         edtavConfirmmessage_Jsonclick = "";
         edtavConfirmmessage_Enabled = 1;
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
         tblTableconditionalconfirm_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtTrGestionTableros_Nombre_Link = "";
         edtavCreartareas_action_Tooltiptext = "";
         edtavListatareas_action_Tooltiptext = "";
         edtavEliminartablero_action_Tooltiptext = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "Grid";
         subGrid_Backcolorstyle = 0;
         edtavTrgestiontableros_fechacreacion_filter_Jsonclick = "";
         edtavTrgestiontableros_fechacreacion_filter_Enabled = 1;
         edtavTrgestiontableros_nombre_filter_Jsonclick = "";
         edtavTrgestiontableros_nombre_filter_Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 1;
         lblLayoutdefined_filtersummary_combined_grid_Caption = "Filter Summary";
         imgLayoutdefined_filtertoggle_combined_grid_Bitmap = (String)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavGenericfilter_grid_Jsonclick = "";
         edtavGenericfilter_grid_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Inicio";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E111N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E221N2',iparms:[{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'lblLayoutdefined_filtersummary_combined_grid_Caption',ctrl:'LAYOUTDEFINED_FILTERSUMMARY_COMBINED_GRID',prop:'Caption'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E231N2',iparms:[{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'A2TrGestionTableros_Nombre',fld:'TRGESTIONTABLEROS_NOMBRE',pic:'',hsh:true},{av:'A3TrGestionTableros_FechaInicio',fld:'TRGESTIONTABLEROS_FECHAINICIO',pic:'',hsh:true},{av:'A4TrGestionTableros_FechaFin',fld:'TRGESTIONTABLEROS_FECHAFIN',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV22EliminarTablero_Action',fld:'vELIMINARTABLERO_ACTION',pic:''},{av:'edtavEliminartablero_action_Tooltiptext',ctrl:'vELIMINARTABLERO_ACTION',prop:'Tooltiptext'},{av:'AV29ListaTareas_Action',fld:'vLISTATAREAS_ACTION',pic:''},{av:'edtavListatareas_action_Tooltiptext',ctrl:'vLISTATAREAS_ACTION',prop:'Tooltiptext'},{av:'AV30CrearTareas_Action',fld:'vCREARTAREAS_ACTION',pic:''},{av:'edtavCreartareas_action_Tooltiptext',ctrl:'vCREARTAREAS_ACTION',prop:'Tooltiptext'},{av:'edtTrGestionTableros_Nombre_Link',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Link'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV32Tableros_ID',fld:'vTABLEROS_ID',pic:''},{av:'AV33TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV34TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV35TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''}]}");
         setEventMetadata("'PAGINGLAST(GRID)'","{handler:'E121N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]");
         setEventMetadata("'PAGINGLAST(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E131N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E141N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E271N1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E151N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV19GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV17RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'}]}");
         setEventMetadata("'E_CREARTABLERO'","{handler:'E161N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''}]");
         setEventMetadata("'E_CREARTABLERO'",",oparms:[{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]}");
         setEventMetadata("'E_ELIMINARTABLERO'","{handler:'E241N2',iparms:[{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'A2TrGestionTableros_Nombre',fld:'TRGESTIONTABLEROS_NOMBRE',pic:'',hsh:true},{av:'A3TrGestionTableros_FechaInicio',fld:'TRGESTIONTABLEROS_FECHAINICIO',pic:'',hsh:true},{av:'A4TrGestionTableros_FechaFin',fld:'TRGESTIONTABLEROS_FECHAFIN',pic:'',hsh:true}]");
         setEventMetadata("'E_ELIMINARTABLERO'",",oparms:[{av:'AV25ConfirmMessage',fld:'vCONFIRMMESSAGE',pic:''},{av:'AV27ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'AV28GridKey_TrGestionTableros_ID',fld:'vGRIDKEY_TRGESTIONTABLEROS_ID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'edtTrGestionTableros_Nombre_Link',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Link'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV32Tableros_ID',fld:'vTABLEROS_ID',pic:''},{av:'AV33TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV34TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV35TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]}");
         setEventMetadata("'CONFIRMNO'","{handler:'E261N1',iparms:[]");
         setEventMetadata("'CONFIRMNO'",",oparms:[{av:'AV27ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'}]}");
         setEventMetadata("'CONFIRMYES'","{handler:'E171N2',iparms:[{av:'AV27ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',grid:110,pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_110',ctrl:'GRID',grid:110,prop:'GridRC'},{av:'AV28GridKey_TrGestionTableros_ID',fld:'vGRIDKEY_TRGESTIONTABLEROS_ID',pic:''},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'A2TrGestionTableros_Nombre',fld:'TRGESTIONTABLEROS_NOMBRE',grid:110,pic:'',hsh:true},{av:'A3TrGestionTableros_FechaInicio',fld:'TRGESTIONTABLEROS_FECHAINICIO',grid:110,pic:'',hsh:true},{av:'A4TrGestionTableros_FechaFin',fld:'TRGESTIONTABLEROS_FECHAFIN',grid:110,pic:'',hsh:true}]");
         setEventMetadata("'CONFIRMYES'",",oparms:[{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Link',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Link'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV32Tableros_ID',fld:'vTABLEROS_ID',pic:''},{av:'AV33TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV34TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV35TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]}");
         setEventMetadata("'E_LISTATAREAS'","{handler:'E281N2',iparms:[{av:'AV32Tableros_ID',fld:'vTABLEROS_ID',pic:''},{av:'AV33TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV34TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV35TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'A2TrGestionTableros_Nombre',fld:'TRGESTIONTABLEROS_NOMBRE',pic:'',hsh:true},{av:'A3TrGestionTableros_FechaInicio',fld:'TRGESTIONTABLEROS_FECHAINICIO',pic:'',hsh:true},{av:'A4TrGestionTableros_FechaFin',fld:'TRGESTIONTABLEROS_FECHAFIN',pic:'',hsh:true}]");
         setEventMetadata("'E_LISTATAREAS'",",oparms:[{av:'edtTrGestionTableros_Nombre_Link',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Link'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV32Tableros_ID',fld:'vTABLEROS_ID',pic:''},{av:'AV33TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV34TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV35TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''}]}");
         setEventMetadata("'E_CREARTAREAS'","{handler:'E251N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV39TrGestionTableros_Nombre_Filter',fld:'vTRGESTIONTABLEROS_NOMBRE_FILTER',pic:''},{av:'AV40TrGestionTableros_FechaCreacion_Filter',fld:'vTRGESTIONTABLEROS_FECHACREACION_FILTER',pic:''},{av:'AV43Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV32Tableros_ID',fld:'vTABLEROS_ID',pic:''},{av:'AV33TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV34TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV35TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A2TrGestionTableros_Nombre',fld:'TRGESTIONTABLEROS_NOMBRE',pic:'',hsh:true},{av:'A3TrGestionTableros_FechaInicio',fld:'TRGESTIONTABLEROS_FECHAINICIO',pic:'',hsh:true},{av:'A4TrGestionTableros_FechaFin',fld:'TRGESTIONTABLEROS_FECHAFIN',pic:'',hsh:true}]");
         setEventMetadata("'E_CREARTAREAS'",",oparms:[{av:'edtTrGestionTableros_Nombre_Link',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Link'},{av:'AV24CrearTablero_SDT',fld:'vCREARTABLERO_SDT',pic:''},{av:'AV32Tableros_ID',fld:'vTABLEROS_ID',pic:''},{av:'AV33TrGestionTableros_Nombre',fld:'vTRGESTIONTABLEROS_NOMBRE',pic:''},{av:'AV34TrGestionTableros_FechaInicio',fld:'vTRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'AV35TrGestionTableros_FechaFin',fld:'vTRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'AV26ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK","{handler:'E181N2',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK","{handler:'E191N2',iparms:[]");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]}");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHACREACION_FILTER","{handler:'Validv_Trgestiontableros_fechacreacion_filter',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_FECHACREACION_FILTER",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Trgestiontableros_fechacreacion',iparms:[]");
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
         AV38GenericFilter_Grid = "";
         AV39TrGestionTableros_Nombre_Filter = "";
         AV40TrGestionTableros_FechaCreacion_Filter = DateTime.MinValue;
         AV43Pgmname = "";
         AV24CrearTablero_SDT = new SdtCrearTablero_SDT(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV27ConfirmationSubId = "";
         AV28GridKey_TrGestionTableros_ID = (Guid)(Guid.Empty);
         AV32Tableros_ID = (Guid)(Guid.Empty);
         AV33TrGestionTableros_Nombre = "";
         AV34TrGestionTableros_FechaInicio = DateTime.MinValue;
         AV35TrGestionTableros_FechaFin = DateTime.MinValue;
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_combined_grid_Jsonclick = "";
         lblLayoutdefined_filtersummary_combined_grid_Jsonclick = "";
         imgLayoutdefined_filterclose_combined_grid_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV22EliminarTablero_Action = "";
         AV29ListaTareas_Action = "";
         AV30CrearTareas_Action = "";
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A2TrGestionTableros_Nombre = "";
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV44Eliminartablero_action_GXI = "";
         AV45Listatareas_action_GXI = "";
         AV46Creartareas_action_GXI = "";
         scmdbuf = "";
         lV39TrGestionTableros_Nombre_Filter = "";
         lV38GenericFilter_Grid = "";
         H001N2_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H001N2_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         H001N2_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H001N2_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         H001N2_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H001N2_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         H001N2_A2TrGestionTableros_Nombre = new String[] {""} ;
         H001N2_n2TrGestionTableros_Nombre = new bool[] {false} ;
         H001N2_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         H001N3_AGRID_nRecordCount = new long[1] ;
         AV25ConfirmMessage = "";
         GridRow = new GXWebRow();
         AV12GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV36K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "TABLEROS_WEB");
         AV37K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_char1 = "";
         bttI_buttonconfirmyes_Jsonclick = "";
         bttI_buttonconfirmno_Jsonclick = "";
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
         bttGridsettings_savegrid_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgrid_Jsonclick = "";
         lblGridtitle_grid_Jsonclick = "";
         bttCreartablero_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inicio__default(),
            new Object[][] {
                new Object[] {
               H001N2_A7TrGestionTableros_FechaCreacion, H001N2_n7TrGestionTableros_FechaCreacion, H001N2_A4TrGestionTableros_FechaFin, H001N2_n4TrGestionTableros_FechaFin, H001N2_A3TrGestionTableros_FechaInicio, H001N2_n3TrGestionTableros_FechaInicio, H001N2_A2TrGestionTableros_Nombre, H001N2_n2TrGestionTableros_Nombre, H001N2_A1TrGestionTableros_ID
               }
               , new Object[] {
               H001N3_AGRID_nRecordCount
               }
            }
         );
         AV43Pgmname = "Inicio";
         /* GeneXus formulas. */
         AV43Pgmname = "Inicio";
         context.Gx_err = 0;
         edtavConfirmmessage_Enabled = 0;
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
      private int divLayoutdefined_filtercollapsiblesection_combined_grid_Visible ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int subGrid_Rows ;
      private int edtavGenericfilter_grid_Enabled ;
      private int edtavTrgestiontableros_nombre_filter_Enabled ;
      private int edtavTrgestiontableros_fechacreacion_filter_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int edtavConfirmmessage_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int tblTableconditionalconfirm_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_lastpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int tblPaginationbar_pagingcontainertablegrid_Visible ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV47GXV1 ;
      private int nGXsfl_110_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavEliminartablero_action_Enabled ;
      private int edtavEliminartablero_action_Visible ;
      private int edtavListatareas_action_Enabled ;
      private int edtavListatareas_action_Visible ;
      private int edtavCreartareas_action_Enabled ;
      private int edtavCreartareas_action_Visible ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_110_idx="0001" ;
      private String AV38GenericFilter_Grid ;
      private String AV39TrGestionTableros_Nombre_Filter ;
      private String AV43Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String AV27ConfirmationSubId ;
      private String AV33TrGestionTableros_Nombre ;
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
      private String divGridcomponent_grid_Internalname ;
      private String divGridcomponentcontent_grid_Internalname ;
      private String divLayoutdefined_grid_inner_grid_Internalname ;
      private String divLayoutdefined_table10_grid_Internalname ;
      private String divLayoutdefined_filterglobalcontainer_grid_Internalname ;
      private String divLayoutdefined_combinedfilterlayout_grid_Internalname ;
      private String divLayoutdefined_section4_grid_Internalname ;
      private String edtavGenericfilter_grid_Internalname ;
      private String TempTags ;
      private String edtavGenericfilter_grid_Jsonclick ;
      private String sImgUrl ;
      private String imgLayoutdefined_filtertoggle_combined_grid_Internalname ;
      private String imgLayoutdefined_filtertoggle_combined_grid_Jsonclick ;
      private String lblLayoutdefined_filtersummary_combined_grid_Internalname ;
      private String lblLayoutdefined_filtersummary_combined_grid_Caption ;
      private String lblLayoutdefined_filtersummary_combined_grid_Jsonclick ;
      private String divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname ;
      private String imgLayoutdefined_filterclose_combined_grid_Internalname ;
      private String imgLayoutdefined_filterclose_combined_grid_Jsonclick ;
      private String divMainfilterresponsivetable_filters_Internalname ;
      private String divFiltercontainertable_filters_Internalname ;
      private String divTable_container_trgestiontableros_nombre_filter_Internalname ;
      private String edtavTrgestiontableros_nombre_filter_Internalname ;
      private String edtavTrgestiontableros_nombre_filter_Jsonclick ;
      private String divTable_container_trgestiontableros_fechacreacion_filter_Internalname ;
      private String edtavTrgestiontableros_fechacreacion_filter_Internalname ;
      private String edtavTrgestiontableros_fechacreacion_filter_Jsonclick ;
      private String divLayoutdefined_table3_grid_Internalname ;
      private String divMaingrid_responsivetable_grid_Internalname ;
      private String sStyleString ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String subGrid_Header ;
      private String edtavEliminartablero_action_Tooltiptext ;
      private String edtavListatareas_action_Tooltiptext ;
      private String edtavCreartareas_action_Tooltiptext ;
      private String A2TrGestionTableros_Nombre ;
      private String edtTrGestionTableros_Nombre_Link ;
      private String divLayoutdefined_section8_grid_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavEliminartablero_action_Internalname ;
      private String edtavListatareas_action_Internalname ;
      private String edtavCreartareas_action_Internalname ;
      private String edtTrGestionTableros_ID_Internalname ;
      private String edtTrGestionTableros_Nombre_Internalname ;
      private String edtTrGestionTableros_FechaInicio_Internalname ;
      private String edtTrGestionTableros_FechaFin_Internalname ;
      private String edtTrGestionTableros_FechaCreacion_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_Internalname ;
      private String edtavConfirmmessage_Internalname ;
      private String scmdbuf ;
      private String lV39TrGestionTableros_Nombre_Filter ;
      private String lV38GenericFilter_Grid ;
      private String AV25ConfirmMessage ;
      private String tblTableconditionalconfirm_Internalname ;
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
      private String sGXsfl_110_fel_idx="0001" ;
      private String GXt_char1 ;
      private String tblSection_condconf_dialog_Internalname ;
      private String tblSection_condconf_dialog_inner_Internalname ;
      private String edtavConfirmmessage_Jsonclick ;
      private String tblConfirm_hidden_actionstable_Internalname ;
      private String bttI_buttonconfirmyes_Internalname ;
      private String bttI_buttonconfirmyes_Jsonclick ;
      private String bttI_buttonconfirmno_Internalname ;
      private String bttI_buttonconfirmno_Jsonclick ;
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
      private String bttGridsettings_savegrid_Internalname ;
      private String bttGridsettings_savegrid_Jsonclick ;
      private String tblGridsettings_tablecontentgrid_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_Jsonclick ;
      private String cmbavGridsettingsrowsperpage_grid_Jsonclick ;
      private String tblGridtitlecontainertable_grid_Internalname ;
      private String lblGridtitle_grid_Internalname ;
      private String lblGridtitle_grid_Jsonclick ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String bttCreartablero_Internalname ;
      private String bttCreartablero_Jsonclick ;
      private String edtavEliminartablero_action_Jsonclick ;
      private String edtavListatareas_action_Jsonclick ;
      private String edtavCreartareas_action_Jsonclick ;
      private String ROClassString ;
      private String edtTrGestionTableros_ID_Jsonclick ;
      private String edtTrGestionTableros_Nombre_Jsonclick ;
      private String edtTrGestionTableros_FechaInicio_Jsonclick ;
      private String edtTrGestionTableros_FechaFin_Jsonclick ;
      private String edtTrGestionTableros_FechaCreacion_Jsonclick ;
      private DateTime AV40TrGestionTableros_FechaCreacion_Filter ;
      private DateTime AV34TrGestionTableros_FechaInicio ;
      private DateTime AV35TrGestionTableros_FechaFin ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV26ConfirmationRequired ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_110_Refreshing=false ;
      private bool n2TrGestionTableros_Nombre ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV22EliminarTablero_Action_IsBlob ;
      private bool AV29ListaTareas_Action_IsBlob ;
      private bool AV30CrearTareas_Action_IsBlob ;
      private String AV44Eliminartablero_action_GXI ;
      private String AV45Listatareas_action_GXI ;
      private String AV46Creartareas_action_GXI ;
      private String AV12GridStateKey ;
      private String imgLayoutdefined_filtertoggle_combined_grid_Bitmap ;
      private String AV22EliminarTablero_Action ;
      private String AV29ListaTareas_Action ;
      private String AV30CrearTareas_Action ;
      private Guid AV28GridKey_TrGestionTableros_ID ;
      private Guid AV32Tableros_ID ;
      private Guid A1TrGestionTableros_ID ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H001N2_A7TrGestionTableros_FechaCreacion ;
      private bool[] H001N2_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] H001N2_A4TrGestionTableros_FechaFin ;
      private bool[] H001N2_n4TrGestionTableros_FechaFin ;
      private DateTime[] H001N2_A3TrGestionTableros_FechaInicio ;
      private bool[] H001N2_n3TrGestionTableros_FechaInicio ;
      private String[] H001N2_A2TrGestionTableros_Nombre ;
      private bool[] H001N2_n2TrGestionTableros_Nombre ;
      private Guid[] H001N2_A1TrGestionTableros_ID ;
      private long[] H001N3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV36K2BFilterValuesSDT_WebForm ;
      private GXWebForm Form ;
      private SdtK2BGridState AV13GridState ;
      private SdtK2BGridState_FilterValue AV14GridStateFilterValue ;
      private SdtCrearTablero_SDT AV24CrearTablero_SDT ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV37K2BFilterValuesSDTItem_WebForm ;
   }

   public class inicio__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001N2( IGxContext context ,
                                             String AV39TrGestionTableros_Nombre_Filter ,
                                             DateTime AV40TrGestionTableros_FechaCreacion_Filter ,
                                             String AV38GenericFilter_Grid ,
                                             String A2TrGestionTableros_Nombre ,
                                             DateTime A7TrGestionTableros_FechaCreacion )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int2 ;
         GXv_int2 = new short [6] ;
         Object[] GXv_Object3 ;
         GXv_Object3 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaInicio], [TrGestionTableros_Nombre], [TrGestionTableros_ID]";
         sFromString = " FROM TABLERO.[TrGestionTableros]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TrGestionTableros_Nombre_Filter)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([TrGestionTableros_Nombre] like @lV39TrGestionTableros_Nombre_Filter)";
            }
            else
            {
               sWhereString = sWhereString + " ([TrGestionTableros_Nombre] like @lV39TrGestionTableros_Nombre_Filter)";
            }
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV40TrGestionTableros_FechaCreacion_Filter) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([TrGestionTableros_FechaCreacion] = @AV40TrGestionTableros_FechaCreacion_Filter)";
            }
            else
            {
               sWhereString = sWhereString + " ([TrGestionTableros_FechaCreacion] = @AV40TrGestionTableros_FechaCreacion_Filter)";
            }
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38GenericFilter_Grid)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([TrGestionTableros_Nombre] like '%' + @lV38GenericFilter_Grid + '%')";
            }
            else
            {
               sWhereString = sWhereString + " ([TrGestionTableros_Nombre] like '%' + @lV38GenericFilter_Grid + '%')";
            }
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            sWhereString = " WHERE" + sWhereString;
         }
         sOrderString = sOrderString + " ORDER BY [TrGestionTableros_ID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H001N3( IGxContext context ,
                                             String AV39TrGestionTableros_Nombre_Filter ,
                                             DateTime AV40TrGestionTableros_FechaCreacion_Filter ,
                                             String AV38GenericFilter_Grid ,
                                             String A2TrGestionTableros_Nombre ,
                                             DateTime A7TrGestionTableros_FechaCreacion )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int4 ;
         GXv_int4 = new short [3] ;
         Object[] GXv_Object5 ;
         GXv_Object5 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM TABLERO.[TrGestionTableros]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TrGestionTableros_Nombre_Filter)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([TrGestionTableros_Nombre] like @lV39TrGestionTableros_Nombre_Filter)";
            }
            else
            {
               sWhereString = sWhereString + " ([TrGestionTableros_Nombre] like @lV39TrGestionTableros_Nombre_Filter)";
            }
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV40TrGestionTableros_FechaCreacion_Filter) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([TrGestionTableros_FechaCreacion] = @AV40TrGestionTableros_FechaCreacion_Filter)";
            }
            else
            {
               sWhereString = sWhereString + " ([TrGestionTableros_FechaCreacion] = @AV40TrGestionTableros_FechaCreacion_Filter)";
            }
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38GenericFilter_Grid)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([TrGestionTableros_Nombre] like '%' + @lV38GenericFilter_Grid + '%')";
            }
            else
            {
               sWhereString = sWhereString + " ([TrGestionTableros_Nombre] like '%' + @lV38GenericFilter_Grid + '%')";
            }
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE" + sWhereString;
         }
         scmdbuf = scmdbuf + "";
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
                     return conditional_H001N2(context, (String)dynConstraints[0] , (DateTime)dynConstraints[1] , (String)dynConstraints[2] , (String)dynConstraints[3] , (DateTime)dynConstraints[4] );
               case 1 :
                     return conditional_H001N3(context, (String)dynConstraints[0] , (DateTime)dynConstraints[1] , (String)dynConstraints[2] , (String)dynConstraints[3] , (DateTime)dynConstraints[4] );
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
          Object[] prmH001N2 ;
          prmH001N2 = new Object[] {
          new Object[] {"@lV39TrGestionTableros_Nombre_Filter",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV40TrGestionTableros_FechaCreacion_Filter",SqlDbType.DateTime,8,0} ,
          new Object[] {"@lV38GenericFilter_Grid",SqlDbType.NChar,100,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH001N3 ;
          prmH001N3 = new Object[] {
          new Object[] {"@lV39TrGestionTableros_Nombre_Filter",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV40TrGestionTableros_FechaCreacion_Filter",SqlDbType.DateTime,8,0} ,
          new Object[] {"@lV38GenericFilter_Grid",SqlDbType.NChar,100,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001N2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001N3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((String[]) buf[6])[0] = rslt.getString(4, 100) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((Guid[]) buf[8])[0] = rslt.getGuid(5) ;
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
                   stmt.SetParameter(sIdx, (String)parms[6]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[7]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[8]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[9]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[10]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[11]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[3]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[4]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[5]);
                }
                return;
       }
    }

 }

}
