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
   public class wpvisualizarinformaciontarea : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpvisualizarinformaciontarea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpvisualizarinformaciontarea( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_TrGestionTareas_ID )
      {
         this.AV26TrGestionTareas_ID = aP0_TrGestionTareas_ID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTrgestiontareas_estado = new GXCombobox();
         cmbavGridsettingsrowsperpage_grid_etiquetas = new GXCombobox();
         cmbavGridsettingsrowsperpage_grid_comentarios = new GXCombobox();
         cmbTrTareaComentarios_Estado = new GXCombobox();
         cmbavGridsettingsrowsperpage_grid_actividades = new GXCombobox();
         cmbTrActividades_Estado = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid_etiquetas") == 0 )
            {
               nRC_GXsfl_111 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_111_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_111_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_etiquetas_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid_etiquetas") == 0 )
            {
               subGrid_etiquetas_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV26TrGestionTareas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV35CurrentPage_Grid_Comentarios = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV56CurrentPage_Grid_Actividades = (short)(NumberUtil.Val( GetNextPar( ), "."));
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
               AV74Pgmname = GetNextPar( );
               AV43CurrentPage_Grid_Etiquetas = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid_comentarios") == 0 )
            {
               nRC_GXsfl_198 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_198_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_198_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_comentarios_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid_comentarios") == 0 )
            {
               subGrid_comentarios_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV26TrGestionTareas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV43CurrentPage_Grid_Etiquetas = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV56CurrentPage_Grid_Actividades = (short)(NumberUtil.Val( GetNextPar( ), "."));
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
               AV74Pgmname = GetNextPar( );
               AV35CurrentPage_Grid_Comentarios = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV35CurrentPage_Grid_Comentarios) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid_actividades") == 0 )
            {
               nRC_GXsfl_285 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_285_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_285_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_actividades_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid_actividades") == 0 )
            {
               subGrid_actividades_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV26TrGestionTareas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV43CurrentPage_Grid_Etiquetas = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV35CurrentPage_Grid_Comentarios = (short)(NumberUtil.Val( GetNextPar( ), "."));
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
               AV74Pgmname = GetNextPar( );
               AV56CurrentPage_Grid_Actividades = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_actividades_refresh( subGrid_actividades_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV56CurrentPage_Grid_Actividades) ;
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
               AV26TrGestionTareas_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV26TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV26TrGestionTareas_ID), 13, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
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
         PA272( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START272( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211745478", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpvisualizarinformaciontarea.aspx") + "?" + UrlEncode("" +AV26TrGestionTareas_ID)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_111", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_111), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_198", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_198), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_285", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_285), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID_ETIQUETAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID_COMENTARIOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID_ACTIVIDADES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56CurrentPage_Grid_Actividades), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_NOMBRE", StringUtil.RTrim( A13TrGestionTareas_Nombre));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_DESCRIPCION", A14TrGestionTareas_Descripcion);
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAINICIO", context.localUtil.DToC( A15TrGestionTareas_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAFIN", context.localUtil.DToC( A16TrGestionTareas_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24TrGestionTareas_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID_ETIQUETAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45RowsPerPage_Grid_Etiquetas), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID_COMENTARIOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40RowsPerPage_Grid_Comentarios), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID_ACTIVIDADES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58RowsPerPage_Grid_Actividades), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68TrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTRACTIVIDADES_IDTAREA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69TrActividades_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ACTIVIDADES_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_etiquetas_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_comentarios_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_ACTIVIDADES_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_actividades_Visible), 5, 0, ".", "")));
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
            WE272( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT272( ) ;
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
         return formatLink("wpvisualizarinformaciontarea.aspx") + "?" + UrlEncode("" +AV26TrGestionTareas_ID) ;
      }

      public override String GetPgmname( )
      {
         return "WpVisualizarInformacionTarea" ;
      }

      public override String GetPgmdesc( )
      {
         return "Visualizar información de la tarea" ;
      }

      protected void WB270( )
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Datos de la tarea", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpVisualizarInformacionTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_id_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_idfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_id_var_lefttext_Internalname, "ID TAREA : ", "", "", lblTrgestiontareas_id_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTrgestiontareas_id_var_lefttext_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TrGestionTareas_ID), 13, 0, ".", "")), ((edtavTrgestiontareas_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV26TrGestionTareas_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV26TrGestionTareas_ID), "ZZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_id_Jsonclick, 0, "Attribute_Trn", ((edtavTrgestiontareas_id_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "", "", "", 1, edtavTrgestiontareas_id_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpVisualizarInformacionTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_nombre_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_nombrefieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_nombre_var_lefttext_Internalname, "Nombre : ", "", "", lblTrgestiontareas_nombre_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-size:"+StringUtil.Str( (decimal)(lblTrgestiontareas_nombre_var_lefttext_Fontsize), 3, 0)+"pt;"+((lblTrgestiontareas_nombre_var_lefttext_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_nombre_Internalname, StringUtil.RTrim( AV15TrGestionTareas_Nombre), StringUtil.RTrim( context.localUtil.Format( AV15TrGestionTareas_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_nombre_Jsonclick, 0, "Attribute_Trn", ((edtavTrgestiontareas_nombre_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "", "", "", 1, edtavTrgestiontareas_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpVisualizarInformacionTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_descripcion_var_lefttext_Internalname, "Descripción : ", "", "", lblTrgestiontareas_descripcion_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-size:"+StringUtil.Str( (decimal)(lblTrgestiontareas_descripcion_var_lefttext_Fontsize), 3, 0)+"pt;"+((lblTrgestiontareas_descripcion_var_lefttext_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_111_idx + "',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = ((edtavTrgestiontareas_descripcion_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;");
            ClassString = "Attribute_Trn";
            StyleString = ((edtavTrgestiontareas_descripcion_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;");
            GxWebStd.gx_html_textarea( context, edtavTrgestiontareas_descripcion_Internalname, AV16TrGestionTareas_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 0, 1, edtavTrgestiontareas_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpVisualizarInformacionTarea.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechainicio_var_lefttext_Internalname, "Fecha de inicio : ", "", "", lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-size:"+StringUtil.Str( (decimal)(lblTrgestiontareas_fechainicio_var_lefttext_Fontsize), 3, 0)+"pt;"+((lblTrgestiontareas_fechainicio_var_lefttext_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_111_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontareas_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_fechainicio_Internalname, context.localUtil.Format(AV17TrGestionTareas_FechaInicio, "99/99/9999"), context.localUtil.Format( AV17TrGestionTareas_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_fechainicio_Jsonclick, 0, "Attribute_TrnDate", ((edtavTrgestiontareas_fechainicio_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "", "", "", 1, edtavTrgestiontareas_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpVisualizarInformacionTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontareas_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontareas_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTrgestiontareas_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-size:"+StringUtil.Str( (decimal)(lblTrgestiontareas_fechafin_var_lefttext_Fontsize), 3, 0)+"pt;"+((lblTrgestiontareas_fechafin_var_lefttext_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_111_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontareas_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_fechafin_Internalname, context.localUtil.Format(AV18TrGestionTareas_FechaFin, "99/99/9999"), context.localUtil.Format( AV18TrGestionTareas_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_fechafin_Jsonclick, 0, "Attribute_TrnDate", ((edtavTrgestiontareas_fechafin_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "", "", "", 1, edtavTrgestiontareas_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpVisualizarInformacionTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontareas_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontareas_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_estado_var_lefttext_Internalname, "Estado : ", "", "", lblTrgestiontareas_estado_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "font-size:"+StringUtil.Str( (decimal)(lblTrgestiontareas_estado_var_lefttext_Fontsize), 3, 0)+"pt;"+((lblTrgestiontareas_estado_var_lefttext_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTrgestiontareas_estado, cmbavTrgestiontareas_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0)), 1, cmbavTrgestiontareas_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTrgestiontareas_estado.Enabled, 0, 0, 0, "em", 0, "", ((cmbavTrgestiontareas_estado.FontBold==1) ? "font-weight:bold;" : "font-weight:normal;"), "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, "HLP_WpVisualizarInformacionTarea.htm");
            cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
            AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", (String)(cmbavTrgestiontareas_estado.ToJavascriptSource()), true);
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
            GxWebStd.gx_group_start( context, grpGroup1_Internalname, "Detalle de acciones", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_group1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumns2_maincolumnstable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumncontainertable_etiquetas_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponent_grid_etiquetas_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_65_272( true) ;
         }
         else
         {
            wb_table1_65_272( false) ;
         }
         return  ;
      }

      protected void wb_table1_65_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_etiquetas_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_etiquetas_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_etiquetas_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_80_272( true) ;
         }
         else
         {
            wb_table2_80_272( false) ;
         }
         return  ;
      }

      protected void wb_table2_80_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_etiquetas_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_etiquetas_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid_etiquetasContainer.SetWrapped(nGXWrapped);
            if ( Grid_etiquetasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid_etiquetasContainer"+"DivS\" data-gxgridid=\"111\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_etiquetas_Internalname, subGrid_etiquetas_Internalname, "", "Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_etiquetas_Backcolorstyle == 0 )
               {
                  subGrid_etiquetas_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_etiquetas_Class) > 0 )
                  {
                     subGrid_etiquetas_Linesclass = subGrid_etiquetas_Class+"Title";
                  }
               }
               else
               {
                  subGrid_etiquetas_Titlebackstyle = 1;
                  if ( subGrid_etiquetas_Backcolorstyle == 1 )
                  {
                     subGrid_etiquetas_Titlebackcolor = subGrid_etiquetas_Allbackcolor;
                     if ( StringUtil.Len( subGrid_etiquetas_Class) > 0 )
                     {
                        subGrid_etiquetas_Linesclass = subGrid_etiquetas_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_etiquetas_Class) > 0 )
                     {
                        subGrid_etiquetas_Linesclass = subGrid_etiquetas_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "ID Etiqueta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre de etiqueta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid_etiquetasContainer.AddObjectProperty("GridName", "Grid_etiquetas");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid_etiquetasContainer = new GXWebGrid( context);
               }
               else
               {
                  Grid_etiquetasContainer.Clear();
               }
               Grid_etiquetasContainer.SetWrapped(nGXWrapped);
               Grid_etiquetasContainer.AddObjectProperty("GridName", "Grid_etiquetas");
               Grid_etiquetasContainer.AddObjectProperty("Header", subGrid_etiquetas_Header);
               Grid_etiquetasContainer.AddObjectProperty("Class", "Grid_WorkWith");
               Grid_etiquetasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Backcolorstyle), 1, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Sortable), 1, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("CmpContext", "");
               Grid_etiquetasContainer.AddObjectProperty("InMasterPage", "false");
               Grid_etiquetasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_etiquetasColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A51TrTareasEtiquetas_ID), 13, 0, ".", "")));
               Grid_etiquetasContainer.AddColumnProperties(Grid_etiquetasColumn);
               Grid_etiquetasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_etiquetasColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")));
               Grid_etiquetasContainer.AddColumnProperties(Grid_etiquetasColumn);
               Grid_etiquetasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_etiquetasColumn.AddObjectProperty("Value", StringUtil.RTrim( A54TrTareasEtiquetas_NombreEtiqueta));
               Grid_etiquetasContainer.AddColumnProperties(Grid_etiquetasColumn);
               Grid_etiquetasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Selectedindex), 4, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Allowselection), 1, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Selectioncolor), 9, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Allowhovering), 1, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Hoveringcolor), 9, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Allowcollapsing), 1, 0, ".", "")));
               Grid_etiquetasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 111 )
         {
            wbEnd = 0;
            nRC_GXsfl_111 = (int)(nGXsfl_111_idx-1);
            if ( Grid_etiquetasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid_etiquetasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid_etiquetas", Grid_etiquetasContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid_etiquetasContainerData", Grid_etiquetasContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid_etiquetasContainerData"+"V", Grid_etiquetasContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid_etiquetasContainerData"+"V"+"\" value='"+Grid_etiquetasContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_117_272( true) ;
         }
         else
         {
            wb_table3_117_272( false) ;
         }
         return  ;
      }

      protected void wb_table3_117_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_grid_etiquetas_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            wb_table4_124_272( true) ;
         }
         else
         {
            wb_table4_124_272( false) ;
         }
         return  ;
      }

      protected void wb_table4_124_272e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumncontainertable_comentarios_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponent_grid_comentarios_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table5_152_272( true) ;
         }
         else
         {
            wb_table5_152_272( false) ;
         }
         return  ;
      }

      protected void wb_table5_152_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_comentarios_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_comentarios_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_comentarios_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table6_167_272( true) ;
         }
         else
         {
            wb_table6_167_272( false) ;
         }
         return  ;
      }

      protected void wb_table6_167_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_comentarios_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_comentarios_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid_comentariosContainer.SetWrapped(nGXWrapped);
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid_comentariosContainer"+"DivS\" data-gxgridid=\"198\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_comentarios_Internalname, subGrid_comentarios_Internalname, "", "Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_comentarios_Backcolorstyle == 0 )
               {
                  subGrid_comentarios_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_comentarios_Class) > 0 )
                  {
                     subGrid_comentarios_Linesclass = subGrid_comentarios_Class+"Title";
                  }
               }
               else
               {
                  subGrid_comentarios_Titlebackstyle = 1;
                  if ( subGrid_comentarios_Backcolorstyle == 1 )
                  {
                     subGrid_comentarios_Titlebackcolor = subGrid_comentarios_Allbackcolor;
                     if ( StringUtil.Len( subGrid_comentarios_Class) > 0 )
                     {
                        subGrid_comentarios_Linesclass = subGrid_comentarios_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_comentarios_Class) > 0 )
                     {
                        subGrid_comentarios_Linesclass = subGrid_comentarios_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripcion ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de creacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de modificación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid_comentariosContainer.AddObjectProperty("GridName", "Grid_comentarios");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid_comentariosContainer = new GXWebGrid( context);
               }
               else
               {
                  Grid_comentariosContainer.Clear();
               }
               Grid_comentariosContainer.SetWrapped(nGXWrapped);
               Grid_comentariosContainer.AddObjectProperty("GridName", "Grid_comentarios");
               Grid_comentariosContainer.AddObjectProperty("Header", subGrid_comentarios_Header);
               Grid_comentariosContainer.AddObjectProperty("Class", "Grid_WorkWith");
               Grid_comentariosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Backcolorstyle), 1, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Sortable), 1, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("CmpContext", "");
               Grid_comentariosContainer.AddObjectProperty("InMasterPage", "false");
               Grid_comentariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_comentariosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A35TrTareaComentarios_ID), 13, 0, ".", "")));
               Grid_comentariosContainer.AddColumnProperties(Grid_comentariosColumn);
               Grid_comentariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_comentariosColumn.AddObjectProperty("Value", A36TrTareaComentarios_Descripcion);
               Grid_comentariosContainer.AddColumnProperties(Grid_comentariosColumn);
               Grid_comentariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_comentariosColumn.AddObjectProperty("Value", context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"));
               Grid_comentariosContainer.AddColumnProperties(Grid_comentariosColumn);
               Grid_comentariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_comentariosColumn.AddObjectProperty("Value", context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"));
               Grid_comentariosContainer.AddColumnProperties(Grid_comentariosColumn);
               Grid_comentariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_comentariosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37TrTareaComentarios_Estado), 4, 0, ".", "")));
               Grid_comentariosContainer.AddColumnProperties(Grid_comentariosColumn);
               Grid_comentariosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Selectedindex), 4, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Allowselection), 1, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Selectioncolor), 9, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Allowhovering), 1, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Hoveringcolor), 9, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Allowcollapsing), 1, 0, ".", "")));
               Grid_comentariosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 198 )
         {
            wbEnd = 0;
            nRC_GXsfl_198 = (int)(nGXsfl_198_idx-1);
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid_comentariosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid_comentarios", Grid_comentariosContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid_comentariosContainerData", Grid_comentariosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid_comentariosContainerData"+"V", Grid_comentariosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid_comentariosContainerData"+"V"+"\" value='"+Grid_comentariosContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table7_206_272( true) ;
         }
         else
         {
            wb_table7_206_272( false) ;
         }
         return  ;
      }

      protected void wb_table7_206_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_grid_comentarios_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            wb_table8_213_272( true) ;
         }
         else
         {
            wb_table8_213_272( false) ;
         }
         return  ;
      }

      protected void wb_table8_213_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponent_grid_actividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table9_239_272( true) ;
         }
         else
         {
            wb_table9_239_272( false) ;
         }
         return  ;
      }

      protected void wb_table9_239_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_actividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_actividades_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_actividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table10_254_272( true) ;
         }
         else
         {
            wb_table10_254_272( false) ;
         }
         return  ;
      }

      protected void wb_table10_254_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_actividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_actividades_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid_actividadesContainer.SetWrapped(nGXWrapped);
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid_actividadesContainer"+"DivS\" data-gxgridid=\"285\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_actividades_Internalname, subGrid_actividades_Internalname, "", "Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_actividades_Backcolorstyle == 0 )
               {
                  subGrid_actividades_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_actividades_Class) > 0 )
                  {
                     subGrid_actividades_Linesclass = subGrid_actividades_Class+"Title";
                  }
               }
               else
               {
                  subGrid_actividades_Titlebackstyle = 1;
                  if ( subGrid_actividades_Backcolorstyle == 1 )
                  {
                     subGrid_actividades_Titlebackcolor = subGrid_actividades_Allbackcolor;
                     if ( StringUtil.Len( subGrid_actividades_Class) > 0 )
                     {
                        subGrid_actividades_Linesclass = subGrid_actividades_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_actividades_Class) > 0 )
                     {
                        subGrid_actividades_Linesclass = subGrid_actividades_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "ID Actividad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Actividades_IDTarea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripción") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha de fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid_actividadesContainer.AddObjectProperty("GridName", "Grid_actividades");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid_actividadesContainer = new GXWebGrid( context);
               }
               else
               {
                  Grid_actividadesContainer.Clear();
               }
               Grid_actividadesContainer.SetWrapped(nGXWrapped);
               Grid_actividadesContainer.AddObjectProperty("GridName", "Grid_actividades");
               Grid_actividadesContainer.AddObjectProperty("Header", subGrid_actividades_Header);
               Grid_actividadesContainer.AddObjectProperty("Class", "Grid_WorkWith");
               Grid_actividadesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Backcolorstyle), 1, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Sortable), 1, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("CmpContext", "");
               Grid_actividadesContainer.AddObjectProperty("InMasterPage", "false");
               Grid_actividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_actividadesColumn.AddObjectProperty("Value", context.convertURL( AV62ActualizarActividad_Action));
               Grid_actividadesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavActualizaractividad_action_Tooltiptext));
               Grid_actividadesContainer.AddColumnProperties(Grid_actividadesColumn);
               Grid_actividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_actividadesColumn.AddObjectProperty("Value", context.convertURL( AV70InformacionActividad_Action));
               Grid_actividadesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavInformacionactividad_action_Tooltiptext));
               Grid_actividadesContainer.AddColumnProperties(Grid_actividadesColumn);
               Grid_actividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_actividadesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")));
               Grid_actividadesContainer.AddColumnProperties(Grid_actividadesColumn);
               Grid_actividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_actividadesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TrActividades_IDTarea), 13, 0, ".", "")));
               Grid_actividadesContainer.AddColumnProperties(Grid_actividadesColumn);
               Grid_actividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_actividadesColumn.AddObjectProperty("Value", StringUtil.RTrim( A27TrActividades_Nombre));
               Grid_actividadesContainer.AddColumnProperties(Grid_actividadesColumn);
               Grid_actividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_actividadesColumn.AddObjectProperty("Value", A28TrActividades_Descripcion);
               Grid_actividadesContainer.AddColumnProperties(Grid_actividadesColumn);
               Grid_actividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_actividadesColumn.AddObjectProperty("Value", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
               Grid_actividadesContainer.AddColumnProperties(Grid_actividadesColumn);
               Grid_actividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_actividadesColumn.AddObjectProperty("Value", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
               Grid_actividadesContainer.AddColumnProperties(Grid_actividadesColumn);
               Grid_actividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_actividadesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33TrActividades_Estado), 4, 0, ".", "")));
               Grid_actividadesContainer.AddColumnProperties(Grid_actividadesColumn);
               Grid_actividadesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Selectedindex), 4, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Allowselection), 1, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Selectioncolor), 9, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Allowhovering), 1, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Hoveringcolor), 9, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Allowcollapsing), 1, 0, ".", "")));
               Grid_actividadesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 285 )
         {
            wbEnd = 0;
            nRC_GXsfl_285 = (int)(nGXsfl_285_idx-1);
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid_actividadesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid_actividades", Grid_actividadesContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid_actividadesContainerData", Grid_actividadesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid_actividadesContainerData"+"V", Grid_actividadesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid_actividadesContainerData"+"V"+"\" value='"+Grid_actividadesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table11_297_272( true) ;
         }
         else
         {
            wb_table11_297_272( false) ;
         }
         return  ;
      }

      protected void wb_table11_297_272e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_grid_actividades_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            wb_table12_304_272( true) ;
         }
         else
         {
            wb_table12_304_272( false) ;
         }
         return  ;
      }

      protected void wb_table12_304_272e( bool wbgen )
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
         if ( wbEnd == 111 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid_etiquetasContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid_etiquetasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid_etiquetas", Grid_etiquetasContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid_etiquetasContainerData", Grid_etiquetasContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid_etiquetasContainerData"+"V", Grid_etiquetasContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid_etiquetasContainerData"+"V"+"\" value='"+Grid_etiquetasContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 198 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid_comentariosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid_comentariosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid_comentarios", Grid_comentariosContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid_comentariosContainerData", Grid_comentariosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid_comentariosContainerData"+"V", Grid_comentariosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid_comentariosContainerData"+"V"+"\" value='"+Grid_comentariosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 285 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid_actividadesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid_actividadesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid_actividades", Grid_actividadesContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid_actividadesContainerData", Grid_actividadesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid_actividadesContainerData"+"V", Grid_actividadesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid_actividadesContainerData"+"V"+"\" value='"+Grid_actividadesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START272( )
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
            Form.Meta.addItem("description", "Visualizar información de la tarea", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP270( ) ;
      }

      protected void WS272( )
      {
         START272( ) ;
         EVT272( ) ;
      }

      protected void EVT272( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGFIRST(GRID_ETIQUETAS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingFirst(Grid_Etiquetas)' */
                              E11272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGLAST(GRID_ETIQUETAS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingLast(Grid_Etiquetas)' */
                              E12272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGNEXT(GRID_ETIQUETAS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingNext(Grid_Etiquetas)' */
                              E13272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGPREVIOUS(GRID_ETIQUETAS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingPrevious(Grid_Etiquetas)' */
                              E14272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID_ETIQUETAS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid_Etiquetas)' */
                              E15272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGFIRST(GRID_COMENTARIOS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingFirst(Grid_Comentarios)' */
                              E16272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGNEXT(GRID_COMENTARIOS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingNext(Grid_Comentarios)' */
                              E17272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGPREVIOUS(GRID_COMENTARIOS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingPrevious(Grid_Comentarios)' */
                              E18272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID_COMENTARIOS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid_Comentarios)' */
                              E19272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGLAST(GRID_COMENTARIOS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingLast(Grid_Comentarios)' */
                              E20272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGFIRST(GRID_ACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingFirst(Grid_Actividades)' */
                              E21272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGLAST(GRID_ACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingLast(Grid_Actividades)' */
                              E22272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGNEXT(GRID_ACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingNext(Grid_Actividades)' */
                              E23272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGPREVIOUS(GRID_ACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingPrevious(Grid_Actividades)' */
                              E24272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID_ACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid_Actividades)' */
                              E25272 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRID_ETIQUETAS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRID_ETIQUETAS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_111_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
                              SubsflControlProps_1112( ) ;
                              A51TrTareasEtiquetas_ID = (long)(context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_ID_Internalname), ".", ","));
                              A53TrTareasEtiquetas_IDEtiqueta = (long)(context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_IDEtiqueta_Internalname), ".", ","));
                              A54TrTareasEtiquetas_NombreEtiqueta = cgiGet( edtTrTareasEtiquetas_NombreEtiqueta_Internalname);
                              n54TrTareasEtiquetas_NombreEtiqueta = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E26272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E27272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID_ETIQUETAS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E28272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID_ETIQUETAS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E29272 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "GRID_ACTIVIDADES.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "GRID_ACTIVIDADES.LOAD") == 0 ) )
                           {
                              nGXsfl_285_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_285_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_285_idx), 4, 0), 4, "0");
                              SubsflControlProps_2855( ) ;
                              AV62ActualizarActividad_Action = cgiGet( edtavActualizaractividad_action_Internalname);
                              AssignProp("", false, edtavActualizaractividad_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62ActualizarActividad_Action)) ? AV75Actualizaractividad_action_GXI : context.convertURL( context.PathToRelativeUrl( AV62ActualizarActividad_Action))), !bGXsfl_285_Refreshing);
                              AssignProp("", false, edtavActualizaractividad_action_Internalname, "SrcSet", context.GetImageSrcSet( AV62ActualizarActividad_Action), true);
                              AV70InformacionActividad_Action = cgiGet( edtavInformacionactividad_action_Internalname);
                              AssignProp("", false, edtavInformacionactividad_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV70InformacionActividad_Action)) ? AV76Informacionactividad_action_GXI : context.convertURL( context.PathToRelativeUrl( AV70InformacionActividad_Action))), !bGXsfl_285_Refreshing);
                              AssignProp("", false, edtavInformacionactividad_action_Internalname, "SrcSet", context.GetImageSrcSet( AV70InformacionActividad_Action), true);
                              A26TrActividades_ID = (long)(context.localUtil.CToN( cgiGet( edtTrActividades_ID_Internalname), ".", ","));
                              A25TrActividades_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtTrActividades_IDTarea_Internalname), ".", ","));
                              n25TrActividades_IDTarea = false;
                              A27TrActividades_Nombre = cgiGet( edtTrActividades_Nombre_Internalname);
                              n27TrActividades_Nombre = false;
                              A28TrActividades_Descripcion = cgiGet( edtTrActividades_Descripcion_Internalname);
                              n28TrActividades_Descripcion = false;
                              A29TrActividades_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrActividades_FechaInicio_Internalname), 0));
                              n29TrActividades_FechaInicio = false;
                              A30TrActividades_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrActividades_FechaFin_Internalname), 0));
                              n30TrActividades_FechaFin = false;
                              cmbTrActividades_Estado.Name = cmbTrActividades_Estado_Internalname;
                              cmbTrActividades_Estado.CurrentValue = cgiGet( cmbTrActividades_Estado_Internalname);
                              A33TrActividades_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrActividades_Estado_Internalname), "."));
                              n33TrActividades_Estado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID_ACTIVIDADES.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID_ACTIVIDADES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E31275 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "GRID_COMENTARIOS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "GRID_COMENTARIOS.LOAD") == 0 ) )
                           {
                              nGXsfl_198_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_198_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_198_idx), 4, 0), 4, "0");
                              SubsflControlProps_1984( ) ;
                              A35TrTareaComentarios_ID = (long)(context.localUtil.CToN( cgiGet( edtTrTareaComentarios_ID_Internalname), ".", ","));
                              A36TrTareaComentarios_Descripcion = cgiGet( edtTrTareaComentarios_Descripcion_Internalname);
                              n36TrTareaComentarios_Descripcion = false;
                              A38TrTareaComentarios_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrTareaComentarios_FechaCreacion_Internalname), 0));
                              n38TrTareaComentarios_FechaCreacion = false;
                              A39TrTareaComentarios_FechaModificacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrTareaComentarios_FechaModificacion_Internalname), 0));
                              n39TrTareaComentarios_FechaModificacion = false;
                              cmbTrTareaComentarios_Estado.Name = cmbTrTareaComentarios_Estado_Internalname;
                              cmbTrTareaComentarios_Estado.CurrentValue = cgiGet( cmbTrTareaComentarios_Estado_Internalname);
                              A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrTareaComentarios_Estado_Internalname), "."));
                              n37TrTareaComentarios_Estado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID_COMENTARIOS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E32272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID_COMENTARIOS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E33274 ();
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

      protected void WE272( )
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

      protected void PA272( )
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

      protected void gxnrGrid_etiquetas_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1112( ) ;
         while ( nGXsfl_111_idx <= nRC_GXsfl_111 )
         {
            sendrow_1112( ) ;
            nGXsfl_111_idx = ((subGrid_etiquetas_Islastpage==1)&&(nGXsfl_111_idx+1>subGrid_etiquetas_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid_etiquetasContainer)) ;
         /* End function gxnrGrid_etiquetas_newrow */
      }

      protected void gxnrGrid_comentarios_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1984( ) ;
         while ( nGXsfl_198_idx <= nRC_GXsfl_198 )
         {
            sendrow_1984( ) ;
            nGXsfl_198_idx = ((subGrid_comentarios_Islastpage==1)&&(nGXsfl_198_idx+1>subGrid_comentarios_fnc_Recordsperpage( )) ? 1 : nGXsfl_198_idx+1);
            sGXsfl_198_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_198_idx), 4, 0), 4, "0");
            SubsflControlProps_1984( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid_comentariosContainer)) ;
         /* End function gxnrGrid_comentarios_newrow */
      }

      protected void gxnrGrid_actividades_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2855( ) ;
         while ( nGXsfl_285_idx <= nRC_GXsfl_285 )
         {
            sendrow_2855( ) ;
            nGXsfl_285_idx = ((subGrid_actividades_Islastpage==1)&&(nGXsfl_285_idx+1>subGrid_actividades_fnc_Recordsperpage( )) ? 1 : nGXsfl_285_idx+1);
            sGXsfl_285_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_285_idx), 4, 0), 4, "0");
            SubsflControlProps_2855( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid_actividadesContainer)) ;
         /* End function gxnrGrid_actividades_newrow */
      }

      protected void gxgrGrid_etiquetas_refresh( int subGrid_etiquetas_Rows ,
                                                 long AV26TrGestionTareas_ID ,
                                                 short AV35CurrentPage_Grid_Comentarios ,
                                                 short AV56CurrentPage_Grid_Actividades ,
                                                 long A12TrGestionTareas_ID ,
                                                 String A13TrGestionTareas_Nombre ,
                                                 String A14TrGestionTareas_Descripcion ,
                                                 DateTime A15TrGestionTareas_FechaInicio ,
                                                 DateTime A16TrGestionTareas_FechaFin ,
                                                 short A24TrGestionTareas_Estado ,
                                                 String AV74Pgmname ,
                                                 short AV43CurrentPage_Grid_Etiquetas )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E27272 ();
         GRID_ETIQUETAS_nCurrentRecord = 0;
         RF272( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_etiquetas_refresh */
      }

      protected void gxgrGrid_comentarios_refresh( int subGrid_comentarios_Rows ,
                                                   long AV26TrGestionTareas_ID ,
                                                   short AV43CurrentPage_Grid_Etiquetas ,
                                                   short AV56CurrentPage_Grid_Actividades ,
                                                   long A12TrGestionTareas_ID ,
                                                   String A13TrGestionTareas_Nombre ,
                                                   String A14TrGestionTareas_Descripcion ,
                                                   DateTime A15TrGestionTareas_FechaInicio ,
                                                   DateTime A16TrGestionTareas_FechaFin ,
                                                   short A24TrGestionTareas_Estado ,
                                                   String AV74Pgmname ,
                                                   short AV35CurrentPage_Grid_Comentarios )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E27272 ();
         GRID_COMENTARIOS_nCurrentRecord = 0;
         RF274( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_comentarios_refresh */
      }

      protected void gxgrGrid_actividades_refresh( int subGrid_actividades_Rows ,
                                                   long AV26TrGestionTareas_ID ,
                                                   short AV43CurrentPage_Grid_Etiquetas ,
                                                   short AV35CurrentPage_Grid_Comentarios ,
                                                   long A12TrGestionTareas_ID ,
                                                   String A13TrGestionTareas_Nombre ,
                                                   String A14TrGestionTareas_Descripcion ,
                                                   DateTime A15TrGestionTareas_FechaInicio ,
                                                   DateTime A16TrGestionTareas_FechaFin ,
                                                   short A24TrGestionTareas_Estado ,
                                                   String AV74Pgmname ,
                                                   short AV56CurrentPage_Grid_Actividades )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E27272 ();
         GRID_ACTIVIDADES_nCurrentRecord = 0;
         RF275( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_actividades_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRACTIVIDADES_IDTAREA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A25TrActividades_IDTarea), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_IDTAREA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TrActividades_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A26TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")));
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
         if ( cmbavTrgestiontareas_estado.ItemCount > 0 )
         {
            AV19TrGestionTareas_Estado = (short)(NumberUtil.Val( cmbavTrgestiontareas_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV19TrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
            AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", cmbavTrgestiontareas_estado.ToJavascriptSource(), true);
         }
         if ( cmbavGridsettingsrowsperpage_grid_etiquetas.ItemCount > 0 )
         {
            AV47GridSettingsRowsPerPage_Grid_Etiquetas = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid_etiquetas.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0))), "."));
            AssignAttri("", false, "AV47GridSettingsRowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid_etiquetas.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname, "Values", cmbavGridsettingsrowsperpage_grid_etiquetas.ToJavascriptSource(), true);
         }
         if ( cmbavGridsettingsrowsperpage_grid_comentarios.ItemCount > 0 )
         {
            AV42GridSettingsRowsPerPage_Grid_Comentarios = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid_comentarios.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0))), "."));
            AssignAttri("", false, "AV42GridSettingsRowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid_comentarios.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_comentarios_Internalname, "Values", cmbavGridsettingsrowsperpage_grid_comentarios.ToJavascriptSource(), true);
         }
         if ( cmbavGridsettingsrowsperpage_grid_actividades.ItemCount > 0 )
         {
            AV60GridSettingsRowsPerPage_Grid_Actividades = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid_actividades.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridSettingsRowsPerPage_Grid_Actividades), 4, 0))), "."));
            AssignAttri("", false, "AV60GridSettingsRowsPerPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV60GridSettingsRowsPerPage_Grid_Actividades), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid_actividades.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridSettingsRowsPerPage_Grid_Actividades), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_actividades_Internalname, "Values", cmbavGridsettingsrowsperpage_grid_actividades.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E27272 ();
         RF272( ) ;
         RF274( ) ;
         RF275( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV74Pgmname = "WpVisualizarInformacionTarea";
         context.Gx_err = 0;
         edtavTrgestiontareas_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_nombre_Enabled), 5, 0), true);
         edtavTrgestiontareas_descripcion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_descripcion_Enabled), 5, 0), true);
         edtavTrgestiontareas_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechainicio_Enabled), 5, 0), true);
         edtavTrgestiontareas_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechafin_Enabled), 5, 0), true);
         cmbavTrgestiontareas_estado.Enabled = 0;
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrgestiontareas_estado.Enabled), 5, 0), true);
      }

      protected void RF272( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid_etiquetasContainer.ClearRows();
         }
         wbStart = 111;
         E28272 ();
         nGXsfl_111_idx = 1;
         sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
         SubsflControlProps_1112( ) ;
         bGXsfl_111_Refreshing = true;
         Grid_etiquetasContainer.AddObjectProperty("GridName", "Grid_etiquetas");
         Grid_etiquetasContainer.AddObjectProperty("CmpContext", "");
         Grid_etiquetasContainer.AddObjectProperty("InMasterPage", "false");
         Grid_etiquetasContainer.AddObjectProperty("Class", "Grid_WorkWith");
         Grid_etiquetasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid_etiquetasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid_etiquetasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Backcolorstyle), 1, 0, ".", "")));
         Grid_etiquetasContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Sortable), 1, 0, ".", "")));
         Grid_etiquetasContainer.PageSize = subGrid_etiquetas_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1112( ) ;
            GXPagingFrom2 = (int)(((subGrid_etiquetas_Rows==0) ? 0 : GRID_ETIQUETAS_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_etiquetas_Rows==0) ? 10000 : subGrid_etiquetas_fnc_Recordsperpage( )+1);
            /* Using cursor H00272 */
            pr_default.execute(0, new Object[] {AV26TrGestionTareas_ID, GXPagingFrom2, GXPagingTo2});
            nGXsfl_111_idx = 1;
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_etiquetas_Rows == 0 ) || ( GRID_ETIQUETAS_nCurrentRecord < subGrid_etiquetas_fnc_Recordsperpage( ) ) ) ) )
            {
               A52TrTareasEtiquetas_TareaID = H00272_A52TrTareasEtiquetas_TareaID[0];
               A54TrTareasEtiquetas_NombreEtiqueta = H00272_A54TrTareasEtiquetas_NombreEtiqueta[0];
               n54TrTareasEtiquetas_NombreEtiqueta = H00272_n54TrTareasEtiquetas_NombreEtiqueta[0];
               A53TrTareasEtiquetas_IDEtiqueta = H00272_A53TrTareasEtiquetas_IDEtiqueta[0];
               A51TrTareasEtiquetas_ID = H00272_A51TrTareasEtiquetas_ID[0];
               A54TrTareasEtiquetas_NombreEtiqueta = H00272_A54TrTareasEtiquetas_NombreEtiqueta[0];
               n54TrTareasEtiquetas_NombreEtiqueta = H00272_n54TrTareasEtiquetas_NombreEtiqueta[0];
               E29272 ();
               pr_default.readNext(0);
            }
            GRID_ETIQUETAS_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 111;
            WB270( ) ;
         }
         bGXsfl_111_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes272( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
      }

      protected void RF274( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid_comentariosContainer.ClearRows();
         }
         wbStart = 198;
         E32272 ();
         nGXsfl_198_idx = 1;
         sGXsfl_198_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_198_idx), 4, 0), 4, "0");
         SubsflControlProps_1984( ) ;
         bGXsfl_198_Refreshing = true;
         Grid_comentariosContainer.AddObjectProperty("GridName", "Grid_comentarios");
         Grid_comentariosContainer.AddObjectProperty("CmpContext", "");
         Grid_comentariosContainer.AddObjectProperty("InMasterPage", "false");
         Grid_comentariosContainer.AddObjectProperty("Class", "Grid_WorkWith");
         Grid_comentariosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid_comentariosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid_comentariosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Backcolorstyle), 1, 0, ".", "")));
         Grid_comentariosContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Sortable), 1, 0, ".", "")));
         Grid_comentariosContainer.PageSize = subGrid_comentarios_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1984( ) ;
            GXPagingFrom4 = (int)(((subGrid_comentarios_Rows==0) ? 0 : GRID_COMENTARIOS_nFirstRecordOnPage));
            GXPagingTo4 = ((subGrid_comentarios_Rows==0) ? 10000 : subGrid_comentarios_fnc_Recordsperpage( )+1);
            /* Using cursor H00273 */
            pr_default.execute(1, new Object[] {AV26TrGestionTareas_ID, GXPagingFrom4, GXPagingTo4});
            nGXsfl_198_idx = 1;
            sGXsfl_198_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_198_idx), 4, 0), 4, "0");
            SubsflControlProps_1984( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_comentarios_Rows == 0 ) || ( GRID_COMENTARIOS_nCurrentRecord < subGrid_comentarios_fnc_Recordsperpage( ) ) ) ) )
            {
               A34TrTareaComentarios_IDTarea = H00273_A34TrTareaComentarios_IDTarea[0];
               n34TrTareaComentarios_IDTarea = H00273_n34TrTareaComentarios_IDTarea[0];
               A37TrTareaComentarios_Estado = H00273_A37TrTareaComentarios_Estado[0];
               n37TrTareaComentarios_Estado = H00273_n37TrTareaComentarios_Estado[0];
               A39TrTareaComentarios_FechaModificacion = H00273_A39TrTareaComentarios_FechaModificacion[0];
               n39TrTareaComentarios_FechaModificacion = H00273_n39TrTareaComentarios_FechaModificacion[0];
               A38TrTareaComentarios_FechaCreacion = H00273_A38TrTareaComentarios_FechaCreacion[0];
               n38TrTareaComentarios_FechaCreacion = H00273_n38TrTareaComentarios_FechaCreacion[0];
               A36TrTareaComentarios_Descripcion = H00273_A36TrTareaComentarios_Descripcion[0];
               n36TrTareaComentarios_Descripcion = H00273_n36TrTareaComentarios_Descripcion[0];
               A35TrTareaComentarios_ID = H00273_A35TrTareaComentarios_ID[0];
               E33274 ();
               pr_default.readNext(1);
            }
            GRID_COMENTARIOS_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 198;
            WB270( ) ;
         }
         bGXsfl_198_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes274( )
      {
      }

      protected void RF275( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid_actividadesContainer.ClearRows();
         }
         wbStart = 285;
         E30272 ();
         nGXsfl_285_idx = 1;
         sGXsfl_285_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_285_idx), 4, 0), 4, "0");
         SubsflControlProps_2855( ) ;
         bGXsfl_285_Refreshing = true;
         Grid_actividadesContainer.AddObjectProperty("GridName", "Grid_actividades");
         Grid_actividadesContainer.AddObjectProperty("CmpContext", "");
         Grid_actividadesContainer.AddObjectProperty("InMasterPage", "false");
         Grid_actividadesContainer.AddObjectProperty("Class", "Grid_WorkWith");
         Grid_actividadesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid_actividadesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid_actividadesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Backcolorstyle), 1, 0, ".", "")));
         Grid_actividadesContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Sortable), 1, 0, ".", "")));
         Grid_actividadesContainer.PageSize = subGrid_actividades_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_2855( ) ;
            GXPagingFrom5 = (int)(((subGrid_actividades_Rows==0) ? 0 : GRID_ACTIVIDADES_nFirstRecordOnPage));
            GXPagingTo5 = ((subGrid_actividades_Rows==0) ? 10000 : subGrid_actividades_fnc_Recordsperpage( )+1);
            /* Using cursor H00274 */
            pr_default.execute(2, new Object[] {AV26TrGestionTareas_ID, GXPagingFrom5, GXPagingTo5});
            nGXsfl_285_idx = 1;
            sGXsfl_285_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_285_idx), 4, 0), 4, "0");
            SubsflControlProps_2855( ) ;
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGrid_actividades_Rows == 0 ) || ( GRID_ACTIVIDADES_nCurrentRecord < subGrid_actividades_fnc_Recordsperpage( ) ) ) ) )
            {
               A33TrActividades_Estado = H00274_A33TrActividades_Estado[0];
               n33TrActividades_Estado = H00274_n33TrActividades_Estado[0];
               A30TrActividades_FechaFin = H00274_A30TrActividades_FechaFin[0];
               n30TrActividades_FechaFin = H00274_n30TrActividades_FechaFin[0];
               A29TrActividades_FechaInicio = H00274_A29TrActividades_FechaInicio[0];
               n29TrActividades_FechaInicio = H00274_n29TrActividades_FechaInicio[0];
               A28TrActividades_Descripcion = H00274_A28TrActividades_Descripcion[0];
               n28TrActividades_Descripcion = H00274_n28TrActividades_Descripcion[0];
               A27TrActividades_Nombre = H00274_A27TrActividades_Nombre[0];
               n27TrActividades_Nombre = H00274_n27TrActividades_Nombre[0];
               A25TrActividades_IDTarea = H00274_A25TrActividades_IDTarea[0];
               n25TrActividades_IDTarea = H00274_n25TrActividades_IDTarea[0];
               A26TrActividades_ID = H00274_A26TrActividades_ID[0];
               E31275 ();
               pr_default.readNext(2);
            }
            GRID_ACTIVIDADES_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ACTIVIDADES_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 285;
            WB270( ) ;
         }
         bGXsfl_285_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes275( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRACTIVIDADES_IDTAREA"+"_"+sGXsfl_285_idx, GetSecureSignedToken( sGXsfl_285_idx, context.localUtil.Format( (decimal)(A25TrActividades_IDTarea), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TRACTIVIDADES_ID"+"_"+sGXsfl_285_idx, GetSecureSignedToken( sGXsfl_285_idx, context.localUtil.Format( (decimal)(A26TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
      }

      protected int subGrid_etiquetas_fnc_Pagecount( )
      {
         GRID_ETIQUETAS_nRecordCount = subGrid_etiquetas_fnc_Recordcount( );
         if ( ((int)((GRID_ETIQUETAS_nRecordCount) % (subGrid_etiquetas_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_ETIQUETAS_nRecordCount/ (decimal)(subGrid_etiquetas_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_ETIQUETAS_nRecordCount/ (decimal)(subGrid_etiquetas_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_etiquetas_fnc_Recordcount( )
      {
         /* Using cursor H00275 */
         pr_default.execute(3, new Object[] {AV26TrGestionTareas_ID});
         GRID_ETIQUETAS_nRecordCount = H00275_AGRID_ETIQUETAS_nRecordCount[0];
         pr_default.close(3);
         return (int)(GRID_ETIQUETAS_nRecordCount) ;
      }

      protected int subGrid_etiquetas_fnc_Recordsperpage( )
      {
         if ( subGrid_etiquetas_Rows > 0 )
         {
            return subGrid_etiquetas_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_etiquetas_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_ETIQUETAS_nFirstRecordOnPage/ (decimal)(subGrid_etiquetas_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_etiquetas_firstpage( )
      {
         GRID_ETIQUETAS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_etiquetas_nextpage( )
      {
         GRID_ETIQUETAS_nRecordCount = subGrid_etiquetas_fnc_Recordcount( );
         if ( ( GRID_ETIQUETAS_nRecordCount >= subGrid_etiquetas_fnc_Recordsperpage( ) ) && ( GRID_ETIQUETAS_nEOF == 0 ) )
         {
            GRID_ETIQUETAS_nFirstRecordOnPage = (long)(GRID_ETIQUETAS_nFirstRecordOnPage+subGrid_etiquetas_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid_etiquetasContainer.AddObjectProperty("GRID_ETIQUETAS_nFirstRecordOnPage", GRID_ETIQUETAS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_ETIQUETAS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_etiquetas_previouspage( )
      {
         if ( GRID_ETIQUETAS_nFirstRecordOnPage >= subGrid_etiquetas_fnc_Recordsperpage( ) )
         {
            GRID_ETIQUETAS_nFirstRecordOnPage = (long)(GRID_ETIQUETAS_nFirstRecordOnPage-subGrid_etiquetas_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_etiquetas_lastpage( )
      {
         GRID_ETIQUETAS_nRecordCount = subGrid_etiquetas_fnc_Recordcount( );
         if ( GRID_ETIQUETAS_nRecordCount > subGrid_etiquetas_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_ETIQUETAS_nRecordCount) % (subGrid_etiquetas_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_ETIQUETAS_nFirstRecordOnPage = (long)(GRID_ETIQUETAS_nRecordCount-subGrid_etiquetas_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_ETIQUETAS_nFirstRecordOnPage = (long)(GRID_ETIQUETAS_nRecordCount-((int)((GRID_ETIQUETAS_nRecordCount) % (subGrid_etiquetas_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_ETIQUETAS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_etiquetas_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_ETIQUETAS_nFirstRecordOnPage = (long)(subGrid_etiquetas_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_ETIQUETAS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGrid_comentarios_fnc_Pagecount( )
      {
         GRID_COMENTARIOS_nRecordCount = subGrid_comentarios_fnc_Recordcount( );
         if ( ((int)((GRID_COMENTARIOS_nRecordCount) % (subGrid_comentarios_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_COMENTARIOS_nRecordCount/ (decimal)(subGrid_comentarios_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_COMENTARIOS_nRecordCount/ (decimal)(subGrid_comentarios_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_comentarios_fnc_Recordcount( )
      {
         /* Using cursor H00276 */
         pr_default.execute(4, new Object[] {AV26TrGestionTareas_ID});
         GRID_COMENTARIOS_nRecordCount = H00276_AGRID_COMENTARIOS_nRecordCount[0];
         pr_default.close(4);
         return (int)(GRID_COMENTARIOS_nRecordCount) ;
      }

      protected int subGrid_comentarios_fnc_Recordsperpage( )
      {
         if ( subGrid_comentarios_Rows > 0 )
         {
            return subGrid_comentarios_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_comentarios_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_COMENTARIOS_nFirstRecordOnPage/ (decimal)(subGrid_comentarios_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_comentarios_firstpage( )
      {
         GRID_COMENTARIOS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV35CurrentPage_Grid_Comentarios) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_comentarios_nextpage( )
      {
         GRID_COMENTARIOS_nRecordCount = subGrid_comentarios_fnc_Recordcount( );
         if ( ( GRID_COMENTARIOS_nRecordCount >= subGrid_comentarios_fnc_Recordsperpage( ) ) && ( GRID_COMENTARIOS_nEOF == 0 ) )
         {
            GRID_COMENTARIOS_nFirstRecordOnPage = (long)(GRID_COMENTARIOS_nFirstRecordOnPage+subGrid_comentarios_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid_comentariosContainer.AddObjectProperty("GRID_COMENTARIOS_nFirstRecordOnPage", GRID_COMENTARIOS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV35CurrentPage_Grid_Comentarios) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_COMENTARIOS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_comentarios_previouspage( )
      {
         if ( GRID_COMENTARIOS_nFirstRecordOnPage >= subGrid_comentarios_fnc_Recordsperpage( ) )
         {
            GRID_COMENTARIOS_nFirstRecordOnPage = (long)(GRID_COMENTARIOS_nFirstRecordOnPage-subGrid_comentarios_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV35CurrentPage_Grid_Comentarios) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_comentarios_lastpage( )
      {
         GRID_COMENTARIOS_nRecordCount = subGrid_comentarios_fnc_Recordcount( );
         if ( GRID_COMENTARIOS_nRecordCount > subGrid_comentarios_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_COMENTARIOS_nRecordCount) % (subGrid_comentarios_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_COMENTARIOS_nFirstRecordOnPage = (long)(GRID_COMENTARIOS_nRecordCount-subGrid_comentarios_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_COMENTARIOS_nFirstRecordOnPage = (long)(GRID_COMENTARIOS_nRecordCount-((int)((GRID_COMENTARIOS_nRecordCount) % (subGrid_comentarios_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_COMENTARIOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV35CurrentPage_Grid_Comentarios) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_comentarios_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_COMENTARIOS_nFirstRecordOnPage = (long)(subGrid_comentarios_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_COMENTARIOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV35CurrentPage_Grid_Comentarios) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGrid_actividades_fnc_Pagecount( )
      {
         GRID_ACTIVIDADES_nRecordCount = subGrid_actividades_fnc_Recordcount( );
         if ( ((int)((GRID_ACTIVIDADES_nRecordCount) % (subGrid_actividades_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_ACTIVIDADES_nRecordCount/ (decimal)(subGrid_actividades_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_ACTIVIDADES_nRecordCount/ (decimal)(subGrid_actividades_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_actividades_fnc_Recordcount( )
      {
         /* Using cursor H00277 */
         pr_default.execute(5, new Object[] {AV26TrGestionTareas_ID});
         GRID_ACTIVIDADES_nRecordCount = H00277_AGRID_ACTIVIDADES_nRecordCount[0];
         pr_default.close(5);
         return (int)(GRID_ACTIVIDADES_nRecordCount) ;
      }

      protected int subGrid_actividades_fnc_Recordsperpage( )
      {
         if ( subGrid_actividades_Rows > 0 )
         {
            return subGrid_actividades_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_actividades_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_ACTIVIDADES_nFirstRecordOnPage/ (decimal)(subGrid_actividades_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_actividades_firstpage( )
      {
         GRID_ACTIVIDADES_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_actividades_refresh( subGrid_actividades_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV56CurrentPage_Grid_Actividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_actividades_nextpage( )
      {
         GRID_ACTIVIDADES_nRecordCount = subGrid_actividades_fnc_Recordcount( );
         if ( ( GRID_ACTIVIDADES_nRecordCount >= subGrid_actividades_fnc_Recordsperpage( ) ) && ( GRID_ACTIVIDADES_nEOF == 0 ) )
         {
            GRID_ACTIVIDADES_nFirstRecordOnPage = (long)(GRID_ACTIVIDADES_nFirstRecordOnPage+subGrid_actividades_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid_actividadesContainer.AddObjectProperty("GRID_ACTIVIDADES_nFirstRecordOnPage", GRID_ACTIVIDADES_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_actividades_refresh( subGrid_actividades_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV56CurrentPage_Grid_Actividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_ACTIVIDADES_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_actividades_previouspage( )
      {
         if ( GRID_ACTIVIDADES_nFirstRecordOnPage >= subGrid_actividades_fnc_Recordsperpage( ) )
         {
            GRID_ACTIVIDADES_nFirstRecordOnPage = (long)(GRID_ACTIVIDADES_nFirstRecordOnPage-subGrid_actividades_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_actividades_refresh( subGrid_actividades_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV56CurrentPage_Grid_Actividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_actividades_lastpage( )
      {
         GRID_ACTIVIDADES_nRecordCount = subGrid_actividades_fnc_Recordcount( );
         if ( GRID_ACTIVIDADES_nRecordCount > subGrid_actividades_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_ACTIVIDADES_nRecordCount) % (subGrid_actividades_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_ACTIVIDADES_nFirstRecordOnPage = (long)(GRID_ACTIVIDADES_nRecordCount-subGrid_actividades_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_ACTIVIDADES_nFirstRecordOnPage = (long)(GRID_ACTIVIDADES_nRecordCount-((int)((GRID_ACTIVIDADES_nRecordCount) % (subGrid_actividades_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_ACTIVIDADES_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_actividades_refresh( subGrid_actividades_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV56CurrentPage_Grid_Actividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_actividades_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_ACTIVIDADES_nFirstRecordOnPage = (long)(subGrid_actividades_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_ACTIVIDADES_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_actividades_refresh( subGrid_actividades_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV56CurrentPage_Grid_Actividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV74Pgmname = "WpVisualizarInformacionTarea";
         context.Gx_err = 0;
         edtavTrgestiontareas_nombre_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_nombre_Enabled), 5, 0), true);
         edtavTrgestiontareas_descripcion_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_descripcion_Enabled), 5, 0), true);
         edtavTrgestiontareas_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechainicio_Enabled), 5, 0), true);
         edtavTrgestiontareas_fechafin_Enabled = 0;
         AssignProp("", false, edtavTrgestiontareas_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrgestiontareas_fechafin_Enabled), 5, 0), true);
         cmbavTrgestiontareas_estado.Enabled = 0;
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrgestiontareas_estado.Enabled), 5, 0), true);
      }

      protected void STRUP270( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E26272 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_111 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_111"), ".", ","));
            nRC_GXsfl_198 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_198"), ".", ","));
            nRC_GXsfl_285 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_285"), ".", ","));
            AV68TrActividades_ID = (long)(context.localUtil.CToN( cgiGet( "vTRACTIVIDADES_ID"), ".", ","));
            AV69TrActividades_IDTarea = (long)(context.localUtil.CToN( cgiGet( "vTRACTIVIDADES_IDTAREA"), ".", ","));
            GRID_ETIQUETAS_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_ETIQUETAS_nFirstRecordOnPage"), ".", ","));
            GRID_COMENTARIOS_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_COMENTARIOS_nFirstRecordOnPage"), ".", ","));
            GRID_ACTIVIDADES_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_ACTIVIDADES_nFirstRecordOnPage"), ".", ","));
            GRID_ETIQUETAS_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_ETIQUETAS_nEOF"), ".", ","));
            GRID_COMENTARIOS_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_COMENTARIOS_nEOF"), ".", ","));
            GRID_ACTIVIDADES_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_ACTIVIDADES_nEOF"), ".", ","));
            subGrid_etiquetas_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_ETIQUETAS_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Rows), 6, 0, ".", "")));
            subGrid_comentarios_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_COMENTARIOS_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Rows), 6, 0, ".", "")));
            subGrid_actividades_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_ACTIVIDADES_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15TrGestionTareas_Nombre = cgiGet( edtavTrgestiontareas_nombre_Internalname);
            AssignAttri("", false, "AV15TrGestionTareas_Nombre", AV15TrGestionTareas_Nombre);
            AV16TrGestionTareas_Descripcion = cgiGet( edtavTrgestiontareas_descripcion_Internalname);
            AssignAttri("", false, "AV16TrGestionTareas_Descripcion", AV16TrGestionTareas_Descripcion);
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Inicio"}), 1, "vTRGESTIONTAREAS_FECHAINICIO");
               GX_FocusControl = edtavTrgestiontareas_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17TrGestionTareas_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV17TrGestionTareas_FechaInicio", context.localUtil.Format(AV17TrGestionTareas_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV17TrGestionTareas_FechaInicio = context.localUtil.CToD( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 2);
               AssignAttri("", false, "AV17TrGestionTareas_FechaInicio", context.localUtil.Format(AV17TrGestionTareas_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Fin"}), 1, "vTRGESTIONTAREAS_FECHAFIN");
               GX_FocusControl = edtavTrgestiontareas_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18TrGestionTareas_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV18TrGestionTareas_FechaFin", context.localUtil.Format(AV18TrGestionTareas_FechaFin, "99/99/9999"));
            }
            else
            {
               AV18TrGestionTareas_FechaFin = context.localUtil.CToD( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 2);
               AssignAttri("", false, "AV18TrGestionTareas_FechaFin", context.localUtil.Format(AV18TrGestionTareas_FechaFin, "99/99/9999"));
            }
            cmbavTrgestiontareas_estado.Name = cmbavTrgestiontareas_estado_Internalname;
            cmbavTrgestiontareas_estado.CurrentValue = cgiGet( cmbavTrgestiontareas_estado_Internalname);
            AV19TrGestionTareas_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTrgestiontareas_estado_Internalname), "."));
            AssignAttri("", false, "AV19TrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
            cmbavGridsettingsrowsperpage_grid_etiquetas.Name = cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname;
            cmbavGridsettingsrowsperpage_grid_etiquetas.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname);
            AV47GridSettingsRowsPerPage_Grid_Etiquetas = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname), "."));
            AssignAttri("", false, "AV47GridSettingsRowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0));
            cmbavGridsettingsrowsperpage_grid_comentarios.Name = cmbavGridsettingsrowsperpage_grid_comentarios_Internalname;
            cmbavGridsettingsrowsperpage_grid_comentarios.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_comentarios_Internalname);
            AV42GridSettingsRowsPerPage_Grid_Comentarios = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_comentarios_Internalname), "."));
            AssignAttri("", false, "AV42GridSettingsRowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0));
            cmbavGridsettingsrowsperpage_grid_actividades.Name = cmbavGridsettingsrowsperpage_grid_actividades_Internalname;
            cmbavGridsettingsrowsperpage_grid_actividades.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_actividades_Internalname);
            AV60GridSettingsRowsPerPage_Grid_Actividades = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_actividades_Internalname), "."));
            AssignAttri("", false, "AV60GridSettingsRowsPerPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV60GridSettingsRowsPerPage_Grid_Actividades), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            /* Check if conditions changed and reset current page numbers */
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S152( )
      {
         /* 'U_STARTPAGE' Routine */
         /* Using cursor H00278 */
         pr_default.execute(6, new Object[] {AV26TrGestionTareas_ID});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A12TrGestionTareas_ID = H00278_A12TrGestionTareas_ID[0];
            A13TrGestionTareas_Nombre = H00278_A13TrGestionTareas_Nombre[0];
            n13TrGestionTareas_Nombre = H00278_n13TrGestionTareas_Nombre[0];
            A14TrGestionTareas_Descripcion = H00278_A14TrGestionTareas_Descripcion[0];
            n14TrGestionTareas_Descripcion = H00278_n14TrGestionTareas_Descripcion[0];
            A15TrGestionTareas_FechaInicio = H00278_A15TrGestionTareas_FechaInicio[0];
            n15TrGestionTareas_FechaInicio = H00278_n15TrGestionTareas_FechaInicio[0];
            A16TrGestionTareas_FechaFin = H00278_A16TrGestionTareas_FechaFin[0];
            n16TrGestionTareas_FechaFin = H00278_n16TrGestionTareas_FechaFin[0];
            A24TrGestionTareas_Estado = H00278_A24TrGestionTareas_Estado[0];
            n24TrGestionTareas_Estado = H00278_n24TrGestionTareas_Estado[0];
            AV15TrGestionTareas_Nombre = A13TrGestionTareas_Nombre;
            AssignAttri("", false, "AV15TrGestionTareas_Nombre", AV15TrGestionTareas_Nombre);
            AV16TrGestionTareas_Descripcion = A14TrGestionTareas_Descripcion;
            AssignAttri("", false, "AV16TrGestionTareas_Descripcion", AV16TrGestionTareas_Descripcion);
            AV17TrGestionTareas_FechaInicio = A15TrGestionTareas_FechaInicio;
            AssignAttri("", false, "AV17TrGestionTareas_FechaInicio", context.localUtil.Format(AV17TrGestionTareas_FechaInicio, "99/99/9999"));
            AV18TrGestionTareas_FechaFin = A16TrGestionTareas_FechaFin;
            AssignAttri("", false, "AV18TrGestionTareas_FechaFin", context.localUtil.Format(AV18TrGestionTareas_FechaFin, "99/99/9999"));
            AV19TrGestionTareas_Estado = A24TrGestionTareas_Estado;
            AssignAttri("", false, "AV19TrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
         lblTrgestiontareas_id_var_lefttext_Fontbold = 1;
         AssignProp("", false, lblTrgestiontareas_id_var_lefttext_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTrgestiontareas_id_var_lefttext_Fontbold), 1, 0), true);
         lblTrgestiontareas_nombre_var_lefttext_Fontbold = 1;
         AssignProp("", false, lblTrgestiontareas_nombre_var_lefttext_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTrgestiontareas_nombre_var_lefttext_Fontbold), 1, 0), true);
         lblTrgestiontareas_descripcion_var_lefttext_Fontbold = 1;
         AssignProp("", false, lblTrgestiontareas_descripcion_var_lefttext_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTrgestiontareas_descripcion_var_lefttext_Fontbold), 1, 0), true);
         lblTrgestiontareas_fechainicio_var_lefttext_Fontbold = 1;
         AssignProp("", false, lblTrgestiontareas_fechainicio_var_lefttext_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTrgestiontareas_fechainicio_var_lefttext_Fontbold), 1, 0), true);
         lblTrgestiontareas_fechafin_var_lefttext_Fontbold = 1;
         AssignProp("", false, lblTrgestiontareas_fechafin_var_lefttext_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTrgestiontareas_fechafin_var_lefttext_Fontbold), 1, 0), true);
         lblTrgestiontareas_estado_var_lefttext_Fontbold = 1;
         AssignProp("", false, lblTrgestiontareas_estado_var_lefttext_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTrgestiontareas_estado_var_lefttext_Fontbold), 1, 0), true);
         lblTrgestiontareas_nombre_var_lefttext_Fontsize = 10;
         AssignProp("", false, lblTrgestiontareas_nombre_var_lefttext_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTrgestiontareas_nombre_var_lefttext_Fontsize), 9, 0), true);
         lblTrgestiontareas_descripcion_var_lefttext_Fontsize = 10;
         AssignProp("", false, lblTrgestiontareas_descripcion_var_lefttext_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTrgestiontareas_descripcion_var_lefttext_Fontsize), 9, 0), true);
         lblTrgestiontareas_fechainicio_var_lefttext_Fontsize = 10;
         AssignProp("", false, lblTrgestiontareas_fechainicio_var_lefttext_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTrgestiontareas_fechainicio_var_lefttext_Fontsize), 9, 0), true);
         lblTrgestiontareas_fechafin_var_lefttext_Fontsize = 10;
         AssignProp("", false, lblTrgestiontareas_fechafin_var_lefttext_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTrgestiontareas_fechafin_var_lefttext_Fontsize), 9, 0), true);
         lblTrgestiontareas_estado_var_lefttext_Fontsize = 10;
         AssignProp("", false, lblTrgestiontareas_estado_var_lefttext_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTrgestiontareas_estado_var_lefttext_Fontsize), 9, 0), true);
         edtavTrgestiontareas_id_Fontbold = 0;
         AssignProp("", false, edtavTrgestiontareas_id_Internalname, "Fontbold", StringUtil.Str( (decimal)(edtavTrgestiontareas_id_Fontbold), 1, 0), true);
         edtavTrgestiontareas_nombre_Fontbold = 0;
         AssignProp("", false, edtavTrgestiontareas_nombre_Internalname, "Fontbold", StringUtil.Str( (decimal)(edtavTrgestiontareas_nombre_Fontbold), 1, 0), true);
         edtavTrgestiontareas_descripcion_Fontbold = 0;
         AssignProp("", false, edtavTrgestiontareas_descripcion_Internalname, "Fontbold", StringUtil.Str( (decimal)(edtavTrgestiontareas_descripcion_Fontbold), 1, 0), true);
         edtavTrgestiontareas_fechainicio_Fontbold = 0;
         AssignProp("", false, edtavTrgestiontareas_fechainicio_Internalname, "Fontbold", StringUtil.Str( (decimal)(edtavTrgestiontareas_fechainicio_Fontbold), 1, 0), true);
         edtavTrgestiontareas_fechafin_Fontbold = 0;
         AssignProp("", false, edtavTrgestiontareas_fechafin_Internalname, "Fontbold", StringUtil.Str( (decimal)(edtavTrgestiontareas_fechafin_Fontbold), 1, 0), true);
         cmbavTrgestiontareas_estado.FontBold = 0;
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Fontbold", StringUtil.Str( (decimal)(cmbavTrgestiontareas_estado.FontBold), 1, 0), true);
      }

      protected void S162( )
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
         E26272 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E26272( )
      {
         /* Start Routine */
         new k2bloadrowsperpage(context ).execute(  AV74Pgmname,  "Grid_Etiquetas", out  AV45RowsPerPage_Grid_Etiquetas, out  AV46RowsPerPageLoaded_Grid_Etiquetas) ;
         AssignAttri("", false, "AV45RowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV45RowsPerPage_Grid_Etiquetas), 4, 0));
         if ( ! AV46RowsPerPageLoaded_Grid_Etiquetas )
         {
            AV45RowsPerPage_Grid_Etiquetas = 10;
            AssignAttri("", false, "AV45RowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV45RowsPerPage_Grid_Etiquetas), 4, 0));
         }
         AV47GridSettingsRowsPerPage_Grid_Etiquetas = AV45RowsPerPage_Grid_Etiquetas;
         AssignAttri("", false, "AV47GridSettingsRowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0));
         subGrid_etiquetas_Rows = AV45RowsPerPage_Grid_Etiquetas;
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Rows), 6, 0, ".", "")));
         new k2bloadrowsperpage(context ).execute(  AV74Pgmname,  "Grid_Comentarios", out  AV40RowsPerPage_Grid_Comentarios, out  AV41RowsPerPageLoaded_Grid_Comentarios) ;
         AssignAttri("", false, "AV40RowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV40RowsPerPage_Grid_Comentarios), 4, 0));
         if ( ! AV41RowsPerPageLoaded_Grid_Comentarios )
         {
            AV40RowsPerPage_Grid_Comentarios = 10;
            AssignAttri("", false, "AV40RowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV40RowsPerPage_Grid_Comentarios), 4, 0));
         }
         AV42GridSettingsRowsPerPage_Grid_Comentarios = AV40RowsPerPage_Grid_Comentarios;
         AssignAttri("", false, "AV42GridSettingsRowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0));
         subGrid_comentarios_Rows = AV40RowsPerPage_Grid_Comentarios;
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Rows), 6, 0, ".", "")));
         new k2bloadrowsperpage(context ).execute(  AV74Pgmname,  "Grid_Actividades", out  AV58RowsPerPage_Grid_Actividades, out  AV59RowsPerPageLoaded_Grid_Actividades) ;
         AssignAttri("", false, "AV58RowsPerPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV58RowsPerPage_Grid_Actividades), 4, 0));
         if ( ! AV59RowsPerPageLoaded_Grid_Actividades )
         {
            AV58RowsPerPage_Grid_Actividades = 10;
            AssignAttri("", false, "AV58RowsPerPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV58RowsPerPage_Grid_Actividades), 4, 0));
         }
         AV60GridSettingsRowsPerPage_Grid_Actividades = AV58RowsPerPage_Grid_Actividades;
         AssignAttri("", false, "AV60GridSettingsRowsPerPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV60GridSettingsRowsPerPage_Grid_Actividades), 4, 0));
         subGrid_actividades_Rows = AV58RowsPerPage_Grid_Actividades;
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID_ETIQUETAS)' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID_COMENTARIOS)' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID_ACTIVIDADES)' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E27272( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_etiquetas_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_etiquetas_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_etiquetas_Visible), 5, 0), true);
         if ( (0==AV43CurrentPage_Grid_Etiquetas) )
         {
            AV43CurrentPage_Grid_Etiquetas = 1;
            AssignAttri("", false, "AV43CurrentPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0));
         }
         subGrid_comentarios_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_comentarios_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_comentarios_Visible), 5, 0), true);
         if ( (0==AV35CurrentPage_Grid_Comentarios) )
         {
            AV35CurrentPage_Grid_Comentarios = 1;
            AssignAttri("", false, "AV35CurrentPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0));
         }
         subGrid_actividades_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_actividades_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_actividades_Visible), 5, 0), true);
         if ( (0==AV56CurrentPage_Grid_Actividades) )
         {
            AV56CurrentPage_Grid_Actividades = 1;
            AssignAttri("", false, "AV56CurrentPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV56CurrentPage_Grid_Actividades), 4, 0));
         }
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", cmbavTrgestiontareas_estado.ToJavascriptSource(), true);
      }

      protected void S202( )
      {
         /* 'U_LOADROWVARS(GRID_ETIQUETAS)' Routine */
      }

      protected void E11272( )
      {
         /* 'PagingFirst(Grid_Etiquetas)' Routine */
         subgrid_etiquetas_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ETIQUETAS)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID_ETIQUETAS)' Routine */
         AV48PageCount_Grid_Etiquetas = (short)(subGrid_etiquetas_fnc_Pagecount( ));
         if ( AV43CurrentPage_Grid_Etiquetas > AV48PageCount_Grid_Etiquetas )
         {
            AV43CurrentPage_Grid_Etiquetas = AV48PageCount_Grid_Etiquetas;
            AssignAttri("", false, "AV43CurrentPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0));
            subgrid_etiquetas_lastpage( ) ;
         }
         if ( AV48PageCount_Grid_Etiquetas == 0 )
         {
            AV43CurrentPage_Grid_Etiquetas = 0;
            AssignAttri("", false, "AV43CurrentPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0));
         }
         else
         {
            AV43CurrentPage_Grid_Etiquetas = (short)(subGrid_etiquetas_fnc_Currentpage( ));
            AssignAttri("", false, "AV43CurrentPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0));
         }
         lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_etiquetas_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption = StringUtil.Str( (decimal)(AV43CurrentPage_Grid_Etiquetas-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_etiquetas_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption = StringUtil.Str( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_etiquetas_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption = StringUtil.Str( (decimal)(AV43CurrentPage_Grid_Etiquetas+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_etiquetas_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption, true);
         lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption = StringUtil.Str( (decimal)(AV48PageCount_Grid_Etiquetas), 10, 0);
         AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_etiquetas_Internalname, "Caption", lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class, true);
         if ( (0==AV43CurrentPage_Grid_Etiquetas) || ( AV43CurrentPage_Grid_Etiquetas <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class, true);
            cellPaginationbar_firstpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_firstpagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_firstpagecellgrid_etiquetas_Class, true);
            lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible), 5, 0), true);
            cellPaginationbar_spacingleftcellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingleftcellgrid_etiquetas_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_etiquetas_Class, true);
            lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible), 5, 0), true);
            cellPaginationbar_previouspagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_previouspagecellgrid_etiquetas_Class, true);
            lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_previouspagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationPrevious";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_previouspagecellgrid_etiquetas_Class, true);
            lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible), 5, 0), true);
            if ( AV43CurrentPage_Grid_Etiquetas == 2 )
            {
               cellPaginationbar_firstpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_firstpagecellgrid_etiquetas_Class, true);
               lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible), 5, 0), true);
               cellPaginationbar_spacingleftcellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingleftcellgrid_etiquetas_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_etiquetas_Class, true);
               lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_firstpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationLeft";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_firstpagecellgrid_etiquetas_Class, true);
               lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible), 5, 0), true);
               if ( AV43CurrentPage_Grid_Etiquetas == 3 )
               {
                  cellPaginationbar_spacingleftcellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_etiquetas_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_etiquetas_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingleftcellgrid_etiquetas_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_etiquetas_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_etiquetas_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible), 5, 0), true);
               }
            }
         }
         if ( AV43CurrentPage_Grid_Etiquetas == AV48PageCount_Grid_Etiquetas )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class, true);
            cellPaginationbar_lastpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_lastpagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_lastpagecellgrid_etiquetas_Class, true);
            lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible = 0;
            AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible), 5, 0), true);
            cellPaginationbar_spacingrightcellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingrightcellgrid_etiquetas_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_etiquetas_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible), 5, 0), true);
            cellPaginationbar_nextpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_nextpagecellgrid_etiquetas_Class, true);
            lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_nextpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationNext";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_nextpagecellgrid_etiquetas_Class, true);
            lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible), 5, 0), true);
            if ( AV43CurrentPage_Grid_Etiquetas == AV48PageCount_Grid_Etiquetas - 1 )
            {
               cellPaginationbar_lastpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_lastpagecellgrid_etiquetas_Class, true);
               lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible = 0;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible), 5, 0), true);
               cellPaginationbar_spacingrightcellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingrightcellgrid_etiquetas_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_etiquetas_Class, true);
               lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_lastpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationRight";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_etiquetas_Internalname, "Class", cellPaginationbar_lastpagecellgrid_etiquetas_Class, true);
               lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible = 1;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible), 5, 0), true);
               if ( AV43CurrentPage_Grid_Etiquetas == AV48PageCount_Grid_Etiquetas - 2 )
               {
                  cellPaginationbar_spacingrightcellgrid_etiquetas_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_etiquetas_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_etiquetas_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingrightcellgrid_etiquetas_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_etiquetas_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_etiquetas_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV43CurrentPage_Grid_Etiquetas <= 1 ) && ( AV48PageCount_Grid_Etiquetas <= 1 ) )
         {
            tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible = 0;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible), 5, 0), true);
         }
         else
         {
            tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible = 1;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'U_GRIDREFRESH(GRID_ETIQUETAS)' Routine */
      }

      protected void E28272( )
      {
         /* Grid_etiquetas_Refresh Routine */
         tblI_noresultsfoundtablename_grid_etiquetas_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_etiquetas_Visible), 5, 0), true);
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID_ETIQUETAS)' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_etiquetas_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID_ETIQUETAS)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ETIQUETAS)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      private void E29272( )
      {
         /* Grid_etiquetas_Load Routine */
         tblI_noresultsfoundtablename_grid_etiquetas_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_etiquetas_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_ETIQUETAS)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 111;
         }
         sendrow_1112( ) ;
         GRID_ETIQUETAS_nCurrentRecord = (long)(GRID_ETIQUETAS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_111_Refreshing )
         {
            context.DoAjaxLoad(111, Grid_etiquetasRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID_ETIQUETAS)' Routine */
         AV12GridStateKey = "Grid_Etiquetas";
         new k2bloadgridstate(context ).execute(  AV74Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV48PageCount_Grid_Etiquetas = (short)(subGrid_etiquetas_fnc_Pagecount( ));
         if ( ( AV13GridState.gxTpr_Currentpage > 0 ) && ( AV13GridState.gxTpr_Currentpage <= AV48PageCount_Grid_Etiquetas ) )
         {
            AV43CurrentPage_Grid_Etiquetas = AV13GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV43CurrentPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0));
            subgrid_etiquetas_gotopage( AV43CurrentPage_Grid_Etiquetas) ;
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE(GRID_ETIQUETAS)' Routine */
         AV12GridStateKey = "Grid_Etiquetas";
         new k2bloadgridstate(context ).execute(  AV74Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_etiquetas_fnc_Currentpage( ));
         AV13GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV74Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void E12272( )
      {
         /* 'PagingLast(Grid_Etiquetas)' Routine */
         subgrid_etiquetas_lastpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ETIQUETAS)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E13272( )
      {
         /* 'PagingNext(Grid_Etiquetas)' Routine */
         subgrid_etiquetas_nextpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ETIQUETAS)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E14272( )
      {
         /* 'PagingPrevious(Grid_Etiquetas)' Routine */
         subgrid_etiquetas_previouspage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ETIQUETAS)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E15272( )
      {
         /* 'SaveGridSettings(Grid_Etiquetas)' Routine */
         subGrid_etiquetas_Rows = AV47GridSettingsRowsPerPage_Grid_Etiquetas;
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Rows), 6, 0, ".", "")));
         if ( AV45RowsPerPage_Grid_Etiquetas != AV47GridSettingsRowsPerPage_Grid_Etiquetas )
         {
            AV45RowsPerPage_Grid_Etiquetas = AV47GridSettingsRowsPerPage_Grid_Etiquetas;
            AssignAttri("", false, "AV45RowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV45RowsPerPage_Grid_Etiquetas), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV74Pgmname,  "Grid_Etiquetas",  AV45RowsPerPage_Grid_Etiquetas) ;
            AV43CurrentPage_Grid_Etiquetas = 1;
            AssignAttri("", false, "AV43CurrentPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0));
            subgrid_etiquetas_firstpage( ) ;
         }
         gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
         divGridsettings_contentoutertablegrid_etiquetas_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_etiquetas_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", cmbavTrgestiontareas_estado.ToJavascriptSource(), true);
      }

      protected void S244( )
      {
         /* 'U_LOADROWVARS(GRID_COMENTARIOS)' Routine */
      }

      protected void E16272( )
      {
         /* 'PagingFirst(Grid_Comentarios)' Routine */
         subgrid_comentarios_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_COMENTARIOS)' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S212( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID_COMENTARIOS)' Routine */
         AV49PageCount_Grid_Comentarios = (short)(subGrid_comentarios_fnc_Pagecount( ));
         if ( AV35CurrentPage_Grid_Comentarios > AV49PageCount_Grid_Comentarios )
         {
            AV35CurrentPage_Grid_Comentarios = AV49PageCount_Grid_Comentarios;
            AssignAttri("", false, "AV35CurrentPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0));
            subgrid_comentarios_lastpage( ) ;
         }
         if ( AV49PageCount_Grid_Comentarios == 0 )
         {
            AV35CurrentPage_Grid_Comentarios = 0;
            AssignAttri("", false, "AV35CurrentPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0));
         }
         else
         {
            AV35CurrentPage_Grid_Comentarios = (short)(subGrid_comentarios_fnc_Currentpage( ));
            AssignAttri("", false, "AV35CurrentPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0));
         }
         lblPaginationbar_firstpagetextblockgrid_comentarios_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_comentarios_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_comentarios_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_comentarios_Caption = StringUtil.Str( (decimal)(AV35CurrentPage_Grid_Comentarios-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_comentarios_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_comentarios_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_comentarios_Caption = StringUtil.Str( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_comentarios_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_comentarios_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_comentarios_Caption = StringUtil.Str( (decimal)(AV35CurrentPage_Grid_Comentarios+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_comentarios_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_comentarios_Caption, true);
         lblPaginationbar_lastpagetextblockgrid_comentarios_Caption = StringUtil.Str( (decimal)(AV49PageCount_Grid_Comentarios), 10, 0);
         AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_comentarios_Internalname, "Caption", lblPaginationbar_lastpagetextblockgrid_comentarios_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class, true);
         if ( (0==AV35CurrentPage_Grid_Comentarios) || ( AV35CurrentPage_Grid_Comentarios <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class, true);
            cellPaginationbar_firstpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_firstpagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_firstpagecellgrid_comentarios_Class, true);
            lblPaginationbar_firstpagetextblockgrid_comentarios_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_comentarios_Visible), 5, 0), true);
            cellPaginationbar_spacingleftcellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingleftcellgrid_comentarios_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_comentarios_Class, true);
            lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible), 5, 0), true);
            cellPaginationbar_previouspagecellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_previouspagecellgrid_comentarios_Class, true);
            lblPaginationbar_previouspagetextblockgrid_comentarios_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_comentarios_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_previouspagecellgrid_comentarios_Class = "K2BToolsCell_PaginationPrevious";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_previouspagecellgrid_comentarios_Class, true);
            lblPaginationbar_previouspagetextblockgrid_comentarios_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_comentarios_Visible), 5, 0), true);
            if ( AV35CurrentPage_Grid_Comentarios == 2 )
            {
               cellPaginationbar_firstpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_firstpagecellgrid_comentarios_Class, true);
               lblPaginationbar_firstpagetextblockgrid_comentarios_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_comentarios_Visible), 5, 0), true);
               cellPaginationbar_spacingleftcellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingleftcellgrid_comentarios_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_comentarios_Class, true);
               lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_firstpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationLeft";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_firstpagecellgrid_comentarios_Class, true);
               lblPaginationbar_firstpagetextblockgrid_comentarios_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_comentarios_Visible), 5, 0), true);
               if ( AV35CurrentPage_Grid_Comentarios == 3 )
               {
                  cellPaginationbar_spacingleftcellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_comentarios_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_comentarios_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingleftcellgrid_comentarios_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_comentarios_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_comentarios_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible), 5, 0), true);
               }
            }
         }
         if ( AV35CurrentPage_Grid_Comentarios == AV49PageCount_Grid_Comentarios )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class, true);
            cellPaginationbar_lastpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_lastpagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_lastpagecellgrid_comentarios_Class, true);
            lblPaginationbar_lastpagetextblockgrid_comentarios_Visible = 0;
            AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_comentarios_Visible), 5, 0), true);
            cellPaginationbar_spacingrightcellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingrightcellgrid_comentarios_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_comentarios_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible), 5, 0), true);
            cellPaginationbar_nextpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_nextpagecellgrid_comentarios_Class, true);
            lblPaginationbar_nextpagetextblockgrid_comentarios_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_comentarios_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_nextpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationNext";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_nextpagecellgrid_comentarios_Class, true);
            lblPaginationbar_nextpagetextblockgrid_comentarios_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_comentarios_Visible), 5, 0), true);
            if ( AV35CurrentPage_Grid_Comentarios == AV49PageCount_Grid_Comentarios - 1 )
            {
               cellPaginationbar_lastpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_lastpagecellgrid_comentarios_Class, true);
               lblPaginationbar_lastpagetextblockgrid_comentarios_Visible = 0;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_comentarios_Visible), 5, 0), true);
               cellPaginationbar_spacingrightcellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingrightcellgrid_comentarios_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_comentarios_Class, true);
               lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_lastpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationRight";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_comentarios_Internalname, "Class", cellPaginationbar_lastpagecellgrid_comentarios_Class, true);
               lblPaginationbar_lastpagetextblockgrid_comentarios_Visible = 1;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_comentarios_Visible), 5, 0), true);
               if ( AV35CurrentPage_Grid_Comentarios == AV49PageCount_Grid_Comentarios - 2 )
               {
                  cellPaginationbar_spacingrightcellgrid_comentarios_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_comentarios_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_comentarios_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingrightcellgrid_comentarios_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_comentarios_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_comentarios_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV35CurrentPage_Grid_Comentarios <= 1 ) && ( AV49PageCount_Grid_Comentarios <= 1 ) )
         {
            tblPaginationbar_pagingcontainertablegrid_comentarios_Visible = 0;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_comentarios_Visible), 5, 0), true);
         }
         else
         {
            tblPaginationbar_pagingcontainertablegrid_comentarios_Visible = 1;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_comentarios_Visible), 5, 0), true);
         }
      }

      protected void S232( )
      {
         /* 'U_GRIDREFRESH(GRID_COMENTARIOS)' Routine */
      }

      protected void E32272( )
      {
         /* Grid_comentarios_Refresh Routine */
         tblI_noresultsfoundtablename_grid_comentarios_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_comentarios_Visible), 5, 0), true);
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID_COMENTARIOS)' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_comentarios_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID_COMENTARIOS)' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_COMENTARIOS)' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE(GRID_COMENTARIOS)' Routine */
         AV12GridStateKey = "Grid_Comentarios";
         new k2bloadgridstate(context ).execute(  AV74Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV49PageCount_Grid_Comentarios = (short)(subGrid_comentarios_fnc_Pagecount( ));
         if ( ( AV13GridState.gxTpr_Currentpage > 0 ) && ( AV13GridState.gxTpr_Currentpage <= AV49PageCount_Grid_Comentarios ) )
         {
            AV35CurrentPage_Grid_Comentarios = AV13GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV35CurrentPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0));
            subgrid_comentarios_gotopage( AV35CurrentPage_Grid_Comentarios) ;
         }
      }

      protected void S222( )
      {
         /* 'SAVEGRIDSTATE(GRID_COMENTARIOS)' Routine */
         AV12GridStateKey = "Grid_Comentarios";
         new k2bloadgridstate(context ).execute(  AV74Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_comentarios_fnc_Currentpage( ));
         AV13GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV74Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void E17272( )
      {
         /* 'PagingNext(Grid_Comentarios)' Routine */
         subgrid_comentarios_nextpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_COMENTARIOS)' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E18272( )
      {
         /* 'PagingPrevious(Grid_Comentarios)' Routine */
         subgrid_comentarios_previouspage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_COMENTARIOS)' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E19272( )
      {
         /* 'SaveGridSettings(Grid_Comentarios)' Routine */
         subGrid_comentarios_Rows = AV42GridSettingsRowsPerPage_Grid_Comentarios;
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Rows), 6, 0, ".", "")));
         if ( AV40RowsPerPage_Grid_Comentarios != AV42GridSettingsRowsPerPage_Grid_Comentarios )
         {
            AV40RowsPerPage_Grid_Comentarios = AV42GridSettingsRowsPerPage_Grid_Comentarios;
            AssignAttri("", false, "AV40RowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV40RowsPerPage_Grid_Comentarios), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV74Pgmname,  "Grid_Comentarios",  AV40RowsPerPage_Grid_Comentarios) ;
            AV35CurrentPage_Grid_Comentarios = 1;
            AssignAttri("", false, "AV35CurrentPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0));
            subgrid_comentarios_firstpage( ) ;
         }
         gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV56CurrentPage_Grid_Actividades, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV35CurrentPage_Grid_Comentarios) ;
         divGridsettings_contentoutertablegrid_comentarios_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_comentarios_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", cmbavTrgestiontareas_estado.ToJavascriptSource(), true);
      }

      protected void E20272( )
      {
         /* 'PagingLast(Grid_Comentarios)' Routine */
         subgrid_comentarios_lastpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_COMENTARIOS)' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S285( )
      {
         /* 'U_LOADROWVARS(GRID_ACTIVIDADES)' Routine */
         AV69TrActividades_IDTarea = A25TrActividades_IDTarea;
         AssignAttri("", false, "AV69TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV69TrActividades_IDTarea), 13, 0));
         AV68TrActividades_ID = A26TrActividades_ID;
         AssignAttri("", false, "AV68TrActividades_ID", StringUtil.LTrimStr( (decimal)(AV68TrActividades_ID), 13, 0));
      }

      protected void E21272( )
      {
         /* 'PagingFirst(Grid_Actividades)' Routine */
         subgrid_actividades_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ACTIVIDADES)' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S252( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID_ACTIVIDADES)' Routine */
         AV61PageCount_Grid_Actividades = (short)(subGrid_actividades_fnc_Pagecount( ));
         if ( AV56CurrentPage_Grid_Actividades > AV61PageCount_Grid_Actividades )
         {
            AV56CurrentPage_Grid_Actividades = AV61PageCount_Grid_Actividades;
            AssignAttri("", false, "AV56CurrentPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV56CurrentPage_Grid_Actividades), 4, 0));
            subgrid_actividades_lastpage( ) ;
         }
         if ( AV61PageCount_Grid_Actividades == 0 )
         {
            AV56CurrentPage_Grid_Actividades = 0;
            AssignAttri("", false, "AV56CurrentPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV56CurrentPage_Grid_Actividades), 4, 0));
         }
         else
         {
            AV56CurrentPage_Grid_Actividades = (short)(subGrid_actividades_fnc_Currentpage( ));
            AssignAttri("", false, "AV56CurrentPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV56CurrentPage_Grid_Actividades), 4, 0));
         }
         lblPaginationbar_firstpagetextblockgrid_actividades_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_actividades_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_actividades_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_actividades_Caption = StringUtil.Str( (decimal)(AV56CurrentPage_Grid_Actividades-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_actividades_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_actividades_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_actividades_Caption = StringUtil.Str( (decimal)(AV56CurrentPage_Grid_Actividades), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_actividades_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_actividades_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_actividades_Caption = StringUtil.Str( (decimal)(AV56CurrentPage_Grid_Actividades+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_actividades_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_actividades_Caption, true);
         lblPaginationbar_lastpagetextblockgrid_actividades_Caption = StringUtil.Str( (decimal)(AV61PageCount_Grid_Actividades), 10, 0);
         AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_actividades_Internalname, "Caption", lblPaginationbar_lastpagetextblockgrid_actividades_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_actividades_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_actividades_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class, true);
         if ( (0==AV56CurrentPage_Grid_Actividades) || ( AV56CurrentPage_Grid_Actividades <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_actividades_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class, true);
            cellPaginationbar_firstpagecellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_firstpagecellgrid_actividades_Internalname, "Class", cellPaginationbar_firstpagecellgrid_actividades_Class, true);
            lblPaginationbar_firstpagetextblockgrid_actividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_actividades_Visible), 5, 0), true);
            cellPaginationbar_spacingleftcellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingleftcellgrid_actividades_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_actividades_Class, true);
            lblPaginationbar_spacinglefttextblockgrid_actividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_actividades_Visible), 5, 0), true);
            cellPaginationbar_previouspagecellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_actividades_Internalname, "Class", cellPaginationbar_previouspagecellgrid_actividades_Class, true);
            lblPaginationbar_previouspagetextblockgrid_actividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_actividades_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_previouspagecellgrid_actividades_Class = "K2BToolsCell_PaginationPrevious";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_actividades_Internalname, "Class", cellPaginationbar_previouspagecellgrid_actividades_Class, true);
            lblPaginationbar_previouspagetextblockgrid_actividades_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_actividades_Visible), 5, 0), true);
            if ( AV56CurrentPage_Grid_Actividades == 2 )
            {
               cellPaginationbar_firstpagecellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_actividades_Internalname, "Class", cellPaginationbar_firstpagecellgrid_actividades_Class, true);
               lblPaginationbar_firstpagetextblockgrid_actividades_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_actividades_Visible), 5, 0), true);
               cellPaginationbar_spacingleftcellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingleftcellgrid_actividades_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_actividades_Class, true);
               lblPaginationbar_spacinglefttextblockgrid_actividades_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_actividades_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_firstpagecellgrid_actividades_Class = "K2BToolsCell_PaginationLeft";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_actividades_Internalname, "Class", cellPaginationbar_firstpagecellgrid_actividades_Class, true);
               lblPaginationbar_firstpagetextblockgrid_actividades_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_actividades_Visible), 5, 0), true);
               if ( AV56CurrentPage_Grid_Actividades == 3 )
               {
                  cellPaginationbar_spacingleftcellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_actividades_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_actividades_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_actividades_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_actividades_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingleftcellgrid_actividades_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_actividades_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_actividades_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_actividades_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_actividades_Visible), 5, 0), true);
               }
            }
         }
         if ( AV56CurrentPage_Grid_Actividades == AV61PageCount_Grid_Actividades )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_actividades_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class, true);
            cellPaginationbar_lastpagecellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_lastpagecellgrid_actividades_Internalname, "Class", cellPaginationbar_lastpagecellgrid_actividades_Class, true);
            lblPaginationbar_lastpagetextblockgrid_actividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_actividades_Visible), 5, 0), true);
            cellPaginationbar_spacingrightcellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingrightcellgrid_actividades_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_actividades_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_actividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_actividades_Visible), 5, 0), true);
            cellPaginationbar_nextpagecellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_actividades_Internalname, "Class", cellPaginationbar_nextpagecellgrid_actividades_Class, true);
            lblPaginationbar_nextpagetextblockgrid_actividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_actividades_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_nextpagecellgrid_actividades_Class = "K2BToolsCell_PaginationNext";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_actividades_Internalname, "Class", cellPaginationbar_nextpagecellgrid_actividades_Class, true);
            lblPaginationbar_nextpagetextblockgrid_actividades_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_actividades_Visible), 5, 0), true);
            if ( AV56CurrentPage_Grid_Actividades == AV61PageCount_Grid_Actividades - 1 )
            {
               cellPaginationbar_lastpagecellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_actividades_Internalname, "Class", cellPaginationbar_lastpagecellgrid_actividades_Class, true);
               lblPaginationbar_lastpagetextblockgrid_actividades_Visible = 0;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_actividades_Visible), 5, 0), true);
               cellPaginationbar_spacingrightcellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingrightcellgrid_actividades_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_actividades_Class, true);
               lblPaginationbar_spacingrighttextblockgrid_actividades_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_actividades_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_lastpagecellgrid_actividades_Class = "K2BToolsCell_PaginationRight";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_actividades_Internalname, "Class", cellPaginationbar_lastpagecellgrid_actividades_Class, true);
               lblPaginationbar_lastpagetextblockgrid_actividades_Visible = 1;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_actividades_Visible), 5, 0), true);
               if ( AV56CurrentPage_Grid_Actividades == AV61PageCount_Grid_Actividades - 2 )
               {
                  cellPaginationbar_spacingrightcellgrid_actividades_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_actividades_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_actividades_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_actividades_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_actividades_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingrightcellgrid_actividades_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_actividades_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_actividades_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_actividades_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_actividades_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV56CurrentPage_Grid_Actividades <= 1 ) && ( AV61PageCount_Grid_Actividades <= 1 ) )
         {
            tblPaginationbar_pagingcontainertablegrid_actividades_Visible = 0;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_actividades_Visible), 5, 0), true);
         }
         else
         {
            tblPaginationbar_pagingcontainertablegrid_actividades_Visible = 1;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_actividades_Visible), 5, 0), true);
         }
      }

      protected void S272( )
      {
         /* 'U_GRIDREFRESH(GRID_ACTIVIDADES)' Routine */
      }

      protected void E30272( )
      {
         /* Grid_actividades_Refresh Routine */
         tblI_noresultsfoundtablename_grid_actividades_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_actividades_Visible), 5, 0), true);
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID_ACTIVIDADES)' */
         S262 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_actividades_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID_ACTIVIDADES)' */
         S272 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ACTIVIDADES)' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE(GRID_ACTIVIDADES)' Routine */
         AV12GridStateKey = "Grid_Actividades";
         new k2bloadgridstate(context ).execute(  AV74Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV61PageCount_Grid_Actividades = (short)(subGrid_actividades_fnc_Pagecount( ));
         if ( ( AV13GridState.gxTpr_Currentpage > 0 ) && ( AV13GridState.gxTpr_Currentpage <= AV61PageCount_Grid_Actividades ) )
         {
            AV56CurrentPage_Grid_Actividades = AV13GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV56CurrentPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV56CurrentPage_Grid_Actividades), 4, 0));
            subgrid_actividades_gotopage( AV56CurrentPage_Grid_Actividades) ;
         }
      }

      protected void S262( )
      {
         /* 'SAVEGRIDSTATE(GRID_ACTIVIDADES)' Routine */
         AV12GridStateKey = "Grid_Actividades";
         new k2bloadgridstate(context ).execute(  AV74Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_actividades_fnc_Currentpage( ));
         AV13GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV74Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void E22272( )
      {
         /* 'PagingLast(Grid_Actividades)' Routine */
         subgrid_actividades_lastpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ACTIVIDADES)' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E23272( )
      {
         /* 'PagingNext(Grid_Actividades)' Routine */
         subgrid_actividades_nextpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ACTIVIDADES)' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E24272( )
      {
         /* 'PagingPrevious(Grid_Actividades)' Routine */
         subgrid_actividades_previouspage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ACTIVIDADES)' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E25272( )
      {
         /* 'SaveGridSettings(Grid_Actividades)' Routine */
         subGrid_actividades_Rows = AV60GridSettingsRowsPerPage_Grid_Actividades;
         GxWebStd.gx_hidden_field( context, "GRID_ACTIVIDADES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_actividades_Rows), 6, 0, ".", "")));
         if ( AV58RowsPerPage_Grid_Actividades != AV60GridSettingsRowsPerPage_Grid_Actividades )
         {
            AV58RowsPerPage_Grid_Actividades = AV60GridSettingsRowsPerPage_Grid_Actividades;
            AssignAttri("", false, "AV58RowsPerPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV58RowsPerPage_Grid_Actividades), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV74Pgmname,  "Grid_Actividades",  AV58RowsPerPage_Grid_Actividades) ;
            AV56CurrentPage_Grid_Actividades = 1;
            AssignAttri("", false, "AV56CurrentPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV56CurrentPage_Grid_Actividades), 4, 0));
            subgrid_actividades_firstpage( ) ;
         }
         gxgrGrid_actividades_refresh( subGrid_actividades_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV74Pgmname, AV56CurrentPage_Grid_Actividades) ;
         divGridsettings_contentoutertablegrid_actividades_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_actividades_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", cmbavTrgestiontareas_estado.ToJavascriptSource(), true);
      }

      protected void S292( )
      {
         /* 'U_ACTUALIZARACTIVIDAD' Routine */
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_ACTIVIDADES)' */
         S285 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         context.PopUp(formatLink("wpactualizaractividadtarea.aspx") + "?" + UrlEncode("" +AV68TrActividades_ID) + "," + UrlEncode("" +AV69TrActividades_IDTarea), new Object[] {});
      }

      protected void S302( )
      {
         /* 'U_INFORMACIONACTIVIDAD' Routine */
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_ACTIVIDADES)' */
         S285 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         CallWebObject(formatLink("wpvisualizarinformacionactividad.aspx") + "?" + UrlEncode("" +AV68TrActividades_ID) + "," + UrlEncode("" +AV69TrActividades_IDTarea));
         context.wjLocDisableFrm = 1;
      }

      private void E33274( )
      {
         /* Grid_comentarios_Load Routine */
         tblI_noresultsfoundtablename_grid_comentarios_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_comentarios_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_COMENTARIOS)' */
         S244 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 198;
         }
         sendrow_1984( ) ;
         GRID_COMENTARIOS_nCurrentRecord = (long)(GRID_COMENTARIOS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_198_Refreshing )
         {
            context.DoAjaxLoad(198, Grid_comentariosRow);
         }
         /*  Sending Event outputs  */
      }

      private void E31275( )
      {
         /* Grid_actividades_Load Routine */
         tblI_noresultsfoundtablename_grid_actividades_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_actividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_actividades_Visible), 5, 0), true);
         AV62ActualizarActividad_Action = context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( ));
         AssignAttri("", false, edtavActualizaractividad_action_Internalname, AV62ActualizarActividad_Action);
         AV75Actualizaractividad_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( )));
         edtavActualizaractividad_action_Tooltiptext = "Actualizar Actividad";
         AV70InformacionActividad_Action = context.GetImagePath( "2f3769f5-8338-4d4d-977a-358584c21168", "", context.GetTheme( ));
         AssignAttri("", false, edtavInformacionactividad_action_Internalname, AV70InformacionActividad_Action);
         AV76Informacionactividad_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2f3769f5-8338-4d4d-977a-358584c21168", "", context.GetTheme( )));
         edtavInformacionactividad_action_Tooltiptext = "Informacion Actividad";
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_ACTIVIDADES)' */
         S285 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 285;
         }
         sendrow_2855( ) ;
         GRID_ACTIVIDADES_nCurrentRecord = (long)(GRID_ACTIVIDADES_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_285_Refreshing )
         {
            context.DoAjaxLoad(285, Grid_actividadesRow);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table12_304_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblPaginationbar_pagingcontainertablegrid_actividades_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblPaginationbar_pagingcontainertablegrid_actividades_Internalname, tblPaginationbar_pagingcontainertablegrid_actividades_Internalname, "", "K2BToolsTable_PaginationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagebuttoncellgrid_actividades_Internalname+"\"  class='K2BToolsCell_PaginationFirst'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_actividades_Internalname, "&laquo;", "", "", lblPaginationbar_previouspagebuttontextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID_ACTIVIDADES)\\'."+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class, 5, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_firstpagecellgrid_actividades_Internalname+"\"  class='"+cellPaginationbar_firstpagecellgrid_actividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_actividades_Internalname, lblPaginationbar_firstpagetextblockgrid_actividades_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGFIRST(GRID_ACTIVIDADES)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_firstpagetextblockgrid_actividades_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingleftcellgrid_actividades_Internalname+"\"  class='"+cellPaginationbar_spacingleftcellgrid_actividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_actividades_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_actividades_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagecellgrid_actividades_Internalname+"\"  class='"+cellPaginationbar_previouspagecellgrid_actividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_actividades_Internalname, lblPaginationbar_previouspagetextblockgrid_actividades_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID_ACTIVIDADES)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_previouspagetextblockgrid_actividades_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_currentpagecellgrid_actividades_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_actividades_Internalname, lblPaginationbar_currentpagetextblockgrid_actividades_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagecellgrid_actividades_Internalname+"\"  class='"+cellPaginationbar_nextpagecellgrid_actividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_actividades_Internalname, lblPaginationbar_nextpagetextblockgrid_actividades_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID_ACTIVIDADES)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_nextpagetextblockgrid_actividades_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingrightcellgrid_actividades_Internalname+"\"  class='"+cellPaginationbar_spacingrightcellgrid_actividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_actividades_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_actividades_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_lastpagecellgrid_actividades_Internalname+"\"  class='"+cellPaginationbar_lastpagecellgrid_actividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_lastpagetextblockgrid_actividades_Internalname, lblPaginationbar_lastpagetextblockgrid_actividades_Caption, "", "", lblPaginationbar_lastpagetextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGLAST(GRID_ACTIVIDADES)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_lastpagetextblockgrid_actividades_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagebuttoncellgrid_actividades_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_actividades_Internalname, "&raquo;", "", "", lblPaginationbar_nextpagebuttontextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID_ACTIVIDADES)\\'."+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class, 5, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table12_304_272e( true) ;
         }
         else
         {
            wb_table12_304_272e( false) ;
         }
      }

      protected void wb_table11_297_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_actividades_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_actividades_Internalname, tblI_noresultsfoundtablename_grid_actividades_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_actividades_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table11_297_272e( true) ;
         }
         else
         {
            wb_table11_297_272e( false) ;
         }
      }

      protected void wb_table10_254_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_grid_actividades_Internalname, tblLayoutdefined_table7_grid_actividades_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltablegrid_actividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_actividades_Internalname, "", "", "", lblGridsettings_labelgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"e34271_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegrid_actividades_Internalname, divGridsettings_contentoutertablegrid_actividades_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table13_266_272( true) ;
         }
         else
         {
            wb_table13_266_272( false) ;
         }
         return  ;
      }

      protected void wb_table13_266_272e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 275,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_actividades_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "Guardar", bttGridsettings_savegrid_actividades_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID_ACTIVIDADES)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpVisualizarInformacionTarea.htm");
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
            wb_table10_254_272e( true) ;
         }
         else
         {
            wb_table10_254_272e( false) ;
         }
      }

      protected void wb_table13_266_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_actividades_Internalname, tblGridsettings_tablecontentgrid_actividades_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_actividades_Internalname, "Filas por página", "", "", lblGridsettings_rowsperpagetextblockgrid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_actividades_Internalname, "Grid Settings Rows Per Page_Grid_Actividades", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 272,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid_actividades, cmbavGridsettingsrowsperpage_grid_actividades_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridSettingsRowsPerPage_Grid_Actividades), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_actividades_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Filas por página", 1, cmbavGridsettingsrowsperpage_grid_actividades.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,272);\"", "", true, "HLP_WpVisualizarInformacionTarea.htm");
            cmbavGridsettingsrowsperpage_grid_actividades.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridSettingsRowsPerPage_Grid_Actividades), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_actividades_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid_actividades.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table13_266_272e( true) ;
         }
         else
         {
            wb_table13_266_272e( false) ;
         }
      }

      protected void wb_table9_239_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridtitlecontainertable_grid_actividades_Internalname, tblGridtitlecontainertable_grid_actividades_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridtitle_grid_actividades_Internalname, "Lista de actividades", "", "", lblGridtitle_grid_actividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_239_272e( true) ;
         }
         else
         {
            wb_table9_239_272e( false) ;
         }
      }

      protected void wb_table8_213_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblPaginationbar_pagingcontainertablegrid_comentarios_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblPaginationbar_pagingcontainertablegrid_comentarios_Internalname, tblPaginationbar_pagingcontainertablegrid_comentarios_Internalname, "", "K2BToolsTable_PaginationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagebuttoncellgrid_comentarios_Internalname+"\"  class='K2BToolsCell_PaginationFirst'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Internalname, "&laquo;", "", "", lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID_COMENTARIOS)\\'."+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class, 5, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_firstpagecellgrid_comentarios_Internalname+"\"  class='"+cellPaginationbar_firstpagecellgrid_comentarios_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_comentarios_Internalname, lblPaginationbar_firstpagetextblockgrid_comentarios_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGFIRST(GRID_COMENTARIOS)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_firstpagetextblockgrid_comentarios_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingleftcellgrid_comentarios_Internalname+"\"  class='"+cellPaginationbar_spacingleftcellgrid_comentarios_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_comentarios_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagecellgrid_comentarios_Internalname+"\"  class='"+cellPaginationbar_previouspagecellgrid_comentarios_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_comentarios_Internalname, lblPaginationbar_previouspagetextblockgrid_comentarios_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID_COMENTARIOS)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_previouspagetextblockgrid_comentarios_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_currentpagecellgrid_comentarios_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_comentarios_Internalname, lblPaginationbar_currentpagetextblockgrid_comentarios_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagecellgrid_comentarios_Internalname+"\"  class='"+cellPaginationbar_nextpagecellgrid_comentarios_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_comentarios_Internalname, lblPaginationbar_nextpagetextblockgrid_comentarios_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID_COMENTARIOS)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_nextpagetextblockgrid_comentarios_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingrightcellgrid_comentarios_Internalname+"\"  class='"+cellPaginationbar_spacingrightcellgrid_comentarios_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_comentarios_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_lastpagecellgrid_comentarios_Internalname+"\"  class='"+cellPaginationbar_lastpagecellgrid_comentarios_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_lastpagetextblockgrid_comentarios_Internalname, lblPaginationbar_lastpagetextblockgrid_comentarios_Caption, "", "", lblPaginationbar_lastpagetextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGLAST(GRID_COMENTARIOS)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_lastpagetextblockgrid_comentarios_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagebuttoncellgrid_comentarios_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Internalname, "&raquo;", "", "", lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID_COMENTARIOS)\\'."+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class, 5, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_213_272e( true) ;
         }
         else
         {
            wb_table8_213_272e( false) ;
         }
      }

      protected void wb_table7_206_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_comentarios_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_comentarios_Internalname, tblI_noresultsfoundtablename_grid_comentarios_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_comentarios_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_206_272e( true) ;
         }
         else
         {
            wb_table7_206_272e( false) ;
         }
      }

      protected void wb_table6_167_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_grid_comentarios_Internalname, tblLayoutdefined_table7_grid_comentarios_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltablegrid_comentarios_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_comentarios_Internalname, "", "", "", lblGridsettings_labelgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+"e35271_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegrid_comentarios_Internalname, divGridsettings_contentoutertablegrid_comentarios_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table14_179_272( true) ;
         }
         else
         {
            wb_table14_179_272( false) ;
         }
         return  ;
      }

      protected void wb_table14_179_272e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_comentarios_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "Guardar", bttGridsettings_savegrid_comentarios_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID_COMENTARIOS)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpVisualizarInformacionTarea.htm");
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
            wb_table6_167_272e( true) ;
         }
         else
         {
            wb_table6_167_272e( false) ;
         }
      }

      protected void wb_table14_179_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_comentarios_Internalname, tblGridsettings_tablecontentgrid_comentarios_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_comentarios_Internalname, "Filas por página", "", "", lblGridsettings_rowsperpagetextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_comentarios_Internalname, "Grid Settings Rows Per Page_Grid_Comentarios", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 185,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid_comentarios, cmbavGridsettingsrowsperpage_grid_comentarios_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_comentarios_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Filas por página", 1, cmbavGridsettingsrowsperpage_grid_comentarios.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,185);\"", "", true, "HLP_WpVisualizarInformacionTarea.htm");
            cmbavGridsettingsrowsperpage_grid_comentarios.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_comentarios_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid_comentarios.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table14_179_272e( true) ;
         }
         else
         {
            wb_table14_179_272e( false) ;
         }
      }

      protected void wb_table5_152_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridtitlecontainertable_grid_comentarios_Internalname, tblGridtitlecontainertable_grid_comentarios_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridtitle_grid_comentarios_Internalname, "Lista de comentarios", "", "", lblGridtitle_grid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_152_272e( true) ;
         }
         else
         {
            wb_table5_152_272e( false) ;
         }
      }

      protected void wb_table4_124_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblPaginationbar_pagingcontainertablegrid_etiquetas_Internalname, tblPaginationbar_pagingcontainertablegrid_etiquetas_Internalname, "", "K2BToolsTable_PaginationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagebuttoncellgrid_etiquetas_Internalname+"\"  class='K2BToolsCell_PaginationFirst'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Internalname, "&laquo;", "", "", lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID_ETIQUETAS)\\'."+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class, 5, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_firstpagecellgrid_etiquetas_Internalname+"\"  class='"+cellPaginationbar_firstpagecellgrid_etiquetas_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_etiquetas_Internalname, lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGFIRST(GRID_ETIQUETAS)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingleftcellgrid_etiquetas_Internalname+"\"  class='"+cellPaginationbar_spacingleftcellgrid_etiquetas_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_etiquetas_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagecellgrid_etiquetas_Internalname+"\"  class='"+cellPaginationbar_previouspagecellgrid_etiquetas_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_etiquetas_Internalname, lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID_ETIQUETAS)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_currentpagecellgrid_etiquetas_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_etiquetas_Internalname, lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagecellgrid_etiquetas_Internalname+"\"  class='"+cellPaginationbar_nextpagecellgrid_etiquetas_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_etiquetas_Internalname, lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID_ETIQUETAS)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingrightcellgrid_etiquetas_Internalname+"\"  class='"+cellPaginationbar_spacingrightcellgrid_etiquetas_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_etiquetas_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_lastpagecellgrid_etiquetas_Internalname+"\"  class='"+cellPaginationbar_lastpagecellgrid_etiquetas_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_lastpagetextblockgrid_etiquetas_Internalname, lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption, "", "", lblPaginationbar_lastpagetextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGLAST(GRID_ETIQUETAS)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagebuttoncellgrid_etiquetas_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Internalname, "&raquo;", "", "", lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID_ETIQUETAS)\\'."+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class, 5, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_124_272e( true) ;
         }
         else
         {
            wb_table4_124_272e( false) ;
         }
      }

      protected void wb_table3_117_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_etiquetas_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_etiquetas_Internalname, tblI_noresultsfoundtablename_grid_etiquetas_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_etiquetas_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_117_272e( true) ;
         }
         else
         {
            wb_table3_117_272e( false) ;
         }
      }

      protected void wb_table2_80_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_grid_etiquetas_Internalname, tblLayoutdefined_table7_grid_etiquetas_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltablegrid_etiquetas_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_etiquetas_Internalname, "", "", "", lblGridsettings_labelgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+"e36271_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegrid_etiquetas_Internalname, divGridsettings_contentoutertablegrid_etiquetas_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table15_92_272( true) ;
         }
         else
         {
            wb_table15_92_272( false) ;
         }
         return  ;
      }

      protected void wb_table15_92_272e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_etiquetas_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "Guardar", bttGridsettings_savegrid_etiquetas_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID_ETIQUETAS)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpVisualizarInformacionTarea.htm");
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
            wb_table2_80_272e( true) ;
         }
         else
         {
            wb_table2_80_272e( false) ;
         }
      }

      protected void wb_table15_92_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_etiquetas_Internalname, tblGridsettings_tablecontentgrid_etiquetas_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_etiquetas_Internalname, "Filas por página", "", "", lblGridsettings_rowsperpagetextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname, "Grid Settings Rows Per Page_Grid_Etiquetas", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid_etiquetas, cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_etiquetas_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Filas por página", 1, cmbavGridsettingsrowsperpage_grid_etiquetas.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "", true, "HLP_WpVisualizarInformacionTarea.htm");
            cmbavGridsettingsrowsperpage_grid_etiquetas.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid_etiquetas.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table15_92_272e( true) ;
         }
         else
         {
            wb_table15_92_272e( false) ;
         }
      }

      protected void wb_table1_65_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridtitlecontainertable_grid_etiquetas_Internalname, tblGridtitlecontainertable_grid_etiquetas_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridtitle_grid_etiquetas_Internalname, "Lista de etiquetas", "", "", lblGridtitle_grid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_65_272e( true) ;
         }
         else
         {
            wb_table1_65_272e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV26TrGestionTareas_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV26TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV26TrGestionTareas_ID), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
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
         PA272( ) ;
         WS272( ) ;
         WE272( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20221021175140", true, true);
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
         context.AddJavascriptSource("wpvisualizarinformaciontarea.js", "?20221021175140", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1112( )
      {
         edtTrTareasEtiquetas_ID_Internalname = "TRTAREASETIQUETAS_ID_"+sGXsfl_111_idx;
         edtTrTareasEtiquetas_IDEtiqueta_Internalname = "TRTAREASETIQUETAS_IDETIQUETA_"+sGXsfl_111_idx;
         edtTrTareasEtiquetas_NombreEtiqueta_Internalname = "TRTAREASETIQUETAS_NOMBREETIQUETA_"+sGXsfl_111_idx;
      }

      protected void SubsflControlProps_fel_1112( )
      {
         edtTrTareasEtiquetas_ID_Internalname = "TRTAREASETIQUETAS_ID_"+sGXsfl_111_fel_idx;
         edtTrTareasEtiquetas_IDEtiqueta_Internalname = "TRTAREASETIQUETAS_IDETIQUETA_"+sGXsfl_111_fel_idx;
         edtTrTareasEtiquetas_NombreEtiqueta_Internalname = "TRTAREASETIQUETAS_NOMBREETIQUETA_"+sGXsfl_111_fel_idx;
      }

      protected void sendrow_1112( )
      {
         SubsflControlProps_1112( ) ;
         WB270( ) ;
         if ( ( subGrid_etiquetas_Rows * 1 == 0 ) || ( nGXsfl_111_idx <= subGrid_etiquetas_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid_etiquetasRow = GXWebRow.GetNew(context,Grid_etiquetasContainer);
            if ( subGrid_etiquetas_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_etiquetas_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_etiquetas_Class, "") != 0 )
               {
                  subGrid_etiquetas_Linesclass = subGrid_etiquetas_Class+"Odd";
               }
            }
            else if ( subGrid_etiquetas_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_etiquetas_Backstyle = 0;
               subGrid_etiquetas_Backcolor = subGrid_etiquetas_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_etiquetas_Class, "") != 0 )
               {
                  subGrid_etiquetas_Linesclass = subGrid_etiquetas_Class+"Uniform";
               }
            }
            else if ( subGrid_etiquetas_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_etiquetas_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_etiquetas_Class, "") != 0 )
               {
                  subGrid_etiquetas_Linesclass = subGrid_etiquetas_Class+"Odd";
               }
               subGrid_etiquetas_Backcolor = (int)(0x0);
            }
            else if ( subGrid_etiquetas_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_etiquetas_Backstyle = 1;
               if ( ((int)((nGXsfl_111_idx) % (2))) == 0 )
               {
                  subGrid_etiquetas_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_etiquetas_Class, "") != 0 )
                  {
                     subGrid_etiquetas_Linesclass = subGrid_etiquetas_Class+"Even";
                  }
               }
               else
               {
                  subGrid_etiquetas_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_etiquetas_Class, "") != 0 )
                  {
                     subGrid_etiquetas_Linesclass = subGrid_etiquetas_Class+"Odd";
                  }
               }
            }
            if ( Grid_etiquetasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"Grid_WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_111_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid_etiquetasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_etiquetasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareasEtiquetas_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A51TrTareasEtiquetas_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A51TrTareasEtiquetas_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareasEtiquetas_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)111,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_etiquetasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_etiquetasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareasEtiquetas_IDEtiqueta_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareasEtiquetas_IDEtiqueta_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)111,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_etiquetasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_etiquetasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareasEtiquetas_NombreEtiqueta_Internalname,StringUtil.RTrim( A54TrTareasEtiquetas_NombreEtiqueta),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareasEtiquetas_NombreEtiqueta_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)256,(short)0,(short)0,(short)111,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            send_integrity_lvl_hashes272( ) ;
            Grid_etiquetasContainer.AddRow(Grid_etiquetasRow);
            nGXsfl_111_idx = ((subGrid_etiquetas_Islastpage==1)&&(nGXsfl_111_idx+1>subGrid_etiquetas_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
         }
         /* End function sendrow_1112 */
      }

      protected void SubsflControlProps_1984( )
      {
         edtTrTareaComentarios_ID_Internalname = "TRTAREACOMENTARIOS_ID_"+sGXsfl_198_idx;
         edtTrTareaComentarios_Descripcion_Internalname = "TRTAREACOMENTARIOS_DESCRIPCION_"+sGXsfl_198_idx;
         edtTrTareaComentarios_FechaCreacion_Internalname = "TRTAREACOMENTARIOS_FECHACREACION_"+sGXsfl_198_idx;
         edtTrTareaComentarios_FechaModificacion_Internalname = "TRTAREACOMENTARIOS_FECHAMODIFICACION_"+sGXsfl_198_idx;
         cmbTrTareaComentarios_Estado_Internalname = "TRTAREACOMENTARIOS_ESTADO_"+sGXsfl_198_idx;
      }

      protected void SubsflControlProps_fel_1984( )
      {
         edtTrTareaComentarios_ID_Internalname = "TRTAREACOMENTARIOS_ID_"+sGXsfl_198_fel_idx;
         edtTrTareaComentarios_Descripcion_Internalname = "TRTAREACOMENTARIOS_DESCRIPCION_"+sGXsfl_198_fel_idx;
         edtTrTareaComentarios_FechaCreacion_Internalname = "TRTAREACOMENTARIOS_FECHACREACION_"+sGXsfl_198_fel_idx;
         edtTrTareaComentarios_FechaModificacion_Internalname = "TRTAREACOMENTARIOS_FECHAMODIFICACION_"+sGXsfl_198_fel_idx;
         cmbTrTareaComentarios_Estado_Internalname = "TRTAREACOMENTARIOS_ESTADO_"+sGXsfl_198_fel_idx;
      }

      protected void sendrow_1984( )
      {
         SubsflControlProps_1984( ) ;
         WB270( ) ;
         if ( ( subGrid_comentarios_Rows * 1 == 0 ) || ( nGXsfl_198_idx <= subGrid_comentarios_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid_comentariosRow = GXWebRow.GetNew(context,Grid_comentariosContainer);
            if ( subGrid_comentarios_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_comentarios_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_comentarios_Class, "") != 0 )
               {
                  subGrid_comentarios_Linesclass = subGrid_comentarios_Class+"Odd";
               }
            }
            else if ( subGrid_comentarios_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_comentarios_Backstyle = 0;
               subGrid_comentarios_Backcolor = subGrid_comentarios_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_comentarios_Class, "") != 0 )
               {
                  subGrid_comentarios_Linesclass = subGrid_comentarios_Class+"Uniform";
               }
            }
            else if ( subGrid_comentarios_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_comentarios_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_comentarios_Class, "") != 0 )
               {
                  subGrid_comentarios_Linesclass = subGrid_comentarios_Class+"Odd";
               }
               subGrid_comentarios_Backcolor = (int)(0x0);
            }
            else if ( subGrid_comentarios_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_comentarios_Backstyle = 1;
               if ( ((int)((nGXsfl_198_idx) % (2))) == 0 )
               {
                  subGrid_comentarios_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_comentarios_Class, "") != 0 )
                  {
                     subGrid_comentarios_Linesclass = subGrid_comentarios_Class+"Even";
                  }
               }
               else
               {
                  subGrid_comentarios_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_comentarios_Class, "") != 0 )
                  {
                     subGrid_comentarios_Linesclass = subGrid_comentarios_Class+"Odd";
                  }
               }
            }
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"Grid_WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_198_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_comentariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A35TrTareaComentarios_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A35TrTareaComentarios_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)198,(short)1,(short)-1,(short)0,(bool)false,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_comentariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_Descripcion_Internalname,(String)A36TrTareaComentarios_Descripcion,(String)A36TrTareaComentarios_Descripcion,(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_Descripcion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)198,(short)1,(short)0,(short)-1,(bool)false,(String)"",(String)"left",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_comentariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_FechaCreacion_Internalname,context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"),context.localUtil.Format( A38TrTareaComentarios_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_FechaCreacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)198,(short)1,(short)-1,(short)0,(bool)false,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_comentariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_FechaModificacion_Internalname,context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"),context.localUtil.Format( A39TrTareaComentarios_FechaModificacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_FechaModificacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)198,(short)1,(short)-1,(short)0,(bool)false,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTrTareaComentarios_Estado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TRTAREACOMENTARIOS_ESTADO_" + sGXsfl_198_idx;
               cmbTrTareaComentarios_Estado.Name = GXCCtl;
               cmbTrTareaComentarios_Estado.WebTags = "";
               cmbTrTareaComentarios_Estado.addItem("1", "Activo", 0);
               cmbTrTareaComentarios_Estado.addItem("2", "Inactivo", 0);
               cmbTrTareaComentarios_Estado.addItem("3", "Eliminado", 0);
               if ( cmbTrTareaComentarios_Estado.ItemCount > 0 )
               {
                  A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbTrTareaComentarios_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0))), "."));
                  n37TrTareaComentarios_Estado = false;
               }
            }
            /* ComboBox */
            Grid_comentariosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTrTareaComentarios_Estado,(String)cmbTrTareaComentarios_Estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0)),(short)1,(String)cmbTrTareaComentarios_Estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute_Grid",(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(String)"",(String)"",(bool)false});
            cmbTrTareaComentarios_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
            AssignProp("", false, cmbTrTareaComentarios_Estado_Internalname, "Values", (String)(cmbTrTareaComentarios_Estado.ToJavascriptSource()), !bGXsfl_198_Refreshing);
            send_integrity_lvl_hashes274( ) ;
            Grid_comentariosContainer.AddRow(Grid_comentariosRow);
            nGXsfl_198_idx = ((subGrid_comentarios_Islastpage==1)&&(nGXsfl_198_idx+1>subGrid_comentarios_fnc_Recordsperpage( )) ? 1 : nGXsfl_198_idx+1);
            sGXsfl_198_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_198_idx), 4, 0), 4, "0");
            SubsflControlProps_1984( ) ;
         }
         /* End function sendrow_1984 */
      }

      protected void SubsflControlProps_2855( )
      {
         edtavActualizaractividad_action_Internalname = "vACTUALIZARACTIVIDAD_ACTION_"+sGXsfl_285_idx;
         edtavInformacionactividad_action_Internalname = "vINFORMACIONACTIVIDAD_ACTION_"+sGXsfl_285_idx;
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID_"+sGXsfl_285_idx;
         edtTrActividades_IDTarea_Internalname = "TRACTIVIDADES_IDTAREA_"+sGXsfl_285_idx;
         edtTrActividades_Nombre_Internalname = "TRACTIVIDADES_NOMBRE_"+sGXsfl_285_idx;
         edtTrActividades_Descripcion_Internalname = "TRACTIVIDADES_DESCRIPCION_"+sGXsfl_285_idx;
         edtTrActividades_FechaInicio_Internalname = "TRACTIVIDADES_FECHAINICIO_"+sGXsfl_285_idx;
         edtTrActividades_FechaFin_Internalname = "TRACTIVIDADES_FECHAFIN_"+sGXsfl_285_idx;
         cmbTrActividades_Estado_Internalname = "TRACTIVIDADES_ESTADO_"+sGXsfl_285_idx;
      }

      protected void SubsflControlProps_fel_2855( )
      {
         edtavActualizaractividad_action_Internalname = "vACTUALIZARACTIVIDAD_ACTION_"+sGXsfl_285_fel_idx;
         edtavInformacionactividad_action_Internalname = "vINFORMACIONACTIVIDAD_ACTION_"+sGXsfl_285_fel_idx;
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID_"+sGXsfl_285_fel_idx;
         edtTrActividades_IDTarea_Internalname = "TRACTIVIDADES_IDTAREA_"+sGXsfl_285_fel_idx;
         edtTrActividades_Nombre_Internalname = "TRACTIVIDADES_NOMBRE_"+sGXsfl_285_fel_idx;
         edtTrActividades_Descripcion_Internalname = "TRACTIVIDADES_DESCRIPCION_"+sGXsfl_285_fel_idx;
         edtTrActividades_FechaInicio_Internalname = "TRACTIVIDADES_FECHAINICIO_"+sGXsfl_285_fel_idx;
         edtTrActividades_FechaFin_Internalname = "TRACTIVIDADES_FECHAFIN_"+sGXsfl_285_fel_idx;
         cmbTrActividades_Estado_Internalname = "TRACTIVIDADES_ESTADO_"+sGXsfl_285_fel_idx;
      }

      protected void sendrow_2855( )
      {
         SubsflControlProps_2855( ) ;
         WB270( ) ;
         if ( ( subGrid_actividades_Rows * 1 == 0 ) || ( nGXsfl_285_idx <= subGrid_actividades_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid_actividadesRow = GXWebRow.GetNew(context,Grid_actividadesContainer);
            if ( subGrid_actividades_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_actividades_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_actividades_Class, "") != 0 )
               {
                  subGrid_actividades_Linesclass = subGrid_actividades_Class+"Odd";
               }
            }
            else if ( subGrid_actividades_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_actividades_Backstyle = 0;
               subGrid_actividades_Backcolor = subGrid_actividades_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_actividades_Class, "") != 0 )
               {
                  subGrid_actividades_Linesclass = subGrid_actividades_Class+"Uniform";
               }
            }
            else if ( subGrid_actividades_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_actividades_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_actividades_Class, "") != 0 )
               {
                  subGrid_actividades_Linesclass = subGrid_actividades_Class+"Odd";
               }
               subGrid_actividades_Backcolor = (int)(0x0);
            }
            else if ( subGrid_actividades_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_actividades_Backstyle = 1;
               if ( ((int)((nGXsfl_285_idx) % (2))) == 0 )
               {
                  subGrid_actividades_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_actividades_Class, "") != 0 )
                  {
                     subGrid_actividades_Linesclass = subGrid_actividades_Class+"Even";
                  }
               }
               else
               {
                  subGrid_actividades_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_actividades_Class, "") != 0 )
                  {
                     subGrid_actividades_Linesclass = subGrid_actividades_Class+"Odd";
                  }
               }
            }
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"Grid_WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_285_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavActualizaractividad_action_Enabled!=0)&&(edtavActualizaractividad_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 286,'',false,'',285)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV62ActualizarActividad_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV62ActualizarActividad_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV75Actualizaractividad_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV62ActualizarActividad_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV62ActualizarActividad_Action)) ? AV75Actualizaractividad_action_GXI : context.PathToRelativeUrl( AV62ActualizarActividad_Action));
            Grid_actividadesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavActualizaractividad_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Actualizar Actividad",(String)edtavActualizaractividad_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)7,(String)edtavActualizaractividad_action_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+"e37275_client"+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV62ActualizarActividad_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavInformacionactividad_action_Enabled!=0)&&(edtavInformacionactividad_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 287,'',false,'',285)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV70InformacionActividad_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV70InformacionActividad_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV76Informacionactividad_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV70InformacionActividad_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV70InformacionActividad_Action)) ? AV76Informacionactividad_action_GXI : context.PathToRelativeUrl( AV70InformacionActividad_Action));
            Grid_actividadesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavInformacionactividad_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Informacion Actividad",(String)edtavInformacionactividad_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)7,(String)edtavInformacionactividad_action_Jsonclick,(String)"'"+""+"'"+",false,"+"'"+"e38275_client"+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV70InformacionActividad_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_actividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A26TrActividades_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)285,(short)1,(short)-1,(short)0,(bool)false,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_actividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_IDTarea_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TrActividades_IDTarea), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A25TrActividades_IDTarea), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_IDTarea_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)0,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)285,(short)1,(short)-1,(short)0,(bool)false,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_actividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_Nombre_Internalname,StringUtil.RTrim( A27TrActividades_Nombre),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_Nombre_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)285,(short)1,(short)-1,(short)-1,(bool)false,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_actividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_Descripcion_Internalname,(String)A28TrActividades_Descripcion,(String)A28TrActividades_Descripcion,(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_Descripcion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)285,(short)1,(short)0,(short)-1,(bool)false,(String)"",(String)"left",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_actividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_FechaInicio_Internalname,context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"),context.localUtil.Format( A29TrActividades_FechaInicio, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_FechaInicio_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)285,(short)1,(short)-1,(short)0,(bool)false,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_actividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_FechaFin_Internalname,context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"),context.localUtil.Format( A30TrActividades_FechaFin, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_FechaFin_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)285,(short)1,(short)-1,(short)0,(bool)false,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_actividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTrActividades_Estado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TRACTIVIDADES_ESTADO_" + sGXsfl_285_idx;
               cmbTrActividades_Estado.Name = GXCCtl;
               cmbTrActividades_Estado.WebTags = "";
               cmbTrActividades_Estado.addItem("1", "Nuevo", 0);
               cmbTrActividades_Estado.addItem("2", "En Progreso", 0);
               cmbTrActividades_Estado.addItem("3", "Completado", 0);
               cmbTrActividades_Estado.addItem("4", "Detenido", 0);
               cmbTrActividades_Estado.addItem("5", "Pendiente", 0);
               if ( cmbTrActividades_Estado.ItemCount > 0 )
               {
                  A33TrActividades_Estado = (short)(NumberUtil.Val( cmbTrActividades_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0))), "."));
                  n33TrActividades_Estado = false;
               }
            }
            /* ComboBox */
            Grid_actividadesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTrActividades_Estado,(String)cmbTrActividades_Estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0)),(short)1,(String)cmbTrActividades_Estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute_Grid",(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(String)"",(String)"",(bool)false});
            cmbTrActividades_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0));
            AssignProp("", false, cmbTrActividades_Estado_Internalname, "Values", (String)(cmbTrActividades_Estado.ToJavascriptSource()), !bGXsfl_285_Refreshing);
            send_integrity_lvl_hashes275( ) ;
            Grid_actividadesContainer.AddRow(Grid_actividadesRow);
            nGXsfl_285_idx = ((subGrid_actividades_Islastpage==1)&&(nGXsfl_285_idx+1>subGrid_actividades_fnc_Recordsperpage( )) ? 1 : nGXsfl_285_idx+1);
            sGXsfl_285_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_285_idx), 4, 0), 4, "0");
            SubsflControlProps_2855( ) ;
         }
         /* End function sendrow_2855 */
      }

      protected void init_web_controls( )
      {
         cmbavTrgestiontareas_estado.Name = "vTRGESTIONTAREAS_ESTADO";
         cmbavTrgestiontareas_estado.WebTags = "";
         cmbavTrgestiontareas_estado.addItem("1", "Nuevo", 0);
         cmbavTrgestiontareas_estado.addItem("2", "En Progreso", 0);
         cmbavTrgestiontareas_estado.addItem("3", "Completado", 0);
         cmbavTrgestiontareas_estado.addItem("4", "Detenido", 0);
         cmbavTrgestiontareas_estado.addItem("5", "Pendiente", 0);
         if ( cmbavTrgestiontareas_estado.ItemCount > 0 )
         {
            AV19TrGestionTareas_Estado = (short)(NumberUtil.Val( cmbavTrgestiontareas_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV19TrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
         }
         cmbavGridsettingsrowsperpage_grid_etiquetas.Name = "vGRIDSETTINGSROWSPERPAGE_GRID_ETIQUETAS";
         cmbavGridsettingsrowsperpage_grid_etiquetas.WebTags = "";
         cmbavGridsettingsrowsperpage_grid_etiquetas.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid_etiquetas.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid_etiquetas.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid_etiquetas.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid_etiquetas.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid_etiquetas.ItemCount > 0 )
         {
            AV47GridSettingsRowsPerPage_Grid_Etiquetas = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid_etiquetas.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0))), "."));
            AssignAttri("", false, "AV47GridSettingsRowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0));
         }
         cmbavGridsettingsrowsperpage_grid_comentarios.Name = "vGRIDSETTINGSROWSPERPAGE_GRID_COMENTARIOS";
         cmbavGridsettingsrowsperpage_grid_comentarios.WebTags = "";
         cmbavGridsettingsrowsperpage_grid_comentarios.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid_comentarios.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid_comentarios.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid_comentarios.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid_comentarios.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid_comentarios.ItemCount > 0 )
         {
            AV42GridSettingsRowsPerPage_Grid_Comentarios = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid_comentarios.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0))), "."));
            AssignAttri("", false, "AV42GridSettingsRowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0));
         }
         GXCCtl = "TRTAREACOMENTARIOS_ESTADO_" + sGXsfl_198_idx;
         cmbTrTareaComentarios_Estado.Name = GXCCtl;
         cmbTrTareaComentarios_Estado.WebTags = "";
         cmbTrTareaComentarios_Estado.addItem("1", "Activo", 0);
         cmbTrTareaComentarios_Estado.addItem("2", "Inactivo", 0);
         cmbTrTareaComentarios_Estado.addItem("3", "Eliminado", 0);
         if ( cmbTrTareaComentarios_Estado.ItemCount > 0 )
         {
            A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbTrTareaComentarios_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0))), "."));
            n37TrTareaComentarios_Estado = false;
         }
         cmbavGridsettingsrowsperpage_grid_actividades.Name = "vGRIDSETTINGSROWSPERPAGE_GRID_ACTIVIDADES";
         cmbavGridsettingsrowsperpage_grid_actividades.WebTags = "";
         cmbavGridsettingsrowsperpage_grid_actividades.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid_actividades.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid_actividades.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid_actividades.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid_actividades.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid_actividades.ItemCount > 0 )
         {
            AV60GridSettingsRowsPerPage_Grid_Actividades = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid_actividades.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridSettingsRowsPerPage_Grid_Actividades), 4, 0))), "."));
            AssignAttri("", false, "AV60GridSettingsRowsPerPage_Grid_Actividades", StringUtil.LTrimStr( (decimal)(AV60GridSettingsRowsPerPage_Grid_Actividades), 4, 0));
         }
         GXCCtl = "TRACTIVIDADES_ESTADO_" + sGXsfl_285_idx;
         cmbTrActividades_Estado.Name = GXCCtl;
         cmbTrActividades_Estado.WebTags = "";
         cmbTrActividades_Estado.addItem("1", "Nuevo", 0);
         cmbTrActividades_Estado.addItem("2", "En Progreso", 0);
         cmbTrActividades_Estado.addItem("3", "Completado", 0);
         cmbTrActividades_Estado.addItem("4", "Detenido", 0);
         cmbTrActividades_Estado.addItem("5", "Pendiente", 0);
         if ( cmbTrActividades_Estado.ItemCount > 0 )
         {
            A33TrActividades_Estado = (short)(NumberUtil.Val( cmbTrActividades_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A33TrActividades_Estado), 4, 0))), "."));
            n33TrActividades_Estado = false;
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTrgestiontareas_id_var_lefttext_Internalname = "TRGESTIONTAREAS_ID_VAR_LEFTTEXT";
         edtavTrgestiontareas_id_Internalname = "vTRGESTIONTAREAS_ID";
         divTable_container_trgestiontareas_idfieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_IDFIELDCONTAINER";
         divTable_container_trgestiontareas_id_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_ID";
         lblTrgestiontareas_nombre_var_lefttext_Internalname = "TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT";
         edtavTrgestiontareas_nombre_Internalname = "vTRGESTIONTAREAS_NOMBRE";
         lblTrgestiontareas_descripcion_var_lefttext_Internalname = "TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT";
         edtavTrgestiontareas_descripcion_Internalname = "vTRGESTIONTAREAS_DESCRIPCION";
         divTable_container_trgestiontareas_nombrefieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_NOMBREFIELDCONTAINER";
         divTable_container_trgestiontareas_nombre_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_NOMBRE";
         lblTrgestiontareas_fechainicio_var_lefttext_Internalname = "TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT";
         edtavTrgestiontareas_fechainicio_Internalname = "vTRGESTIONTAREAS_FECHAINICIO";
         lblTrgestiontareas_fechafin_var_lefttext_Internalname = "TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT";
         edtavTrgestiontareas_fechafin_Internalname = "vTRGESTIONTAREAS_FECHAFIN";
         lblTrgestiontareas_estado_var_lefttext_Internalname = "TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT";
         cmbavTrgestiontareas_estado_Internalname = "vTRGESTIONTAREAS_ESTADO";
         divTable_container_trgestiontareas_fechainiciofieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAINICIOFIELDCONTAINER";
         divTable_container_trgestiontareas_fechainicio_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAINICIO";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         lblGridtitle_grid_etiquetas_Internalname = "GRIDTITLE_GRID_ETIQUETAS";
         tblGridtitlecontainertable_grid_etiquetas_Internalname = "GRIDTITLECONTAINERTABLE_GRID_ETIQUETAS";
         lblGridsettings_labelgrid_etiquetas_Internalname = "GRIDSETTINGS_LABELGRID_ETIQUETAS";
         lblGridsettings_rowsperpagetextblockgrid_etiquetas_Internalname = "GRIDSETTINGS_ROWSPERPAGETEXTBLOCKGRID_ETIQUETAS";
         cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID_ETIQUETAS";
         tblGridsettings_tablecontentgrid_etiquetas_Internalname = "GRIDSETTINGS_TABLECONTENTGRID_ETIQUETAS";
         bttGridsettings_savegrid_etiquetas_Internalname = "GRIDSETTINGS_SAVEGRID_ETIQUETAS";
         divGridsettings_contentoutertablegrid_etiquetas_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS";
         divGridsettings_globaltablegrid_etiquetas_Internalname = "GRIDSETTINGS_GLOBALTABLEGRID_ETIQUETAS";
         tblLayoutdefined_table7_grid_etiquetas_Internalname = "LAYOUTDEFINED_TABLE7_GRID_ETIQUETAS";
         divLayoutdefined_table10_grid_etiquetas_Internalname = "LAYOUTDEFINED_TABLE10_GRID_ETIQUETAS";
         edtTrTareasEtiquetas_ID_Internalname = "TRTAREASETIQUETAS_ID";
         edtTrTareasEtiquetas_IDEtiqueta_Internalname = "TRTAREASETIQUETAS_IDETIQUETA";
         edtTrTareasEtiquetas_NombreEtiqueta_Internalname = "TRTAREASETIQUETAS_NOMBREETIQUETA";
         lblI_noresultsfoundtextblock_grid_etiquetas_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID_ETIQUETAS";
         tblI_noresultsfoundtablename_grid_etiquetas_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID_ETIQUETAS";
         divMaingrid_responsivetable_grid_etiquetas_Internalname = "MAINGRID_RESPONSIVETABLE_GRID_ETIQUETAS";
         lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS";
         cellPaginationbar_previouspagebuttoncellgrid_etiquetas_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONCELLGRID_ETIQUETAS";
         lblPaginationbar_firstpagetextblockgrid_etiquetas_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS";
         cellPaginationbar_firstpagecellgrid_etiquetas_Internalname = "PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS";
         lblPaginationbar_spacinglefttextblockgrid_etiquetas_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS";
         cellPaginationbar_spacingleftcellgrid_etiquetas_Internalname = "PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS";
         lblPaginationbar_previouspagetextblockgrid_etiquetas_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS";
         cellPaginationbar_previouspagecellgrid_etiquetas_Internalname = "PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS";
         lblPaginationbar_currentpagetextblockgrid_etiquetas_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS";
         cellPaginationbar_currentpagecellgrid_etiquetas_Internalname = "PAGINATIONBAR_CURRENTPAGECELLGRID_ETIQUETAS";
         lblPaginationbar_nextpagetextblockgrid_etiquetas_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS";
         cellPaginationbar_nextpagecellgrid_etiquetas_Internalname = "PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS";
         lblPaginationbar_spacingrighttextblockgrid_etiquetas_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS";
         cellPaginationbar_spacingrightcellgrid_etiquetas_Internalname = "PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS";
         lblPaginationbar_lastpagetextblockgrid_etiquetas_Internalname = "PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS";
         cellPaginationbar_lastpagecellgrid_etiquetas_Internalname = "PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS";
         lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS";
         cellPaginationbar_nextpagebuttoncellgrid_etiquetas_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONCELLGRID_ETIQUETAS";
         tblPaginationbar_pagingcontainertablegrid_etiquetas_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS";
         divLayoutdefined_section8_grid_etiquetas_Internalname = "LAYOUTDEFINED_SECTION8_GRID_ETIQUETAS";
         divLayoutdefined_table3_grid_etiquetas_Internalname = "LAYOUTDEFINED_TABLE3_GRID_ETIQUETAS";
         divLayoutdefined_grid_inner_grid_etiquetas_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID_ETIQUETAS";
         divGridcomponentcontent_grid_etiquetas_Internalname = "GRIDCOMPONENTCONTENT_GRID_ETIQUETAS";
         divGridcomponent_grid_etiquetas_Internalname = "GRIDCOMPONENT_GRID_ETIQUETAS";
         divColumncontainertable_etiquetas_Internalname = "COLUMNCONTAINERTABLE_ETIQUETAS";
         lblGridtitle_grid_comentarios_Internalname = "GRIDTITLE_GRID_COMENTARIOS";
         tblGridtitlecontainertable_grid_comentarios_Internalname = "GRIDTITLECONTAINERTABLE_GRID_COMENTARIOS";
         lblGridsettings_labelgrid_comentarios_Internalname = "GRIDSETTINGS_LABELGRID_COMENTARIOS";
         lblGridsettings_rowsperpagetextblockgrid_comentarios_Internalname = "GRIDSETTINGS_ROWSPERPAGETEXTBLOCKGRID_COMENTARIOS";
         cmbavGridsettingsrowsperpage_grid_comentarios_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID_COMENTARIOS";
         tblGridsettings_tablecontentgrid_comentarios_Internalname = "GRIDSETTINGS_TABLECONTENTGRID_COMENTARIOS";
         bttGridsettings_savegrid_comentarios_Internalname = "GRIDSETTINGS_SAVEGRID_COMENTARIOS";
         divGridsettings_contentoutertablegrid_comentarios_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS";
         divGridsettings_globaltablegrid_comentarios_Internalname = "GRIDSETTINGS_GLOBALTABLEGRID_COMENTARIOS";
         tblLayoutdefined_table7_grid_comentarios_Internalname = "LAYOUTDEFINED_TABLE7_GRID_COMENTARIOS";
         divLayoutdefined_table10_grid_comentarios_Internalname = "LAYOUTDEFINED_TABLE10_GRID_COMENTARIOS";
         edtTrTareaComentarios_ID_Internalname = "TRTAREACOMENTARIOS_ID";
         edtTrTareaComentarios_Descripcion_Internalname = "TRTAREACOMENTARIOS_DESCRIPCION";
         edtTrTareaComentarios_FechaCreacion_Internalname = "TRTAREACOMENTARIOS_FECHACREACION";
         edtTrTareaComentarios_FechaModificacion_Internalname = "TRTAREACOMENTARIOS_FECHAMODIFICACION";
         cmbTrTareaComentarios_Estado_Internalname = "TRTAREACOMENTARIOS_ESTADO";
         lblI_noresultsfoundtextblock_grid_comentarios_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID_COMENTARIOS";
         tblI_noresultsfoundtablename_grid_comentarios_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID_COMENTARIOS";
         divMaingrid_responsivetable_grid_comentarios_Internalname = "MAINGRID_RESPONSIVETABLE_GRID_COMENTARIOS";
         lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS";
         cellPaginationbar_previouspagebuttoncellgrid_comentarios_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONCELLGRID_COMENTARIOS";
         lblPaginationbar_firstpagetextblockgrid_comentarios_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS";
         cellPaginationbar_firstpagecellgrid_comentarios_Internalname = "PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS";
         lblPaginationbar_spacinglefttextblockgrid_comentarios_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS";
         cellPaginationbar_spacingleftcellgrid_comentarios_Internalname = "PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS";
         lblPaginationbar_previouspagetextblockgrid_comentarios_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS";
         cellPaginationbar_previouspagecellgrid_comentarios_Internalname = "PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS";
         lblPaginationbar_currentpagetextblockgrid_comentarios_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS";
         cellPaginationbar_currentpagecellgrid_comentarios_Internalname = "PAGINATIONBAR_CURRENTPAGECELLGRID_COMENTARIOS";
         lblPaginationbar_nextpagetextblockgrid_comentarios_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS";
         cellPaginationbar_nextpagecellgrid_comentarios_Internalname = "PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS";
         lblPaginationbar_spacingrighttextblockgrid_comentarios_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS";
         cellPaginationbar_spacingrightcellgrid_comentarios_Internalname = "PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS";
         lblPaginationbar_lastpagetextblockgrid_comentarios_Internalname = "PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS";
         cellPaginationbar_lastpagecellgrid_comentarios_Internalname = "PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS";
         lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS";
         cellPaginationbar_nextpagebuttoncellgrid_comentarios_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONCELLGRID_COMENTARIOS";
         tblPaginationbar_pagingcontainertablegrid_comentarios_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS";
         divLayoutdefined_section8_grid_comentarios_Internalname = "LAYOUTDEFINED_SECTION8_GRID_COMENTARIOS";
         divLayoutdefined_table3_grid_comentarios_Internalname = "LAYOUTDEFINED_TABLE3_GRID_COMENTARIOS";
         divLayoutdefined_grid_inner_grid_comentarios_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID_COMENTARIOS";
         divGridcomponentcontent_grid_comentarios_Internalname = "GRIDCOMPONENTCONTENT_GRID_COMENTARIOS";
         divGridcomponent_grid_comentarios_Internalname = "GRIDCOMPONENT_GRID_COMENTARIOS";
         divColumncontainertable_comentarios_Internalname = "COLUMNCONTAINERTABLE_COMENTARIOS";
         divColumns2_maincolumnstable_Internalname = "COLUMNS2_MAINCOLUMNSTABLE";
         divMaingroupresponsivetable_group1_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP1";
         grpGroup1_Internalname = "GROUP1";
         lblGridtitle_grid_actividades_Internalname = "GRIDTITLE_GRID_ACTIVIDADES";
         tblGridtitlecontainertable_grid_actividades_Internalname = "GRIDTITLECONTAINERTABLE_GRID_ACTIVIDADES";
         lblGridsettings_labelgrid_actividades_Internalname = "GRIDSETTINGS_LABELGRID_ACTIVIDADES";
         lblGridsettings_rowsperpagetextblockgrid_actividades_Internalname = "GRIDSETTINGS_ROWSPERPAGETEXTBLOCKGRID_ACTIVIDADES";
         cmbavGridsettingsrowsperpage_grid_actividades_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID_ACTIVIDADES";
         tblGridsettings_tablecontentgrid_actividades_Internalname = "GRIDSETTINGS_TABLECONTENTGRID_ACTIVIDADES";
         bttGridsettings_savegrid_actividades_Internalname = "GRIDSETTINGS_SAVEGRID_ACTIVIDADES";
         divGridsettings_contentoutertablegrid_actividades_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID_ACTIVIDADES";
         divGridsettings_globaltablegrid_actividades_Internalname = "GRIDSETTINGS_GLOBALTABLEGRID_ACTIVIDADES";
         tblLayoutdefined_table7_grid_actividades_Internalname = "LAYOUTDEFINED_TABLE7_GRID_ACTIVIDADES";
         divLayoutdefined_table10_grid_actividades_Internalname = "LAYOUTDEFINED_TABLE10_GRID_ACTIVIDADES";
         edtavActualizaractividad_action_Internalname = "vACTUALIZARACTIVIDAD_ACTION";
         edtavInformacionactividad_action_Internalname = "vINFORMACIONACTIVIDAD_ACTION";
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID";
         edtTrActividades_IDTarea_Internalname = "TRACTIVIDADES_IDTAREA";
         edtTrActividades_Nombre_Internalname = "TRACTIVIDADES_NOMBRE";
         edtTrActividades_Descripcion_Internalname = "TRACTIVIDADES_DESCRIPCION";
         edtTrActividades_FechaInicio_Internalname = "TRACTIVIDADES_FECHAINICIO";
         edtTrActividades_FechaFin_Internalname = "TRACTIVIDADES_FECHAFIN";
         cmbTrActividades_Estado_Internalname = "TRACTIVIDADES_ESTADO";
         lblI_noresultsfoundtextblock_grid_actividades_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID_ACTIVIDADES";
         tblI_noresultsfoundtablename_grid_actividades_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID_ACTIVIDADES";
         divMaingrid_responsivetable_grid_actividades_Internalname = "MAINGRID_RESPONSIVETABLE_GRID_ACTIVIDADES";
         lblPaginationbar_previouspagebuttontextblockgrid_actividades_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES";
         cellPaginationbar_previouspagebuttoncellgrid_actividades_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONCELLGRID_ACTIVIDADES";
         lblPaginationbar_firstpagetextblockgrid_actividades_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES";
         cellPaginationbar_firstpagecellgrid_actividades_Internalname = "PAGINATIONBAR_FIRSTPAGECELLGRID_ACTIVIDADES";
         lblPaginationbar_spacinglefttextblockgrid_actividades_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ACTIVIDADES";
         cellPaginationbar_spacingleftcellgrid_actividades_Internalname = "PAGINATIONBAR_SPACINGLEFTCELLGRID_ACTIVIDADES";
         lblPaginationbar_previouspagetextblockgrid_actividades_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES";
         cellPaginationbar_previouspagecellgrid_actividades_Internalname = "PAGINATIONBAR_PREVIOUSPAGECELLGRID_ACTIVIDADES";
         lblPaginationbar_currentpagetextblockgrid_actividades_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ACTIVIDADES";
         cellPaginationbar_currentpagecellgrid_actividades_Internalname = "PAGINATIONBAR_CURRENTPAGECELLGRID_ACTIVIDADES";
         lblPaginationbar_nextpagetextblockgrid_actividades_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES";
         cellPaginationbar_nextpagecellgrid_actividades_Internalname = "PAGINATIONBAR_NEXTPAGECELLGRID_ACTIVIDADES";
         lblPaginationbar_spacingrighttextblockgrid_actividades_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ACTIVIDADES";
         cellPaginationbar_spacingrightcellgrid_actividades_Internalname = "PAGINATIONBAR_SPACINGRIGHTCELLGRID_ACTIVIDADES";
         lblPaginationbar_lastpagetextblockgrid_actividades_Internalname = "PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES";
         cellPaginationbar_lastpagecellgrid_actividades_Internalname = "PAGINATIONBAR_LASTPAGECELLGRID_ACTIVIDADES";
         lblPaginationbar_nextpagebuttontextblockgrid_actividades_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES";
         cellPaginationbar_nextpagebuttoncellgrid_actividades_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONCELLGRID_ACTIVIDADES";
         tblPaginationbar_pagingcontainertablegrid_actividades_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ACTIVIDADES";
         divLayoutdefined_section8_grid_actividades_Internalname = "LAYOUTDEFINED_SECTION8_GRID_ACTIVIDADES";
         divLayoutdefined_table3_grid_actividades_Internalname = "LAYOUTDEFINED_TABLE3_GRID_ACTIVIDADES";
         divLayoutdefined_grid_inner_grid_actividades_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID_ACTIVIDADES";
         divGridcomponentcontent_grid_actividades_Internalname = "GRIDCOMPONENTCONTENT_GRID_ACTIVIDADES";
         divGridcomponent_grid_actividades_Internalname = "GRIDCOMPONENT_GRID_ACTIVIDADES";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_etiquetas_Internalname = "GRID_ETIQUETAS";
         subGrid_comentarios_Internalname = "GRID_COMENTARIOS";
         subGrid_actividades_Internalname = "GRID_ACTIVIDADES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         cmbTrActividades_Estado_Jsonclick = "";
         edtTrActividades_FechaFin_Jsonclick = "";
         edtTrActividades_FechaInicio_Jsonclick = "";
         edtTrActividades_Descripcion_Jsonclick = "";
         edtTrActividades_Nombre_Jsonclick = "";
         edtTrActividades_IDTarea_Jsonclick = "";
         edtTrActividades_ID_Jsonclick = "";
         edtavInformacionactividad_action_Jsonclick = "";
         edtavInformacionactividad_action_Visible = -1;
         edtavInformacionactividad_action_Enabled = 1;
         edtavActualizaractividad_action_Jsonclick = "";
         edtavActualizaractividad_action_Visible = -1;
         edtavActualizaractividad_action_Enabled = 1;
         cmbTrTareaComentarios_Estado_Jsonclick = "";
         edtTrTareaComentarios_FechaModificacion_Jsonclick = "";
         edtTrTareaComentarios_FechaCreacion_Jsonclick = "";
         edtTrTareaComentarios_Descripcion_Jsonclick = "";
         edtTrTareaComentarios_ID_Jsonclick = "";
         edtTrTareasEtiquetas_NombreEtiqueta_Jsonclick = "";
         edtTrTareasEtiquetas_IDEtiqueta_Jsonclick = "";
         edtTrTareasEtiquetas_ID_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid_etiquetas_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid_etiquetas.Enabled = 1;
         divGridsettings_contentoutertablegrid_etiquetas_Visible = 1;
         lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible = 1;
         lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible = 1;
         lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible = 1;
         cmbavGridsettingsrowsperpage_grid_comentarios_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid_comentarios.Enabled = 1;
         divGridsettings_contentoutertablegrid_comentarios_Visible = 1;
         lblPaginationbar_lastpagetextblockgrid_comentarios_Visible = 1;
         lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_comentarios_Visible = 1;
         lblPaginationbar_previouspagetextblockgrid_comentarios_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_comentarios_Visible = 1;
         cmbavGridsettingsrowsperpage_grid_actividades_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid_actividades.Enabled = 1;
         divGridsettings_contentoutertablegrid_actividades_Visible = 1;
         lblPaginationbar_lastpagetextblockgrid_actividades_Visible = 1;
         lblPaginationbar_spacingrighttextblockgrid_actividades_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_actividades_Visible = 1;
         lblPaginationbar_previouspagetextblockgrid_actividades_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_actividades_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_actividades_Visible = 1;
         tblI_noresultsfoundtablename_grid_actividades_Visible = 1;
         tblPaginationbar_pagingcontainertablegrid_actividades_Visible = 1;
         cellPaginationbar_nextpagecellgrid_actividades_Class = "K2BToolsCell_PaginationNext";
         cellPaginationbar_spacingrightcellgrid_actividades_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
         cellPaginationbar_lastpagecellgrid_actividades_Class = "K2BToolsCell_PaginationRight";
         cellPaginationbar_previouspagecellgrid_actividades_Class = "K2BToolsCell_PaginationPrevious";
         cellPaginationbar_spacingleftcellgrid_actividades_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
         cellPaginationbar_firstpagecellgrid_actividades_Class = "K2BToolsCell_PaginationLeft";
         lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_lastpagetextblockgrid_actividades_Caption = "1";
         lblPaginationbar_nextpagetextblockgrid_actividades_Caption = "#";
         lblPaginationbar_currentpagetextblockgrid_actividades_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_actividades_Caption = "#";
         lblPaginationbar_firstpagetextblockgrid_actividades_Caption = "1";
         tblI_noresultsfoundtablename_grid_comentarios_Visible = 1;
         tblPaginationbar_pagingcontainertablegrid_comentarios_Visible = 1;
         cellPaginationbar_nextpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationNext";
         cellPaginationbar_spacingrightcellgrid_comentarios_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
         cellPaginationbar_lastpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationRight";
         cellPaginationbar_previouspagecellgrid_comentarios_Class = "K2BToolsCell_PaginationPrevious";
         cellPaginationbar_spacingleftcellgrid_comentarios_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
         cellPaginationbar_firstpagecellgrid_comentarios_Class = "K2BToolsCell_PaginationLeft";
         lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_lastpagetextblockgrid_comentarios_Caption = "1";
         lblPaginationbar_nextpagetextblockgrid_comentarios_Caption = "#";
         lblPaginationbar_currentpagetextblockgrid_comentarios_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_comentarios_Caption = "#";
         lblPaginationbar_firstpagetextblockgrid_comentarios_Caption = "1";
         tblI_noresultsfoundtablename_grid_etiquetas_Visible = 1;
         tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible = 1;
         cellPaginationbar_nextpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationNext";
         cellPaginationbar_spacingrightcellgrid_etiquetas_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
         cellPaginationbar_lastpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationRight";
         cellPaginationbar_previouspagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationPrevious";
         cellPaginationbar_spacingleftcellgrid_etiquetas_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
         cellPaginationbar_firstpagecellgrid_etiquetas_Class = "K2BToolsCell_PaginationLeft";
         lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption = "1";
         lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption = "#";
         lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption = "#";
         lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption = "1";
         subGrid_actividades_Allowcollapsing = 0;
         subGrid_actividades_Allowselection = 0;
         edtavInformacionactividad_action_Tooltiptext = "";
         edtavActualizaractividad_action_Tooltiptext = "";
         subGrid_actividades_Sortable = 0;
         subGrid_actividades_Header = "";
         subGrid_actividades_Class = "Grid_WorkWith";
         subGrid_actividades_Backcolorstyle = 0;
         subGrid_comentarios_Allowcollapsing = 0;
         subGrid_comentarios_Allowselection = 0;
         subGrid_comentarios_Sortable = 0;
         subGrid_comentarios_Header = "";
         subGrid_comentarios_Class = "Grid_WorkWith";
         subGrid_comentarios_Backcolorstyle = 0;
         subGrid_etiquetas_Allowcollapsing = 0;
         subGrid_etiquetas_Allowselection = 0;
         subGrid_etiquetas_Sortable = 0;
         subGrid_etiquetas_Header = "";
         subGrid_etiquetas_Class = "Grid_WorkWith";
         subGrid_etiquetas_Backcolorstyle = 0;
         cmbavTrgestiontareas_estado_Jsonclick = "";
         cmbavTrgestiontareas_estado.Enabled = 1;
         cmbavTrgestiontareas_estado.FontBold = 0;
         lblTrgestiontareas_estado_var_lefttext_Fontbold = 0;
         lblTrgestiontareas_estado_var_lefttext_Fontsize = (int)(10.0m);
         edtavTrgestiontareas_fechafin_Jsonclick = "";
         edtavTrgestiontareas_fechafin_Fontbold = 0;
         edtavTrgestiontareas_fechafin_Enabled = 1;
         lblTrgestiontareas_fechafin_var_lefttext_Fontbold = 0;
         lblTrgestiontareas_fechafin_var_lefttext_Fontsize = (int)(10.0m);
         edtavTrgestiontareas_fechainicio_Jsonclick = "";
         edtavTrgestiontareas_fechainicio_Fontbold = 0;
         edtavTrgestiontareas_fechainicio_Enabled = 1;
         lblTrgestiontareas_fechainicio_var_lefttext_Fontbold = 0;
         lblTrgestiontareas_fechainicio_var_lefttext_Fontsize = (int)(10.0m);
         edtavTrgestiontareas_descripcion_Fontbold = 0;
         edtavTrgestiontareas_descripcion_Enabled = 1;
         lblTrgestiontareas_descripcion_var_lefttext_Fontbold = 0;
         lblTrgestiontareas_descripcion_var_lefttext_Fontsize = (int)(10.0m);
         edtavTrgestiontareas_nombre_Jsonclick = "";
         edtavTrgestiontareas_nombre_Fontbold = 0;
         edtavTrgestiontareas_nombre_Enabled = 1;
         lblTrgestiontareas_nombre_var_lefttext_Fontbold = 0;
         lblTrgestiontareas_nombre_var_lefttext_Fontsize = (int)(10.0m);
         edtavTrgestiontareas_id_Jsonclick = "";
         edtavTrgestiontareas_id_Fontbold = 0;
         edtavTrgestiontareas_id_Enabled = 0;
         lblTrgestiontareas_id_var_lefttext_Fontbold = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Visualizar información de la tarea";
         subGrid_actividades_Rows = 10;
         subGrid_comentarios_Rows = 10;
         subGrid_etiquetas_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'GRID_ACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_ACTIVIDADES_nEOF'},{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGrid_etiquetas_Backcolorstyle',ctrl:'GRID_ETIQUETAS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'subGrid_comentarios_Backcolorstyle',ctrl:'GRID_COMENTARIOS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'subGrid_actividades_Backcolorstyle',ctrl:'GRID_ACTIVIDADES',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_actividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ACTIVIDADES',prop:'Visible'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'AV15TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV16TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV17TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV18TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV19TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'lblTrgestiontareas_id_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_ID_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_nombre_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_descripcion_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_fechainicio_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_fechafin_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_estado_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_nombre_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_descripcion_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_fechainicio_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_fechafin_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_estado_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT',prop:'Fontsize'},{av:'edtavTrgestiontareas_id_Fontbold',ctrl:'vTRGESTIONTAREAS_ID',prop:'Fontbold'},{av:'edtavTrgestiontareas_nombre_Fontbold',ctrl:'vTRGESTIONTAREAS_NOMBRE',prop:'Fontbold'},{av:'edtavTrgestiontareas_descripcion_Fontbold',ctrl:'vTRGESTIONTAREAS_DESCRIPCION',prop:'Fontbold'},{av:'edtavTrgestiontareas_fechainicio_Fontbold',ctrl:'vTRGESTIONTAREAS_FECHAINICIO',prop:'Fontbold'},{av:'edtavTrgestiontareas_fechafin_Fontbold',ctrl:'vTRGESTIONTAREAS_FECHAFIN',prop:'Fontbold'}]}");
         setEventMetadata("'PAGINGFIRST(GRID_ETIQUETAS)'","{handler:'E11272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGFIRST(GRID_ETIQUETAS)'",",oparms:[{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("GRID_ETIQUETAS.REFRESH","{handler:'E28272',iparms:[{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("GRID_ETIQUETAS.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_etiquetas_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_ETIQUETAS',prop:'Visible'},{av:'subGrid_etiquetas_Backcolorstyle',ctrl:'GRID_ETIQUETAS',prop:'Backcolorstyle'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("GRID_ETIQUETAS.LOAD","{handler:'E29272',iparms:[]");
         setEventMetadata("GRID_ETIQUETAS.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_etiquetas_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGLAST(GRID_ETIQUETAS)'","{handler:'E12272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGLAST(GRID_ETIQUETAS)'",",oparms:[{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID_ETIQUETAS)'","{handler:'E13272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRID_ETIQUETAS)'",",oparms:[{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID_ETIQUETAS)'","{handler:'E14272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID_ETIQUETAS)'",",oparms:[{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_ETIQUETAS)'","{handler:'E36271',iparms:[{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_ETIQUETAS)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_ETIQUETAS)'","{handler:'E15272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid_etiquetas'},{av:'AV47GridSettingsRowsPerPage_Grid_Etiquetas',fld:'vGRIDSETTINGSROWSPERPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV45RowsPerPage_Grid_Etiquetas',fld:'vROWSPERPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'GRID_ACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_ACTIVIDADES_nEOF'},{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_ETIQUETAS)'",",oparms:[{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV45RowsPerPage_Grid_Etiquetas',fld:'vROWSPERPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'},{av:'subGrid_etiquetas_Backcolorstyle',ctrl:'GRID_ETIQUETAS',prop:'Backcolorstyle'},{av:'subGrid_comentarios_Backcolorstyle',ctrl:'GRID_COMENTARIOS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'subGrid_actividades_Backcolorstyle',ctrl:'GRID_ACTIVIDADES',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_actividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ACTIVIDADES',prop:'Visible'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'AV15TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV16TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV17TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV18TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV19TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'lblTrgestiontareas_id_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_ID_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_nombre_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_descripcion_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_fechainicio_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_fechafin_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_estado_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_nombre_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_descripcion_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_fechainicio_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_fechafin_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_estado_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT',prop:'Fontsize'},{av:'edtavTrgestiontareas_id_Fontbold',ctrl:'vTRGESTIONTAREAS_ID',prop:'Fontbold'},{av:'edtavTrgestiontareas_nombre_Fontbold',ctrl:'vTRGESTIONTAREAS_NOMBRE',prop:'Fontbold'},{av:'edtavTrgestiontareas_descripcion_Fontbold',ctrl:'vTRGESTIONTAREAS_DESCRIPCION',prop:'Fontbold'},{av:'edtavTrgestiontareas_fechainicio_Fontbold',ctrl:'vTRGESTIONTAREAS_FECHAINICIO',prop:'Fontbold'},{av:'edtavTrgestiontareas_fechafin_Fontbold',ctrl:'vTRGESTIONTAREAS_FECHAFIN',prop:'Fontbold'}]}");
         setEventMetadata("'PAGINGFIRST(GRID_COMENTARIOS)'","{handler:'E16272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGFIRST(GRID_COMENTARIOS)'",",oparms:[{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("GRID_COMENTARIOS.REFRESH","{handler:'E32272',iparms:[{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("GRID_COMENTARIOS.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_comentarios_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_COMENTARIOS',prop:'Visible'},{av:'subGrid_comentarios_Backcolorstyle',ctrl:'GRID_COMENTARIOS',prop:'Backcolorstyle'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("GRID_COMENTARIOS.LOAD","{handler:'E33274',iparms:[]");
         setEventMetadata("GRID_COMENTARIOS.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_comentarios_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID_COMENTARIOS)'","{handler:'E17272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRID_COMENTARIOS)'",",oparms:[{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID_COMENTARIOS)'","{handler:'E18272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID_COMENTARIOS)'",",oparms:[{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_COMENTARIOS)'","{handler:'E35271',iparms:[{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_COMENTARIOS)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_COMENTARIOS)'","{handler:'E19272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid_comentarios'},{av:'AV42GridSettingsRowsPerPage_Grid_Comentarios',fld:'vGRIDSETTINGSROWSPERPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV40RowsPerPage_Grid_Comentarios',fld:'vROWSPERPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'GRID_ACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_ACTIVIDADES_nEOF'},{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_COMENTARIOS)'",",oparms:[{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV40RowsPerPage_Grid_Comentarios',fld:'vROWSPERPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'},{av:'subGrid_etiquetas_Backcolorstyle',ctrl:'GRID_ETIQUETAS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'subGrid_comentarios_Backcolorstyle',ctrl:'GRID_COMENTARIOS',prop:'Backcolorstyle'},{av:'subGrid_actividades_Backcolorstyle',ctrl:'GRID_ACTIVIDADES',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_actividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ACTIVIDADES',prop:'Visible'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'AV15TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV16TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV17TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV18TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV19TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'lblTrgestiontareas_id_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_ID_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_nombre_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_descripcion_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_fechainicio_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_fechafin_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_estado_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_nombre_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_descripcion_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_fechainicio_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_fechafin_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_estado_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT',prop:'Fontsize'},{av:'edtavTrgestiontareas_id_Fontbold',ctrl:'vTRGESTIONTAREAS_ID',prop:'Fontbold'},{av:'edtavTrgestiontareas_nombre_Fontbold',ctrl:'vTRGESTIONTAREAS_NOMBRE',prop:'Fontbold'},{av:'edtavTrgestiontareas_descripcion_Fontbold',ctrl:'vTRGESTIONTAREAS_DESCRIPCION',prop:'Fontbold'},{av:'edtavTrgestiontareas_fechainicio_Fontbold',ctrl:'vTRGESTIONTAREAS_FECHAINICIO',prop:'Fontbold'},{av:'edtavTrgestiontareas_fechafin_Fontbold',ctrl:'vTRGESTIONTAREAS_FECHAFIN',prop:'Fontbold'}]}");
         setEventMetadata("'PAGINGLAST(GRID_COMENTARIOS)'","{handler:'E20272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGLAST(GRID_COMENTARIOS)'",",oparms:[{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID_ACTIVIDADES)'","{handler:'E21272',iparms:[{av:'GRID_ACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_ACTIVIDADES_nEOF'},{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGFIRST(GRID_ACTIVIDADES)'",",oparms:[{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_actividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("GRID_ACTIVIDADES.REFRESH","{handler:'E30272',iparms:[{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_ACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_ACTIVIDADES_nEOF'},{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("GRID_ACTIVIDADES.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_actividades_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_ACTIVIDADES',prop:'Visible'},{av:'subGrid_actividades_Backcolorstyle',ctrl:'GRID_ACTIVIDADES',prop:'Backcolorstyle'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_actividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("GRID_ACTIVIDADES.LOAD","{handler:'E31275',iparms:[{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("GRID_ACTIVIDADES.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_actividades_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_ACTIVIDADES',prop:'Visible'},{av:'AV62ActualizarActividad_Action',fld:'vACTUALIZARACTIVIDAD_ACTION',pic:''},{av:'edtavActualizaractividad_action_Tooltiptext',ctrl:'vACTUALIZARACTIVIDAD_ACTION',prop:'Tooltiptext'},{av:'AV70InformacionActividad_Action',fld:'vINFORMACIONACTIVIDAD_ACTION',pic:''},{av:'edtavInformacionactividad_action_Tooltiptext',ctrl:'vINFORMACIONACTIVIDAD_ACTION',prop:'Tooltiptext'},{av:'AV69TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV68TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("'PAGINGLAST(GRID_ACTIVIDADES)'","{handler:'E22272',iparms:[{av:'GRID_ACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_ACTIVIDADES_nEOF'},{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGLAST(GRID_ACTIVIDADES)'",",oparms:[{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_actividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID_ACTIVIDADES)'","{handler:'E23272',iparms:[{av:'GRID_ACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_ACTIVIDADES_nEOF'},{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRID_ACTIVIDADES)'",",oparms:[{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_actividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID_ACTIVIDADES)'","{handler:'E24272',iparms:[{av:'GRID_ACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_ACTIVIDADES_nEOF'},{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID_ACTIVIDADES)'",",oparms:[{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_actividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_actividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_actividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_actividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_ACTIVIDADES)'","{handler:'E34271',iparms:[{av:'divGridsettings_contentoutertablegrid_actividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ACTIVIDADES',prop:'Visible'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_ACTIVIDADES)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_actividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_ACTIVIDADES)'","{handler:'E25272',iparms:[{av:'GRID_ACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_ACTIVIDADES_nEOF'},{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid_actividades'},{av:'AV60GridSettingsRowsPerPage_Grid_Actividades',fld:'vGRIDSETTINGSROWSPERPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'AV58RowsPerPage_Grid_Actividades',fld:'vROWSPERPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_ACTIVIDADES)'",",oparms:[{av:'subGrid_actividades_Rows',ctrl:'GRID_ACTIVIDADES',prop:'Rows'},{av:'AV58RowsPerPage_Grid_Actividades',fld:'vROWSPERPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'AV56CurrentPage_Grid_Actividades',fld:'vCURRENTPAGE_GRID_ACTIVIDADES',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_actividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ACTIVIDADES',prop:'Visible'},{av:'subGrid_etiquetas_Backcolorstyle',ctrl:'GRID_ETIQUETAS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'subGrid_comentarios_Backcolorstyle',ctrl:'GRID_COMENTARIOS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'subGrid_actividades_Backcolorstyle',ctrl:'GRID_ACTIVIDADES',prop:'Backcolorstyle'},{av:'AV15TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV16TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV17TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV18TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV19TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'lblTrgestiontareas_id_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_ID_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_nombre_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_descripcion_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_fechainicio_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_fechafin_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_estado_var_lefttext_Fontbold',ctrl:'TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT',prop:'Fontbold'},{av:'lblTrgestiontareas_nombre_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_descripcion_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_fechainicio_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_fechafin_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT',prop:'Fontsize'},{av:'lblTrgestiontareas_estado_var_lefttext_Fontsize',ctrl:'TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT',prop:'Fontsize'},{av:'edtavTrgestiontareas_id_Fontbold',ctrl:'vTRGESTIONTAREAS_ID',prop:'Fontbold'},{av:'edtavTrgestiontareas_nombre_Fontbold',ctrl:'vTRGESTIONTAREAS_NOMBRE',prop:'Fontbold'},{av:'edtavTrgestiontareas_descripcion_Fontbold',ctrl:'vTRGESTIONTAREAS_DESCRIPCION',prop:'Fontbold'},{av:'edtavTrgestiontareas_fechainicio_Fontbold',ctrl:'vTRGESTIONTAREAS_FECHAINICIO',prop:'Fontbold'},{av:'edtavTrgestiontareas_fechafin_Fontbold',ctrl:'vTRGESTIONTAREAS_FECHAFIN',prop:'Fontbold'}]}");
         setEventMetadata("'E_ACTUALIZARACTIVIDAD'","{handler:'E37275',iparms:[{av:'AV68TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV69TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_ACTUALIZARACTIVIDAD'",",oparms:[{av:'AV69TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV68TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_INFORMACIONACTIVIDAD'","{handler:'E38275',iparms:[{av:'AV68TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV69TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_INFORMACIONACTIVIDAD'",",oparms:[{av:'AV69TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV68TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_ID","{handler:'Validv_Trgestiontareas_id',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_ID",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAINICIO","{handler:'Validv_Trgestiontareas_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAFIN","{handler:'Validv_Trgestiontareas_fechafin',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_ESTADO","{handler:'Validv_Trgestiontareas_estado',iparms:[]");
         setEventMetadata("VALIDV_TRGESTIONTAREAS_ESTADO",",oparms:[]}");
         setEventMetadata("VALID_TRTAREASETIQUETAS_IDETIQUETA","{handler:'Valid_Trtareasetiquetas_idetiqueta',iparms:[]");
         setEventMetadata("VALID_TRTAREASETIQUETAS_IDETIQUETA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Trtareasetiquetas_nombreetiqueta',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Trtareacomentarios_estado',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tractividades_estado',iparms:[]");
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
         A13TrGestionTareas_Nombre = "";
         A14TrGestionTareas_Descripcion = "";
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
         AV74Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTrgestiontareas_id_var_lefttext_Jsonclick = "";
         lblTrgestiontareas_nombre_var_lefttext_Jsonclick = "";
         TempTags = "";
         AV15TrGestionTareas_Nombre = "";
         lblTrgestiontareas_descripcion_var_lefttext_Jsonclick = "";
         AV16TrGestionTareas_Descripcion = "";
         lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick = "";
         AV17TrGestionTareas_FechaInicio = DateTime.MinValue;
         lblTrgestiontareas_fechafin_var_lefttext_Jsonclick = "";
         AV18TrGestionTareas_FechaFin = DateTime.MinValue;
         lblTrgestiontareas_estado_var_lefttext_Jsonclick = "";
         Grid_etiquetasContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_etiquetas_Linesclass = "";
         Grid_etiquetasColumn = new GXWebColumn();
         A54TrTareasEtiquetas_NombreEtiqueta = "";
         Grid_comentariosContainer = new GXWebGrid( context);
         subGrid_comentarios_Linesclass = "";
         Grid_comentariosColumn = new GXWebColumn();
         A36TrTareaComentarios_Descripcion = "";
         A38TrTareaComentarios_FechaCreacion = DateTime.MinValue;
         A39TrTareaComentarios_FechaModificacion = DateTime.MinValue;
         Grid_actividadesContainer = new GXWebGrid( context);
         subGrid_actividades_Linesclass = "";
         Grid_actividadesColumn = new GXWebColumn();
         AV62ActualizarActividad_Action = "";
         AV70InformacionActividad_Action = "";
         A27TrActividades_Nombre = "";
         A28TrActividades_Descripcion = "";
         A29TrActividades_FechaInicio = DateTime.MinValue;
         A30TrActividades_FechaFin = DateTime.MinValue;
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV75Actualizaractividad_action_GXI = "";
         AV76Informacionactividad_action_GXI = "";
         scmdbuf = "";
         H00272_A52TrTareasEtiquetas_TareaID = new long[1] ;
         H00272_A54TrTareasEtiquetas_NombreEtiqueta = new String[] {""} ;
         H00272_n54TrTareasEtiquetas_NombreEtiqueta = new bool[] {false} ;
         H00272_A53TrTareasEtiquetas_IDEtiqueta = new long[1] ;
         H00272_A51TrTareasEtiquetas_ID = new long[1] ;
         H00273_A34TrTareaComentarios_IDTarea = new long[1] ;
         H00273_n34TrTareaComentarios_IDTarea = new bool[] {false} ;
         H00273_A37TrTareaComentarios_Estado = new short[1] ;
         H00273_n37TrTareaComentarios_Estado = new bool[] {false} ;
         H00273_A39TrTareaComentarios_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         H00273_n39TrTareaComentarios_FechaModificacion = new bool[] {false} ;
         H00273_A38TrTareaComentarios_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H00273_n38TrTareaComentarios_FechaCreacion = new bool[] {false} ;
         H00273_A36TrTareaComentarios_Descripcion = new String[] {""} ;
         H00273_n36TrTareaComentarios_Descripcion = new bool[] {false} ;
         H00273_A35TrTareaComentarios_ID = new long[1] ;
         H00274_A33TrActividades_Estado = new short[1] ;
         H00274_n33TrActividades_Estado = new bool[] {false} ;
         H00274_A30TrActividades_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H00274_n30TrActividades_FechaFin = new bool[] {false} ;
         H00274_A29TrActividades_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00274_n29TrActividades_FechaInicio = new bool[] {false} ;
         H00274_A28TrActividades_Descripcion = new String[] {""} ;
         H00274_n28TrActividades_Descripcion = new bool[] {false} ;
         H00274_A27TrActividades_Nombre = new String[] {""} ;
         H00274_n27TrActividades_Nombre = new bool[] {false} ;
         H00274_A25TrActividades_IDTarea = new long[1] ;
         H00274_n25TrActividades_IDTarea = new bool[] {false} ;
         H00274_A26TrActividades_ID = new long[1] ;
         H00275_AGRID_ETIQUETAS_nRecordCount = new long[1] ;
         H00276_AGRID_COMENTARIOS_nRecordCount = new long[1] ;
         H00277_AGRID_ACTIVIDADES_nRecordCount = new long[1] ;
         H00278_A12TrGestionTareas_ID = new long[1] ;
         H00278_A13TrGestionTareas_Nombre = new String[] {""} ;
         H00278_n13TrGestionTareas_Nombre = new bool[] {false} ;
         H00278_A14TrGestionTareas_Descripcion = new String[] {""} ;
         H00278_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         H00278_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00278_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         H00278_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H00278_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         H00278_A24TrGestionTareas_Estado = new short[1] ;
         H00278_n24TrGestionTareas_Estado = new bool[] {false} ;
         Grid_etiquetasRow = new GXWebRow();
         AV12GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         Grid_comentariosRow = new GXWebRow();
         Grid_actividadesRow = new GXWebRow();
         lblPaginationbar_previouspagebuttontextblockgrid_actividades_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_actividades_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_actividades_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_actividades_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_actividades_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_actividades_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_actividades_Jsonclick = "";
         lblPaginationbar_lastpagetextblockgrid_actividades_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_actividades_Jsonclick = "";
         lblI_noresultsfoundtextblock_grid_actividades_Jsonclick = "";
         lblGridsettings_labelgrid_actividades_Jsonclick = "";
         bttGridsettings_savegrid_actividades_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgrid_actividades_Jsonclick = "";
         lblGridtitle_grid_actividades_Jsonclick = "";
         lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_comentarios_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_comentarios_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_comentarios_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_comentarios_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_comentarios_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_comentarios_Jsonclick = "";
         lblPaginationbar_lastpagetextblockgrid_comentarios_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Jsonclick = "";
         lblI_noresultsfoundtextblock_grid_comentarios_Jsonclick = "";
         lblGridsettings_labelgrid_comentarios_Jsonclick = "";
         bttGridsettings_savegrid_comentarios_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgrid_comentarios_Jsonclick = "";
         lblGridtitle_grid_comentarios_Jsonclick = "";
         lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_etiquetas_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_etiquetas_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_etiquetas_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_etiquetas_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_etiquetas_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_etiquetas_Jsonclick = "";
         lblPaginationbar_lastpagetextblockgrid_etiquetas_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Jsonclick = "";
         lblI_noresultsfoundtextblock_grid_etiquetas_Jsonclick = "";
         lblGridsettings_labelgrid_etiquetas_Jsonclick = "";
         bttGridsettings_savegrid_etiquetas_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgrid_etiquetas_Jsonclick = "";
         lblGridtitle_grid_etiquetas_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpvisualizarinformaciontarea__default(),
            new Object[][] {
                new Object[] {
               H00272_A52TrTareasEtiquetas_TareaID, H00272_A54TrTareasEtiquetas_NombreEtiqueta, H00272_n54TrTareasEtiquetas_NombreEtiqueta, H00272_A53TrTareasEtiquetas_IDEtiqueta, H00272_A51TrTareasEtiquetas_ID
               }
               , new Object[] {
               H00273_A34TrTareaComentarios_IDTarea, H00273_n34TrTareaComentarios_IDTarea, H00273_A37TrTareaComentarios_Estado, H00273_n37TrTareaComentarios_Estado, H00273_A39TrTareaComentarios_FechaModificacion, H00273_n39TrTareaComentarios_FechaModificacion, H00273_A38TrTareaComentarios_FechaCreacion, H00273_n38TrTareaComentarios_FechaCreacion, H00273_A36TrTareaComentarios_Descripcion, H00273_n36TrTareaComentarios_Descripcion,
               H00273_A35TrTareaComentarios_ID
               }
               , new Object[] {
               H00274_A33TrActividades_Estado, H00274_n33TrActividades_Estado, H00274_A30TrActividades_FechaFin, H00274_n30TrActividades_FechaFin, H00274_A29TrActividades_FechaInicio, H00274_n29TrActividades_FechaInicio, H00274_A28TrActividades_Descripcion, H00274_n28TrActividades_Descripcion, H00274_A27TrActividades_Nombre, H00274_n27TrActividades_Nombre,
               H00274_A25TrActividades_IDTarea, H00274_n25TrActividades_IDTarea, H00274_A26TrActividades_ID
               }
               , new Object[] {
               H00275_AGRID_ETIQUETAS_nRecordCount
               }
               , new Object[] {
               H00276_AGRID_COMENTARIOS_nRecordCount
               }
               , new Object[] {
               H00277_AGRID_ACTIVIDADES_nRecordCount
               }
               , new Object[] {
               H00278_A12TrGestionTareas_ID, H00278_A13TrGestionTareas_Nombre, H00278_n13TrGestionTareas_Nombre, H00278_A14TrGestionTareas_Descripcion, H00278_n14TrGestionTareas_Descripcion, H00278_A15TrGestionTareas_FechaInicio, H00278_n15TrGestionTareas_FechaInicio, H00278_A16TrGestionTareas_FechaFin, H00278_n16TrGestionTareas_FechaFin, H00278_A24TrGestionTareas_Estado,
               H00278_n24TrGestionTareas_Estado
               }
            }
         );
         AV74Pgmname = "WpVisualizarInformacionTarea";
         /* GeneXus formulas. */
         AV74Pgmname = "WpVisualizarInformacionTarea";
         context.Gx_err = 0;
         edtavTrgestiontareas_nombre_Enabled = 0;
         edtavTrgestiontareas_descripcion_Enabled = 0;
         edtavTrgestiontareas_fechainicio_Enabled = 0;
         edtavTrgestiontareas_fechafin_Enabled = 0;
         cmbavTrgestiontareas_estado.Enabled = 0;
      }

      private short GRID_ETIQUETAS_nEOF ;
      private short GRID_COMENTARIOS_nEOF ;
      private short GRID_ACTIVIDADES_nEOF ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV35CurrentPage_Grid_Comentarios ;
      private short AV56CurrentPage_Grid_Actividades ;
      private short A24TrGestionTareas_Estado ;
      private short AV43CurrentPage_Grid_Etiquetas ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV45RowsPerPage_Grid_Etiquetas ;
      private short AV40RowsPerPage_Grid_Comentarios ;
      private short AV58RowsPerPage_Grid_Actividades ;
      private short wbEnd ;
      private short wbStart ;
      private short lblTrgestiontareas_id_var_lefttext_Fontbold ;
      private short edtavTrgestiontareas_id_Fontbold ;
      private short lblTrgestiontareas_nombre_var_lefttext_Fontbold ;
      private short edtavTrgestiontareas_nombre_Fontbold ;
      private short lblTrgestiontareas_descripcion_var_lefttext_Fontbold ;
      private short edtavTrgestiontareas_descripcion_Fontbold ;
      private short lblTrgestiontareas_fechainicio_var_lefttext_Fontbold ;
      private short edtavTrgestiontareas_fechainicio_Fontbold ;
      private short lblTrgestiontareas_fechafin_var_lefttext_Fontbold ;
      private short edtavTrgestiontareas_fechafin_Fontbold ;
      private short lblTrgestiontareas_estado_var_lefttext_Fontbold ;
      private short AV19TrGestionTareas_Estado ;
      private short subGrid_etiquetas_Backcolorstyle ;
      private short subGrid_etiquetas_Titlebackstyle ;
      private short subGrid_etiquetas_Sortable ;
      private short subGrid_etiquetas_Allowselection ;
      private short subGrid_etiquetas_Allowhovering ;
      private short subGrid_etiquetas_Allowcollapsing ;
      private short subGrid_etiquetas_Collapsed ;
      private short subGrid_comentarios_Backcolorstyle ;
      private short subGrid_comentarios_Titlebackstyle ;
      private short subGrid_comentarios_Sortable ;
      private short A37TrTareaComentarios_Estado ;
      private short subGrid_comentarios_Allowselection ;
      private short subGrid_comentarios_Allowhovering ;
      private short subGrid_comentarios_Allowcollapsing ;
      private short subGrid_comentarios_Collapsed ;
      private short subGrid_actividades_Backcolorstyle ;
      private short subGrid_actividades_Titlebackstyle ;
      private short subGrid_actividades_Sortable ;
      private short A33TrActividades_Estado ;
      private short subGrid_actividades_Allowselection ;
      private short subGrid_actividades_Allowhovering ;
      private short subGrid_actividades_Allowcollapsing ;
      private short subGrid_actividades_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV47GridSettingsRowsPerPage_Grid_Etiquetas ;
      private short AV42GridSettingsRowsPerPage_Grid_Comentarios ;
      private short AV60GridSettingsRowsPerPage_Grid_Actividades ;
      private short AV48PageCount_Grid_Etiquetas ;
      private short AV49PageCount_Grid_Comentarios ;
      private short AV61PageCount_Grid_Actividades ;
      private short nGXWrapped ;
      private short subGrid_etiquetas_Backstyle ;
      private short subGrid_comentarios_Backstyle ;
      private short subGrid_actividades_Backstyle ;
      private int divGridsettings_contentoutertablegrid_etiquetas_Visible ;
      private int divGridsettings_contentoutertablegrid_comentarios_Visible ;
      private int divGridsettings_contentoutertablegrid_actividades_Visible ;
      private int nRC_GXsfl_111 ;
      private int nRC_GXsfl_198 ;
      private int nRC_GXsfl_285 ;
      private int nGXsfl_111_idx=1 ;
      private int subGrid_etiquetas_Rows ;
      private int nGXsfl_198_idx=1 ;
      private int subGrid_comentarios_Rows ;
      private int nGXsfl_285_idx=1 ;
      private int subGrid_actividades_Rows ;
      private int edtavTrgestiontareas_id_Enabled ;
      private int lblTrgestiontareas_nombre_var_lefttext_Fontsize ;
      private int edtavTrgestiontareas_nombre_Enabled ;
      private int lblTrgestiontareas_descripcion_var_lefttext_Fontsize ;
      private int edtavTrgestiontareas_descripcion_Enabled ;
      private int lblTrgestiontareas_fechainicio_var_lefttext_Fontsize ;
      private int edtavTrgestiontareas_fechainicio_Enabled ;
      private int lblTrgestiontareas_fechafin_var_lefttext_Fontsize ;
      private int edtavTrgestiontareas_fechafin_Enabled ;
      private int lblTrgestiontareas_estado_var_lefttext_Fontsize ;
      private int subGrid_etiquetas_Titlebackcolor ;
      private int subGrid_etiquetas_Allbackcolor ;
      private int subGrid_etiquetas_Selectedindex ;
      private int subGrid_etiquetas_Selectioncolor ;
      private int subGrid_etiquetas_Hoveringcolor ;
      private int subGrid_comentarios_Titlebackcolor ;
      private int subGrid_comentarios_Allbackcolor ;
      private int subGrid_comentarios_Selectedindex ;
      private int subGrid_comentarios_Selectioncolor ;
      private int subGrid_comentarios_Hoveringcolor ;
      private int subGrid_actividades_Titlebackcolor ;
      private int subGrid_actividades_Allbackcolor ;
      private int subGrid_actividades_Selectedindex ;
      private int subGrid_actividades_Selectioncolor ;
      private int subGrid_actividades_Hoveringcolor ;
      private int subGrid_etiquetas_Islastpage ;
      private int subGrid_comentarios_Islastpage ;
      private int subGrid_actividades_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingFrom4 ;
      private int GXPagingTo4 ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible ;
      private int lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible ;
      private int tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible ;
      private int tblI_noresultsfoundtablename_grid_etiquetas_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_comentarios_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_comentarios_Visible ;
      private int lblPaginationbar_lastpagetextblockgrid_comentarios_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_comentarios_Visible ;
      private int tblPaginationbar_pagingcontainertablegrid_comentarios_Visible ;
      private int tblI_noresultsfoundtablename_grid_comentarios_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_actividades_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_actividades_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_actividades_Visible ;
      private int lblPaginationbar_lastpagetextblockgrid_actividades_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_actividades_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_actividades_Visible ;
      private int tblPaginationbar_pagingcontainertablegrid_actividades_Visible ;
      private int tblI_noresultsfoundtablename_grid_actividades_Visible ;
      private int idxLst ;
      private int subGrid_etiquetas_Backcolor ;
      private int subGrid_comentarios_Backcolor ;
      private int subGrid_actividades_Backcolor ;
      private int edtavActualizaractividad_action_Enabled ;
      private int edtavActualizaractividad_action_Visible ;
      private int edtavInformacionactividad_action_Enabled ;
      private int edtavInformacionactividad_action_Visible ;
      private long AV26TrGestionTareas_ID ;
      private long wcpOAV26TrGestionTareas_ID ;
      private long GRID_ETIQUETAS_nFirstRecordOnPage ;
      private long GRID_COMENTARIOS_nFirstRecordOnPage ;
      private long GRID_ACTIVIDADES_nFirstRecordOnPage ;
      private long A12TrGestionTareas_ID ;
      private long AV68TrActividades_ID ;
      private long AV69TrActividades_IDTarea ;
      private long A51TrTareasEtiquetas_ID ;
      private long A53TrTareasEtiquetas_IDEtiqueta ;
      private long A35TrTareaComentarios_ID ;
      private long A26TrActividades_ID ;
      private long A25TrActividades_IDTarea ;
      private long GRID_ETIQUETAS_nCurrentRecord ;
      private long GRID_COMENTARIOS_nCurrentRecord ;
      private long GRID_ACTIVIDADES_nCurrentRecord ;
      private long A52TrTareasEtiquetas_TareaID ;
      private long A34TrTareaComentarios_IDTarea ;
      private long GRID_ETIQUETAS_nRecordCount ;
      private long GRID_COMENTARIOS_nRecordCount ;
      private long GRID_ACTIVIDADES_nRecordCount ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_111_idx="0001" ;
      private String A13TrGestionTareas_Nombre ;
      private String AV74Pgmname ;
      private String sGXsfl_198_idx="0001" ;
      private String sGXsfl_285_idx="0001" ;
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
      private String grpGroup_Internalname ;
      private String divMaingroupresponsivetable_group_Internalname ;
      private String divResponsivetable_mainattributes_attributes_Internalname ;
      private String divAttributescontainertable_attributes_Internalname ;
      private String divTable_container_trgestiontareas_id_Internalname ;
      private String divTable_container_trgestiontareas_idfieldcontainer_Internalname ;
      private String lblTrgestiontareas_id_var_lefttext_Internalname ;
      private String lblTrgestiontareas_id_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_id_Internalname ;
      private String edtavTrgestiontareas_id_Jsonclick ;
      private String divTable_container_trgestiontareas_nombre_Internalname ;
      private String divTable_container_trgestiontareas_nombrefieldcontainer_Internalname ;
      private String lblTrgestiontareas_nombre_var_lefttext_Internalname ;
      private String lblTrgestiontareas_nombre_var_lefttext_Jsonclick ;
      private String TempTags ;
      private String edtavTrgestiontareas_nombre_Internalname ;
      private String AV15TrGestionTareas_Nombre ;
      private String edtavTrgestiontareas_nombre_Jsonclick ;
      private String lblTrgestiontareas_descripcion_var_lefttext_Internalname ;
      private String lblTrgestiontareas_descripcion_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_descripcion_Internalname ;
      private String divTable_container_trgestiontareas_fechainicio_Internalname ;
      private String divTable_container_trgestiontareas_fechainiciofieldcontainer_Internalname ;
      private String lblTrgestiontareas_fechainicio_var_lefttext_Internalname ;
      private String lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_fechainicio_Internalname ;
      private String edtavTrgestiontareas_fechainicio_Jsonclick ;
      private String lblTrgestiontareas_fechafin_var_lefttext_Internalname ;
      private String lblTrgestiontareas_fechafin_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_fechafin_Internalname ;
      private String edtavTrgestiontareas_fechafin_Jsonclick ;
      private String lblTrgestiontareas_estado_var_lefttext_Internalname ;
      private String lblTrgestiontareas_estado_var_lefttext_Jsonclick ;
      private String cmbavTrgestiontareas_estado_Internalname ;
      private String cmbavTrgestiontareas_estado_Jsonclick ;
      private String grpGroup1_Internalname ;
      private String divMaingroupresponsivetable_group1_Internalname ;
      private String divColumns2_maincolumnstable_Internalname ;
      private String divColumncontainertable_etiquetas_Internalname ;
      private String divGridcomponent_grid_etiquetas_Internalname ;
      private String divGridcomponentcontent_grid_etiquetas_Internalname ;
      private String divLayoutdefined_grid_inner_grid_etiquetas_Internalname ;
      private String divLayoutdefined_table10_grid_etiquetas_Internalname ;
      private String divLayoutdefined_table3_grid_etiquetas_Internalname ;
      private String divMaingrid_responsivetable_grid_etiquetas_Internalname ;
      private String sStyleString ;
      private String subGrid_etiquetas_Internalname ;
      private String subGrid_etiquetas_Class ;
      private String subGrid_etiquetas_Linesclass ;
      private String subGrid_etiquetas_Header ;
      private String A54TrTareasEtiquetas_NombreEtiqueta ;
      private String divLayoutdefined_section8_grid_etiquetas_Internalname ;
      private String divColumncontainertable_comentarios_Internalname ;
      private String divGridcomponent_grid_comentarios_Internalname ;
      private String divGridcomponentcontent_grid_comentarios_Internalname ;
      private String divLayoutdefined_grid_inner_grid_comentarios_Internalname ;
      private String divLayoutdefined_table10_grid_comentarios_Internalname ;
      private String divLayoutdefined_table3_grid_comentarios_Internalname ;
      private String divMaingrid_responsivetable_grid_comentarios_Internalname ;
      private String subGrid_comentarios_Internalname ;
      private String subGrid_comentarios_Class ;
      private String subGrid_comentarios_Linesclass ;
      private String subGrid_comentarios_Header ;
      private String divLayoutdefined_section8_grid_comentarios_Internalname ;
      private String divGridcomponent_grid_actividades_Internalname ;
      private String divGridcomponentcontent_grid_actividades_Internalname ;
      private String divLayoutdefined_grid_inner_grid_actividades_Internalname ;
      private String divLayoutdefined_table10_grid_actividades_Internalname ;
      private String divLayoutdefined_table3_grid_actividades_Internalname ;
      private String divMaingrid_responsivetable_grid_actividades_Internalname ;
      private String subGrid_actividades_Internalname ;
      private String subGrid_actividades_Class ;
      private String subGrid_actividades_Linesclass ;
      private String subGrid_actividades_Header ;
      private String edtavActualizaractividad_action_Tooltiptext ;
      private String edtavInformacionactividad_action_Tooltiptext ;
      private String A27TrActividades_Nombre ;
      private String divLayoutdefined_section8_grid_actividades_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtTrTareasEtiquetas_ID_Internalname ;
      private String edtTrTareasEtiquetas_IDEtiqueta_Internalname ;
      private String edtTrTareasEtiquetas_NombreEtiqueta_Internalname ;
      private String edtavActualizaractividad_action_Internalname ;
      private String edtavInformacionactividad_action_Internalname ;
      private String edtTrActividades_ID_Internalname ;
      private String edtTrActividades_IDTarea_Internalname ;
      private String edtTrActividades_Nombre_Internalname ;
      private String edtTrActividades_Descripcion_Internalname ;
      private String edtTrActividades_FechaInicio_Internalname ;
      private String edtTrActividades_FechaFin_Internalname ;
      private String cmbTrActividades_Estado_Internalname ;
      private String edtTrTareaComentarios_ID_Internalname ;
      private String edtTrTareaComentarios_Descripcion_Internalname ;
      private String edtTrTareaComentarios_FechaCreacion_Internalname ;
      private String edtTrTareaComentarios_FechaModificacion_Internalname ;
      private String cmbTrTareaComentarios_Estado_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_comentarios_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_actividades_Internalname ;
      private String scmdbuf ;
      private String divGridsettings_contentoutertablegrid_etiquetas_Internalname ;
      private String divGridsettings_contentoutertablegrid_comentarios_Internalname ;
      private String divGridsettings_contentoutertablegrid_actividades_Internalname ;
      private String lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption ;
      private String lblPaginationbar_firstpagetextblockgrid_etiquetas_Internalname ;
      private String lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption ;
      private String lblPaginationbar_previouspagetextblockgrid_etiquetas_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption ;
      private String lblPaginationbar_currentpagetextblockgrid_etiquetas_Internalname ;
      private String lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption ;
      private String lblPaginationbar_nextpagetextblockgrid_etiquetas_Internalname ;
      private String lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption ;
      private String lblPaginationbar_lastpagetextblockgrid_etiquetas_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Internalname ;
      private String cellPaginationbar_firstpagecellgrid_etiquetas_Class ;
      private String cellPaginationbar_firstpagecellgrid_etiquetas_Internalname ;
      private String cellPaginationbar_spacingleftcellgrid_etiquetas_Class ;
      private String cellPaginationbar_spacingleftcellgrid_etiquetas_Internalname ;
      private String lblPaginationbar_spacinglefttextblockgrid_etiquetas_Internalname ;
      private String cellPaginationbar_previouspagecellgrid_etiquetas_Class ;
      private String cellPaginationbar_previouspagecellgrid_etiquetas_Internalname ;
      private String cellPaginationbar_lastpagecellgrid_etiquetas_Class ;
      private String cellPaginationbar_lastpagecellgrid_etiquetas_Internalname ;
      private String cellPaginationbar_spacingrightcellgrid_etiquetas_Class ;
      private String cellPaginationbar_spacingrightcellgrid_etiquetas_Internalname ;
      private String lblPaginationbar_spacingrighttextblockgrid_etiquetas_Internalname ;
      private String cellPaginationbar_nextpagecellgrid_etiquetas_Class ;
      private String cellPaginationbar_nextpagecellgrid_etiquetas_Internalname ;
      private String tblPaginationbar_pagingcontainertablegrid_etiquetas_Internalname ;
      private String tblI_noresultsfoundtablename_grid_etiquetas_Internalname ;
      private String lblPaginationbar_firstpagetextblockgrid_comentarios_Caption ;
      private String lblPaginationbar_firstpagetextblockgrid_comentarios_Internalname ;
      private String lblPaginationbar_previouspagetextblockgrid_comentarios_Caption ;
      private String lblPaginationbar_previouspagetextblockgrid_comentarios_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_comentarios_Caption ;
      private String lblPaginationbar_currentpagetextblockgrid_comentarios_Internalname ;
      private String lblPaginationbar_nextpagetextblockgrid_comentarios_Caption ;
      private String lblPaginationbar_nextpagetextblockgrid_comentarios_Internalname ;
      private String lblPaginationbar_lastpagetextblockgrid_comentarios_Caption ;
      private String lblPaginationbar_lastpagetextblockgrid_comentarios_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Internalname ;
      private String cellPaginationbar_firstpagecellgrid_comentarios_Class ;
      private String cellPaginationbar_firstpagecellgrid_comentarios_Internalname ;
      private String cellPaginationbar_spacingleftcellgrid_comentarios_Class ;
      private String cellPaginationbar_spacingleftcellgrid_comentarios_Internalname ;
      private String lblPaginationbar_spacinglefttextblockgrid_comentarios_Internalname ;
      private String cellPaginationbar_previouspagecellgrid_comentarios_Class ;
      private String cellPaginationbar_previouspagecellgrid_comentarios_Internalname ;
      private String cellPaginationbar_lastpagecellgrid_comentarios_Class ;
      private String cellPaginationbar_lastpagecellgrid_comentarios_Internalname ;
      private String cellPaginationbar_spacingrightcellgrid_comentarios_Class ;
      private String cellPaginationbar_spacingrightcellgrid_comentarios_Internalname ;
      private String lblPaginationbar_spacingrighttextblockgrid_comentarios_Internalname ;
      private String cellPaginationbar_nextpagecellgrid_comentarios_Class ;
      private String cellPaginationbar_nextpagecellgrid_comentarios_Internalname ;
      private String tblPaginationbar_pagingcontainertablegrid_comentarios_Internalname ;
      private String tblI_noresultsfoundtablename_grid_comentarios_Internalname ;
      private String lblPaginationbar_firstpagetextblockgrid_actividades_Caption ;
      private String lblPaginationbar_firstpagetextblockgrid_actividades_Internalname ;
      private String lblPaginationbar_previouspagetextblockgrid_actividades_Caption ;
      private String lblPaginationbar_previouspagetextblockgrid_actividades_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_actividades_Caption ;
      private String lblPaginationbar_currentpagetextblockgrid_actividades_Internalname ;
      private String lblPaginationbar_nextpagetextblockgrid_actividades_Caption ;
      private String lblPaginationbar_nextpagetextblockgrid_actividades_Internalname ;
      private String lblPaginationbar_lastpagetextblockgrid_actividades_Caption ;
      private String lblPaginationbar_lastpagetextblockgrid_actividades_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_actividades_Class ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_actividades_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_actividades_Class ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_actividades_Internalname ;
      private String cellPaginationbar_firstpagecellgrid_actividades_Class ;
      private String cellPaginationbar_firstpagecellgrid_actividades_Internalname ;
      private String cellPaginationbar_spacingleftcellgrid_actividades_Class ;
      private String cellPaginationbar_spacingleftcellgrid_actividades_Internalname ;
      private String lblPaginationbar_spacinglefttextblockgrid_actividades_Internalname ;
      private String cellPaginationbar_previouspagecellgrid_actividades_Class ;
      private String cellPaginationbar_previouspagecellgrid_actividades_Internalname ;
      private String cellPaginationbar_lastpagecellgrid_actividades_Class ;
      private String cellPaginationbar_lastpagecellgrid_actividades_Internalname ;
      private String cellPaginationbar_spacingrightcellgrid_actividades_Class ;
      private String cellPaginationbar_spacingrightcellgrid_actividades_Internalname ;
      private String lblPaginationbar_spacingrighttextblockgrid_actividades_Internalname ;
      private String cellPaginationbar_nextpagecellgrid_actividades_Class ;
      private String cellPaginationbar_nextpagecellgrid_actividades_Internalname ;
      private String tblPaginationbar_pagingcontainertablegrid_actividades_Internalname ;
      private String tblI_noresultsfoundtablename_grid_actividades_Internalname ;
      private String cellPaginationbar_previouspagebuttoncellgrid_actividades_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_actividades_Jsonclick ;
      private String lblPaginationbar_firstpagetextblockgrid_actividades_Jsonclick ;
      private String lblPaginationbar_spacinglefttextblockgrid_actividades_Jsonclick ;
      private String lblPaginationbar_previouspagetextblockgrid_actividades_Jsonclick ;
      private String cellPaginationbar_currentpagecellgrid_actividades_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_actividades_Jsonclick ;
      private String lblPaginationbar_nextpagetextblockgrid_actividades_Jsonclick ;
      private String lblPaginationbar_spacingrighttextblockgrid_actividades_Jsonclick ;
      private String lblPaginationbar_lastpagetextblockgrid_actividades_Jsonclick ;
      private String cellPaginationbar_nextpagebuttoncellgrid_actividades_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_actividades_Jsonclick ;
      private String lblI_noresultsfoundtextblock_grid_actividades_Internalname ;
      private String lblI_noresultsfoundtextblock_grid_actividades_Jsonclick ;
      private String tblLayoutdefined_table7_grid_actividades_Internalname ;
      private String divGridsettings_globaltablegrid_actividades_Internalname ;
      private String lblGridsettings_labelgrid_actividades_Internalname ;
      private String lblGridsettings_labelgrid_actividades_Jsonclick ;
      private String bttGridsettings_savegrid_actividades_Internalname ;
      private String bttGridsettings_savegrid_actividades_Jsonclick ;
      private String tblGridsettings_tablecontentgrid_actividades_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_actividades_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_actividades_Jsonclick ;
      private String cmbavGridsettingsrowsperpage_grid_actividades_Jsonclick ;
      private String tblGridtitlecontainertable_grid_actividades_Internalname ;
      private String lblGridtitle_grid_actividades_Internalname ;
      private String lblGridtitle_grid_actividades_Jsonclick ;
      private String cellPaginationbar_previouspagebuttoncellgrid_comentarios_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Jsonclick ;
      private String lblPaginationbar_firstpagetextblockgrid_comentarios_Jsonclick ;
      private String lblPaginationbar_spacinglefttextblockgrid_comentarios_Jsonclick ;
      private String lblPaginationbar_previouspagetextblockgrid_comentarios_Jsonclick ;
      private String cellPaginationbar_currentpagecellgrid_comentarios_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_comentarios_Jsonclick ;
      private String lblPaginationbar_nextpagetextblockgrid_comentarios_Jsonclick ;
      private String lblPaginationbar_spacingrighttextblockgrid_comentarios_Jsonclick ;
      private String lblPaginationbar_lastpagetextblockgrid_comentarios_Jsonclick ;
      private String cellPaginationbar_nextpagebuttoncellgrid_comentarios_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Jsonclick ;
      private String lblI_noresultsfoundtextblock_grid_comentarios_Internalname ;
      private String lblI_noresultsfoundtextblock_grid_comentarios_Jsonclick ;
      private String tblLayoutdefined_table7_grid_comentarios_Internalname ;
      private String divGridsettings_globaltablegrid_comentarios_Internalname ;
      private String lblGridsettings_labelgrid_comentarios_Internalname ;
      private String lblGridsettings_labelgrid_comentarios_Jsonclick ;
      private String bttGridsettings_savegrid_comentarios_Internalname ;
      private String bttGridsettings_savegrid_comentarios_Jsonclick ;
      private String tblGridsettings_tablecontentgrid_comentarios_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_comentarios_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_comentarios_Jsonclick ;
      private String cmbavGridsettingsrowsperpage_grid_comentarios_Jsonclick ;
      private String tblGridtitlecontainertable_grid_comentarios_Internalname ;
      private String lblGridtitle_grid_comentarios_Internalname ;
      private String lblGridtitle_grid_comentarios_Jsonclick ;
      private String cellPaginationbar_previouspagebuttoncellgrid_etiquetas_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Jsonclick ;
      private String lblPaginationbar_firstpagetextblockgrid_etiquetas_Jsonclick ;
      private String lblPaginationbar_spacinglefttextblockgrid_etiquetas_Jsonclick ;
      private String lblPaginationbar_previouspagetextblockgrid_etiquetas_Jsonclick ;
      private String cellPaginationbar_currentpagecellgrid_etiquetas_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_etiquetas_Jsonclick ;
      private String lblPaginationbar_nextpagetextblockgrid_etiquetas_Jsonclick ;
      private String lblPaginationbar_spacingrighttextblockgrid_etiquetas_Jsonclick ;
      private String lblPaginationbar_lastpagetextblockgrid_etiquetas_Jsonclick ;
      private String cellPaginationbar_nextpagebuttoncellgrid_etiquetas_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Jsonclick ;
      private String lblI_noresultsfoundtextblock_grid_etiquetas_Internalname ;
      private String lblI_noresultsfoundtextblock_grid_etiquetas_Jsonclick ;
      private String tblLayoutdefined_table7_grid_etiquetas_Internalname ;
      private String divGridsettings_globaltablegrid_etiquetas_Internalname ;
      private String lblGridsettings_labelgrid_etiquetas_Internalname ;
      private String lblGridsettings_labelgrid_etiquetas_Jsonclick ;
      private String bttGridsettings_savegrid_etiquetas_Internalname ;
      private String bttGridsettings_savegrid_etiquetas_Jsonclick ;
      private String tblGridsettings_tablecontentgrid_etiquetas_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_etiquetas_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_etiquetas_Jsonclick ;
      private String cmbavGridsettingsrowsperpage_grid_etiquetas_Jsonclick ;
      private String tblGridtitlecontainertable_grid_etiquetas_Internalname ;
      private String lblGridtitle_grid_etiquetas_Internalname ;
      private String lblGridtitle_grid_etiquetas_Jsonclick ;
      private String sGXsfl_111_fel_idx="0001" ;
      private String ROClassString ;
      private String edtTrTareasEtiquetas_ID_Jsonclick ;
      private String edtTrTareasEtiquetas_IDEtiqueta_Jsonclick ;
      private String edtTrTareasEtiquetas_NombreEtiqueta_Jsonclick ;
      private String sGXsfl_198_fel_idx="0001" ;
      private String edtTrTareaComentarios_ID_Jsonclick ;
      private String edtTrTareaComentarios_Descripcion_Jsonclick ;
      private String edtTrTareaComentarios_FechaCreacion_Jsonclick ;
      private String edtTrTareaComentarios_FechaModificacion_Jsonclick ;
      private String GXCCtl ;
      private String cmbTrTareaComentarios_Estado_Jsonclick ;
      private String sGXsfl_285_fel_idx="0001" ;
      private String sImgUrl ;
      private String edtavActualizaractividad_action_Jsonclick ;
      private String edtavInformacionactividad_action_Jsonclick ;
      private String edtTrActividades_ID_Jsonclick ;
      private String edtTrActividades_IDTarea_Jsonclick ;
      private String edtTrActividades_Nombre_Jsonclick ;
      private String edtTrActividades_Descripcion_Jsonclick ;
      private String edtTrActividades_FechaInicio_Jsonclick ;
      private String edtTrActividades_FechaFin_Jsonclick ;
      private String cmbTrActividades_Estado_Jsonclick ;
      private DateTime A15TrGestionTareas_FechaInicio ;
      private DateTime A16TrGestionTareas_FechaFin ;
      private DateTime AV17TrGestionTareas_FechaInicio ;
      private DateTime AV18TrGestionTareas_FechaFin ;
      private DateTime A38TrTareaComentarios_FechaCreacion ;
      private DateTime A39TrTareaComentarios_FechaModificacion ;
      private DateTime A29TrActividades_FechaInicio ;
      private DateTime A30TrActividades_FechaFin ;
      private bool entryPointCalled ;
      private bool n13TrGestionTareas_Nombre ;
      private bool n14TrGestionTareas_Descripcion ;
      private bool n15TrGestionTareas_FechaInicio ;
      private bool n16TrGestionTareas_FechaFin ;
      private bool n24TrGestionTareas_Estado ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n54TrTareasEtiquetas_NombreEtiqueta ;
      private bool bGXsfl_285_Refreshing=false ;
      private bool n25TrActividades_IDTarea ;
      private bool n27TrActividades_Nombre ;
      private bool n28TrActividades_Descripcion ;
      private bool n29TrActividades_FechaInicio ;
      private bool n30TrActividades_FechaFin ;
      private bool n33TrActividades_Estado ;
      private bool n36TrTareaComentarios_Descripcion ;
      private bool n38TrTareaComentarios_FechaCreacion ;
      private bool n39TrTareaComentarios_FechaModificacion ;
      private bool n37TrTareaComentarios_Estado ;
      private bool bGXsfl_111_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_198_Refreshing=false ;
      private bool n34TrTareaComentarios_IDTarea ;
      private bool returnInSub ;
      private bool AV46RowsPerPageLoaded_Grid_Etiquetas ;
      private bool AV41RowsPerPageLoaded_Grid_Comentarios ;
      private bool AV59RowsPerPageLoaded_Grid_Actividades ;
      private bool gx_refresh_fired ;
      private bool AV62ActualizarActividad_Action_IsBlob ;
      private bool AV70InformacionActividad_Action_IsBlob ;
      private String A14TrGestionTareas_Descripcion ;
      private String AV16TrGestionTareas_Descripcion ;
      private String A36TrTareaComentarios_Descripcion ;
      private String A28TrActividades_Descripcion ;
      private String AV75Actualizaractividad_action_GXI ;
      private String AV76Informacionactividad_action_GXI ;
      private String AV12GridStateKey ;
      private String AV62ActualizarActividad_Action ;
      private String AV70InformacionActividad_Action ;
      private GXWebGrid Grid_etiquetasContainer ;
      private GXWebGrid Grid_comentariosContainer ;
      private GXWebGrid Grid_actividadesContainer ;
      private GXWebRow Grid_etiquetasRow ;
      private GXWebRow Grid_comentariosRow ;
      private GXWebRow Grid_actividadesRow ;
      private GXWebColumn Grid_etiquetasColumn ;
      private GXWebColumn Grid_comentariosColumn ;
      private GXWebColumn Grid_actividadesColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTrgestiontareas_estado ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid_etiquetas ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid_comentarios ;
      private GXCombobox cmbTrTareaComentarios_Estado ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid_actividades ;
      private GXCombobox cmbTrActividades_Estado ;
      private IDataStoreProvider pr_default ;
      private long[] H00272_A52TrTareasEtiquetas_TareaID ;
      private String[] H00272_A54TrTareasEtiquetas_NombreEtiqueta ;
      private bool[] H00272_n54TrTareasEtiquetas_NombreEtiqueta ;
      private long[] H00272_A53TrTareasEtiquetas_IDEtiqueta ;
      private long[] H00272_A51TrTareasEtiquetas_ID ;
      private long[] H00273_A34TrTareaComentarios_IDTarea ;
      private bool[] H00273_n34TrTareaComentarios_IDTarea ;
      private short[] H00273_A37TrTareaComentarios_Estado ;
      private bool[] H00273_n37TrTareaComentarios_Estado ;
      private DateTime[] H00273_A39TrTareaComentarios_FechaModificacion ;
      private bool[] H00273_n39TrTareaComentarios_FechaModificacion ;
      private DateTime[] H00273_A38TrTareaComentarios_FechaCreacion ;
      private bool[] H00273_n38TrTareaComentarios_FechaCreacion ;
      private String[] H00273_A36TrTareaComentarios_Descripcion ;
      private bool[] H00273_n36TrTareaComentarios_Descripcion ;
      private long[] H00273_A35TrTareaComentarios_ID ;
      private short[] H00274_A33TrActividades_Estado ;
      private bool[] H00274_n33TrActividades_Estado ;
      private DateTime[] H00274_A30TrActividades_FechaFin ;
      private bool[] H00274_n30TrActividades_FechaFin ;
      private DateTime[] H00274_A29TrActividades_FechaInicio ;
      private bool[] H00274_n29TrActividades_FechaInicio ;
      private String[] H00274_A28TrActividades_Descripcion ;
      private bool[] H00274_n28TrActividades_Descripcion ;
      private String[] H00274_A27TrActividades_Nombre ;
      private bool[] H00274_n27TrActividades_Nombre ;
      private long[] H00274_A25TrActividades_IDTarea ;
      private bool[] H00274_n25TrActividades_IDTarea ;
      private long[] H00274_A26TrActividades_ID ;
      private long[] H00275_AGRID_ETIQUETAS_nRecordCount ;
      private long[] H00276_AGRID_COMENTARIOS_nRecordCount ;
      private long[] H00277_AGRID_ACTIVIDADES_nRecordCount ;
      private long[] H00278_A12TrGestionTareas_ID ;
      private String[] H00278_A13TrGestionTareas_Nombre ;
      private bool[] H00278_n13TrGestionTareas_Nombre ;
      private String[] H00278_A14TrGestionTareas_Descripcion ;
      private bool[] H00278_n14TrGestionTareas_Descripcion ;
      private DateTime[] H00278_A15TrGestionTareas_FechaInicio ;
      private bool[] H00278_n15TrGestionTareas_FechaInicio ;
      private DateTime[] H00278_A16TrGestionTareas_FechaFin ;
      private bool[] H00278_n16TrGestionTareas_FechaFin ;
      private short[] H00278_A24TrGestionTareas_Estado ;
      private bool[] H00278_n24TrGestionTareas_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtK2BGridState AV13GridState ;
   }

   public class wpvisualizarinformaciontarea__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00272 ;
          prmH00272 = new Object[] {
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00273 ;
          prmH00273 = new Object[] {
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@GXPagingFrom4",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo4",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00274 ;
          prmH00274 = new Object[] {
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@GXPagingFrom5",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo5",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00275 ;
          prmH00275 = new Object[] {
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmH00276 ;
          prmH00276 = new Object[] {
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmH00277 ;
          prmH00277 = new Object[] {
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmH00278 ;
          prmH00278 = new Object[] {
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00272", "SELECT T1.[TrTareasEtiquetas_TareaID], T2.[TrEtiquetas_Nombre] AS TrTareasEtiquetas_NombreEtiqueta, T1.[TrTareasEtiquetas_IDEtiqueta] AS TrTareasEtiquetas_IDEtiqueta, T1.[TrTareasEtiquetas_ID] FROM (TABLERO.[TrTareasEtiquetas] T1 INNER JOIN TABLERO.[TrEtiquetas] T2 ON T2.[TrEtiquetas_ID] = T1.[TrTareasEtiquetas_IDEtiqueta]) WHERE T1.[TrTareasEtiquetas_TareaID] = @AV26TrGestionTareas_ID ORDER BY T1.[TrTareasEtiquetas_TareaID]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00272,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00273", "SELECT [TrTareaComentarios_IDTarea], [TrTareaComentarios_Estado], [TrTareaComentarios_FechaModificacion], [TrTareaComentarios_FechaCreacion], [TrTareaComentarios_Descripcion], [TrTareaComentarios_ID] FROM TABLERO.[TrTareaComentarios] WHERE [TrTareaComentarios_IDTarea] = @AV26TrGestionTareas_ID ORDER BY [TrTareaComentarios_IDTarea]  OFFSET @GXPagingFrom4 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo4 > 0 THEN @GXPagingTo4 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00273,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00274", "SELECT [TrActividades_Estado], [TrActividades_FechaFin], [TrActividades_FechaInicio], [TrActividades_Descripcion], [TrActividades_Nombre], [TrActividades_IDTarea], [TrActividades_ID] FROM TABLERO.[TrActividades] WHERE [TrActividades_IDTarea] = @AV26TrGestionTareas_ID ORDER BY [TrActividades_IDTarea]  OFFSET @GXPagingFrom5 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo5 > 0 THEN @GXPagingTo5 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00274,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00275", "SELECT COUNT(*) FROM (TABLERO.[TrTareasEtiquetas] T1 INNER JOIN TABLERO.[TrEtiquetas] T2 ON T2.[TrEtiquetas_ID] = T1.[TrTareasEtiquetas_IDEtiqueta]) WHERE T1.[TrTareasEtiquetas_TareaID] = @AV26TrGestionTareas_ID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00275,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00276", "SELECT COUNT(*) FROM TABLERO.[TrTareaComentarios] WHERE [TrTareaComentarios_IDTarea] = @AV26TrGestionTareas_ID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00276,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00277", "SELECT COUNT(*) FROM TABLERO.[TrActividades] WHERE [TrActividades_IDTarea] = @AV26TrGestionTareas_ID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00277,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00278", "SELECT [TrGestionTareas_ID], [TrGestionTareas_Nombre], [TrGestionTareas_Descripcion], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_Estado] FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @AV26TrGestionTareas_ID ORDER BY [TrGestionTareas_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00278,1, GxCacheFrequency.OFF ,false,true )
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
                ((String[]) buf[1])[0] = rslt.getString(2, 256) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3) ;
                ((long[]) buf[4])[0] = rslt.getLong(4) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((String[]) buf[8])[0] = rslt.getLongVarchar(5) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6) ;
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((String[]) buf[6])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((String[]) buf[8])[0] = rslt.getString(5, 100) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7) ;
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
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
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 1 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 2 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 3 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 6 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
       }
    }

 }

}
