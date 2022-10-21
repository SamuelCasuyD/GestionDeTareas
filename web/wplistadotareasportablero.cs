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
               nRC_GXsfl_98 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_98_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_98_idx = GetNextPar( );
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
               AV40Pgmname = GetNextPar( );
               AV19CurrentPage_Grid = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV23HasNextPage_Grid = StringUtil.StrToBool( GetNextPar( ));
               A11TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
               AV12TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
               A12TrGestionTareas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               A13TrGestionTareas_Nombre = GetNextPar( );
               n13TrGestionTareas_Nombre = false;
               A14TrGestionTareas_Descripcion = GetNextPar( );
               n14TrGestionTareas_Descripcion = false;
               A15TrGestionTareas_FechaInicio = context.localUtil.ParseDateParm( GetNextPar( ));
               n15TrGestionTareas_FechaInicio = false;
               A16TrGestionTareas_FechaFin = context.localUtil.ParseDateParm( GetNextPar( ));
               n16TrGestionTareas_FechaFin = false;
               A24TrGestionTareas_Estado = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n24TrGestionTareas_Estado = false;
               AV24RowsPerPage_Grid = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( AV40Pgmname, AV19CurrentPage_Grid, AV23HasNextPage_Grid, A11TrGestionTareas_IDTablero, AV12TrGestionTableros_ID, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV24RowsPerPage_Grid) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2022102021351813", false, true);
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV23HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTABLEROS_ID", GetSecureSignedToken( "", AV12TrGestionTableros_ID, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_98", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_98), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV23HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV23HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_IDTABLERO", A11TrGestionTareas_IDTablero.ToString());
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_NOMBRE", StringUtil.RTrim( A13TrGestionTareas_Nombre));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_DESCRIPCION", A14TrGestionTareas_Descripcion);
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAINICIO", context.localUtil.DToC( A15TrGestionTareas_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAFIN", context.localUtil.DToC( A16TrGestionTareas_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24TrGestionTareas_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24RowsPerPage_Grid), 4, 0, ".", "")));
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Crear nueva tarea", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpListadoTareasPorTablero.htm");
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
            wb_table2_67_1X2( true) ;
         }
         else
         {
            wb_table2_67_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table2_67_1X2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"98\">") ;
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
         if ( wbEnd == 98 )
         {
            wbEnd = 0;
            nRC_GXsfl_98 = (int)(nGXsfl_98_idx-1);
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
            wb_table3_112_1X2( true) ;
         }
         else
         {
            wb_table3_112_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table3_112_1X2e( bool wbgen )
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
            wb_table4_119_1X2( true) ;
         }
         else
         {
            wb_table4_119_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table4_119_1X2e( bool wbgen )
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
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 98 )
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
                              nGXsfl_98_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
                              SubsflControlProps_982( ) ;
                              AV34ActualizarTarea_Action = cgiGet( edtavActualizartarea_action_Internalname);
                              AssignProp("", false, edtavActualizartarea_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV34ActualizarTarea_Action)) ? AV42Actualizartarea_action_GXI : context.convertURL( context.PathToRelativeUrl( AV34ActualizarTarea_Action))), !bGXsfl_98_Refreshing);
                              AssignProp("", false, edtavActualizartarea_action_Internalname, "SrcSet", context.GetImageSrcSet( AV34ActualizarTarea_Action), true);
                              AV35AgregarEtiqueta_Action = cgiGet( edtavAgregaretiqueta_action_Internalname);
                              AssignProp("", false, edtavAgregaretiqueta_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV35AgregarEtiqueta_Action)) ? AV43Agregaretiqueta_action_GXI : context.convertURL( context.PathToRelativeUrl( AV35AgregarEtiqueta_Action))), !bGXsfl_98_Refreshing);
                              AssignProp("", false, edtavAgregaretiqueta_action_Internalname, "SrcSet", context.GetImageSrcSet( AV35AgregarEtiqueta_Action), true);
                              AV37AgregarComentario_Action = cgiGet( edtavAgregarcomentario_action_Internalname);
                              AssignProp("", false, edtavAgregarcomentario_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37AgregarComentario_Action)) ? AV44Agregarcomentario_action_GXI : context.convertURL( context.PathToRelativeUrl( AV37AgregarComentario_Action))), !bGXsfl_98_Refreshing);
                              AssignProp("", false, edtavAgregarcomentario_action_Internalname, "SrcSet", context.GetImageSrcSet( AV37AgregarComentario_Action), true);
                              AV36InformacionTarea_Action = cgiGet( edtavInformaciontarea_action_Internalname);
                              AssignProp("", false, edtavInformaciontarea_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV36InformacionTarea_Action)) ? AV45Informaciontarea_action_GXI : context.convertURL( context.PathToRelativeUrl( AV36InformacionTarea_Action))), !bGXsfl_98_Refreshing);
                              AssignProp("", false, edtavInformaciontarea_action_Internalname, "SrcSet", context.GetImageSrcSet( AV36InformacionTarea_Action), true);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRGESTIONTAREAS_ID");
                                 GX_FocusControl = edtavTrgestiontareas_id_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV33TrGestionTareas_ID = 0;
                                 AssignAttri("", false, edtavTrgestiontareas_id_Internalname, StringUtil.LTrimStr( (decimal)(AV33TrGestionTareas_ID), 13, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sGXsfl_98_idx, context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV33TrGestionTareas_ID = (long)(context.localUtil.CToN( cgiGet( edtavTrgestiontareas_id_Internalname), ".", ","));
                                 AssignAttri("", false, edtavTrgestiontareas_id_Internalname, StringUtil.LTrimStr( (decimal)(AV33TrGestionTareas_ID), 13, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sGXsfl_98_idx, context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
                              }
                              if ( StringUtil.StrCmp(cgiGet( edtavTrgestiontareas_idtablero_Internalname), "") == 0 )
                              {
                                 AV28TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
                                 AssignAttri("", false, edtavTrgestiontareas_idtablero_Internalname, AV28TrGestionTareas_IDTablero.ToString());
                                 GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sGXsfl_98_idx, AV28TrGestionTareas_IDTablero, context));
                              }
                              else
                              {
                                 try
                                 {
                                    AV28TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( edtavTrgestiontareas_idtablero_Internalname)));
                                    AssignAttri("", false, edtavTrgestiontareas_idtablero_Internalname, AV28TrGestionTareas_IDTablero.ToString());
                                    GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sGXsfl_98_idx, AV28TrGestionTareas_IDTablero, context));
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
                                    E121X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E131X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E141X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E151X2 ();
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
         SubsflControlProps_982( ) ;
         while ( nGXsfl_98_idx <= nRC_GXsfl_98 )
         {
            sendrow_982( ) ;
            nGXsfl_98_idx = ((subGrid_Islastpage==1)&&(nGXsfl_98_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_98_idx+1);
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( String AV40Pgmname ,
                                       short AV19CurrentPage_Grid ,
                                       bool AV23HasNextPage_Grid ,
                                       Guid A11TrGestionTareas_IDTablero ,
                                       Guid AV12TrGestionTableros_ID ,
                                       long A12TrGestionTareas_ID ,
                                       String A13TrGestionTareas_Nombre ,
                                       String A14TrGestionTareas_Descripcion ,
                                       DateTime A15TrGestionTareas_FechaInicio ,
                                       DateTime A16TrGestionTareas_FechaFin ,
                                       short A24TrGestionTareas_Estado ,
                                       short AV24RowsPerPage_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E131X2 ();
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
         E131X2 ();
         RF1X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV40Pgmname = "WpListadoTareasPorTablero";
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
         AssignProp("", false, edtavTrgestiontareas_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_id_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_idtablero_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_idtablero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_idtablero_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_nombre_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_descripcion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_descripcion_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechainicio_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechafin_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         cmbavTrgestiontareas_estado.Enabled = 0;
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrgestiontareas_estado.Enabled), 5, 0), !bGXsfl_98_Refreshing);
      }

      protected void RF1X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 98;
         E141X2 ();
         nGXsfl_98_idx = 1;
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         bGXsfl_98_Refreshing = true;
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
            SubsflControlProps_982( ) ;
            E151X2 ();
            wbEnd = 98;
            WB1X0( ) ;
         }
         bGXsfl_98_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1X2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV23HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV23HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sGXsfl_98_idx, context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sGXsfl_98_idx, AV28TrGestionTareas_IDTablero, context));
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
         AV40Pgmname = "WpListadoTareasPorTablero";
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
         AssignProp("", false, edtavTrgestiontareas_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_id_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_idtablero_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_idtablero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_idtablero_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_nombre_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_descripcion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_descripcion_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechainicio_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtavTrgestiontareas_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechafin_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         cmbavTrgestiontareas_estado.Enabled = 0;
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrgestiontareas_estado.Enabled), 5, 0), !bGXsfl_98_Refreshing);
      }

      protected void STRUP1X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E121X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_98 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_98"), ".", ","));
            AV24RowsPerPage_Grid = (short)(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_GRID"), ".", ","));
            AV19CurrentPage_Grid = (short)(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRID"), ".", ","));
            AV23HasNextPage_Grid = StringUtil.StrToBool( cgiGet( "vHASNEXTPAGE_GRID"));
            /* Read variables values. */
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV26GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
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
         E121X2 ();
         if (returnInSub) return;
      }

      protected void E121X2( )
      {
         /* Start Routine */
         new k2bloadrowsperpage(context ).execute(  AV40Pgmname,  "Grid", out  AV24RowsPerPage_Grid, out  AV25RowsPerPageLoaded_Grid) ;
         AssignAttri("", false, "AV24RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_Grid), 4, 0));
         if ( ! AV25RowsPerPageLoaded_Grid )
         {
            AV24RowsPerPage_Grid = 20;
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
      }

      protected void E131X2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S132 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         if ( (0==AV19CurrentPage_Grid) )
         {
            AV19CurrentPage_Grid = 1;
            AssignAttri("", false, "AV19CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV19CurrentPage_Grid), 4, 0));
         }
         AV20Reload_Grid = true;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S183( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
      }

      protected void S172( )
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

      protected void S162( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
      }

      protected void E141X2( )
      {
         /* Grid_Refresh Routine */
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S152 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E151X2( )
      {
         /* Grid_Load Routine */
         tblI_noresultsfoundtablename_grid_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV22I_LoadCount_Grid = 0;
         AV23HasNextPage_Grid = false;
         AssignAttri("", false, "AV23HasNextPage_Grid", AV23HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV23HasNextPage_Grid, context));
         AV41GXLvl157 = 0;
         /* Using cursor H001X2 */
         pr_default.execute(0, new Object[] {AV12TrGestionTableros_ID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11TrGestionTareas_IDTablero = (Guid)((Guid)(H001X2_A11TrGestionTareas_IDTablero[0]));
            A12TrGestionTareas_ID = H001X2_A12TrGestionTareas_ID[0];
            A13TrGestionTareas_Nombre = H001X2_A13TrGestionTareas_Nombre[0];
            n13TrGestionTareas_Nombre = H001X2_n13TrGestionTareas_Nombre[0];
            A14TrGestionTareas_Descripcion = H001X2_A14TrGestionTareas_Descripcion[0];
            n14TrGestionTareas_Descripcion = H001X2_n14TrGestionTareas_Descripcion[0];
            A15TrGestionTareas_FechaInicio = H001X2_A15TrGestionTareas_FechaInicio[0];
            n15TrGestionTareas_FechaInicio = H001X2_n15TrGestionTareas_FechaInicio[0];
            A16TrGestionTareas_FechaFin = H001X2_A16TrGestionTareas_FechaFin[0];
            n16TrGestionTareas_FechaFin = H001X2_n16TrGestionTareas_FechaFin[0];
            A24TrGestionTareas_Estado = H001X2_A24TrGestionTareas_Estado[0];
            n24TrGestionTareas_Estado = H001X2_n24TrGestionTareas_Estado[0];
            AV41GXLvl157 = 1;
            AV33TrGestionTareas_ID = A12TrGestionTareas_ID;
            AssignAttri("", false, edtavTrgestiontareas_id_Internalname, StringUtil.LTrimStr( (decimal)(AV33TrGestionTareas_ID), 13, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sGXsfl_98_idx, context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
            AV28TrGestionTareas_IDTablero = (Guid)(A11TrGestionTareas_IDTablero);
            AssignAttri("", false, edtavTrgestiontareas_idtablero_Internalname, AV28TrGestionTareas_IDTablero.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sGXsfl_98_idx, AV28TrGestionTareas_IDTablero, context));
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
            AV34ActualizarTarea_Action = context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( ));
            AssignAttri("", false, edtavActualizartarea_action_Internalname, AV34ActualizarTarea_Action);
            AV42Actualizartarea_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( )));
            edtavActualizartarea_action_Tooltiptext = "Actualizar Tarea";
            AV35AgregarEtiqueta_Action = context.GetImagePath( "d544a810-d067-45f9-a74b-b82632541d38", "", context.GetTheme( ));
            AssignAttri("", false, edtavAgregaretiqueta_action_Internalname, AV35AgregarEtiqueta_Action);
            AV43Agregaretiqueta_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "d544a810-d067-45f9-a74b-b82632541d38", "", context.GetTheme( )));
            edtavAgregaretiqueta_action_Tooltiptext = "Agregar Etiqueta";
            AV37AgregarComentario_Action = context.GetImagePath( "d006b751-0154-4c41-8d12-c49198748691", "", context.GetTheme( ));
            AssignAttri("", false, edtavAgregarcomentario_action_Internalname, AV37AgregarComentario_Action);
            AV44Agregarcomentario_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "d006b751-0154-4c41-8d12-c49198748691", "", context.GetTheme( )));
            edtavAgregarcomentario_action_Tooltiptext = "Agregar Comentario";
            AV36InformacionTarea_Action = context.GetImagePath( "71387ecf-b35f-45a7-aefb-b55a5da4cbe2", "", context.GetTheme( ));
            AssignAttri("", false, edtavInformaciontarea_action_Internalname, AV36InformacionTarea_Action);
            AV45Informaciontarea_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "71387ecf-b35f-45a7-aefb-b55a5da4cbe2", "", context.GetTheme( )));
            edtavInformaciontarea_action_Tooltiptext = "Informacion Tarea";
            AV22I_LoadCount_Grid = (short)(AV22I_LoadCount_Grid+1);
            AV21LoadRow_Grid = true;
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S183 ();
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
                     wbStart = 98;
                  }
                  sendrow_982( ) ;
                  if ( isFullAjaxMode( ) && ! bGXsfl_98_Refreshing )
                  {
                     context.DoAjaxLoad(98, GridRow);
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
         if ( AV41GXLvl157 == 0 )
         {
            tblI_noresultsfoundtablename_grid_Visible = 1;
            AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            /* Execute user subroutine: 'U_WHENNONE(GRID)' */
            S192 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32TrGestionTareas_Estado), 4, 0));
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         AV16GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV40Pgmname,  AV16GridStateKey, out  AV17GridState) ;
         if ( AV17GridState.gxTpr_Currentpage > 0 )
         {
            AV19CurrentPage_Grid = AV17GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV19CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV19CurrentPage_Grid), 4, 0));
         }
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         AV16GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV40Pgmname,  AV16GridStateKey, out  AV17GridState) ;
         AV17GridState.gxTpr_Currentpage = AV19CurrentPage_Grid;
         AV17GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV40Pgmname,  AV16GridStateKey,  AV17GridState) ;
      }

      protected void S192( )
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
            new k2bsaverowsperpage(context ).execute(  AV40Pgmname,  "Grid",  AV24RowsPerPage_Grid) ;
            AV19CurrentPage_Grid = 1;
            AssignAttri("", false, "AV19CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV19CurrentPage_Grid), 4, 0));
         }
         gxgrGrid_refresh( AV40Pgmname, AV19CurrentPage_Grid, AV23HasNextPage_Grid, A11TrGestionTareas_IDTablero, AV12TrGestionTableros_ID, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV24RowsPerPage_Grid) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void S202( )
      {
         /* 'U_ACTUALIZARTAREA' Routine */
         context.PopUp(formatLink("wpactualizartareaportablero.aspx") + "?" + UrlEncode("" +AV33TrGestionTareas_ID) + "," + UrlEncode(AV28TrGestionTareas_IDTablero.ToString()), new Object[] {});
      }

      protected void S212( )
      {
         /* 'U_AGREGARETIQUETA' Routine */
         context.PopUp(formatLink("wptareasagregaretiquetas.aspx") + "?" + UrlEncode("" +AV33TrGestionTareas_ID), new Object[] {});
      }

      protected void S222( )
      {
         /* 'U_INFORMACIONTAREA' Routine */
         CallWebObject(formatLink("wpvisualizarinformaciontarea.aspx") + "?" + UrlEncode("" +AV33TrGestionTareas_ID));
         context.wjLocDisableFrm = 1;
      }

      protected void S232( )
      {
         /* 'U_AGREGARCOMENTARIO' Routine */
         context.PopUp(formatLink("wpcrearcomentariostarea.aspx") + "?" + UrlEncode("" +AV33TrGestionTareas_ID), new Object[] {});
      }

      protected void wb_table4_119_1X2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "&laquo;", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e161x1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 1, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_firstpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_firstpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e171x1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingleftcellgrid_Internalname+"\"  class='"+cellPaginationbar_spacingleftcellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagecellgrid_Internalname+"\"  class='"+cellPaginationbar_previouspagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e161x1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_currentpagecellgrid_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagecellgrid_Internalname+"\"  class='"+cellPaginationbar_nextpagecellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e181x1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingrightcellgrid_Internalname+"\"  class='"+cellPaginationbar_spacingrightcellgrid_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagebuttoncellgrid_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "&raquo;", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e181x1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 1, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_119_1X2e( true) ;
         }
         else
         {
            wb_table4_119_1X2e( false) ;
         }
      }

      protected void wb_table3_112_1X2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_112_1X2e( true) ;
         }
         else
         {
            wb_table3_112_1X2e( false) ;
         }
      }

      protected void wb_table2_67_1X2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_Internalname, "", "", "", lblGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e191x1_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WpListadoTareasPorTablero.htm");
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
            wb_table5_79_1X2( true) ;
         }
         else
         {
            wb_table5_79_1X2( false) ;
         }
         return  ;
      }

      protected void wb_table5_79_1X2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", "Save", bttGridsettings_savegrid_Jsonclick, 5, "Save", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpListadoTareasPorTablero.htm");
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
            wb_table2_67_1X2e( true) ;
         }
         else
         {
            wb_table2_67_1X2e( false) ;
         }
      }

      protected void wb_table5_79_1X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_Internalname, tblGridsettings_tablecontentgrid_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_Internalname, "Rows per page", "", "", lblGridsettings_rowsperpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WpListadoTareasPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, "Grid Settings Rows Per Page_Grid", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Rows per page", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, "HLP_WpListadoTareasPorTablero.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_79_1X2e( true) ;
         }
         else
         {
            wb_table5_79_1X2e( false) ;
         }
      }

      protected void wb_table1_52_1X2( bool wbgen )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?2022102021351919", true, true);
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
         context.AddJavascriptSource("wplistadotareasportablero.js", "?2022102021351919", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_982( )
      {
         edtavActualizartarea_action_Internalname = "vACTUALIZARTAREA_ACTION_"+sGXsfl_98_idx;
         edtavAgregaretiqueta_action_Internalname = "vAGREGARETIQUETA_ACTION_"+sGXsfl_98_idx;
         edtavAgregarcomentario_action_Internalname = "vAGREGARCOMENTARIO_ACTION_"+sGXsfl_98_idx;
         edtavInformaciontarea_action_Internalname = "vINFORMACIONTAREA_ACTION_"+sGXsfl_98_idx;
         edtavTrgestiontareas_id_Internalname = "vTRGESTIONTAREAS_ID_"+sGXsfl_98_idx;
         edtavTrgestiontareas_idtablero_Internalname = "vTRGESTIONTAREAS_IDTABLERO_"+sGXsfl_98_idx;
         edtavTrgestiontareas_nombre_Internalname = "vTRGESTIONTAREAS_NOMBRE_"+sGXsfl_98_idx;
         edtavTrgestiontareas_descripcion_Internalname = "vTRGESTIONTAREAS_DESCRIPCION_"+sGXsfl_98_idx;
         edtavTrgestiontareas_fechainicio_Internalname = "vTRGESTIONTAREAS_FECHAINICIO_"+sGXsfl_98_idx;
         edtavTrgestiontareas_fechafin_Internalname = "vTRGESTIONTAREAS_FECHAFIN_"+sGXsfl_98_idx;
         cmbavTrgestiontareas_estado_Internalname = "vTRGESTIONTAREAS_ESTADO_"+sGXsfl_98_idx;
      }

      protected void SubsflControlProps_fel_982( )
      {
         edtavActualizartarea_action_Internalname = "vACTUALIZARTAREA_ACTION_"+sGXsfl_98_fel_idx;
         edtavAgregaretiqueta_action_Internalname = "vAGREGARETIQUETA_ACTION_"+sGXsfl_98_fel_idx;
         edtavAgregarcomentario_action_Internalname = "vAGREGARCOMENTARIO_ACTION_"+sGXsfl_98_fel_idx;
         edtavInformaciontarea_action_Internalname = "vINFORMACIONTAREA_ACTION_"+sGXsfl_98_fel_idx;
         edtavTrgestiontareas_id_Internalname = "vTRGESTIONTAREAS_ID_"+sGXsfl_98_fel_idx;
         edtavTrgestiontareas_idtablero_Internalname = "vTRGESTIONTAREAS_IDTABLERO_"+sGXsfl_98_fel_idx;
         edtavTrgestiontareas_nombre_Internalname = "vTRGESTIONTAREAS_NOMBRE_"+sGXsfl_98_fel_idx;
         edtavTrgestiontareas_descripcion_Internalname = "vTRGESTIONTAREAS_DESCRIPCION_"+sGXsfl_98_fel_idx;
         edtavTrgestiontareas_fechainicio_Internalname = "vTRGESTIONTAREAS_FECHAINICIO_"+sGXsfl_98_fel_idx;
         edtavTrgestiontareas_fechafin_Internalname = "vTRGESTIONTAREAS_FECHAFIN_"+sGXsfl_98_fel_idx;
         cmbavTrgestiontareas_estado_Internalname = "vTRGESTIONTAREAS_ESTADO_"+sGXsfl_98_fel_idx;
      }

      protected void sendrow_982( )
      {
         SubsflControlProps_982( ) ;
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
            if ( ((int)((nGXsfl_98_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_98_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavActualizartarea_action_Enabled!=0)&&(edtavActualizartarea_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 99,'',false,'',98)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV34ActualizarTarea_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV34ActualizarTarea_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV42Actualizartarea_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV34ActualizarTarea_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV34ActualizarTarea_Action)) ? AV42Actualizartarea_action_GXI : context.PathToRelativeUrl( AV34ActualizarTarea_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavActualizartarea_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Actualizar Tarea",(String)edtavActualizartarea_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)7,(String)edtavActualizartarea_action_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+"e201x2_client"+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV34ActualizarTarea_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavAgregaretiqueta_action_Enabled!=0)&&(edtavAgregaretiqueta_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 100,'',false,'',98)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV35AgregarEtiqueta_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV35AgregarEtiqueta_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV43Agregaretiqueta_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV35AgregarEtiqueta_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV35AgregarEtiqueta_Action)) ? AV43Agregaretiqueta_action_GXI : context.PathToRelativeUrl( AV35AgregarEtiqueta_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavAgregaretiqueta_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Agregar Etiqueta",(String)edtavAgregaretiqueta_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)7,(String)edtavAgregaretiqueta_action_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+"e211x2_client"+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV35AgregarEtiqueta_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavAgregarcomentario_action_Enabled!=0)&&(edtavAgregarcomentario_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 101,'',false,'',98)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV37AgregarComentario_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV37AgregarComentario_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV44Agregarcomentario_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV37AgregarComentario_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37AgregarComentario_Action)) ? AV44Agregarcomentario_action_GXI : context.PathToRelativeUrl( AV37AgregarComentario_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavAgregarcomentario_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Agregar Comentario",(String)edtavAgregarcomentario_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)7,(String)edtavAgregarcomentario_action_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+"e221x2_client"+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV37AgregarComentario_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavInformaciontarea_action_Enabled!=0)&&(edtavInformaciontarea_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 102,'',false,'',98)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV36InformacionTarea_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV36InformacionTarea_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV45Informaciontarea_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV36InformacionTarea_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV36InformacionTarea_Action)) ? AV45Informaciontarea_action_GXI : context.PathToRelativeUrl( AV36InformacionTarea_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavInformaciontarea_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Informacion Tarea",(String)edtavInformaciontarea_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)7,(String)edtavInformaciontarea_action_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+"e231x2_client"+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV36InformacionTarea_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_id_Enabled!=0)&&(edtavTrgestiontareas_id_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 103,'',false,'"+sGXsfl_98_idx+"',98)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_id_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TrGestionTareas_ID), 13, 0, ".", "")),((edtavTrgestiontareas_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV33TrGestionTareas_ID), "ZZZZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_id_Enabled!=0)&&(edtavTrgestiontareas_id_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,103);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_id_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_id_Enabled,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)98,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_idtablero_Enabled!=0)&&(edtavTrgestiontareas_idtablero_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 104,'',false,'"+sGXsfl_98_idx+"',98)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_idtablero_Internalname,AV28TrGestionTareas_IDTablero.ToString(),AV28TrGestionTareas_IDTablero.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_idtablero_Enabled!=0)&&(edtavTrgestiontareas_idtablero_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,104);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_idtablero_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)0,(int)edtavTrgestiontareas_idtablero_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)36,(short)0,(short)0,(short)98,(short)1,(short)0,(short)0,(bool)true,(String)"",(String)"",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_nombre_Enabled!=0)&&(edtavTrgestiontareas_nombre_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 105,'',false,'"+sGXsfl_98_idx+"',98)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_nombre_Internalname,StringUtil.RTrim( AV27TrGestionTareas_Nombre),(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_nombre_Enabled!=0)&&(edtavTrgestiontareas_nombre_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,105);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_nombre_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_nombre_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)98,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_descripcion_Enabled!=0)&&(edtavTrgestiontareas_descripcion_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 106,'',false,'"+sGXsfl_98_idx+"',98)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_descripcion_Internalname,(String)AV29TrGestionTareas_Descripcion,(String)AV29TrGestionTareas_Descripcion,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_descripcion_Enabled!=0)&&(edtavTrgestiontareas_descripcion_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,106);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_descripcion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_descripcion_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)98,(short)1,(short)0,(short)-1,(bool)true,(String)"",(String)"left",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_fechainicio_Enabled!=0)&&(edtavTrgestiontareas_fechainicio_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 107,'',false,'"+sGXsfl_98_idx+"',98)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_fechainicio_Internalname,context.localUtil.Format(AV30TrGestionTareas_FechaInicio, "99/99/9999"),context.localUtil.Format( AV30TrGestionTareas_FechaInicio, "99/99/9999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_fechainicio_Enabled!=0)&&(edtavTrgestiontareas_fechainicio_Visible!=0) ? " onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,107);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_fechainicio_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_fechainicio_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)98,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrgestiontareas_fechafin_Enabled!=0)&&(edtavTrgestiontareas_fechafin_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 108,'',false,'"+sGXsfl_98_idx+"',98)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavTrgestiontareas_fechafin_Internalname,context.localUtil.Format(AV31TrGestionTareas_FechaFin, "99/99/9999"),context.localUtil.Format( AV31TrGestionTareas_FechaFin, "99/99/9999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+((edtavTrgestiontareas_fechafin_Enabled!=0)&&(edtavTrgestiontareas_fechafin_Visible!=0) ? " onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,108);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavTrgestiontareas_fechafin_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(int)edtavTrgestiontareas_fechafin_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)98,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         TempTags = " " + ((cmbavTrgestiontareas_estado.Enabled!=0)&&(cmbavTrgestiontareas_estado.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 109,'',false,'"+sGXsfl_98_idx+"',98)\"" : " ");
         if ( ( cmbavTrgestiontareas_estado.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vTRGESTIONTAREAS_ESTADO_" + sGXsfl_98_idx;
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
         GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavTrgestiontareas_estado,(String)cmbavTrgestiontareas_estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV32TrGestionTareas_Estado), 4, 0)),(short)1,(String)cmbavTrgestiontareas_estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,cmbavTrgestiontareas_estado.Enabled,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute_Grid",(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavTrgestiontareas_estado.Enabled!=0)&&(cmbavTrgestiontareas_estado.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,109);\"" : " "),(String)"",(bool)true});
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV32TrGestionTareas_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", (String)(cmbavTrgestiontareas_estado.ToJavascriptSource()), !bGXsfl_98_Refreshing);
         send_integrity_lvl_hashes1X2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_98_idx = ((subGrid_Islastpage==1)&&(nGXsfl_98_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_98_idx+1);
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         /* End function sendrow_982 */
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
         GXCCtl = "vTRGESTIONTAREAS_ESTADO_" + sGXsfl_98_idx;
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
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         edtavActualizartarea_action_Internalname = "vACTUALIZARTAREA_ACTION";
         edtavAgregaretiqueta_action_Internalname = "vAGREGARETIQUETA_ACTION";
         edtavAgregarcomentario_action_Internalname = "vAGREGARCOMENTARIO_ACTION";
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
         edtavAgregarcomentario_action_Jsonclick = "";
         edtavAgregarcomentario_action_Visible = -1;
         edtavAgregarcomentario_action_Enabled = 1;
         edtavAgregaretiqueta_action_Jsonclick = "";
         edtavAgregaretiqueta_action_Visible = -1;
         edtavAgregaretiqueta_action_Enabled = 1;
         edtavActualizartarea_action_Jsonclick = "";
         edtavActualizartarea_action_Visible = -1;
         edtavActualizartarea_action_Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_Visible = 1;
         lblPaginationbar_previouspagetextblockgrid_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_Visible = 1;
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavInformaciontarea_action_Tooltiptext = "";
         edtavAgregarcomentario_action_Tooltiptext = "";
         edtavAgregaretiqueta_action_Tooltiptext = "";
         edtavActualizartarea_action_Tooltiptext = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E171X1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E141X2',iparms:[{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E151X2',iparms:[{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV28TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:'',hsh:true},{av:'AV27TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV29TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV30TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV31TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV32TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV34ActualizarTarea_Action',fld:'vACTUALIZARTAREA_ACTION',pic:''},{av:'edtavActualizartarea_action_Tooltiptext',ctrl:'vACTUALIZARTAREA_ACTION',prop:'Tooltiptext'},{av:'AV35AgregarEtiqueta_Action',fld:'vAGREGARETIQUETA_ACTION',pic:''},{av:'edtavAgregaretiqueta_action_Tooltiptext',ctrl:'vAGREGARETIQUETA_ACTION',prop:'Tooltiptext'},{av:'AV37AgregarComentario_Action',fld:'vAGREGARCOMENTARIO_ACTION',pic:''},{av:'edtavAgregarcomentario_action_Tooltiptext',ctrl:'vAGREGARCOMENTARIO_ACTION',prop:'Tooltiptext'},{av:'AV36InformacionTarea_Action',fld:'vINFORMACIONTAREA_ACTION',pic:''},{av:'edtavInformaciontarea_action_Tooltiptext',ctrl:'vINFORMACIONTAREA_ACTION',prop:'Tooltiptext'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E181X1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E161X1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E191X1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV26GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E111X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'A11TrGestionTareas_IDTablero',fld:'TRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV12TrGestionTableros_ID',fld:'vTRGESTIONTABLEROS_ID',pic:'',hsh:true},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV26GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV24RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'}]}");
         setEventMetadata("'E_ACTUALIZARTAREA'","{handler:'E201X2',iparms:[{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV28TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:'',hsh:true}]");
         setEventMetadata("'E_ACTUALIZARTAREA'",",oparms:[]}");
         setEventMetadata("'E_AGREGARETIQUETA'","{handler:'E211X2',iparms:[{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_AGREGARETIQUETA'",",oparms:[]}");
         setEventMetadata("'E_INFORMACIONTAREA'","{handler:'E231X2',iparms:[{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_INFORMACIONTAREA'",",oparms:[]}");
         setEventMetadata("'E_AGREGARCOMENTARIO'","{handler:'E221X2',iparms:[{av:'AV33TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_AGREGARCOMENTARIO'",",oparms:[]}");
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
         AV40Pgmname = "";
         A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         A13TrGestionTareas_Nombre = "";
         A14TrGestionTareas_Descripcion = "";
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
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
         lblTrgestiontableros_id_var_lefttext_Jsonclick = "";
         lblTrgestiontableros_nombre_var_lefttext_Jsonclick = "";
         lblTrgestiontableros_fechainicio_var_lefttext_Jsonclick = "";
         lblTrgestiontableros_fechafin_var_lefttext_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV34ActualizarTarea_Action = "";
         AV35AgregarEtiqueta_Action = "";
         AV37AgregarComentario_Action = "";
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
         AV42Actualizartarea_action_GXI = "";
         AV43Agregaretiqueta_action_GXI = "";
         AV44Agregarcomentario_action_GXI = "";
         AV45Informaciontarea_action_GXI = "";
         scmdbuf = "";
         H001X2_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         H001X2_A12TrGestionTareas_ID = new long[1] ;
         H001X2_A13TrGestionTareas_Nombre = new String[] {""} ;
         H001X2_n13TrGestionTareas_Nombre = new bool[] {false} ;
         H001X2_A14TrGestionTareas_Descripcion = new String[] {""} ;
         H001X2_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         H001X2_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H001X2_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         H001X2_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H001X2_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         H001X2_A24TrGestionTareas_Estado = new short[1] ;
         H001X2_n24TrGestionTareas_Estado = new bool[] {false} ;
         GridRow = new GXWebRow();
         AV16GridStateKey = "";
         AV17GridState = new SdtK2BGridState(context);
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
         TempTags = "";
         bttGridsettings_savegrid_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgrid_Jsonclick = "";
         lblGridtitle_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistadotareasportablero__default(),
            new Object[][] {
                new Object[] {
               H001X2_A11TrGestionTareas_IDTablero, H001X2_A12TrGestionTareas_ID, H001X2_A13TrGestionTareas_Nombre, H001X2_n13TrGestionTareas_Nombre, H001X2_A14TrGestionTareas_Descripcion, H001X2_n14TrGestionTareas_Descripcion, H001X2_A15TrGestionTareas_FechaInicio, H001X2_n15TrGestionTareas_FechaInicio, H001X2_A16TrGestionTareas_FechaFin, H001X2_n16TrGestionTareas_FechaFin,
               H001X2_A24TrGestionTareas_Estado, H001X2_n24TrGestionTareas_Estado
               }
            }
         );
         AV40Pgmname = "WpListadoTareasPorTablero";
         /* GeneXus formulas. */
         AV40Pgmname = "WpListadoTareasPorTablero";
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
      private short AV41GXLvl157 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int divGridsettings_contentoutertablegrid_Visible ;
      private int nRC_GXsfl_98 ;
      private int nGXsfl_98_idx=1 ;
      private int edtavTrgestiontableros_id_Enabled ;
      private int edtavTrgestiontableros_nombre_Enabled ;
      private int edtavTrgestiontableros_fechainicio_Enabled ;
      private int edtavTrgestiontableros_fechafin_Enabled ;
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
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int tblPaginationbar_pagingcontainertablegrid_Visible ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavActualizartarea_action_Enabled ;
      private int edtavActualizartarea_action_Visible ;
      private int edtavAgregaretiqueta_action_Enabled ;
      private int edtavAgregaretiqueta_action_Visible ;
      private int edtavAgregarcomentario_action_Enabled ;
      private int edtavAgregarcomentario_action_Visible ;
      private int edtavInformaciontarea_action_Enabled ;
      private int edtavInformaciontarea_action_Visible ;
      private int edtavTrgestiontareas_id_Visible ;
      private int edtavTrgestiontareas_idtablero_Visible ;
      private int edtavTrgestiontareas_nombre_Visible ;
      private int edtavTrgestiontareas_descripcion_Visible ;
      private int edtavTrgestiontareas_fechainicio_Visible ;
      private int edtavTrgestiontareas_fechafin_Visible ;
      private long A12TrGestionTareas_ID ;
      private long AV33TrGestionTareas_ID ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private String AV13TrGestionTableros_Nombre ;
      private String wcpOAV13TrGestionTableros_Nombre ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_98_idx="0001" ;
      private String AV40Pgmname ;
      private String A13TrGestionTareas_Nombre ;
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
      private String divGridcomponent_grid_Internalname ;
      private String divGridcomponentcontent_grid_Internalname ;
      private String divLayoutdefined_grid_inner_grid_Internalname ;
      private String divLayoutdefined_table10_grid_Internalname ;
      private String divLayoutdefined_table3_grid_Internalname ;
      private String divMaingrid_responsivetable_grid_Internalname ;
      private String sStyleString ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String subGrid_Header ;
      private String edtavActualizartarea_action_Tooltiptext ;
      private String edtavAgregaretiqueta_action_Tooltiptext ;
      private String edtavAgregarcomentario_action_Tooltiptext ;
      private String edtavInformaciontarea_action_Tooltiptext ;
      private String AV27TrGestionTareas_Nombre ;
      private String divLayoutdefined_section8_grid_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavActualizartarea_action_Internalname ;
      private String edtavAgregaretiqueta_action_Internalname ;
      private String edtavAgregarcomentario_action_Internalname ;
      private String edtavInformaciontarea_action_Internalname ;
      private String edtavTrgestiontareas_id_Internalname ;
      private String edtavTrgestiontareas_idtablero_Internalname ;
      private String edtavTrgestiontareas_nombre_Internalname ;
      private String edtavTrgestiontareas_descripcion_Internalname ;
      private String edtavTrgestiontareas_fechainicio_Internalname ;
      private String edtavTrgestiontareas_fechafin_Internalname ;
      private String cmbavTrgestiontareas_estado_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_Internalname ;
      private String divGridsettings_contentoutertablegrid_Internalname ;
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
      private String TempTags ;
      private String bttGridsettings_savegrid_Internalname ;
      private String bttGridsettings_savegrid_Jsonclick ;
      private String tblGridsettings_tablecontentgrid_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_Jsonclick ;
      private String cmbavGridsettingsrowsperpage_grid_Jsonclick ;
      private String tblGridtitlecontainertable_grid_Internalname ;
      private String lblGridtitle_grid_Internalname ;
      private String lblGridtitle_grid_Jsonclick ;
      private String sGXsfl_98_fel_idx="0001" ;
      private String sImgUrl ;
      private String edtavActualizartarea_action_Jsonclick ;
      private String edtavAgregaretiqueta_action_Jsonclick ;
      private String edtavAgregarcomentario_action_Jsonclick ;
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
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_98_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV25RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV20Reload_Grid ;
      private bool AV21LoadRow_Grid ;
      private bool AV34ActualizarTarea_Action_IsBlob ;
      private bool AV35AgregarEtiqueta_Action_IsBlob ;
      private bool AV37AgregarComentario_Action_IsBlob ;
      private bool AV36InformacionTarea_Action_IsBlob ;
      private String A14TrGestionTareas_Descripcion ;
      private String AV29TrGestionTareas_Descripcion ;
      private String AV42Actualizartarea_action_GXI ;
      private String AV43Agregaretiqueta_action_GXI ;
      private String AV44Agregarcomentario_action_GXI ;
      private String AV45Informaciontarea_action_GXI ;
      private String AV16GridStateKey ;
      private String AV34ActualizarTarea_Action ;
      private String AV35AgregarEtiqueta_Action ;
      private String AV37AgregarComentario_Action ;
      private String AV36InformacionTarea_Action ;
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
      private Guid[] H001X2_A11TrGestionTareas_IDTablero ;
      private long[] H001X2_A12TrGestionTareas_ID ;
      private String[] H001X2_A13TrGestionTareas_Nombre ;
      private bool[] H001X2_n13TrGestionTareas_Nombre ;
      private String[] H001X2_A14TrGestionTareas_Descripcion ;
      private bool[] H001X2_n14TrGestionTareas_Descripcion ;
      private DateTime[] H001X2_A15TrGestionTareas_FechaInicio ;
      private bool[] H001X2_n15TrGestionTareas_FechaInicio ;
      private DateTime[] H001X2_A16TrGestionTareas_FechaFin ;
      private bool[] H001X2_n16TrGestionTareas_FechaFin ;
      private short[] H001X2_A24TrGestionTareas_Estado ;
      private bool[] H001X2_n24TrGestionTareas_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtK2BGridState AV17GridState ;
   }

   public class wplistadotareasportablero__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH001X2 ;
          prmH001X2 = new Object[] {
          new Object[] {"@AV12TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001X2", "SELECT [TrGestionTareas_IDTablero], [TrGestionTareas_ID], [TrGestionTareas_Nombre], [TrGestionTareas_Descripcion], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_Estado] FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_IDTablero] = @AV12TrGestionTableros_ID ORDER BY [TrGestionTareas_IDTablero] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 100) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((String[]) buf[4])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
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
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
       }
    }

 }

}
