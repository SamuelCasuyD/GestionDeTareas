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
   public class wpactualizarlistaactividad : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpactualizarlistaactividad( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpactualizarlistaactividad( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( Guid aP0_TrListaActividad_ID ,
                           long aP1_TrActividades_ID )
      {
         this.AV15TrListaActividad_ID = aP0_TrListaActividad_ID;
         this.AV21TrActividades_ID = aP1_TrActividades_ID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTrlistaactividad_estado = new GXCombobox();
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
               AV15TrListaActividad_ID = (Guid)(StringUtil.StrToGuid( gxfirstwebparm));
               AssignAttri("", false, "AV15TrListaActividad_ID", AV15TrListaActividad_ID.ToString());
               GxWebStd.gx_hidden_field( context, "gxhash_vTRLISTAACTIVIDAD_ID", GetSecureSignedToken( "", AV15TrListaActividad_ID, context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV21TrActividades_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "AV21TrActividades_ID", StringUtil.LTrimStr( (decimal)(AV21TrActividades_ID), 13, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
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
         PA2F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2F2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210211745131", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpactualizarlistaactividad.aspx") + "?" + UrlEncode(AV15TrListaActividad_ID.ToString()) + "," + UrlEncode("" +AV21TrActividades_ID)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTRLISTAACTIVIDAD_ID", GetSecureSignedToken( "", AV15TrListaActividad_ID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_ID", A55TrListaActividad_ID.ToString());
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21TrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_NOMBRE", StringUtil.RTrim( A56TrListaActividad_Nombre));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_DESCRIPCION", A57TrListaActividad_Descripcion);
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHAINICIO", context.localUtil.DToC( A58TrListaActividad_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_FECHAFIN", context.localUtil.DToC( A59TrListaActividad_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TRLISTAACTIVIDAD_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62TrListaActividad_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCONFIRMATIONSUBID", StringUtil.RTrim( AV14ConfirmationSubId));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONACTIVIDADES_SDT", AV22GestionActividades_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONACTIVIDADES_SDT", AV22GestionActividades_SDT);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCONFIRMATIONREQUIRED", AV13ConfirmationRequired);
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
            WE2F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2F2( ) ;
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
         return formatLink("wpactualizarlistaactividad.aspx") + "?" + UrlEncode(AV15TrListaActividad_ID.ToString()) + "," + UrlEncode("" +AV21TrActividades_ID) ;
      }

      public override String GetPgmname( )
      {
         return "WpActualizarListaActividad" ;
      }

      public override String GetPgmdesc( )
      {
         return "Actividad" ;
      }

      protected void WB2F0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Editar actividad", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, "HLP_WpActualizarListaActividad.htm");
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Ingresar datos solicitados", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpActualizarListaActividad.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_id_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_idfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrlistaactividad_id_var_lefttext_Internalname, "ID ACTIVIDAD : ", "", "", lblTrlistaactividad_id_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarListaActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTrlistaactividad_id_Internalname, AV15TrListaActividad_ID.ToString(), AV15TrListaActividad_ID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrlistaactividad_id_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrlistaactividad_id_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_WpActualizarListaActividad.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_nombre_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_nombrefieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrlistaactividad_nombre_var_lefttext_Internalname, "Nombre : ", "", "", lblTrlistaactividad_nombre_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarListaActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrlistaactividad_nombre_Internalname, StringUtil.RTrim( AV16TrListaActividad_Nombre), StringUtil.RTrim( context.localUtil.Format( AV16TrListaActividad_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrlistaactividad_nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTrlistaactividad_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpActualizarListaActividad.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_descripcion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_descripcionfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrlistaactividad_descripcion_var_lefttext_Internalname, "Descripción : ", "", "", lblTrlistaactividad_descripcion_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarListaActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTrlistaactividad_descripcion_Internalname, AV17TrListaActividad_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtavTrlistaactividad_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpActualizarListaActividad.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_fechainicio_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_fechainiciofieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrlistaactividad_fechainicio_var_lefttext_Internalname, "Fecha de inicio : ", "", "", lblTrlistaactividad_fechainicio_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarListaActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrlistaactividad_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrlistaactividad_fechainicio_Internalname, context.localUtil.Format(AV18TrListaActividad_FechaInicio, "99/99/9999"), context.localUtil.Format( AV18TrListaActividad_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrlistaactividad_fechainicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrlistaactividad_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarListaActividad.htm");
            GxWebStd.gx_bitmap( context, edtavTrlistaactividad_fechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrlistaactividad_fechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarListaActividad.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_fechafin_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_fechafinfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrlistaactividad_fechafin_var_lefttext_Internalname, "Fecha de fin : ", "", "", lblTrlistaactividad_fechafin_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarListaActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTrlistaactividad_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTrlistaactividad_fechafin_Internalname, context.localUtil.Format(AV19TrListaActividad_FechaFin, "99/99/9999"), context.localUtil.Format( AV19TrListaActividad_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrlistaactividad_fechafin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavTrlistaactividad_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpActualizarListaActividad.htm");
            GxWebStd.gx_bitmap( context, edtavTrlistaactividad_fechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTrlistaactividad_fechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpActualizarListaActividad.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_estado_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trlistaactividad_estadofieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrlistaactividad_estado_var_lefttext_Internalname, "Estado : ", "", "", lblTrlistaactividad_estado_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpActualizarListaActividad.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTrlistaactividad_estado, cmbavTrlistaactividad_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20TrListaActividad_Estado), 4, 0)), 1, cmbavTrlistaactividad_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTrlistaactividad_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, "HLP_WpActualizarListaActividad.htm");
            cmbavTrlistaactividad_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20TrListaActividad_Estado), 4, 0));
            AssignProp("", false, cmbavTrlistaactividad_estado_Internalname, "Values", (String)(cmbavTrlistaactividad_estado.ToJavascriptSource()), true);
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
            wb_table1_74_2F2( true) ;
         }
         else
         {
            wb_table1_74_2F2( false) ;
         }
         return  ;
      }

      protected void wb_table1_74_2F2e( bool wbgen )
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
            wb_table2_80_2F2( true) ;
         }
         else
         {
            wb_table2_80_2F2( false) ;
         }
         return  ;
      }

      protected void wb_table2_80_2F2e( bool wbgen )
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
         wbLoad = true;
      }

      protected void START2F2( )
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
            Form.Meta.addItem("description", "Actividad", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2F0( ) ;
      }

      protected void WS2F2( )
      {
         START2F2( ) ;
         EVT2F2( ) ;
      }

      protected void EVT2F2( )
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
                              E112F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E122F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMYES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmYes' */
                              E132F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CONFIRMAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_Confirmar' */
                              E142F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E152F2 ();
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

      protected void WE2F2( )
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

      protected void PA2F2( )
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
               GX_FocusControl = edtavTrlistaactividad_nombre_Internalname;
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
         if ( cmbavTrlistaactividad_estado.ItemCount > 0 )
         {
            AV20TrListaActividad_Estado = (short)(NumberUtil.Val( cmbavTrlistaactividad_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20TrListaActividad_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV20TrListaActividad_Estado", StringUtil.LTrimStr( (decimal)(AV20TrListaActividad_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTrlistaactividad_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20TrListaActividad_Estado), 4, 0));
            AssignProp("", false, cmbavTrlistaactividad_estado_Internalname, "Values", cmbavTrlistaactividad_estado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTrlistaactividad_id_Enabled = 0;
         AssignProp("", false, edtavTrlistaactividad_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrlistaactividad_id_Enabled), 5, 0), true);
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void RF2F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E122F2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152F2 ();
            WB2F0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2F2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavTrlistaactividad_id_Enabled = 0;
         AssignProp("", false, edtavTrlistaactividad_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrlistaactividad_id_Enabled), 5, 0), true);
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void STRUP2F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV14ConfirmationSubId = cgiGet( "vCONFIRMATIONSUBID");
            /* Read variables values. */
            AV16TrListaActividad_Nombre = cgiGet( edtavTrlistaactividad_nombre_Internalname);
            AssignAttri("", false, "AV16TrListaActividad_Nombre", AV16TrListaActividad_Nombre);
            AV17TrListaActividad_Descripcion = cgiGet( edtavTrlistaactividad_descripcion_Internalname);
            AssignAttri("", false, "AV17TrListaActividad_Descripcion", AV17TrListaActividad_Descripcion);
            if ( context.localUtil.VCDate( cgiGet( edtavTrlistaactividad_fechainicio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Inicio"}), 1, "vTRLISTAACTIVIDAD_FECHAINICIO");
               GX_FocusControl = edtavTrlistaactividad_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18TrListaActividad_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV18TrListaActividad_FechaInicio", context.localUtil.Format(AV18TrListaActividad_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV18TrListaActividad_FechaInicio = context.localUtil.CToD( cgiGet( edtavTrlistaactividad_fechainicio_Internalname), 2);
               AssignAttri("", false, "AV18TrListaActividad_FechaInicio", context.localUtil.Format(AV18TrListaActividad_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTrlistaactividad_fechafin_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Lista Actividad_Fecha Fin"}), 1, "vTRLISTAACTIVIDAD_FECHAFIN");
               GX_FocusControl = edtavTrlistaactividad_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19TrListaActividad_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV19TrListaActividad_FechaFin", context.localUtil.Format(AV19TrListaActividad_FechaFin, "99/99/9999"));
            }
            else
            {
               AV19TrListaActividad_FechaFin = context.localUtil.CToD( cgiGet( edtavTrlistaactividad_fechafin_Internalname), 2);
               AssignAttri("", false, "AV19TrListaActividad_FechaFin", context.localUtil.Format(AV19TrListaActividad_FechaFin, "99/99/9999"));
            }
            cmbavTrlistaactividad_estado.CurrentValue = cgiGet( cmbavTrlistaactividad_estado_Internalname);
            AV20TrListaActividad_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTrlistaactividad_estado_Internalname), "."));
            AssignAttri("", false, "AV20TrListaActividad_Estado", StringUtil.LTrimStr( (decimal)(AV20TrListaActividad_Estado), 4, 0));
            AV12ConfirmMessage = cgiGet( edtavConfirmmessage_Internalname);
            AssignAttri("", false, "AV12ConfirmMessage", AV12ConfirmMessage);
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
         /* Using cursor H002F2 */
         pr_default.execute(0, new Object[] {AV21TrActividades_ID, AV15TrListaActividad_ID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A26TrActividades_ID = H002F2_A26TrActividades_ID[0];
            A55TrListaActividad_ID = (Guid)((Guid)(H002F2_A55TrListaActividad_ID[0]));
            A56TrListaActividad_Nombre = H002F2_A56TrListaActividad_Nombre[0];
            n56TrListaActividad_Nombre = H002F2_n56TrListaActividad_Nombre[0];
            A57TrListaActividad_Descripcion = H002F2_A57TrListaActividad_Descripcion[0];
            n57TrListaActividad_Descripcion = H002F2_n57TrListaActividad_Descripcion[0];
            A58TrListaActividad_FechaInicio = H002F2_A58TrListaActividad_FechaInicio[0];
            n58TrListaActividad_FechaInicio = H002F2_n58TrListaActividad_FechaInicio[0];
            A59TrListaActividad_FechaFin = H002F2_A59TrListaActividad_FechaFin[0];
            n59TrListaActividad_FechaFin = H002F2_n59TrListaActividad_FechaFin[0];
            A62TrListaActividad_Estado = H002F2_A62TrListaActividad_Estado[0];
            n62TrListaActividad_Estado = H002F2_n62TrListaActividad_Estado[0];
            AV16TrListaActividad_Nombre = A56TrListaActividad_Nombre;
            AssignAttri("", false, "AV16TrListaActividad_Nombre", AV16TrListaActividad_Nombre);
            AV17TrListaActividad_Descripcion = A57TrListaActividad_Descripcion;
            AssignAttri("", false, "AV17TrListaActividad_Descripcion", AV17TrListaActividad_Descripcion);
            AV18TrListaActividad_FechaInicio = A58TrListaActividad_FechaInicio;
            AssignAttri("", false, "AV18TrListaActividad_FechaInicio", context.localUtil.Format(AV18TrListaActividad_FechaInicio, "99/99/9999"));
            AV19TrListaActividad_FechaFin = A59TrListaActividad_FechaFin;
            AssignAttri("", false, "AV19TrListaActividad_FechaFin", context.localUtil.Format(AV19TrListaActividad_FechaFin, "99/99/9999"));
            AV20TrListaActividad_Estado = A62TrListaActividad_Estado;
            AssignAttri("", false, "AV20TrListaActividad_Estado", StringUtil.LTrimStr( (decimal)(AV20TrListaActividad_Estado), 4, 0));
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
         E112F2 ();
         if (returnInSub) return;
      }

      protected void E112F2( )
      {
         /* Start Routine */
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
      }

      protected void E122F2( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         AV13ConfirmationRequired = false;
         AssignAttri("", false, "AV13ConfirmationRequired", AV13ConfirmationRequired);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavTrlistaactividad_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20TrListaActividad_Estado), 4, 0));
         AssignProp("", false, cmbavTrlistaactividad_estado_Internalname, "Values", cmbavTrlistaactividad_estado.ToJavascriptSource(), true);
      }

      protected void E132F2( )
      {
         /* 'ConfirmYes' Routine */
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV14ConfirmationSubId, "'U_Confirmar'") == 0 )
         {
            /* Execute user subroutine: 'U_CONFIRMAR' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22GestionActividades_SDT", AV22GestionActividades_SDT);
      }

      protected void S152( )
      {
         /* 'U_CONFIRMATIONREQUIRED(CONFIRMAR)' Routine */
         AV13ConfirmationRequired = true;
         AssignAttri("", false, "AV13ConfirmationRequired", AV13ConfirmationRequired);
      }

      protected void E142F2( )
      {
         /* 'E_Confirmar' Routine */
         AV12ConfirmMessage = "¿Está seguro?";
         AssignAttri("", false, "AV12ConfirmMessage", AV12ConfirmMessage);
         /* Execute user subroutine: 'U_CONFIRMATIONREQUIRED(CONFIRMAR)' */
         S152 ();
         if (returnInSub) return;
         if ( AV13ConfirmationRequired )
         {
            AV14ConfirmationSubId = "'U_Confirmar'";
            AssignAttri("", false, "AV14ConfirmationSubId", AV14ConfirmationSubId);
            tblTableconditionalconfirm_Visible = 1;
            AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         }
         else
         {
            /* Execute user subroutine: 'U_CONFIRMAR' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22GestionActividades_SDT", AV22GestionActividades_SDT);
      }

      protected void S142( )
      {
         /* 'U_CONFIRMAR' Routine */
         AV22GestionActividades_SDT.gxTpr_Tractividades_id = AV21TrActividades_ID;
         AV22GestionActividades_SDT.gxTpr_Trlistaactividad_id = (Guid)(AV15TrListaActividad_ID);
         AV22GestionActividades_SDT.gxTpr_Trlistaactividad_nombre = AV16TrListaActividad_Nombre;
         AV22GestionActividades_SDT.gxTpr_Trlistaactividad_descripcion = AV17TrListaActividad_Descripcion;
         AV22GestionActividades_SDT.gxTpr_Trlistaactividad_fechainicio = AV18TrListaActividad_FechaInicio;
         AV22GestionActividades_SDT.gxTpr_Trlistaactividad_fechafin = AV19TrListaActividad_FechaFin;
         AV22GestionActividades_SDT.gxTpr_Trlistaactividad_estado = AV20TrListaActividad_Estado;
         new prgestionaractividades(context ).execute(  AV22GestionActividades_SDT,  "AUD") ;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E152F2( )
      {
         /* Load Routine */
      }

      protected void wb_table2_80_2F2( bool wbgen )
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
            wb_table3_83_2F2( true) ;
         }
         else
         {
            wb_table3_83_2F2( false) ;
         }
         return  ;
      }

      protected void wb_table3_83_2F2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_80_2F2e( true) ;
         }
         else
         {
            wb_table2_80_2F2e( false) ;
         }
      }

      protected void wb_table3_83_2F2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSection_condconf_dialog_Internalname, tblSection_condconf_dialog_Internalname, "", "Section_CondConf_Dialog", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table4_86_2F2( true) ;
         }
         else
         {
            wb_table4_86_2F2( false) ;
         }
         return  ;
      }

      protected void wb_table4_86_2F2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_83_2F2e( true) ;
         }
         else
         {
            wb_table3_83_2F2e( false) ;
         }
      }

      protected void wb_table4_86_2F2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfirmmessage_Internalname, StringUtil.RTrim( AV12ConfirmMessage), StringUtil.RTrim( context.localUtil.Format( AV12ConfirmMessage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfirmmessage_Jsonclick, 0, "Attribute_ConditionalConfirm", "", "", "", "", 1, edtavConfirmmessage_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpActualizarListaActividad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_93_2F2( true) ;
         }
         else
         {
            wb_table5_93_2F2( false) ;
         }
         return  ;
      }

      protected void wb_table5_93_2F2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_86_2F2e( true) ;
         }
         else
         {
            wb_table4_86_2F2e( false) ;
         }
      }

      protected void wb_table5_93_2F2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblConfirm_hidden_actionstable_Internalname, tblConfirm_hidden_actionstable_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction_Confirm";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmyes_Internalname, "", "Aceptar", bttI_buttonconfirmyes_Jsonclick, 5, "Aceptar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMYES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpActualizarListaActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmno_Internalname, "", "Cancelar", bttI_buttonconfirmno_Jsonclick, 7, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e162f1_client"+"'", TempTags, "", 2, "HLP_WpActualizarListaActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_93_2F2e( true) ;
         }
         else
         {
            wb_table5_93_2F2e( false) ;
         }
      }

      protected void wb_table1_74_2F2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirmar_Internalname, "", "Confirmar", bttConfirmar_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CONFIRMAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpActualizarListaActividad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_74_2F2e( true) ;
         }
         else
         {
            wb_table1_74_2F2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15TrListaActividad_ID = (Guid)((Guid)getParm(obj,0));
         AssignAttri("", false, "AV15TrListaActividad_ID", AV15TrListaActividad_ID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRLISTAACTIVIDAD_ID", GetSecureSignedToken( "", AV15TrListaActividad_ID, context));
         AV21TrActividades_ID = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV21TrActividades_ID", StringUtil.LTrimStr( (decimal)(AV21TrActividades_ID), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
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
         PA2F2( ) ;
         WS2F2( ) ;
         WE2F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210211745190", true, true);
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
         context.AddJavascriptSource("wpactualizarlistaactividad.js", "?202210211745190", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavTrlistaactividad_estado.Name = "vTRLISTAACTIVIDAD_ESTADO";
         cmbavTrlistaactividad_estado.WebTags = "";
         cmbavTrlistaactividad_estado.addItem("1", "Nuevo", 0);
         cmbavTrlistaactividad_estado.addItem("2", "En Progreso", 0);
         cmbavTrlistaactividad_estado.addItem("3", "Completado", 0);
         cmbavTrlistaactividad_estado.addItem("4", "Detenido", 0);
         cmbavTrlistaactividad_estado.addItem("5", "Pendiente", 0);
         if ( cmbavTrlistaactividad_estado.ItemCount > 0 )
         {
            AV20TrListaActividad_Estado = (short)(NumberUtil.Val( cmbavTrlistaactividad_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20TrListaActividad_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV20TrListaActividad_Estado", StringUtil.LTrimStr( (decimal)(AV20TrListaActividad_Estado), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divSection2_Internalname = "SECTION2";
         divTable1_Internalname = "TABLE1";
         lblTrlistaactividad_id_var_lefttext_Internalname = "TRLISTAACTIVIDAD_ID_VAR_LEFTTEXT";
         edtavTrlistaactividad_id_Internalname = "vTRLISTAACTIVIDAD_ID";
         divTable_container_trlistaactividad_idfieldcontainer_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_IDFIELDCONTAINER";
         divTable_container_trlistaactividad_id_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_ID";
         lblTrlistaactividad_nombre_var_lefttext_Internalname = "TRLISTAACTIVIDAD_NOMBRE_VAR_LEFTTEXT";
         edtavTrlistaactividad_nombre_Internalname = "vTRLISTAACTIVIDAD_NOMBRE";
         divTable_container_trlistaactividad_nombrefieldcontainer_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_NOMBREFIELDCONTAINER";
         divTable_container_trlistaactividad_nombre_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_NOMBRE";
         lblTrlistaactividad_descripcion_var_lefttext_Internalname = "TRLISTAACTIVIDAD_DESCRIPCION_VAR_LEFTTEXT";
         edtavTrlistaactividad_descripcion_Internalname = "vTRLISTAACTIVIDAD_DESCRIPCION";
         divTable_container_trlistaactividad_descripcionfieldcontainer_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_DESCRIPCIONFIELDCONTAINER";
         divTable_container_trlistaactividad_descripcion_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_DESCRIPCION";
         lblTrlistaactividad_fechainicio_var_lefttext_Internalname = "TRLISTAACTIVIDAD_FECHAINICIO_VAR_LEFTTEXT";
         edtavTrlistaactividad_fechainicio_Internalname = "vTRLISTAACTIVIDAD_FECHAINICIO";
         divTable_container_trlistaactividad_fechainiciofieldcontainer_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_FECHAINICIOFIELDCONTAINER";
         divTable_container_trlistaactividad_fechainicio_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_FECHAINICIO";
         lblTrlistaactividad_fechafin_var_lefttext_Internalname = "TRLISTAACTIVIDAD_FECHAFIN_VAR_LEFTTEXT";
         edtavTrlistaactividad_fechafin_Internalname = "vTRLISTAACTIVIDAD_FECHAFIN";
         divTable_container_trlistaactividad_fechafinfieldcontainer_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_FECHAFINFIELDCONTAINER";
         divTable_container_trlistaactividad_fechafin_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_FECHAFIN";
         lblTrlistaactividad_estado_var_lefttext_Internalname = "TRLISTAACTIVIDAD_ESTADO_VAR_LEFTTEXT";
         cmbavTrlistaactividad_estado_Internalname = "vTRLISTAACTIVIDAD_ESTADO";
         divTable_container_trlistaactividad_estadofieldcontainer_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_ESTADOFIELDCONTAINER";
         divTable_container_trlistaactividad_estado_Internalname = "TABLE_CONTAINER_TRLISTAACTIVIDAD_ESTADO";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         bttConfirmar_Internalname = "CONFIRMAR";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
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
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavConfirmmessage_Jsonclick = "";
         edtavConfirmmessage_Enabled = 1;
         tblTableconditionalconfirm_Visible = 1;
         cmbavTrlistaactividad_estado_Jsonclick = "";
         cmbavTrlistaactividad_estado.Enabled = 1;
         edtavTrlistaactividad_fechafin_Jsonclick = "";
         edtavTrlistaactividad_fechafin_Enabled = 1;
         edtavTrlistaactividad_fechainicio_Jsonclick = "";
         edtavTrlistaactividad_fechainicio_Enabled = 1;
         edtavTrlistaactividad_descripcion_Enabled = 1;
         edtavTrlistaactividad_nombre_Jsonclick = "";
         edtavTrlistaactividad_nombre_Enabled = 1;
         edtavTrlistaactividad_id_Jsonclick = "";
         edtavTrlistaactividad_id_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Actividad";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A55TrListaActividad_ID',fld:'TRLISTAACTIVIDAD_ID',pic:''},{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'A56TrListaActividad_Nombre',fld:'TRLISTAACTIVIDAD_NOMBRE',pic:''},{av:'A57TrListaActividad_Descripcion',fld:'TRLISTAACTIVIDAD_DESCRIPCION',pic:''},{av:'A58TrListaActividad_FechaInicio',fld:'TRLISTAACTIVIDAD_FECHAINICIO',pic:''},{av:'A59TrListaActividad_FechaFin',fld:'TRLISTAACTIVIDAD_FECHAFIN',pic:''},{av:'A62TrListaActividad_Estado',fld:'TRLISTAACTIVIDAD_ESTADO',pic:'ZZZ9'},{av:'AV21TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV15TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV13ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV16TrListaActividad_Nombre',fld:'vTRLISTAACTIVIDAD_NOMBRE',pic:''},{av:'AV17TrListaActividad_Descripcion',fld:'vTRLISTAACTIVIDAD_DESCRIPCION',pic:''},{av:'AV18TrListaActividad_FechaInicio',fld:'vTRLISTAACTIVIDAD_FECHAINICIO',pic:''},{av:'AV19TrListaActividad_FechaFin',fld:'vTRLISTAACTIVIDAD_FECHAFIN',pic:''},{av:'cmbavTrlistaactividad_estado'},{av:'AV20TrListaActividad_Estado',fld:'vTRLISTAACTIVIDAD_ESTADO',pic:'ZZZ9'}]}");
         setEventMetadata("'CONFIRMNO'","{handler:'E162F1',iparms:[]");
         setEventMetadata("'CONFIRMNO'",",oparms:[{av:'AV14ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'}]}");
         setEventMetadata("'CONFIRMYES'","{handler:'E132F2',iparms:[{av:'AV14ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'AV21TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV22GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''},{av:'AV15TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:'',hsh:true},{av:'AV16TrListaActividad_Nombre',fld:'vTRLISTAACTIVIDAD_NOMBRE',pic:''},{av:'AV17TrListaActividad_Descripcion',fld:'vTRLISTAACTIVIDAD_DESCRIPCION',pic:''},{av:'AV18TrListaActividad_FechaInicio',fld:'vTRLISTAACTIVIDAD_FECHAINICIO',pic:''},{av:'AV19TrListaActividad_FechaFin',fld:'vTRLISTAACTIVIDAD_FECHAFIN',pic:''},{av:'cmbavTrlistaactividad_estado'},{av:'AV20TrListaActividad_Estado',fld:'vTRLISTAACTIVIDAD_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("'CONFIRMYES'",",oparms:[{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV22GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''}]}");
         setEventMetadata("'E_CONFIRMAR'","{handler:'E142F2',iparms:[{av:'AV13ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV21TrActividades_ID',fld:'vTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV22GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''},{av:'AV15TrListaActividad_ID',fld:'vTRLISTAACTIVIDAD_ID',pic:'',hsh:true},{av:'AV16TrListaActividad_Nombre',fld:'vTRLISTAACTIVIDAD_NOMBRE',pic:''},{av:'AV17TrListaActividad_Descripcion',fld:'vTRLISTAACTIVIDAD_DESCRIPCION',pic:''},{av:'AV18TrListaActividad_FechaInicio',fld:'vTRLISTAACTIVIDAD_FECHAINICIO',pic:''},{av:'AV19TrListaActividad_FechaFin',fld:'vTRLISTAACTIVIDAD_FECHAFIN',pic:''},{av:'cmbavTrlistaactividad_estado'},{av:'AV20TrListaActividad_Estado',fld:'vTRLISTAACTIVIDAD_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("'E_CONFIRMAR'",",oparms:[{av:'AV12ConfirmMessage',fld:'vCONFIRMMESSAGE',pic:''},{av:'AV14ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV13ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV22GestionActividades_SDT',fld:'vGESTIONACTIVIDADES_SDT',pic:''}]}");
         setEventMetadata("VALIDV_TRLISTAACTIVIDAD_ID","{handler:'Validv_Trlistaactividad_id',iparms:[]");
         setEventMetadata("VALIDV_TRLISTAACTIVIDAD_ID",",oparms:[]}");
         setEventMetadata("VALIDV_TRLISTAACTIVIDAD_FECHAINICIO","{handler:'Validv_Trlistaactividad_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_TRLISTAACTIVIDAD_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_TRLISTAACTIVIDAD_FECHAFIN","{handler:'Validv_Trlistaactividad_fechafin',iparms:[]");
         setEventMetadata("VALIDV_TRLISTAACTIVIDAD_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_TRLISTAACTIVIDAD_ESTADO","{handler:'Validv_Trlistaactividad_estado',iparms:[]");
         setEventMetadata("VALIDV_TRLISTAACTIVIDAD_ESTADO",",oparms:[]}");
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
         wcpOAV15TrListaActividad_ID = (Guid)(Guid.Empty);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A55TrListaActividad_ID = (Guid)(Guid.Empty);
         A56TrListaActividad_Nombre = "";
         A57TrListaActividad_Descripcion = "";
         A58TrListaActividad_FechaInicio = DateTime.MinValue;
         A59TrListaActividad_FechaFin = DateTime.MinValue;
         AV14ConfirmationSubId = "";
         AV22GestionActividades_SDT = new SdtGestionActividades_SDT(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTrlistaactividad_id_var_lefttext_Jsonclick = "";
         lblTrlistaactividad_nombre_var_lefttext_Jsonclick = "";
         TempTags = "";
         AV16TrListaActividad_Nombre = "";
         lblTrlistaactividad_descripcion_var_lefttext_Jsonclick = "";
         AV17TrListaActividad_Descripcion = "";
         lblTrlistaactividad_fechainicio_var_lefttext_Jsonclick = "";
         AV18TrListaActividad_FechaInicio = DateTime.MinValue;
         lblTrlistaactividad_fechafin_var_lefttext_Jsonclick = "";
         AV19TrListaActividad_FechaFin = DateTime.MinValue;
         lblTrlistaactividad_estado_var_lefttext_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12ConfirmMessage = "";
         scmdbuf = "";
         H002F2_A26TrActividades_ID = new long[1] ;
         H002F2_A55TrListaActividad_ID = new Guid[] {Guid.Empty} ;
         H002F2_A56TrListaActividad_Nombre = new String[] {""} ;
         H002F2_n56TrListaActividad_Nombre = new bool[] {false} ;
         H002F2_A57TrListaActividad_Descripcion = new String[] {""} ;
         H002F2_n57TrListaActividad_Descripcion = new bool[] {false} ;
         H002F2_A58TrListaActividad_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H002F2_n58TrListaActividad_FechaInicio = new bool[] {false} ;
         H002F2_A59TrListaActividad_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H002F2_n59TrListaActividad_FechaFin = new bool[] {false} ;
         H002F2_A62TrListaActividad_Estado = new short[1] ;
         H002F2_n62TrListaActividad_Estado = new bool[] {false} ;
         sStyleString = "";
         bttI_buttonconfirmyes_Jsonclick = "";
         bttI_buttonconfirmno_Jsonclick = "";
         bttConfirmar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpactualizarlistaactividad__default(),
            new Object[][] {
                new Object[] {
               H002F2_A26TrActividades_ID, H002F2_A55TrListaActividad_ID, H002F2_A56TrListaActividad_Nombre, H002F2_n56TrListaActividad_Nombre, H002F2_A57TrListaActividad_Descripcion, H002F2_n57TrListaActividad_Descripcion, H002F2_A58TrListaActividad_FechaInicio, H002F2_n58TrListaActividad_FechaInicio, H002F2_A59TrListaActividad_FechaFin, H002F2_n59TrListaActividad_FechaFin,
               H002F2_A62TrListaActividad_Estado, H002F2_n62TrListaActividad_Estado
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTrlistaactividad_id_Enabled = 0;
         edtavConfirmmessage_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A62TrListaActividad_Estado ;
      private short wbEnd ;
      private short wbStart ;
      private short AV20TrListaActividad_Estado ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTrlistaactividad_id_Enabled ;
      private int edtavTrlistaactividad_nombre_Enabled ;
      private int edtavTrlistaactividad_descripcion_Enabled ;
      private int edtavTrlistaactividad_fechainicio_Enabled ;
      private int edtavTrlistaactividad_fechafin_Enabled ;
      private int edtavConfirmmessage_Enabled ;
      private int tblTableconditionalconfirm_Visible ;
      private int idxLst ;
      private long AV21TrActividades_ID ;
      private long wcpOAV21TrActividades_ID ;
      private long A26TrActividades_ID ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String A56TrListaActividad_Nombre ;
      private String AV14ConfirmationSubId ;
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
      private String divTable_container_trlistaactividad_id_Internalname ;
      private String divTable_container_trlistaactividad_idfieldcontainer_Internalname ;
      private String lblTrlistaactividad_id_var_lefttext_Internalname ;
      private String lblTrlistaactividad_id_var_lefttext_Jsonclick ;
      private String edtavTrlistaactividad_id_Internalname ;
      private String edtavTrlistaactividad_id_Jsonclick ;
      private String divTable_container_trlistaactividad_nombre_Internalname ;
      private String divTable_container_trlistaactividad_nombrefieldcontainer_Internalname ;
      private String lblTrlistaactividad_nombre_var_lefttext_Internalname ;
      private String lblTrlistaactividad_nombre_var_lefttext_Jsonclick ;
      private String TempTags ;
      private String edtavTrlistaactividad_nombre_Internalname ;
      private String AV16TrListaActividad_Nombre ;
      private String edtavTrlistaactividad_nombre_Jsonclick ;
      private String divTable_container_trlistaactividad_descripcion_Internalname ;
      private String divTable_container_trlistaactividad_descripcionfieldcontainer_Internalname ;
      private String lblTrlistaactividad_descripcion_var_lefttext_Internalname ;
      private String lblTrlistaactividad_descripcion_var_lefttext_Jsonclick ;
      private String edtavTrlistaactividad_descripcion_Internalname ;
      private String divTable_container_trlistaactividad_fechainicio_Internalname ;
      private String divTable_container_trlistaactividad_fechainiciofieldcontainer_Internalname ;
      private String lblTrlistaactividad_fechainicio_var_lefttext_Internalname ;
      private String lblTrlistaactividad_fechainicio_var_lefttext_Jsonclick ;
      private String edtavTrlistaactividad_fechainicio_Internalname ;
      private String edtavTrlistaactividad_fechainicio_Jsonclick ;
      private String divTable_container_trlistaactividad_fechafin_Internalname ;
      private String divTable_container_trlistaactividad_fechafinfieldcontainer_Internalname ;
      private String lblTrlistaactividad_fechafin_var_lefttext_Internalname ;
      private String lblTrlistaactividad_fechafin_var_lefttext_Jsonclick ;
      private String edtavTrlistaactividad_fechafin_Internalname ;
      private String edtavTrlistaactividad_fechafin_Jsonclick ;
      private String divTable_container_trlistaactividad_estado_Internalname ;
      private String divTable_container_trlistaactividad_estadofieldcontainer_Internalname ;
      private String lblTrlistaactividad_estado_var_lefttext_Internalname ;
      private String lblTrlistaactividad_estado_var_lefttext_Jsonclick ;
      private String cmbavTrlistaactividad_estado_Internalname ;
      private String cmbavTrlistaactividad_estado_Jsonclick ;
      private String divResponsivetable_containernode_actions_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavConfirmmessage_Internalname ;
      private String AV12ConfirmMessage ;
      private String scmdbuf ;
      private String tblTableconditionalconfirm_Internalname ;
      private String sStyleString ;
      private String tblSection_condconf_dialog_Internalname ;
      private String tblSection_condconf_dialog_inner_Internalname ;
      private String edtavConfirmmessage_Jsonclick ;
      private String tblConfirm_hidden_actionstable_Internalname ;
      private String bttI_buttonconfirmyes_Internalname ;
      private String bttI_buttonconfirmyes_Jsonclick ;
      private String bttI_buttonconfirmno_Internalname ;
      private String bttI_buttonconfirmno_Jsonclick ;
      private String tblActionscontainertableleft_actions_Internalname ;
      private String bttConfirmar_Internalname ;
      private String bttConfirmar_Jsonclick ;
      private DateTime A58TrListaActividad_FechaInicio ;
      private DateTime A59TrListaActividad_FechaFin ;
      private DateTime AV18TrListaActividad_FechaInicio ;
      private DateTime AV19TrListaActividad_FechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13ConfirmationRequired ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n56TrListaActividad_Nombre ;
      private bool n57TrListaActividad_Descripcion ;
      private bool n58TrListaActividad_FechaInicio ;
      private bool n59TrListaActividad_FechaFin ;
      private bool n62TrListaActividad_Estado ;
      private bool returnInSub ;
      private String A57TrListaActividad_Descripcion ;
      private String AV17TrListaActividad_Descripcion ;
      private Guid AV15TrListaActividad_ID ;
      private Guid wcpOAV15TrListaActividad_ID ;
      private Guid A55TrListaActividad_ID ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTrlistaactividad_estado ;
      private IDataStoreProvider pr_default ;
      private long[] H002F2_A26TrActividades_ID ;
      private Guid[] H002F2_A55TrListaActividad_ID ;
      private String[] H002F2_A56TrListaActividad_Nombre ;
      private bool[] H002F2_n56TrListaActividad_Nombre ;
      private String[] H002F2_A57TrListaActividad_Descripcion ;
      private bool[] H002F2_n57TrListaActividad_Descripcion ;
      private DateTime[] H002F2_A58TrListaActividad_FechaInicio ;
      private bool[] H002F2_n58TrListaActividad_FechaInicio ;
      private DateTime[] H002F2_A59TrListaActividad_FechaFin ;
      private bool[] H002F2_n59TrListaActividad_FechaFin ;
      private short[] H002F2_A62TrListaActividad_Estado ;
      private bool[] H002F2_n62TrListaActividad_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtGestionActividades_SDT AV22GestionActividades_SDT ;
   }

   public class wpactualizarlistaactividad__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002F2 ;
          prmH002F2 = new Object[] {
          new Object[] {"@AV21TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV15TrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H002F2", "SELECT [TrActividades_ID], [TrListaActividad_ID], [TrListaActividad_Nombre], [TrListaActividad_Descripcion], [TrListaActividad_FechaInicio], [TrListaActividad_FechaFin], [TrListaActividad_Estado] FROM TABLERO.[TrActividadesLevel1] WHERE [TrActividades_ID] = @AV21TrActividades_ID and [TrListaActividad_ID] = @AV15TrListaActividad_ID ORDER BY [TrActividades_ID], [TrListaActividad_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002F2,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2) ;
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
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (Guid)parms[1]);
                return;
       }
    }

 }

}
