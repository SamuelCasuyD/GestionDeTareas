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
               nRC_GXsfl_106 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_106_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_106_idx = GetNextPar( );
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
               AV53Pgmname = GetNextPar( );
               AV43CurrentPage_Grid_Etiquetas = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid_comentarios") == 0 )
            {
               nRC_GXsfl_191 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_191_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_191_idx = GetNextPar( );
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
               AV53Pgmname = GetNextPar( );
               AV35CurrentPage_Grid_Comentarios = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV35CurrentPage_Grid_Comentarios) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2022102021474341", false, true);
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_106", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_106), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_191", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_191), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID_ETIQUETAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID_COMENTARIOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_NOMBRE", StringUtil.RTrim( A13TrGestionTareas_Nombre));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_DESCRIPCION", A14TrGestionTareas_Descripcion);
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAINICIO", context.localUtil.DToC( A15TrGestionTareas_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAFIN", context.localUtil.DToC( A16TrGestionTareas_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24TrGestionTareas_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID_ETIQUETAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45RowsPerPage_Grid_Etiquetas), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID_COMENTARIOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40RowsPerPage_Grid_Comentarios), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_etiquetas_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_comentarios_Visible), 5, 0, ".", "")));
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
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_nombre_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_nombrefieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_nombre_var_lefttext_Internalname, "Nombre : ", "", "", lblTrgestiontareas_nombre_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_106_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_nombre_Internalname, StringUtil.RTrim( AV15TrGestionTareas_Nombre), StringUtil.RTrim( context.localUtil.Format( AV15TrGestionTareas_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontareas_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpVisualizarInformacionTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_descripcion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_descripcionfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_descripcion_var_lefttext_Internalname, "Descripción : ", "", "", lblTrgestiontareas_descripcion_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTrgestiontareas_descripcion_Internalname, AV16TrGestionTareas_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", 0, 1, edtavTrgestiontareas_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpVisualizarInformacionTarea.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechainicio_var_lefttext_Internalname, "Fecha de inicio : ", "", "", lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_106_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontareas_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_fechainicio_Internalname, context.localUtil.Format(AV17TrGestionTareas_FechaInicio, "99/99/9999"), context.localUtil.Format( AV17TrGestionTareas_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontareas_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpVisualizarInformacionTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontareas_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontareas_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpVisualizarInformacionTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_fechafin_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_fechafinfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTrgestiontareas_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_106_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontareas_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_fechafin_Internalname, context.localUtil.Format(AV18TrGestionTareas_FechaFin, "99/99/9999"), context.localUtil.Format( AV18TrGestionTareas_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontareas_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpVisualizarInformacionTarea.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontareas_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontareas_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpVisualizarInformacionTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_estado_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trgestiontareas_estadofieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_estado_var_lefttext_Internalname, "Estado : ", "", "", lblTrgestiontareas_estado_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_106_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTrgestiontareas_estado, cmbavTrgestiontareas_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0)), 1, cmbavTrgestiontareas_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTrgestiontareas_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, "HLP_WpVisualizarInformacionTarea.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponent_grid_etiquetas_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_60_272( true) ;
         }
         else
         {
            wb_table1_60_272( false) ;
         }
         return  ;
      }

      protected void wb_table1_60_272e( bool wbgen )
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
            wb_table2_75_272( true) ;
         }
         else
         {
            wb_table2_75_272( false) ;
         }
         return  ;
      }

      protected void wb_table2_75_272e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"Grid_etiquetasContainer"+"DivS\" data-gxgridid=\"106\">") ;
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
         if ( wbEnd == 106 )
         {
            wbEnd = 0;
            nRC_GXsfl_106 = (int)(nGXsfl_106_idx-1);
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
            wb_table3_112_272( true) ;
         }
         else
         {
            wb_table3_112_272( false) ;
         }
         return  ;
      }

      protected void wb_table3_112_272e( bool wbgen )
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
            wb_table4_119_272( true) ;
         }
         else
         {
            wb_table4_119_272( false) ;
         }
         return  ;
      }

      protected void wb_table4_119_272e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponent_grid_comentarios_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table5_145_272( true) ;
         }
         else
         {
            wb_table5_145_272( false) ;
         }
         return  ;
      }

      protected void wb_table5_145_272e( bool wbgen )
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
            wb_table6_160_272( true) ;
         }
         else
         {
            wb_table6_160_272( false) ;
         }
         return  ;
      }

      protected void wb_table6_160_272e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"Grid_comentariosContainer"+"DivS\" data-gxgridid=\"191\">") ;
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
         if ( wbEnd == 191 )
         {
            wbEnd = 0;
            nRC_GXsfl_191 = (int)(nGXsfl_191_idx-1);
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
            wb_table7_199_272( true) ;
         }
         else
         {
            wb_table7_199_272( false) ;
         }
         return  ;
      }

      protected void wb_table7_199_272e( bool wbgen )
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
            wb_table8_206_272( true) ;
         }
         else
         {
            wb_table8_206_272( false) ;
         }
         return  ;
      }

      protected void wb_table8_206_272e( bool wbgen )
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
         if ( wbEnd == 106 )
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
         if ( wbEnd == 191 )
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
                              nGXsfl_106_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
                              SubsflControlProps_1062( ) ;
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
                                    E21272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E22272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID_ETIQUETAS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E23272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID_ETIQUETAS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E24272 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "GRID_COMENTARIOS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "GRID_COMENTARIOS.LOAD") == 0 ) )
                           {
                              nGXsfl_191_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
                              SubsflControlProps_1914( ) ;
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
                                    E25272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID_COMENTARIOS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E26274 ();
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
         SubsflControlProps_1062( ) ;
         while ( nGXsfl_106_idx <= nRC_GXsfl_106 )
         {
            sendrow_1062( ) ;
            nGXsfl_106_idx = ((subGrid_etiquetas_Islastpage==1)&&(nGXsfl_106_idx+1>subGrid_etiquetas_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_idx+1);
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1062( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid_etiquetasContainer)) ;
         /* End function gxnrGrid_etiquetas_newrow */
      }

      protected void gxnrGrid_comentarios_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1914( ) ;
         while ( nGXsfl_191_idx <= nRC_GXsfl_191 )
         {
            sendrow_1914( ) ;
            nGXsfl_191_idx = ((subGrid_comentarios_Islastpage==1)&&(nGXsfl_191_idx+1>subGrid_comentarios_fnc_Recordsperpage( )) ? 1 : nGXsfl_191_idx+1);
            sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
            SubsflControlProps_1914( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid_comentariosContainer)) ;
         /* End function gxnrGrid_comentarios_newrow */
      }

      protected void gxgrGrid_etiquetas_refresh( int subGrid_etiquetas_Rows ,
                                                 long AV26TrGestionTareas_ID ,
                                                 short AV35CurrentPage_Grid_Comentarios ,
                                                 long A12TrGestionTareas_ID ,
                                                 String A13TrGestionTareas_Nombre ,
                                                 String A14TrGestionTareas_Descripcion ,
                                                 DateTime A15TrGestionTareas_FechaInicio ,
                                                 DateTime A16TrGestionTareas_FechaFin ,
                                                 short A24TrGestionTareas_Estado ,
                                                 String AV53Pgmname ,
                                                 short AV43CurrentPage_Grid_Etiquetas )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E22272 ();
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
                                                   long A12TrGestionTareas_ID ,
                                                   String A13TrGestionTareas_Nombre ,
                                                   String A14TrGestionTareas_Descripcion ,
                                                   DateTime A15TrGestionTareas_FechaInicio ,
                                                   DateTime A16TrGestionTareas_FechaFin ,
                                                   short A24TrGestionTareas_Estado ,
                                                   String AV53Pgmname ,
                                                   short AV35CurrentPage_Grid_Comentarios )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E22272 ();
         GRID_COMENTARIOS_nCurrentRecord = 0;
         RF274( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_comentarios_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E22272 ();
         RF272( ) ;
         RF274( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV53Pgmname = "WpVisualizarInformacionTarea";
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
         wbStart = 106;
         E23272 ();
         nGXsfl_106_idx = 1;
         sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
         SubsflControlProps_1062( ) ;
         bGXsfl_106_Refreshing = true;
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
            SubsflControlProps_1062( ) ;
            GXPagingFrom2 = (int)(((subGrid_etiquetas_Rows==0) ? 0 : GRID_ETIQUETAS_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_etiquetas_Rows==0) ? 10000 : subGrid_etiquetas_fnc_Recordsperpage( )+1);
            /* Using cursor H00272 */
            pr_default.execute(0, new Object[] {AV26TrGestionTareas_ID, GXPagingFrom2, GXPagingTo2});
            nGXsfl_106_idx = 1;
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1062( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_etiquetas_Rows == 0 ) || ( GRID_ETIQUETAS_nCurrentRecord < subGrid_etiquetas_fnc_Recordsperpage( ) ) ) ) )
            {
               A52TrTareasEtiquetas_TareaID = H00272_A52TrTareasEtiquetas_TareaID[0];
               A54TrTareasEtiquetas_NombreEtiqueta = H00272_A54TrTareasEtiquetas_NombreEtiqueta[0];
               n54TrTareasEtiquetas_NombreEtiqueta = H00272_n54TrTareasEtiquetas_NombreEtiqueta[0];
               A53TrTareasEtiquetas_IDEtiqueta = H00272_A53TrTareasEtiquetas_IDEtiqueta[0];
               A51TrTareasEtiquetas_ID = H00272_A51TrTareasEtiquetas_ID[0];
               A54TrTareasEtiquetas_NombreEtiqueta = H00272_A54TrTareasEtiquetas_NombreEtiqueta[0];
               n54TrTareasEtiquetas_NombreEtiqueta = H00272_n54TrTareasEtiquetas_NombreEtiqueta[0];
               E24272 ();
               pr_default.readNext(0);
            }
            GRID_ETIQUETAS_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_ETIQUETAS_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 106;
            WB270( ) ;
         }
         bGXsfl_106_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes272( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
      }

      protected void RF274( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid_comentariosContainer.ClearRows();
         }
         wbStart = 191;
         E25272 ();
         nGXsfl_191_idx = 1;
         sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
         SubsflControlProps_1914( ) ;
         bGXsfl_191_Refreshing = true;
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
            SubsflControlProps_1914( ) ;
            GXPagingFrom4 = (int)(((subGrid_comentarios_Rows==0) ? 0 : GRID_COMENTARIOS_nFirstRecordOnPage));
            GXPagingTo4 = ((subGrid_comentarios_Rows==0) ? 10000 : subGrid_comentarios_fnc_Recordsperpage( )+1);
            /* Using cursor H00273 */
            pr_default.execute(1, new Object[] {AV26TrGestionTareas_ID, GXPagingFrom4, GXPagingTo4});
            nGXsfl_191_idx = 1;
            sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
            SubsflControlProps_1914( ) ;
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
               E26274 ();
               pr_default.readNext(1);
            }
            GRID_COMENTARIOS_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_COMENTARIOS_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 191;
            WB270( ) ;
         }
         bGXsfl_191_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes274( )
      {
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
         /* Using cursor H00274 */
         pr_default.execute(2, new Object[] {AV26TrGestionTareas_ID});
         GRID_ETIQUETAS_nRecordCount = H00274_AGRID_ETIQUETAS_nRecordCount[0];
         pr_default.close(2);
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
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
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
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
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
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
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
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
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
            gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
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
         /* Using cursor H00275 */
         pr_default.execute(3, new Object[] {AV26TrGestionTareas_ID});
         GRID_COMENTARIOS_nRecordCount = H00275_AGRID_COMENTARIOS_nRecordCount[0];
         pr_default.close(3);
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
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV35CurrentPage_Grid_Comentarios) ;
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
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV35CurrentPage_Grid_Comentarios) ;
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
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV35CurrentPage_Grid_Comentarios) ;
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
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV35CurrentPage_Grid_Comentarios) ;
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
            gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV35CurrentPage_Grid_Comentarios) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV53Pgmname = "WpVisualizarInformacionTarea";
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
         E21272 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_106 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_106"), ".", ","));
            nRC_GXsfl_191 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_191"), ".", ","));
            GRID_ETIQUETAS_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_ETIQUETAS_nFirstRecordOnPage"), ".", ","));
            GRID_COMENTARIOS_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_COMENTARIOS_nFirstRecordOnPage"), ".", ","));
            GRID_ETIQUETAS_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_ETIQUETAS_nEOF"), ".", ","));
            GRID_COMENTARIOS_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_COMENTARIOS_nEOF"), ".", ","));
            subGrid_etiquetas_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_ETIQUETAS_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Rows), 6, 0, ".", "")));
            subGrid_comentarios_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_COMENTARIOS_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15TrGestionTareas_Nombre = cgiGet( edtavTrgestiontareas_nombre_Internalname);
            AssignAttri("", false, "AV15TrGestionTareas_Nombre", AV15TrGestionTareas_Nombre);
            AV16TrGestionTareas_Descripcion = cgiGet( edtavTrgestiontareas_descripcion_Internalname);
            AssignAttri("", false, "AV16TrGestionTareas_Descripcion", AV16TrGestionTareas_Descripcion);
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 1) == 0 )
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
               AV17TrGestionTareas_FechaInicio = context.localUtil.CToD( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 1);
               AssignAttri("", false, "AV17TrGestionTareas_FechaInicio", context.localUtil.Format(AV17TrGestionTareas_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 1) == 0 )
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
               AV18TrGestionTareas_FechaFin = context.localUtil.CToD( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 1);
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
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S142( )
      {
         /* 'U_STARTPAGE' Routine */
         /* Using cursor H00276 */
         pr_default.execute(4, new Object[] {AV26TrGestionTareas_ID});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A12TrGestionTareas_ID = H00276_A12TrGestionTareas_ID[0];
            A13TrGestionTareas_Nombre = H00276_A13TrGestionTareas_Nombre[0];
            n13TrGestionTareas_Nombre = H00276_n13TrGestionTareas_Nombre[0];
            A14TrGestionTareas_Descripcion = H00276_A14TrGestionTareas_Descripcion[0];
            n14TrGestionTareas_Descripcion = H00276_n14TrGestionTareas_Descripcion[0];
            A15TrGestionTareas_FechaInicio = H00276_A15TrGestionTareas_FechaInicio[0];
            n15TrGestionTareas_FechaInicio = H00276_n15TrGestionTareas_FechaInicio[0];
            A16TrGestionTareas_FechaFin = H00276_A16TrGestionTareas_FechaFin[0];
            n16TrGestionTareas_FechaFin = H00276_n16TrGestionTareas_FechaFin[0];
            A24TrGestionTareas_Estado = H00276_A24TrGestionTareas_Estado[0];
            n24TrGestionTareas_Estado = H00276_n24TrGestionTareas_Estado[0];
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
         pr_default.close(4);
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
         E21272 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21272( )
      {
         /* Start Routine */
         new k2bloadrowsperpage(context ).execute(  AV53Pgmname,  "Grid_Etiquetas", out  AV45RowsPerPage_Grid_Etiquetas, out  AV46RowsPerPageLoaded_Grid_Etiquetas) ;
         AssignAttri("", false, "AV45RowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV45RowsPerPage_Grid_Etiquetas), 4, 0));
         if ( ! AV46RowsPerPageLoaded_Grid_Etiquetas )
         {
            AV45RowsPerPage_Grid_Etiquetas = 20;
            AssignAttri("", false, "AV45RowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV45RowsPerPage_Grid_Etiquetas), 4, 0));
         }
         AV47GridSettingsRowsPerPage_Grid_Etiquetas = AV45RowsPerPage_Grid_Etiquetas;
         AssignAttri("", false, "AV47GridSettingsRowsPerPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0));
         subGrid_etiquetas_Rows = AV45RowsPerPage_Grid_Etiquetas;
         GxWebStd.gx_hidden_field( context, "GRID_ETIQUETAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_etiquetas_Rows), 6, 0, ".", "")));
         new k2bloadrowsperpage(context ).execute(  AV53Pgmname,  "Grid_Comentarios", out  AV40RowsPerPage_Grid_Comentarios, out  AV41RowsPerPageLoaded_Grid_Comentarios) ;
         AssignAttri("", false, "AV40RowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV40RowsPerPage_Grid_Comentarios), 4, 0));
         if ( ! AV41RowsPerPageLoaded_Grid_Comentarios )
         {
            AV40RowsPerPage_Grid_Comentarios = 20;
            AssignAttri("", false, "AV40RowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV40RowsPerPage_Grid_Comentarios), 4, 0));
         }
         AV42GridSettingsRowsPerPage_Grid_Comentarios = AV40RowsPerPage_Grid_Comentarios;
         AssignAttri("", false, "AV42GridSettingsRowsPerPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0));
         subGrid_comentarios_Rows = AV40RowsPerPage_Grid_Comentarios;
         GxWebStd.gx_hidden_field( context, "GRID_COMENTARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_comentarios_Rows), 6, 0, ".", "")));
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
      }

      protected void E22272( )
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
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", cmbavTrgestiontareas_estado.ToJavascriptSource(), true);
      }

      protected void S192( )
      {
         /* 'U_LOADROWVARS(GRID_ETIQUETAS)' Routine */
      }

      protected void E11272( )
      {
         /* 'PagingFirst(Grid_Etiquetas)' Routine */
         subgrid_etiquetas_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ETIQUETAS)' */
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

      protected void S182( )
      {
         /* 'U_GRIDREFRESH(GRID_ETIQUETAS)' Routine */
      }

      protected void E23272( )
      {
         /* Grid_etiquetas_Refresh Routine */
         tblI_noresultsfoundtablename_grid_etiquetas_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_etiquetas_Visible), 5, 0), true);
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID_ETIQUETAS)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_etiquetas_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID_ETIQUETAS)' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ETIQUETAS)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      private void E24272( )
      {
         /* Grid_etiquetas_Load Routine */
         tblI_noresultsfoundtablename_grid_etiquetas_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_etiquetas_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_ETIQUETAS)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 106;
         }
         sendrow_1062( ) ;
         GRID_ETIQUETAS_nCurrentRecord = (long)(GRID_ETIQUETAS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_106_Refreshing )
         {
            context.DoAjaxLoad(106, Grid_etiquetasRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID_ETIQUETAS)' Routine */
         AV12GridStateKey = "Grid_Etiquetas";
         new k2bloadgridstate(context ).execute(  AV53Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV48PageCount_Grid_Etiquetas = (short)(subGrid_etiquetas_fnc_Pagecount( ));
         if ( ( AV13GridState.gxTpr_Currentpage > 0 ) && ( AV13GridState.gxTpr_Currentpage <= AV48PageCount_Grid_Etiquetas ) )
         {
            AV43CurrentPage_Grid_Etiquetas = AV13GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV43CurrentPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0));
            subgrid_etiquetas_gotopage( AV43CurrentPage_Grid_Etiquetas) ;
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE(GRID_ETIQUETAS)' Routine */
         AV12GridStateKey = "Grid_Etiquetas";
         new k2bloadgridstate(context ).execute(  AV53Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_etiquetas_fnc_Currentpage( ));
         AV13GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV53Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void E12272( )
      {
         /* 'PagingLast(Grid_Etiquetas)' Routine */
         subgrid_etiquetas_lastpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_ETIQUETAS)' */
         S162 ();
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
         S162 ();
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
         S162 ();
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
            new k2bsaverowsperpage(context ).execute(  AV53Pgmname,  "Grid_Etiquetas",  AV45RowsPerPage_Grid_Etiquetas) ;
            AV43CurrentPage_Grid_Etiquetas = 1;
            AssignAttri("", false, "AV43CurrentPage_Grid_Etiquetas", StringUtil.LTrimStr( (decimal)(AV43CurrentPage_Grid_Etiquetas), 4, 0));
            subgrid_etiquetas_firstpage( ) ;
         }
         gxgrGrid_etiquetas_refresh( subGrid_etiquetas_Rows, AV26TrGestionTareas_ID, AV35CurrentPage_Grid_Comentarios, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV43CurrentPage_Grid_Etiquetas) ;
         divGridsettings_contentoutertablegrid_etiquetas_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_etiquetas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_etiquetas_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19TrGestionTareas_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", cmbavTrgestiontareas_estado.ToJavascriptSource(), true);
      }

      protected void S234( )
      {
         /* 'U_LOADROWVARS(GRID_COMENTARIOS)' Routine */
      }

      protected void E16272( )
      {
         /* 'PagingFirst(Grid_Comentarios)' Routine */
         subgrid_comentarios_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_COMENTARIOS)' */
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

      protected void S222( )
      {
         /* 'U_GRIDREFRESH(GRID_COMENTARIOS)' Routine */
      }

      protected void E25272( )
      {
         /* Grid_comentarios_Refresh Routine */
         tblI_noresultsfoundtablename_grid_comentarios_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_comentarios_Visible), 5, 0), true);
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID_COMENTARIOS)' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_comentarios_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID_COMENTARIOS)' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_COMENTARIOS)' */
         S202 ();
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
         new k2bloadgridstate(context ).execute(  AV53Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV49PageCount_Grid_Comentarios = (short)(subGrid_comentarios_fnc_Pagecount( ));
         if ( ( AV13GridState.gxTpr_Currentpage > 0 ) && ( AV13GridState.gxTpr_Currentpage <= AV49PageCount_Grid_Comentarios ) )
         {
            AV35CurrentPage_Grid_Comentarios = AV13GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV35CurrentPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0));
            subgrid_comentarios_gotopage( AV35CurrentPage_Grid_Comentarios) ;
         }
      }

      protected void S212( )
      {
         /* 'SAVEGRIDSTATE(GRID_COMENTARIOS)' Routine */
         AV12GridStateKey = "Grid_Comentarios";
         new k2bloadgridstate(context ).execute(  AV53Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_comentarios_fnc_Currentpage( ));
         AV13GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV53Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void E17272( )
      {
         /* 'PagingNext(Grid_Comentarios)' Routine */
         subgrid_comentarios_nextpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_COMENTARIOS)' */
         S202 ();
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
         S202 ();
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
            new k2bsaverowsperpage(context ).execute(  AV53Pgmname,  "Grid_Comentarios",  AV40RowsPerPage_Grid_Comentarios) ;
            AV35CurrentPage_Grid_Comentarios = 1;
            AssignAttri("", false, "AV35CurrentPage_Grid_Comentarios", StringUtil.LTrimStr( (decimal)(AV35CurrentPage_Grid_Comentarios), 4, 0));
            subgrid_comentarios_firstpage( ) ;
         }
         gxgrGrid_comentarios_refresh( subGrid_comentarios_Rows, AV26TrGestionTareas_ID, AV43CurrentPage_Grid_Etiquetas, A12TrGestionTareas_ID, A13TrGestionTareas_Nombre, A14TrGestionTareas_Descripcion, A15TrGestionTareas_FechaInicio, A16TrGestionTareas_FechaFin, A24TrGestionTareas_Estado, AV53Pgmname, AV35CurrentPage_Grid_Comentarios) ;
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
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      private void E26274( )
      {
         /* Grid_comentarios_Load Routine */
         tblI_noresultsfoundtablename_grid_comentarios_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_comentarios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_comentarios_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_COMENTARIOS)' */
         S234 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 191;
         }
         sendrow_1914( ) ;
         GRID_COMENTARIOS_nCurrentRecord = (long)(GRID_COMENTARIOS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_191_Refreshing )
         {
            context.DoAjaxLoad(191, Grid_comentariosRow);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table8_206_272( bool wbgen )
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
            wb_table8_206_272e( true) ;
         }
         else
         {
            wb_table8_206_272e( false) ;
         }
      }

      protected void wb_table7_199_272( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_comentarios_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_199_272e( true) ;
         }
         else
         {
            wb_table7_199_272e( false) ;
         }
      }

      protected void wb_table6_160_272( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_comentarios_Internalname, "", "", "", lblGridsettings_labelgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+"e27271_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
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
            wb_table9_172_272( true) ;
         }
         else
         {
            wb_table9_172_272( false) ;
         }
         return  ;
      }

      protected void wb_table9_172_272e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_comentarios_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(106), 3, 0)+","+"null"+");", "Save", bttGridsettings_savegrid_comentarios_Jsonclick, 5, "Save", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID_COMENTARIOS)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpVisualizarInformacionTarea.htm");
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
            wb_table6_160_272e( true) ;
         }
         else
         {
            wb_table6_160_272e( false) ;
         }
      }

      protected void wb_table9_172_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_comentarios_Internalname, tblGridsettings_tablecontentgrid_comentarios_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_comentarios_Internalname, "Rows per page", "", "", lblGridsettings_rowsperpagetextblockgrid_comentarios_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_comentarios_Internalname, "Grid Settings Rows Per Page_Grid_Comentarios", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'" + sGXsfl_106_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid_comentarios, cmbavGridsettingsrowsperpage_grid_comentarios_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_comentarios_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Rows per page", 1, cmbavGridsettingsrowsperpage_grid_comentarios.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,178);\"", "", true, "HLP_WpVisualizarInformacionTarea.htm");
            cmbavGridsettingsrowsperpage_grid_comentarios.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPage_Grid_Comentarios), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_comentarios_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid_comentarios.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_172_272e( true) ;
         }
         else
         {
            wb_table9_172_272e( false) ;
         }
      }

      protected void wb_table5_145_272( bool wbgen )
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
            wb_table5_145_272e( true) ;
         }
         else
         {
            wb_table5_145_272e( false) ;
         }
      }

      protected void wb_table4_119_272( bool wbgen )
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
            wb_table4_119_272e( true) ;
         }
         else
         {
            wb_table4_119_272e( false) ;
         }
      }

      protected void wb_table3_112_272( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_etiquetas_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_112_272e( true) ;
         }
         else
         {
            wb_table3_112_272e( false) ;
         }
      }

      protected void wb_table2_75_272( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_etiquetas_Internalname, "", "", "", lblGridsettings_labelgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+"e28271_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WpVisualizarInformacionTarea.htm");
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
            wb_table10_87_272( true) ;
         }
         else
         {
            wb_table10_87_272( false) ;
         }
         return  ;
      }

      protected void wb_table10_87_272e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_etiquetas_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(106), 3, 0)+","+"null"+");", "Save", bttGridsettings_savegrid_etiquetas_Jsonclick, 5, "Save", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID_ETIQUETAS)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpVisualizarInformacionTarea.htm");
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
            wb_table2_75_272e( true) ;
         }
         else
         {
            wb_table2_75_272e( false) ;
         }
      }

      protected void wb_table10_87_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_etiquetas_Internalname, tblGridsettings_tablecontentgrid_etiquetas_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_etiquetas_Internalname, "Rows per page", "", "", lblGridsettings_rowsperpagetextblockgrid_etiquetas_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname, "Grid Settings Rows Per Page_Grid_Etiquetas", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_106_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid_etiquetas, cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_etiquetas_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Rows per page", 1, cmbavGridsettingsrowsperpage_grid_etiquetas.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, "HLP_WpVisualizarInformacionTarea.htm");
            cmbavGridsettingsrowsperpage_grid_etiquetas.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_Grid_Etiquetas), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid_etiquetas.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_87_272e( true) ;
         }
         else
         {
            wb_table10_87_272e( false) ;
         }
      }

      protected void wb_table1_60_272( bool wbgen )
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
            wb_table1_60_272e( true) ;
         }
         else
         {
            wb_table1_60_272e( false) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?2022102021474610", true, true);
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
         context.AddJavascriptSource("wpvisualizarinformaciontarea.js", "?2022102021474610", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1062( )
      {
         edtTrTareasEtiquetas_ID_Internalname = "TRTAREASETIQUETAS_ID_"+sGXsfl_106_idx;
         edtTrTareasEtiquetas_IDEtiqueta_Internalname = "TRTAREASETIQUETAS_IDETIQUETA_"+sGXsfl_106_idx;
         edtTrTareasEtiquetas_NombreEtiqueta_Internalname = "TRTAREASETIQUETAS_NOMBREETIQUETA_"+sGXsfl_106_idx;
      }

      protected void SubsflControlProps_fel_1062( )
      {
         edtTrTareasEtiquetas_ID_Internalname = "TRTAREASETIQUETAS_ID_"+sGXsfl_106_fel_idx;
         edtTrTareasEtiquetas_IDEtiqueta_Internalname = "TRTAREASETIQUETAS_IDETIQUETA_"+sGXsfl_106_fel_idx;
         edtTrTareasEtiquetas_NombreEtiqueta_Internalname = "TRTAREASETIQUETAS_NOMBREETIQUETA_"+sGXsfl_106_fel_idx;
      }

      protected void sendrow_1062( )
      {
         SubsflControlProps_1062( ) ;
         WB270( ) ;
         if ( ( subGrid_etiquetas_Rows * 1 == 0 ) || ( nGXsfl_106_idx <= subGrid_etiquetas_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_106_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_106_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid_etiquetasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_etiquetasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareasEtiquetas_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A51TrTareasEtiquetas_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A51TrTareasEtiquetas_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareasEtiquetas_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_etiquetasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_etiquetasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareasEtiquetas_IDEtiqueta_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareasEtiquetas_IDEtiqueta_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_etiquetasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_etiquetasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareasEtiquetas_NombreEtiqueta_Internalname,StringUtil.RTrim( A54TrTareasEtiquetas_NombreEtiqueta),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareasEtiquetas_NombreEtiqueta_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)256,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            send_integrity_lvl_hashes272( ) ;
            Grid_etiquetasContainer.AddRow(Grid_etiquetasRow);
            nGXsfl_106_idx = ((subGrid_etiquetas_Islastpage==1)&&(nGXsfl_106_idx+1>subGrid_etiquetas_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_idx+1);
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1062( ) ;
         }
         /* End function sendrow_1062 */
      }

      protected void SubsflControlProps_1914( )
      {
         edtTrTareaComentarios_ID_Internalname = "TRTAREACOMENTARIOS_ID_"+sGXsfl_191_idx;
         edtTrTareaComentarios_Descripcion_Internalname = "TRTAREACOMENTARIOS_DESCRIPCION_"+sGXsfl_191_idx;
         edtTrTareaComentarios_FechaCreacion_Internalname = "TRTAREACOMENTARIOS_FECHACREACION_"+sGXsfl_191_idx;
         edtTrTareaComentarios_FechaModificacion_Internalname = "TRTAREACOMENTARIOS_FECHAMODIFICACION_"+sGXsfl_191_idx;
         cmbTrTareaComentarios_Estado_Internalname = "TRTAREACOMENTARIOS_ESTADO_"+sGXsfl_191_idx;
      }

      protected void SubsflControlProps_fel_1914( )
      {
         edtTrTareaComentarios_ID_Internalname = "TRTAREACOMENTARIOS_ID_"+sGXsfl_191_fel_idx;
         edtTrTareaComentarios_Descripcion_Internalname = "TRTAREACOMENTARIOS_DESCRIPCION_"+sGXsfl_191_fel_idx;
         edtTrTareaComentarios_FechaCreacion_Internalname = "TRTAREACOMENTARIOS_FECHACREACION_"+sGXsfl_191_fel_idx;
         edtTrTareaComentarios_FechaModificacion_Internalname = "TRTAREACOMENTARIOS_FECHAMODIFICACION_"+sGXsfl_191_fel_idx;
         cmbTrTareaComentarios_Estado_Internalname = "TRTAREACOMENTARIOS_ESTADO_"+sGXsfl_191_fel_idx;
      }

      protected void sendrow_1914( )
      {
         SubsflControlProps_1914( ) ;
         WB270( ) ;
         if ( ( subGrid_comentarios_Rows * 1 == 0 ) || ( nGXsfl_191_idx <= subGrid_comentarios_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_191_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_191_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_comentariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A35TrTareaComentarios_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A35TrTareaComentarios_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)191,(short)1,(short)-1,(short)0,(bool)false,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_comentariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_Descripcion_Internalname,(String)A36TrTareaComentarios_Descripcion,(String)A36TrTareaComentarios_Descripcion,(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_Descripcion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)191,(short)1,(short)0,(short)-1,(bool)false,(String)"",(String)"left",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_comentariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_FechaCreacion_Internalname,context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"),context.localUtil.Format( A38TrTareaComentarios_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_FechaCreacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)191,(short)1,(short)-1,(short)0,(bool)false,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_comentariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_FechaModificacion_Internalname,context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"),context.localUtil.Format( A39TrTareaComentarios_FechaModificacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_FechaModificacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)191,(short)1,(short)-1,(short)0,(bool)false,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_comentariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTrTareaComentarios_Estado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TRTAREACOMENTARIOS_ESTADO_" + sGXsfl_191_idx;
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
            AssignProp("", false, cmbTrTareaComentarios_Estado_Internalname, "Values", (String)(cmbTrTareaComentarios_Estado.ToJavascriptSource()), !bGXsfl_191_Refreshing);
            send_integrity_lvl_hashes274( ) ;
            Grid_comentariosContainer.AddRow(Grid_comentariosRow);
            nGXsfl_191_idx = ((subGrid_comentarios_Islastpage==1)&&(nGXsfl_191_idx+1>subGrid_comentarios_fnc_Recordsperpage( )) ? 1 : nGXsfl_191_idx+1);
            sGXsfl_191_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_191_idx), 4, 0), 4, "0");
            SubsflControlProps_1914( ) ;
         }
         /* End function sendrow_1914 */
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
         GXCCtl = "TRTAREACOMENTARIOS_ESTADO_" + sGXsfl_191_idx;
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
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTrgestiontareas_nombre_var_lefttext_Internalname = "TRGESTIONTAREAS_NOMBRE_VAR_LEFTTEXT";
         edtavTrgestiontareas_nombre_Internalname = "vTRGESTIONTAREAS_NOMBRE";
         divTable_container_trgestiontareas_nombrefieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_NOMBREFIELDCONTAINER";
         divTable_container_trgestiontareas_nombre_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_NOMBRE";
         lblTrgestiontareas_descripcion_var_lefttext_Internalname = "TRGESTIONTAREAS_DESCRIPCION_VAR_LEFTTEXT";
         edtavTrgestiontareas_descripcion_Internalname = "vTRGESTIONTAREAS_DESCRIPCION";
         divTable_container_trgestiontareas_descripcionfieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_DESCRIPCIONFIELDCONTAINER";
         divTable_container_trgestiontareas_descripcion_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_DESCRIPCION";
         lblTrgestiontareas_fechainicio_var_lefttext_Internalname = "TRGESTIONTAREAS_FECHAINICIO_VAR_LEFTTEXT";
         edtavTrgestiontareas_fechainicio_Internalname = "vTRGESTIONTAREAS_FECHAINICIO";
         divTable_container_trgestiontareas_fechainiciofieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAINICIOFIELDCONTAINER";
         divTable_container_trgestiontareas_fechainicio_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAINICIO";
         lblTrgestiontareas_fechafin_var_lefttext_Internalname = "TRGESTIONTAREAS_FECHAFIN_VAR_LEFTTEXT";
         edtavTrgestiontareas_fechafin_Internalname = "vTRGESTIONTAREAS_FECHAFIN";
         divTable_container_trgestiontareas_fechafinfieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAFINFIELDCONTAINER";
         divTable_container_trgestiontareas_fechafin_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_FECHAFIN";
         lblTrgestiontareas_estado_var_lefttext_Internalname = "TRGESTIONTAREAS_ESTADO_VAR_LEFTTEXT";
         cmbavTrgestiontareas_estado_Internalname = "vTRGESTIONTAREAS_ESTADO";
         divTable_container_trgestiontareas_estadofieldcontainer_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_ESTADOFIELDCONTAINER";
         divTable_container_trgestiontareas_estado_Internalname = "TABLE_CONTAINER_TRGESTIONTAREAS_ESTADO";
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
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_etiquetas_Internalname = "GRID_ETIQUETAS";
         subGrid_comentarios_Internalname = "GRID_COMENTARIOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
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
         edtavTrgestiontareas_fechafin_Jsonclick = "";
         edtavTrgestiontareas_fechafin_Enabled = 1;
         edtavTrgestiontareas_fechainicio_Jsonclick = "";
         edtavTrgestiontareas_fechainicio_Enabled = 1;
         edtavTrgestiontareas_descripcion_Enabled = 1;
         edtavTrgestiontareas_nombre_Jsonclick = "";
         edtavTrgestiontareas_nombre_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Visualizar información de la tarea";
         subGrid_comentarios_Rows = 20;
         subGrid_etiquetas_Rows = 20;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGrid_etiquetas_Backcolorstyle',ctrl:'GRID_ETIQUETAS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'subGrid_comentarios_Backcolorstyle',ctrl:'GRID_COMENTARIOS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV15TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV16TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV17TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV18TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV19TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'}]}");
         setEventMetadata("'PAGINGFIRST(GRID_ETIQUETAS)'","{handler:'E11272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGFIRST(GRID_ETIQUETAS)'",",oparms:[{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("GRID_ETIQUETAS.REFRESH","{handler:'E23272',iparms:[{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("GRID_ETIQUETAS.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_etiquetas_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_ETIQUETAS',prop:'Visible'},{av:'subGrid_etiquetas_Backcolorstyle',ctrl:'GRID_ETIQUETAS',prop:'Backcolorstyle'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("GRID_ETIQUETAS.LOAD","{handler:'E24272',iparms:[]");
         setEventMetadata("GRID_ETIQUETAS.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_etiquetas_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGLAST(GRID_ETIQUETAS)'","{handler:'E12272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGLAST(GRID_ETIQUETAS)'",",oparms:[{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID_ETIQUETAS)'","{handler:'E13272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRID_ETIQUETAS)'",",oparms:[{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID_ETIQUETAS)'","{handler:'E14272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID_ETIQUETAS)'",",oparms:[{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_ETIQUETAS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_etiquetas_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_ETIQUETAS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_ETIQUETAS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_etiquetas_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_ETIQUETAS)'","{handler:'E28271',iparms:[{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_ETIQUETAS)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_ETIQUETAS)'","{handler:'E15272',iparms:[{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid_etiquetas'},{av:'AV47GridSettingsRowsPerPage_Grid_Etiquetas',fld:'vGRIDSETTINGSROWSPERPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV45RowsPerPage_Grid_Etiquetas',fld:'vROWSPERPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_ETIQUETAS)'",",oparms:[{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'},{av:'AV45RowsPerPage_Grid_Etiquetas',fld:'vROWSPERPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'},{av:'subGrid_etiquetas_Backcolorstyle',ctrl:'GRID_ETIQUETAS',prop:'Backcolorstyle'},{av:'subGrid_comentarios_Backcolorstyle',ctrl:'GRID_COMENTARIOS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV15TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV16TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV17TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV18TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV19TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'}]}");
         setEventMetadata("'PAGINGFIRST(GRID_COMENTARIOS)'","{handler:'E16272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGFIRST(GRID_COMENTARIOS)'",",oparms:[{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("GRID_COMENTARIOS.REFRESH","{handler:'E25272',iparms:[{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("GRID_COMENTARIOS.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_comentarios_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_COMENTARIOS',prop:'Visible'},{av:'subGrid_comentarios_Backcolorstyle',ctrl:'GRID_COMENTARIOS',prop:'Backcolorstyle'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("GRID_COMENTARIOS.LOAD","{handler:'E26274',iparms:[]");
         setEventMetadata("GRID_COMENTARIOS.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_comentarios_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID_COMENTARIOS)'","{handler:'E17272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRID_COMENTARIOS)'",",oparms:[{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID_COMENTARIOS)'","{handler:'E18272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID_COMENTARIOS)'",",oparms:[{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_COMENTARIOS)'","{handler:'E27271',iparms:[{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_COMENTARIOS)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_COMENTARIOS)'","{handler:'E19272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid_comentarios'},{av:'AV42GridSettingsRowsPerPage_Grid_Comentarios',fld:'vGRIDSETTINGSROWSPERPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV40RowsPerPage_Grid_Comentarios',fld:'vROWSPERPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'GRID_ETIQUETAS_nFirstRecordOnPage'},{av:'GRID_ETIQUETAS_nEOF'},{av:'subGrid_etiquetas_Rows',ctrl:'GRID_ETIQUETAS',prop:'Rows'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_COMENTARIOS)'",",oparms:[{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV40RowsPerPage_Grid_Comentarios',fld:'vROWSPERPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_comentarios_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_COMENTARIOS',prop:'Visible'},{av:'subGrid_etiquetas_Backcolorstyle',ctrl:'GRID_ETIQUETAS',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_etiquetas_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_ETIQUETAS',prop:'Visible'},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'subGrid_comentarios_Backcolorstyle',ctrl:'GRID_COMENTARIOS',prop:'Backcolorstyle'},{av:'AV15TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV16TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV17TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV18TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV19TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'}]}");
         setEventMetadata("'PAGINGLAST(GRID_COMENTARIOS)'","{handler:'E20272',iparms:[{av:'GRID_COMENTARIOS_nFirstRecordOnPage'},{av:'GRID_COMENTARIOS_nEOF'},{av:'subGrid_comentarios_Rows',ctrl:'GRID_COMENTARIOS',prop:'Rows'},{av:'AV26TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV43CurrentPage_Grid_Etiquetas',fld:'vCURRENTPAGE_GRID_ETIQUETAS',pic:'ZZZ9'},{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGLAST(GRID_COMENTARIOS)'",",oparms:[{av:'AV35CurrentPage_Grid_Comentarios',fld:'vCURRENTPAGE_GRID_COMENTARIOS',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_COMENTARIOS',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_comentarios_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_COMENTARIOS',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_comentarios_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_COMENTARIOS',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_comentarios_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_COMENTARIOS',prop:'Visible'}]}");
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
         AV53Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
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
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
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
         H00274_AGRID_ETIQUETAS_nRecordCount = new long[1] ;
         H00275_AGRID_COMENTARIOS_nRecordCount = new long[1] ;
         H00276_A12TrGestionTareas_ID = new long[1] ;
         H00276_A13TrGestionTareas_Nombre = new String[] {""} ;
         H00276_n13TrGestionTareas_Nombre = new bool[] {false} ;
         H00276_A14TrGestionTareas_Descripcion = new String[] {""} ;
         H00276_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         H00276_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00276_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         H00276_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H00276_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         H00276_A24TrGestionTareas_Estado = new short[1] ;
         H00276_n24TrGestionTareas_Estado = new bool[] {false} ;
         Grid_etiquetasRow = new GXWebRow();
         AV12GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         Grid_comentariosRow = new GXWebRow();
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
               H00274_AGRID_ETIQUETAS_nRecordCount
               }
               , new Object[] {
               H00275_AGRID_COMENTARIOS_nRecordCount
               }
               , new Object[] {
               H00276_A12TrGestionTareas_ID, H00276_A13TrGestionTareas_Nombre, H00276_n13TrGestionTareas_Nombre, H00276_A14TrGestionTareas_Descripcion, H00276_n14TrGestionTareas_Descripcion, H00276_A15TrGestionTareas_FechaInicio, H00276_n15TrGestionTareas_FechaInicio, H00276_A16TrGestionTareas_FechaFin, H00276_n16TrGestionTareas_FechaFin, H00276_A24TrGestionTareas_Estado,
               H00276_n24TrGestionTareas_Estado
               }
            }
         );
         AV53Pgmname = "WpVisualizarInformacionTarea";
         /* GeneXus formulas. */
         AV53Pgmname = "WpVisualizarInformacionTarea";
         context.Gx_err = 0;
         edtavTrgestiontareas_nombre_Enabled = 0;
         edtavTrgestiontareas_descripcion_Enabled = 0;
         edtavTrgestiontareas_fechainicio_Enabled = 0;
         edtavTrgestiontareas_fechafin_Enabled = 0;
         cmbavTrgestiontareas_estado.Enabled = 0;
      }

      private short GRID_ETIQUETAS_nEOF ;
      private short GRID_COMENTARIOS_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV35CurrentPage_Grid_Comentarios ;
      private short A24TrGestionTareas_Estado ;
      private short AV43CurrentPage_Grid_Etiquetas ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV45RowsPerPage_Grid_Etiquetas ;
      private short AV40RowsPerPage_Grid_Comentarios ;
      private short wbEnd ;
      private short wbStart ;
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
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV47GridSettingsRowsPerPage_Grid_Etiquetas ;
      private short AV42GridSettingsRowsPerPage_Grid_Comentarios ;
      private short AV48PageCount_Grid_Etiquetas ;
      private short AV49PageCount_Grid_Comentarios ;
      private short nGXWrapped ;
      private short subGrid_etiquetas_Backstyle ;
      private short subGrid_comentarios_Backstyle ;
      private int divGridsettings_contentoutertablegrid_etiquetas_Visible ;
      private int divGridsettings_contentoutertablegrid_comentarios_Visible ;
      private int nRC_GXsfl_106 ;
      private int nRC_GXsfl_191 ;
      private int nGXsfl_106_idx=1 ;
      private int subGrid_etiquetas_Rows ;
      private int nGXsfl_191_idx=1 ;
      private int subGrid_comentarios_Rows ;
      private int edtavTrgestiontareas_nombre_Enabled ;
      private int edtavTrgestiontareas_descripcion_Enabled ;
      private int edtavTrgestiontareas_fechainicio_Enabled ;
      private int edtavTrgestiontareas_fechafin_Enabled ;
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
      private int subGrid_etiquetas_Islastpage ;
      private int subGrid_comentarios_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingFrom4 ;
      private int GXPagingTo4 ;
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
      private int idxLst ;
      private int subGrid_etiquetas_Backcolor ;
      private int subGrid_comentarios_Backcolor ;
      private long AV26TrGestionTareas_ID ;
      private long wcpOAV26TrGestionTareas_ID ;
      private long GRID_ETIQUETAS_nFirstRecordOnPage ;
      private long GRID_COMENTARIOS_nFirstRecordOnPage ;
      private long A12TrGestionTareas_ID ;
      private long A51TrTareasEtiquetas_ID ;
      private long A53TrTareasEtiquetas_IDEtiqueta ;
      private long A35TrTareaComentarios_ID ;
      private long GRID_ETIQUETAS_nCurrentRecord ;
      private long GRID_COMENTARIOS_nCurrentRecord ;
      private long A52TrTareasEtiquetas_TareaID ;
      private long A34TrTareaComentarios_IDTarea ;
      private long GRID_ETIQUETAS_nRecordCount ;
      private long GRID_COMENTARIOS_nRecordCount ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_106_idx="0001" ;
      private String A13TrGestionTareas_Nombre ;
      private String AV53Pgmname ;
      private String sGXsfl_191_idx="0001" ;
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
      private String divTable_container_trgestiontareas_nombre_Internalname ;
      private String divTable_container_trgestiontareas_nombrefieldcontainer_Internalname ;
      private String lblTrgestiontareas_nombre_var_lefttext_Internalname ;
      private String lblTrgestiontareas_nombre_var_lefttext_Jsonclick ;
      private String TempTags ;
      private String edtavTrgestiontareas_nombre_Internalname ;
      private String AV15TrGestionTareas_Nombre ;
      private String edtavTrgestiontareas_nombre_Jsonclick ;
      private String divTable_container_trgestiontareas_descripcion_Internalname ;
      private String divTable_container_trgestiontareas_descripcionfieldcontainer_Internalname ;
      private String lblTrgestiontareas_descripcion_var_lefttext_Internalname ;
      private String lblTrgestiontareas_descripcion_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_descripcion_Internalname ;
      private String divTable_container_trgestiontareas_fechainicio_Internalname ;
      private String divTable_container_trgestiontareas_fechainiciofieldcontainer_Internalname ;
      private String lblTrgestiontareas_fechainicio_var_lefttext_Internalname ;
      private String lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_fechainicio_Internalname ;
      private String edtavTrgestiontareas_fechainicio_Jsonclick ;
      private String divTable_container_trgestiontareas_fechafin_Internalname ;
      private String divTable_container_trgestiontareas_fechafinfieldcontainer_Internalname ;
      private String lblTrgestiontareas_fechafin_var_lefttext_Internalname ;
      private String lblTrgestiontareas_fechafin_var_lefttext_Jsonclick ;
      private String edtavTrgestiontareas_fechafin_Internalname ;
      private String edtavTrgestiontareas_fechafin_Jsonclick ;
      private String divTable_container_trgestiontareas_estado_Internalname ;
      private String divTable_container_trgestiontareas_estadofieldcontainer_Internalname ;
      private String lblTrgestiontareas_estado_var_lefttext_Internalname ;
      private String lblTrgestiontareas_estado_var_lefttext_Jsonclick ;
      private String cmbavTrgestiontareas_estado_Internalname ;
      private String cmbavTrgestiontareas_estado_Jsonclick ;
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
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtTrTareasEtiquetas_ID_Internalname ;
      private String edtTrTareasEtiquetas_IDEtiqueta_Internalname ;
      private String edtTrTareasEtiquetas_NombreEtiqueta_Internalname ;
      private String edtTrTareaComentarios_ID_Internalname ;
      private String edtTrTareaComentarios_Descripcion_Internalname ;
      private String edtTrTareaComentarios_FechaCreacion_Internalname ;
      private String edtTrTareaComentarios_FechaModificacion_Internalname ;
      private String cmbTrTareaComentarios_Estado_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_etiquetas_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_comentarios_Internalname ;
      private String scmdbuf ;
      private String divGridsettings_contentoutertablegrid_etiquetas_Internalname ;
      private String divGridsettings_contentoutertablegrid_comentarios_Internalname ;
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
      private String sGXsfl_106_fel_idx="0001" ;
      private String ROClassString ;
      private String edtTrTareasEtiquetas_ID_Jsonclick ;
      private String edtTrTareasEtiquetas_IDEtiqueta_Jsonclick ;
      private String edtTrTareasEtiquetas_NombreEtiqueta_Jsonclick ;
      private String sGXsfl_191_fel_idx="0001" ;
      private String edtTrTareaComentarios_ID_Jsonclick ;
      private String edtTrTareaComentarios_Descripcion_Jsonclick ;
      private String edtTrTareaComentarios_FechaCreacion_Jsonclick ;
      private String edtTrTareaComentarios_FechaModificacion_Jsonclick ;
      private String GXCCtl ;
      private String cmbTrTareaComentarios_Estado_Jsonclick ;
      private DateTime A15TrGestionTareas_FechaInicio ;
      private DateTime A16TrGestionTareas_FechaFin ;
      private DateTime AV17TrGestionTareas_FechaInicio ;
      private DateTime AV18TrGestionTareas_FechaFin ;
      private DateTime A38TrTareaComentarios_FechaCreacion ;
      private DateTime A39TrTareaComentarios_FechaModificacion ;
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
      private bool n36TrTareaComentarios_Descripcion ;
      private bool n38TrTareaComentarios_FechaCreacion ;
      private bool n39TrTareaComentarios_FechaModificacion ;
      private bool n37TrTareaComentarios_Estado ;
      private bool bGXsfl_106_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_191_Refreshing=false ;
      private bool n34TrTareaComentarios_IDTarea ;
      private bool returnInSub ;
      private bool AV46RowsPerPageLoaded_Grid_Etiquetas ;
      private bool AV41RowsPerPageLoaded_Grid_Comentarios ;
      private bool gx_refresh_fired ;
      private String A14TrGestionTareas_Descripcion ;
      private String AV16TrGestionTareas_Descripcion ;
      private String A36TrTareaComentarios_Descripcion ;
      private String AV12GridStateKey ;
      private GXWebGrid Grid_etiquetasContainer ;
      private GXWebGrid Grid_comentariosContainer ;
      private GXWebRow Grid_etiquetasRow ;
      private GXWebRow Grid_comentariosRow ;
      private GXWebColumn Grid_etiquetasColumn ;
      private GXWebColumn Grid_comentariosColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTrgestiontareas_estado ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid_etiquetas ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid_comentarios ;
      private GXCombobox cmbTrTareaComentarios_Estado ;
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
      private long[] H00274_AGRID_ETIQUETAS_nRecordCount ;
      private long[] H00275_AGRID_COMENTARIOS_nRecordCount ;
      private long[] H00276_A12TrGestionTareas_ID ;
      private String[] H00276_A13TrGestionTareas_Nombre ;
      private bool[] H00276_n13TrGestionTareas_Nombre ;
      private String[] H00276_A14TrGestionTareas_Descripcion ;
      private bool[] H00276_n14TrGestionTareas_Descripcion ;
      private DateTime[] H00276_A15TrGestionTareas_FechaInicio ;
      private bool[] H00276_n15TrGestionTareas_FechaInicio ;
      private DateTime[] H00276_A16TrGestionTareas_FechaFin ;
      private bool[] H00276_n16TrGestionTareas_FechaFin ;
      private short[] H00276_A24TrGestionTareas_Estado ;
      private bool[] H00276_n24TrGestionTareas_Estado ;
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
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmH00275 ;
          prmH00275 = new Object[] {
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmH00276 ;
          prmH00276 = new Object[] {
          new Object[] {"@AV26TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00272", "SELECT T1.[TrTareasEtiquetas_TareaID], T2.[TrEtiquetas_Nombre] AS TrTareasEtiquetas_NombreEtiqueta, T1.[TrTareasEtiquetas_IDEtiqueta] AS TrTareasEtiquetas_IDEtiqueta, T1.[TrTareasEtiquetas_ID] FROM (TABLERO.[TrTareasEtiquetas] T1 INNER JOIN TABLERO.[TrEtiquetas] T2 ON T2.[TrEtiquetas_ID] = T1.[TrTareasEtiquetas_IDEtiqueta]) WHERE T1.[TrTareasEtiquetas_TareaID] = @AV26TrGestionTareas_ID ORDER BY T1.[TrTareasEtiquetas_TareaID]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00272,21, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00273", "SELECT [TrTareaComentarios_IDTarea], [TrTareaComentarios_Estado], [TrTareaComentarios_FechaModificacion], [TrTareaComentarios_FechaCreacion], [TrTareaComentarios_Descripcion], [TrTareaComentarios_ID] FROM TABLERO.[TrTareaComentarios] WHERE [TrTareaComentarios_IDTarea] = @AV26TrGestionTareas_ID ORDER BY [TrTareaComentarios_IDTarea]  OFFSET @GXPagingFrom4 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo4 > 0 THEN @GXPagingTo4 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00273,21, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00274", "SELECT COUNT(*) FROM (TABLERO.[TrTareasEtiquetas] T1 INNER JOIN TABLERO.[TrEtiquetas] T2 ON T2.[TrEtiquetas_ID] = T1.[TrTareasEtiquetas_IDEtiqueta]) WHERE T1.[TrTareasEtiquetas_TareaID] = @AV26TrGestionTareas_ID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00274,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00275", "SELECT COUNT(*) FROM TABLERO.[TrTareaComentarios] WHERE [TrTareaComentarios_IDTarea] = @AV26TrGestionTareas_ID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00275,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00276", "SELECT [TrGestionTareas_ID], [TrGestionTareas_Nombre], [TrGestionTareas_Descripcion], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_Estado] FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @AV26TrGestionTareas_ID ORDER BY [TrGestionTareas_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00276,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 4 :
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
                return;
             case 3 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
       }
    }

 }

}
