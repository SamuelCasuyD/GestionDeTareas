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
   public class wpactualizartareaportablero : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpactualizartareaportablero( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpactualizartareaportablero( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_TrGestionTareas_ID ,
                           Guid aP1_TrGestionTareas_IDTablero )
      {
         this.AV12TrGestionTareas_ID = aP0_TrGestionTareas_ID;
         this.AV25TrGestionTareas_IDTablero = aP1_TrGestionTareas_IDTablero;
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
               AV12TrGestionTareas_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV12TrGestionTareas_ID), 13, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV25TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
                  AssignAttri("", false, "AV25TrGestionTareas_IDTablero", AV25TrGestionTareas_IDTablero.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO", GetSecureSignedToken( "", AV25TrGestionTareas_IDTablero, context));
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
         PA1Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1Y2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2022102021351523", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpactualizartareaportablero.aspx") + "?" + UrlEncode("" +AV12TrGestionTareas_ID) + "," + UrlEncode(AV25TrGestionTareas_IDTablero.ToString())+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTRCOMENTARIOTAREA_SDT", GetSecureSignedToken( "", AV26TrComentarioTarea_SDT, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO", GetSecureSignedToken( "", AV25TrGestionTareas_IDTablero, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_NOMBRE", StringUtil.RTrim( A13TrGestionTareas_Nombre));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_DESCRIPCION", A14TrGestionTareas_Descripcion);
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAINICIO", context.localUtil.DToC( A15TrGestionTareas_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAFIN", context.localUtil.DToC( A16TrGestionTareas_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24TrGestionTareas_Estado), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONTAREAS_SDT", AV19GestionTareas_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONTAREAS_SDT", AV19GestionTareas_SDT);
         }
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_IDTABLERO", AV25TrGestionTareas_IDTablero.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO", GetSecureSignedToken( "", AV25TrGestionTareas_IDTablero, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRCOMENTARIOTAREA_SDT", AV26TrComentarioTarea_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRCOMENTARIOTAREA_SDT", AV26TrComentarioTarea_SDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRCOMENTARIOTAREA_SDT", GetSecureSignedToken( "", AV26TrComentarioTarea_SDT, context));
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
            WE1Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1Y2( ) ;
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
         return formatLink("wpactualizartareaportablero.aspx") + "?" + UrlEncode("" +AV12TrGestionTareas_ID) + "," + UrlEncode(AV25TrGestionTareas_IDTablero.ToString()) ;
      }

      public override String GetPgmname( )
      {
         return "WpActualizarTareaPorTablero" ;
      }

      public override String GetPgmdesc( )
      {
         return "Wp Actualizar Tarea Por Tablero" ;
      }

      protected void WB1Y0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Modificación de datos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpActualizarTareaPorTablero.htm");
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Datos de la tarea", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpActualizarTareaPorTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_nombre_var_lefttext_Internalname, "Nombre : ", "", "", lblTrgestiontareas_nombre_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarTareaPorTablero.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_nombre_Internalname, StringUtil.RTrim( AV13TrGestionTareas_Nombre), StringUtil.RTrim( context.localUtil.Format( AV13TrGestionTareas_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrgestiontareas_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpActualizarTareaPorTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_descripcion_var_lefttext_Internalname, "Descripción : ", "", "", lblTrgestiontareas_descripcion_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarTareaPorTablero.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTrgestiontareas_descripcion_Internalname, AV14TrGestionTareas_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", 0, 1, edtavTrgestiontareas_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpActualizarTareaPorTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechainicio_var_lefttext_Internalname, "Fecha de inicio : ", "", "", lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarTareaPorTablero.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontareas_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_fechainicio_Internalname, context.localUtil.Format(AV15TrGestionTareas_FechaInicio, "99/99/9999"), context.localUtil.Format( AV15TrGestionTareas_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontareas_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarTareaPorTablero.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontareas_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontareas_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarTareaPorTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTrgestiontareas_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarTareaPorTablero.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrgestiontareas_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrgestiontareas_fechafin_Internalname, context.localUtil.Format(AV16TrGestionTareas_FechaFin, "99/99/9999"), context.localUtil.Format( AV16TrGestionTareas_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrgestiontareas_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrgestiontareas_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarTareaPorTablero.htm");
            GxWebStd.gx_bitmap( context, edtavTrgestiontareas_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrgestiontareas_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarTareaPorTablero.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTrgestiontareas_estado_var_lefttext_Internalname, "Estado : ", "", "", lblTrgestiontareas_estado_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarTareaPorTablero.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTrgestiontareas_estado, cmbavTrgestiontareas_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrGestionTareas_Estado), 4, 0)), 1, cmbavTrgestiontareas_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTrgestiontareas_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, "HLP_WpActualizarTareaPorTablero.htm");
            cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrGestionTareas_Estado), 4, 0));
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_67_1Y2( true) ;
         }
         else
         {
            wb_table1_67_1Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_67_1Y2e( bool wbgen )
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
         wbLoad = true;
      }

      protected void START1Y2( )
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
            Form.Meta.addItem("description", "Wp Actualizar Tarea Por Tablero", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1Y0( ) ;
      }

      protected void WS1Y2( )
      {
         START1Y2( ) ;
         EVT1Y2( ) ;
      }

      protected void EVT1Y2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E111Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E121Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_MODIFICARTAREA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_ModificarTarea' */
                              E131Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E141Y2 ();
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1Y2( )
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

      protected void PA1Y2( )
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
            AV18TrGestionTareas_Estado = (short)(NumberUtil.Val( cmbavTrgestiontareas_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrGestionTareas_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV18TrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV18TrGestionTareas_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrGestionTareas_Estado), 4, 0));
            AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", cmbavTrgestiontareas_estado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF1Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E121Y2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E141Y2 ();
            WB1Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1Y2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRCOMENTARIOTAREA_SDT", AV26TrComentarioTarea_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRCOMENTARIOTAREA_SDT", AV26TrComentarioTarea_SDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRCOMENTARIOTAREA_SDT", GetSecureSignedToken( "", AV26TrComentarioTarea_SDT, context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP1Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV13TrGestionTareas_Nombre = cgiGet( edtavTrgestiontareas_nombre_Internalname);
            AssignAttri("", false, "AV13TrGestionTareas_Nombre", AV13TrGestionTareas_Nombre);
            AV14TrGestionTareas_Descripcion = cgiGet( edtavTrgestiontareas_descripcion_Internalname);
            AssignAttri("", false, "AV14TrGestionTareas_Descripcion", AV14TrGestionTareas_Descripcion);
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Inicio"}), 1, "vTRGESTIONTAREAS_FECHAINICIO");
               GX_FocusControl = edtavTrgestiontareas_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15TrGestionTareas_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV15TrGestionTareas_FechaInicio", context.localUtil.Format(AV15TrGestionTareas_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV15TrGestionTareas_FechaInicio = context.localUtil.CToD( cgiGet( edtavTrgestiontareas_fechainicio_Internalname), 1);
               AssignAttri("", false, "AV15TrGestionTareas_FechaInicio", context.localUtil.Format(AV15TrGestionTareas_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Fin"}), 1, "vTRGESTIONTAREAS_FECHAFIN");
               GX_FocusControl = edtavTrgestiontareas_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16TrGestionTareas_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV16TrGestionTareas_FechaFin", context.localUtil.Format(AV16TrGestionTareas_FechaFin, "99/99/9999"));
            }
            else
            {
               AV16TrGestionTareas_FechaFin = context.localUtil.CToD( cgiGet( edtavTrgestiontareas_fechafin_Internalname), 1);
               AssignAttri("", false, "AV16TrGestionTareas_FechaFin", context.localUtil.Format(AV16TrGestionTareas_FechaFin, "99/99/9999"));
            }
            cmbavTrgestiontareas_estado.CurrentValue = cgiGet( cmbavTrgestiontareas_estado_Internalname);
            AV18TrGestionTareas_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTrgestiontareas_estado_Internalname), "."));
            AssignAttri("", false, "AV18TrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV18TrGestionTareas_Estado), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         /* Using cursor H001Y2 */
         pr_default.execute(0, new Object[] {AV12TrGestionTareas_ID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A12TrGestionTareas_ID = H001Y2_A12TrGestionTareas_ID[0];
            A13TrGestionTareas_Nombre = H001Y2_A13TrGestionTareas_Nombre[0];
            n13TrGestionTareas_Nombre = H001Y2_n13TrGestionTareas_Nombre[0];
            A14TrGestionTareas_Descripcion = H001Y2_A14TrGestionTareas_Descripcion[0];
            n14TrGestionTareas_Descripcion = H001Y2_n14TrGestionTareas_Descripcion[0];
            A15TrGestionTareas_FechaInicio = H001Y2_A15TrGestionTareas_FechaInicio[0];
            n15TrGestionTareas_FechaInicio = H001Y2_n15TrGestionTareas_FechaInicio[0];
            A16TrGestionTareas_FechaFin = H001Y2_A16TrGestionTareas_FechaFin[0];
            n16TrGestionTareas_FechaFin = H001Y2_n16TrGestionTareas_FechaFin[0];
            A24TrGestionTareas_Estado = H001Y2_A24TrGestionTareas_Estado[0];
            n24TrGestionTareas_Estado = H001Y2_n24TrGestionTareas_Estado[0];
            AV13TrGestionTareas_Nombre = A13TrGestionTareas_Nombre;
            AssignAttri("", false, "AV13TrGestionTareas_Nombre", AV13TrGestionTareas_Nombre);
            AV14TrGestionTareas_Descripcion = A14TrGestionTareas_Descripcion;
            AssignAttri("", false, "AV14TrGestionTareas_Descripcion", AV14TrGestionTareas_Descripcion);
            AV15TrGestionTareas_FechaInicio = A15TrGestionTareas_FechaInicio;
            AssignAttri("", false, "AV15TrGestionTareas_FechaInicio", context.localUtil.Format(AV15TrGestionTareas_FechaInicio, "99/99/9999"));
            AV16TrGestionTareas_FechaFin = A16TrGestionTareas_FechaFin;
            AssignAttri("", false, "AV16TrGestionTareas_FechaFin", context.localUtil.Format(AV16TrGestionTareas_FechaFin, "99/99/9999"));
            AV18TrGestionTareas_Estado = A24TrGestionTareas_Estado;
            AssignAttri("", false, "AV18TrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV18TrGestionTareas_Estado), 4, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S132( )
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
         E111Y2 ();
         if (returnInSub) return;
      }

      protected void E111Y2( )
      {
         /* Start Routine */
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E121Y2( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavTrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrGestionTareas_Estado), 4, 0));
         AssignProp("", false, cmbavTrgestiontareas_estado_Internalname, "Values", cmbavTrgestiontareas_estado.ToJavascriptSource(), true);
      }

      protected void E131Y2( )
      {
         /* 'E_ModificarTarea' Routine */
         /* Execute user subroutine: 'U_MODIFICARTAREA' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19GestionTareas_SDT", AV19GestionTareas_SDT);
      }

      protected void S142( )
      {
         /* 'U_MODIFICARTAREA' Routine */
         AV19GestionTareas_SDT.gxTpr_Trgestiontareas_id = AV12TrGestionTareas_ID;
         AV19GestionTareas_SDT.gxTpr_Trgestiontareas_idtablero = (Guid)(AV25TrGestionTareas_IDTablero);
         AV19GestionTareas_SDT.gxTpr_Trgestiontareas_nombre = AV13TrGestionTareas_Nombre;
         AV19GestionTareas_SDT.gxTpr_Trgestiontareas_descripcion = AV14TrGestionTareas_Descripcion;
         AV19GestionTareas_SDT.gxTpr_Trgestiontareas_fechainicio = AV15TrGestionTareas_FechaInicio;
         AV19GestionTareas_SDT.gxTpr_Trgestiontareas_fechafin = AV16TrGestionTareas_FechaFin;
         AV19GestionTareas_SDT.gxTpr_Trgestiontareas_estado = AV18TrGestionTareas_Estado;
         new prgestionesdetareas(context ).execute(  AV19GestionTareas_SDT,  AV26TrComentarioTarea_SDT,  "UDP") ;
      }

      protected void nextLoad( )
      {
      }

      protected void E141Y2( )
      {
         /* Load Routine */
      }

      protected void wb_table1_67_1Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttModificartarea_Internalname, "", "Modificar Tarea", bttModificartarea_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_MODIFICARTAREA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpActualizarTareaPorTablero.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_67_1Y2e( true) ;
         }
         else
         {
            wb_table1_67_1Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12TrGestionTareas_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV12TrGestionTareas_ID), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         AV25TrGestionTareas_IDTablero = (Guid)((Guid)getParm(obj,1));
         AssignAttri("", false, "AV25TrGestionTareas_IDTablero", AV25TrGestionTareas_IDTablero.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_IDTABLERO", GetSecureSignedToken( "", AV25TrGestionTareas_IDTablero, context));
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
         PA1Y2( ) ;
         WS1Y2( ) ;
         WE1Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?2022102021351552", true, true);
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
         context.AddJavascriptSource("wpactualizartareaportablero.js", "?2022102021351552", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
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
            AV18TrGestionTareas_Estado = (short)(NumberUtil.Val( cmbavTrgestiontareas_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrGestionTareas_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV18TrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV18TrGestionTareas_Estado), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divSection2_Internalname = "SECTION2";
         divTable1_Internalname = "TABLE1";
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
         bttModificartarea_Internalname = "MODIFICARTAREA";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Wp Actualizar Tarea Por Tablero";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A13TrGestionTareas_Nombre',fld:'TRGESTIONTAREAS_NOMBRE',pic:''},{av:'A14TrGestionTareas_Descripcion',fld:'TRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'A15TrGestionTareas_FechaInicio',fld:'TRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'A16TrGestionTareas_FechaFin',fld:'TRGESTIONTAREAS_FECHAFIN',pic:''},{av:'A24TrGestionTareas_Estado',fld:'TRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV12TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV25TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:'',hsh:true},{av:'AV26TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV13TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV14TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV15TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV16TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV18TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'}]}");
         setEventMetadata("'E_MODIFICARTAREA'","{handler:'E131Y2',iparms:[{av:'AV12TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV19GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''},{av:'AV25TrGestionTareas_IDTablero',fld:'vTRGESTIONTAREAS_IDTABLERO',pic:'',hsh:true},{av:'AV13TrGestionTareas_Nombre',fld:'vTRGESTIONTAREAS_NOMBRE',pic:''},{av:'AV14TrGestionTareas_Descripcion',fld:'vTRGESTIONTAREAS_DESCRIPCION',pic:''},{av:'AV15TrGestionTareas_FechaInicio',fld:'vTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV16TrGestionTareas_FechaFin',fld:'vTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'cmbavTrgestiontareas_estado'},{av:'AV18TrGestionTareas_Estado',fld:'vTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'},{av:'AV26TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:'',hsh:true}]");
         setEventMetadata("'E_MODIFICARTAREA'",",oparms:[{av:'AV19GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:''}]}");
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
         wcpOAV25TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV26TrComentarioTarea_SDT = new SdtTrComentarioTarea_SDT(context);
         GXKey = "";
         A13TrGestionTareas_Nombre = "";
         A14TrGestionTareas_Descripcion = "";
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
         AV19GestionTareas_SDT = new SdtGestionTareas_SDT(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTrgestiontareas_nombre_var_lefttext_Jsonclick = "";
         TempTags = "";
         AV13TrGestionTareas_Nombre = "";
         lblTrgestiontareas_descripcion_var_lefttext_Jsonclick = "";
         AV14TrGestionTareas_Descripcion = "";
         lblTrgestiontareas_fechainicio_var_lefttext_Jsonclick = "";
         AV15TrGestionTareas_FechaInicio = DateTime.MinValue;
         lblTrgestiontareas_fechafin_var_lefttext_Jsonclick = "";
         AV16TrGestionTareas_FechaFin = DateTime.MinValue;
         lblTrgestiontareas_estado_var_lefttext_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H001Y2_A12TrGestionTareas_ID = new long[1] ;
         H001Y2_A13TrGestionTareas_Nombre = new String[] {""} ;
         H001Y2_n13TrGestionTareas_Nombre = new bool[] {false} ;
         H001Y2_A14TrGestionTareas_Descripcion = new String[] {""} ;
         H001Y2_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         H001Y2_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H001Y2_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         H001Y2_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H001Y2_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         H001Y2_A24TrGestionTareas_Estado = new short[1] ;
         H001Y2_n24TrGestionTareas_Estado = new bool[] {false} ;
         sStyleString = "";
         bttModificartarea_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpactualizartareaportablero__default(),
            new Object[][] {
                new Object[] {
               H001Y2_A12TrGestionTareas_ID, H001Y2_A13TrGestionTareas_Nombre, H001Y2_n13TrGestionTareas_Nombre, H001Y2_A14TrGestionTareas_Descripcion, H001Y2_n14TrGestionTareas_Descripcion, H001Y2_A15TrGestionTareas_FechaInicio, H001Y2_n15TrGestionTareas_FechaInicio, H001Y2_A16TrGestionTareas_FechaFin, H001Y2_n16TrGestionTareas_FechaFin, H001Y2_A24TrGestionTareas_Estado,
               H001Y2_n24TrGestionTareas_Estado
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A24TrGestionTareas_Estado ;
      private short wbEnd ;
      private short wbStart ;
      private short AV18TrGestionTareas_Estado ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTrgestiontareas_nombre_Enabled ;
      private int edtavTrgestiontareas_descripcion_Enabled ;
      private int edtavTrgestiontareas_fechainicio_Enabled ;
      private int edtavTrgestiontareas_fechafin_Enabled ;
      private int idxLst ;
      private long AV12TrGestionTareas_ID ;
      private long wcpOAV12TrGestionTareas_ID ;
      private long A12TrGestionTareas_ID ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String A13TrGestionTareas_Nombre ;
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
      private String divTable_container_trgestiontareas_nombre_Internalname ;
      private String divTable_container_trgestiontareas_nombrefieldcontainer_Internalname ;
      private String lblTrgestiontareas_nombre_var_lefttext_Internalname ;
      private String lblTrgestiontareas_nombre_var_lefttext_Jsonclick ;
      private String TempTags ;
      private String edtavTrgestiontareas_nombre_Internalname ;
      private String AV13TrGestionTareas_Nombre ;
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
      private String divResponsivetable_containernode_actions_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String scmdbuf ;
      private String sStyleString ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String bttModificartarea_Internalname ;
      private String bttModificartarea_Jsonclick ;
      private DateTime A15TrGestionTareas_FechaInicio ;
      private DateTime A16TrGestionTareas_FechaFin ;
      private DateTime AV15TrGestionTareas_FechaInicio ;
      private DateTime AV16TrGestionTareas_FechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n13TrGestionTareas_Nombre ;
      private bool n14TrGestionTareas_Descripcion ;
      private bool n15TrGestionTareas_FechaInicio ;
      private bool n16TrGestionTareas_FechaFin ;
      private bool n24TrGestionTareas_Estado ;
      private bool returnInSub ;
      private String A14TrGestionTareas_Descripcion ;
      private String AV14TrGestionTareas_Descripcion ;
      private Guid AV25TrGestionTareas_IDTablero ;
      private Guid wcpOAV25TrGestionTareas_IDTablero ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTrgestiontareas_estado ;
      private IDataStoreProvider pr_default ;
      private long[] H001Y2_A12TrGestionTareas_ID ;
      private String[] H001Y2_A13TrGestionTareas_Nombre ;
      private bool[] H001Y2_n13TrGestionTareas_Nombre ;
      private String[] H001Y2_A14TrGestionTareas_Descripcion ;
      private bool[] H001Y2_n14TrGestionTareas_Descripcion ;
      private DateTime[] H001Y2_A15TrGestionTareas_FechaInicio ;
      private bool[] H001Y2_n15TrGestionTareas_FechaInicio ;
      private DateTime[] H001Y2_A16TrGestionTareas_FechaFin ;
      private bool[] H001Y2_n16TrGestionTareas_FechaFin ;
      private short[] H001Y2_A24TrGestionTareas_Estado ;
      private bool[] H001Y2_n24TrGestionTareas_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtGestionTareas_SDT AV19GestionTareas_SDT ;
      private SdtTrComentarioTarea_SDT AV26TrComentarioTarea_SDT ;
   }

   public class wpactualizartareaportablero__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH001Y2 ;
          prmH001Y2 = new Object[] {
          new Object[] {"@AV12TrGestionTareas_ID",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H001Y2", "SELECT [TrGestionTareas_ID], [TrGestionTareas_Nombre], [TrGestionTareas_Descripcion], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_Estado] FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @AV12TrGestionTareas_ID ORDER BY [TrGestionTareas_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Y2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
