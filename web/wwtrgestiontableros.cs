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
   public class wwtrgestiontableros : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwtrgestiontableros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wwtrgestiontableros( IGxContext context )
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
         chkavAtt_trgestiontableros_id_visible = new GXCheckbox();
         chkavAtt_trgestiontableros_nombre_visible = new GXCheckbox();
         chkavAtt_trgestiontableros_comentario_visible = new GXCheckbox();
         chkavAtt_trgestiontableros_descripcion_visible = new GXCheckbox();
         chkavAtt_trgestiontableros_tipotablero_visible = new GXCheckbox();
         chkavAtt_trgestiontableros_fechainicio_visible = new GXCheckbox();
         chkavAtt_trgestiontableros_fechafin_visible = new GXCheckbox();
         chkavAtt_trgestiontableros_fechacreacion_visible = new GXCheckbox();
         chkavAtt_trgestiontableros_fechamodificacion_visible = new GXCheckbox();
         chkavAtt_trgestiontableros_estado_visible = new GXCheckbox();
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
         cmbTrGestionTableros_Estado = new GXCombobox();
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
               nRC_GXsfl_136 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_136_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_136_idx = GetNextPar( );
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
               AV43OrderedBy = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV8CurrentPage = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV59Pgmname = GetNextPar( );
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridColumns);
               AV49TrGestionTableros_Nombre_IsAuthorized = StringUtil.StrToBool( GetNextPar( ));
               AV12Att_TrGestionTableros_ID_Visible = StringUtil.StrToBool( GetNextPar( ));
               AV13Att_TrGestionTableros_Nombre_Visible = StringUtil.StrToBool( GetNextPar( ));
               AV14Att_TrGestionTableros_Comentario_Visible = StringUtil.StrToBool( GetNextPar( ));
               AV15Att_TrGestionTableros_Descripcion_Visible = StringUtil.StrToBool( GetNextPar( ));
               AV16Att_TrGestionTableros_TipoTablero_Visible = StringUtil.StrToBool( GetNextPar( ));
               AV17Att_TrGestionTableros_FechaInicio_Visible = StringUtil.StrToBool( GetNextPar( ));
               AV18Att_TrGestionTableros_FechaFin_Visible = StringUtil.StrToBool( GetNextPar( ));
               AV19Att_TrGestionTableros_FechaCreacion_Visible = StringUtil.StrToBool( GetNextPar( ));
               AV56Att_TrGestionTableros_FechaModificacion_Visible = StringUtil.StrToBool( GetNextPar( ));
               AV21Att_TrGestionTableros_Estado_Visible = StringUtil.StrToBool( GetNextPar( ));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV43OrderedBy, AV8CurrentPage, AV59Pgmname, AV10GridColumns, AV49TrGestionTableros_Nombre_IsAuthorized, AV12Att_TrGestionTableros_ID_Visible, AV13Att_TrGestionTableros_Nombre_Visible, AV14Att_TrGestionTableros_Comentario_Visible, AV15Att_TrGestionTableros_Descripcion_Visible, AV16Att_TrGestionTableros_TipoTablero_Visible, AV17Att_TrGestionTableros_FechaInicio_Visible, AV18Att_TrGestionTableros_FechaFin_Visible, AV19Att_TrGestionTableros_FechaCreacion_Visible, AV56Att_TrGestionTableros_FechaModificacion_Visible, AV21Att_TrGestionTableros_Estado_Visible) ;
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
         PA1R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1R2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210201141877", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwtrgestiontableros.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_136", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_136), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV44GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV44GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCOLUMNS", AV10GridColumns);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCOLUMNS", AV10GridColumns);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED", AV49TrGestionTableros_Nombre_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "K2BORDERBYUSERCONTROL_Gridcontrolname", StringUtil.RTrim( K2borderbyusercontrol_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            WE1R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1R2( ) ;
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
         return formatLink("wwtrgestiontableros.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WWTrGestionTableros" ;
      }

      public override String GetPgmdesc( )
      {
         return "Nombre de tableroes" ;
      }

      protected void WB1R0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Nombre de tableroes", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WorkWithContentTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            wb_table1_25_1R2( true) ;
         }
         else
         {
            wb_table1_25_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_1R2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"136\">") ;
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
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(334), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTableros_ID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id tablero") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTableros_Nombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTableros_Comentario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Comentario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTableros_Descripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Descripción") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTableros_TipoTablero_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Tipo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTableros_FechaInicio_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTableros_FechaFin_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTableros_FechaCreacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha de creación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTrGestionTableros_FechaModificacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha de modificación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((cmbTrGestionTableros_Estado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
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
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1TrGestionTableros_ID.ToString());
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTableros_ID_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A2TrGestionTableros_Nombre));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTrGestionTableros_Nombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTableros_Nombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A6TrGestionTableros_Comentario);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTableros_Comentario_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A5TrGestionTableros_Descripcion);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTableros_Descripcion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTableros_TipoTablero_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTableros_FechaInicio_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTableros_FechaFin_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTableros_FechaCreacion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrGestionTableros_FechaModificacion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10TrGestionTableros_Estado), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbTrGestionTableros_Estado.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV50Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV51Delete));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 136 )
         {
            wbEnd = 0;
            nRC_GXsfl_136 = (int)(nGXsfl_136_idx-1);
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
            wb_table2_151_1R2( true) ;
         }
         else
         {
            wb_table2_151_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_151_1R2e( bool wbgen )
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
            wb_table3_161_1R2( true) ;
         }
         else
         {
            wb_table3_161_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table3_161_1R2e( bool wbgen )
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV44GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV46UC_OrderedBy);
            ucK2borderbyusercontrol.Render(context, "k2borderby", K2borderbyusercontrol_Internalname, "K2BORDERBYUSERCONTROLContainer");
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
         if ( wbEnd == 136 )
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

      protected void START1R2( )
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
            Form.Meta.addItem("description", "Nombre de tableroes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1R0( ) ;
      }

      protected void WS1R2( )
      {
         START1R2( ) ;
         EVT1R2( ) ;
      }

      protected void EVT1R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E111R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E121R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E141R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E151R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E161R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E171R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E181R2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_136_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_136_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_136_idx), 4, 0), 4, "0");
                              SubsflControlProps_1362( ) ;
                              A1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrGestionTableros_ID_Internalname)));
                              A2TrGestionTableros_Nombre = cgiGet( edtTrGestionTableros_Nombre_Internalname);
                              n2TrGestionTableros_Nombre = false;
                              A6TrGestionTableros_Comentario = cgiGet( edtTrGestionTableros_Comentario_Internalname);
                              n6TrGestionTableros_Comentario = false;
                              A5TrGestionTableros_Descripcion = cgiGet( edtTrGestionTableros_Descripcion_Internalname);
                              n5TrGestionTableros_Descripcion = false;
                              A9TrGestionTableros_TipoTablero = (short)(context.localUtil.CToN( cgiGet( edtTrGestionTableros_TipoTablero_Internalname), ".", ","));
                              n9TrGestionTableros_TipoTablero = false;
                              A3TrGestionTableros_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaInicio_Internalname), 0));
                              n3TrGestionTableros_FechaInicio = false;
                              A4TrGestionTableros_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaFin_Internalname), 0));
                              n4TrGestionTableros_FechaFin = false;
                              A7TrGestionTableros_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaCreacion_Internalname), 0));
                              n7TrGestionTableros_FechaCreacion = false;
                              A8TrGestionTableros_FechaModificacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTableros_FechaModificacion_Internalname), 0));
                              n8TrGestionTableros_FechaModificacion = false;
                              cmbTrGestionTableros_Estado.Name = cmbTrGestionTableros_Estado_Internalname;
                              cmbTrGestionTableros_Estado.CurrentValue = cgiGet( cmbTrGestionTableros_Estado_Internalname);
                              A10TrGestionTableros_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrGestionTableros_Estado_Internalname), "."));
                              n10TrGestionTableros_Estado = false;
                              AV50Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV61Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_136_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
                              AV51Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV62Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_136_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E191R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E201R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E211R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E221R2 ();
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

      protected void WE1R2( )
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

      protected void PA1R2( )
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
               GX_FocusControl = chkavAtt_trgestiontableros_id_visible_Internalname;
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
         SubsflControlProps_1362( ) ;
         while ( nGXsfl_136_idx <= nRC_GXsfl_136 )
         {
            sendrow_1362( ) ;
            nGXsfl_136_idx = ((subGrid_Islastpage==1)&&(nGXsfl_136_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_136_idx+1);
            sGXsfl_136_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_136_idx), 4, 0), 4, "0");
            SubsflControlProps_1362( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV43OrderedBy ,
                                       int AV8CurrentPage ,
                                       String AV59Pgmname ,
                                       GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ,
                                       bool AV49TrGestionTableros_Nombre_IsAuthorized ,
                                       bool AV12Att_TrGestionTableros_ID_Visible ,
                                       bool AV13Att_TrGestionTableros_Nombre_Visible ,
                                       bool AV14Att_TrGestionTableros_Comentario_Visible ,
                                       bool AV15Att_TrGestionTableros_Descripcion_Visible ,
                                       bool AV16Att_TrGestionTableros_TipoTablero_Visible ,
                                       bool AV17Att_TrGestionTableros_FechaInicio_Visible ,
                                       bool AV18Att_TrGestionTableros_FechaFin_Visible ,
                                       bool AV19Att_TrGestionTableros_FechaCreacion_Visible ,
                                       bool AV56Att_TrGestionTableros_FechaModificacion_Visible ,
                                       bool AV21Att_TrGestionTableros_Estado_Visible )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E201R2 ();
         GRID_nCurrentRecord = 0;
         RF1R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_ID", GetSecureSignedToken( "", A1TrGestionTableros_ID, context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTABLEROS_ID", A1TrGestionTableros_ID.ToString());
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
         AV12Att_TrGestionTableros_ID_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV12Att_TrGestionTableros_ID_Visible));
         AssignAttri("", false, "AV12Att_TrGestionTableros_ID_Visible", AV12Att_TrGestionTableros_ID_Visible);
         AV13Att_TrGestionTableros_Nombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV13Att_TrGestionTableros_Nombre_Visible));
         AssignAttri("", false, "AV13Att_TrGestionTableros_Nombre_Visible", AV13Att_TrGestionTableros_Nombre_Visible);
         AV14Att_TrGestionTableros_Comentario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_TrGestionTableros_Comentario_Visible));
         AssignAttri("", false, "AV14Att_TrGestionTableros_Comentario_Visible", AV14Att_TrGestionTableros_Comentario_Visible);
         AV15Att_TrGestionTableros_Descripcion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_TrGestionTableros_Descripcion_Visible));
         AssignAttri("", false, "AV15Att_TrGestionTableros_Descripcion_Visible", AV15Att_TrGestionTableros_Descripcion_Visible);
         AV16Att_TrGestionTableros_TipoTablero_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_TrGestionTableros_TipoTablero_Visible));
         AssignAttri("", false, "AV16Att_TrGestionTableros_TipoTablero_Visible", AV16Att_TrGestionTableros_TipoTablero_Visible);
         AV17Att_TrGestionTableros_FechaInicio_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_TrGestionTableros_FechaInicio_Visible));
         AssignAttri("", false, "AV17Att_TrGestionTableros_FechaInicio_Visible", AV17Att_TrGestionTableros_FechaInicio_Visible);
         AV18Att_TrGestionTableros_FechaFin_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_TrGestionTableros_FechaFin_Visible));
         AssignAttri("", false, "AV18Att_TrGestionTableros_FechaFin_Visible", AV18Att_TrGestionTableros_FechaFin_Visible);
         AV19Att_TrGestionTableros_FechaCreacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_TrGestionTableros_FechaCreacion_Visible));
         AssignAttri("", false, "AV19Att_TrGestionTableros_FechaCreacion_Visible", AV19Att_TrGestionTableros_FechaCreacion_Visible);
         AV56Att_TrGestionTableros_FechaModificacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV56Att_TrGestionTableros_FechaModificacion_Visible));
         AssignAttri("", false, "AV56Att_TrGestionTableros_FechaModificacion_Visible", AV56Att_TrGestionTableros_FechaModificacion_Visible);
         AV21Att_TrGestionTableros_Estado_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_TrGestionTableros_Estado_Visible));
         AssignAttri("", false, "AV21Att_TrGestionTableros_Estado_Visible", AV21Att_TrGestionTableros_Estado_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV22GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV22GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E201R2 ();
         RF1R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV59Pgmname = "WWTrGestionTableros";
         context.Gx_err = 0;
      }

      protected void RF1R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 136;
         E211R2 ();
         nGXsfl_136_idx = 1;
         sGXsfl_136_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_136_idx), 4, 0), 4, "0");
         SubsflControlProps_1362( ) ;
         bGXsfl_136_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_1362( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV43OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.SHORT
                                                 }
            } ) ;
            /* Using cursor H001R2 */
            pr_default.execute(0, new Object[] {GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_136_idx = 1;
            sGXsfl_136_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_136_idx), 4, 0), 4, "0");
            SubsflControlProps_1362( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A10TrGestionTableros_Estado = H001R2_A10TrGestionTableros_Estado[0];
               n10TrGestionTableros_Estado = H001R2_n10TrGestionTableros_Estado[0];
               A8TrGestionTableros_FechaModificacion = H001R2_A8TrGestionTableros_FechaModificacion[0];
               n8TrGestionTableros_FechaModificacion = H001R2_n8TrGestionTableros_FechaModificacion[0];
               A7TrGestionTableros_FechaCreacion = H001R2_A7TrGestionTableros_FechaCreacion[0];
               n7TrGestionTableros_FechaCreacion = H001R2_n7TrGestionTableros_FechaCreacion[0];
               A4TrGestionTableros_FechaFin = H001R2_A4TrGestionTableros_FechaFin[0];
               n4TrGestionTableros_FechaFin = H001R2_n4TrGestionTableros_FechaFin[0];
               A3TrGestionTableros_FechaInicio = H001R2_A3TrGestionTableros_FechaInicio[0];
               n3TrGestionTableros_FechaInicio = H001R2_n3TrGestionTableros_FechaInicio[0];
               A9TrGestionTableros_TipoTablero = H001R2_A9TrGestionTableros_TipoTablero[0];
               n9TrGestionTableros_TipoTablero = H001R2_n9TrGestionTableros_TipoTablero[0];
               A5TrGestionTableros_Descripcion = H001R2_A5TrGestionTableros_Descripcion[0];
               n5TrGestionTableros_Descripcion = H001R2_n5TrGestionTableros_Descripcion[0];
               A6TrGestionTableros_Comentario = H001R2_A6TrGestionTableros_Comentario[0];
               n6TrGestionTableros_Comentario = H001R2_n6TrGestionTableros_Comentario[0];
               A2TrGestionTableros_Nombre = H001R2_A2TrGestionTableros_Nombre[0];
               n2TrGestionTableros_Nombre = H001R2_n2TrGestionTableros_Nombre[0];
               A1TrGestionTableros_ID = (Guid)((Guid)(H001R2_A1TrGestionTableros_ID[0]));
               E221R2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 136;
            WB1R0( ) ;
         }
         bGXsfl_136_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTABLEROS_ID"+"_"+sGXsfl_136_idx, GetSecureSignedToken( sGXsfl_136_idx, A1TrGestionTableros_ID, context));
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
                                              AV43OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         } ) ;
         /* Using cursor H001R3 */
         pr_default.execute(1);
         GRID_nRecordCount = H001R3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV43OrderedBy, AV8CurrentPage, AV59Pgmname, AV10GridColumns, AV49TrGestionTableros_Nombre_IsAuthorized, AV12Att_TrGestionTableros_ID_Visible, AV13Att_TrGestionTableros_Nombre_Visible, AV14Att_TrGestionTableros_Comentario_Visible, AV15Att_TrGestionTableros_Descripcion_Visible, AV16Att_TrGestionTableros_TipoTablero_Visible, AV17Att_TrGestionTableros_FechaInicio_Visible, AV18Att_TrGestionTableros_FechaFin_Visible, AV19Att_TrGestionTableros_FechaCreacion_Visible, AV56Att_TrGestionTableros_FechaModificacion_Visible, AV21Att_TrGestionTableros_Estado_Visible) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV43OrderedBy, AV8CurrentPage, AV59Pgmname, AV10GridColumns, AV49TrGestionTableros_Nombre_IsAuthorized, AV12Att_TrGestionTableros_ID_Visible, AV13Att_TrGestionTableros_Nombre_Visible, AV14Att_TrGestionTableros_Comentario_Visible, AV15Att_TrGestionTableros_Descripcion_Visible, AV16Att_TrGestionTableros_TipoTablero_Visible, AV17Att_TrGestionTableros_FechaInicio_Visible, AV18Att_TrGestionTableros_FechaFin_Visible, AV19Att_TrGestionTableros_FechaCreacion_Visible, AV56Att_TrGestionTableros_FechaModificacion_Visible, AV21Att_TrGestionTableros_Estado_Visible) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV43OrderedBy, AV8CurrentPage, AV59Pgmname, AV10GridColumns, AV49TrGestionTableros_Nombre_IsAuthorized, AV12Att_TrGestionTableros_ID_Visible, AV13Att_TrGestionTableros_Nombre_Visible, AV14Att_TrGestionTableros_Comentario_Visible, AV15Att_TrGestionTableros_Descripcion_Visible, AV16Att_TrGestionTableros_TipoTablero_Visible, AV17Att_TrGestionTableros_FechaInicio_Visible, AV18Att_TrGestionTableros_FechaFin_Visible, AV19Att_TrGestionTableros_FechaCreacion_Visible, AV56Att_TrGestionTableros_FechaModificacion_Visible, AV21Att_TrGestionTableros_Estado_Visible) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV43OrderedBy, AV8CurrentPage, AV59Pgmname, AV10GridColumns, AV49TrGestionTableros_Nombre_IsAuthorized, AV12Att_TrGestionTableros_ID_Visible, AV13Att_TrGestionTableros_Nombre_Visible, AV14Att_TrGestionTableros_Comentario_Visible, AV15Att_TrGestionTableros_Descripcion_Visible, AV16Att_TrGestionTableros_TipoTablero_Visible, AV17Att_TrGestionTableros_FechaInicio_Visible, AV18Att_TrGestionTableros_FechaFin_Visible, AV19Att_TrGestionTableros_FechaCreacion_Visible, AV56Att_TrGestionTableros_FechaModificacion_Visible, AV21Att_TrGestionTableros_Estado_Visible) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV43OrderedBy, AV8CurrentPage, AV59Pgmname, AV10GridColumns, AV49TrGestionTableros_Nombre_IsAuthorized, AV12Att_TrGestionTableros_ID_Visible, AV13Att_TrGestionTableros_Nombre_Visible, AV14Att_TrGestionTableros_Comentario_Visible, AV15Att_TrGestionTableros_Descripcion_Visible, AV16Att_TrGestionTableros_TipoTablero_Visible, AV17Att_TrGestionTableros_FechaInicio_Visible, AV18Att_TrGestionTableros_FechaFin_Visible, AV19Att_TrGestionTableros_FechaCreacion_Visible, AV56Att_TrGestionTableros_FechaModificacion_Visible, AV21Att_TrGestionTableros_Estado_Visible) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV59Pgmname = "WWTrGestionTableros";
         context.Gx_err = 0;
      }

      protected void STRUP1R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E191R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV44GridOrders);
            /* Read saved values. */
            nRC_GXsfl_136 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_136"), ".", ","));
            AV46UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV43OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( "REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( "EXPORT_Visible"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV12Att_TrGestionTableros_ID_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_id_visible_Internalname));
            AssignAttri("", false, "AV12Att_TrGestionTableros_ID_Visible", AV12Att_TrGestionTableros_ID_Visible);
            AV13Att_TrGestionTableros_Nombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_nombre_visible_Internalname));
            AssignAttri("", false, "AV13Att_TrGestionTableros_Nombre_Visible", AV13Att_TrGestionTableros_Nombre_Visible);
            AV14Att_TrGestionTableros_Comentario_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_comentario_visible_Internalname));
            AssignAttri("", false, "AV14Att_TrGestionTableros_Comentario_Visible", AV14Att_TrGestionTableros_Comentario_Visible);
            AV15Att_TrGestionTableros_Descripcion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_descripcion_visible_Internalname));
            AssignAttri("", false, "AV15Att_TrGestionTableros_Descripcion_Visible", AV15Att_TrGestionTableros_Descripcion_Visible);
            AV16Att_TrGestionTableros_TipoTablero_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_tipotablero_visible_Internalname));
            AssignAttri("", false, "AV16Att_TrGestionTableros_TipoTablero_Visible", AV16Att_TrGestionTableros_TipoTablero_Visible);
            AV17Att_TrGestionTableros_FechaInicio_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_fechainicio_visible_Internalname));
            AssignAttri("", false, "AV17Att_TrGestionTableros_FechaInicio_Visible", AV17Att_TrGestionTableros_FechaInicio_Visible);
            AV18Att_TrGestionTableros_FechaFin_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_fechafin_visible_Internalname));
            AssignAttri("", false, "AV18Att_TrGestionTableros_FechaFin_Visible", AV18Att_TrGestionTableros_FechaFin_Visible);
            AV19Att_TrGestionTableros_FechaCreacion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_fechacreacion_visible_Internalname));
            AssignAttri("", false, "AV19Att_TrGestionTableros_FechaCreacion_Visible", AV19Att_TrGestionTableros_FechaCreacion_Visible);
            AV56Att_TrGestionTableros_FechaModificacion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_fechamodificacion_visible_Internalname));
            AssignAttri("", false, "AV56Att_TrGestionTableros_FechaModificacion_Visible", AV56Att_TrGestionTableros_FechaModificacion_Visible);
            AV21Att_TrGestionTableros_Estado_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trgestiontableros_estado_visible_Internalname));
            AssignAttri("", false, "AV21Att_TrGestionTableros_Estado_Visible", AV21Att_TrGestionTableros_Estado_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV22GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV22GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
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
         E191R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191R2( )
      {
         /* Start Routine */
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         new k2bloadrowsperpage(context ).execute(  AV59Pgmname,  "Grid", out  AV23RowsPerPageVariable, out  AV24RowsPerPageLoaded) ;
         if ( ! AV24RowsPerPageLoaded )
         {
            AV23RowsPerPageVariable = 20;
         }
         AV22GridSettingsRowsPerPageVariable = AV23RowsPerPageVariable;
         AssignAttri("", false, "AV22GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV23RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Nombre de tableroes";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         K2borderbyusercontrol_Gridcontrolname = subGrid_Internalname;
         ucK2borderbyusercontrol.SendProperty(context, "", false, K2borderbyusercontrol_Internalname, "GridControlName", K2borderbyusercontrol_Gridcontrolname);
         AV44GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "TABLEROS_WEB");
         AV45GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV45GridOrder.gxTpr_Ascendingorder = 0;
         AV45GridOrder.gxTpr_Descendingorder = 1;
         AV45GridOrder.gxTpr_Gridcolumnindex = 1;
         AV44GridOrders.Add(AV45GridOrder, 0);
      }

      protected void E201R2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         GXt_objcol_SdtMessages_Message1 = AV47Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV47Messages = GXt_objcol_SdtMessages_Message1;
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV47Messages.Count )
         {
            AV48Message = ((SdtMessages_Message)AV47Messages.Item(AV60GXV1));
            GX_msglist.addItem(AV48Message.gxTpr_Description);
            AV60GXV1 = (int)(AV60GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV59Pgmname;
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV54ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)) + "," + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)) + "," + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)) + "," + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)) + "," + UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname)));
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
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Insert";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV50Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV61Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_136_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
         AV61Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV61Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_136_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
         edtavUpdate_Tooltiptext = "Update";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_136_Refreshing);
         AV51Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV62Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_136_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
         AV62Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV62Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_136_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
         edtavDelete_Tooltiptext = "Delete";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_136_Refreshing);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
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
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridColumns", AV10GridColumns);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            AV25GridStateKey = "";
            new k2bloadgridstate(context ).execute(  AV59Pgmname,  AV25GridStateKey, out  AV26GridState) ;
            AV43OrderedBy = AV26GridState.gxTpr_Orderedby;
            AssignAttri("", false, "AV43OrderedBy", StringUtil.LTrimStr( (decimal)(AV43OrderedBy), 4, 0));
            AV46UC_OrderedBy = AV26GridState.gxTpr_Orderedby;
            AssignAttri("", false, "AV46UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV46UC_OrderedBy), 4, 0));
            if ( ( AV26GridState.gxTpr_Currentpage > 0 ) && ( AV26GridState.gxTpr_Currentpage <= subGrid_fnc_Pagecount( ) ) )
            {
               AV8CurrentPage = AV26GridState.gxTpr_Currentpage;
               AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
               subgrid_gotopage( AV8CurrentPage) ;
            }
         }
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         AV25GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV59Pgmname,  AV25GridStateKey, out  AV26GridState) ;
         AV26GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV26GridState.gxTpr_Orderedby = AV43OrderedBy;
         AV26GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV59Pgmname,  AV25GridStateKey,  AV26GridState) ;
      }

      protected void S182( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV52TrnContext = new SdtK2BTrnContext(context);
         AV52TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV52TrnContext.gxTpr_Returnmode = "Stack";
         AV52TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV52TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV52TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV52TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV52TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV52TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "TrGestionTableros",  AV52TrnContext) ;
      }

      protected void E111R2( )
      {
         /* 'DoInsert' Routine */
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "TrGestionTableros",  "TrGestionTableros",  "Insert",  "",  "EntityManagerTrGestionTableros") )
         {
            CallWebObject(formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(StringUtil.RTrim("")));
            context.wjLocDisableFrm = 1;
         }
         else
         {
         }
      }

      protected void E121R2( )
      {
         /* 'DoExport' Routine */
         CallWebObject(formatLink("exportwwtrgestiontableros.aspx") + "?" + UrlEncode("" +AV43OrderedBy));
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
         new k2bloadgridcolumns(context ).execute(  AV59Pgmname,  "Grid", ref  AV10GridColumns) ;
         edtTrGestionTableros_ID_Visible = 1;
         AssignProp("", false, edtTrGestionTableros_ID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_ID_Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV12Att_TrGestionTableros_ID_Visible = true;
         AssignAttri("", false, "AV12Att_TrGestionTableros_ID_Visible", AV12Att_TrGestionTableros_ID_Visible);
         edtTrGestionTableros_Nombre_Visible = 1;
         AssignProp("", false, edtTrGestionTableros_Nombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Nombre_Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV13Att_TrGestionTableros_Nombre_Visible = true;
         AssignAttri("", false, "AV13Att_TrGestionTableros_Nombre_Visible", AV13Att_TrGestionTableros_Nombre_Visible);
         edtTrGestionTableros_Comentario_Visible = 1;
         AssignProp("", false, edtTrGestionTableros_Comentario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Comentario_Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV14Att_TrGestionTableros_Comentario_Visible = true;
         AssignAttri("", false, "AV14Att_TrGestionTableros_Comentario_Visible", AV14Att_TrGestionTableros_Comentario_Visible);
         edtTrGestionTableros_Descripcion_Visible = 1;
         AssignProp("", false, edtTrGestionTableros_Descripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Descripcion_Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV15Att_TrGestionTableros_Descripcion_Visible = true;
         AssignAttri("", false, "AV15Att_TrGestionTableros_Descripcion_Visible", AV15Att_TrGestionTableros_Descripcion_Visible);
         edtTrGestionTableros_TipoTablero_Visible = 1;
         AssignProp("", false, edtTrGestionTableros_TipoTablero_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_TipoTablero_Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV16Att_TrGestionTableros_TipoTablero_Visible = true;
         AssignAttri("", false, "AV16Att_TrGestionTableros_TipoTablero_Visible", AV16Att_TrGestionTableros_TipoTablero_Visible);
         edtTrGestionTableros_FechaInicio_Visible = 1;
         AssignProp("", false, edtTrGestionTableros_FechaInicio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaInicio_Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV17Att_TrGestionTableros_FechaInicio_Visible = true;
         AssignAttri("", false, "AV17Att_TrGestionTableros_FechaInicio_Visible", AV17Att_TrGestionTableros_FechaInicio_Visible);
         edtTrGestionTableros_FechaFin_Visible = 1;
         AssignProp("", false, edtTrGestionTableros_FechaFin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaFin_Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV18Att_TrGestionTableros_FechaFin_Visible = true;
         AssignAttri("", false, "AV18Att_TrGestionTableros_FechaFin_Visible", AV18Att_TrGestionTableros_FechaFin_Visible);
         edtTrGestionTableros_FechaCreacion_Visible = 1;
         AssignProp("", false, edtTrGestionTableros_FechaCreacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaCreacion_Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV19Att_TrGestionTableros_FechaCreacion_Visible = true;
         AssignAttri("", false, "AV19Att_TrGestionTableros_FechaCreacion_Visible", AV19Att_TrGestionTableros_FechaCreacion_Visible);
         edtTrGestionTableros_FechaModificacion_Visible = 1;
         AssignProp("", false, edtTrGestionTableros_FechaModificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaModificacion_Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV56Att_TrGestionTableros_FechaModificacion_Visible = true;
         AssignAttri("", false, "AV56Att_TrGestionTableros_FechaModificacion_Visible", AV56Att_TrGestionTableros_FechaModificacion_Visible);
         cmbTrGestionTableros_Estado.Visible = 1;
         AssignProp("", false, cmbTrGestionTableros_Estado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbTrGestionTableros_Estado.Visible), 5, 0), !bGXsfl_136_Refreshing);
         AV21Att_TrGestionTableros_Estado_Visible = true;
         AssignAttri("", false, "AV21Att_TrGestionTableros_Estado_Visible", AV21Att_TrGestionTableros_Estado_Visible);
         new k2bsavegridcolumns(context ).execute(  AV59Pgmname,  "Grid",  AV10GridColumns,  false) ;
         AV63GXV2 = 1;
         while ( AV63GXV2 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV63GXV2));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_ID") == 0 )
               {
                  edtTrGestionTableros_ID_Visible = 0;
                  AssignProp("", false, edtTrGestionTableros_ID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_ID_Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV12Att_TrGestionTableros_ID_Visible = false;
                  AssignAttri("", false, "AV12Att_TrGestionTableros_ID_Visible", AV12Att_TrGestionTableros_ID_Visible);
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_Nombre") == 0 )
               {
                  edtTrGestionTableros_Nombre_Visible = 0;
                  AssignProp("", false, edtTrGestionTableros_Nombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Nombre_Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV13Att_TrGestionTableros_Nombre_Visible = false;
                  AssignAttri("", false, "AV13Att_TrGestionTableros_Nombre_Visible", AV13Att_TrGestionTableros_Nombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_Comentario") == 0 )
               {
                  edtTrGestionTableros_Comentario_Visible = 0;
                  AssignProp("", false, edtTrGestionTableros_Comentario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Comentario_Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV14Att_TrGestionTableros_Comentario_Visible = false;
                  AssignAttri("", false, "AV14Att_TrGestionTableros_Comentario_Visible", AV14Att_TrGestionTableros_Comentario_Visible);
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_Descripcion") == 0 )
               {
                  edtTrGestionTableros_Descripcion_Visible = 0;
                  AssignProp("", false, edtTrGestionTableros_Descripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Descripcion_Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV15Att_TrGestionTableros_Descripcion_Visible = false;
                  AssignAttri("", false, "AV15Att_TrGestionTableros_Descripcion_Visible", AV15Att_TrGestionTableros_Descripcion_Visible);
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_TipoTablero") == 0 )
               {
                  edtTrGestionTableros_TipoTablero_Visible = 0;
                  AssignProp("", false, edtTrGestionTableros_TipoTablero_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_TipoTablero_Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV16Att_TrGestionTableros_TipoTablero_Visible = false;
                  AssignAttri("", false, "AV16Att_TrGestionTableros_TipoTablero_Visible", AV16Att_TrGestionTableros_TipoTablero_Visible);
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaInicio") == 0 )
               {
                  edtTrGestionTableros_FechaInicio_Visible = 0;
                  AssignProp("", false, edtTrGestionTableros_FechaInicio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaInicio_Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV17Att_TrGestionTableros_FechaInicio_Visible = false;
                  AssignAttri("", false, "AV17Att_TrGestionTableros_FechaInicio_Visible", AV17Att_TrGestionTableros_FechaInicio_Visible);
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaFin") == 0 )
               {
                  edtTrGestionTableros_FechaFin_Visible = 0;
                  AssignProp("", false, edtTrGestionTableros_FechaFin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaFin_Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV18Att_TrGestionTableros_FechaFin_Visible = false;
                  AssignAttri("", false, "AV18Att_TrGestionTableros_FechaFin_Visible", AV18Att_TrGestionTableros_FechaFin_Visible);
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaCreacion") == 0 )
               {
                  edtTrGestionTableros_FechaCreacion_Visible = 0;
                  AssignProp("", false, edtTrGestionTableros_FechaCreacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaCreacion_Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV19Att_TrGestionTableros_FechaCreacion_Visible = false;
                  AssignAttri("", false, "AV19Att_TrGestionTableros_FechaCreacion_Visible", AV19Att_TrGestionTableros_FechaCreacion_Visible);
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaModificacion") == 0 )
               {
                  edtTrGestionTableros_FechaModificacion_Visible = 0;
                  AssignProp("", false, edtTrGestionTableros_FechaModificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaModificacion_Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV56Att_TrGestionTableros_FechaModificacion_Visible = false;
                  AssignAttri("", false, "AV56Att_TrGestionTableros_FechaModificacion_Visible", AV56Att_TrGestionTableros_FechaModificacion_Visible);
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_Estado") == 0 )
               {
                  cmbTrGestionTableros_Estado.Visible = 0;
                  AssignProp("", false, cmbTrGestionTableros_Estado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbTrGestionTableros_Estado.Visible), 5, 0), !bGXsfl_136_Refreshing);
                  AV21Att_TrGestionTableros_Estado_Visible = false;
                  AssignAttri("", false, "AV21Att_TrGestionTableros_Estado_Visible", AV21Att_TrGestionTableros_Estado_Visible);
               }
            }
            AV63GXV2 = (int)(AV63GXV2+1);
         }
      }

      protected void S172( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_ID";
         AV11GridColumn.gxTpr_Columntitle = "Id tablero";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_Nombre";
         AV11GridColumn.gxTpr_Columntitle = "Nombre ";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_Comentario";
         AV11GridColumn.gxTpr_Columntitle = "Comentario";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_Descripcion";
         AV11GridColumn.gxTpr_Columntitle = "Descripción";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_TipoTablero";
         AV11GridColumn.gxTpr_Columntitle = "Tipo";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_FechaInicio";
         AV11GridColumn.gxTpr_Columntitle = "Fecha inicio";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_FechaFin";
         AV11GridColumn.gxTpr_Columntitle = "Fecha fin";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_FechaCreacion";
         AV11GridColumn.gxTpr_Columntitle = "Fecha de creación";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_FechaModificacion";
         AV11GridColumn.gxTpr_Columntitle = "Fecha de modificación";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TrGestionTableros_Estado";
         AV11GridColumn.gxTpr_Columntitle = "Estado";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
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
         /* Execute user subroutine: 'DISPLAYINGRIDACTIONS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S192( )
      {
         /* 'DISPLAYPERSISTENTACTIONS' Routine */
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWTrGestionTableros";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWTrGestionTableros";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTrGestionTableros";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV54ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            bttInsert_Visible = 1;
            AssignProp("", false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
         else
         {
            bttInsert_Visible = 0;
            AssignProp("", false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTrGestionTableros";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTrGestionTableros";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TrGestionTableros";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTrGestionTableros";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV54ActivityList) ;
         AV49TrGestionTableros_Nombre_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV49TrGestionTableros_Nombre_IsAuthorized", AV49TrGestionTableros_Nombre_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_136_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_136_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_136_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_136_Refreshing);
         }
      }

      protected void S142( )
      {
         /* 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' Routine */
         if ( ( bttReport_Visible == 1 ) || ( bttExport_Visible == 1 ) )
         {
            divDownloadsactionssectioncontainer_Visible = 1;
            AssignProp("", false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
         else
         {
            divDownloadsactionssectioncontainer_Visible = 0;
            AssignProp("", false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
      }

      protected void E211R2( )
      {
         /* Grid_Refresh Routine */
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Insert";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV50Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV61Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_136_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
         AV61Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV61Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_136_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
         edtavUpdate_Tooltiptext = "Update";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_136_Refreshing);
         AV51Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV62Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_136_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
         AV62Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV62Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_136_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
         edtavDelete_Tooltiptext = "Delete";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_136_Refreshing);
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
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV46UC_OrderedBy = AV43OrderedBy;
         AssignAttri("", false, "AV46UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV46UC_OrderedBy), 4, 0));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridColumns", AV10GridColumns);
      }

      private void E221R2( )
      {
         /* Grid_Load Routine */
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV49TrGestionTableros_Nombre_IsAuthorized )
         {
            edtTrGestionTableros_Nombre_Link = formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(A1TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
         }
         else
         {
            edtTrGestionTableros_Nombre_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A1TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
         edtavUpdate_Tooltiptext = "Update";
         edtavUpdate_Enabled = 1;
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagertrgestiontableros.aspx") + "?" + UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A1TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
         edtavDelete_Tooltiptext = "Delete";
         edtavDelete_Enabled = 1;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 136;
         }
         sendrow_1362( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_136_Refreshing )
         {
            context.DoAjaxLoad(136, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E131R2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         AV43OrderedBy = AV46UC_OrderedBy;
         AssignAttri("", false, "AV43OrderedBy", StringUtil.LTrimStr( (decimal)(AV43OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV43OrderedBy, AV8CurrentPage, AV59Pgmname, AV10GridColumns, AV49TrGestionTableros_Nombre_IsAuthorized, AV12Att_TrGestionTableros_ID_Visible, AV13Att_TrGestionTableros_Nombre_Visible, AV14Att_TrGestionTableros_Comentario_Visible, AV15Att_TrGestionTableros_Descripcion_Visible, AV16Att_TrGestionTableros_TipoTablero_Visible, AV17Att_TrGestionTableros_FechaInicio_Visible, AV18Att_TrGestionTableros_FechaFin_Visible, AV19Att_TrGestionTableros_FechaCreacion_Visible, AV56Att_TrGestionTableros_FechaModificacion_Visible, AV21Att_TrGestionTableros_Estado_Visible) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridColumns", AV10GridColumns);
      }

      protected void E141R2( )
      {
         /* 'SaveGridSettings' Routine */
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridcolumns(context ).execute(  AV59Pgmname,  "Grid", ref  AV10GridColumns) ;
         AV64GXV3 = 1;
         while ( AV64GXV3 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV64GXV3));
            if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_ID") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV12Att_TrGestionTableros_ID_Visible;
            }
            else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_Nombre") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV13Att_TrGestionTableros_Nombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_Comentario") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV14Att_TrGestionTableros_Comentario_Visible;
            }
            else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_Descripcion") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV15Att_TrGestionTableros_Descripcion_Visible;
            }
            else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_TipoTablero") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV16Att_TrGestionTableros_TipoTablero_Visible;
            }
            else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaInicio") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV17Att_TrGestionTableros_FechaInicio_Visible;
            }
            else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaFin") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV18Att_TrGestionTableros_FechaFin_Visible;
            }
            else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaCreacion") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV19Att_TrGestionTableros_FechaCreacion_Visible;
            }
            else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaModificacion") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV56Att_TrGestionTableros_FechaModificacion_Visible;
            }
            else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TrGestionTableros_Estado") == 0 )
            {
               AV11GridColumn.gxTpr_Showattribute = AV21Att_TrGestionTableros_Estado_Visible;
            }
            AV64GXV3 = (int)(AV64GXV3+1);
         }
         new k2bsavegridcolumns(context ).execute(  AV59Pgmname,  "Grid",  AV10GridColumns,  true) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV46UC_OrderedBy = AV43OrderedBy;
         AssignAttri("", false, "AV46UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV46UC_OrderedBy), 4, 0));
         if ( subGrid_Rows != AV22GridSettingsRowsPerPageVariable )
         {
            AV23RowsPerPageVariable = AV22GridSettingsRowsPerPageVariable;
            subGrid_Rows = AV23RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV59Pgmname,  "Grid",  AV23RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV43OrderedBy, AV8CurrentPage, AV59Pgmname, AV10GridColumns, AV49TrGestionTableros_Nombre_IsAuthorized, AV12Att_TrGestionTableros_ID_Visible, AV13Att_TrGestionTableros_Nombre_Visible, AV14Att_TrGestionTableros_Comentario_Visible, AV15Att_TrGestionTableros_Descripcion_Visible, AV16Att_TrGestionTableros_TipoTablero_Visible, AV17Att_TrGestionTableros_FechaInicio_Visible, AV18Att_TrGestionTableros_FechaFin_Visible, AV19Att_TrGestionTableros_FechaCreacion_Visible, AV56Att_TrGestionTableros_FechaModificacion_Visible, AV21Att_TrGestionTableros_Estado_Visible) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridColumns", AV10GridColumns);
      }

      protected void S162( )
      {
         /* 'DISPLAYPAGINGBUTTONS' Routine */
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( AV8CurrentPage > AV9K2BMaxPages )
         {
            AV8CurrentPage = AV9K2BMaxPages;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_lastpage( ) ;
            context.DoAjaxRefresh();
         }
         if ( AV9K2BMaxPages == 0 )
         {
            AV8CurrentPage = 0;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         }
         else
         {
            AV8CurrentPage = subGrid_fnc_Currentpage( );
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         }
         lblFirstpagetextblock_Caption = "1";
         AssignProp("", false, lblFirstpagetextblock_Internalname, "Caption", lblFirstpagetextblock_Caption, true);
         lblPreviouspagetextblock_Caption = StringUtil.Str( (decimal)(AV8CurrentPage-1), 10, 0);
         AssignProp("", false, lblPreviouspagetextblock_Internalname, "Caption", lblPreviouspagetextblock_Caption, true);
         lblCurrentpagetextblock_Caption = StringUtil.Str( (decimal)(AV8CurrentPage), 5, 0);
         AssignProp("", false, lblCurrentpagetextblock_Internalname, "Caption", lblCurrentpagetextblock_Caption, true);
         lblNextpagetextblock_Caption = StringUtil.Str( (decimal)(AV8CurrentPage+1), 10, 0);
         AssignProp("", false, lblNextpagetextblock_Internalname, "Caption", lblNextpagetextblock_Caption, true);
         lblLastpagetextblock_Caption = StringUtil.Str( (decimal)(AV9K2BMaxPages), 6, 0);
         AssignProp("", false, lblLastpagetextblock_Internalname, "Caption", lblLastpagetextblock_Caption, true);
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
         if ( (0==AV8CurrentPage) || ( AV8CurrentPage <= 1 ) )
         {
            cellFirstpagecell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellFirstpagecell_Internalname, "Class", cellFirstpagecell_Class, true);
            lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
            lblFirstpagetextblock_Visible = 0;
            AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
            cellSpacingleftcell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellSpacingleftcell_Internalname, "Class", cellSpacingleftcell_Class, true);
            lblSpacinglefttextblock_Visible = 0;
            AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            cellPreviouspagecell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPreviouspagecell_Internalname, "Class", cellPreviouspagecell_Class, true);
            lblPreviouspagetextblock_Visible = 0;
            AssignProp("", false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
         }
         else
         {
            cellPreviouspagecell_Class = "K2BToolsCell_PaginationPrevious";
            AssignProp("", false, cellPreviouspagecell_Internalname, "Class", cellPreviouspagecell_Class, true);
            lblPreviouspagetextblock_Visible = 1;
            AssignProp("", false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
            if ( AV8CurrentPage == 2 )
            {
               cellFirstpagecell_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellFirstpagecell_Internalname, "Class", cellFirstpagecell_Class, true);
               lblFirstpagetextblock_Visible = 0;
               AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               cellSpacingleftcell_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellSpacingleftcell_Internalname, "Class", cellSpacingleftcell_Class, true);
               lblSpacinglefttextblock_Visible = 0;
               AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            }
            else
            {
               cellFirstpagecell_Class = "K2BToolsCell_PaginationLeft";
               AssignProp("", false, cellFirstpagecell_Internalname, "Class", cellFirstpagecell_Class, true);
               lblFirstpagetextblock_Visible = 1;
               AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               if ( AV8CurrentPage == 3 )
               {
                  cellSpacingleftcell_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellSpacingleftcell_Internalname, "Class", cellSpacingleftcell_Class, true);
                  lblSpacinglefttextblock_Visible = 0;
                  AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
               else
               {
                  cellSpacingleftcell_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
                  AssignProp("", false, cellSpacingleftcell_Internalname, "Class", cellSpacingleftcell_Class, true);
                  lblSpacinglefttextblock_Visible = 1;
                  AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( AV8CurrentPage == AV9K2BMaxPages )
         {
            cellLastpagecell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellLastpagecell_Internalname, "Class", cellLastpagecell_Class, true);
            lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
            lblLastpagetextblock_Visible = 0;
            AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
            cellSpacingrightcell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellSpacingrightcell_Internalname, "Class", cellSpacingrightcell_Class, true);
            lblSpacingrighttextblock_Visible = 0;
            AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            cellNextpagecell_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellNextpagecell_Internalname, "Class", cellNextpagecell_Class, true);
            lblNextpagetextblock_Visible = 0;
            AssignProp("", false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
         }
         else
         {
            cellNextpagecell_Class = "K2BToolsCell_PaginationNext";
            AssignProp("", false, cellNextpagecell_Internalname, "Class", cellNextpagecell_Class, true);
            lblNextpagetextblock_Visible = 1;
            AssignProp("", false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
            if ( AV8CurrentPage == AV9K2BMaxPages - 1 )
            {
               cellLastpagecell_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellLastpagecell_Internalname, "Class", cellLastpagecell_Class, true);
               lblLastpagetextblock_Visible = 0;
               AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               cellSpacingrightcell_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellSpacingrightcell_Internalname, "Class", cellSpacingrightcell_Class, true);
               lblSpacingrighttextblock_Visible = 0;
               AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            }
            else
            {
               cellLastpagecell_Class = "K2BToolsCell_PaginationRight";
               AssignProp("", false, cellLastpagecell_Internalname, "Class", cellLastpagecell_Class, true);
               lblLastpagetextblock_Visible = 1;
               AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               if ( AV8CurrentPage == AV9K2BMaxPages - 2 )
               {
                  cellSpacingrightcell_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellSpacingrightcell_Internalname, "Class", cellSpacingrightcell_Class, true);
                  lblSpacingrighttextblock_Visible = 0;
                  AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
               else
               {
                  cellSpacingrightcell_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
                  AssignProp("", false, cellSpacingrightcell_Internalname, "Class", cellSpacingrightcell_Class, true);
                  lblSpacingrighttextblock_Visible = 1;
                  AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV8CurrentPage <= 1 ) && ( AV9K2BMaxPages <= 1 ) )
         {
            tblK2btoolspagingcontainertable_Visible = 0;
            AssignProp("", false, tblK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
         else
         {
            tblK2btoolspagingcontainertable_Visible = 1;
            AssignProp("", false, tblK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
      }

      protected void E151R2( )
      {
         /* 'DoFirst' Routine */
         AV8CurrentPage = 1;
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridColumns", AV10GridColumns);
      }

      protected void E161R2( )
      {
         /* 'DoPrevious' Routine */
         if ( AV8CurrentPage > 1 )
         {
            AV8CurrentPage = (int)(AV8CurrentPage-1);
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridColumns", AV10GridColumns);
      }

      protected void E171R2( )
      {
         /* 'DoNext' Routine */
         if ( AV8CurrentPage != subGrid_fnc_Pagecount( ) )
         {
            AV8CurrentPage = (int)(AV8CurrentPage+1);
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridColumns", AV10GridColumns);
      }

      protected void E181R2( )
      {
         /* 'DoLast' Routine */
         AV8CurrentPage = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridColumns", AV10GridColumns);
      }

      protected void wb_table3_161_1R2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "&laquo;", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 1, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFirstpagecell_Internalname+"\"  class='"+cellFirstpagecell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellSpacingleftcell_Internalname+"\"  class='"+cellSpacingleftcell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPreviouspagecell_Internalname+"\"  class='"+cellPreviouspagecell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellCurrentpagecell_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellNextpagecell_Internalname+"\"  class='"+cellNextpagecell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellSpacingrightcell_Internalname+"\"  class='"+cellSpacingrightcell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellLastpagecell_Internalname+"\"  class='"+cellLastpagecell_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellNextpagebuttoncell_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "&raquo;", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 1, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_161_1R2e( true) ;
         }
         else
         {
            wb_table3_161_1R2e( false) ;
         }
      }

      protected void wb_table2_151_1R2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No results found", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_151_1R2e( true) ;
         }
         else
         {
            wb_table2_151_1R2e( false) ;
         }
      }

      protected void wb_table1_25_1R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable6_Internalname, tblTable6_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingstable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblK2bgridsettingslabel_Internalname, "", "", "", lblK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e231r1_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WWTrGestionTableros.htm");
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
            wb_table4_37_1R2( true) ;
         }
         else
         {
            wb_table4_37_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table4_37_1R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(136), 3, 0)+","+"null"+");", "Save", bttK2bgridsettingssave_Jsonclick, 5, "Save", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTrGestionTableros.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e241r1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWTrGestionTableros.htm");
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
            wb_table5_117_1R2( true) ;
         }
         else
         {
            wb_table5_117_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table5_117_1R2e( bool wbgen )
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
            context.WriteHtmlText( "<td>") ;
            wb_table6_124_1R2( true) ;
         }
         else
         {
            wb_table6_124_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table6_124_1R2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_1R2e( true) ;
         }
         else
         {
            wb_table1_25_1R2e( false) ;
         }
      }

      protected void wb_table6_124_1R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(136), 3, 0)+","+"null"+");", "Add new", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_124_1R2e( true) ;
         }
         else
         {
            wb_table6_124_1R2e( false) ;
         }
      }

      protected void wb_table5_117_1R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(136), 3, 0)+","+"null"+");", "Report", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e251r1_client"+"'", TempTags, "", 2, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(136), 3, 0)+","+"null"+");", "Export", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_117_1R2e( true) ;
         }
         else
         {
            wb_table5_117_1R2e( false) ;
         }
      }

      protected void wb_table4_37_1R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettingstable_content_Internalname, tblGridsettingstable_content_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_idruntimecolumnatt_Internalname, "Id tablero", "", "", lblTrgestiontableros_idruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_id_visible_Internalname, "Id tablero", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_id_visible_Internalname, StringUtil.BoolToStr( AV12Att_TrGestionTableros_ID_Visible), "", "Id tablero", 1, chkavAtt_trgestiontableros_id_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(43, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,43);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_nombreruntimecolumnatt_Internalname, "Nombre ", "", "", lblTrgestiontableros_nombreruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_nombre_visible_Internalname, "Nombre ", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_nombre_visible_Internalname, StringUtil.BoolToStr( AV13Att_TrGestionTableros_Nombre_Visible), "", "Nombre ", 1, chkavAtt_trgestiontableros_nombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_comentarioruntimecolumnatt_Internalname, "Comentario", "", "", lblTrgestiontableros_comentarioruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_comentario_visible_Internalname, "Comentario", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_comentario_visible_Internalname, StringUtil.BoolToStr( AV14Att_TrGestionTableros_Comentario_Visible), "", "Comentario", 1, chkavAtt_trgestiontableros_comentario_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(55, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,55);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_descripcionruntimecolumnatt_Internalname, "Descripción", "", "", lblTrgestiontableros_descripcionruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_descripcion_visible_Internalname, "Descripción", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_descripcion_visible_Internalname, StringUtil.BoolToStr( AV15Att_TrGestionTableros_Descripcion_Visible), "", "Descripción", 1, chkavAtt_trgestiontableros_descripcion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(61, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,61);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_tipotableroruntimecolumnatt_Internalname, "Tipo", "", "", lblTrgestiontableros_tipotableroruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_tipotablero_visible_Internalname, "Tipo", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_tipotablero_visible_Internalname, StringUtil.BoolToStr( AV16Att_TrGestionTableros_TipoTablero_Visible), "", "Tipo", 1, chkavAtt_trgestiontableros_tipotablero_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(67, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,67);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_fechainicioruntimecolumnatt_Internalname, "Fecha inicio", "", "", lblTrgestiontableros_fechainicioruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_fechainicio_visible_Internalname, "Fecha inicio", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_fechainicio_visible_Internalname, StringUtil.BoolToStr( AV17Att_TrGestionTableros_FechaInicio_Visible), "", "Fecha inicio", 1, chkavAtt_trgestiontableros_fechainicio_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(73, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,73);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_fechafinruntimecolumnatt_Internalname, "Fecha fin", "", "", lblTrgestiontableros_fechafinruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_fechafin_visible_Internalname, "Fecha fin", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_fechafin_visible_Internalname, StringUtil.BoolToStr( AV18Att_TrGestionTableros_FechaFin_Visible), "", "Fecha fin", 1, chkavAtt_trgestiontableros_fechafin_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_fechacreacionruntimecolumnatt_Internalname, "Fecha de creación", "", "", lblTrgestiontableros_fechacreacionruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_fechacreacion_visible_Internalname, "Fecha de creación", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_fechacreacion_visible_Internalname, StringUtil.BoolToStr( AV19Att_TrGestionTableros_FechaCreacion_Visible), "", "Fecha de creación", 1, chkavAtt_trgestiontableros_fechacreacion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(85, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,85);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_fechamodificacionruntimecolumnatt_Internalname, "Fecha de modificación", "", "", lblTrgestiontableros_fechamodificacionruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_fechamodificacion_visible_Internalname, "Fecha de modificación", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_fechamodificacion_visible_Internalname, StringUtil.BoolToStr( AV56Att_TrGestionTableros_FechaModificacion_Visible), "", "Fecha de modificación", 1, chkavAtt_trgestiontableros_fechamodificacion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(91, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,91);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_estadoruntimecolumnatt_Internalname, "Estado", "", "", lblTrgestiontableros_estadoruntimecolumnatt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trgestiontableros_estado_visible_Internalname, "Estado", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_136_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trgestiontableros_estado_visible_Internalname, StringUtil.BoolToStr( AV21Att_TrGestionTableros_Estado_Visible), "", "Estado", 1, chkavAtt_trgestiontableros_estado_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(97, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,97);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRowsperpagegrid_Internalname, "Rows per page", "", "", lblRowsperpagegrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WWTrGestionTableros.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpagevariable_Internalname, "GridSettingsRowsPerPageVariable", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_136_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Rows per page", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "", true, "HLP_WWTrGestionTableros.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", (String)(cmbavGridsettingsrowsperpagevariable.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_37_1R2e( true) ;
         }
         else
         {
            wb_table4_37_1R2e( false) ;
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
         PA1R2( ) ;
         WS1R2( ) ;
         WE1R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210201142095", true, true);
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
         context.AddJavascriptSource("wwtrgestiontableros.js", "?202210201142095", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1362( )
      {
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID_"+sGXsfl_136_idx;
         edtTrGestionTableros_Nombre_Internalname = "TRGESTIONTABLEROS_NOMBRE_"+sGXsfl_136_idx;
         edtTrGestionTableros_Comentario_Internalname = "TRGESTIONTABLEROS_COMENTARIO_"+sGXsfl_136_idx;
         edtTrGestionTableros_Descripcion_Internalname = "TRGESTIONTABLEROS_DESCRIPCION_"+sGXsfl_136_idx;
         edtTrGestionTableros_TipoTablero_Internalname = "TRGESTIONTABLEROS_TIPOTABLERO_"+sGXsfl_136_idx;
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO_"+sGXsfl_136_idx;
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN_"+sGXsfl_136_idx;
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION_"+sGXsfl_136_idx;
         edtTrGestionTableros_FechaModificacion_Internalname = "TRGESTIONTABLEROS_FECHAMODIFICACION_"+sGXsfl_136_idx;
         cmbTrGestionTableros_Estado_Internalname = "TRGESTIONTABLEROS_ESTADO_"+sGXsfl_136_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_136_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_136_idx;
      }

      protected void SubsflControlProps_fel_1362( )
      {
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID_"+sGXsfl_136_fel_idx;
         edtTrGestionTableros_Nombre_Internalname = "TRGESTIONTABLEROS_NOMBRE_"+sGXsfl_136_fel_idx;
         edtTrGestionTableros_Comentario_Internalname = "TRGESTIONTABLEROS_COMENTARIO_"+sGXsfl_136_fel_idx;
         edtTrGestionTableros_Descripcion_Internalname = "TRGESTIONTABLEROS_DESCRIPCION_"+sGXsfl_136_fel_idx;
         edtTrGestionTableros_TipoTablero_Internalname = "TRGESTIONTABLEROS_TIPOTABLERO_"+sGXsfl_136_fel_idx;
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO_"+sGXsfl_136_fel_idx;
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN_"+sGXsfl_136_fel_idx;
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION_"+sGXsfl_136_fel_idx;
         edtTrGestionTableros_FechaModificacion_Internalname = "TRGESTIONTABLEROS_FECHAMODIFICACION_"+sGXsfl_136_fel_idx;
         cmbTrGestionTableros_Estado_Internalname = "TRGESTIONTABLEROS_ESTADO_"+sGXsfl_136_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_136_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_136_fel_idx;
      }

      protected void sendrow_1362( )
      {
         SubsflControlProps_1362( ) ;
         WB1R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_136_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_136_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_136_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtTrGestionTableros_ID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_ID_Internalname,A1TrGestionTableros_ID.ToString(),A1TrGestionTableros_ID.ToString(),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTableros_ID_Visible,(short)0,(short)0,(String)"text",(String)"",(short)334,(String)"px",(short)17,(String)"px",(short)36,(short)0,(short)0,(short)136,(short)1,(short)0,(short)0,(bool)true,(String)"",(String)"",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtTrGestionTableros_Nombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_Nombre_Internalname,StringUtil.RTrim( A2TrGestionTableros_Nombre),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)edtTrGestionTableros_Nombre_Link,(String)"",(String)"",(String)"",(String)edtTrGestionTableros_Nombre_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn K2BToolsSortableColumn",(String)"",(int)edtTrGestionTableros_Nombre_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)136,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtTrGestionTableros_Comentario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_Comentario_Internalname,(String)A6TrGestionTableros_Comentario,(String)A6TrGestionTableros_Comentario,(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_Comentario_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTableros_Comentario_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)136,(short)1,(short)0,(short)-1,(bool)true,(String)"",(String)"left",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtTrGestionTableros_Descripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_Descripcion_Internalname,(String)A5TrGestionTableros_Descripcion,(String)A5TrGestionTableros_Descripcion,(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_Descripcion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTableros_Descripcion_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)136,(short)1,(short)0,(short)-1,(bool)true,(String)"",(String)"left",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTableros_TipoTablero_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_TipoTablero_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0, ".", "")),context.localUtil.Format( (decimal)(A9TrGestionTableros_TipoTablero), "ZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_TipoTablero_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTableros_TipoTablero_Visible,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)136,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTableros_FechaInicio_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaInicio_Internalname,context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"),context.localUtil.Format( A3TrGestionTableros_FechaInicio, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaInicio_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTableros_FechaInicio_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)136,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTableros_FechaFin_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaFin_Internalname,context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"),context.localUtil.Format( A4TrGestionTableros_FechaFin, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaFin_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTableros_FechaFin_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)136,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTableros_FechaCreacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaCreacion_Internalname,context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"),context.localUtil.Format( A7TrGestionTableros_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaCreacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTableros_FechaCreacion_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)136,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTrGestionTableros_FechaModificacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTableros_FechaModificacion_Internalname,context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"),context.localUtil.Format( A8TrGestionTableros_FechaModificacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTableros_FechaModificacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(int)edtTrGestionTableros_FechaModificacion_Visible,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)136,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((cmbTrGestionTableros_Estado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbTrGestionTableros_Estado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TRGESTIONTABLEROS_ESTADO_" + sGXsfl_136_idx;
               cmbTrGestionTableros_Estado.Name = GXCCtl;
               cmbTrGestionTableros_Estado.WebTags = "";
               cmbTrGestionTableros_Estado.addItem("1", "Activo", 0);
               cmbTrGestionTableros_Estado.addItem("2", "Inactivo", 0);
               if ( cmbTrGestionTableros_Estado.ItemCount > 0 )
               {
                  A10TrGestionTableros_Estado = (short)(NumberUtil.Val( cmbTrGestionTableros_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0))), "."));
                  n10TrGestionTableros_Estado = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTrGestionTableros_Estado,(String)cmbTrGestionTableros_Estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0)),(short)1,(String)cmbTrGestionTableros_Estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",cmbTrGestionTableros_Estado.Visible,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute_Grid",(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbTrGestionTableros_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0));
            AssignProp("", false, cmbTrGestionTableros_Estado_Internalname, "Values", (String)(cmbTrGestionTableros_Estado.ToJavascriptSource()), !bGXsfl_136_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV50Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV50Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV61Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV61Update_GXI : context.PathToRelativeUrl( AV50Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavUpdate_Internalname,(String)sImgUrl,(String)edtavUpdate_Link,(String)"",(String)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(String)"",(String)edtavUpdate_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV50Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV51Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV62Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV62Delete_GXI : context.PathToRelativeUrl( AV51Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavDelete_Internalname,(String)sImgUrl,(String)edtavDelete_Link,(String)"",(String)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(String)"",(String)edtavDelete_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV51Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes1R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_136_idx = ((subGrid_Islastpage==1)&&(nGXsfl_136_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_136_idx+1);
            sGXsfl_136_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_136_idx), 4, 0), 4, "0");
            SubsflControlProps_1362( ) ;
         }
         /* End function sendrow_1362 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_trgestiontableros_id_visible.Name = "vATT_TRGESTIONTABLEROS_ID_VISIBLE";
         chkavAtt_trgestiontableros_id_visible.WebTags = "";
         chkavAtt_trgestiontableros_id_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_id_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_id_visible.Caption, true);
         chkavAtt_trgestiontableros_id_visible.CheckedValue = "false";
         AV12Att_TrGestionTableros_ID_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV12Att_TrGestionTableros_ID_Visible));
         AssignAttri("", false, "AV12Att_TrGestionTableros_ID_Visible", AV12Att_TrGestionTableros_ID_Visible);
         chkavAtt_trgestiontableros_nombre_visible.Name = "vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE";
         chkavAtt_trgestiontableros_nombre_visible.WebTags = "";
         chkavAtt_trgestiontableros_nombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_nombre_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_nombre_visible.Caption, true);
         chkavAtt_trgestiontableros_nombre_visible.CheckedValue = "false";
         AV13Att_TrGestionTableros_Nombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV13Att_TrGestionTableros_Nombre_Visible));
         AssignAttri("", false, "AV13Att_TrGestionTableros_Nombre_Visible", AV13Att_TrGestionTableros_Nombre_Visible);
         chkavAtt_trgestiontableros_comentario_visible.Name = "vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE";
         chkavAtt_trgestiontableros_comentario_visible.WebTags = "";
         chkavAtt_trgestiontableros_comentario_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_comentario_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_comentario_visible.Caption, true);
         chkavAtt_trgestiontableros_comentario_visible.CheckedValue = "false";
         AV14Att_TrGestionTableros_Comentario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_TrGestionTableros_Comentario_Visible));
         AssignAttri("", false, "AV14Att_TrGestionTableros_Comentario_Visible", AV14Att_TrGestionTableros_Comentario_Visible);
         chkavAtt_trgestiontableros_descripcion_visible.Name = "vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE";
         chkavAtt_trgestiontableros_descripcion_visible.WebTags = "";
         chkavAtt_trgestiontableros_descripcion_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_descripcion_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_descripcion_visible.Caption, true);
         chkavAtt_trgestiontableros_descripcion_visible.CheckedValue = "false";
         AV15Att_TrGestionTableros_Descripcion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_TrGestionTableros_Descripcion_Visible));
         AssignAttri("", false, "AV15Att_TrGestionTableros_Descripcion_Visible", AV15Att_TrGestionTableros_Descripcion_Visible);
         chkavAtt_trgestiontableros_tipotablero_visible.Name = "vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE";
         chkavAtt_trgestiontableros_tipotablero_visible.WebTags = "";
         chkavAtt_trgestiontableros_tipotablero_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_tipotablero_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_tipotablero_visible.Caption, true);
         chkavAtt_trgestiontableros_tipotablero_visible.CheckedValue = "false";
         AV16Att_TrGestionTableros_TipoTablero_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_TrGestionTableros_TipoTablero_Visible));
         AssignAttri("", false, "AV16Att_TrGestionTableros_TipoTablero_Visible", AV16Att_TrGestionTableros_TipoTablero_Visible);
         chkavAtt_trgestiontableros_fechainicio_visible.Name = "vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE";
         chkavAtt_trgestiontableros_fechainicio_visible.WebTags = "";
         chkavAtt_trgestiontableros_fechainicio_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_fechainicio_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_fechainicio_visible.Caption, true);
         chkavAtt_trgestiontableros_fechainicio_visible.CheckedValue = "false";
         AV17Att_TrGestionTableros_FechaInicio_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_TrGestionTableros_FechaInicio_Visible));
         AssignAttri("", false, "AV17Att_TrGestionTableros_FechaInicio_Visible", AV17Att_TrGestionTableros_FechaInicio_Visible);
         chkavAtt_trgestiontableros_fechafin_visible.Name = "vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE";
         chkavAtt_trgestiontableros_fechafin_visible.WebTags = "";
         chkavAtt_trgestiontableros_fechafin_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_fechafin_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_fechafin_visible.Caption, true);
         chkavAtt_trgestiontableros_fechafin_visible.CheckedValue = "false";
         AV18Att_TrGestionTableros_FechaFin_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_TrGestionTableros_FechaFin_Visible));
         AssignAttri("", false, "AV18Att_TrGestionTableros_FechaFin_Visible", AV18Att_TrGestionTableros_FechaFin_Visible);
         chkavAtt_trgestiontableros_fechacreacion_visible.Name = "vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE";
         chkavAtt_trgestiontableros_fechacreacion_visible.WebTags = "";
         chkavAtt_trgestiontableros_fechacreacion_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_fechacreacion_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_fechacreacion_visible.Caption, true);
         chkavAtt_trgestiontableros_fechacreacion_visible.CheckedValue = "false";
         AV19Att_TrGestionTableros_FechaCreacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_TrGestionTableros_FechaCreacion_Visible));
         AssignAttri("", false, "AV19Att_TrGestionTableros_FechaCreacion_Visible", AV19Att_TrGestionTableros_FechaCreacion_Visible);
         chkavAtt_trgestiontableros_fechamodificacion_visible.Name = "vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE";
         chkavAtt_trgestiontableros_fechamodificacion_visible.WebTags = "";
         chkavAtt_trgestiontableros_fechamodificacion_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_fechamodificacion_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_fechamodificacion_visible.Caption, true);
         chkavAtt_trgestiontableros_fechamodificacion_visible.CheckedValue = "false";
         AV56Att_TrGestionTableros_FechaModificacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV56Att_TrGestionTableros_FechaModificacion_Visible));
         AssignAttri("", false, "AV56Att_TrGestionTableros_FechaModificacion_Visible", AV56Att_TrGestionTableros_FechaModificacion_Visible);
         chkavAtt_trgestiontableros_estado_visible.Name = "vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE";
         chkavAtt_trgestiontableros_estado_visible.WebTags = "";
         chkavAtt_trgestiontableros_estado_visible.Caption = "";
         AssignProp("", false, chkavAtt_trgestiontableros_estado_visible_Internalname, "TitleCaption", chkavAtt_trgestiontableros_estado_visible.Caption, true);
         chkavAtt_trgestiontableros_estado_visible.CheckedValue = "false";
         AV21Att_TrGestionTableros_Estado_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_TrGestionTableros_Estado_Visible));
         AssignAttri("", false, "AV21Att_TrGestionTableros_Estado_Visible", AV21Att_TrGestionTableros_Estado_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV22GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV22GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
         }
         GXCCtl = "TRGESTIONTABLEROS_ESTADO_" + sGXsfl_136_idx;
         cmbTrGestionTableros_Estado.Name = GXCCtl;
         cmbTrGestionTableros_Estado.WebTags = "";
         cmbTrGestionTableros_Estado.addItem("1", "Activo", 0);
         cmbTrGestionTableros_Estado.addItem("2", "Inactivo", 0);
         if ( cmbTrGestionTableros_Estado.ItemCount > 0 )
         {
            A10TrGestionTableros_Estado = (short)(NumberUtil.Val( cmbTrGestionTableros_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0))), "."));
            n10TrGestionTableros_Estado = false;
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblPgmdescriptortextblock_Internalname = "PGMDESCRIPTORTEXTBLOCK";
         divSection2_Internalname = "SECTION2";
         divTable3_Internalname = "TABLE3";
         lblK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblTrgestiontableros_idruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_IDRUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_id_visible_Internalname = "vATT_TRGESTIONTABLEROS_ID_VISIBLE";
         lblTrgestiontableros_nombreruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_NOMBRERUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_nombre_visible_Internalname = "vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE";
         lblTrgestiontableros_comentarioruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_COMENTARIORUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_comentario_visible_Internalname = "vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE";
         lblTrgestiontableros_descripcionruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_DESCRIPCIONRUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_descripcion_visible_Internalname = "vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE";
         lblTrgestiontableros_tipotableroruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_TIPOTABLERORUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_tipotablero_visible_Internalname = "vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE";
         lblTrgestiontableros_fechainicioruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_FECHAINICIORUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_fechainicio_visible_Internalname = "vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE";
         lblTrgestiontableros_fechafinruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_FECHAFINRUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_fechafin_visible_Internalname = "vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE";
         lblTrgestiontableros_fechacreacionruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_FECHACREACIONRUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_fechacreacion_visible_Internalname = "vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE";
         lblTrgestiontableros_fechamodificacionruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_FECHAMODIFICACIONRUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_fechamodificacion_visible_Internalname = "vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE";
         lblTrgestiontableros_estadoruntimecolumnatt_Internalname = "TRGESTIONTABLEROS_ESTADORUNTIMECOLUMNATT";
         chkavAtt_trgestiontableros_estado_visible_Internalname = "vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE";
         lblRowsperpagegrid_Internalname = "ROWSPERPAGEGRID";
         cmbavGridsettingsrowsperpagevariable_Internalname = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         tblGridsettingstable_content_Internalname = "GRIDSETTINGSTABLE_CONTENT";
         bttK2bgridsettingssave_Internalname = "K2BGRIDSETTINGSSAVE";
         divK2bgridsettingscontentoutertable_Internalname = "K2BGRIDSETTINGSCONTENTOUTERTABLE";
         divK2bgridsettingstable_Internalname = "K2BGRIDSETTINGSTABLE";
         imgImage1_Internalname = "IMAGE1";
         bttReport_Internalname = "REPORT";
         bttExport_Internalname = "EXPORT";
         tblK2btabledownloadssectioncontainer_Internalname = "K2BTABLEDOWNLOADSSECTIONCONTAINER";
         divDownloadactionstable_Internalname = "DOWNLOADACTIONSTABLE";
         divDownloadsactionssectioncontainer_Internalname = "DOWNLOADSACTIONSSECTIONCONTAINER";
         bttInsert_Internalname = "INSERT";
         tblK2btableactionsrightcontainer_Internalname = "K2BTABLEACTIONSRIGHTCONTAINER";
         tblTable6_Internalname = "TABLE6";
         divTable10_Internalname = "TABLE10";
         edtTrGestionTableros_ID_Internalname = "TRGESTIONTABLEROS_ID";
         edtTrGestionTableros_Nombre_Internalname = "TRGESTIONTABLEROS_NOMBRE";
         edtTrGestionTableros_Comentario_Internalname = "TRGESTIONTABLEROS_COMENTARIO";
         edtTrGestionTableros_Descripcion_Internalname = "TRGESTIONTABLEROS_DESCRIPCION";
         edtTrGestionTableros_TipoTablero_Internalname = "TRGESTIONTABLEROS_TIPOTABLERO";
         edtTrGestionTableros_FechaInicio_Internalname = "TRGESTIONTABLEROS_FECHAINICIO";
         edtTrGestionTableros_FechaFin_Internalname = "TRGESTIONTABLEROS_FECHAFIN";
         edtTrGestionTableros_FechaCreacion_Internalname = "TRGESTIONTABLEROS_FECHACREACION";
         edtTrGestionTableros_FechaModificacion_Internalname = "TRGESTIONTABLEROS_FECHAMODIFICACION";
         cmbTrGestionTableros_Estado_Internalname = "TRGESTIONTABLEROS_ESTADO";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         lblNoresultsfoundtextblock_Internalname = "NORESULTSFOUNDTEXTBLOCK";
         tblNoresultsfoundtable_Internalname = "NORESULTSFOUNDTABLE";
         divMaingridcontainergrid_Internalname = "MAINGRIDCONTAINERGRID";
         lblPreviouspagebuttontextblock_Internalname = "PREVIOUSPAGEBUTTONTEXTBLOCK";
         cellPreviouspagebuttoncell_Internalname = "PREVIOUSPAGEBUTTONCELL";
         lblFirstpagetextblock_Internalname = "FIRSTPAGETEXTBLOCK";
         cellFirstpagecell_Internalname = "FIRSTPAGECELL";
         lblSpacinglefttextblock_Internalname = "SPACINGLEFTTEXTBLOCK";
         cellSpacingleftcell_Internalname = "SPACINGLEFTCELL";
         lblPreviouspagetextblock_Internalname = "PREVIOUSPAGETEXTBLOCK";
         cellPreviouspagecell_Internalname = "PREVIOUSPAGECELL";
         lblCurrentpagetextblock_Internalname = "CURRENTPAGETEXTBLOCK";
         cellCurrentpagecell_Internalname = "CURRENTPAGECELL";
         lblNextpagetextblock_Internalname = "NEXTPAGETEXTBLOCK";
         cellNextpagecell_Internalname = "NEXTPAGECELL";
         lblSpacingrighttextblock_Internalname = "SPACINGRIGHTTEXTBLOCK";
         cellSpacingrightcell_Internalname = "SPACINGRIGHTCELL";
         lblLastpagetextblock_Internalname = "LASTPAGETEXTBLOCK";
         cellLastpagecell_Internalname = "LASTPAGECELL";
         lblNextpagebuttontextblock_Internalname = "NEXTPAGEBUTTONTEXTBLOCK";
         cellNextpagebuttoncell_Internalname = "NEXTPAGEBUTTONCELL";
         tblK2btoolspagingcontainertable_Internalname = "K2BTOOLSPAGINGCONTAINERTABLE";
         divSection8_Internalname = "SECTION8";
         divTable4_Internalname = "TABLE4";
         divGlobalgridtable_Internalname = "GLOBALGRIDTABLE";
         divTable7_Internalname = "TABLE7";
         divTable2_Internalname = "TABLE2";
         K2borderbyusercontrol_Internalname = "K2BORDERBYUSERCONTROL";
         divK2btoolsabstracthiddenitemsgrid_Internalname = "K2BTOOLSABSTRACTHIDDENITEMSGRID";
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
         chkavAtt_trgestiontableros_estado_visible.Caption = "Estado";
         chkavAtt_trgestiontableros_fechamodificacion_visible.Caption = "Fecha de modificación";
         chkavAtt_trgestiontableros_fechacreacion_visible.Caption = "Fecha de creación";
         chkavAtt_trgestiontableros_fechafin_visible.Caption = "Fecha fin";
         chkavAtt_trgestiontableros_fechainicio_visible.Caption = "Fecha inicio";
         chkavAtt_trgestiontableros_tipotablero_visible.Caption = "Tipo";
         chkavAtt_trgestiontableros_descripcion_visible.Caption = "Descripción";
         chkavAtt_trgestiontableros_comentario_visible.Caption = "Comentario";
         chkavAtt_trgestiontableros_nombre_visible.Caption = "Nombre ";
         chkavAtt_trgestiontableros_id_visible.Caption = "Id tablero";
         cmbTrGestionTableros_Estado_Jsonclick = "";
         edtTrGestionTableros_FechaModificacion_Jsonclick = "";
         edtTrGestionTableros_FechaCreacion_Jsonclick = "";
         edtTrGestionTableros_FechaFin_Jsonclick = "";
         edtTrGestionTableros_FechaInicio_Jsonclick = "";
         edtTrGestionTableros_TipoTablero_Jsonclick = "";
         edtTrGestionTableros_Descripcion_Jsonclick = "";
         edtTrGestionTableros_Comentario_Jsonclick = "";
         edtTrGestionTableros_Nombre_Jsonclick = "";
         edtTrGestionTableros_ID_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_trgestiontableros_estado_visible.Enabled = 1;
         chkavAtt_trgestiontableros_fechamodificacion_visible.Enabled = 1;
         chkavAtt_trgestiontableros_fechacreacion_visible.Enabled = 1;
         chkavAtt_trgestiontableros_fechafin_visible.Enabled = 1;
         chkavAtt_trgestiontableros_fechainicio_visible.Enabled = 1;
         chkavAtt_trgestiontableros_tipotablero_visible.Enabled = 1;
         chkavAtt_trgestiontableros_descripcion_visible.Enabled = 1;
         chkavAtt_trgestiontableros_comentario_visible.Enabled = 1;
         chkavAtt_trgestiontableros_nombre_visible.Enabled = 1;
         chkavAtt_trgestiontableros_id_visible.Enabled = 1;
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
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
         bttInsert_Tooltiptext = "Insert";
         bttExport_Tooltiptext = "";
         bttReport_Tooltiptext = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavDelete_Tooltiptext = "";
         edtavDelete_Link = "";
         edtavUpdate_Tooltiptext = "";
         edtavUpdate_Link = "";
         edtTrGestionTableros_Nombre_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Enabled = 1;
         edtavUpdate_Visible = -1;
         cmbTrGestionTableros_Estado.Visible = -1;
         edtTrGestionTableros_FechaModificacion_Visible = -1;
         edtTrGestionTableros_FechaCreacion_Visible = -1;
         edtTrGestionTableros_FechaFin_Visible = -1;
         edtTrGestionTableros_FechaInicio_Visible = -1;
         edtTrGestionTableros_TipoTablero_Visible = -1;
         edtTrGestionTableros_Descripcion_Visible = -1;
         edtTrGestionTableros_Comentario_Visible = -1;
         edtTrGestionTableros_Nombre_Visible = -1;
         edtTrGestionTableros_ID_Visible = -1;
         subGrid_Class = "Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Nombre de tableroes";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTableros_ID_Visible',ctrl:'TRGESTIONTABLEROS_ID',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Visible',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTableros_Comentario_Visible',ctrl:'TRGESTIONTABLEROS_COMENTARIO',prop:'Visible'},{av:'edtTrGestionTableros_Descripcion_Visible',ctrl:'TRGESTIONTABLEROS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTableros_TipoTablero_Visible',ctrl:'TRGESTIONTABLEROS_TIPOTABLERO',prop:'Visible'},{av:'edtTrGestionTableros_FechaInicio_Visible',ctrl:'TRGESTIONTABLEROS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTableros_FechaFin_Visible',ctrl:'TRGESTIONTABLEROS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTableros_FechaCreacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTableros_FechaModificacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACION',prop:'Visible'},{av:'cmbTrGestionTableros_Estado'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E111R2',iparms:[{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E121R2',iparms:[{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E251R1',iparms:[{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E211R2',iparms:[{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV46UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTableros_ID_Visible',ctrl:'TRGESTIONTABLEROS_ID',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Visible',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTableros_Comentario_Visible',ctrl:'TRGESTIONTABLEROS_COMENTARIO',prop:'Visible'},{av:'edtTrGestionTableros_Descripcion_Visible',ctrl:'TRGESTIONTABLEROS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTableros_TipoTablero_Visible',ctrl:'TRGESTIONTABLEROS_TIPOTABLERO',prop:'Visible'},{av:'edtTrGestionTableros_FechaInicio_Visible',ctrl:'TRGESTIONTABLEROS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTableros_FechaFin_Visible',ctrl:'TRGESTIONTABLEROS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTableros_FechaCreacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTableros_FechaModificacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACION',prop:'Visible'},{av:'cmbTrGestionTableros_Estado'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E221R2',iparms:[{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Link',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E131R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'AV46UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTableros_ID_Visible',ctrl:'TRGESTIONTABLEROS_ID',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Visible',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTableros_Comentario_Visible',ctrl:'TRGESTIONTABLEROS_COMENTARIO',prop:'Visible'},{av:'edtTrGestionTableros_Descripcion_Visible',ctrl:'TRGESTIONTABLEROS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTableros_TipoTablero_Visible',ctrl:'TRGESTIONTABLEROS_TIPOTABLERO',prop:'Visible'},{av:'edtTrGestionTableros_FechaInicio_Visible',ctrl:'TRGESTIONTABLEROS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTableros_FechaFin_Visible',ctrl:'TRGESTIONTABLEROS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTableros_FechaCreacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTableros_FechaModificacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACION',prop:'Visible'},{av:'cmbTrGestionTableros_Estado'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E231R1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E141R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV22GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV46UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'edtTrGestionTableros_ID_Visible',ctrl:'TRGESTIONTABLEROS_ID',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Visible',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTableros_Comentario_Visible',ctrl:'TRGESTIONTABLEROS_COMENTARIO',prop:'Visible'},{av:'edtTrGestionTableros_Descripcion_Visible',ctrl:'TRGESTIONTABLEROS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTableros_TipoTablero_Visible',ctrl:'TRGESTIONTABLEROS_TIPOTABLERO',prop:'Visible'},{av:'edtTrGestionTableros_FechaInicio_Visible',ctrl:'TRGESTIONTABLEROS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTableros_FechaFin_Visible',ctrl:'TRGESTIONTABLEROS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTableros_FechaCreacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTableros_FechaModificacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACION',prop:'Visible'},{av:'cmbTrGestionTableros_Estado'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E151R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTableros_ID_Visible',ctrl:'TRGESTIONTABLEROS_ID',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Visible',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTableros_Comentario_Visible',ctrl:'TRGESTIONTABLEROS_COMENTARIO',prop:'Visible'},{av:'edtTrGestionTableros_Descripcion_Visible',ctrl:'TRGESTIONTABLEROS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTableros_TipoTablero_Visible',ctrl:'TRGESTIONTABLEROS_TIPOTABLERO',prop:'Visible'},{av:'edtTrGestionTableros_FechaInicio_Visible',ctrl:'TRGESTIONTABLEROS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTableros_FechaFin_Visible',ctrl:'TRGESTIONTABLEROS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTableros_FechaCreacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTableros_FechaModificacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACION',prop:'Visible'},{av:'cmbTrGestionTableros_Estado'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E161R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTableros_ID_Visible',ctrl:'TRGESTIONTABLEROS_ID',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Visible',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTableros_Comentario_Visible',ctrl:'TRGESTIONTABLEROS_COMENTARIO',prop:'Visible'},{av:'edtTrGestionTableros_Descripcion_Visible',ctrl:'TRGESTIONTABLEROS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTableros_TipoTablero_Visible',ctrl:'TRGESTIONTABLEROS_TIPOTABLERO',prop:'Visible'},{av:'edtTrGestionTableros_FechaInicio_Visible',ctrl:'TRGESTIONTABLEROS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTableros_FechaFin_Visible',ctrl:'TRGESTIONTABLEROS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTableros_FechaCreacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTableros_FechaModificacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACION',prop:'Visible'},{av:'cmbTrGestionTableros_Estado'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E171R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTableros_ID_Visible',ctrl:'TRGESTIONTABLEROS_ID',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Visible',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTableros_Comentario_Visible',ctrl:'TRGESTIONTABLEROS_COMENTARIO',prop:'Visible'},{av:'edtTrGestionTableros_Descripcion_Visible',ctrl:'TRGESTIONTABLEROS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTableros_TipoTablero_Visible',ctrl:'TRGESTIONTABLEROS_TIPOTABLERO',prop:'Visible'},{av:'edtTrGestionTableros_FechaInicio_Visible',ctrl:'TRGESTIONTABLEROS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTableros_FechaFin_Visible',ctrl:'TRGESTIONTABLEROS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTableros_FechaCreacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTableros_FechaModificacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACION',prop:'Visible'},{av:'cmbTrGestionTableros_Estado'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E181R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'cellFirstpagecell_Class',ctrl:'FIRSTPAGECELL',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingleftcell_Class',ctrl:'SPACINGLEFTCELL',prop:'Class'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'cellPreviouspagecell_Class',ctrl:'PREVIOUSPAGECELL',prop:'Class'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'cellLastpagecell_Class',ctrl:'LASTPAGECELL',prop:'Class'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'cellSpacingrightcell_Class',ctrl:'SPACINGRIGHTCELL',prop:'Class'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'cellNextpagecell_Class',ctrl:'NEXTPAGECELL',prop:'Class'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'tblK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridColumns',fld:'vGRIDCOLUMNS',pic:''},{av:'edtTrGestionTableros_ID_Visible',ctrl:'TRGESTIONTABLEROS_ID',prop:'Visible'},{av:'edtTrGestionTableros_Nombre_Visible',ctrl:'TRGESTIONTABLEROS_NOMBRE',prop:'Visible'},{av:'edtTrGestionTableros_Comentario_Visible',ctrl:'TRGESTIONTABLEROS_COMENTARIO',prop:'Visible'},{av:'edtTrGestionTableros_Descripcion_Visible',ctrl:'TRGESTIONTABLEROS_DESCRIPCION',prop:'Visible'},{av:'edtTrGestionTableros_TipoTablero_Visible',ctrl:'TRGESTIONTABLEROS_TIPOTABLERO',prop:'Visible'},{av:'edtTrGestionTableros_FechaInicio_Visible',ctrl:'TRGESTIONTABLEROS_FECHAINICIO',prop:'Visible'},{av:'edtTrGestionTableros_FechaFin_Visible',ctrl:'TRGESTIONTABLEROS_FECHAFIN',prop:'Visible'},{av:'edtTrGestionTableros_FechaCreacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHACREACION',prop:'Visible'},{av:'edtTrGestionTableros_FechaModificacion_Visible',ctrl:'TRGESTIONTABLEROS_FECHAMODIFICACION',prop:'Visible'},{av:'cmbTrGestionTableros_Estado'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49TrGestionTableros_Nombre_IsAuthorized',fld:'vTRGESTIONTABLEROS_NOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E241R1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV12Att_TrGestionTableros_ID_Visible',fld:'vATT_TRGESTIONTABLEROS_ID_VISIBLE',pic:''},{av:'AV13Att_TrGestionTableros_Nombre_Visible',fld:'vATT_TRGESTIONTABLEROS_NOMBRE_VISIBLE',pic:''},{av:'AV14Att_TrGestionTableros_Comentario_Visible',fld:'vATT_TRGESTIONTABLEROS_COMENTARIO_VISIBLE',pic:''},{av:'AV15Att_TrGestionTableros_Descripcion_Visible',fld:'vATT_TRGESTIONTABLEROS_DESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_TrGestionTableros_TipoTablero_Visible',fld:'vATT_TRGESTIONTABLEROS_TIPOTABLERO_VISIBLE',pic:''},{av:'AV17Att_TrGestionTableros_FechaInicio_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAINICIO_VISIBLE',pic:''},{av:'AV18Att_TrGestionTableros_FechaFin_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAFIN_VISIBLE',pic:''},{av:'AV19Att_TrGestionTableros_FechaCreacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHACREACION_VISIBLE',pic:''},{av:'AV56Att_TrGestionTableros_FechaModificacion_Visible',fld:'vATT_TRGESTIONTABLEROS_FECHAMODIFICACION_VISIBLE',pic:''},{av:'AV21Att_TrGestionTableros_Estado_Visible',fld:'vATT_TRGESTIONTABLEROS_ESTADO_VISIBLE',pic:''}]}");
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
         AV59Pgmname = "";
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV44GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "TABLEROS_WEB");
         K2borderbyusercontrol_Gridcontrolname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblPgmdescriptortextblock_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A2TrGestionTableros_Nombre = "";
         A6TrGestionTableros_Comentario = "";
         A5TrGestionTableros_Descripcion = "";
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         AV50Update = "";
         AV51Delete = "";
         ucK2borderbyusercontrol = new GXUserControl();
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV61Update_GXI = "";
         AV62Delete_GXI = "";
         scmdbuf = "";
         H001R2_A10TrGestionTableros_Estado = new short[1] ;
         H001R2_n10TrGestionTableros_Estado = new bool[] {false} ;
         H001R2_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         H001R2_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         H001R2_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H001R2_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         H001R2_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H001R2_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         H001R2_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H001R2_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         H001R2_A9TrGestionTableros_TipoTablero = new short[1] ;
         H001R2_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         H001R2_A5TrGestionTableros_Descripcion = new String[] {""} ;
         H001R2_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         H001R2_A6TrGestionTableros_Comentario = new String[] {""} ;
         H001R2_n6TrGestionTableros_Comentario = new bool[] {false} ;
         H001R2_A2TrGestionTableros_Nombre = new String[] {""} ;
         H001R2_n2TrGestionTableros_Nombre = new bool[] {false} ;
         H001R2_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         H001R3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV45GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV47Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV48Message = new SdtMessages_Message(context);
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV25GridStateKey = "";
         AV26GridState = new SdtK2BGridState(context);
         AV52TrnContext = new SdtK2BTrnContext(context);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
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
         bttInsert_Jsonclick = "";
         bttReport_Jsonclick = "";
         bttExport_Jsonclick = "";
         lblTrgestiontableros_idruntimecolumnatt_Jsonclick = "";
         lblTrgestiontableros_nombreruntimecolumnatt_Jsonclick = "";
         lblTrgestiontableros_comentarioruntimecolumnatt_Jsonclick = "";
         lblTrgestiontableros_descripcionruntimecolumnatt_Jsonclick = "";
         lblTrgestiontableros_tipotableroruntimecolumnatt_Jsonclick = "";
         lblTrgestiontableros_fechainicioruntimecolumnatt_Jsonclick = "";
         lblTrgestiontableros_fechafinruntimecolumnatt_Jsonclick = "";
         lblTrgestiontableros_fechacreacionruntimecolumnatt_Jsonclick = "";
         lblTrgestiontableros_fechamodificacionruntimecolumnatt_Jsonclick = "";
         lblTrgestiontableros_estadoruntimecolumnatt_Jsonclick = "";
         lblRowsperpagegrid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwtrgestiontableros__default(),
            new Object[][] {
                new Object[] {
               H001R2_A10TrGestionTableros_Estado, H001R2_n10TrGestionTableros_Estado, H001R2_A8TrGestionTableros_FechaModificacion, H001R2_n8TrGestionTableros_FechaModificacion, H001R2_A7TrGestionTableros_FechaCreacion, H001R2_n7TrGestionTableros_FechaCreacion, H001R2_A4TrGestionTableros_FechaFin, H001R2_n4TrGestionTableros_FechaFin, H001R2_A3TrGestionTableros_FechaInicio, H001R2_n3TrGestionTableros_FechaInicio,
               H001R2_A9TrGestionTableros_TipoTablero, H001R2_n9TrGestionTableros_TipoTablero, H001R2_A5TrGestionTableros_Descripcion, H001R2_n5TrGestionTableros_Descripcion, H001R2_A6TrGestionTableros_Comentario, H001R2_n6TrGestionTableros_Comentario, H001R2_A2TrGestionTableros_Nombre, H001R2_n2TrGestionTableros_Nombre, H001R2_A1TrGestionTableros_ID
               }
               , new Object[] {
               H001R3_AGRID_nRecordCount
               }
            }
         );
         AV59Pgmname = "WWTrGestionTableros";
         /* GeneXus formulas. */
         AV59Pgmname = "WWTrGestionTableros";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV43OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV46UC_OrderedBy ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A9TrGestionTableros_TipoTablero ;
      private short A10TrGestionTableros_Estado ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV22GridSettingsRowsPerPageVariable ;
      private short AV23RowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int subGrid_Rows ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_136 ;
      private int nGXsfl_136_idx=1 ;
      private int AV8CurrentPage ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtTrGestionTableros_ID_Visible ;
      private int edtTrGestionTableros_Nombre_Visible ;
      private int edtTrGestionTableros_Comentario_Visible ;
      private int edtTrGestionTableros_Descripcion_Visible ;
      private int edtTrGestionTableros_TipoTablero_Visible ;
      private int edtTrGestionTableros_FechaInicio_Visible ;
      private int edtTrGestionTableros_FechaFin_Visible ;
      private int edtTrGestionTableros_FechaCreacion_Visible ;
      private int edtTrGestionTableros_FechaModificacion_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV60GXV1 ;
      private int AV63GXV2 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV64GXV3 ;
      private int AV9K2BMaxPages ;
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
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_136_idx="0001" ;
      private String AV59Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String K2borderbyusercontrol_Gridcontrolname ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable3_Internalname ;
      private String divSection2_Internalname ;
      private String lblPgmdescriptortextblock_Internalname ;
      private String lblPgmdescriptortextblock_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String divTable2_Internalname ;
      private String divTable7_Internalname ;
      private String divTable10_Internalname ;
      private String divGlobalgridtable_Internalname ;
      private String divMaingridcontainergrid_Internalname ;
      private String sStyleString ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String subGrid_Header ;
      private String A2TrGestionTableros_Nombre ;
      private String edtTrGestionTableros_Nombre_Link ;
      private String edtavUpdate_Link ;
      private String edtavUpdate_Tooltiptext ;
      private String edtavDelete_Link ;
      private String edtavDelete_Tooltiptext ;
      private String divTable4_Internalname ;
      private String divSection8_Internalname ;
      private String divK2btoolsabstracthiddenitemsgrid_Internalname ;
      private String K2borderbyusercontrol_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtTrGestionTableros_ID_Internalname ;
      private String edtTrGestionTableros_Nombre_Internalname ;
      private String edtTrGestionTableros_Comentario_Internalname ;
      private String edtTrGestionTableros_Descripcion_Internalname ;
      private String edtTrGestionTableros_TipoTablero_Internalname ;
      private String edtTrGestionTableros_FechaInicio_Internalname ;
      private String edtTrGestionTableros_FechaFin_Internalname ;
      private String edtTrGestionTableros_FechaCreacion_Internalname ;
      private String edtTrGestionTableros_FechaModificacion_Internalname ;
      private String cmbTrGestionTableros_Estado_Internalname ;
      private String edtavUpdate_Internalname ;
      private String edtavDelete_Internalname ;
      private String chkavAtt_trgestiontableros_id_visible_Internalname ;
      private String cmbavGridsettingsrowsperpagevariable_Internalname ;
      private String scmdbuf ;
      private String chkavAtt_trgestiontableros_nombre_visible_Internalname ;
      private String chkavAtt_trgestiontableros_comentario_visible_Internalname ;
      private String chkavAtt_trgestiontableros_descripcion_visible_Internalname ;
      private String chkavAtt_trgestiontableros_tipotablero_visible_Internalname ;
      private String chkavAtt_trgestiontableros_fechainicio_visible_Internalname ;
      private String chkavAtt_trgestiontableros_fechafin_visible_Internalname ;
      private String chkavAtt_trgestiontableros_fechacreacion_visible_Internalname ;
      private String chkavAtt_trgestiontableros_fechamodificacion_visible_Internalname ;
      private String chkavAtt_trgestiontableros_estado_visible_Internalname ;
      private String divDownloadactionstable_Internalname ;
      private String bttReport_Tooltiptext ;
      private String bttReport_Internalname ;
      private String bttExport_Tooltiptext ;
      private String bttExport_Internalname ;
      private String bttInsert_Tooltiptext ;
      private String bttInsert_Internalname ;
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
      private String tblTable6_Internalname ;
      private String divK2bgridsettingstable_Internalname ;
      private String lblK2bgridsettingslabel_Internalname ;
      private String lblK2bgridsettingslabel_Jsonclick ;
      private String TempTags ;
      private String bttK2bgridsettingssave_Internalname ;
      private String bttK2bgridsettingssave_Jsonclick ;
      private String sImgUrl ;
      private String imgImage1_Internalname ;
      private String imgImage1_Jsonclick ;
      private String tblK2btableactionsrightcontainer_Internalname ;
      private String bttInsert_Jsonclick ;
      private String tblK2btabledownloadssectioncontainer_Internalname ;
      private String bttReport_Jsonclick ;
      private String bttExport_Jsonclick ;
      private String tblGridsettingstable_content_Internalname ;
      private String lblTrgestiontableros_idruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_idruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontableros_nombreruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_nombreruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontableros_comentarioruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_comentarioruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontableros_descripcionruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_descripcionruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontableros_tipotableroruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_tipotableroruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontableros_fechainicioruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_fechainicioruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontableros_fechafinruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_fechafinruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontableros_fechacreacionruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_fechacreacionruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontableros_fechamodificacionruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_fechamodificacionruntimecolumnatt_Jsonclick ;
      private String lblTrgestiontableros_estadoruntimecolumnatt_Internalname ;
      private String lblTrgestiontableros_estadoruntimecolumnatt_Jsonclick ;
      private String lblRowsperpagegrid_Internalname ;
      private String lblRowsperpagegrid_Jsonclick ;
      private String cmbavGridsettingsrowsperpagevariable_Jsonclick ;
      private String sGXsfl_136_fel_idx="0001" ;
      private String ROClassString ;
      private String edtTrGestionTableros_ID_Jsonclick ;
      private String edtTrGestionTableros_Nombre_Jsonclick ;
      private String edtTrGestionTableros_Comentario_Jsonclick ;
      private String edtTrGestionTableros_Descripcion_Jsonclick ;
      private String edtTrGestionTableros_TipoTablero_Jsonclick ;
      private String edtTrGestionTableros_FechaInicio_Jsonclick ;
      private String edtTrGestionTableros_FechaFin_Jsonclick ;
      private String edtTrGestionTableros_FechaCreacion_Jsonclick ;
      private String edtTrGestionTableros_FechaModificacion_Jsonclick ;
      private String GXCCtl ;
      private String cmbTrGestionTableros_Estado_Jsonclick ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private DateTime A8TrGestionTableros_FechaModificacion ;
      private bool entryPointCalled ;
      private bool AV49TrGestionTableros_Nombre_IsAuthorized ;
      private bool AV12Att_TrGestionTableros_ID_Visible ;
      private bool AV13Att_TrGestionTableros_Nombre_Visible ;
      private bool AV14Att_TrGestionTableros_Comentario_Visible ;
      private bool AV15Att_TrGestionTableros_Descripcion_Visible ;
      private bool AV16Att_TrGestionTableros_TipoTablero_Visible ;
      private bool AV17Att_TrGestionTableros_FechaInicio_Visible ;
      private bool AV18Att_TrGestionTableros_FechaFin_Visible ;
      private bool AV19Att_TrGestionTableros_FechaCreacion_Visible ;
      private bool AV56Att_TrGestionTableros_FechaModificacion_Visible ;
      private bool AV21Att_TrGestionTableros_Estado_Visible ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n2TrGestionTableros_Nombre ;
      private bool n6TrGestionTableros_Comentario ;
      private bool n5TrGestionTableros_Descripcion ;
      private bool n9TrGestionTableros_TipoTablero ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n8TrGestionTableros_FechaModificacion ;
      private bool n10TrGestionTableros_Estado ;
      private bool bGXsfl_136_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV24RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV50Update_IsBlob ;
      private bool AV51Delete_IsBlob ;
      private String A6TrGestionTableros_Comentario ;
      private String A5TrGestionTableros_Descripcion ;
      private String AV61Update_GXI ;
      private String AV62Delete_GXI ;
      private String AV25GridStateKey ;
      private String AV50Update ;
      private String AV51Delete ;
      private Guid A1TrGestionTableros_ID ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_trgestiontableros_id_visible ;
      private GXCheckbox chkavAtt_trgestiontableros_nombre_visible ;
      private GXCheckbox chkavAtt_trgestiontableros_comentario_visible ;
      private GXCheckbox chkavAtt_trgestiontableros_descripcion_visible ;
      private GXCheckbox chkavAtt_trgestiontableros_tipotablero_visible ;
      private GXCheckbox chkavAtt_trgestiontableros_fechainicio_visible ;
      private GXCheckbox chkavAtt_trgestiontableros_fechafin_visible ;
      private GXCheckbox chkavAtt_trgestiontableros_fechacreacion_visible ;
      private GXCheckbox chkavAtt_trgestiontableros_fechamodificacion_visible ;
      private GXCheckbox chkavAtt_trgestiontableros_estado_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCombobox cmbTrGestionTableros_Estado ;
      private IDataStoreProvider pr_default ;
      private short[] H001R2_A10TrGestionTableros_Estado ;
      private bool[] H001R2_n10TrGestionTableros_Estado ;
      private DateTime[] H001R2_A8TrGestionTableros_FechaModificacion ;
      private bool[] H001R2_n8TrGestionTableros_FechaModificacion ;
      private DateTime[] H001R2_A7TrGestionTableros_FechaCreacion ;
      private bool[] H001R2_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] H001R2_A4TrGestionTableros_FechaFin ;
      private bool[] H001R2_n4TrGestionTableros_FechaFin ;
      private DateTime[] H001R2_A3TrGestionTableros_FechaInicio ;
      private bool[] H001R2_n3TrGestionTableros_FechaInicio ;
      private short[] H001R2_A9TrGestionTableros_TipoTablero ;
      private bool[] H001R2_n9TrGestionTableros_TipoTablero ;
      private String[] H001R2_A5TrGestionTableros_Descripcion ;
      private bool[] H001R2_n5TrGestionTableros_Descripcion ;
      private String[] H001R2_A6TrGestionTableros_Comentario ;
      private bool[] H001R2_n6TrGestionTableros_Comentario ;
      private String[] H001R2_A2TrGestionTableros_Nombre ;
      private bool[] H001R2_n2TrGestionTableros_Nombre ;
      private Guid[] H001R2_A1TrGestionTableros_ID ;
      private long[] H001R3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV44GridOrders ;
      private GXBaseCollection<SdtMessages_Message> AV47Messages ;
      private GXBaseCollection<SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV54ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BGridState AV26GridState ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV45GridOrder ;
      private SdtMessages_Message AV48Message ;
      private SdtK2BTrnContext AV52TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV55ActivityListItem ;
   }

   public class wwtrgestiontableros__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001R2( IGxContext context ,
                                             short AV43OrderedBy )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int2 ;
         GXv_int2 = new short [3] ;
         Object[] GXv_Object3 ;
         GXv_Object3 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [TrGestionTableros_Estado], [TrGestionTableros_FechaModificacion], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaInicio], [TrGestionTableros_TipoTablero], [TrGestionTableros_Descripcion], [TrGestionTableros_Comentario], [TrGestionTableros_Nombre], [TrGestionTableros_ID]";
         sFromString = " FROM TABLERO.[TrGestionTableros]";
         sOrderString = "";
         if ( AV43OrderedBy == 0 )
         {
            sOrderString = sOrderString + " ORDER BY [TrGestionTableros_Nombre]";
         }
         else if ( AV43OrderedBy == 1 )
         {
            sOrderString = sOrderString + " ORDER BY [TrGestionTableros_Nombre] DESC";
         }
         else if ( true )
         {
            sOrderString = sOrderString + " ORDER BY [TrGestionTableros_ID]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H001R3( IGxContext context ,
                                             short AV43OrderedBy )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM TABLERO.[TrGestionTableros]";
         if ( AV43OrderedBy == 0 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( AV43OrderedBy == 1 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( true )
         {
            scmdbuf = scmdbuf + "";
         }
         GXv_Object4[0] = scmdbuf;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001R2(context, (short)dynConstraints[0] );
               case 1 :
                     return conditional_H001R3(context, (short)dynConstraints[0] );
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
          Object[] prmH001R2 ;
          prmH001R2 = new Object[] {
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH001R3 ;
          prmH001R3 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("H001R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001R2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001R3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((String[]) buf[12])[0] = rslt.getLongVarchar(7) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((String[]) buf[14])[0] = rslt.getLongVarchar(8) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((String[]) buf[16])[0] = rslt.getString(9, 100) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((Guid[]) buf[18])[0] = rslt.getGuid(10) ;
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
                   stmt.SetParameter(sIdx, (int)parms[3]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[4]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[5]);
                }
                return;
       }
    }

 }

}
