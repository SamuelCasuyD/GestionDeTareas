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
   public class wplistadotareasportablero : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wplistadotareasportablero( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wplistadotareasportablero( IGxContext context )
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
         this.AV12TrGestionTableros_ID = aP0_TrGestionTableros_ID;
         this.AV13TrGestionTableros_Nombre = aP1_TrGestionTableros_Nombre;
         this.AV14TrGestionTableros_FechaInicio = aP2_TrGestionTableros_FechaInicio;
         this.AV15TrGestionTableros_FechaFin = aP3_TrGestionTableros_FechaFin;
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
         cmbavTrgestiontareas_estado = new GXCombobox();
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
               nRC_GXsfl_140 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_140_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_140_idx = GetNextPar( );
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
               AV43TrGestionTareas_Nombre_Filter_PreviousValue = GetNextPar( );
               AV42TrGestionTareas_Nombre_Filter = GetNextPar( );
               AV45TrGestionTareas_ID_Filter_PreviousValue = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV44TrGestionTareas_ID_Filter = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV55Pgmname = GetNextPar( );
               AV19CurrentPage_Grid = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV41GenericFilter_Grid = GetNextPar( );
               AV23HasNextPage_Grid = StringUtil.StrToBool( GetNextPar( ));
               A11TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
               AV12TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
               A13TrGestionTareas_Nombre = GetNextPar( );
               n13TrGestionTareas_Nombre = false;
               A12TrGestionTareas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               A14TrGestionTareas_Descripcion = GetNextPar( );
               n14TrGestionTareas_Descripcion = false;
               A15TrGestionTareas_FechaInicio = context.localUtil.ParseDateParm( GetNextPar( ));
               n15TrGestionTareas_FechaInicio = false;
               A16TrGestionTareas_FechaFin = context.localUtil.ParseDateParm( GetNextPar( ));
               n16TrGestionTareas_FechaFin = false;
               A24TrGestionTareas_Estado = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n24TrGestionTareas_Estado = false;
               AV24RowsPerPage_Grid = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV33TrGestionTareas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV51GestionTareas_SDT);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV52TrComentarioTarea_SDT);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( AV43TrGestionTareas_Nombre_Filter_PreviousValue, AV42TrGestionTareas_Nombre_Filter, AV45TrGestionTareas_ID_Filter_PreviousValue, AV44TrGestionTareas_ID_Filter, AV55Pgmname, AV19CurrentPage_Grid, AV41GenericFilter_Grid, AV23HasNextPage_Grid, A11TrGestionTareas_IDTablero, AV12TrGestionTableros_ID, A13TrGestionTareas_Nombre, A12TrGestionTareas_ID, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV24RowsPerPage_Grid, AV33TrGestionTareas_ID, AV51GestionTareas_SDT, AV52TrComentarioTarea_SDT) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV12TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( gxfirstwebparm));
               AssignAttri("", false, "AV12TrGestionTableros_ID", AV12TrGestionTableros_ID.ToString());
               GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV12TrGestionTableros_ID, context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13TrGestionTableros_Nombre = GetNextPar( );
                  AssignAttri("", false, "AV13TrGestionTableros_Nombre", AV13TrGestionTableros_Nombre);
                  AV14TrGestionTableros_FechaInicio = context.localUtil.ParseDateParm( GetNextPar( ));
                  AssignAttri("", false, "AV14TrGestionTableros_FechaInicio", context.localUtil.Format(AV14TrGestionTableros_FechaInicio, "99/99/9999"));
                  AV15TrGestionTableros_FechaFin = context.localUtil.ParseDateParm( GetNextPar( ));
                  AssignAttri("", false, "AV15TrGestionTableros_FechaFin", context.localUtil.Format(AV15TrGestionTableros_FechaFin, "99/99/9999"));
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
         PA1X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1X2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20221022122654", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wplistadotareasportablero.aspx") + "?" + UrlEncode(AV12TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV13TrGestionTableros_Nombre)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV14TrGestionTableros_FechaInicio)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV15TrGestionTableros_FechaFin))+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV23HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRCOMENTARIOTAREA_SDT", GetSecureSignedToken( "", AV52TrComentarioTarea_SDT, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV12TrGestionTableros_ID, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_140", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_140), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE", StringUtil.RTrim( AV43TrGestionTareas_Nombre_Filter_PreviousValue));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TrGestionTareas_ID_Filter_PreviousValue), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV23HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV23HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_IDTABLERO", A11TrGestionTareas_IDTablero.ToString());
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_NOMBRE", StringUtil.RTrim( A13TrGestionTareas_Nombre));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_DESCRIPCION", A14TrGestionTareas_Descripcion);
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAINICIO", context.localUtil.DToC( A15TrGestionTareas_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAFIN", context.localUtil.DToC( A16TrGestionTareas_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24TrGestionTareas_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24RowsPerPage_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONTAREAS_SDT", AV51GestionTareas_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONTAREAS_SDT", AV51GestionTareas_SDT);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCONFIRMATIONREQUIRED", AV48ConfirmationRequired);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRCOMENTARIOTAREA_SDT", AV52TrComentarioTarea_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRCOMENTARIOTAREA_SDT", AV52TrComentarioTarea_SDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRCOMENTARIOTAREA_SDT", GetSecureSignedToken( "", AV52TrComentarioTarea_SDT, context));
         GxWebStd.gx_hidden_field( context, "vCONFIRMATIONSUBID", StringUtil.RTrim( AV49ConfirmationSubId));
         GxWebStd.gx_hidden_field( context, "vGRIDKEY_TRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridKey_TrGestionTareas_ID), 13, 0, ".", "")));
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
            WE1X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1X2( ) ;
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
         return formatLink("wplistadotareasportablero.aspx") + "?" + UrlEncode(AV12TrGestionTableros_ID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV13TrGestionTableros_Nombre)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV14TrGestionTableros_FechaInicio)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV15TrGestionTableros_FechaFin)) ;
      }

      public override String GetPgmname( )
      {
         return "WpListadoTareasPorTablero" ;
      }

      public override String GetPgmdesc( )
      {
         return "Listado de tareas por tablero" ;
      }

      protected void WB1X0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tareas por tablero", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "DATOS DEL TABLERO", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpListadoTareasPorTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_id_var_lefttext_Internalname, "ID : ", "", "", lblTrgestiontableros_id_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_id_Internalname, AV12TrGestionTableros_ID.ToString(), AV12TrGestionTableros_ID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_id_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontableros_id_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_WpListadoTareasPorTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_nombre_var_lefttext_Internalname, "Nombre de tablero : ", "", "", lblTrgestiontableros_nombre_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_nombre_Internalname, StringUtil.RTrim( AV13TrGestionTableros_Nombre), StringUtil.RTrim( context.localUtil.Format( AV13TrGestionTableros_Nombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontableros_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpListadoTareasPorTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_fechainicio_var_lefttext_Internalname, "Fecha de inicio : ", "", "", lblTrgestiontableros_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontableros_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechainicio_Internalname, context.localUtil.Format(AV14TrGestionTableros_FechaInicio, "99/99/9999"), context.localUtil.Format( AV14TrGestionTableros_FechaInicio, "99/99/9999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpListadoTareasPorTablero.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontableros_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTrgestiontableros_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontableros_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontableros_fechafin_Internalname, context.localUtil.Format(AV15TrGestionTableros_FechaFin, "99/99/9999"), context.localUtil.Format( AV15TrGestionTableros_FechaFin, "99/99/9999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontableros_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontableros_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpListadoTareasPorTablero.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontableros_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontableros_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpListadoTareasPorTablero.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_52_1X2( true) ;
         }
         else
         {
            wb_table1_52_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_52_1X2e( bool wbgen )
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
            context.WriteHtmlText( "</fieldset>") ;
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
            wb_table2_61_1X2( true) ;
         }
         else
         {
            wb_table2_61_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table2_61_1X2e( bool wbgen )
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
            wb_table3_76_1X2( true) ;
         }
         else
         {
            wb_table3_76_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table3_76_1X2e( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_140_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_grid_Internalname, StringUtil.RTrim( AV41GenericFilter_Grid), StringUtil.RTrim( context.localUtil.Format( AV41GenericFilter_Grid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavGenericfilter_grid_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavGenericfilter_grid_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpListadoTareasPorTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgLayoutdefined_filtertoggle_combined_grid_Bitmap;
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_combined_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filtertoggle_combined_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpListadoTareasPorTablero.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLayoutdefined_filtersummary_combined_grid_Internalname, lblLayoutdefined_filtersummary_combined_grid_Caption, "", "", lblLayoutdefined_filtersummary_combined_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_FilterSummary", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filterclose_combined_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filterclose_combined_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpListadoTareasPorTablero.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_nombre_filter_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavTrgestiontareas_nombre_filter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrgestiontareas_nombre_filter_Internalname, "Nombre de la tarea", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_140_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_nombre_filter_Internalname, StringUtil.RTrim( AV42TrGestionTareas_Nombre_Filter), StringUtil.RTrim( context.localUtil.Format( AV42TrGestionTareas_Nombre_Filter, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_nombre_filter_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavTrgestiontareas_nombre_filter_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpListadoTareasPorTablero.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_id_filter_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavTrgestiontareas_id_filter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrgestiontareas_id_filter_Internalname, "ID de tarea", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_140_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_id_filter_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TrGestionTareas_ID_Filter), 13, 0, ".", "")), ((edtavTrgestiontareas_id_filter_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44TrGestionTareas_ID_Filter), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV44TrGestionTareas_ID_Filter), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_id_filter_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavTrgestiontareas_id_filter_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpListadoTareasPorTablero.htm");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"140\">") ;
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
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tareas ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "ID de tablero") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre de tarea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripcion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estdo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
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
               GridColumn.AddObjectProperty("Value", context.convertURL( AV46EliminarTarea_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavEliminartarea_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV34ActualizarTarea_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavActualizartarea_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV35AgregarEtiqueta_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavAgregaretiqueta_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV37AgregarComentario_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavAgregarcomentario_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV38CrearActividad_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavCrearactividad_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV36InformacionTarea_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavInformaciontarea_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TrGestionTareas_ID), 13, 0, ".", "")));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTrgestiontareas_id_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", AV28TrGestionTareas_IDTablero.ToString());
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTrgestiontareas_idtablero_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV27TrGestionTareas_Nombre));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTrgestiontareas_nombre_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", AV29TrGestionTareas_Descripcion);
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTrgestiontareas_descripcion_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(AV30TrGestionTareas_FechaInicio, "99/99/9999"));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTrgestiontareas_fechainicio_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(AV31TrGestionTareas_FechaFin, "99/99/9999"));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTrgestiontareas_fechafin_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TrGestionTareas_Estado), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavTrgestiontareas_estado.Enabled), 5, 0, ".", "")));
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
         if ( wbEnd == 140 )
         {
            wbEnd = 0;
            nRC_GXsfl_140 = (int)(nGXsfl_140_idx-1);
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
            wb_table4_156_1X2( true) ;
         }
         else
         {
            wb_table4_156_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table4_156_1X2e( bool wbgen )
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
            wb_table5_163_1X2( true) ;
         }
         else
         {
            wb_table5_163_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table5_163_1X2e( bool wbgen )
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
            wb_table6_184_1X2( true) ;
         }
         else
         {
            wb_table6_184_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table6_184_1X2e( bool wbgen )
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
         if ( wbEnd == 140 )
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

      protected void START1X2( )
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
            Form.Meta.addItem("description", "Listado de tareas por tablero", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1X0( ) ;
      }

      protected void WS1X2( )
      {
         START1X2( ) ;
         EVT1X2( ) ;
      }

      protected void EVT1X2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid)' */
                              E111X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_LISTATABLEROS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_ListaTableros' */
                              E121X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMYES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmYes' */
                              E151X2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "'E_AGREGARETIQUETA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "'E_AGREGARCOMENTARIO'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'E_CREARACTIVIDAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "'E_ELIMINARTAREA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "'E_ELIMINARTAREA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "'E_AGREGARETIQUETA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "'E_AGREGARCOMENTARIO'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'E_CREARACTIVIDAD'") == 0 ) )
                           {
                              nGXsfl_140_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
                              SubsflControlProps_1402( ) ;
                              AV46EliminarTarea_Action = cgiGet( edtavEliminartarea_action_Internalname);
                              AssignProp("", false, edtavEliminartarea_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV46EliminarTarea_Action)) ? AV57Eliminartarea_action_GXI : context.convertURL( context.PathToRelativeUrl( AV46EliminarTarea_Action))), !bGXsfl_140_Refreshing);
                              AssignProp("", false, edtavEliminartarea_action_Internalname, "SrcSet", context.GetImageSrcSet( AV46EliminarTarea_Action), true);
                              AV34ActualizarTarea_Action = cgiGet( edtavActualizartarea_action_Internalname);
                              AssignProp("", false, edtavActualizartarea_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV34ActualizarTarea_Action)) ? AV58Actualizartarea_action_GXI : context.convertURL( context.PathToRelativeUrl( AV34ActualizarTarea_Action))), !bGXsfl_140_Refreshing);
                              AssignProp("", false, edtavActualizartarea_action_Internalname, "SrcSet", context.GetImageSrcSet( AV34ActualizarTarea_Action), true);
                              AV35AgregarEtiqueta_Action = cgiGet( edtavAgregaretiqueta_action_Internalname);
                              AssignProp("", false, edtavAgregaretiqueta_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV35AgregarEtiqueta_Action)) ? AV59Agregaretiqueta_action_GXI : context.convertURL( context.PathToRelativeUrl( AV35AgregarEtiqueta_Action))), !bGXsfl_140_Refreshing);
                              AssignProp("", false, edtavAgregaretiqueta_action_Internalname, "SrcSet", context.GetImageSrcSet( AV35AgregarEtiqueta_Action), true);
                              AV37AgregarComentario_Action = cgiGet( edtavAgregarcomentario_action_Internalname);
                              AssignProp("", false, edtavAgregarcomentario_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37AgregarComentario_Action)) ? AV60Agregarcomentario_action_GXI : context.convertURL( context.PathToRelativeUrl( AV37AgregarComentario_Action))), !bGXsfl_140_Refreshing);
                              AssignProp("", false, edtavAgregarcomentario_action_Internalname, "SrcSet", context.GetImageSrcSet( AV37AgregarComentario_Action), true);
                              AV38CrearActividad_Action = cgiGet( edtavCrearactividad_action_Internalname);
                              AssignProp("", false, edtavCrearactividad_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV38CrearActividad_Action)) ? AV61Crearactividad_action_GXI : context.convertURL( context.PathToRelativeUrl( AV38CrearActividad_Action))), !bGXsfl_140_Refreshing);
                              AssignProp("", false, edtavCrearactividad_action_Internalname, "SrcSet", context.GetImageSrcSet( AV38CrearActividad_Action), true);
                              AV36InformacionTarea_Action = cgiGet( edtavInformaciontarea_action_Internalname);
                              AssignProp("", false, edtavInformaciontarea_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV36InformacionTarea_Action)) ? AV62Informaciontarea_action_GXI : context.convertURL( context.PathToRelativeUrl( AV36InformacionTarea_Action))), !bGXsfl_140_Refreshing);
                              AssignProp("", false, edtavInformaciontarea_action_Internalname, "SrcSet", context.GetImageSrcSet( AV36InformacionTarea_Action), true);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRGESTIONTAREAS_ID");
                                 GX_FocusControl = edtavTrgestiontareas_id_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV33TrGestionTareas_ID = 0;
                                 AssignAttri("", false, edtavTrgestiontareas_id_Internalname, StringUtil.LTrimStr( (decimal)(AV33TrGestionTareas_ID), 13, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID"+"_"+sGXsfl_140_idx, GetSecureSignedToken( sGXsfl_140_idx, context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV33TrGestionTareas_ID = (long)(context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_Internalname), ".", ","));
                                 AssignAttri("", false, edtavTrgestiontareas_id_Internalname, StringUtil.LTrimStr( (decimal)(AV33TrGestionTareas_ID), 13, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID"+"_"+sGXsfl_140_idx, GetSecureSignedToken( sGXsfl_140_idx, context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
                              }
                              if ( StringUtil.StrCmp(cgiGet( edtavTrgestiontareas_idtablero_Internalname), "") == 0 )
                              {
                                 AV28TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
                                 AssignAttri("", false, edtavTrgestiontareas_idtablero_Internalname, AV28TrGestionTareas_IDTablero.ToString());
                                 GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO"+"_"+sGXsfl_140_idx, GetSecureSignedToken( sGXsfl_140_idx, AV28TrGestionTareas_IDTablero, context));
                              }
                              else
                              {
                                 try
                                 {
                                    AV28TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( edtavTrgestiontareas_idtablero_Internalname)));
                                    AssignAttri("", false, edtavTrgestiontareas_idtablero_Internalname, AV28TrGestionTareas_IDTablero.ToString());
                                    GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO"+"_"+sGXsfl_140_idx, GetSecureSignedToken( sGXsfl_140_idx, AV28TrGestionTareas_IDTablero, context));
                                 }
                                 catch ( Exception e )
                                 {
                                    GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vTRGESTIONTAREAS_IDTABLERO");
                                    GX_FocusControl = edtavTrgestiontareas_idtablero_Internalname;
                                    AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                    wbErr = true;
                                 }
                              }
                              AV27TrGestionTareas_Nombre = cgiGet( edtavTrgestiontareas_nombre_Internalname);
                              AssignAttri("", false, edtavTrgestiontareas_nombre_Internalname, AV27TrGestionTareas_Nombre);
                              AV29TrGestionTareas_Descripcion = cgiGet( edtavTrgestiontareas_descripcion_Internalname);
                              AssignAttri("", false, edtavTrgestiontareas_descripcion_Internalname, AV29TrGestionTareas_Descripcion);
                              if ( context.localUtil.VCDateTime( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Inicio"}), 1, "vTRGESTIONTAREAS_FECHAINICIO");
                                 GX_FocusControl = edtavTrgestiontareas_fechainicio_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV30TrGestionTareas_FechaInicio = (DateTime)(DateTime.MinValue);
                                 AssignAttri("", false, edtavTrgestiontareas_fechainicio_Internalname, context.localUtil.Format(AV30TrGestionTareas_FechaInicio, "99/99/9999"));
                              }
                              else
                              {
                                 AV30TrGestionTareas_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 0));
                                 AssignAttri("", false, edtavTrgestiontareas_fechainicio_Internalname, context.localUtil.Format(AV30TrGestionTareas_FechaInicio, "99/99/9999"));
                              }
                              if ( context.localUtil.VCDateTime( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Fin"}), 1, "vTRGESTIONTAREAS_FECHAFIN");
                                 GX_FocusControl = edtavTrgestiontareas_fechafin_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV31TrGestionTareas_FechaFin = (DateTime)(DateTime.MinValue);
                                 AssignAttri("", false, edtavTrgestiontareas_fechafin_Internalname, context.localUtil.Format(AV31TrGestionTareas_FechaFin, "99/99/9999"));
                              }
                              else
                              {
                                 AV31TrGestionTareas_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 0));
                                 AssignAttri("", false, edtavTrgestiontareas_fechafin_Internalname, context.localUtil.Format(AV31TrGestionTareas_FechaFin, "99/99/9999"));
                              }
                              cmbavTrgestiontareas_estado.Name = cmbavTrgestiontareas_estado_Internalname;
                              cmbavTrgestiontareas_estado.CurrentValue = cgiGet( cmbavTrgestiontareas_estado_Internalname);
                              AV32TrGestionTareas_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTrgestiontareas_estado_Internalname), "."));
                              AssignAttri("", false, cmbavTrgestiontareas_estado_Internalname, StringUtil.LTrimStr( (decimal)(AV32TrGestionTareas_Estado), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E161X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E171X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E181X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E191X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_AGREGARETIQUETA'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_AgregarEtiqueta' */
                                    E201X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_AGREGARCOMENTARIO'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_AgregarComentario' */
                                    E211X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_CREARACTIVIDAD'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_CrearActividad' */
                                    E221X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_ELIMINARTAREA'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_EliminarTarea' */
                                    E231X2 ();
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

      protected void WE1X2( )
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

      protected void PA1X2( )
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
         SubsflControlProps_1402( ) ;
         while ( nGXsfl_140_idx <= nRC_GXsfl_140 )
         {
            sendrow_1402( ) ;
            nGXsfl_140_idx = ((subGrid_Islastpage==1)&&(nGXsfl_140_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_idx+1);
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1402( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( String AV43TrGestionTareas_Nombre_Filter_PreviousValue ,
                                       String AV42TrGestionTareas_Nombre_Filter ,
                                       long AV45TrGestionTareas_ID_Filter_PreviousValue ,
                                       long AV44TrGestionTareas_ID_Filter ,
                                       String AV55Pgmname ,
                                       short AV19CurrentPage_Grid ,
                                       String AV41GenericFilter_Grid ,
                                       bool AV23HasNextPage_Grid ,
                                       Guid A11TrGestionTareas_IDTablero ,
                                       Guid AV12TrGestionTableros_ID ,
                                       String A13TrGestionTareas_Nombre ,
                                       long A12TrGestionTareas_ID ,
                                       String A14TrGestionTareas_Descripcion ,
                                       DateTime A15TrGestionTareas_FechaInicio ,
                                       DateTime A16TrGestionTareas_FechaFin ,
                                       short A24TrGestionTareas_Estado ,
                                       short AV24RowsPerPage_Grid ,
                                       long AV33TrGestionTareas_ID ,
                                       SdtGestionTareas_SDT AV51GestionTareas_SDT ,
                                       SdtTrComentarioTarea_SDT AV52TrComentarioTarea_SDT )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E171X2 ();
         GRID_nCurrentRecord = 0;
         RF1X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO", GetSecureSignedToken( "", AV28TrGestionTareas_IDTablero, context));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_IDTABLERO", AV28TrGestionTareas_IDTablero.ToString());
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
            AV26GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E171X2 ();
         RF1X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV55Pgmname = "WpListadoTareasPorTablero";
         context.Gx_err = 0;
         edtavTrgestiontableros_id_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_id_Enabled), 5, 0), true);
         edtavTrgestiontableros_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_nombre_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechainicio_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechafin_Enabled), 5, 0), true);
         edtavTrgestiontareas_id_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_id_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_idtablero_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_idtablero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_idtablero_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_nombre_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_descripcion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_descripcion_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechainicio_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechafin_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         cmbavTrgestiontareas_estado.Enabled = 0;
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrgestiontareas_estado.Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void RF1X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 140;
         E181X2 ();
         nGXsfl_140_idx = 1;
         sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
         SubsflControlProps_1402( ) ;
         bGXsfl_140_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "Grid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1402( ) ;
            E191X2 ();
            wbEnd = 140;
            WB1X0( ) ;
         }
         bGXsfl_140_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1X2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV23HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV23HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID"+"_"+sGXsfl_140_idx, GetSecureSignedToken( sGXsfl_140_idx, context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO"+"_"+sGXsfl_140_idx, GetSecureSignedToken( sGXsfl_140_idx, AV28TrGestionTareas_IDTablero, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRCOMENTARIOTAREA_SDT", AV52TrComentarioTarea_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRCOMENTARIOTAREA_SDT", AV52TrComentarioTarea_SDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRCOMENTARIOTAREA_SDT", GetSecureSignedToken( "", AV52TrComentarioTarea_SDT, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV55Pgmname = "WpListadoTareasPorTablero";
         context.Gx_err = 0;
         edtavTrgestiontableros_id_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_id_Enabled), 5, 0), true);
         edtavTrgestiontableros_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_nombre_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechainicio_Enabled), 5, 0), true);
         edtavTrgestiontableros_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontableros_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontableros_fechafin_Enabled), 5, 0), true);
         edtavTrgestiontareas_id_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_id_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_idtablero_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_idtablero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_idtablero_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_nombre_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_descripcion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_descripcion_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechainicio_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavTrgestiontareas_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechafin_Enabled), 5, 0), !bGXsfl_140_Refreshing);
         cmbavTrgestiontareas_estado.Enabled = 0;
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrgestiontareas_estado.Enabled), 5, 0), !bGXsfl_140_Refreshing);
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void STRUP1X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E161X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_140 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_140"), ".", ","));
            AV49ConfirmationSubId = cgiGet( "vCONFIRMATIONSUBID");
            AV24RowsPerPage_Grid = (short)(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_GRID"), ".", ","));
            AV19CurrentPage_Grid = (short)(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRID"), ".", ","));
            AV23HasNextPage_Grid = StringUtil.StrToBool( cgiGet( "vHASNEXTPAGE_GRID"));
            divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = (int)(context.localUtil.CToN( cgiGet( "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID_Visible"), ".", ","));
            /* Read variables values. */
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV26GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0));
            AV41GenericFilter_Grid = cgiGet( edtavGenericfilter_grid_Internalname);
            AssignAttri("", false, "AV41GenericFilter_Grid", AV41GenericFilter_Grid);
            AV42TrGestionTareas_Nombre_Filter = cgiGet( edtavTrgestiontareas_nombre_filter_Internalname);
            AssignAttri("", false, "AV42TrGestionTareas_Nombre_Filter", AV42TrGestionTareas_Nombre_Filter);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_filter_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_filter_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRGESTIONTAREAS_ID_FILTER");
               GX_FocusControl = edtavTrgestiontareas_id_filter_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44TrGestionTareas_ID_Filter = 0;
               AssignAttri("", false, "AV44TrGestionTareas_ID_Filter", StringUtil.LTrimStr( (decimal)(AV44TrGestionTareas_ID_Filter), 13, 0));
            }
            else
            {
               AV44TrGestionTareas_ID_Filter = (long)(context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_filter_Internalname), ".", ","));
               AssignAttri("", false, "AV44TrGestionTareas_ID_Filter", StringUtil.LTrimStr( (decimal)(AV44TrGestionTareas_ID_Filter), 13, 0));
            }
            AV47ConfirmMessage = cgiGet( edtavConfirmmessage_Internalname);
            AssignAttri("", false, "AV47ConfirmMessage", AV47ConfirmMessage);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         E161X2 ();
         if (returnInSub) return;
      }

      protected void E161X2( )
      {
         /* Start Routine */
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV55Pgmname,  "Grid", out  AV24RowsPerPage_Grid, out  AV25RowsPerPageLoaded_Grid) ;
         AssignAttri("", false, "AV24RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_Grid), 4, 0));
         if ( ! AV25RowsPerPageLoaded_Grid )
         {
            AV24RowsPerPage_Grid = 10;
            AssignAttri("", false, "AV24RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_Grid), 4, 0));
         }
         AV26GridSettingsRowsPerPage_Grid = AV24RowsPerPage_Grid;
         AssignAttri("", false, "AV26GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV43TrGestionTareas_Nombre_Filter_PreviousValue = AV42TrGestionTareas_Nombre_Filter;
         AssignAttri("", false, "AV43TrGestionTareas_Nombre_Filter_PreviousValue", AV43TrGestionTareas_Nombre_Filter_PreviousValue);
         AV45TrGestionTareas_ID_Filter_PreviousValue = AV44TrGestionTareas_ID_Filter;
         AssignAttri("", false, "AV45TrGestionTareas_ID_Filter_PreviousValue", StringUtil.LTrimStr( (decimal)(AV45TrGestionTareas_ID_Filter_PreviousValue), 13, 0));
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
      }

      protected void E171X2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S142 ();
         if (returnInSub) return;
         AV48ConfirmationRequired = false;
         AssignAttri("", false, "AV48ConfirmationRequired", AV48ConfirmationRequired);
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         if ( (0==AV19CurrentPage_Grid) )
         {
            AV19CurrentPage_Grid = 1;
            AssignAttri("", false, "AV19CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV19CurrentPage_Grid), 4, 0));
         }
         AV20Reload_Grid = true;
         imgListatableros_Bitmap = context.GetImagePath( "dc7fa476-057a-4183-b3c2-d6a8394cb2a4", "", context.GetTheme( ));
         AssignProp("", false, imgListatableros_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgListatableros_Bitmap)), true);
         AssignProp("", false, imgListatableros_Internalname, "SrcSet", context.GetImageSrcSet( imgListatableros_Bitmap), true);
         imgListatableros_Tooltiptext = "Lista Tableros";
         AssignProp("", false, imgListatableros_Internalname, "Tooltiptext", imgListatableros_Tooltiptext, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S193( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         AV51GestionTareas_SDT.gxTpr_Trgestiontareas_id = AV33TrGestionTareas_ID;
         AV51GestionTareas_SDT.gxTpr_Trgestiontareas_idtablero = (Guid)(AV12TrGestionTableros_ID);
      }

      protected void S182( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV19CurrentPage_Grid-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV19CurrentPage_Grid), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV19CurrentPage_Grid+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV19CurrentPage_Grid) || ( AV19CurrentPage_Grid <= 1 ) )
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
            if ( AV19CurrentPage_Grid == 2 )
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
               if ( AV19CurrentPage_Grid == 3 )
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
         if ( ! AV23HasNextPage_Grid )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
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
            cellPaginationbar_spacingrightcellgrid_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
            AssignProp("", false, cellPaginationbar_spacingrightcellgrid_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
         }
         if ( ( AV19CurrentPage_Grid <= 1 ) && ! AV23HasNextPage_Grid )
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

      protected void S172( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
      }

      protected void E181X2( )
      {
         /* Grid_Refresh Routine */
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S162 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV43TrGestionTareas_Nombre_Filter_PreviousValue, AV42TrGestionTareas_Nombre_Filter) != 0 )
         {
            AV43TrGestionTareas_Nombre_Filter_PreviousValue = AV42TrGestionTareas_Nombre_Filter;
            AssignAttri("", false, "AV43TrGestionTareas_Nombre_Filter_PreviousValue", AV43TrGestionTareas_Nombre_Filter_PreviousValue);
            AV19CurrentPage_Grid = 1;
            AssignAttri("", false, "AV19CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV19CurrentPage_Grid), 4, 0));
         }
         if ( AV45TrGestionTareas_ID_Filter_PreviousValue != AV44TrGestionTareas_ID_Filter )
         {
            AV45TrGestionTareas_ID_Filter_PreviousValue = AV44TrGestionTareas_ID_Filter;
            AssignAttri("", false, "AV45TrGestionTareas_ID_Filter_PreviousValue", StringUtil.LTrimStr( (decimal)(AV45TrGestionTareas_ID_Filter_PreviousValue), 13, 0));
            AV19CurrentPage_Grid = 1;
            AssignAttri("", false, "AV19CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV19CurrentPage_Grid), 4, 0));
         }
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E191X2( )
      {
         /* Grid_Load Routine */
         tblI_noresultsfoundtablename_grid_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV22I_LoadCount_Grid = 0;
         AV23HasNextPage_Grid = false;
         AssignAttri("", false, "AV23HasNextPage_Grid", AV23HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV23HasNextPage_Grid, context));
         AV56GXLvl179 = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42TrGestionTareas_Nombre_Filter ,
                                              AV44TrGestionTareas_ID_Filter ,
                                              AV41GenericFilter_Grid ,
                                              A13TrGestionTareas_Nombre ,
                                              A12TrGestionTareas_ID ,
                                              A14TrGestionTareas_Descripcion ,
                                              AV12TrGestionTableros_ID ,
                                              A11TrGestionTareas_IDTablero } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.LONG, TypeConstants.STRING, TypeConstants.STRING, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.STRING, TypeConstants.BOOLEAN
                                              }
         } ) ;
         lV42TrGestionTareas_Nombre_Filter = StringUtil.PadR( StringUtil.RTrim( AV42TrGestionTareas_Nombre_Filter), 100, "%");
         lV41GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV41GenericFilter_Grid), 100, "%");
         lV41GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV41GenericFilter_Grid), 100, "%");
         /* Using cursor H001X2 */
         pr_default.execute(0, new Object[] {AV12TrGestionTableros_ID, lV42TrGestionTareas_Nombre_Filter, AV44TrGestionTareas_ID_Filter, lV41GenericFilter_Grid, lV41GenericFilter_Grid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14TrGestionTareas_Descripcion = H001X2_A14TrGestionTareas_Descripcion[0];
            n14TrGestionTareas_Descripcion = H001X2_n14TrGestionTareas_Descripcion[0];
            A12TrGestionTareas_ID = H001X2_A12TrGestionTareas_ID[0];
            A13TrGestionTareas_Nombre = H001X2_A13TrGestionTareas_Nombre[0];
            n13TrGestionTareas_Nombre = H001X2_n13TrGestionTareas_Nombre[0];
            A11TrGestionTareas_IDTablero = (Guid)((Guid)(H001X2_A11TrGestionTareas_IDTablero[0]));
            A15TrGestionTareas_FechaInicio = H001X2_A15TrGestionTareas_FechaInicio[0];
            n15TrGestionTareas_FechaInicio = H001X2_n15TrGestionTareas_FechaInicio[0];
            A16TrGestionTareas_FechaFin = H001X2_A16TrGestionTareas_FechaFin[0];
            n16TrGestionTareas_FechaFin = H001X2_n16TrGestionTareas_FechaFin[0];
            A24TrGestionTareas_Estado = H001X2_A24TrGestionTareas_Estado[0];
            n24TrGestionTareas_Estado = H001X2_n24TrGestionTareas_Estado[0];
            AV56GXLvl179 = 1;
            AV33TrGestionTareas_ID = A12TrGestionTareas_ID;
            AssignAttri("", false, edtavTrgestiontareas_id_Internalname, StringUtil.LTrimStr( (decimal)(AV33TrGestionTareas_ID), 13, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID"+"_"+sGXsfl_140_idx, GetSecureSignedToken( sGXsfl_140_idx, context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
            AV28TrGestionTareas_IDTablero = (Guid)(A11TrGestionTareas_IDTablero);
            AssignAttri("", false, edtavTrgestiontareas_idtablero_Internalname, AV28TrGestionTareas_IDTablero.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO"+"_"+sGXsfl_140_idx, GetSecureSignedToken( sGXsfl_140_idx, AV28TrGestionTareas_IDTablero, context));
            AV27TrGestionTareas_Nombre = A13TrGestionTareas_Nombre;
            AssignAttri("", false, edtavTrgestiontareas_nombre_Internalname, AV27TrGestionTareas_Nombre);
            AV29TrGestionTareas_Descripcion = A14TrGestionTareas_Descripcion;
            AssignAttri("", false, edtavTrgestiontareas_descripcion_Internalname, AV29TrGestionTareas_Descripcion);
            AV30TrGestionTareas_FechaInicio = A15TrGestionTareas_FechaInicio;
            AssignAttri("", false, edtavTrgestiontareas_fechainicio_Internalname, context.localUtil.Format(AV30TrGestionTareas_FechaInicio, "99/99/9999"));
            AV31TrGestionTareas_FechaFin = A16TrGestionTareas_FechaFin;
            AssignAttri("", false, edtavTrgestiontareas_fechafin_Internalname, context.localUtil.Format(AV31TrGestionTareas_FechaFin, "99/99/9999"));
            AV32TrGestionTareas_Estado = A24TrGestionTareas_Estado;
            AssignAttri("", false, cmbavTrgestiontareas_estado_Internalname, StringUtil.LTrimStr( (decimal)(AV32TrGestionTareas_Estado), 4, 0));
            AV46EliminarTarea_Action = context.GetImagePath( "4cb13b83-cf55-4682-9d11-58cce2b11e48", "", context.GetTheme( ));
            AssignAttri("", false, edtavEliminartarea_action_Internalname, AV46EliminarTarea_Action);
            AV57Eliminartarea_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "4cb13b83-cf55-4682-9d11-58cce2b11e48", "", context.GetTheme( )));
            edtavEliminartarea_action_Tooltiptext = "Eliminar Tarea";
            AV34ActualizarTarea_Action = context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( ));
            AssignAttri("", false, edtavActualizartarea_action_Internalname, AV34ActualizarTarea_Action);
            AV58Actualizartarea_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( )));
            edtavActualizartarea_action_Tooltiptext = "Actualizar Tarea";
            AV35AgregarEtiqueta_Action = context.GetImagePath( "d544a810-d067-45f9-a74b-b82632541d38", "", context.GetTheme( ));
            AssignAttri("", false, edtavAgregaretiqueta_action_Internalname, AV35AgregarEtiqueta_Action);
            AV59Agregaretiqueta_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "d544a810-d067-45f9-a74b-b82632541d38", "", context.GetTheme( )));
            edtavAgregaretiqueta_action_Tooltiptext = "Agregar Etiqueta";
            AV37AgregarComentario_Action = context.GetImagePath( "d006b751-0154-4c41-8d12-c49198748691", "", context.GetTheme( ));
            AssignAttri("", false, edtavAgregarcomentario_action_Internalname, AV37AgregarComentario_Action);
            AV60Agregarcomentario_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "d006b751-0154-4c41-8d12-c49198748691", "", context.GetTheme( )));
            edtavAgregarcomentario_action_Tooltiptext = "Crear Comentario";
            AV38CrearActividad_Action = context.GetImagePath( "6bc47837-a751-4230-bb5e-23b9a3f4b81d", "", context.GetTheme( ));
            AssignAttri("", false, edtavCrearactividad_action_Internalname, AV38CrearActividad_Action);
            AV61Crearactividad_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6bc47837-a751-4230-bb5e-23b9a3f4b81d", "", context.GetTheme( )));
            edtavCrearactividad_action_Tooltiptext = "Crear Actividad";
            AV36InformacionTarea_Action = context.GetImagePath( "71387ecf-b35f-45a7-aefb-b55a5da4cbe2", "", context.GetTheme( ));
            AssignAttri("", false, edtavInformaciontarea_action_Internalname, AV36InformacionTarea_Action);
            AV62Informaciontarea_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "71387ecf-b35f-45a7-aefb-b55a5da4cbe2", "", context.GetTheme( )));
            edtavInformaciontarea_action_Tooltiptext = "Informacion Tarea";
            AV22I_LoadCount_Grid = (short)(AV22I_LoadCount_Grid+1);
            AV21LoadRow_Grid = true;
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S193 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( AV21LoadRow_Grid )
            {
               if ( AV22I_LoadCount_Grid > AV24RowsPerPage_Grid * AV19CurrentPage_Grid )
               {
                  AV23HasNextPage_Grid = true;
                  AssignAttri("", false, "AV23HasNextPage_Grid", AV23HasNextPage_Grid);
                  GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV23HasNextPage_Grid, context));
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               if ( ( AV22I_LoadCount_Grid > ( AV24RowsPerPage_Grid * ( AV19CurrentPage_Grid - 1 ) ) ) && ( AV22I_LoadCount_Grid <= ( AV24RowsPerPage_Grid * AV19CurrentPage_Grid ) ) )
               {
                  /* Load Method */
                  if ( wbStart != -1 )
                  {
                     wbStart = 140;
                  }
                  sendrow_1402( ) ;
                  if ( isFullAjaxMode( ) && ! bGXsfl_140_Refreshing )
                  {
                     context.DoAjaxLoad(140, GridRow);
                  }
               }
            }
            else
            {
               AV22I_LoadCount_Grid = (short)(AV22I_LoadCount_Grid-1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV56GXLvl179 == 0 )
         {
            tblI_noresultsfoundtablename_grid_Visible = 1;
            AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            /* Execute user subroutine: 'U_WHENNONE(GRID)' */
            S202 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32TrGestionTareas_Estado), 4, 0));
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51GestionTareas_SDT", AV51GestionTareas_SDT);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         AV16GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV55Pgmname,  AV16GridStateKey, out  AV17GridState) ;
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV17GridState.gxTpr_Filtervalues.Count )
         {
            AV18GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV17GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Filtername, "TrGestionTareas_Nombre_Filter") == 0 )
            {
               AV42TrGestionTareas_Nombre_Filter = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TrGestionTareas_Nombre_Filter", AV42TrGestionTareas_Nombre_Filter);
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Filtername, "TrGestionTareas_ID_Filter") == 0 )
            {
               AV44TrGestionTareas_ID_Filter = (long)(NumberUtil.Val( AV18GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV44TrGestionTareas_ID_Filter", StringUtil.LTrimStr( (decimal)(AV44TrGestionTareas_ID_Filter), 13, 0));
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Filtername, "GenericFilter_Grid") == 0 )
            {
               AV41GenericFilter_Grid = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41GenericFilter_Grid", AV41GenericFilter_Grid);
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
         if ( AV17GridState.gxTpr_Currentpage > 0 )
         {
            AV19CurrentPage_Grid = AV17GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV19CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV19CurrentPage_Grid), 4, 0));
         }
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         AV16GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV55Pgmname,  AV16GridStateKey, out  AV17GridState) ;
         AV17GridState.gxTpr_Currentpage = AV19CurrentPage_Grid;
         AV17GridState.gxTpr_Filtervalues.Clear();
         AV18GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV18GridStateFilterValue.gxTpr_Filtername = "TrGestionTareas_Nombre_Filter";
         AV18GridStateFilterValue.gxTpr_Value = AV42TrGestionTareas_Nombre_Filter;
         AV17GridState.gxTpr_Filtervalues.Add(AV18GridStateFilterValue, 0);
         AV18GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV18GridStateFilterValue.gxTpr_Filtername = "TrGestionTareas_ID_Filter";
         AV18GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV44TrGestionTareas_ID_Filter), 13, 0);
         AV17GridState.gxTpr_Filtervalues.Add(AV18GridStateFilterValue, 0);
         AV18GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV18GridStateFilterValue.gxTpr_Filtername = "GenericFilter_Grid";
         AV18GridStateFilterValue.gxTpr_Value = AV41GenericFilter_Grid;
         AV17GridState.gxTpr_Filtervalues.Add(AV18GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV55Pgmname,  AV16GridStateKey,  AV17GridState) ;
      }

      protected void S202( )
      {
         /* 'U_WHENNONE(GRID)' Routine */
      }

      protected void E111X2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         if ( AV24RowsPerPage_Grid != AV26GridSettingsRowsPerPage_Grid )
         {
            AV24RowsPerPage_Grid = AV26GridSettingsRowsPerPage_Grid;
            AssignAttri("", false, "AV24RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV55Pgmname,  "Grid",  AV24RowsPerPage_Grid) ;
            AV19CurrentPage_Grid = 1;
            AssignAttri("", false, "AV19CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV19CurrentPage_Grid), 4, 0));
         }
         gxgrGrid_refresh( AV43TrGestionTareas_Nombre_Filter_PreviousValue, AV42TrGestionTareas_Nombre_Filter, AV45TrGestionTareas_ID_Filter_PreviousValue, AV44TrGestionTareas_ID_Filter, AV55Pgmname, AV19CurrentPage_Grid, AV41GenericFilter_Grid, AV23HasNextPage_Grid, A11TrGestionTareas_IDTablero, AV12TrGestionTableros_ID, A13TrGestionTareas_Nombre, A12TrGestionTareas_ID, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV24RowsPerPage_Grid, AV33TrGestionTareas_ID, AV51GestionTareas_SDT, AV52TrComentarioTarea_SDT) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void S212( )
      {
         /* 'U_ACTUALIZARTAREA' Routine */
         context.PopUp(formatLink("wpactualizartareaportablero.aspx") + "?" + UrlEncode("" +AV33TrGestionTareas_ID) + "," + UrlEncode(AV28TrGestionTareas_IDTablero.ToString()), new Object[] {});
      }

      protected void E201X2( )
      {
         /* 'E_AgregarEtiqueta' Routine */
         /* Execute user subroutine: 'U_AGREGARETIQUETA' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S222( )
      {
         /* 'U_AGREGARETIQUETA' Routine */
         context.PopUp(formatLink("wptareasagregaretiquetas.aspx") + "?" + UrlEncode("" +AV33TrGestionTareas_ID), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void S232( )
      {
         /* 'U_INFORMACIONTAREA' Routine */
         CallWebObject(formatLink("wpvisualizarinformaciontarea.aspx") + "?" + UrlEncode("" +AV33TrGestionTareas_ID));
         context.wjLocDisableFrm = 1;
      }

      protected void E211X2( )
      {
         /* 'E_AgregarComentario' Routine */
         /* Execute user subroutine: 'U_AGREGARCOMENTARIO' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S242( )
      {
         /* 'U_AGREGARCOMENTARIO' Routine */
         context.PopUp(formatLink("wpcrearcomentariostarea.aspx") + "?" + UrlEncode("" +AV33TrGestionTareas_ID), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void E121X2( )
      {
         /* 'E_ListaTableros' Routine */
         /* Execute user subroutine: 'U_LISTATABLEROS' */
         S252 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S252( )
      {
         /* 'U_LISTATABLEROS' Routine */
         CallWebObject(formatLink("inicio.aspx") );
         context.wjLocDisableFrm = 1;
         context.DoAjaxRefresh();
      }

      protected void E221X2( )
      {
         /* 'E_CrearActividad' Routine */
         /* Execute user subroutine: 'U_CREARACTIVIDAD' */
         S262 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S262( )
      {
         /* 'U_CREARACTIVIDAD' Routine */
         context.PopUp(formatLink("wpcrearactividadtarea.aspx") + "?" + UrlEncode("" +AV33TrGestionTareas_ID), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         AV39K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "TABLEROS_WEB");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TrGestionTareas_Nombre_Filter)) )
         {
            AV40K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "TrGestionTareas_Nombre_Filter";
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Nombre de la tarea";
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV42TrGestionTareas_Nombre_Filter;
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV42TrGestionTareas_Nombre_Filter;
            AV39K2BFilterValuesSDT_WebForm.Add(AV40K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! (0==AV44TrGestionTareas_ID_Filter) )
         {
            AV40K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "TrGestionTareas_ID_Filter";
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "ID de tarea";
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Value = StringUtil.Str( (decimal)(AV44TrGestionTareas_ID_Filter), 13, 0);
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = StringUtil.Str( (decimal)(AV44TrGestionTareas_ID_Filter), 13, 0);
            AV39K2BFilterValuesSDT_WebForm.Add(AV40K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( AV39K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_char1 = "";
            new k2bgetfilterssummary(context ).execute(  AV55Pgmname,  "Grid",  AV39K2BFilterValuesSDT_WebForm, out  GXt_char1) ;
            lblLayoutdefined_filtersummary_combined_grid_Caption = GXt_char1;
            AssignProp("", false, lblLayoutdefined_filtersummary_combined_grid_Internalname, "Caption", lblLayoutdefined_filtersummary_combined_grid_Caption, true);
         }
         else
         {
            lblLayoutdefined_filtersummary_combined_grid_Caption = "No hay filtros aplicados";
            AssignProp("", false, lblLayoutdefined_filtersummary_combined_grid_Internalname, "Caption", lblLayoutdefined_filtersummary_combined_grid_Caption, true);
         }
      }

      protected void E131X2( )
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

      protected void E141X2( )
      {
         /* Layoutdefined_filterclose_combined_grid_Click Routine */
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
         imgLayoutdefined_filtertoggle_combined_grid_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_grid_Bitmap)), true);
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_grid_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void E231X2( )
      {
         /* 'E_EliminarTarea' Routine */
         AV47ConfirmMessage = "¿Está seguro?";
         AssignAttri("", false, "AV47ConfirmMessage", AV47ConfirmMessage);
         /* Execute user subroutine: 'U_CONFIRMATIONREQUIRED(ELIMINARTAREA)' */
         S272 ();
         if (returnInSub) return;
         if ( AV48ConfirmationRequired )
         {
            AV49ConfirmationSubId = "'U_EliminarTarea'";
            AssignAttri("", false, "AV49ConfirmationSubId", AV49ConfirmationSubId);
            AV20Reload_Grid = false;
            AV50GridKey_TrGestionTareas_ID = AV33TrGestionTareas_ID;
            AssignAttri("", false, "AV50GridKey_TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV50GridKey_TrGestionTareas_ID), 13, 0));
            tblTableconditionalconfirm_Visible = 1;
            AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         }
         else
         {
            /* Execute user subroutine: 'U_ELIMINARTAREA' */
            S282 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51GestionTareas_SDT", AV51GestionTareas_SDT);
      }

      protected void S282( )
      {
         /* 'U_ELIMINARTAREA' Routine */
         /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
         S193 ();
         if (returnInSub) return;
         new prgestionesdetareas(context ).execute(  AV51GestionTareas_SDT,  AV52TrComentarioTarea_SDT,  "DEL") ;
         context.DoAjaxRefresh();
      }

      protected void E151X2( )
      {
         /* 'ConfirmYes' Routine */
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV49ConfirmationSubId, "'U_EliminarTarea'") == 0 )
         {
            /* Execute user subroutine: 'E_SETROWPOSITION(ELIMINARTAREA)' */
            S292 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51GestionTareas_SDT", AV51GestionTareas_SDT);
      }

      protected void S272( )
      {
         /* 'U_CONFIRMATIONREQUIRED(ELIMINARTAREA)' Routine */
         AV48ConfirmationRequired = true;
         AssignAttri("", false, "AV48ConfirmationRequired", AV48ConfirmationRequired);
      }

      protected void S292( )
      {
         /* 'E_SETROWPOSITION(ELIMINARTAREA)' Routine */
         /* Start For Each Line in Grid */
         nRC_GXsfl_140 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_140"), ".", ","));
         nGXsfl_140_fel_idx = 0;
         while ( nGXsfl_140_fel_idx < nRC_GXsfl_140 )
         {
            nGXsfl_140_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_140_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_fel_idx+1);
            sGXsfl_140_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1402( ) ;
            AV46EliminarTarea_Action = cgiGet( edtavEliminartarea_action_Internalname);
            AV34ActualizarTarea_Action = cgiGet( edtavActualizartarea_action_Internalname);
            AV35AgregarEtiqueta_Action = cgiGet( edtavAgregaretiqueta_action_Internalname);
            AV37AgregarComentario_Action = cgiGet( edtavAgregarcomentario_action_Internalname);
            AV38CrearActividad_Action = cgiGet( edtavCrearactividad_action_Internalname);
            AV36InformacionTarea_Action = cgiGet( edtavInformaciontarea_action_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRGESTIONTAREAS_ID");
               GX_FocusControl = edtavTrgestiontareas_id_Internalname;
               wbErr = true;
               AV33TrGestionTareas_ID = 0;
            }
            else
            {
               AV33TrGestionTareas_ID = (long)(context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_Internalname), ".", ","));
            }
            if ( StringUtil.StrCmp(cgiGet( edtavTrgestiontareas_idtablero_Internalname), "") == 0 )
            {
               AV28TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
            }
            else
            {
               try
               {
                  AV28TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( edtavTrgestiontareas_idtablero_Internalname)));
               }
               catch ( Exception e )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vTRGESTIONTAREAS_IDTABLERO");
                  GX_FocusControl = edtavTrgestiontareas_idtablero_Internalname;
                  wbErr = true;
               }
            }
            AV27TrGestionTareas_Nombre = cgiGet( edtavTrgestiontareas_nombre_Internalname);
            AV29TrGestionTareas_Descripcion = cgiGet( edtavTrgestiontareas_descripcion_Internalname);
            if ( context.localUtil.VCDateTime( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 0, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Inicio"}), 1, "vTRGESTIONTAREAS_FECHAINICIO");
               GX_FocusControl = edtavTrgestiontareas_fechainicio_Internalname;
               wbErr = true;
               AV30TrGestionTareas_FechaInicio = (DateTime)(DateTime.MinValue);
            }
            else
            {
               AV30TrGestionTareas_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 0, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Fin"}), 1, "vTRGESTIONTAREAS_FECHAFIN");
               GX_FocusControl = edtavTrgestiontareas_fechafin_Internalname;
               wbErr = true;
               AV31TrGestionTareas_FechaFin = (DateTime)(DateTime.MinValue);
            }
            else
            {
               AV31TrGestionTareas_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 0));
            }
            cmbavTrgestiontareas_estado.Name = cmbavTrgestiontareas_estado_Internalname;
            cmbavTrgestiontareas_estado.CurrentValue = cgiGet( cmbavTrgestiontareas_estado_Internalname);
            AV32TrGestionTareas_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTrgestiontareas_estado_Internalname), "."));
            if ( AV33TrGestionTareas_ID == AV50GridKey_TrGestionTareas_ID )
            {
               /* Execute user subroutine: 'U_ELIMINARTAREA' */
               S282 ();
               if (returnInSub) return;
            }
            /* End For Each Line */
         }
         if ( nGXsfl_140_fel_idx == 0 )
         {
            nGXsfl_140_idx = 1;
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1402( ) ;
         }
         nGXsfl_140_fel_idx = 1;
      }

      protected void wb_table6_184_1X2( bool wbgen )
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
            wb_table7_187_1X2( true) ;
         }
         else
         {
            wb_table7_187_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table7_187_1X2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_184_1X2e( true) ;
         }
         else
         {
            wb_table6_184_1X2e( false) ;
         }
      }

      protected void wb_table7_187_1X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSection_condconf_dialog_Internalname, tblSection_condconf_dialog_Internalname, "", "Section_CondConf_Dialog", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table8_190_1X2( true) ;
         }
         else
         {
            wb_table8_190_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table8_190_1X2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_187_1X2e( true) ;
         }
         else
         {
            wb_table7_187_1X2e( false) ;
         }
      }

      protected void wb_table8_190_1X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'" + sGXsfl_140_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfirmmessage_Internalname, StringUtil.RTrim( AV47ConfirmMessage), StringUtil.RTrim( context.localUtil.Format( AV47ConfirmMessage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfirmmessage_Jsonclick, 0, "Attribute_ConditionalConfirm", "", "", "", "", 1, edtavConfirmmessage_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpListadoTareasPorTablero.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table9_197_1X2( true) ;
         }
         else
         {
            wb_table9_197_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table9_197_1X2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_190_1X2e( true) ;
         }
         else
         {
            wb_table8_190_1X2e( false) ;
         }
      }

      protected void wb_table9_197_1X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblConfirm_hidden_actionstable_Internalname, tblConfirm_hidden_actionstable_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction_Confirm";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmyes_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(140), 3, 0)+","+"null"+");", "Aceptar", bttI_buttonconfirmyes_Jsonclick, 5, "Aceptar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMYES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmno_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(140), 3, 0)+","+"null"+");", "Cancelar", bttI_buttonconfirmno_Jsonclick, 7, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e241x1_client"+"'", TempTags, "", 2, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_197_1X2e( true) ;
         }
         else
         {
            wb_table9_197_1X2e( false) ;
         }
      }

      protected void wb_table5_163_1X2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "&laquo;", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e251x1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 1, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_firstpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_firstpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e261x1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingleftcellgrid_Internalname+"\"  class='"+cellPaginationbar_spacingleftcellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagecellgrid_Internalname+"\"  class='"+cellPaginationbar_previouspagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e251x1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_currentpagecellgrid_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_nextpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e271x1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingrightcellgrid_Internalname+"\"  class='"+cellPaginationbar_spacingrightcellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagebuttoncellgrid_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "&raquo;", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e271x1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 1, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_163_1X2e( true) ;
         }
         else
         {
            wb_table5_163_1X2e( false) ;
         }
      }

      protected void wb_table4_156_1X2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_156_1X2e( true) ;
         }
         else
         {
            wb_table4_156_1X2e( false) ;
         }
      }

      protected void wb_table3_76_1X2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_Internalname, "", "", "", lblGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e281x1_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WpListadoTareasPorTablero.htm");
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
            wb_table10_88_1X2( true) ;
         }
         else
         {
            wb_table10_88_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table10_88_1X2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(140), 3, 0)+","+"null"+");", "Guardar", bttGridsettings_savegrid_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpListadoTareasPorTablero.htm");
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
            wb_table3_76_1X2e( true) ;
         }
         else
         {
            wb_table3_76_1X2e( false) ;
         }
      }

      protected void wb_table10_88_1X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_Internalname, tblGridsettings_tablecontentgrid_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_Internalname, "Filas por página", "", "", lblGridsettings_rowsperpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, "Grid Settings Rows Per Page_Grid", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_140_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Filas por página", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "", true, "HLP_WpListadoTareasPorTablero.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_88_1X2e( true) ;
         }
         else
         {
            wb_table10_88_1X2e( false) ;
         }
      }

      protected void wb_table2_61_1X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridtitlecontainertable_grid_Internalname, tblGridtitlecontainertable_grid_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridtitle_grid_Internalname, "Lista de tareas", "", "", lblGridtitle_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_61_1X2e( true) ;
         }
         else
         {
            wb_table2_61_1X2e( false) ;
         }
      }

      protected void wb_table1_52_1X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableright_actions_Internalname, tblActionscontainertableright_actions_Internalname, "", "K2BTableActionsRightContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = imgListatableros_Bitmap;
            GxWebStd.gx_bitmap( context, imgListatableros_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "Lista Tableros", imgListatableros_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 5, imgListatableros_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'E_LISTATABLEROS\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_52_1X2e( true) ;
         }
         else
         {
            wb_table1_52_1X2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12TrGestionTableros_ID = (Guid)((Guid)getParm(obj,0));
         AssignAttri("", false, "AV12TrGestionTableros_ID", AV12TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV12TrGestionTableros_ID, context));
         AV13TrGestionTableros_Nombre = (String)getParm(obj,1);
         AssignAttri("", false, "AV13TrGestionTableros_Nombre", AV13TrGestionTableros_Nombre);
         AV14TrGestionTableros_FechaInicio = (DateTime)getParm(obj,2);
         AssignAttri("", false, "AV14TrGestionTableros_FechaInicio", context.localUtil.Format(AV14TrGestionTableros_FechaInicio, "99/99/9999"));
         AV15TrGestionTableros_FechaFin = (DateTime)getParm(obj,3);
         AssignAttri("", false, "AV15TrGestionTableros_FechaFin", context.localUtil.Format(AV15TrGestionTableros_FechaFin, "99/99/9999"));
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
         PA1X2( ) ;
         WS1X2( ) ;
         WE1X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20221022122873", true, true);
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
         context.AddJavascriptSource("wplistadotareasportablero.js", "?20221022122873", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1402( )
      {
         edtavEliminartarea_action_Internalname = "vELIMINARTAREA_ACTION_"+sGXsfl_140_idx;
         edtavActualizartarea_action_Internalname = "vACTUALIZARTAREA_ACTION_"+sGXsfl_140_idx;
         edtavAgregaretiqueta_action_Internalname = "vAGREGARETIQUETA_ACTION_"+sGXsfl_140_idx;
         edtavAgregarcomentario_action_Internalname = "vAGREGARCOMENTARIO_ACTION_"+sGXsfl_140_idx;
         edtavCrearactividad_action_Internalname = "vCREARACTIVIDAD_ACTION_"+sGXsfl_140_idx;
         edtavInformaciontarea_action_Internalname = "vINFORMACIONTAREA_ACTION_"+sGXsfl_140_idx;
         edtavTrgestiontareas_id_Internalname = "vTRGESTIONTAREAS_ID_"+sGXsfl_140_idx;
         edtavTrgestiontareas_idtablero_Internalname = "vTRGESTIONTAREAS_IDTABLERO_"+sGXsfl_140_idx;
         edtavTrgestiontareas_nombre_Internalname = "vTRGESTIONTAREAS_NOMBRE_"+sGXsfl_140_idx;
         edtavTrgestiontareas_descripcion_Internalname = "vTRGESTIONTAREAS_DESCRIPCION_"+sGXsfl_140_idx;
         edtavTrgestiontareas_fechainicio_Internalname = "vTRGESTIONTAREAS_FECHAINICIO_"+sGXsfl_140_idx;
         edtavTrgestiontareas_fechafin_Internalname = "vTRGESTIONTAREAS_FECHAFIN_"+sGXsfl_140_idx;
         cmbavTrgestiontareas_estado_Internalname = "vTRGESTIONTAREAS_ESTADO_"+sGXsfl_140_idx;
      }

      protected void SubsflControlProps_fel_1402( )
      {
         edtavEliminartarea_action_Internalname = "vELIMINARTAREA_ACTION_"+sGXsfl_140_fel_idx;
         edtavActualizartarea_action_Internalname = "vACTUALIZARTAREA_ACTION_"+sGXsfl_140_fel_idx;
         edtavAgregaretiqueta_action_Internalname = "vAGREGARETIQUETA_ACTION_"+sGXsfl_140_fel_idx;
         edtavAgregarcomentario_action_Internalname = "vAGREGARCOMENTARIO_ACTION_"+sGXsfl_140_fel_idx;
         edtavCrearactividad_action_Internalname = "vCREARACTIVIDAD_ACTION_"+sGXsfl_140_fel_idx;
         edtavInformaciontarea_action_Internalname = "vINFORMACIONTAREA_ACTION_"+sGXsfl_140_fel_idx;
         edtavTrgestiontareas_id_Internalname = "vTRGESTIONTAREAS_ID_"+sGXsfl_140_fel_idx;
         edtavTrgestiontareas_idtablero_Internalname = "vTRGESTIONTAREAS_IDTABLERO_"+sGXsfl_140_fel_idx;
         edtavTrgestiontareas_nombre_Internalname = "vTRGESTIONTAREAS_NOMBRE_"+sGXsfl_140_fel_idx;
         edtavTrgestiontareas_descripcion_Internalname = "vTRGESTIONTAREAS_DESCRIPCION_"+sGXsfl_140_fel_idx;
         edtavTrgestiontareas_fechainicio_Internalname = "vTRGESTIONTAREAS_FECHAINICIO_"+sGXsfl_140_fel_idx;
         edtavTrgestiontareas_fechafin_Internalname = "vTRGESTIONTAREAS_FECHAFIN_"+sGXsfl_140_fel_idx;
         cmbavTrgestiontareas_estado_Internalname = "vTRGESTIONTAREAS_ESTADO_"+sGXsfl_140_fel_idx;
      }

      protected void sendrow_1402( )
      {
         SubsflControlProps_1402( ) ;
         WB1X0( ) ;
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
            if ( ((int)((nGXsfl_140_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_140_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavEliminartarea_action_Enabled!=0)&&(edtavEliminartarea_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 141,'',false,'',140)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV46EliminarTarea_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV46EliminarTarea_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV57Eliminartarea_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV46EliminarTarea_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV46EliminarTarea_Action)) ? AV57Eliminartarea_action_GXI : context.PathToRelativeUrl( AV46EliminarTarea_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavEliminartarea_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Eliminar Tarea",(String)edtavEliminartarea_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavEliminartarea_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_ELIMINARTAREA\\'."+sGXsfl_140_idx+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV46EliminarTarea_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavActualizartarea_action_Enabled!=0)&&(edtavActualizartarea_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 142,'',false,'',140)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV34ActualizarTarea_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV34ActualizarTarea_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV58Actualizartarea_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV34ActualizarTarea_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV34ActualizarTarea_Action)) ? AV58Actualizartarea_action_GXI : context.PathToRelativeUrl( AV34ActualizarTarea_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavActualizartarea_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Actualizar Tarea",(String)edtavActualizartarea_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)7,(String)edtavActualizartarea_action_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+"e291x2_client"+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV34ActualizarTarea_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavAgregaretiqueta_action_Enabled!=0)&&(edtavAgregaretiqueta_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 143,'',false,'',140)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV35AgregarEtiqueta_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV35AgregarEtiqueta_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV59Agregaretiqueta_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV35AgregarEtiqueta_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV35AgregarEtiqueta_Action)) ? AV59Agregaretiqueta_action_GXI : context.PathToRelativeUrl( AV35AgregarEtiqueta_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavAgregaretiqueta_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Agregar Etiqueta",(String)edtavAgregaretiqueta_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavAgregaretiqueta_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_AGREGARETIQUETA\\'."+sGXsfl_140_idx+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV35AgregarEtiqueta_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavAgregarcomentario_action_Enabled!=0)&&(edtavAgregarcomentario_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 144,'',false,'',140)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV37AgregarComentario_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV37AgregarComentario_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV60Agregarcomentario_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV37AgregarComentario_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37AgregarComentario_Action)) ? AV60Agregarcomentario_action_GXI : context.PathToRelativeUrl( AV37AgregarComentario_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavAgregarcomentario_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Agregar Comentario",(String)edtavAgregarcomentario_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavAgregarcomentario_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_AGREGARCOMENTARIO\\'."+sGXsfl_140_idx+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV37AgregarComentario_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavCrearactividad_action_Enabled!=0)&&(edtavCrearactividad_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 145,'',false,'',140)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV38CrearActividad_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV38CrearActividad_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV61Crearactividad_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV38CrearActividad_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38CrearActividad_Action)) ? AV61Crearactividad_action_GXI : context.PathToRelativeUrl( AV38CrearActividad_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavCrearactividad_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Crear Actividad",(String)edtavCrearactividad_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavCrearactividad_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_CREARACTIVIDAD\\'."+sGXsfl_140_idx+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV38CrearActividad_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavInformaciontarea_action_Enabled!=0)&&(edtavInformaciontarea_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 146,'',false,'',140)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV36InformacionTarea_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV36InformacionTarea_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV62Informaciontarea_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV36InformacionTarea_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV36InformacionTarea_Action)) ? AV62Informaciontarea_action_GXI : context.PathToRelativeUrl( AV36InformacionTarea_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavInformaciontarea_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Informacion Tarea",(String)edtavInformaciontarea_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)7,(String)edtavInformaciontarea_action_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+"e301x2_client"+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV36InformacionTarea_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_id_Enabled!=0)&&(edtavTrgestiontareas_id_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 147,'',false,'"+sGXsfl_140_idx+"',140)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_id_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TrGestionTareas_ID), 13, 0, ".", "")),((edtavTrgestiontareas_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_id_Enabled!=0)&&(edtavTrgestiontareas_id_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,147);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_id_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_id_Enabled,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)140,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_idtablero_Enabled!=0)&&(edtavTrgestiontareas_idtablero_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 148,'',false,'"+sGXsfl_140_idx+"',140)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_idtablero_Internalname,AV28TrGestionTareas_IDTablero.ToString(),AV28TrGestionTareas_IDTablero.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_idtablero_Enabled!=0)&&(edtavTrgestiontareas_idtablero_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,148);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_idtablero_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)0,(int)edtavTrgestiontareas_idtablero_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)36,(short)0,(short)0,(short)140,(short)1,(short)0,(short)0,(bool)true,(String)"",(String)"",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_nombre_Enabled!=0)&&(edtavTrgestiontareas_nombre_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 149,'',false,'"+sGXsfl_140_idx+"',140)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_nombre_Internalname,StringUtil.RTrim( AV27TrGestionTareas_Nombre),(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_nombre_Enabled!=0)&&(edtavTrgestiontareas_nombre_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,149);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_nombre_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_nombre_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)140,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_descripcion_Enabled!=0)&&(edtavTrgestiontareas_descripcion_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 150,'',false,'"+sGXsfl_140_idx+"',140)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_descripcion_Internalname,(String)AV29TrGestionTareas_Descripcion,(String)AV29TrGestionTareas_Descripcion,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_descripcion_Enabled!=0)&&(edtavTrgestiontareas_descripcion_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,150);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_descripcion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_descripcion_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)140,(short)1,(short)0,(short)-1,(bool)true,(String)"",(String)"left",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_fechainicio_Enabled!=0)&&(edtavTrgestiontareas_fechainicio_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 151,'',false,'"+sGXsfl_140_idx+"',140)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_fechainicio_Internalname,context.localUtil.Format(AV30TrGestionTareas_FechaInicio, "99/99/9999"),context.localUtil.Format( AV30TrGestionTareas_FechaInicio, "99/99/9999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_fechainicio_Enabled!=0)&&(edtavTrgestiontareas_fechainicio_Visible!=0) ? " onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,151);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_fechainicio_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_fechainicio_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)140,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_fechafin_Enabled!=0)&&(edtavTrgestiontareas_fechafin_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 152,'',false,'"+sGXsfl_140_idx+"',140)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_fechafin_Internalname,context.localUtil.Format(AV31TrGestionTareas_FechaFin, "99/99/9999"),context.localUtil.Format( AV31TrGestionTareas_FechaFin, "99/99/9999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_fechafin_Enabled!=0)&&(edtavTrgestiontareas_fechafin_Visible!=0) ? " onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,152);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_fechafin_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_fechafin_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)140,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         TempTags = " " + ((cmbavTrgestiontareas_estado.Enabled!=0)&&(cmbavTrgestiontareas_estado.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 153,'',false,'"+sGXsfl_140_idx+"',140)\"" : " ");
         if ( ( cmbavTrgestiontareas_estado.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vTRGESTIONTAREAS_ESTADO_" + sGXsfl_140_idx;
            cmbavTrgestiontareas_estado.Name = GXCCtl;
            cmbavTrgestiontareas_estado.WebTags = "";
            cmbavTrgestiontareas_estado.addItem("1", "Nuevo", 0);
            cmbavTrgestiontareas_estado.addItem("2", "En Progreso", 0);
            cmbavTrgestiontareas_estado.addItem("3", "Completado", 0);
            cmbavTrgestiontareas_estado.addItem("4", "Detenido", 0);
            cmbavTrgestiontareas_estado.addItem("5", "Pendiente", 0);
            if ( cmbavTrgestiontareas_estado.ItemCount > 0 )
            {
               AV32TrGestionTareas_Estado = (short)(NumberUtil.Val( cmbavTrgestiontareas_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV32TrGestionTareas_Estado), 4, 0))), "."));
               AssignAttri("", false, cmbavTrgestiontareas_estado_Internalname, StringUtil.LTrimStr( (decimal)(AV32TrGestionTareas_Estado), 4, 0));
            }
         }
         /* ComboBox */
         GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavTrgestiontareas_estado,(String)cmbavTrgestiontareas_estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV32TrGestionTareas_Estado), 4, 0)),(short)1,(String)cmbavTrgestiontareas_estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,cmbavTrgestiontareas_estado.Enabled,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute_Grid",(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavTrgestiontareas_estado.Enabled!=0)&&(cmbavTrgestiontareas_estado.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,153);\"" : " "),(String)"",(bool)true});
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32TrGestionTareas_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", (String)(cmbavTrgestiontareas_estado.ToJavascriptSource()), !bGXsfl_140_Refreshing);
         send_integrity_lvl_hashes1X2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_140_idx = ((subGrid_Islastpage==1)&&(nGXsfl_140_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_idx+1);
         sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
         SubsflControlProps_1402( ) ;
         /* End function sendrow_1402 */
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
            AV26GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0));
         }
         GXCCtl = "vTRGESTIONTAREAS_ESTADO_" + sGXsfl_140_idx;
         cmbavTrgestiontareas_estado.Name = GXCCtl;
         cmbavTrgestiontareas_estado.WebTags = "";
         cmbavTrgestiontareas_estado.addItem("1", "Nuevo", 0);
         cmbavTrgestiontareas_estado.addItem("2", "En Progreso", 0);
         cmbavTrgestiontareas_estado.addItem("3", "Completado", 0);
         cmbavTrgestiontareas_estado.addItem("4", "Detenido", 0);
         cmbavTrgestiontareas_estado.addItem("5", "Pendiente", 0);
         if ( cmbavTrgestiontareas_estado.ItemCount > 0 )
         {
            AV32TrGestionTareas_Estado = (short)(NumberUtil.Val( cmbavTrgestiontareas_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV32TrGestionTareas_Estado), 4, 0))), "."));
            AssignAttri("", false, cmbavTrgestiontareas_estado_Internalname, StringUtil.LTrimStr( (decimal)(AV32TrGestionTareas_Estado), 4, 0));
         }
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
         imgListatableros_Internalname = "LISTATABLEROS";
         tblActionscontainertableright_actions_Internalname = "ACTIONSCONTAINERTABLERIGHT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
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
         edtavTrgestiontareas_nombre_filter_Internalname = "vTRGESTIONTAREAS_NOMBRE_FILTER";
         divTable_container_trgestiontareas_nombre_filter_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_NOMBRE_FILTER";
         edtavTrgestiontareas_id_filter_Internalname = "vTRGESTIONTAREAS_ID_FILTER";
         divTable_container_trgestiontareas_id_filter_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_ID_FILTER";
         divFiltercontainertable_filters_Internalname = "FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = "MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname = "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID";
         divLayoutdefined_combinedfilterlayout_grid_Internalname = "LAYOUTDEFINED_COMBINEDFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         edtavEliminartarea_action_Internalname = "vELIMINARTAREA_ACTION";
         edtavActualizartarea_action_Internalname = "vACTUALIZARTAREA_ACTION";
         edtavAgregaretiqueta_action_Internalname = "vAGREGARETIQUETA_ACTION";
         edtavAgregarcomentario_action_Internalname = "vAGREGARCOMENTARIO_ACTION";
         edtavCrearactividad_action_Internalname = "vCREARACTIVIDAD_ACTION";
         edtavInformaciontarea_action_Internalname = "vINFORMACIONTAREA_ACTION";
         edtavTrgestiontareas_id_Internalname = "vTRGESTIONTAREAS_ID";
         edtavTrgestiontareas_idtablero_Internalname = "vTRGESTIONTAREAS_IDTABLERO";
         edtavTrgestiontareas_nombre_Internalname = "vTRGESTIONTAREAS_NOMBRE";
         edtavTrgestiontareas_descripcion_Internalname = "vTRGESTIONTAREAS_DESCRIPCION";
         edtavTrgestiontareas_fechainicio_Internalname = "vTRGESTIONTAREAS_FECHAINICIO";
         edtavTrgestiontareas_fechafin_Internalname = "vTRGESTIONTAREAS_FECHAFIN";
         cmbavTrgestiontareas_estado_Internalname = "vTRGESTIONTAREAS_ESTADO";
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
         cmbavTrgestiontareas_estado_Jsonclick = "";
         cmbavTrgestiontareas_estado.Visible = -1;
         edtavTrgestiontareas_fechafin_Jsonclick = "";
         edtavTrgestiontareas_fechafin_Visible = -1;
         edtavTrgestiontareas_fechainicio_Jsonclick = "";
         edtavTrgestiontareas_fechainicio_Visible = -1;
         edtavTrgestiontareas_descripcion_Jsonclick = "";
         edtavTrgestiontareas_descripcion_Visible = -1;
         edtavTrgestiontareas_nombre_Jsonclick = "";
         edtavTrgestiontareas_nombre_Visible = -1;
         edtavTrgestiontareas_idtablero_Jsonclick = "";
         edtavTrgestiontareas_idtablero_Visible = 0;
         edtavTrgestiontareas_id_Jsonclick = "";
         edtavTrgestiontareas_id_Visible = -1;
         edtavInformaciontarea_action_Jsonclick = "";
         edtavInformaciontarea_action_Visible = -1;
         edtavInformaciontarea_action_Enabled = 1;
         edtavCrearactividad_action_Jsonclick = "";
         edtavCrearactividad_action_Visible = -1;
         edtavCrearactividad_action_Enabled = 1;
         edtavAgregarcomentario_action_Jsonclick = "";
         edtavAgregarcomentario_action_Visible = -1;
         edtavAgregarcomentario_action_Enabled = 1;
         edtavAgregaretiqueta_action_Jsonclick = "";
         edtavAgregaretiqueta_action_Visible = -1;
         edtavAgregaretiqueta_action_Enabled = 1;
         edtavActualizartarea_action_Jsonclick = "";
         edtavActualizartarea_action_Visible = -1;
         edtavActualizartarea_action_Enabled = 1;
         edtavEliminartarea_action_Jsonclick = "";
         edtavEliminartarea_action_Visible = -1;
         edtavEliminartarea_action_Enabled = 1;
         imgListatableros_Bitmap = (String)(context.GetImagePath( "dc7fa476-057a-4183-b3c2-d6a8394cb2a4", "", context.GetTheme( )));
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
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
         cellPaginationbar_previouspagecellgrid_Class = "K2BToolsCell_PaginationPrevious";
         cellPaginationbar_spacingleftcellgrid_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
         cellPaginationbar_firstpagecellgrid_Class = "K2BToolsCell_PaginationLeft";
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_nextpagetextblockgrid_Caption = "#";
         lblPaginationbar_currentpagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Caption = "#";
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         imgListatableros_Tooltiptext = "Lista Tableros";
         tblTableconditionalconfirm_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavInformaciontarea_action_Tooltiptext = "";
         edtavCrearactividad_action_Tooltiptext = "";
         edtavAgregarcomentario_action_Tooltiptext = "";
         edtavAgregaretiqueta_action_Tooltiptext = "";
         edtavActualizartarea_action_Tooltiptext = "";
         edtavEliminartarea_action_Tooltiptext = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         cmbavTrgestiontareas_estado.Enabled = 1;
         edtavTrgestiontareas_fechafin_Enabled = 1;
         edtavTrgestiontareas_fechainicio_Enabled = 1;
         edtavTrgestiontareas_descripcion_Enabled = 1;
         edtavTrgestiontareas_nombre_Enabled = 1;
         edtavTrgestiontareas_idtablero_Enabled = 1;
         edtavTrgestiontareas_id_Enabled = 1;
         subGrid_Class = "Grid";
         subGrid_Backcolorstyle = 0;
         edtavTrgestiontareas_id_filter_Jsonclick = "";
         edtavTrgestiontareas_id_filter_Enabled = 1;
         edtavTrgestiontareas_nombre_filter_Jsonclick = "";
         edtavTrgestiontareas_nombre_filter_Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 1;
         lblLayoutdefined_filtersummary_combined_grid_Caption = "Filter Summary";
         imgLayoutdefined_filtertoggle_combined_grid_Bitmap = (String)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavGenericfilter_grid_Jsonclick = "";
         edtavGenericfilter_grid_Enabled = 1;
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
         Form.Caption = "Listado de tareas por tablero";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E261X1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E181X2',iparms:[{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'lblLayoutdefined_filtersummary_combined_grid_Caption',ctrl:'LAYOUTDEFINED_FILTERSUMMARY_COMBINED_GRID',prop:'Caption'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E191X2',iparms:[{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV28TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:'',hsh:true},{av:'AV27TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV29TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV30TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV31TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV32TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV46EliminarTarea_Action',fld:'vELIMINARTAREA_ACTION',pic:''},{av:'edtavEliminartarea_action_Tooltiptext',ctrl:'vELIMINARTAREA_ACTION',prop:'Tooltiptext'},{av:'AV34ActualizarTarea_Action',fld:'vACTUALIZARTAREA_ACTION',pic:''},{av:'edtavActualizartarea_action_Tooltiptext',ctrl:'vACTUALIZARTAREA_ACTION',prop:'Tooltiptext'},{av:'AV35AgregarEtiqueta_Action',fld:'vAGREGARETIQUETA_ACTION',pic:''},{av:'edtavAgregaretiqueta_action_Tooltiptext',ctrl:'vAGREGARETIQUETA_ACTION',prop:'Tooltiptext'},{av:'AV37AgregarComentario_Action',fld:'vAGREGARCOMENTARIO_ACTION',pic:''},{av:'edtavAgregarcomentario_action_Tooltiptext',ctrl:'vAGREGARCOMENTARIO_ACTION',prop:'Tooltiptext'},{av:'AV38CrearActividad_Action',fld:'vCREARACTIVIDAD_ACTION',pic:''},{av:'edtavCrearactividad_action_Tooltiptext',ctrl:'vCREARACTIVIDAD_ACTION',prop:'Tooltiptext'},{av:'AV36InformacionTarea_Action',fld:'vINFORMACIONTAREA_ACTION',pic:''},{av:'edtavInformaciontarea_action_Tooltiptext',ctrl:'vINFORMACIONTAREA_ACTION',prop:'Tooltiptext'},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E271X1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E251X1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E281X1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV26GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E111X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV26GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("'E_ACTUALIZARTAREA'","{handler:'E291X2',iparms:[{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV28TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:'',hsh:true}]");
         setEventMetadata("'E_ACTUALIZARTAREA'",",oparms:[]}");
         setEventMetadata("'E_AGREGARETIQUETA'","{handler:'E201X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'E_AGREGARETIQUETA'",",oparms:[{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("'E_INFORMACIONTAREA'","{handler:'E301X2',iparms:[{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_INFORMACIONTAREA'",",oparms:[]}");
         setEventMetadata("'E_AGREGARCOMENTARIO'","{handler:'E211X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'E_AGREGARCOMENTARIO'",",oparms:[{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("'E_LISTATABLEROS'","{handler:'E121X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'E_LISTATABLEROS'",",oparms:[{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("'E_CREARACTIVIDAD'","{handler:'E221X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'E_CREARACTIVIDAD'",",oparms:[{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK","{handler:'E131X2',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK","{handler:'E141X2',iparms:[]");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]}");
         setEventMetadata("'E_ELIMINARTAREA'","{handler:'E231X2',iparms:[{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'E_ELIMINARTAREA'",",oparms:[{av:'AV47ConfirmMessage',fld:'vCONFIRMMESSAGE',pic:''},{av:'AV49ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'AV50GridKey_TrGestionTareas_ID',fld:'vGRIDKEY_TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("'CONFIRMNO'","{handler:'E241X1',iparms:[]");
         setEventMetadata("'CONFIRMNO'",",oparms:[{av:'AV49ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'}]}");
         setEventMetadata("'CONFIRMYES'","{handler:'E151X2',iparms:[{av:'AV49ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',grid:140,pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_140',ctrl:'GRID',grid:140,prop:'GridRC'},{av:'AV50GridKey_TrGestionTareas_ID',fld:'vGRIDKEY_TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'GRID_nEOF'},{av:'AV43TrGestionTareas_Nombre_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER_PREVIOUSVALUE',pic:''},{av:'AV42TrGestionTareas_Nombre_Filter',fld:'vTRGESTIONTAREAS_NOMBRE_FILTER',pic:''},{av:'AV45TrGestionTareas_ID_Filter_PreviousValue',fld:'vTRGESTIONTAREAS_ID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZZ9'},{av:'AV44TrGestionTareas_ID_Filter',fld:'vTRGESTIONTAREAS_ID_FILTER',pic:'ZZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV41GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV52TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'CONFIRMYES'",",oparms:[{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV51GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV48ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'imgListatableros_Tooltiptext',ctrl:'LISTATABLEROS',prop:'Tooltiptext'}]}");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_ID","{handler:'Validv_Trgestiontableros_id',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTABLEROS_ID",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_IDTABLERO","{handler:'Validv_Trgestiontareas_idtablero',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_IDTABLERO",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAINICIO","{handler:'Validv_Trgestiontareas_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAFIN","{handler:'Validv_Trgestiontareas_fechafin',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_ESTADO","{handler:'Validv_Trgestiontareas_estado',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_ESTADO",",oparms:[]}");
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
         wcpOAV12TrGestionTableros_ID = (Guid)(Guid.Empty);
         wcpOAV13TrGestionTableros_Nombre = "";
         wcpOAV14TrGestionTableros_FechaInicio = DateTime.MinValue;
         wcpOAV15TrGestionTableros_FechaFin = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV43TrGestionTareas_Nombre_Filter_PreviousValue = "";
         AV42TrGestionTareas_Nombre_Filter = "";
         AV55Pgmname = "";
         AV41GenericFilter_Grid = "";
         A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         A13TrGestionTareas_Nombre = "";
         A14TrGestionTareas_Descripcion = "";
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
         AV51GestionTareas_SDT = new SdtGestionTareas_SDT(context);
         AV52TrComentarioTarea_SDT = new SdtTrComentarioTarea_SDT(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV49ConfirmationSubId = "";
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
         TempTags = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_combined_grid_Jsonclick = "";
         lblLayoutdefined_filtersummary_combined_grid_Jsonclick = "";
         imgLayoutdefined_filterclose_combined_grid_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV46EliminarTarea_Action = "";
         AV34ActualizarTarea_Action = "";
         AV35AgregarEtiqueta_Action = "";
         AV37AgregarComentario_Action = "";
         AV38CrearActividad_Action = "";
         AV36InformacionTarea_Action = "";
         AV28TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         AV27TrGestionTareas_Nombre = "";
         AV29TrGestionTareas_Descripcion = "";
         AV30TrGestionTareas_FechaInicio = DateTime.MinValue;
         AV31TrGestionTareas_FechaFin = DateTime.MinValue;
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV57Eliminartarea_action_GXI = "";
         AV58Actualizartarea_action_GXI = "";
         AV59Agregaretiqueta_action_GXI = "";
         AV60Agregarcomentario_action_GXI = "";
         AV61Crearactividad_action_GXI = "";
         AV62Informaciontarea_action_GXI = "";
         AV47ConfirmMessage = "";
         scmdbuf = "";
         lV42TrGestionTareas_Nombre_Filter = "";
         lV41GenericFilter_Grid = "";
         H001X2_A14TrGestionTareas_Descripcion = new String[] {""} ;
         H001X2_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         H001X2_A12TrGestionTareas_ID = new long[1] ;
         H001X2_A13TrGestionTareas_Nombre = new String[] {""} ;
         H001X2_n13TrGestionTareas_Nombre = new bool[] {false} ;
         H001X2_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         H001X2_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H001X2_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         H001X2_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H001X2_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         H001X2_A24TrGestionTareas_Estado = new short[1] ;
         H001X2_n24TrGestionTareas_Estado = new bool[] {false} ;
         GridRow = new GXWebRow();
         AV16GridStateKey = "";
         AV17GridState = new SdtK2BGridState(context);
         AV18GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV39K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "TABLEROS_WEB");
         AV40K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
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
         lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick = "";
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         lblGridsettings_labelgrid_Jsonclick = "";
         bttGridsettings_savegrid_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgrid_Jsonclick = "";
         lblGridtitle_grid_Jsonclick = "";
         imgListatableros_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistadotareasportablero__default(),
            new Object[][] {
                new Object[] {
               H001X2_A14TrGestionTareas_Descripcion, H001X2_n14TrGestionTareas_Descripcion, H001X2_A12TrGestionTareas_ID, H001X2_A13TrGestionTareas_Nombre, H001X2_n13TrGestionTareas_Nombre, H001X2_A11TrGestionTareas_IDTablero, H001X2_A15TrGestionTareas_FechaInicio, H001X2_n15TrGestionTareas_FechaInicio, H001X2_A16TrGestionTareas_FechaFin, H001X2_n16TrGestionTareas_FechaFin,
               H001X2_A24TrGestionTareas_Estado, H001X2_n24TrGestionTareas_Estado
               }
            }
         );
         AV55Pgmname = "WpListadoTareasPorTablero";
         /* GeneXus formulas. */
         AV55Pgmname = "WpListadoTareasPorTablero";
         context.Gx_err = 0;
         edtavTrgestiontableros_id_Enabled = 0;
         edtavTrgestiontableros_nombre_Enabled = 0;
         edtavTrgestiontableros_fechainicio_Enabled = 0;
         edtavTrgestiontableros_fechafin_Enabled = 0;
         edtavTrgestiontareas_id_Enabled = 0;
         edtavTrgestiontareas_idtablero_Enabled = 0;
         edtavTrgestiontareas_nombre_Enabled = 0;
         edtavTrgestiontareas_descripcion_Enabled = 0;
         edtavTrgestiontareas_fechainicio_Enabled = 0;
         edtavTrgestiontareas_fechafin_Enabled = 0;
         cmbavTrgestiontareas_estado.Enabled = 0;
         edtavConfirmmessage_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19CurrentPage_Grid ;
      private short A24TrGestionTareas_Estado ;
      private short AV24RowsPerPage_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV32TrGestionTareas_Estado ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV26GridSettingsRowsPerPage_Grid ;
      private short GRID_nEOF ;
      private short AV22I_LoadCount_Grid ;
      private short AV56GXLvl179 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int divGridsettings_contentoutertablegrid_Visible ;
      private int divLayoutdefined_filtercollapsiblesection_combined_grid_Visible ;
      private int nRC_GXsfl_140 ;
      private int nGXsfl_140_idx=1 ;
      private int edtavTrgestiontableros_id_Enabled ;
      private int edtavTrgestiontableros_nombre_Enabled ;
      private int edtavTrgestiontableros_fechainicio_Enabled ;
      private int edtavTrgestiontableros_fechafin_Enabled ;
      private int edtavGenericfilter_grid_Enabled ;
      private int edtavTrgestiontareas_nombre_filter_Enabled ;
      private int edtavTrgestiontareas_id_filter_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavTrgestiontareas_id_Enabled ;
      private int edtavTrgestiontareas_idtablero_Enabled ;
      private int edtavTrgestiontareas_nombre_Enabled ;
      private int edtavTrgestiontareas_descripcion_Enabled ;
      private int edtavTrgestiontareas_fechainicio_Enabled ;
      private int edtavTrgestiontareas_fechafin_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int edtavConfirmmessage_Enabled ;
      private int tblTableconditionalconfirm_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int tblPaginationbar_pagingcontainertablegrid_Visible ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV63GXV1 ;
      private int nGXsfl_140_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavEliminartarea_action_Enabled ;
      private int edtavEliminartarea_action_Visible ;
      private int edtavActualizartarea_action_Enabled ;
      private int edtavActualizartarea_action_Visible ;
      private int edtavAgregaretiqueta_action_Enabled ;
      private int edtavAgregaretiqueta_action_Visible ;
      private int edtavAgregarcomentario_action_Enabled ;
      private int edtavAgregarcomentario_action_Visible ;
      private int edtavCrearactividad_action_Enabled ;
      private int edtavCrearactividad_action_Visible ;
      private int edtavInformaciontarea_action_Enabled ;
      private int edtavInformaciontarea_action_Visible ;
      private int edtavTrgestiontareas_id_Visible ;
      private int edtavTrgestiontareas_idtablero_Visible ;
      private int edtavTrgestiontareas_nombre_Visible ;
      private int edtavTrgestiontareas_descripcion_Visible ;
      private int edtavTrgestiontareas_fechainicio_Visible ;
      private int edtavTrgestiontareas_fechafin_Visible ;
      private long AV45TrGestionTareas_ID_Filter_PreviousValue ;
      private long AV44TrGestionTareas_ID_Filter ;
      private long A12TrGestionTareas_ID ;
      private long AV33TrGestionTareas_ID ;
      private long AV50GridKey_TrGestionTareas_ID ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private String AV13TrGestionTableros_Nombre ;
      private String wcpOAV13TrGestionTableros_Nombre ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_140_idx="0001" ;
      private String AV43TrGestionTareas_Nombre_Filter_PreviousValue ;
      private String AV42TrGestionTareas_Nombre_Filter ;
      private String AV55Pgmname ;
      private String AV41GenericFilter_Grid ;
      private String A13TrGestionTareas_Nombre ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String AV49ConfirmationSubId ;
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
      private String divTable_container_trgestiontareas_nombre_filter_Internalname ;
      private String edtavTrgestiontareas_nombre_filter_Internalname ;
      private String edtavTrgestiontareas_nombre_filter_Jsonclick ;
      private String divTable_container_trgestiontareas_id_filter_Internalname ;
      private String edtavTrgestiontareas_id_filter_Internalname ;
      private String edtavTrgestiontareas_id_filter_Jsonclick ;
      private String divLayoutdefined_table3_grid_Internalname ;
      private String divMaingrid_responsivetable_grid_Internalname ;
      private String sStyleString ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String subGrid_Header ;
      private String edtavEliminartarea_action_Tooltiptext ;
      private String edtavActualizartarea_action_Tooltiptext ;
      private String edtavAgregaretiqueta_action_Tooltiptext ;
      private String edtavAgregarcomentario_action_Tooltiptext ;
      private String edtavCrearactividad_action_Tooltiptext ;
      private String edtavInformaciontarea_action_Tooltiptext ;
      private String AV27TrGestionTareas_Nombre ;
      private String divLayoutdefined_section8_grid_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavEliminartarea_action_Internalname ;
      private String edtavActualizartarea_action_Internalname ;
      private String edtavAgregaretiqueta_action_Internalname ;
      private String edtavAgregarcomentario_action_Internalname ;
      private String edtavCrearactividad_action_Internalname ;
      private String edtavInformaciontarea_action_Internalname ;
      private String edtavTrgestiontareas_id_Internalname ;
      private String edtavTrgestiontareas_idtablero_Internalname ;
      private String edtavTrgestiontareas_nombre_Internalname ;
      private String edtavTrgestiontareas_descripcion_Internalname ;
      private String edtavTrgestiontareas_fechainicio_Internalname ;
      private String edtavTrgestiontareas_fechafin_Internalname ;
      private String cmbavTrgestiontareas_estado_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_Internalname ;
      private String edtavConfirmmessage_Internalname ;
      private String AV47ConfirmMessage ;
      private String tblTableconditionalconfirm_Internalname ;
      private String divGridsettings_contentoutertablegrid_Internalname ;
      private String imgListatableros_Internalname ;
      private String imgListatableros_Tooltiptext ;
      private String lblPaginationbar_firstpagetextblockgrid_Caption ;
      private String lblPaginationbar_firstpagetextblockgrid_Internalname ;
      private String lblPaginationbar_previouspagetextblockgrid_Caption ;
      private String lblPaginationbar_previouspagetextblockgrid_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_Caption ;
      private String lblPaginationbar_currentpagetextblockgrid_Internalname ;
      private String lblPaginationbar_nextpagetextblockgrid_Caption ;
      private String lblPaginationbar_nextpagetextblockgrid_Internalname ;
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
      private String cellPaginationbar_spacingrightcellgrid_Class ;
      private String cellPaginationbar_spacingrightcellgrid_Internalname ;
      private String lblPaginationbar_spacingrighttextblockgrid_Internalname ;
      private String cellPaginationbar_nextpagecellgrid_Class ;
      private String cellPaginationbar_nextpagecellgrid_Internalname ;
      private String tblPaginationbar_pagingcontainertablegrid_Internalname ;
      private String tblI_noresultsfoundtablename_grid_Internalname ;
      private String scmdbuf ;
      private String lV42TrGestionTareas_Nombre_Filter ;
      private String lV41GenericFilter_Grid ;
      private String GXt_char1 ;
      private String sGXsfl_140_fel_idx="0001" ;
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
      private String tblActionscontainertableright_actions_Internalname ;
      private String imgListatableros_Jsonclick ;
      private String edtavEliminartarea_action_Jsonclick ;
      private String edtavActualizartarea_action_Jsonclick ;
      private String edtavAgregaretiqueta_action_Jsonclick ;
      private String edtavAgregarcomentario_action_Jsonclick ;
      private String edtavCrearactividad_action_Jsonclick ;
      private String edtavInformaciontarea_action_Jsonclick ;
      private String ROClassString ;
      private String edtavTrgestiontareas_id_Jsonclick ;
      private String edtavTrgestiontareas_idtablero_Jsonclick ;
      private String edtavTrgestiontareas_nombre_Jsonclick ;
      private String edtavTrgestiontareas_descripcion_Jsonclick ;
      private String edtavTrgestiontareas_fechainicio_Jsonclick ;
      private String edtavTrgestiontareas_fechafin_Jsonclick ;
      private String GXCCtl ;
      private String cmbavTrgestiontareas_estado_Jsonclick ;
      private DateTime AV14TrGestionTableros_FechaInicio ;
      private DateTime AV15TrGestionTableros_FechaFin ;
      private DateTime wcpOAV14TrGestionTableros_FechaInicio ;
      private DateTime wcpOAV15TrGestionTableros_FechaFin ;
      private DateTime A15TrGestionTareas_FechaInicio ;
      private DateTime A16TrGestionTareas_FechaFin ;
      private DateTime AV30TrGestionTareas_FechaInicio ;
      private DateTime AV31TrGestionTareas_FechaFin ;
      private bool entryPointCalled ;
      private bool AV23HasNextPage_Grid ;
      private bool n13TrGestionTareas_Nombre ;
      private bool n14TrGestionTareas_Descripcion ;
      private bool n15TrGestionTareas_FechaInicio ;
      private bool n16TrGestionTareas_FechaFin ;
      private bool n24TrGestionTareas_Estado ;
      private bool toggleJsOutput ;
      private bool AV48ConfirmationRequired ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_140_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV25RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV20Reload_Grid ;
      private bool AV21LoadRow_Grid ;
      private bool AV46EliminarTarea_Action_IsBlob ;
      private bool AV34ActualizarTarea_Action_IsBlob ;
      private bool AV35AgregarEtiqueta_Action_IsBlob ;
      private bool AV37AgregarComentario_Action_IsBlob ;
      private bool AV38CrearActividad_Action_IsBlob ;
      private bool AV36InformacionTarea_Action_IsBlob ;
      private String A14TrGestionTareas_Descripcion ;
      private String AV29TrGestionTareas_Descripcion ;
      private String AV57Eliminartarea_action_GXI ;
      private String AV58Actualizartarea_action_GXI ;
      private String AV59Agregaretiqueta_action_GXI ;
      private String AV60Agregarcomentario_action_GXI ;
      private String AV61Crearactividad_action_GXI ;
      private String AV62Informaciontarea_action_GXI ;
      private String AV16GridStateKey ;
      private String imgLayoutdefined_filtertoggle_combined_grid_Bitmap ;
      private String AV46EliminarTarea_Action ;
      private String AV34ActualizarTarea_Action ;
      private String AV35AgregarEtiqueta_Action ;
      private String AV37AgregarComentario_Action ;
      private String AV38CrearActividad_Action ;
      private String AV36InformacionTarea_Action ;
      private String imgListatableros_Bitmap ;
      private Guid AV12TrGestionTableros_ID ;
      private Guid wcpOAV12TrGestionTableros_ID ;
      private Guid A11TrGestionTareas_IDTablero ;
      private Guid AV28TrGestionTareas_IDTablero ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCombobox cmbavTrgestiontareas_estado ;
      private IDataStoreProvider pr_default ;
      private String[] H001X2_A14TrGestionTareas_Descripcion ;
      private bool[] H001X2_n14TrGestionTareas_Descripcion ;
      private long[] H001X2_A12TrGestionTareas_ID ;
      private String[] H001X2_A13TrGestionTareas_Nombre ;
      private bool[] H001X2_n13TrGestionTareas_Nombre ;
      private Guid[] H001X2_A11TrGestionTareas_IDTablero ;
      private DateTime[] H001X2_A15TrGestionTareas_FechaInicio ;
      private bool[] H001X2_n15TrGestionTareas_FechaInicio ;
      private DateTime[] H001X2_A16TrGestionTareas_FechaFin ;
      private bool[] H001X2_n16TrGestionTareas_FechaFin ;
      private short[] H001X2_A24TrGestionTareas_Estado ;
      private bool[] H001X2_n24TrGestionTareas_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV39K2BFilterValuesSDT_WebForm ;
      private GXWebForm Form ;
      private SdtK2BGridState AV17GridState ;
      private SdtK2BGridState_FilterValue AV18GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV40K2BFilterValuesSDTItem_WebForm ;
      private SdtGestionTareas_SDT AV51GestionTareas_SDT ;
      private SdtTrComentarioTarea_SDT AV52TrComentarioTarea_SDT ;
   }

   public class wplistadotareasportablero__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001X2( IGxContext context ,
                                             String AV42TrGestionTareas_Nombre_Filter ,
                                             long AV44TrGestionTareas_ID_Filter ,
                                             String AV41GenericFilter_Grid ,
                                             String A13TrGestionTareas_Nombre ,
                                             long A12TrGestionTareas_ID ,
                                             String A14TrGestionTareas_Descripcion ,
                                             Guid AV12TrGestionTableros_ID ,
                                             Guid A11TrGestionTareas_IDTablero )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int2 ;
         GXv_int2 = new short [5] ;
         Object[] GXv_Object3 ;
         GXv_Object3 = new Object [2] ;
         scmdbuf = "SELECT [TrGestionTareas_Descripcion], [TrGestionTareas_ID], [TrGestionTareas_Nombre], [TrGestionTareas_IDTablero], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_Estado] FROM TABLERO.[TrGestionTareas]";
         scmdbuf = scmdbuf + " WHERE ([TrGestionTareas_IDTablero] = @AV12TrGestionTableros_ID)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TrGestionTareas_Nombre_Filter)) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_Nombre] like @lV42TrGestionTareas_Nombre_Filter)";
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV44TrGestionTareas_ID_Filter) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_ID] = @AV44TrGestionTareas_ID_Filter)";
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41GenericFilter_Grid)) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_Nombre] like '%' + @lV41GenericFilter_Grid + '%' or [TrGestionTareas_Descripcion] like '%' + @lV41GenericFilter_Grid + '%')";
         }
         else
         {
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + " ORDER BY [TrGestionTareas_IDTablero]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001X2(context, (String)dynConstraints[0] , (long)dynConstraints[1] , (String)dynConstraints[2] , (String)dynConstraints[3] , (long)dynConstraints[4] , (String)dynConstraints[5] , (Guid)dynConstraints[6] , (Guid)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH001X2 ;
          prmH001X2 = new Object[] {
          new Object[] {"@AV12TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@lV42TrGestionTareas_Nombre_Filter",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV44TrGestionTareas_ID_Filter",SqlDbType.Decimal,13,0} ,
          new Object[] {"@lV41GenericFilter_Grid",SqlDbType.NChar,100,0} ,
          new Object[] {"@lV41GenericFilter_Grid",SqlDbType.NChar,100,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[0])[0] = rslt.getLongVarchar(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2) ;
                ((String[]) buf[3])[0] = rslt.getString(3, 100) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4) ;
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((short[]) buf[10])[0] = rslt.getShort(7) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
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
                   stmt.SetParameter(sIdx, (Guid)parms[5]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[6]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[7]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[8]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[9]);
                }
                return;
       }
    }

 }

}
