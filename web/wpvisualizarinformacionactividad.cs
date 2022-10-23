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
   public class wpvisualizarinformacionactividad : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpvisualizarinformacionactividad( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpvisualizarinformacionactividad( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_TrActividades_ID ,
                           long aP1_TrActividades_IDTarea )
      {
         this.AV12TrActividades_ID = aP0_TrActividades_ID;
         this.AV13TrActividades_IDTarea = aP1_TrActividades_IDTarea;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTractividades_estado = new GXCombobox();
         cmbavGridsettingsrowsperpage_grid_listaactividades = new GXCombobox();
         cmbTrListaActividad_Estado = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid_listaactividades") == 0 )
            {
               nRC_GXsfl_113 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_113_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_113_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_listaactividades_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid_listaactividades") == 0 )
            {
               subGrid_listaactividades_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV12TrActividades_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               A25TrActividades_IDTarea = (long)(NumberUtil.Val( GetNextPar( ), "."));
               n25TrActividades_IDTarea = false;
               AV13TrActividades_IDTarea = (long)(NumberUtil.Val( GetNextPar( ), "."));
               A27TrActividades_Nombre = GetNextPar( );
               n27TrActividades_Nombre = false;
               A28TrActividades_Descripcion = GetNextPar( );
               n28TrActividades_Descripcion = false;
               A29TrActividades_FechaInicio = context.localUtil.ParseDateParm( GetNextPar( ));
               n29TrActividades_FechaInicio = false;
               A30TrActividades_FechaFin = context.localUtil.ParseDateParm( GetNextPar( ));
               n30TrActividades_FechaFin = false;
               A31TrActividades_FechaCreacion = context.localUtil.ParseDateParm( GetNextPar( ));
               n31TrActividades_FechaCreacion = false;
               A33TrActividades_Estado = (short)(NumberUtil.Val( GetNextPar( ), "."));
               n33TrActividades_Estado = false;
               AV41Pgmname = GetNextPar( );
               AV22CurrentPage_Grid_ListaActividades = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_listaactividades_refresh( subGrid_listaactividades_Rows, AV12TrActividades_ID, A25TrActividades_IDTarea, AV13TrActividades_IDTarea, A27TrActividades_Nombre, A28TrActividades_Descripcion, A29TrActividades_FechaInicio, A30TrActividades_FechaFin, A31TrActividades_FechaCreacion, A33TrActividades_Estado, AV41Pgmname, AV22CurrentPage_Grid_ListaActividades) ;
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
               AV12TrActividades_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV12TrActividades_ID", StringUtil.LTrimStr( (decimal)(AV12TrActividades_ID), 13, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13TrActividades_IDTarea = (long)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "AV13TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV13TrActividades_IDTarea), 13, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_IDTAREA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9"), context));
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
         PA2D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2D2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211745182", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpvisualizarinformacionactividad.aspx") + "?" + UrlEncode("" +AV12TrActividades_ID) + "," + UrlEncode("" +AV13TrActividades_IDTarea)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_IDTAREA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_113", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_113), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID_LISTAACTIVIDADES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22CurrentPage_Grid_ListaActividades), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_IDTAREA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TrActividades_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_NOMBRE", StringUtil.RTrim( A27TrActividades_Nombre));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_DESCRIPCION", A28TrActividades_Descripcion);
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_FECHAINICIO", context.localUtil.DToC( A29TrActividades_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_FECHAFIN", context.localUtil.DToC( A30TrActividades_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_FECHACREACION", context.localUtil.DToC( A31TrActividades_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33TrActividades_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID_LISTAACTIVIDADES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24RowsPerPage_Grid_ListaActividades), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCONFIRMATIONREQUIRED", AV32ConfirmationRequired);
         GxWebStd.gx_hidden_field( context, "vTRLISTAACTIVIDAD_ID", AV35TrListaActividad_ID.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONACTIVIDADES_SDT", AV36GestionActividades_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONACTIVIDADES_SDT", AV36GestionActividades_SDT);
         }
         GxWebStd.gx_hidden_field( context, "vCONFIRMATIONSUBID", StringUtil.RTrim( AV33ConfirmationSubId));
         GxWebStd.gx_hidden_field( context, "vGRIDKEY_TRLISTAACTIVIDAD_ID", AV34GridKey_TrListaActividad_ID.ToString());
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_LISTAACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_LISTAACTIVIDADES_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_listaactividades_Visible), 5, 0, ".", "")));
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
            WE2D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2D2( ) ;
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
         return formatLink("wpvisualizarinformacionactividad.aspx") + "?" + UrlEncode("" +AV12TrActividades_ID) + "," + UrlEncode("" +AV13TrActividades_IDTarea) ;
      }

      public override String GetPgmname( )
      {
         return "WpVisualizarInformacionActividad" ;
      }

      public override String GetPgmdesc( )
      {
         return "Informacion de actividad" ;
      }

      protected void WB2D0( )
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Detalle de actividad", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpVisualizarInformacionActividad.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tractividades_id_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_idfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_id_var_lefttext_Internalname, "ID ACTIVIDAD : ", "", "", lblTractividades_id_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTractividades_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12TrActividades_ID), 13, 0, ".", "")), ((edtavTractividades_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_id_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTractividades_id_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpVisualizarInformacionActividad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_idtarea_var_lefttext_Internalname, "ID Tarea : ", "", "", lblTractividades_idtarea_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTractividades_idtarea_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13TrActividades_IDTarea), 13, 0, ".", "")), ((edtavTractividades_idtarea_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_idtarea_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTractividades_idtarea_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpVisualizarInformacionActividad.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tractividades_nombre_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_nombrefieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_nombre_var_lefttext_Internalname, "Nombre : ", "", "", lblTractividades_nombre_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTractividades_nombre_Internalname, StringUtil.RTrim( AV14TrActividades_Nombre), StringUtil.RTrim( context.localUtil.Format( AV14TrActividades_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTractividades_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpVisualizarInformacionActividad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_descripcion_var_lefttext_Internalname, "Descripción : ", "", "", lblTractividades_descripcion_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_113_idx + "',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTractividades_descripcion_Internalname, AV15TrActividades_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtavTractividades_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpVisualizarInformacionActividad.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tractividades_fechainicio_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tractividades_fechainiciofieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_fechainicio_var_lefttext_Internalname, "Fecha de Inicio : ", "", "", lblTractividades_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_113_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTractividades_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTractividades_fechainicio_Internalname, context.localUtil.Format(AV16TrActividades_FechaInicio, "99/99/9999"), context.localUtil.Format( AV16TrActividades_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTractividades_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpVisualizarInformacionActividad.htm");
            GxWebStd.gx_bitmap( context, edtavTractividades_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTractividades_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTractividades_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_113_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTractividades_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTractividades_fechafin_Internalname, context.localUtil.Format(AV17TrActividades_FechaFin, "99/99/9999"), context.localUtil.Format( AV17TrActividades_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTractividades_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTractividades_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpVisualizarInformacionActividad.htm");
            GxWebStd.gx_bitmap( context, edtavTractividades_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTractividades_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTractividades_estado_var_lefttext_Internalname, "Estado : ", "", "", lblTractividades_estado_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_113_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTractividades_estado, cmbavTractividades_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0)), 1, cmbavTractividades_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTractividades_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, "HLP_WpVisualizarInformacionActividad.htm");
            cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
            AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", (String)(cmbavTractividades_estado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divGridcomponent_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_58_2D2( true) ;
         }
         else
         {
            wb_table1_58_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table1_58_2D2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_73_2D2( true) ;
         }
         else
         {
            wb_table2_73_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table2_73_2D2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section1_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section7_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatLeft", "left", "top", "", "", "div");
            wb_table3_103_2D2( true) ;
         }
         else
         {
            wb_table3_103_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table3_103_2D2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section3_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatRight", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid_listaactividadesContainer.SetWrapped(nGXWrapped);
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid_listaactividadesContainer"+"DivS\" data-gxgridid=\"113\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_listaactividades_Internalname, subGrid_listaactividades_Internalname, "", "Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_listaactividades_Backcolorstyle == 0 )
               {
                  subGrid_listaactividades_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_listaactividades_Class) > 0 )
                  {
                     subGrid_listaactividades_Linesclass = subGrid_listaactividades_Class+"Title";
                  }
               }
               else
               {
                  subGrid_listaactividades_Titlebackstyle = 1;
                  if ( subGrid_listaactividades_Backcolorstyle == 1 )
                  {
                     subGrid_listaactividades_Titlebackcolor = subGrid_listaactividades_Allbackcolor;
                     if ( StringUtil.Len( subGrid_listaactividades_Class) > 0 )
                     {
                        subGrid_listaactividades_Linesclass = subGrid_listaactividades_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_listaactividades_Class) > 0 )
                     {
                        subGrid_listaactividades_Linesclass = subGrid_listaactividades_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Lista Actividad_ID") ;
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
               context.SendWebValue( "Fecha de creación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid_listaactividadesContainer.AddObjectProperty("GridName", "Grid_listaactividades");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid_listaactividadesContainer = new GXWebGrid( context);
               }
               else
               {
                  Grid_listaactividadesContainer.Clear();
               }
               Grid_listaactividadesContainer.SetWrapped(nGXWrapped);
               Grid_listaactividadesContainer.AddObjectProperty("GridName", "Grid_listaactividades");
               Grid_listaactividadesContainer.AddObjectProperty("Header", subGrid_listaactividades_Header);
               Grid_listaactividadesContainer.AddObjectProperty("Class", "Grid_WorkWith");
               Grid_listaactividadesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Backcolorstyle), 1, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Sortable), 1, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("CmpContext", "");
               Grid_listaactividadesContainer.AddObjectProperty("InMasterPage", "false");
               Grid_listaactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_listaactividadesColumn.AddObjectProperty("Value", context.convertURL( AV37Actualizaractividad_Action));
               Grid_listaactividadesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavActualizaractividad_action_Tooltiptext));
               Grid_listaactividadesContainer.AddColumnProperties(Grid_listaactividadesColumn);
               Grid_listaactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_listaactividadesColumn.AddObjectProperty("Value", context.convertURL( AV30EliminarActividad_Action));
               Grid_listaactividadesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavEliminaractividad_action_Tooltiptext));
               Grid_listaactividadesContainer.AddColumnProperties(Grid_listaactividadesColumn);
               Grid_listaactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_listaactividadesColumn.AddObjectProperty("Value", A55TrListaActividad_ID.ToString());
               Grid_listaactividadesContainer.AddColumnProperties(Grid_listaactividadesColumn);
               Grid_listaactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_listaactividadesColumn.AddObjectProperty("Value", StringUtil.RTrim( A56TrListaActividad_Nombre));
               Grid_listaactividadesContainer.AddColumnProperties(Grid_listaactividadesColumn);
               Grid_listaactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_listaactividadesColumn.AddObjectProperty("Value", A57TrListaActividad_Descripcion);
               Grid_listaactividadesContainer.AddColumnProperties(Grid_listaactividadesColumn);
               Grid_listaactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_listaactividadesColumn.AddObjectProperty("Value", context.localUtil.Format(A58TrListaActividad_FechaInicio, "99/99/9999"));
               Grid_listaactividadesContainer.AddColumnProperties(Grid_listaactividadesColumn);
               Grid_listaactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_listaactividadesColumn.AddObjectProperty("Value", context.localUtil.Format(A59TrListaActividad_FechaFin, "99/99/9999"));
               Grid_listaactividadesContainer.AddColumnProperties(Grid_listaactividadesColumn);
               Grid_listaactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_listaactividadesColumn.AddObjectProperty("Value", context.localUtil.Format(A60TrListaActividad_FechaCreacion, "99/99/9999"));
               Grid_listaactividadesContainer.AddColumnProperties(Grid_listaactividadesColumn);
               Grid_listaactividadesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid_listaactividadesColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62TrListaActividad_Estado), 4, 0, ".", "")));
               Grid_listaactividadesContainer.AddColumnProperties(Grid_listaactividadesColumn);
               Grid_listaactividadesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Selectedindex), 4, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Allowselection), 1, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Selectioncolor), 9, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Allowhovering), 1, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Hoveringcolor), 9, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Allowcollapsing), 1, 0, ".", "")));
               Grid_listaactividadesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 113 )
         {
            wbEnd = 0;
            nRC_GXsfl_113 = (int)(nGXsfl_113_idx-1);
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid_listaactividadesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid_listaactividades", Grid_listaactividadesContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid_listaactividadesContainerData", Grid_listaactividadesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid_listaactividadesContainerData"+"V", Grid_listaactividadesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid_listaactividadesContainerData"+"V"+"\" value='"+Grid_listaactividadesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table4_125_2D2( true) ;
         }
         else
         {
            wb_table4_125_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table4_125_2D2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_grid_listaactividades_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            wb_table5_132_2D2( true) ;
         }
         else
         {
            wb_table5_132_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table5_132_2D2e( bool wbgen )
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
            wb_table6_155_2D2( true) ;
         }
         else
         {
            wb_table6_155_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table6_155_2D2e( bool wbgen )
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
         if ( wbEnd == 113 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid_listaactividadesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid_listaactividades", Grid_listaactividadesContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid_listaactividadesContainerData", Grid_listaactividadesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid_listaactividadesContainerData"+"V", Grid_listaactividadesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid_listaactividadesContainerData"+"V"+"\" value='"+Grid_listaactividadesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2D2( )
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
            Form.Meta.addItem("description", "Informacion de actividad", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2D0( ) ;
      }

      protected void WS2D2( )
      {
         START2D2( ) ;
         EVT2D2( ) ;
      }

      protected void EVT2D2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGFIRST(GRID_LISTAACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingFirst(Grid_ListaActividades)' */
                              E112D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGLAST(GRID_LISTAACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingLast(Grid_ListaActividades)' */
                              E122D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGNEXT(GRID_LISTAACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingNext(Grid_ListaActividades)' */
                              E132D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGPREVIOUS(GRID_LISTAACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingPrevious(Grid_ListaActividades)' */
                              E142D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID_LISTAACTIVIDADES)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid_ListaActividades)' */
                              E152D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_AGREGARACTIVIDAD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_AgregarActividad' */
                              E162D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMYES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmYes' */
                              E172D2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 29), "GRID_LISTAACTIVIDADES.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "GRID_LISTAACTIVIDADES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "'E_ELIMINARACTIVIDAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "'E_ACTUALIZARACTIVIDAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "'E_ACTUALIZARACTIVIDAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "'E_ELIMINARACTIVIDAD'") == 0 ) )
                           {
                              nGXsfl_113_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
                              SubsflControlProps_1132( ) ;
                              AV37Actualizaractividad_Action = cgiGet( edtavActualizaractividad_action_Internalname);
                              AssignProp("", false, edtavActualizaractividad_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37Actualizaractividad_Action)) ? AV42Actualizaractividad_action_GXI : context.convertURL( context.PathToRelativeUrl( AV37Actualizaractividad_Action))), !bGXsfl_113_Refreshing);
                              AssignProp("", false, edtavActualizaractividad_action_Internalname, "SrcSet", context.GetImageSrcSet( AV37Actualizaractividad_Action), true);
                              AV30EliminarActividad_Action = cgiGet( edtavEliminaractividad_action_Internalname);
                              AssignProp("", false, edtavEliminaractividad_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV30EliminarActividad_Action)) ? AV43Eliminaractividad_action_GXI : context.convertURL( context.PathToRelativeUrl( AV30EliminarActividad_Action))), !bGXsfl_113_Refreshing);
                              AssignProp("", false, edtavEliminaractividad_action_Internalname, "SrcSet", context.GetImageSrcSet( AV30EliminarActividad_Action), true);
                              A55TrListaActividad_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrListaActividad_ID_Internalname)));
                              A56TrListaActividad_Nombre = cgiGet( edtTrListaActividad_Nombre_Internalname);
                              n56TrListaActividad_Nombre = false;
                              A57TrListaActividad_Descripcion = cgiGet( edtTrListaActividad_Descripcion_Internalname);
                              n57TrListaActividad_Descripcion = false;
                              A58TrListaActividad_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrListaActividad_FechaInicio_Internalname), 0));
                              n58TrListaActividad_FechaInicio = false;
                              A59TrListaActividad_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrListaActividad_FechaFin_Internalname), 0));
                              n59TrListaActividad_FechaFin = false;
                              A60TrListaActividad_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrListaActividad_FechaCreacion_Internalname), 0));
                              n60TrListaActividad_FechaCreacion = false;
                              cmbTrListaActividad_Estado.Name = cmbTrListaActividad_Estado_Internalname;
                              cmbTrListaActividad_Estado.CurrentValue = cgiGet( cmbTrListaActividad_Estado_Internalname);
                              A62TrListaActividad_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrListaActividad_Estado_Internalname), "."));
                              n62TrListaActividad_Estado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E182D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E192D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID_LISTAACTIVIDADES.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E202D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID_LISTAACTIVIDADES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E212D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_ELIMINARACTIVIDAD'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_EliminarActividad' */
                                    E222D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_ACTUALIZARACTIVIDAD'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Actualizaractividad' */
                                    E232D2 ();
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

      protected void WE2D2( )
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

      protected void PA2D2( )
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
               GX_FocusControl = edtavTractividades_nombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_listaactividades_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1132( ) ;
         while ( nGXsfl_113_idx <= nRC_GXsfl_113 )
         {
            sendrow_1132( ) ;
            nGXsfl_113_idx = ((subGrid_listaactividades_Islastpage==1)&&(nGXsfl_113_idx+1>subGrid_listaactividades_fnc_Recordsperpage( )) ? 1 : nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1132( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid_listaactividadesContainer)) ;
         /* End function gxnrGrid_listaactividades_newrow */
      }

      protected void gxgrGrid_listaactividades_refresh( int subGrid_listaactividades_Rows ,
                                                        long AV12TrActividades_ID ,
                                                        long A25TrActividades_IDTarea ,
                                                        long AV13TrActividades_IDTarea ,
                                                        String A27TrActividades_Nombre ,
                                                        String A28TrActividades_Descripcion ,
                                                        DateTime A29TrActividades_FechaInicio ,
                                                        DateTime A30TrActividades_FechaFin ,
                                                        DateTime A31TrActividades_FechaCreacion ,
                                                        short A33TrActividades_Estado ,
                                                        String AV41Pgmname ,
                                                        short AV22CurrentPage_Grid_ListaActividades )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E192D2 ();
         GRID_LISTAACTIVIDADES_nCurrentRecord = 0;
         RF2D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_listaactividades_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRLISTAACTIVIDAD_ID", GetSecureSignedToken( "", A55TrListaActividad_ID, context));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_ID", A55TrListaActividad_ID.ToString());
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
         if ( cmbavTractividades_estado.ItemCount > 0 )
         {
            AV18TrActividades_Estado = (short)(NumberUtil.Val( cmbavTractividades_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV18TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV18TrActividades_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
            AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
         }
         if ( cmbavGridsettingsrowsperpage_grid_listaactividades.ItemCount > 0 )
         {
            AV26GridSettingsRowsPerPage_Grid_ListaActividades = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid_listaactividades.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid_ListaActividades), 4, 0))), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_Grid_ListaActividades), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid_listaactividades.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid_ListaActividades), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_listaactividades_Internalname, "Values", cmbavGridsettingsrowsperpage_grid_listaactividades.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E192D2 ();
         RF2D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV41Pgmname = "WpVisualizarInformacionActividad";
         context.Gx_err = 0;
         edtavTractividades_id_Enabled = 0;
         AssignProp("", false, edtavTractividades_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_id_Enabled), 5, 0), true);
         edtavTractividades_idtarea_Enabled = 0;
         AssignProp("", false, edtavTractividades_idtarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_idtarea_Enabled), 5, 0), true);
         edtavTractividades_nombre_Enabled = 0;
         AssignProp("", false, edtavTractividades_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_nombre_Enabled), 5, 0), true);
         edtavTractividades_descripcion_Enabled = 0;
         AssignProp("", false, edtavTractividades_descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_descripcion_Enabled), 5, 0), true);
         edtavTractividades_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTractividades_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_fechainicio_Enabled), 5, 0), true);
         edtavTractividades_fechafin_Enabled = 0;
         AssignProp("", false, edtavTractividades_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_fechafin_Enabled), 5, 0), true);
         cmbavTractividades_estado.Enabled = 0;
         AssignProp("", false, cmbavTractividades_estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTractividades_estado.Enabled), 5, 0), true);
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void RF2D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid_listaactividadesContainer.ClearRows();
         }
         wbStart = 113;
         E202D2 ();
         nGXsfl_113_idx = 1;
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_1132( ) ;
         bGXsfl_113_Refreshing = true;
         Grid_listaactividadesContainer.AddObjectProperty("GridName", "Grid_listaactividades");
         Grid_listaactividadesContainer.AddObjectProperty("CmpContext", "");
         Grid_listaactividadesContainer.AddObjectProperty("InMasterPage", "false");
         Grid_listaactividadesContainer.AddObjectProperty("Class", "Grid_WorkWith");
         Grid_listaactividadesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid_listaactividadesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid_listaactividadesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Backcolorstyle), 1, 0, ".", "")));
         Grid_listaactividadesContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Sortable), 1, 0, ".", "")));
         Grid_listaactividadesContainer.PageSize = subGrid_listaactividades_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1132( ) ;
            GXPagingFrom2 = (int)(((subGrid_listaactividades_Rows==0) ? 0 : GRID_LISTAACTIVIDADES_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_listaactividades_Rows==0) ? 10000 : subGrid_listaactividades_fnc_Recordsperpage( )+1);
            /* Using cursor H002D2 */
            pr_default.execute(0, new Object[] {AV12TrActividades_ID, GXPagingFrom2, GXPagingTo2});
            nGXsfl_113_idx = 1;
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1132( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_listaactividades_Rows == 0 ) || ( GRID_LISTAACTIVIDADES_nCurrentRecord < subGrid_listaactividades_fnc_Recordsperpage( ) ) ) ) )
            {
               A26TrActividades_ID = H002D2_A26TrActividades_ID[0];
               A62TrListaActividad_Estado = H002D2_A62TrListaActividad_Estado[0];
               n62TrListaActividad_Estado = H002D2_n62TrListaActividad_Estado[0];
               A60TrListaActividad_FechaCreacion = H002D2_A60TrListaActividad_FechaCreacion[0];
               n60TrListaActividad_FechaCreacion = H002D2_n60TrListaActividad_FechaCreacion[0];
               A59TrListaActividad_FechaFin = H002D2_A59TrListaActividad_FechaFin[0];
               n59TrListaActividad_FechaFin = H002D2_n59TrListaActividad_FechaFin[0];
               A58TrListaActividad_FechaInicio = H002D2_A58TrListaActividad_FechaInicio[0];
               n58TrListaActividad_FechaInicio = H002D2_n58TrListaActividad_FechaInicio[0];
               A57TrListaActividad_Descripcion = H002D2_A57TrListaActividad_Descripcion[0];
               n57TrListaActividad_Descripcion = H002D2_n57TrListaActividad_Descripcion[0];
               A56TrListaActividad_Nombre = H002D2_A56TrListaActividad_Nombre[0];
               n56TrListaActividad_Nombre = H002D2_n56TrListaActividad_Nombre[0];
               A55TrListaActividad_ID = (Guid)((Guid)(H002D2_A55TrListaActividad_ID[0]));
               E212D2 ();
               pr_default.readNext(0);
            }
            GRID_LISTAACTIVIDADES_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_LISTAACTIVIDADES_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 113;
            WB2D0( ) ;
         }
         bGXsfl_113_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2D2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TRLISTAACTIVIDAD_ID"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, A55TrListaActividad_ID, context));
      }

      protected int subGrid_listaactividades_fnc_Pagecount( )
      {
         GRID_LISTAACTIVIDADES_nRecordCount = subGrid_listaactividades_fnc_Recordcount( );
         if ( ((int)((GRID_LISTAACTIVIDADES_nRecordCount) % (subGrid_listaactividades_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_LISTAACTIVIDADES_nRecordCount/ (decimal)(subGrid_listaactividades_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_LISTAACTIVIDADES_nRecordCount/ (decimal)(subGrid_listaactividades_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_listaactividades_fnc_Recordcount( )
      {
         /* Using cursor H002D3 */
         pr_default.execute(1, new Object[] {AV12TrActividades_ID});
         GRID_LISTAACTIVIDADES_nRecordCount = H002D3_AGRID_LISTAACTIVIDADES_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_LISTAACTIVIDADES_nRecordCount) ;
      }

      protected int subGrid_listaactividades_fnc_Recordsperpage( )
      {
         if ( subGrid_listaactividades_Rows > 0 )
         {
            return subGrid_listaactividades_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_listaactividades_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_LISTAACTIVIDADES_nFirstRecordOnPage/ (decimal)(subGrid_listaactividades_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_listaactividades_firstpage( )
      {
         GRID_LISTAACTIVIDADES_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_LISTAACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_listaactividades_refresh( subGrid_listaactividades_Rows, AV12TrActividades_ID, A25TrActividades_IDTarea, AV13TrActividades_IDTarea, A27TrActividades_Nombre, A28TrActividades_Descripcion, A29TrActividades_FechaInicio, A30TrActividades_FechaFin, A31TrActividades_FechaCreacion, A33TrActividades_Estado, AV41Pgmname, AV22CurrentPage_Grid_ListaActividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_listaactividades_nextpage( )
      {
         GRID_LISTAACTIVIDADES_nRecordCount = subGrid_listaactividades_fnc_Recordcount( );
         if ( ( GRID_LISTAACTIVIDADES_nRecordCount >= subGrid_listaactividades_fnc_Recordsperpage( ) ) && ( GRID_LISTAACTIVIDADES_nEOF == 0 ) )
         {
            GRID_LISTAACTIVIDADES_nFirstRecordOnPage = (long)(GRID_LISTAACTIVIDADES_nFirstRecordOnPage+subGrid_listaactividades_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_LISTAACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid_listaactividadesContainer.AddObjectProperty("GRID_LISTAACTIVIDADES_nFirstRecordOnPage", GRID_LISTAACTIVIDADES_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_listaactividades_refresh( subGrid_listaactividades_Rows, AV12TrActividades_ID, A25TrActividades_IDTarea, AV13TrActividades_IDTarea, A27TrActividades_Nombre, A28TrActividades_Descripcion, A29TrActividades_FechaInicio, A30TrActividades_FechaFin, A31TrActividades_FechaCreacion, A33TrActividades_Estado, AV41Pgmname, AV22CurrentPage_Grid_ListaActividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_LISTAACTIVIDADES_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_listaactividades_previouspage( )
      {
         if ( GRID_LISTAACTIVIDADES_nFirstRecordOnPage >= subGrid_listaactividades_fnc_Recordsperpage( ) )
         {
            GRID_LISTAACTIVIDADES_nFirstRecordOnPage = (long)(GRID_LISTAACTIVIDADES_nFirstRecordOnPage-subGrid_listaactividades_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_LISTAACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_listaactividades_refresh( subGrid_listaactividades_Rows, AV12TrActividades_ID, A25TrActividades_IDTarea, AV13TrActividades_IDTarea, A27TrActividades_Nombre, A28TrActividades_Descripcion, A29TrActividades_FechaInicio, A30TrActividades_FechaFin, A31TrActividades_FechaCreacion, A33TrActividades_Estado, AV41Pgmname, AV22CurrentPage_Grid_ListaActividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_listaactividades_lastpage( )
      {
         GRID_LISTAACTIVIDADES_nRecordCount = subGrid_listaactividades_fnc_Recordcount( );
         if ( GRID_LISTAACTIVIDADES_nRecordCount > subGrid_listaactividades_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_LISTAACTIVIDADES_nRecordCount) % (subGrid_listaactividades_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_LISTAACTIVIDADES_nFirstRecordOnPage = (long)(GRID_LISTAACTIVIDADES_nRecordCount-subGrid_listaactividades_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_LISTAACTIVIDADES_nFirstRecordOnPage = (long)(GRID_LISTAACTIVIDADES_nRecordCount-((int)((GRID_LISTAACTIVIDADES_nRecordCount) % (subGrid_listaactividades_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_LISTAACTIVIDADES_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_LISTAACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_listaactividades_refresh( subGrid_listaactividades_Rows, AV12TrActividades_ID, A25TrActividades_IDTarea, AV13TrActividades_IDTarea, A27TrActividades_Nombre, A28TrActividades_Descripcion, A29TrActividades_FechaInicio, A30TrActividades_FechaFin, A31TrActividades_FechaCreacion, A33TrActividades_Estado, AV41Pgmname, AV22CurrentPage_Grid_ListaActividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_listaactividades_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_LISTAACTIVIDADES_nFirstRecordOnPage = (long)(subGrid_listaactividades_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_LISTAACTIVIDADES_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_LISTAACTIVIDADES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_listaactividades_refresh( subGrid_listaactividades_Rows, AV12TrActividades_ID, A25TrActividades_IDTarea, AV13TrActividades_IDTarea, A27TrActividades_Nombre, A28TrActividades_Descripcion, A29TrActividades_FechaInicio, A30TrActividades_FechaFin, A31TrActividades_FechaCreacion, A33TrActividades_Estado, AV41Pgmname, AV22CurrentPage_Grid_ListaActividades) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV41Pgmname = "WpVisualizarInformacionActividad";
         context.Gx_err = 0;
         edtavTractividades_id_Enabled = 0;
         AssignProp("", false, edtavTractividades_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_id_Enabled), 5, 0), true);
         edtavTractividades_idtarea_Enabled = 0;
         AssignProp("", false, edtavTractividades_idtarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_idtarea_Enabled), 5, 0), true);
         edtavTractividades_nombre_Enabled = 0;
         AssignProp("", false, edtavTractividades_nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_nombre_Enabled), 5, 0), true);
         edtavTractividades_descripcion_Enabled = 0;
         AssignProp("", false, edtavTractividades_descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_descripcion_Enabled), 5, 0), true);
         edtavTractividades_fechainicio_Enabled = 0;
         AssignProp("", false, edtavTractividades_fechainicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_fechainicio_Enabled), 5, 0), true);
         edtavTractividades_fechafin_Enabled = 0;
         AssignProp("", false, edtavTractividades_fechafin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTractividades_fechafin_Enabled), 5, 0), true);
         cmbavTractividades_estado.Enabled = 0;
         AssignProp("", false, cmbavTractividades_estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTractividades_estado.Enabled), 5, 0), true);
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void STRUP2D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_113 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_113"), ".", ","));
            AV33ConfirmationSubId = cgiGet( "vCONFIRMATIONSUBID");
            GRID_LISTAACTIVIDADES_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_LISTAACTIVIDADES_nFirstRecordOnPage"), ".", ","));
            GRID_LISTAACTIVIDADES_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_LISTAACTIVIDADES_nEOF"), ".", ","));
            subGrid_listaactividades_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_LISTAACTIVIDADES_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV14TrActividades_Nombre = cgiGet( edtavTractividades_nombre_Internalname);
            AssignAttri("", false, "AV14TrActividades_Nombre", AV14TrActividades_Nombre);
            AV15TrActividades_Descripcion = cgiGet( edtavTractividades_descripcion_Internalname);
            AssignAttri("", false, "AV15TrActividades_Descripcion", AV15TrActividades_Descripcion);
            if ( context.localUtil.VCDate( cgiGet( edtavTractividades_fechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Inicio"}), 1, "vTRACTIVIDADES_FECHAINICIO");
               GX_FocusControl = edtavTractividades_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16TrActividades_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV16TrActividades_FechaInicio", context.localUtil.Format(AV16TrActividades_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV16TrActividades_FechaInicio = context.localUtil.CToD( cgiGet( edtavTractividades_fechainicio_Internalname), 2);
               AssignAttri("", false, "AV16TrActividades_FechaInicio", context.localUtil.Format(AV16TrActividades_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTractividades_fechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Fin"}), 1, "vTRACTIVIDADES_FECHAFIN");
               GX_FocusControl = edtavTractividades_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17TrActividades_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV17TrActividades_FechaFin", context.localUtil.Format(AV17TrActividades_FechaFin, "99/99/9999"));
            }
            else
            {
               AV17TrActividades_FechaFin = context.localUtil.CToD( cgiGet( edtavTractividades_fechafin_Internalname), 2);
               AssignAttri("", false, "AV17TrActividades_FechaFin", context.localUtil.Format(AV17TrActividades_FechaFin, "99/99/9999"));
            }
            cmbavTractividades_estado.Name = cmbavTractividades_estado_Internalname;
            cmbavTractividades_estado.CurrentValue = cgiGet( cmbavTractividades_estado_Internalname);
            AV18TrActividades_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTractividades_estado_Internalname), "."));
            AssignAttri("", false, "AV18TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV18TrActividades_Estado), 4, 0));
            cmbavGridsettingsrowsperpage_grid_listaactividades.Name = cmbavGridsettingsrowsperpage_grid_listaactividades_Internalname;
            cmbavGridsettingsrowsperpage_grid_listaactividades.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_listaactividades_Internalname);
            AV26GridSettingsRowsPerPage_Grid_ListaActividades = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_listaactividades_Internalname), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_Grid_ListaActividades), 4, 0));
            AV31ConfirmMessage = cgiGet( edtavConfirmmessage_Internalname);
            AssignAttri("", false, "AV31ConfirmMessage", AV31ConfirmMessage);
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
         /* Using cursor H002D4 */
         pr_default.execute(2, new Object[] {AV12TrActividades_ID, AV13TrActividades_IDTarea});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A25TrActividades_IDTarea = H002D4_A25TrActividades_IDTarea[0];
            n25TrActividades_IDTarea = H002D4_n25TrActividades_IDTarea[0];
            A26TrActividades_ID = H002D4_A26TrActividades_ID[0];
            A27TrActividades_Nombre = H002D4_A27TrActividades_Nombre[0];
            n27TrActividades_Nombre = H002D4_n27TrActividades_Nombre[0];
            A28TrActividades_Descripcion = H002D4_A28TrActividades_Descripcion[0];
            n28TrActividades_Descripcion = H002D4_n28TrActividades_Descripcion[0];
            A29TrActividades_FechaInicio = H002D4_A29TrActividades_FechaInicio[0];
            n29TrActividades_FechaInicio = H002D4_n29TrActividades_FechaInicio[0];
            A30TrActividades_FechaFin = H002D4_A30TrActividades_FechaFin[0];
            n30TrActividades_FechaFin = H002D4_n30TrActividades_FechaFin[0];
            A31TrActividades_FechaCreacion = H002D4_A31TrActividades_FechaCreacion[0];
            n31TrActividades_FechaCreacion = H002D4_n31TrActividades_FechaCreacion[0];
            A33TrActividades_Estado = H002D4_A33TrActividades_Estado[0];
            n33TrActividades_Estado = H002D4_n33TrActividades_Estado[0];
            AV14TrActividades_Nombre = A27TrActividades_Nombre;
            AssignAttri("", false, "AV14TrActividades_Nombre", AV14TrActividades_Nombre);
            AV15TrActividades_Descripcion = A28TrActividades_Descripcion;
            AssignAttri("", false, "AV15TrActividades_Descripcion", AV15TrActividades_Descripcion);
            AV16TrActividades_FechaInicio = A29TrActividades_FechaInicio;
            AssignAttri("", false, "AV16TrActividades_FechaInicio", context.localUtil.Format(AV16TrActividades_FechaInicio, "99/99/9999"));
            AV17TrActividades_FechaFin = A30TrActividades_FechaFin;
            AssignAttri("", false, "AV17TrActividades_FechaFin", context.localUtil.Format(AV17TrActividades_FechaFin, "99/99/9999"));
            AV29TrActividades_FechaCreacion = A31TrActividades_FechaCreacion;
            AV18TrActividades_Estado = A33TrActividades_Estado;
            AssignAttri("", false, "AV18TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV18TrActividades_Estado), 4, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
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
         E182D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182D2( )
      {
         /* Start Routine */
         new k2bloadrowsperpage(context ).execute(  AV41Pgmname,  "Grid_ListaActividades", out  AV24RowsPerPage_Grid_ListaActividades, out  AV25RowsPerPageLoaded_Grid_ListaActividades) ;
         AssignAttri("", false, "AV24RowsPerPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_Grid_ListaActividades), 4, 0));
         if ( ! AV25RowsPerPageLoaded_Grid_ListaActividades )
         {
            AV24RowsPerPage_Grid_ListaActividades = 10;
            AssignAttri("", false, "AV24RowsPerPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_Grid_ListaActividades), 4, 0));
         }
         AV26GridSettingsRowsPerPage_Grid_ListaActividades = AV24RowsPerPage_Grid_ListaActividades;
         AssignAttri("", false, "AV26GridSettingsRowsPerPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_Grid_ListaActividades), 4, 0));
         subGrid_listaactividades_Rows = AV24RowsPerPage_Grid_ListaActividades;
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID_LISTAACTIVIDADES)' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
      }

      protected void E192D2( )
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
         AV32ConfirmationRequired = false;
         AssignAttri("", false, "AV32ConfirmationRequired", AV32ConfirmationRequired);
         subGrid_listaactividades_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_listaactividades_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_listaactividades_Visible), 5, 0), true);
         if ( (0==AV22CurrentPage_Grid_ListaActividades) )
         {
            AV22CurrentPage_Grid_ListaActividades = 1;
            AssignAttri("", false, "AV22CurrentPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV22CurrentPage_Grid_ListaActividades), 4, 0));
         }
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID_LISTAACTIVIDADES)' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
         AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
      }

      protected void S192( )
      {
         /* 'U_LOADROWVARS(GRID_LISTAACTIVIDADES)' Routine */
         AV35TrListaActividad_ID = (Guid)(A55TrListaActividad_ID);
         AssignAttri("", false, "AV35TrListaActividad_ID", AV35TrListaActividad_ID.ToString());
      }

      protected void E112D2( )
      {
         /* 'PagingFirst(Grid_ListaActividades)' Routine */
         subgrid_listaactividades_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_LISTAACTIVIDADES)' */
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
         /* 'UPDATEPAGINGCONTROLS(GRID_LISTAACTIVIDADES)' Routine */
         AV27PageCount_Grid_ListaActividades = (short)(subGrid_listaactividades_fnc_Pagecount( ));
         if ( AV22CurrentPage_Grid_ListaActividades > AV27PageCount_Grid_ListaActividades )
         {
            AV22CurrentPage_Grid_ListaActividades = AV27PageCount_Grid_ListaActividades;
            AssignAttri("", false, "AV22CurrentPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV22CurrentPage_Grid_ListaActividades), 4, 0));
            subgrid_listaactividades_lastpage( ) ;
         }
         if ( AV27PageCount_Grid_ListaActividades == 0 )
         {
            AV22CurrentPage_Grid_ListaActividades = 0;
            AssignAttri("", false, "AV22CurrentPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV22CurrentPage_Grid_ListaActividades), 4, 0));
         }
         else
         {
            AV22CurrentPage_Grid_ListaActividades = (short)(subGrid_listaactividades_fnc_Currentpage( ));
            AssignAttri("", false, "AV22CurrentPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV22CurrentPage_Grid_ListaActividades), 4, 0));
         }
         lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_listaactividades_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption = StringUtil.Str( (decimal)(AV22CurrentPage_Grid_ListaActividades-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_listaactividades_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption = StringUtil.Str( (decimal)(AV22CurrentPage_Grid_ListaActividades), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_listaactividades_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption = StringUtil.Str( (decimal)(AV22CurrentPage_Grid_ListaActividades+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_listaactividades_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption, true);
         lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption = StringUtil.Str( (decimal)(AV27PageCount_Grid_ListaActividades), 10, 0);
         AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_listaactividades_Internalname, "Caption", lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class, true);
         if ( (0==AV22CurrentPage_Grid_ListaActividades) || ( AV22CurrentPage_Grid_ListaActividades <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class, true);
            cellPaginationbar_firstpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_firstpagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_firstpagecellgrid_listaactividades_Class, true);
            lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible), 5, 0), true);
            cellPaginationbar_spacingleftcellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingleftcellgrid_listaactividades_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_listaactividades_Class, true);
            lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible), 5, 0), true);
            cellPaginationbar_previouspagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_previouspagecellgrid_listaactividades_Class, true);
            lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_previouspagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationPrevious";
            AssignProp("", false, cellPaginationbar_previouspagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_previouspagecellgrid_listaactividades_Class, true);
            lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible), 5, 0), true);
            if ( AV22CurrentPage_Grid_ListaActividades == 2 )
            {
               cellPaginationbar_firstpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_firstpagecellgrid_listaactividades_Class, true);
               lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible), 5, 0), true);
               cellPaginationbar_spacingleftcellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingleftcellgrid_listaactividades_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_listaactividades_Class, true);
               lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_firstpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationLeft";
               AssignProp("", false, cellPaginationbar_firstpagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_firstpagecellgrid_listaactividades_Class, true);
               lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible), 5, 0), true);
               if ( AV22CurrentPage_Grid_ListaActividades == 3 )
               {
                  cellPaginationbar_spacingleftcellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_listaactividades_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_listaactividades_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingleftcellgrid_listaactividades_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
                  AssignProp("", false, cellPaginationbar_spacingleftcellgrid_listaactividades_Internalname, "Class", cellPaginationbar_spacingleftcellgrid_listaactividades_Class, true);
                  lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible), 5, 0), true);
               }
            }
         }
         if ( AV22CurrentPage_Grid_ListaActividades == AV27PageCount_Grid_ListaActividades )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class, true);
            cellPaginationbar_lastpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_lastpagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_lastpagecellgrid_listaactividades_Class, true);
            lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible), 5, 0), true);
            cellPaginationbar_spacingrightcellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_spacingrightcellgrid_listaactividades_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_listaactividades_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible), 5, 0), true);
            cellPaginationbar_nextpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_nextpagecellgrid_listaactividades_Class, true);
            lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible), 5, 0), true);
         }
         else
         {
            cellPaginationbar_nextpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationNext";
            AssignProp("", false, cellPaginationbar_nextpagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_nextpagecellgrid_listaactividades_Class, true);
            lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible), 5, 0), true);
            if ( AV22CurrentPage_Grid_ListaActividades == AV27PageCount_Grid_ListaActividades - 1 )
            {
               cellPaginationbar_lastpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_lastpagecellgrid_listaactividades_Class, true);
               lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible = 0;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible), 5, 0), true);
               cellPaginationbar_spacingrightcellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
               AssignProp("", false, cellPaginationbar_spacingrightcellgrid_listaactividades_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_listaactividades_Class, true);
               lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible), 5, 0), true);
            }
            else
            {
               cellPaginationbar_lastpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationRight";
               AssignProp("", false, cellPaginationbar_lastpagecellgrid_listaactividades_Internalname, "Class", cellPaginationbar_lastpagecellgrid_listaactividades_Class, true);
               lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible = 1;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible), 5, 0), true);
               if ( AV22CurrentPage_Grid_ListaActividades == AV27PageCount_Grid_ListaActividades - 2 )
               {
                  cellPaginationbar_spacingrightcellgrid_listaactividades_Class = "K2BToolsCell_PaginationInvisible";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_listaactividades_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_listaactividades_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible), 5, 0), true);
               }
               else
               {
                  cellPaginationbar_spacingrightcellgrid_listaactividades_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
                  AssignProp("", false, cellPaginationbar_spacingrightcellgrid_listaactividades_Internalname, "Class", cellPaginationbar_spacingrightcellgrid_listaactividades_Class, true);
                  lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV22CurrentPage_Grid_ListaActividades <= 1 ) && ( AV27PageCount_Grid_ListaActividades <= 1 ) )
         {
            tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible = 0;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible), 5, 0), true);
         }
         else
         {
            tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible = 1;
            AssignProp("", false, tblPaginationbar_pagingcontainertablegrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible), 5, 0), true);
         }
      }

      protected void S182( )
      {
         /* 'U_GRIDREFRESH(GRID_LISTAACTIVIDADES)' Routine */
      }

      protected void E202D2( )
      {
         /* Grid_listaactividades_Refresh Routine */
         tblI_noresultsfoundtablename_grid_listaactividades_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_listaactividades_Visible), 5, 0), true);
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID_LISTAACTIVIDADES)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_listaactividades_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID_LISTAACTIVIDADES)' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID_LISTAACTIVIDADES)' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_LISTAACTIVIDADES)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      private void E212D2( )
      {
         /* Grid_listaactividades_Load Routine */
         tblI_noresultsfoundtablename_grid_listaactividades_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_listaactividades_Visible), 5, 0), true);
         AV37Actualizaractividad_Action = context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( ));
         AssignAttri("", false, edtavActualizaractividad_action_Internalname, AV37Actualizaractividad_Action);
         AV42Actualizaractividad_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "18c2916e-5fdc-4c1d-9cf4-dd90c6c5abc6", "", context.GetTheme( )));
         edtavActualizaractividad_action_Tooltiptext = "Actualizaractividad";
         AV30EliminarActividad_Action = context.GetImagePath( "4cb13b83-cf55-4682-9d11-58cce2b11e48", "", context.GetTheme( ));
         AssignAttri("", false, edtavEliminaractividad_action_Internalname, AV30EliminarActividad_Action);
         AV43Eliminaractividad_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "4cb13b83-cf55-4682-9d11-58cce2b11e48", "", context.GetTheme( )));
         edtavEliminaractividad_action_Tooltiptext = "Eliminar Actividad";
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_LISTAACTIVIDADES)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 113;
         }
         sendrow_1132( ) ;
         GRID_LISTAACTIVIDADES_nCurrentRecord = (long)(GRID_LISTAACTIVIDADES_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_113_Refreshing )
         {
            context.DoAjaxLoad(113, Grid_listaactividadesRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID_LISTAACTIVIDADES)' Routine */
         AV19GridStateKey = "Grid_ListaActividades";
         new k2bloadgridstate(context ).execute(  AV41Pgmname,  AV19GridStateKey, out  AV20GridState) ;
         AV27PageCount_Grid_ListaActividades = (short)(subGrid_listaactividades_fnc_Pagecount( ));
         if ( ( AV20GridState.gxTpr_Currentpage > 0 ) && ( AV20GridState.gxTpr_Currentpage <= AV27PageCount_Grid_ListaActividades ) )
         {
            AV22CurrentPage_Grid_ListaActividades = AV20GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV22CurrentPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV22CurrentPage_Grid_ListaActividades), 4, 0));
            subgrid_listaactividades_gotopage( AV22CurrentPage_Grid_ListaActividades) ;
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE(GRID_LISTAACTIVIDADES)' Routine */
         AV19GridStateKey = "Grid_ListaActividades";
         new k2bloadgridstate(context ).execute(  AV41Pgmname,  AV19GridStateKey, out  AV20GridState) ;
         AV20GridState.gxTpr_Currentpage = (short)(subGrid_listaactividades_fnc_Currentpage( ));
         AV20GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV41Pgmname,  AV19GridStateKey,  AV20GridState) ;
      }

      protected void E122D2( )
      {
         /* 'PagingLast(Grid_ListaActividades)' Routine */
         subgrid_listaactividades_lastpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_LISTAACTIVIDADES)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E132D2( )
      {
         /* 'PagingNext(Grid_ListaActividades)' Routine */
         subgrid_listaactividades_nextpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_LISTAACTIVIDADES)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E142D2( )
      {
         /* 'PagingPrevious(Grid_ListaActividades)' Routine */
         subgrid_listaactividades_previouspage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID_LISTAACTIVIDADES)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E152D2( )
      {
         /* 'SaveGridSettings(Grid_ListaActividades)' Routine */
         subGrid_listaactividades_Rows = AV26GridSettingsRowsPerPage_Grid_ListaActividades;
         GxWebStd.gx_hidden_field( context, "GRID_LISTAACTIVIDADES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_listaactividades_Rows), 6, 0, ".", "")));
         if ( AV24RowsPerPage_Grid_ListaActividades != AV26GridSettingsRowsPerPage_Grid_ListaActividades )
         {
            AV24RowsPerPage_Grid_ListaActividades = AV26GridSettingsRowsPerPage_Grid_ListaActividades;
            AssignAttri("", false, "AV24RowsPerPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_Grid_ListaActividades), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV41Pgmname,  "Grid_ListaActividades",  AV24RowsPerPage_Grid_ListaActividades) ;
            AV22CurrentPage_Grid_ListaActividades = 1;
            AssignAttri("", false, "AV22CurrentPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV22CurrentPage_Grid_ListaActividades), 4, 0));
            subgrid_listaactividades_firstpage( ) ;
         }
         gxgrGrid_listaactividades_refresh( subGrid_listaactividades_Rows, AV12TrActividades_ID, A25TrActividades_IDTarea, AV13TrActividades_IDTarea, A27TrActividades_Nombre, A28TrActividades_Descripcion, A29TrActividades_FechaInicio, A30TrActividades_FechaFin, A31TrActividades_FechaCreacion, A33TrActividades_Estado, AV41Pgmname, AV22CurrentPage_Grid_ListaActividades) ;
         divGridsettings_contentoutertablegrid_listaactividades_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_listaactividades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_listaactividades_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
         AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
      }

      protected void S252( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID_LISTAACTIVIDADES)' Routine */
         bttAgregaractividad_Visible = 1;
         AssignProp("", false, bttAgregaractividad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAgregaractividad_Visible), 5, 0), true);
      }

      protected void S142( )
      {
         /* 'REFRESHGRIDACTIONS(GRID_LISTAACTIVIDADES)' Routine */
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(GRID_LISTAACTIVIDADES)' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E162D2( )
      {
         /* 'E_AgregarActividad' Routine */
         /* Execute user subroutine: 'U_AGREGARACTIVIDAD' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
         AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
      }

      protected void S202( )
      {
         /* 'U_AGREGARACTIVIDAD' Routine */
         context.PopUp(formatLink("wpagrearactividades.aspx") + "?" + UrlEncode("" +AV12TrActividades_ID), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void E222D2( )
      {
         /* 'E_EliminarActividad' Routine */
         AV31ConfirmMessage = "¿Está seguro?";
         AssignAttri("", false, "AV31ConfirmMessage", AV31ConfirmMessage);
         /* Execute user subroutine: 'U_CONFIRMATIONREQUIRED(ELIMINARACTIVIDAD)' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV32ConfirmationRequired )
         {
            AV33ConfirmationSubId = "'U_EliminarActividad'";
            AssignAttri("", false, "AV33ConfirmationSubId", AV33ConfirmationSubId);
            AV34GridKey_TrListaActividad_ID = (Guid)(A55TrListaActividad_ID);
            AssignAttri("", false, "AV34GridKey_TrListaActividad_ID", AV34GridKey_TrListaActividad_ID.ToString());
            tblTableconditionalconfirm_Visible = 1;
            AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         }
         else
         {
            /* Execute user subroutine: 'U_ELIMINARACTIVIDAD' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36GestionActividades_SDT", AV36GestionActividades_SDT);
         cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
         AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
      }

      protected void S222( )
      {
         /* 'U_ELIMINARACTIVIDAD' Routine */
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_LISTAACTIVIDADES)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV36GestionActividades_SDT.gxTpr_Trlistaactividad_id = (Guid)(AV35TrListaActividad_ID);
         AV36GestionActividades_SDT.gxTpr_Tractividades_id = AV12TrActividades_ID;
         new prgestionaractividades(context ).execute(  AV36GestionActividades_SDT,  "ADE") ;
         context.DoAjaxRefresh();
      }

      protected void E172D2( )
      {
         /* 'ConfirmYes' Routine */
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV33ConfirmationSubId, "'U_EliminarActividad'") == 0 )
         {
            /* Execute user subroutine: 'E_SETROWPOSITION(ELIMINARACTIVIDAD)' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36GestionActividades_SDT", AV36GestionActividades_SDT);
         cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
         AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
      }

      protected void S212( )
      {
         /* 'U_CONFIRMATIONREQUIRED(ELIMINARACTIVIDAD)' Routine */
         AV32ConfirmationRequired = true;
         AssignAttri("", false, "AV32ConfirmationRequired", AV32ConfirmationRequired);
      }

      protected void S232( )
      {
         /* 'E_SETROWPOSITION(ELIMINARACTIVIDAD)' Routine */
         /* Start For Each Line in Grid_listaactividades */
         nRC_GXsfl_113 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_113"), ".", ","));
         nGXsfl_113_fel_idx = 0;
         while ( nGXsfl_113_fel_idx < nRC_GXsfl_113 )
         {
            nGXsfl_113_fel_idx = ((subGrid_listaactividades_Islastpage==1)&&(nGXsfl_113_fel_idx+1>subGrid_listaactividades_fnc_Recordsperpage( )) ? 1 : nGXsfl_113_fel_idx+1);
            sGXsfl_113_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1132( ) ;
            AV37Actualizaractividad_Action = cgiGet( edtavActualizaractividad_action_Internalname);
            AV30EliminarActividad_Action = cgiGet( edtavEliminaractividad_action_Internalname);
            A55TrListaActividad_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrListaActividad_ID_Internalname)));
            A56TrListaActividad_Nombre = cgiGet( edtTrListaActividad_Nombre_Internalname);
            n56TrListaActividad_Nombre = false;
            A57TrListaActividad_Descripcion = cgiGet( edtTrListaActividad_Descripcion_Internalname);
            n57TrListaActividad_Descripcion = false;
            A58TrListaActividad_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrListaActividad_FechaInicio_Internalname), 0));
            n58TrListaActividad_FechaInicio = false;
            A59TrListaActividad_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrListaActividad_FechaFin_Internalname), 0));
            n59TrListaActividad_FechaFin = false;
            A60TrListaActividad_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrListaActividad_FechaCreacion_Internalname), 0));
            n60TrListaActividad_FechaCreacion = false;
            cmbTrListaActividad_Estado.Name = cmbTrListaActividad_Estado_Internalname;
            cmbTrListaActividad_Estado.CurrentValue = cgiGet( cmbTrListaActividad_Estado_Internalname);
            A62TrListaActividad_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrListaActividad_Estado_Internalname), "."));
            n62TrListaActividad_Estado = false;
            if ( A55TrListaActividad_ID == AV34GridKey_TrListaActividad_ID )
            {
               /* Execute user subroutine: 'U_ELIMINARACTIVIDAD' */
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
         if ( nGXsfl_113_fel_idx == 0 )
         {
            nGXsfl_113_idx = 1;
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1132( ) ;
         }
         nGXsfl_113_fel_idx = 1;
      }

      protected void E232D2( )
      {
         /* 'E_Actualizaractividad' Routine */
         /* Execute user subroutine: 'U_ACTUALIZARACTIVIDAD' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavTractividades_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0));
         AssignProp("", false, cmbavTractividades_estado_Internalname, "Values", cmbavTractividades_estado.ToJavascriptSource(), true);
      }

      protected void S242( )
      {
         /* 'U_ACTUALIZARACTIVIDAD' Routine */
         /* Execute user subroutine: 'U_LOADROWVARS(GRID_LISTAACTIVIDADES)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         context.PopUp(formatLink("wpactualizarlistaactividad.aspx") + "?" + UrlEncode(AV35TrListaActividad_ID.ToString()) + "," + UrlEncode("" +AV12TrActividades_ID), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void wb_table6_155_2D2( bool wbgen )
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
            wb_table7_158_2D2( true) ;
         }
         else
         {
            wb_table7_158_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table7_158_2D2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_155_2D2e( true) ;
         }
         else
         {
            wb_table6_155_2D2e( false) ;
         }
      }

      protected void wb_table7_158_2D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSection_condconf_dialog_Internalname, tblSection_condconf_dialog_Internalname, "", "Section_CondConf_Dialog", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table8_161_2D2( true) ;
         }
         else
         {
            wb_table8_161_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table8_161_2D2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_158_2D2e( true) ;
         }
         else
         {
            wb_table7_158_2D2e( false) ;
         }
      }

      protected void wb_table8_161_2D2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfirmmessage_Internalname, StringUtil.RTrim( AV31ConfirmMessage), StringUtil.RTrim( context.localUtil.Format( AV31ConfirmMessage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfirmmessage_Jsonclick, 0, "Attribute_ConditionalConfirm", "", "", "", "", 1, edtavConfirmmessage_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpVisualizarInformacionActividad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table9_168_2D2( true) ;
         }
         else
         {
            wb_table9_168_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table9_168_2D2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_161_2D2e( true) ;
         }
         else
         {
            wb_table8_161_2D2e( false) ;
         }
      }

      protected void wb_table9_168_2D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblConfirm_hidden_actionstable_Internalname, tblConfirm_hidden_actionstable_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction_Confirm";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmyes_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(113), 3, 0)+","+"null"+");", "Aceptar", bttI_buttonconfirmyes_Jsonclick, 5, "Aceptar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMYES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmno_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(113), 3, 0)+","+"null"+");", "Cancelar", bttI_buttonconfirmno_Jsonclick, 7, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e242d1_client"+"'", TempTags, "", 2, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_168_2D2e( true) ;
         }
         else
         {
            wb_table9_168_2D2e( false) ;
         }
      }

      protected void wb_table5_132_2D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblPaginationbar_pagingcontainertablegrid_listaactividades_Internalname, tblPaginationbar_pagingcontainertablegrid_listaactividades_Internalname, "", "K2BToolsTable_PaginationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagebuttoncellgrid_listaactividades_Internalname+"\"  class='K2BToolsCell_PaginationFirst'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Internalname, "&laquo;", "", "", lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID_LISTAACTIVIDADES)\\'."+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class, 5, "", 1, 1, 1, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_firstpagecellgrid_listaactividades_Internalname+"\"  class='"+cellPaginationbar_firstpagecellgrid_listaactividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_listaactividades_Internalname, lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGFIRST(GRID_LISTAACTIVIDADES)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingleftcellgrid_listaactividades_Internalname+"\"  class='"+cellPaginationbar_spacingleftcellgrid_listaactividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_listaactividades_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_previouspagecellgrid_listaactividades_Internalname+"\"  class='"+cellPaginationbar_previouspagecellgrid_listaactividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_listaactividades_Internalname, lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID_LISTAACTIVIDADES)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_currentpagecellgrid_listaactividades_Internalname+"\"  class='K2BToolsCell_PaginationCurrentPage'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_listaactividades_Internalname, lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagecellgrid_listaactividades_Internalname+"\"  class='"+cellPaginationbar_nextpagecellgrid_listaactividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_listaactividades_Internalname, lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID_LISTAACTIVIDADES)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_spacingrightcellgrid_listaactividades_Internalname+"\"  class='"+cellPaginationbar_spacingrightcellgrid_listaactividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_listaactividades_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_lastpagecellgrid_listaactividades_Internalname+"\"  class='"+cellPaginationbar_lastpagecellgrid_listaactividades_Class+"'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_lastpagetextblockgrid_listaactividades_Internalname, lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption, "", "", lblPaginationbar_lastpagetextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGLAST(GRID_LISTAACTIVIDADES)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellPaginationbar_nextpagebuttoncellgrid_listaactividades_Internalname+"\"  class='K2BToolsCell_PaginationLast'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Internalname, "&raquo;", "", "", lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID_LISTAACTIVIDADES)\\'."+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class, 5, "", 1, 1, 1, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_132_2D2e( true) ;
         }
         else
         {
            wb_table5_132_2D2e( false) ;
         }
      }

      protected void wb_table4_125_2D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_listaactividades_Visible == 0 )
            {
               sStyleString = sStyleString + "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_listaactividades_Internalname, tblI_noresultsfoundtablename_grid_listaactividades_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_listaactividades_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_125_2D2e( true) ;
         }
         else
         {
            wb_table4_125_2D2e( false) ;
         }
      }

      protected void wb_table3_103_2D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_grid_listaactividades_gridassociatedleft_Internalname, tblActions_grid_listaactividades_gridassociatedleft_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAgregaractividad_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(113), 3, 0)+","+"null"+");", "Agregar Actividad", bttAgregaractividad_Jsonclick, 5, "", "", StyleString, ClassString, bttAgregaractividad_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_AGREGARACTIVIDAD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_103_2D2e( true) ;
         }
         else
         {
            wb_table3_103_2D2e( false) ;
         }
      }

      protected void wb_table2_73_2D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_grid_listaactividades_Internalname, tblLayoutdefined_table7_grid_listaactividades_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltablegrid_listaactividades_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgrid_listaactividades_Internalname, "", "", "", lblGridsettings_labelgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+"e252d1_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 1, "HLP_WpVisualizarInformacionActividad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegrid_listaactividades_Internalname, divGridsettings_contentoutertablegrid_listaactividades_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table10_85_2D2( true) ;
         }
         else
         {
            wb_table10_85_2D2( false) ;
         }
         return  ;
      }

      protected void wb_table10_85_2D2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_listaactividades_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(113), 3, 0)+","+"null"+");", "Guardar", bttGridsettings_savegrid_listaactividades_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID_LISTAACTIVIDADES)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpVisualizarInformacionActividad.htm");
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
            wb_table2_73_2D2e( true) ;
         }
         else
         {
            wb_table2_73_2D2e( false) ;
         }
      }

      protected void wb_table10_85_2D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgrid_listaactividades_Internalname, tblGridsettings_tablecontentgrid_listaactividades_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgrid_listaactividades_Internalname, "Filas por página", "", "", lblGridsettings_rowsperpagetextblockgrid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_listaactividades_Internalname, "Grid Settings Rows Per Page_Grid_Lista Actividades", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_113_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid_listaactividades, cmbavGridsettingsrowsperpage_grid_listaactividades_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid_ListaActividades), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_listaactividades_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Filas por página", 1, cmbavGridsettingsrowsperpage_grid_listaactividades.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, "HLP_WpVisualizarInformacionActividad.htm");
            cmbavGridsettingsrowsperpage_grid_listaactividades.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid_ListaActividades), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_listaactividades_Internalname, "Values", (String)(cmbavGridsettingsrowsperpage_grid_listaactividades.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_85_2D2e( true) ;
         }
         else
         {
            wb_table10_85_2D2e( false) ;
         }
      }

      protected void wb_table1_58_2D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridtitlecontainertable_grid_listaactividades_Internalname, tblGridtitlecontainertable_grid_listaactividades_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridtitle_grid_listaactividades_Internalname, "Detalle de actividades", "", "", lblGridtitle_grid_listaactividades_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, "HLP_WpVisualizarInformacionActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_58_2D2e( true) ;
         }
         else
         {
            wb_table1_58_2D2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12TrActividades_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12TrActividades_ID", StringUtil.LTrimStr( (decimal)(AV12TrActividades_ID), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
         AV13TrActividades_IDTarea = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV13TrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV13TrActividades_IDTarea), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_IDTAREA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13TrActividades_IDTarea), "ZZZZZZZZZZZZ9"), context));
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
         PA2D2( ) ;
         WS2D2( ) ;
         WE2D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211745470", true, true);
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
         context.AddJavascriptSource("wpvisualizarinformacionactividad.js", "?202210211745470", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1132( )
      {
         edtavActualizaractividad_action_Internalname = "vACTUALIZARACTIVIDAD_ACTION_"+sGXsfl_113_idx;
         edtavEliminaractividad_action_Internalname = "vELIMINARACTIVIDAD_ACTION_"+sGXsfl_113_idx;
         edtTrListaActividad_ID_Internalname = "TRLISTAACTIVIDAD_ID_"+sGXsfl_113_idx;
         edtTrListaActividad_Nombre_Internalname = "TRLISTAACTIVIDAD_NOMBRE_"+sGXsfl_113_idx;
         edtTrListaActividad_Descripcion_Internalname = "TRLISTAACTIVIDAD_DESCRIPCION_"+sGXsfl_113_idx;
         edtTrListaActividad_FechaInicio_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_113_idx;
         edtTrListaActividad_FechaFin_Internalname = "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_113_idx;
         edtTrListaActividad_FechaCreacion_Internalname = "TRLISTAACTIVIDAD_FECHACREACION_"+sGXsfl_113_idx;
         cmbTrListaActividad_Estado_Internalname = "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_113_idx;
      }

      protected void SubsflControlProps_fel_1132( )
      {
         edtavActualizaractividad_action_Internalname = "vACTUALIZARACTIVIDAD_ACTION_"+sGXsfl_113_fel_idx;
         edtavEliminaractividad_action_Internalname = "vELIMINARACTIVIDAD_ACTION_"+sGXsfl_113_fel_idx;
         edtTrListaActividad_ID_Internalname = "TRLISTAACTIVIDAD_ID_"+sGXsfl_113_fel_idx;
         edtTrListaActividad_Nombre_Internalname = "TRLISTAACTIVIDAD_NOMBRE_"+sGXsfl_113_fel_idx;
         edtTrListaActividad_Descripcion_Internalname = "TRLISTAACTIVIDAD_DESCRIPCION_"+sGXsfl_113_fel_idx;
         edtTrListaActividad_FechaInicio_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO_"+sGXsfl_113_fel_idx;
         edtTrListaActividad_FechaFin_Internalname = "TRLISTAACTIVIDAD_FECHAFIN_"+sGXsfl_113_fel_idx;
         edtTrListaActividad_FechaCreacion_Internalname = "TRLISTAACTIVIDAD_FECHACREACION_"+sGXsfl_113_fel_idx;
         cmbTrListaActividad_Estado_Internalname = "TRLISTAACTIVIDAD_ESTADO_"+sGXsfl_113_fel_idx;
      }

      protected void sendrow_1132( )
      {
         SubsflControlProps_1132( ) ;
         WB2D0( ) ;
         if ( ( subGrid_listaactividades_Rows * 1 == 0 ) || ( nGXsfl_113_idx <= subGrid_listaactividades_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid_listaactividadesRow = GXWebRow.GetNew(context,Grid_listaactividadesContainer);
            if ( subGrid_listaactividades_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_listaactividades_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_listaactividades_Class, "") != 0 )
               {
                  subGrid_listaactividades_Linesclass = subGrid_listaactividades_Class+"Odd";
               }
            }
            else if ( subGrid_listaactividades_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_listaactividades_Backstyle = 0;
               subGrid_listaactividades_Backcolor = subGrid_listaactividades_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_listaactividades_Class, "") != 0 )
               {
                  subGrid_listaactividades_Linesclass = subGrid_listaactividades_Class+"Uniform";
               }
            }
            else if ( subGrid_listaactividades_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_listaactividades_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_listaactividades_Class, "") != 0 )
               {
                  subGrid_listaactividades_Linesclass = subGrid_listaactividades_Class+"Odd";
               }
               subGrid_listaactividades_Backcolor = (int)(0x0);
            }
            else if ( subGrid_listaactividades_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_listaactividades_Backstyle = 1;
               if ( ((int)((nGXsfl_113_idx) % (2))) == 0 )
               {
                  subGrid_listaactividades_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_listaactividades_Class, "") != 0 )
                  {
                     subGrid_listaactividades_Linesclass = subGrid_listaactividades_Class+"Even";
                  }
               }
               else
               {
                  subGrid_listaactividades_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_listaactividades_Class, "") != 0 )
                  {
                     subGrid_listaactividades_Linesclass = subGrid_listaactividades_Class+"Odd";
                  }
               }
            }
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"Grid_WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_113_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavActualizaractividad_action_Enabled!=0)&&(edtavActualizaractividad_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 114,'',false,'',113)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV37Actualizaractividad_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV37Actualizaractividad_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV42Actualizaractividad_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV37Actualizaractividad_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37Actualizaractividad_Action)) ? AV42Actualizaractividad_action_GXI : context.PathToRelativeUrl( AV37Actualizaractividad_Action));
            Grid_listaactividadesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavActualizaractividad_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Actualizaractividad",(String)edtavActualizaractividad_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavActualizaractividad_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_ACTUALIZARACTIVIDAD\\'."+sGXsfl_113_idx+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV37Actualizaractividad_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavEliminaractividad_action_Enabled!=0)&&(edtavEliminaractividad_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 115,'',false,'',113)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV30EliminarActividad_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV30EliminarActividad_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV43Eliminaractividad_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV30EliminarActividad_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV30EliminarActividad_Action)) ? AV43Eliminaractividad_action_GXI : context.PathToRelativeUrl( AV30EliminarActividad_Action));
            Grid_listaactividadesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavEliminaractividad_action_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"Eliminar Actividad",(String)edtavEliminaractividad_action_Tooltiptext,(short)0,(short)1,(short)20,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)5,(String)edtavEliminaractividad_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_ELIMINARACTIVIDAD\\'."+sGXsfl_113_idx+"'",(String)StyleString,(String)ClassString,(String)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV30EliminarActividad_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_listaactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_ID_Internalname,A55TrListaActividad_ID.ToString(),A55TrListaActividad_ID.ToString(),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_ID_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)0,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)36,(short)0,(short)0,(short)113,(short)1,(short)0,(short)0,(bool)true,(String)"",(String)"",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_listaactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_Nombre_Internalname,StringUtil.RTrim( A56TrListaActividad_Nombre),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_Nombre_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)100,(short)0,(short)0,(short)113,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_listaactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_Descripcion_Internalname,(String)A57TrListaActividad_Descripcion,(String)A57TrListaActividad_Descripcion,(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_Descripcion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(int)2097152,(short)0,(short)0,(short)113,(short)1,(short)0,(short)-1,(bool)true,(String)"",(String)"left",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_listaactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_FechaInicio_Internalname,context.localUtil.Format(A58TrListaActividad_FechaInicio, "99/99/9999"),context.localUtil.Format( A58TrListaActividad_FechaInicio, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_FechaInicio_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)113,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_listaactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_FechaFin_Internalname,context.localUtil.Format(A59TrListaActividad_FechaFin, "99/99/9999"),context.localUtil.Format( A59TrListaActividad_FechaFin, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_FechaFin_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)113,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            Grid_listaactividadesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrListaActividad_FechaCreacion_Internalname,context.localUtil.Format(A60TrListaActividad_FechaCreacion, "99/99/9999"),context.localUtil.Format( A60TrListaActividad_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrListaActividad_FechaCreacion_Jsonclick,(short)0,(String)"Attribute_Grid",(String)"",(String)ROClassString,(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)113,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid_listaactividadesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTrListaActividad_Estado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TRLISTAACTIVIDAD_ESTADO_" + sGXsfl_113_idx;
               cmbTrListaActividad_Estado.Name = GXCCtl;
               cmbTrListaActividad_Estado.WebTags = "";
               cmbTrListaActividad_Estado.addItem("1", "Nuevo", 0);
               cmbTrListaActividad_Estado.addItem("2", "En Progreso", 0);
               cmbTrListaActividad_Estado.addItem("3", "Completado", 0);
               cmbTrListaActividad_Estado.addItem("4", "Detenido", 0);
               cmbTrListaActividad_Estado.addItem("5", "Pendiente", 0);
               if ( cmbTrListaActividad_Estado.ItemCount > 0 )
               {
                  A62TrListaActividad_Estado = (short)(NumberUtil.Val( cmbTrListaActividad_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0))), "."));
                  n62TrListaActividad_Estado = false;
               }
            }
            /* ComboBox */
            Grid_listaactividadesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTrListaActividad_Estado,(String)cmbTrListaActividad_Estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0)),(short)1,(String)cmbTrListaActividad_Estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"Attribute_Grid",(String)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbTrListaActividad_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0));
            AssignProp("", false, cmbTrListaActividad_Estado_Internalname, "Values", (String)(cmbTrListaActividad_Estado.ToJavascriptSource()), !bGXsfl_113_Refreshing);
            send_integrity_lvl_hashes2D2( ) ;
            Grid_listaactividadesContainer.AddRow(Grid_listaactividadesRow);
            nGXsfl_113_idx = ((subGrid_listaactividades_Islastpage==1)&&(nGXsfl_113_idx+1>subGrid_listaactividades_fnc_Recordsperpage( )) ? 1 : nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1132( ) ;
         }
         /* End function sendrow_1132 */
      }

      protected void init_web_controls( )
      {
         cmbavTractividades_estado.Name = "vTRACTIVIDADES_ESTADO";
         cmbavTractividades_estado.WebTags = "";
         cmbavTractividades_estado.addItem("1", "Nuevo", 0);
         cmbavTractividades_estado.addItem("2", "En Progreso", 0);
         cmbavTractividades_estado.addItem("3", "Completado", 0);
         cmbavTractividades_estado.addItem("4", "Detenido", 0);
         cmbavTractividades_estado.addItem("5", "Pendiente", 0);
         if ( cmbavTractividades_estado.ItemCount > 0 )
         {
            AV18TrActividades_Estado = (short)(NumberUtil.Val( cmbavTractividades_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrActividades_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV18TrActividades_Estado", StringUtil.LTrimStr( (decimal)(AV18TrActividades_Estado), 4, 0));
         }
         cmbavGridsettingsrowsperpage_grid_listaactividades.Name = "vGRIDSETTINGSROWSPERPAGE_GRID_LISTAACTIVIDADES";
         cmbavGridsettingsrowsperpage_grid_listaactividades.WebTags = "";
         cmbavGridsettingsrowsperpage_grid_listaactividades.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid_listaactividades.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid_listaactividades.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid_listaactividades.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid_listaactividades.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid_listaactividades.ItemCount > 0 )
         {
            AV26GridSettingsRowsPerPage_Grid_ListaActividades = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid_listaactividades.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_Grid_ListaActividades), 4, 0))), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_Grid_ListaActividades", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_Grid_ListaActividades), 4, 0));
         }
         GXCCtl = "TRLISTAACTIVIDAD_ESTADO_" + sGXsfl_113_idx;
         cmbTrListaActividad_Estado.Name = GXCCtl;
         cmbTrListaActividad_Estado.WebTags = "";
         cmbTrListaActividad_Estado.addItem("1", "Nuevo", 0);
         cmbTrListaActividad_Estado.addItem("2", "En Progreso", 0);
         cmbTrListaActividad_Estado.addItem("3", "Completado", 0);
         cmbTrListaActividad_Estado.addItem("4", "Detenido", 0);
         cmbTrListaActividad_Estado.addItem("5", "Pendiente", 0);
         if ( cmbTrListaActividad_Estado.ItemCount > 0 )
         {
            A62TrListaActividad_Estado = (short)(NumberUtil.Val( cmbTrListaActividad_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A62TrListaActividad_Estado), 4, 0))), "."));
            n62TrListaActividad_Estado = false;
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTractividades_id_var_lefttext_Internalname = "TRACTIVIDADES_ID_VAR_LEFTTEXT";
         edtavTractividades_id_Internalname = "vTRACTIVIDADES_ID";
         lblTractividades_idtarea_var_lefttext_Internalname = "TRACTIVIDADES_IDTAREA_VAR_LEFTTEXT";
         edtavTractividades_idtarea_Internalname = "vTRACTIVIDADES_IDTAREA";
         divTable_container_tractividades_idfieldcontainer_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_IDFIELDCONTAINER";
         divTable_container_tractividades_id_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_ID";
         lblTractividades_nombre_var_lefttext_Internalname = "TRACTIVIDADES_NOMBRE_VAR_LEFTTEXT";
         edtavTractividades_nombre_Internalname = "vTRACTIVIDADES_NOMBRE";
         lblTractividades_descripcion_var_lefttext_Internalname = "TRACTIVIDADES_DESCRIPCION_VAR_LEFTTEXT";
         edtavTractividades_descripcion_Internalname = "vTRACTIVIDADES_DESCRIPCION";
         divTable_container_tractividades_nombrefieldcontainer_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_NOMBREFIELDCONTAINER";
         divTable_container_tractividades_nombre_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_NOMBRE";
         lblTractividades_fechainicio_var_lefttext_Internalname = "TRACTIVIDADES_FECHAINICIO_VAR_LEFTTEXT";
         edtavTractividades_fechainicio_Internalname = "vTRACTIVIDADES_FECHAINICIO";
         lblTractividades_fechafin_var_lefttext_Internalname = "TRACTIVIDADES_FECHAFIN_VAR_LEFTTEXT";
         edtavTractividades_fechafin_Internalname = "vTRACTIVIDADES_FECHAFIN";
         lblTractividades_estado_var_lefttext_Internalname = "TRACTIVIDADES_ESTADO_VAR_LEFTTEXT";
         cmbavTractividades_estado_Internalname = "vTRACTIVIDADES_ESTADO";
         divTable_container_tractividades_fechainiciofieldcontainer_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_FECHAINICIOFIELDCONTAINER";
         divTable_container_tractividades_fechainicio_Internalname = "TABLE_CONTAINER_TRACTIVIDADES_FECHAINICIO";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         lblGridtitle_grid_listaactividades_Internalname = "GRIDTITLE_GRID_LISTAACTIVIDADES";
         tblGridtitlecontainertable_grid_listaactividades_Internalname = "GRIDTITLECONTAINERTABLE_GRID_LISTAACTIVIDADES";
         lblGridsettings_labelgrid_listaactividades_Internalname = "GRIDSETTINGS_LABELGRID_LISTAACTIVIDADES";
         lblGridsettings_rowsperpagetextblockgrid_listaactividades_Internalname = "GRIDSETTINGS_ROWSPERPAGETEXTBLOCKGRID_LISTAACTIVIDADES";
         cmbavGridsettingsrowsperpage_grid_listaactividades_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID_LISTAACTIVIDADES";
         tblGridsettings_tablecontentgrid_listaactividades_Internalname = "GRIDSETTINGS_TABLECONTENTGRID_LISTAACTIVIDADES";
         bttGridsettings_savegrid_listaactividades_Internalname = "GRIDSETTINGS_SAVEGRID_LISTAACTIVIDADES";
         divGridsettings_contentoutertablegrid_listaactividades_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES";
         divGridsettings_globaltablegrid_listaactividades_Internalname = "GRIDSETTINGS_GLOBALTABLEGRID_LISTAACTIVIDADES";
         tblLayoutdefined_table7_grid_listaactividades_Internalname = "LAYOUTDEFINED_TABLE7_GRID_LISTAACTIVIDADES";
         divLayoutdefined_table10_grid_listaactividades_Internalname = "LAYOUTDEFINED_TABLE10_GRID_LISTAACTIVIDADES";
         bttAgregaractividad_Internalname = "AGREGARACTIVIDAD";
         tblActions_grid_listaactividades_gridassociatedleft_Internalname = "ACTIONS_GRID_LISTAACTIVIDADES_GRIDASSOCIATEDLEFT";
         divLayoutdefined_section7_grid_listaactividades_Internalname = "LAYOUTDEFINED_SECTION7_GRID_LISTAACTIVIDADES";
         divLayoutdefined_section3_grid_listaactividades_Internalname = "LAYOUTDEFINED_SECTION3_GRID_LISTAACTIVIDADES";
         divLayoutdefined_section1_grid_listaactividades_Internalname = "LAYOUTDEFINED_SECTION1_GRID_LISTAACTIVIDADES";
         edtavActualizaractividad_action_Internalname = "vACTUALIZARACTIVIDAD_ACTION";
         edtavEliminaractividad_action_Internalname = "vELIMINARACTIVIDAD_ACTION";
         edtTrListaActividad_ID_Internalname = "TRLISTAACTIVIDAD_ID";
         edtTrListaActividad_Nombre_Internalname = "TRLISTAACTIVIDAD_NOMBRE";
         edtTrListaActividad_Descripcion_Internalname = "TRLISTAACTIVIDAD_DESCRIPCION";
         edtTrListaActividad_FechaInicio_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO";
         edtTrListaActividad_FechaFin_Internalname = "TRLISTAACTIVIDAD_FECHAFIN";
         edtTrListaActividad_FechaCreacion_Internalname = "TRLISTAACTIVIDAD_FECHACREACION";
         cmbTrListaActividad_Estado_Internalname = "TRLISTAACTIVIDAD_ESTADO";
         lblI_noresultsfoundtextblock_grid_listaactividades_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID_LISTAACTIVIDADES";
         tblI_noresultsfoundtablename_grid_listaactividades_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID_LISTAACTIVIDADES";
         divMaingrid_responsivetable_grid_listaactividades_Internalname = "MAINGRID_RESPONSIVETABLE_GRID_LISTAACTIVIDADES";
         lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES";
         cellPaginationbar_previouspagebuttoncellgrid_listaactividades_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONCELLGRID_LISTAACTIVIDADES";
         lblPaginationbar_firstpagetextblockgrid_listaactividades_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES";
         cellPaginationbar_firstpagecellgrid_listaactividades_Internalname = "PAGINATIONBAR_FIRSTPAGECELLGRID_LISTAACTIVIDADES";
         lblPaginationbar_spacinglefttextblockgrid_listaactividades_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_LISTAACTIVIDADES";
         cellPaginationbar_spacingleftcellgrid_listaactividades_Internalname = "PAGINATIONBAR_SPACINGLEFTCELLGRID_LISTAACTIVIDADES";
         lblPaginationbar_previouspagetextblockgrid_listaactividades_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES";
         cellPaginationbar_previouspagecellgrid_listaactividades_Internalname = "PAGINATIONBAR_PREVIOUSPAGECELLGRID_LISTAACTIVIDADES";
         lblPaginationbar_currentpagetextblockgrid_listaactividades_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_LISTAACTIVIDADES";
         cellPaginationbar_currentpagecellgrid_listaactividades_Internalname = "PAGINATIONBAR_CURRENTPAGECELLGRID_LISTAACTIVIDADES";
         lblPaginationbar_nextpagetextblockgrid_listaactividades_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES";
         cellPaginationbar_nextpagecellgrid_listaactividades_Internalname = "PAGINATIONBAR_NEXTPAGECELLGRID_LISTAACTIVIDADES";
         lblPaginationbar_spacingrighttextblockgrid_listaactividades_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_LISTAACTIVIDADES";
         cellPaginationbar_spacingrightcellgrid_listaactividades_Internalname = "PAGINATIONBAR_SPACINGRIGHTCELLGRID_LISTAACTIVIDADES";
         lblPaginationbar_lastpagetextblockgrid_listaactividades_Internalname = "PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES";
         cellPaginationbar_lastpagecellgrid_listaactividades_Internalname = "PAGINATIONBAR_LASTPAGECELLGRID_LISTAACTIVIDADES";
         lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES";
         cellPaginationbar_nextpagebuttoncellgrid_listaactividades_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONCELLGRID_LISTAACTIVIDADES";
         tblPaginationbar_pagingcontainertablegrid_listaactividades_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_LISTAACTIVIDADES";
         divLayoutdefined_section8_grid_listaactividades_Internalname = "LAYOUTDEFINED_SECTION8_GRID_LISTAACTIVIDADES";
         divLayoutdefined_table3_grid_listaactividades_Internalname = "LAYOUTDEFINED_TABLE3_GRID_LISTAACTIVIDADES";
         divLayoutdefined_grid_inner_grid_listaactividades_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID_LISTAACTIVIDADES";
         divGridcomponentcontent_grid_listaactividades_Internalname = "GRIDCOMPONENTCONTENT_GRID_LISTAACTIVIDADES";
         divGridcomponent_grid_listaactividades_Internalname = "GRIDCOMPONENT_GRID_LISTAACTIVIDADES";
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
         subGrid_listaactividades_Internalname = "GRID_LISTAACTIVIDADES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         cmbTrListaActividad_Estado_Jsonclick = "";
         edtTrListaActividad_FechaCreacion_Jsonclick = "";
         edtTrListaActividad_FechaFin_Jsonclick = "";
         edtTrListaActividad_FechaInicio_Jsonclick = "";
         edtTrListaActividad_Descripcion_Jsonclick = "";
         edtTrListaActividad_Nombre_Jsonclick = "";
         edtTrListaActividad_ID_Jsonclick = "";
         edtavEliminaractividad_action_Jsonclick = "";
         edtavEliminaractividad_action_Visible = -1;
         edtavEliminaractividad_action_Enabled = 1;
         edtavActualizaractividad_action_Jsonclick = "";
         edtavActualizaractividad_action_Visible = -1;
         edtavActualizaractividad_action_Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_listaactividades_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid_listaactividades.Enabled = 1;
         divGridsettings_contentoutertablegrid_listaactividades_Visible = 1;
         bttAgregaractividad_Visible = 1;
         lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible = 1;
         lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible = 1;
         lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible = 1;
         edtavConfirmmessage_Jsonclick = "";
         edtavConfirmmessage_Enabled = 1;
         tblI_noresultsfoundtablename_grid_listaactividades_Visible = 1;
         tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible = 1;
         cellPaginationbar_nextpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationNext";
         cellPaginationbar_spacingrightcellgrid_listaactividades_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationRight";
         cellPaginationbar_lastpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationRight";
         cellPaginationbar_previouspagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationPrevious";
         cellPaginationbar_spacingleftcellgrid_listaactividades_Class = "K2BToolsCell_PaginationDisabled K2BToolsCell_PaginationLeft";
         cellPaginationbar_firstpagecellgrid_listaactividades_Class = "K2BToolsCell_PaginationLeft";
         lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption = "1";
         lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption = "#";
         lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption = "#";
         lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption = "1";
         tblTableconditionalconfirm_Visible = 1;
         subGrid_listaactividades_Allowcollapsing = 0;
         subGrid_listaactividades_Allowselection = 0;
         edtavEliminaractividad_action_Tooltiptext = "";
         edtavActualizaractividad_action_Tooltiptext = "";
         subGrid_listaactividades_Sortable = 0;
         subGrid_listaactividades_Header = "";
         subGrid_listaactividades_Class = "Grid_WorkWith";
         subGrid_listaactividades_Backcolorstyle = 0;
         cmbavTractividades_estado_Jsonclick = "";
         cmbavTractividades_estado.Enabled = 1;
         edtavTractividades_fechafin_Jsonclick = "";
         edtavTractividades_fechafin_Enabled = 1;
         edtavTractividades_fechainicio_Jsonclick = "";
         edtavTractividades_fechainicio_Enabled = 1;
         edtavTractividades_descripcion_Enabled = 1;
         edtavTractividades_nombre_Jsonclick = "";
         edtavTractividades_nombre_Enabled = 1;
         edtavTractividades_idtarea_Jsonclick = "";
         edtavTractividades_idtarea_Enabled = 0;
         edtavTractividades_id_Jsonclick = "";
         edtavTractividades_id_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Informacion de actividad";
         subGrid_listaactividades_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV32ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_listaactividades_Backcolorstyle',ctrl:'GRID_LISTAACTIVIDADES',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_listaactividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV14TrActividades_Nombre',fld:'vTRACTIVIDADES_NOMBRE',pic:''},{av:'AV15TrActividades_Descripcion',fld:'vTRACTIVIDADES_DESCRIPCION',pic:''},{av:'AV16TrActividades_FechaInicio',fld:'vTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV17TrActividades_FechaFin',fld:'vTRACTIVIDADES_FECHAFIN',pic:''},{av:'cmbavTractividades_estado'},{av:'AV18TrActividades_Estado',fld:'vTRACTIVIDADES_ESTADO',pic:'ZZZ9'},{ctrl:'AGREGARACTIVIDAD',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID_LISTAACTIVIDADES)'","{handler:'E112D2',iparms:[{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGFIRST(GRID_LISTAACTIVIDADES)'",",oparms:[{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("GRID_LISTAACTIVIDADES.REFRESH","{handler:'E202D2',iparms:[{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("GRID_LISTAACTIVIDADES.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_listaactividades_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_LISTAACTIVIDADES',prop:'Visible'},{av:'subGrid_listaactividades_Backcolorstyle',ctrl:'GRID_LISTAACTIVIDADES',prop:'Backcolorstyle'},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'},{ctrl:'AGREGARACTIVIDAD',prop:'Visible'}]}");
         setEventMetadata("GRID_LISTAACTIVIDADES.LOAD","{handler:'E212D2',iparms:[{av:'A55TrListaActividad_ID',fld:'TRLISTAACTIVIDAD_ID',pic:'',hsh:true}]");
         setEventMetadata("GRID_LISTAACTIVIDADES.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_listaactividades_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID_LISTAACTIVIDADES',prop:'Visible'},{av:'AV37Actualizaractividad_Action',fld:'vACTUALIZARACTIVIDAD_ACTION',pic:''},{av:'edtavActualizaractividad_action_Tooltiptext',ctrl:'vACTUALIZARACTIVIDAD_ACTION',prop:'Tooltiptext'},{av:'AV30EliminarActividad_Action',fld:'vELIMINARACTIVIDAD_ACTION',pic:''},{av:'edtavEliminaractividad_action_Tooltiptext',ctrl:'vELIMINARACTIVIDAD_ACTION',prop:'Tooltiptext'},{av:'AV35TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:''}]}");
         setEventMetadata("'PAGINGLAST(GRID_LISTAACTIVIDADES)'","{handler:'E122D2',iparms:[{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGLAST(GRID_LISTAACTIVIDADES)'",",oparms:[{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID_LISTAACTIVIDADES)'","{handler:'E132D2',iparms:[{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRID_LISTAACTIVIDADES)'",",oparms:[{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID_LISTAACTIVIDADES)'","{handler:'E142D2',iparms:[{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID_LISTAACTIVIDADES)'",",oparms:[{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Class'},{av:'cellPaginationbar_firstpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_FIRSTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingleftcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGLEFTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_previouspagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_lastpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_LASTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_spacingrightcellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_SPACINGRIGHTCELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'cellPaginationbar_nextpagecellgrid_listaactividades_Class',ctrl:'PAGINATIONBAR_NEXTPAGECELLGRID_LISTAACTIVIDADES',prop:'Class'},{av:'lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_LISTAACTIVIDADES)'","{handler:'E252D1',iparms:[{av:'divGridsettings_contentoutertablegrid_listaactividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID_LISTAACTIVIDADES)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_listaactividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_LISTAACTIVIDADES)'","{handler:'E152D2',iparms:[{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid_listaactividades'},{av:'AV26GridSettingsRowsPerPage_Grid_ListaActividades',fld:'vGRIDSETTINGSROWSPERPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV24RowsPerPage_Grid_ListaActividades',fld:'vROWSPERPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID_LISTAACTIVIDADES)'",",oparms:[{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV24RowsPerPage_Grid_ListaActividades',fld:'vROWSPERPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_listaactividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'AV32ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_listaactividades_Backcolorstyle',ctrl:'GRID_LISTAACTIVIDADES',prop:'Backcolorstyle'},{av:'AV14TrActividades_Nombre',fld:'vTRACTIVIDADES_NOMBRE',pic:''},{av:'AV15TrActividades_Descripcion',fld:'vTRACTIVIDADES_DESCRIPCION',pic:''},{av:'AV16TrActividades_FechaInicio',fld:'vTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV17TrActividades_FechaFin',fld:'vTRACTIVIDADES_FECHAFIN',pic:''},{av:'cmbavTractividades_estado'},{av:'AV18TrActividades_Estado',fld:'vTRACTIVIDADES_ESTADO',pic:'ZZZ9'},{ctrl:'AGREGARACTIVIDAD',prop:'Visible'}]}");
         setEventMetadata("'E_AGREGARACTIVIDAD'","{handler:'E162D2',iparms:[{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_AGREGARACTIVIDAD'",",oparms:[{av:'AV32ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_listaactividades_Backcolorstyle',ctrl:'GRID_LISTAACTIVIDADES',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_listaactividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV14TrActividades_Nombre',fld:'vTRACTIVIDADES_NOMBRE',pic:''},{av:'AV15TrActividades_Descripcion',fld:'vTRACTIVIDADES_DESCRIPCION',pic:''},{av:'AV16TrActividades_FechaInicio',fld:'vTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV17TrActividades_FechaFin',fld:'vTRACTIVIDADES_FECHAFIN',pic:''},{av:'cmbavTractividades_estado'},{av:'AV18TrActividades_Estado',fld:'vTRACTIVIDADES_ESTADO',pic:'ZZZ9'},{ctrl:'AGREGARACTIVIDAD',prop:'Visible'}]}");
         setEventMetadata("'E_ELIMINARACTIVIDAD'","{handler:'E222D2',iparms:[{av:'AV32ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'A55TrListaActividad_ID',fld:'TRLISTAACTIVIDAD_ID',pic:'',hsh:true},{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV35TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:''},{av:'AV36GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_ELIMINARACTIVIDAD'",",oparms:[{av:'AV31ConfirmMessage',fld:'vCONFIRMMESSAGE',pic:''},{av:'AV33ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'AV34GridKey_TrListaActividad_ID',fld:'vGRIDKEY_TRLISTAACTIVIDAD_ID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV32ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV36GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''},{av:'AV35TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:''},{av:'subGrid_listaactividades_Backcolorstyle',ctrl:'GRID_LISTAACTIVIDADES',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_listaactividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV14TrActividades_Nombre',fld:'vTRACTIVIDADES_NOMBRE',pic:''},{av:'AV15TrActividades_Descripcion',fld:'vTRACTIVIDADES_DESCRIPCION',pic:''},{av:'AV16TrActividades_FechaInicio',fld:'vTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV17TrActividades_FechaFin',fld:'vTRACTIVIDADES_FECHAFIN',pic:''},{av:'cmbavTractividades_estado'},{av:'AV18TrActividades_Estado',fld:'vTRACTIVIDADES_ESTADO',pic:'ZZZ9'},{ctrl:'AGREGARACTIVIDAD',prop:'Visible'}]}");
         setEventMetadata("'CONFIRMNO'","{handler:'E242D1',iparms:[]");
         setEventMetadata("'CONFIRMNO'",",oparms:[{av:'AV33ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'}]}");
         setEventMetadata("'CONFIRMYES'","{handler:'E172D2',iparms:[{av:'AV33ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'A55TrListaActividad_ID',fld:'TRLISTAACTIVIDAD_ID',grid:113,pic:'',hsh:true},{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'nRC_GXsfl_113',ctrl:'GRID_LISTAACTIVIDADES',grid:113,prop:'GridRC'},{av:'AV34GridKey_TrListaActividad_ID',fld:'vGRIDKEY_TRLISTAACTIVIDAD_ID',pic:''},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV35TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:''},{av:'AV36GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("'CONFIRMYES'",",oparms:[{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV36GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''},{av:'AV35TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:''},{av:'AV32ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_listaactividades_Backcolorstyle',ctrl:'GRID_LISTAACTIVIDADES',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_listaactividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV14TrActividades_Nombre',fld:'vTRACTIVIDADES_NOMBRE',pic:''},{av:'AV15TrActividades_Descripcion',fld:'vTRACTIVIDADES_DESCRIPCION',pic:''},{av:'AV16TrActividades_FechaInicio',fld:'vTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV17TrActividades_FechaFin',fld:'vTRACTIVIDADES_FECHAFIN',pic:''},{av:'cmbavTractividades_estado'},{av:'AV18TrActividades_Estado',fld:'vTRACTIVIDADES_ESTADO',pic:'ZZZ9'},{ctrl:'AGREGARACTIVIDAD',prop:'Visible'}]}");
         setEventMetadata("'E_ACTUALIZARACTIVIDAD'","{handler:'E232D2',iparms:[{av:'GRID_LISTAACTIVIDADES_nFirstRecordOnPage'},{av:'GRID_LISTAACTIVIDADES_nEOF'},{av:'subGrid_listaactividades_Rows',ctrl:'GRID_LISTAACTIVIDADES',prop:'Rows'},{av:'AV12TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A25TrActividades_IDTarea',fld:'TRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV13TrActividades_IDTarea',fld:'vTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'A27TrActividades_Nombre',fld:'TRACTIVIDADES_NOMBRE',pic:''},{av:'A28TrActividades_Descripcion',fld:'TRACTIVIDADES_DESCRIPCION',pic:''},{av:'A29TrActividades_FechaInicio',fld:'TRACTIVIDADES_FECHAINICIO',pic:''},{av:'A30TrActividades_FechaFin',fld:'TRACTIVIDADES_FECHAFIN',pic:''},{av:'A31TrActividades_FechaCreacion',fld:'TRACTIVIDADES_FECHACREACION',pic:''},{av:'A33TrActividades_Estado',fld:'TRACTIVIDADES_ESTADO',pic:'ZZZ9'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV35TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:''},{av:'A55TrListaActividad_ID',fld:'TRLISTAACTIVIDAD_ID',pic:'',hsh:true},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_ACTUALIZARACTIVIDAD'",",oparms:[{av:'AV35TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:''},{av:'AV32ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'subGrid_listaactividades_Backcolorstyle',ctrl:'GRID_LISTAACTIVIDADES',prop:'Backcolorstyle'},{av:'divGridsettings_contentoutertablegrid_listaactividades_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID_LISTAACTIVIDADES',prop:'Visible'},{av:'AV22CurrentPage_Grid_ListaActividades',fld:'vCURRENTPAGE_GRID_LISTAACTIVIDADES',pic:'ZZZ9'},{av:'AV14TrActividades_Nombre',fld:'vTRACTIVIDADES_NOMBRE',pic:''},{av:'AV15TrActividades_Descripcion',fld:'vTRACTIVIDADES_DESCRIPCION',pic:''},{av:'AV16TrActividades_FechaInicio',fld:'vTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV17TrActividades_FechaFin',fld:'vTRACTIVIDADES_FECHAFIN',pic:''},{av:'cmbavTractividades_estado'},{av:'AV18TrActividades_Estado',fld:'vTRACTIVIDADES_ESTADO',pic:'ZZZ9'},{ctrl:'AGREGARACTIVIDAD',prop:'Visible'}]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_ID","{handler:'Validv_Tractividades_id',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_ID",",oparms:[]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAINICIO","{handler:'Validv_Tractividades_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAFIN","{handler:'Validv_Tractividades_fechafin',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_TRACTIVIDADES_ESTADO","{handler:'Validv_Tractividades_estado',iparms:[]");
         setEventMetadata("VALIDV_TRACTIVIDADES_ESTADO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Trlistaactividad_estado',iparms:[]");
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
         A27TrActividades_Nombre = "";
         A28TrActividades_Descripcion = "";
         A29TrActividades_FechaInicio = DateTime.MinValue;
         A30TrActividades_FechaFin = DateTime.MinValue;
         A31TrActividades_FechaCreacion = DateTime.MinValue;
         AV41Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV35TrListaActividad_ID = (Guid)(Guid.Empty);
         AV36GestionActividades_SDT = new SdtGestionActividades_SDT(context);
         AV33ConfirmationSubId = "";
         AV34GridKey_TrListaActividad_ID = (Guid)(Guid.Empty);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTractividades_id_var_lefttext_Jsonclick = "";
         lblTractividades_idtarea_var_lefttext_Jsonclick = "";
         lblTractividades_nombre_var_lefttext_Jsonclick = "";
         TempTags = "";
         AV14TrActividades_Nombre = "";
         lblTractividades_descripcion_var_lefttext_Jsonclick = "";
         AV15TrActividades_Descripcion = "";
         lblTractividades_fechainicio_var_lefttext_Jsonclick = "";
         AV16TrActividades_FechaInicio = DateTime.MinValue;
         lblTractividades_fechafin_var_lefttext_Jsonclick = "";
         AV17TrActividades_FechaFin = DateTime.MinValue;
         lblTractividades_estado_var_lefttext_Jsonclick = "";
         Grid_listaactividadesContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_listaactividades_Linesclass = "";
         Grid_listaactividadesColumn = new GXWebColumn();
         AV37Actualizaractividad_Action = "";
         AV30EliminarActividad_Action = "";
         A55TrListaActividad_ID = (Guid)(Guid.Empty);
         A56TrListaActividad_Nombre = "";
         A57TrListaActividad_Descripcion = "";
         A58TrListaActividad_FechaInicio = DateTime.MinValue;
         A59TrListaActividad_FechaFin = DateTime.MinValue;
         A60TrListaActividad_FechaCreacion = DateTime.MinValue;
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV42Actualizaractividad_action_GXI = "";
         AV43Eliminaractividad_action_GXI = "";
         scmdbuf = "";
         H002D2_A26TrActividades_ID = new long[1] ;
         H002D2_A62TrListaActividad_Estado = new short[1] ;
         H002D2_n62TrListaActividad_Estado = new bool[] {false} ;
         H002D2_A60TrListaActividad_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H002D2_n60TrListaActividad_FechaCreacion = new bool[] {false} ;
         H002D2_A59TrListaActividad_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H002D2_n59TrListaActividad_FechaFin = new bool[] {false} ;
         H002D2_A58TrListaActividad_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H002D2_n58TrListaActividad_FechaInicio = new bool[] {false} ;
         H002D2_A57TrListaActividad_Descripcion = new String[] {""} ;
         H002D2_n57TrListaActividad_Descripcion = new bool[] {false} ;
         H002D2_A56TrListaActividad_Nombre = new String[] {""} ;
         H002D2_n56TrListaActividad_Nombre = new bool[] {false} ;
         H002D2_A55TrListaActividad_ID = new Guid[] {Guid.Empty} ;
         H002D3_AGRID_LISTAACTIVIDADES_nRecordCount = new long[1] ;
         AV31ConfirmMessage = "";
         H002D4_A25TrActividades_IDTarea = new long[1] ;
         H002D4_n25TrActividades_IDTarea = new bool[] {false} ;
         H002D4_A26TrActividades_ID = new long[1] ;
         H002D4_A27TrActividades_Nombre = new String[] {""} ;
         H002D4_n27TrActividades_Nombre = new bool[] {false} ;
         H002D4_A28TrActividades_Descripcion = new String[] {""} ;
         H002D4_n28TrActividades_Descripcion = new bool[] {false} ;
         H002D4_A29TrActividades_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H002D4_n29TrActividades_FechaInicio = new bool[] {false} ;
         H002D4_A30TrActividades_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H002D4_n30TrActividades_FechaFin = new bool[] {false} ;
         H002D4_A31TrActividades_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H002D4_n31TrActividades_FechaCreacion = new bool[] {false} ;
         H002D4_A33TrActividades_Estado = new short[1] ;
         H002D4_n33TrActividades_Estado = new bool[] {false} ;
         AV29TrActividades_FechaCreacion = DateTime.MinValue;
         Grid_listaactividadesRow = new GXWebRow();
         AV19GridStateKey = "";
         AV20GridState = new SdtK2BGridState(context);
         bttI_buttonconfirmyes_Jsonclick = "";
         bttI_buttonconfirmno_Jsonclick = "";
         lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_listaactividades_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_listaactividades_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_listaactividades_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_listaactividades_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_listaactividades_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_listaactividades_Jsonclick = "";
         lblPaginationbar_lastpagetextblockgrid_listaactividades_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Jsonclick = "";
         lblI_noresultsfoundtextblock_grid_listaactividades_Jsonclick = "";
         bttAgregaractividad_Jsonclick = "";
         lblGridsettings_labelgrid_listaactividades_Jsonclick = "";
         bttGridsettings_savegrid_listaactividades_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgrid_listaactividades_Jsonclick = "";
         lblGridtitle_grid_listaactividades_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpvisualizarinformacionactividad__default(),
            new Object[][] {
                new Object[] {
               H002D2_A26TrActividades_ID, H002D2_A62TrListaActividad_Estado, H002D2_n62TrListaActividad_Estado, H002D2_A60TrListaActividad_FechaCreacion, H002D2_n60TrListaActividad_FechaCreacion, H002D2_A59TrListaActividad_FechaFin, H002D2_n59TrListaActividad_FechaFin, H002D2_A58TrListaActividad_FechaInicio, H002D2_n58TrListaActividad_FechaInicio, H002D2_A57TrListaActividad_Descripcion,
               H002D2_n57TrListaActividad_Descripcion, H002D2_A56TrListaActividad_Nombre, H002D2_n56TrListaActividad_Nombre, H002D2_A55TrListaActividad_ID
               }
               , new Object[] {
               H002D3_AGRID_LISTAACTIVIDADES_nRecordCount
               }
               , new Object[] {
               H002D4_A25TrActividades_IDTarea, H002D4_n25TrActividades_IDTarea, H002D4_A26TrActividades_ID, H002D4_A27TrActividades_Nombre, H002D4_n27TrActividades_Nombre, H002D4_A28TrActividades_Descripcion, H002D4_n28TrActividades_Descripcion, H002D4_A29TrActividades_FechaInicio, H002D4_n29TrActividades_FechaInicio, H002D4_A30TrActividades_FechaFin,
               H002D4_n30TrActividades_FechaFin, H002D4_A31TrActividades_FechaCreacion, H002D4_n31TrActividades_FechaCreacion, H002D4_A33TrActividades_Estado, H002D4_n33TrActividades_Estado
               }
            }
         );
         AV41Pgmname = "WpVisualizarInformacionActividad";
         /* GeneXus formulas. */
         AV41Pgmname = "WpVisualizarInformacionActividad";
         context.Gx_err = 0;
         edtavTractividades_id_Enabled = 0;
         edtavTractividades_idtarea_Enabled = 0;
         edtavTractividades_nombre_Enabled = 0;
         edtavTractividades_descripcion_Enabled = 0;
         edtavTractividades_fechainicio_Enabled = 0;
         edtavTractividades_fechafin_Enabled = 0;
         cmbavTractividades_estado.Enabled = 0;
         edtavConfirmmessage_Enabled = 0;
      }

      private short GRID_LISTAACTIVIDADES_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A33TrActividades_Estado ;
      private short AV22CurrentPage_Grid_ListaActividades ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV24RowsPerPage_Grid_ListaActividades ;
      private short wbEnd ;
      private short wbStart ;
      private short AV18TrActividades_Estado ;
      private short subGrid_listaactividades_Backcolorstyle ;
      private short subGrid_listaactividades_Titlebackstyle ;
      private short subGrid_listaactividades_Sortable ;
      private short A62TrListaActividad_Estado ;
      private short subGrid_listaactividades_Allowselection ;
      private short subGrid_listaactividades_Allowhovering ;
      private short subGrid_listaactividades_Allowcollapsing ;
      private short subGrid_listaactividades_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV26GridSettingsRowsPerPage_Grid_ListaActividades ;
      private short AV27PageCount_Grid_ListaActividades ;
      private short nGXWrapped ;
      private short subGrid_listaactividades_Backstyle ;
      private int divGridsettings_contentoutertablegrid_listaactividades_Visible ;
      private int nRC_GXsfl_113 ;
      private int nGXsfl_113_idx=1 ;
      private int subGrid_listaactividades_Rows ;
      private int edtavTractividades_id_Enabled ;
      private int edtavTractividades_idtarea_Enabled ;
      private int edtavTractividades_nombre_Enabled ;
      private int edtavTractividades_descripcion_Enabled ;
      private int edtavTractividades_fechainicio_Enabled ;
      private int edtavTractividades_fechafin_Enabled ;
      private int subGrid_listaactividades_Titlebackcolor ;
      private int subGrid_listaactividades_Allbackcolor ;
      private int subGrid_listaactividades_Selectedindex ;
      private int subGrid_listaactividades_Selectioncolor ;
      private int subGrid_listaactividades_Hoveringcolor ;
      private int subGrid_listaactividades_Islastpage ;
      private int edtavConfirmmessage_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int tblTableconditionalconfirm_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_listaactividades_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_listaactividades_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_listaactividades_Visible ;
      private int lblPaginationbar_lastpagetextblockgrid_listaactividades_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_listaactividades_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_listaactividades_Visible ;
      private int tblPaginationbar_pagingcontainertablegrid_listaactividades_Visible ;
      private int tblI_noresultsfoundtablename_grid_listaactividades_Visible ;
      private int bttAgregaractividad_Visible ;
      private int nGXsfl_113_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_listaactividades_Backcolor ;
      private int edtavActualizaractividad_action_Enabled ;
      private int edtavActualizaractividad_action_Visible ;
      private int edtavEliminaractividad_action_Enabled ;
      private int edtavEliminaractividad_action_Visible ;
      private long AV12TrActividades_ID ;
      private long AV13TrActividades_IDTarea ;
      private long wcpOAV12TrActividades_ID ;
      private long wcpOAV13TrActividades_IDTarea ;
      private long GRID_LISTAACTIVIDADES_nFirstRecordOnPage ;
      private long A25TrActividades_IDTarea ;
      private long A26TrActividades_ID ;
      private long GRID_LISTAACTIVIDADES_nCurrentRecord ;
      private long GRID_LISTAACTIVIDADES_nRecordCount ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_113_idx="0001" ;
      private String A27TrActividades_Nombre ;
      private String AV41Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String AV33ConfirmationSubId ;
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
      private String divTable_container_tractividades_id_Internalname ;
      private String divTable_container_tractividades_idfieldcontainer_Internalname ;
      private String lblTractividades_id_var_lefttext_Internalname ;
      private String lblTractividades_id_var_lefttext_Jsonclick ;
      private String edtavTractividades_id_Internalname ;
      private String edtavTractividades_id_Jsonclick ;
      private String lblTractividades_idtarea_var_lefttext_Internalname ;
      private String lblTractividades_idtarea_var_lefttext_Jsonclick ;
      private String edtavTractividades_idtarea_Internalname ;
      private String edtavTractividades_idtarea_Jsonclick ;
      private String divTable_container_tractividades_nombre_Internalname ;
      private String divTable_container_tractividades_nombrefieldcontainer_Internalname ;
      private String lblTractividades_nombre_var_lefttext_Internalname ;
      private String lblTractividades_nombre_var_lefttext_Jsonclick ;
      private String TempTags ;
      private String edtavTractividades_nombre_Internalname ;
      private String AV14TrActividades_Nombre ;
      private String edtavTractividades_nombre_Jsonclick ;
      private String lblTractividades_descripcion_var_lefttext_Internalname ;
      private String lblTractividades_descripcion_var_lefttext_Jsonclick ;
      private String edtavTractividades_descripcion_Internalname ;
      private String divTable_container_tractividades_fechainicio_Internalname ;
      private String divTable_container_tractividades_fechainiciofieldcontainer_Internalname ;
      private String lblTractividades_fechainicio_var_lefttext_Internalname ;
      private String lblTractividades_fechainicio_var_lefttext_Jsonclick ;
      private String edtavTractividades_fechainicio_Internalname ;
      private String edtavTractividades_fechainicio_Jsonclick ;
      private String lblTractividades_fechafin_var_lefttext_Internalname ;
      private String lblTractividades_fechafin_var_lefttext_Jsonclick ;
      private String edtavTractividades_fechafin_Internalname ;
      private String edtavTractividades_fechafin_Jsonclick ;
      private String lblTractividades_estado_var_lefttext_Internalname ;
      private String lblTractividades_estado_var_lefttext_Jsonclick ;
      private String cmbavTractividades_estado_Internalname ;
      private String cmbavTractividades_estado_Jsonclick ;
      private String divGridcomponent_grid_listaactividades_Internalname ;
      private String divGridcomponentcontent_grid_listaactividades_Internalname ;
      private String divLayoutdefined_grid_inner_grid_listaactividades_Internalname ;
      private String divLayoutdefined_table10_grid_listaactividades_Internalname ;
      private String divLayoutdefined_table3_grid_listaactividades_Internalname ;
      private String divLayoutdefined_section1_grid_listaactividades_Internalname ;
      private String divLayoutdefined_section7_grid_listaactividades_Internalname ;
      private String divLayoutdefined_section3_grid_listaactividades_Internalname ;
      private String divMaingrid_responsivetable_grid_listaactividades_Internalname ;
      private String sStyleString ;
      private String subGrid_listaactividades_Internalname ;
      private String subGrid_listaactividades_Class ;
      private String subGrid_listaactividades_Linesclass ;
      private String subGrid_listaactividades_Header ;
      private String edtavActualizaractividad_action_Tooltiptext ;
      private String edtavEliminaractividad_action_Tooltiptext ;
      private String A56TrListaActividad_Nombre ;
      private String divLayoutdefined_section8_grid_listaactividades_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavActualizaractividad_action_Internalname ;
      private String edtavEliminaractividad_action_Internalname ;
      private String edtTrListaActividad_ID_Internalname ;
      private String edtTrListaActividad_Nombre_Internalname ;
      private String edtTrListaActividad_Descripcion_Internalname ;
      private String edtTrListaActividad_FechaInicio_Internalname ;
      private String edtTrListaActividad_FechaFin_Internalname ;
      private String edtTrListaActividad_FechaCreacion_Internalname ;
      private String cmbTrListaActividad_Estado_Internalname ;
      private String cmbavGridsettingsrowsperpage_grid_listaactividades_Internalname ;
      private String edtavConfirmmessage_Internalname ;
      private String scmdbuf ;
      private String AV31ConfirmMessage ;
      private String tblTableconditionalconfirm_Internalname ;
      private String divGridsettings_contentoutertablegrid_listaactividades_Internalname ;
      private String lblPaginationbar_firstpagetextblockgrid_listaactividades_Caption ;
      private String lblPaginationbar_firstpagetextblockgrid_listaactividades_Internalname ;
      private String lblPaginationbar_previouspagetextblockgrid_listaactividades_Caption ;
      private String lblPaginationbar_previouspagetextblockgrid_listaactividades_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_listaactividades_Caption ;
      private String lblPaginationbar_currentpagetextblockgrid_listaactividades_Internalname ;
      private String lblPaginationbar_nextpagetextblockgrid_listaactividades_Caption ;
      private String lblPaginationbar_nextpagetextblockgrid_listaactividades_Internalname ;
      private String lblPaginationbar_lastpagetextblockgrid_listaactividades_Caption ;
      private String lblPaginationbar_lastpagetextblockgrid_listaactividades_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Class ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Class ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Internalname ;
      private String cellPaginationbar_firstpagecellgrid_listaactividades_Class ;
      private String cellPaginationbar_firstpagecellgrid_listaactividades_Internalname ;
      private String cellPaginationbar_spacingleftcellgrid_listaactividades_Class ;
      private String cellPaginationbar_spacingleftcellgrid_listaactividades_Internalname ;
      private String lblPaginationbar_spacinglefttextblockgrid_listaactividades_Internalname ;
      private String cellPaginationbar_previouspagecellgrid_listaactividades_Class ;
      private String cellPaginationbar_previouspagecellgrid_listaactividades_Internalname ;
      private String cellPaginationbar_lastpagecellgrid_listaactividades_Class ;
      private String cellPaginationbar_lastpagecellgrid_listaactividades_Internalname ;
      private String cellPaginationbar_spacingrightcellgrid_listaactividades_Class ;
      private String cellPaginationbar_spacingrightcellgrid_listaactividades_Internalname ;
      private String lblPaginationbar_spacingrighttextblockgrid_listaactividades_Internalname ;
      private String cellPaginationbar_nextpagecellgrid_listaactividades_Class ;
      private String cellPaginationbar_nextpagecellgrid_listaactividades_Internalname ;
      private String tblPaginationbar_pagingcontainertablegrid_listaactividades_Internalname ;
      private String tblI_noresultsfoundtablename_grid_listaactividades_Internalname ;
      private String bttAgregaractividad_Internalname ;
      private String sGXsfl_113_fel_idx="0001" ;
      private String tblSection_condconf_dialog_Internalname ;
      private String tblSection_condconf_dialog_inner_Internalname ;
      private String edtavConfirmmessage_Jsonclick ;
      private String tblConfirm_hidden_actionstable_Internalname ;
      private String bttI_buttonconfirmyes_Internalname ;
      private String bttI_buttonconfirmyes_Jsonclick ;
      private String bttI_buttonconfirmno_Internalname ;
      private String bttI_buttonconfirmno_Jsonclick ;
      private String cellPaginationbar_previouspagebuttoncellgrid_listaactividades_Internalname ;
      private String lblPaginationbar_previouspagebuttontextblockgrid_listaactividades_Jsonclick ;
      private String lblPaginationbar_firstpagetextblockgrid_listaactividades_Jsonclick ;
      private String lblPaginationbar_spacinglefttextblockgrid_listaactividades_Jsonclick ;
      private String lblPaginationbar_previouspagetextblockgrid_listaactividades_Jsonclick ;
      private String cellPaginationbar_currentpagecellgrid_listaactividades_Internalname ;
      private String lblPaginationbar_currentpagetextblockgrid_listaactividades_Jsonclick ;
      private String lblPaginationbar_nextpagetextblockgrid_listaactividades_Jsonclick ;
      private String lblPaginationbar_spacingrighttextblockgrid_listaactividades_Jsonclick ;
      private String lblPaginationbar_lastpagetextblockgrid_listaactividades_Jsonclick ;
      private String cellPaginationbar_nextpagebuttoncellgrid_listaactividades_Internalname ;
      private String lblPaginationbar_nextpagebuttontextblockgrid_listaactividades_Jsonclick ;
      private String lblI_noresultsfoundtextblock_grid_listaactividades_Internalname ;
      private String lblI_noresultsfoundtextblock_grid_listaactividades_Jsonclick ;
      private String tblActions_grid_listaactividades_gridassociatedleft_Internalname ;
      private String bttAgregaractividad_Jsonclick ;
      private String tblLayoutdefined_table7_grid_listaactividades_Internalname ;
      private String divGridsettings_globaltablegrid_listaactividades_Internalname ;
      private String lblGridsettings_labelgrid_listaactividades_Internalname ;
      private String lblGridsettings_labelgrid_listaactividades_Jsonclick ;
      private String bttGridsettings_savegrid_listaactividades_Internalname ;
      private String bttGridsettings_savegrid_listaactividades_Jsonclick ;
      private String tblGridsettings_tablecontentgrid_listaactividades_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_listaactividades_Internalname ;
      private String lblGridsettings_rowsperpagetextblockgrid_listaactividades_Jsonclick ;
      private String cmbavGridsettingsrowsperpage_grid_listaactividades_Jsonclick ;
      private String tblGridtitlecontainertable_grid_listaactividades_Internalname ;
      private String lblGridtitle_grid_listaactividades_Internalname ;
      private String lblGridtitle_grid_listaactividades_Jsonclick ;
      private String sImgUrl ;
      private String edtavActualizaractividad_action_Jsonclick ;
      private String edtavEliminaractividad_action_Jsonclick ;
      private String ROClassString ;
      private String edtTrListaActividad_ID_Jsonclick ;
      private String edtTrListaActividad_Nombre_Jsonclick ;
      private String edtTrListaActividad_Descripcion_Jsonclick ;
      private String edtTrListaActividad_FechaInicio_Jsonclick ;
      private String edtTrListaActividad_FechaFin_Jsonclick ;
      private String edtTrListaActividad_FechaCreacion_Jsonclick ;
      private String GXCCtl ;
      private String cmbTrListaActividad_Estado_Jsonclick ;
      private DateTime A29TrActividades_FechaInicio ;
      private DateTime A30TrActividades_FechaFin ;
      private DateTime A31TrActividades_FechaCreacion ;
      private DateTime AV16TrActividades_FechaInicio ;
      private DateTime AV17TrActividades_FechaFin ;
      private DateTime A58TrListaActividad_FechaInicio ;
      private DateTime A59TrListaActividad_FechaFin ;
      private DateTime A60TrListaActividad_FechaCreacion ;
      private DateTime AV29TrActividades_FechaCreacion ;
      private bool entryPointCalled ;
      private bool n25TrActividades_IDTarea ;
      private bool n27TrActividades_Nombre ;
      private bool n28TrActividades_Descripcion ;
      private bool n29TrActividades_FechaInicio ;
      private bool n30TrActividades_FechaFin ;
      private bool n31TrActividades_FechaCreacion ;
      private bool n33TrActividades_Estado ;
      private bool toggleJsOutput ;
      private bool AV32ConfirmationRequired ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_113_Refreshing=false ;
      private bool n56TrListaActividad_Nombre ;
      private bool n57TrListaActividad_Descripcion ;
      private bool n58TrListaActividad_FechaInicio ;
      private bool n59TrListaActividad_FechaFin ;
      private bool n60TrListaActividad_FechaCreacion ;
      private bool n62TrListaActividad_Estado ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV25RowsPerPageLoaded_Grid_ListaActividades ;
      private bool gx_refresh_fired ;
      private bool AV37Actualizaractividad_Action_IsBlob ;
      private bool AV30EliminarActividad_Action_IsBlob ;
      private String A28TrActividades_Descripcion ;
      private String AV15TrActividades_Descripcion ;
      private String A57TrListaActividad_Descripcion ;
      private String AV42Actualizaractividad_action_GXI ;
      private String AV43Eliminaractividad_action_GXI ;
      private String AV19GridStateKey ;
      private String AV37Actualizaractividad_Action ;
      private String AV30EliminarActividad_Action ;
      private Guid AV35TrListaActividad_ID ;
      private Guid AV34GridKey_TrListaActividad_ID ;
      private Guid A55TrListaActividad_ID ;
      private GXWebGrid Grid_listaactividadesContainer ;
      private GXWebRow Grid_listaactividadesRow ;
      private GXWebColumn Grid_listaactividadesColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTractividades_estado ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid_listaactividades ;
      private GXCombobox cmbTrListaActividad_Estado ;
      private IDataStoreProvider pr_default ;
      private long[] H002D2_A26TrActividades_ID ;
      private short[] H002D2_A62TrListaActividad_Estado ;
      private bool[] H002D2_n62TrListaActividad_Estado ;
      private DateTime[] H002D2_A60TrListaActividad_FechaCreacion ;
      private bool[] H002D2_n60TrListaActividad_FechaCreacion ;
      private DateTime[] H002D2_A59TrListaActividad_FechaFin ;
      private bool[] H002D2_n59TrListaActividad_FechaFin ;
      private DateTime[] H002D2_A58TrListaActividad_FechaInicio ;
      private bool[] H002D2_n58TrListaActividad_FechaInicio ;
      private String[] H002D2_A57TrListaActividad_Descripcion ;
      private bool[] H002D2_n57TrListaActividad_Descripcion ;
      private String[] H002D2_A56TrListaActividad_Nombre ;
      private bool[] H002D2_n56TrListaActividad_Nombre ;
      private Guid[] H002D2_A55TrListaActividad_ID ;
      private long[] H002D3_AGRID_LISTAACTIVIDADES_nRecordCount ;
      private long[] H002D4_A25TrActividades_IDTarea ;
      private bool[] H002D4_n25TrActividades_IDTarea ;
      private long[] H002D4_A26TrActividades_ID ;
      private String[] H002D4_A27TrActividades_Nombre ;
      private bool[] H002D4_n27TrActividades_Nombre ;
      private String[] H002D4_A28TrActividades_Descripcion ;
      private bool[] H002D4_n28TrActividades_Descripcion ;
      private DateTime[] H002D4_A29TrActividades_FechaInicio ;
      private bool[] H002D4_n29TrActividades_FechaInicio ;
      private DateTime[] H002D4_A30TrActividades_FechaFin ;
      private bool[] H002D4_n30TrActividades_FechaFin ;
      private DateTime[] H002D4_A31TrActividades_FechaCreacion ;
      private bool[] H002D4_n31TrActividades_FechaCreacion ;
      private short[] H002D4_A33TrActividades_Estado ;
      private bool[] H002D4_n33TrActividades_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtK2BGridState AV20GridState ;
      private SdtGestionActividades_SDT AV36GestionActividades_SDT ;
   }

   public class wpvisualizarinformacionactividad__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002D2 ;
          prmH002D2 = new Object[] {
          new Object[] {"@AV12TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH002D3 ;
          prmH002D3 = new Object[] {
          new Object[] {"@AV12TrActividades_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmH002D4 ;
          prmH002D4 = new Object[] {
          new Object[] {"@AV12TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV13TrActividades_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002D2", "SELECT [TrActividades_ID], [TrListaActividad_Estado], [TrListaActividad_FechaCreacion], [TrListaActividad_FechaFin], [TrListaActividad_FechaInicio], [TrListaActividad_Descripcion], [TrListaActividad_Nombre], [TrListaActividad_ID] FROM TABLERO.[TrActividadesLevel1] WHERE [TrActividades_ID] = @AV12TrActividades_ID ORDER BY [TrActividades_ID]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002D3", "SELECT COUNT(*) FROM TABLERO.[TrActividadesLevel1] WHERE [TrActividades_ID] = @AV12TrActividades_ID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002D4", "SELECT [TrActividades_IDTarea], [TrActividades_ID], [TrActividades_Nombre], [TrActividades_Descripcion], [TrActividades_FechaInicio], [TrActividades_FechaFin], [TrActividades_FechaCreacion], [TrActividades_Estado] FROM TABLERO.[TrActividades] WHERE ([TrActividades_ID] = @AV12TrActividades_ID) AND ([TrActividades_IDTarea] = @AV13TrActividades_IDTarea) ORDER BY [TrActividades_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D4,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
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
                ((Guid[]) buf[13])[0] = rslt.getGuid(8) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2) ;
                ((String[]) buf[3])[0] = rslt.getString(3, 100) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
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
                return;
             case 2 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                return;
       }
    }

 }

}
