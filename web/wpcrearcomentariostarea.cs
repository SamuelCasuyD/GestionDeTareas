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
   public class wpcrearcomentariostarea : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpcrearcomentariostarea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public wpcrearcomentariostarea( IGxContext context )
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
         this.AV20TrGestionTareas_ID = aP0_TrGestionTareas_ID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTrtareacomentarios_estado = new GXCombobox();
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
               AV20TrGestionTareas_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV20TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV20TrGestionTareas_ID), 13, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
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
         PA292( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START292( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2022102021351755", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpcrearcomentariostarea.aspx") + "?" + UrlEncode("" +AV20TrGestionTareas_ID)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGESTIONTAREAS_SDT", GetSecureSignedToken( "", AV19GestionTareas_SDT, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vCONFIRMATIONSUBID", StringUtil.RTrim( AV14ConfirmationSubId));
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRCOMENTARIOTAREA_SDT", AV21TrComentarioTarea_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRCOMENTARIOTAREA_SDT", AV21TrComentarioTarea_SDT);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONTAREAS_SDT", AV19GestionTareas_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONTAREAS_SDT", AV19GestionTareas_SDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vGESTIONTAREAS_SDT", GetSecureSignedToken( "", AV19GestionTareas_SDT, context));
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
            WE292( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT292( ) ;
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
         return formatLink("wpcrearcomentariostarea.aspx") + "?" + UrlEncode("" +AV20TrGestionTareas_ID) ;
      }

      public override String GetPgmname( )
      {
         return "WpCrearComentariosTarea" ;
      }

      public override String GetPgmdesc( )
      {
         return "Wp Crear Comentarios Tarea" ;
      }

      protected void WB290( )
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, "Ingresar los datos requeridos", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_WpCrearComentariosTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trtareacomentarios_id_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavTrtareacomentarios_id_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavTrtareacomentarios_id_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrtareacomentarios_id_Internalname, "Tarea Comentarios_ID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrtareacomentarios_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15TrTareaComentarios_ID), 13, 0, ".", "")), ((edtavTrtareacomentarios_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15TrTareaComentarios_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV15TrTareaComentarios_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrtareacomentarios_id_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavTrtareacomentarios_id_Visible, edtavTrtareacomentarios_id_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpCrearComentariosTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trtareacomentarios_idtarea_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavTrtareacomentarios_idtarea_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavTrtareacomentarios_idtarea_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrtareacomentarios_idtarea_Internalname, "Tarea Comentarios_IDTarea", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrtareacomentarios_idtarea_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16TrTareaComentarios_IDTarea), 13, 0, ".", "")), ((edtavTrtareacomentarios_idtarea_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16TrTareaComentarios_IDTarea), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV16TrTareaComentarios_IDTarea), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrtareacomentarios_idtarea_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavTrtareacomentarios_idtarea_Visible, edtavTrtareacomentarios_idtarea_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WpCrearComentariosTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trtareacomentarios_descripcion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trtareacomentarios_descripcionfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrtareacomentarios_descripcion_var_lefttext_Internalname, "Comentario  : ", "", "", lblTrtareacomentarios_descripcion_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpCrearComentariosTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTrtareacomentarios_descripcion_Internalname, AV17TrTareaComentarios_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtavTrtareacomentarios_descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WpCrearComentariosTarea.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_trtareacomentarios_estado_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_trtareacomentarios_estadofieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTrtareacomentarios_estado_var_lefttext_Internalname, "Estado : ", "", "", lblTrtareacomentarios_estado_var_lefttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, "HLP_WpCrearComentariosTarea.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTrtareacomentarios_estado, cmbavTrtareacomentarios_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrTareaComentarios_Estado), 4, 0)), 1, cmbavTrtareacomentarios_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTrtareacomentarios_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, "HLP_WpCrearComentariosTarea.htm");
            cmbavTrtareacomentarios_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrTareaComentarios_Estado), 4, 0));
            AssignProp("", false, cmbavTrtareacomentarios_estado_Internalname, "Values", (String)(cmbavTrtareacomentarios_estado.ToJavascriptSource()), true);
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
            wb_table1_51_292( true) ;
         }
         else
         {
            wb_table1_51_292( false) ;
         }
         return  ;
      }

      protected void wb_table1_51_292e( bool wbgen )
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
            wb_table2_57_292( true) ;
         }
         else
         {
            wb_table2_57_292( false) ;
         }
         return  ;
      }

      protected void wb_table2_57_292e( bool wbgen )
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

      protected void START292( )
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
            Form.Meta.addItem("description", "Wp Crear Comentarios Tarea", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP290( ) ;
      }

      protected void WS292( )
      {
         START292( ) ;
         EVT292( ) ;
      }

      protected void EVT292( )
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
                              E11292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E12292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMYES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmYes' */
                              E13292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CREARCOMENTARIO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_CrearComentario' */
                              E14292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15292 ();
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

      protected void WE292( )
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

      protected void PA292( )
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
               GX_FocusControl = edtavTrtareacomentarios_id_Internalname;
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
         if ( cmbavTrtareacomentarios_estado.ItemCount > 0 )
         {
            AV18TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbavTrtareacomentarios_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrTareaComentarios_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV18TrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(AV18TrTareaComentarios_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTrtareacomentarios_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrTareaComentarios_Estado), 4, 0));
            AssignProp("", false, cmbavTrtareacomentarios_estado_Internalname, "Values", cmbavTrtareacomentarios_estado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF292( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void RF292( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E12292 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15292 ();
            WB290( ) ;
         }
      }

      protected void send_integrity_lvl_hashes292( )
      {
         GxWebStd.gx_hidden_field( context, "vTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20TrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGESTIONTAREAS_SDT", AV19GestionTareas_SDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGESTIONTAREAS_SDT", AV19GestionTareas_SDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vGESTIONTAREAS_SDT", GetSecureSignedToken( "", AV19GestionTareas_SDT, context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavConfirmmessage_Enabled = 0;
         AssignProp("", false, edtavConfirmmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConfirmmessage_Enabled), 5, 0), true);
      }

      protected void STRUP290( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11292 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV14ConfirmationSubId = cgiGet( "vCONFIRMATIONSUBID");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTrtareacomentarios_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTrtareacomentarios_id_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRTAREACOMENTARIOS_ID");
               GX_FocusControl = edtavTrtareacomentarios_id_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15TrTareaComentarios_ID = 0;
               AssignAttri("", false, "AV15TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(AV15TrTareaComentarios_ID), 13, 0));
            }
            else
            {
               AV15TrTareaComentarios_ID = (long)(context.localUtil.CToN( cgiGet( edtavTrtareacomentarios_id_Internalname), ".", ","));
               AssignAttri("", false, "AV15TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(AV15TrTareaComentarios_ID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTrtareacomentarios_idtarea_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTrtareacomentarios_idtarea_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRTAREACOMENTARIOS_IDTAREA");
               GX_FocusControl = edtavTrtareacomentarios_idtarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16TrTareaComentarios_IDTarea = 0;
               AssignAttri("", false, "AV16TrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(AV16TrTareaComentarios_IDTarea), 13, 0));
            }
            else
            {
               AV16TrTareaComentarios_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtavTrtareacomentarios_idtarea_Internalname), ".", ","));
               AssignAttri("", false, "AV16TrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(AV16TrTareaComentarios_IDTarea), 13, 0));
            }
            AV17TrTareaComentarios_Descripcion = cgiGet( edtavTrtareacomentarios_descripcion_Internalname);
            AssignAttri("", false, "AV17TrTareaComentarios_Descripcion", AV17TrTareaComentarios_Descripcion);
            cmbavTrtareacomentarios_estado.CurrentValue = cgiGet( cmbavTrtareacomentarios_estado_Internalname);
            AV18TrTareaComentarios_Estado = (short)(NumberUtil.Val( cgiGet( cmbavTrtareacomentarios_estado_Internalname), "."));
            AssignAttri("", false, "AV18TrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(AV18TrTareaComentarios_Estado), 4, 0));
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
         E11292 ();
         if (returnInSub) return;
      }

      protected void E11292( )
      {
         /* Start Routine */
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
      }

      protected void E12292( )
      {
         /* Refresh Routine */
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         AV13ConfirmationRequired = false;
         AssignAttri("", false, "AV13ConfirmationRequired", AV13ConfirmationRequired);
         edtavTrtareacomentarios_id_Visible = 0;
         AssignProp("", false, edtavTrtareacomentarios_id_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrtareacomentarios_id_Visible), 5, 0), true);
         edtavTrtareacomentarios_idtarea_Visible = 0;
         AssignProp("", false, edtavTrtareacomentarios_idtarea_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrtareacomentarios_idtarea_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E13292( )
      {
         /* 'ConfirmYes' Routine */
         tblTableconditionalconfirm_Visible = 0;
         AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV14ConfirmationSubId, "'U_CrearComentario'") == 0 )
         {
            /* Execute user subroutine: 'U_CREARCOMENTARIO' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21TrComentarioTarea_SDT", AV21TrComentarioTarea_SDT);
      }

      protected void S152( )
      {
         /* 'U_CONFIRMATIONREQUIRED(CREARCOMENTARIO)' Routine */
         AV13ConfirmationRequired = true;
         AssignAttri("", false, "AV13ConfirmationRequired", AV13ConfirmationRequired);
      }

      protected void E14292( )
      {
         /* 'E_CrearComentario' Routine */
         AV12ConfirmMessage = "Are you sure?";
         AssignAttri("", false, "AV12ConfirmMessage", AV12ConfirmMessage);
         /* Execute user subroutine: 'U_CONFIRMATIONREQUIRED(CREARCOMENTARIO)' */
         S152 ();
         if (returnInSub) return;
         if ( AV13ConfirmationRequired )
         {
            AV14ConfirmationSubId = "'U_CrearComentario'";
            AssignAttri("", false, "AV14ConfirmationSubId", AV14ConfirmationSubId);
            tblTableconditionalconfirm_Visible = 1;
            AssignProp("", false, tblTableconditionalconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableconditionalconfirm_Visible), 5, 0), true);
         }
         else
         {
            /* Execute user subroutine: 'U_CREARCOMENTARIO' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21TrComentarioTarea_SDT", AV21TrComentarioTarea_SDT);
      }

      protected void S142( )
      {
         /* 'U_CREARCOMENTARIO' Routine */
         AV21TrComentarioTarea_SDT.gxTpr_Trtareacomentarios_idtarea = AV20TrGestionTareas_ID;
         AV21TrComentarioTarea_SDT.gxTpr_Trtareacomentarios_descripcion = AV17TrTareaComentarios_Descripcion;
         AV21TrComentarioTarea_SDT.gxTpr_Trtareacomentarios_estado = AV18TrTareaComentarios_Estado;
         new prgestionesdetareas(context ).execute(  AV19GestionTareas_SDT,  AV21TrComentarioTarea_SDT,  "CIN") ;
         context.DoAjaxRefresh();
      }

      protected void nextLoad( )
      {
      }

      protected void E15292( )
      {
         /* Load Routine */
      }

      protected void wb_table2_57_292( bool wbgen )
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
            wb_table3_60_292( true) ;
         }
         else
         {
            wb_table3_60_292( false) ;
         }
         return  ;
      }

      protected void wb_table3_60_292e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_57_292e( true) ;
         }
         else
         {
            wb_table2_57_292e( false) ;
         }
      }

      protected void wb_table3_60_292( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSection_condconf_dialog_Internalname, tblSection_condconf_dialog_Internalname, "", "Section_CondConf_Dialog", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table4_63_292( true) ;
         }
         else
         {
            wb_table4_63_292( false) ;
         }
         return  ;
      }

      protected void wb_table4_63_292e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_60_292e( true) ;
         }
         else
         {
            wb_table3_60_292e( false) ;
         }
      }

      protected void wb_table4_63_292( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfirmmessage_Internalname, StringUtil.RTrim( AV12ConfirmMessage), StringUtil.RTrim( context.localUtil.Format( AV12ConfirmMessage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfirmmessage_Jsonclick, 0, "Attribute_ConditionalConfirm", "", "", "", "", 1, edtavConfirmmessage_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WpCrearComentariosTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_70_292( true) ;
         }
         else
         {
            wb_table5_70_292( false) ;
         }
         return  ;
      }

      protected void wb_table5_70_292e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_63_292e( true) ;
         }
         else
         {
            wb_table4_63_292e( false) ;
         }
      }

      protected void wb_table5_70_292( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblConfirm_hidden_actionstable_Internalname, tblConfirm_hidden_actionstable_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction_Confirm";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmyes_Internalname, "", "Ok", bttI_buttonconfirmyes_Jsonclick, 5, "Ok", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMYES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpCrearComentariosTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttI_buttonconfirmno_Internalname, "", "Cancel", bttI_buttonconfirmno_Jsonclick, 7, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16291_client"+"'", TempTags, "", 2, "HLP_WpCrearComentariosTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_70_292e( true) ;
         }
         else
         {
            wb_table5_70_292e( false) ;
         }
      }

      protected void wb_table1_51_292( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCrearcomentario_Internalname, "", "Crear Comentario", bttCrearcomentario_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CREARCOMENTARIO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpCrearComentariosTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_51_292e( true) ;
         }
         else
         {
            wb_table1_51_292e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV20TrGestionTareas_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV20TrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV20TrGestionTareas_ID), 13, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
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
         PA292( ) ;
         WS292( ) ;
         WE292( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?2022102021351780", true, true);
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
         context.AddJavascriptSource("wpcrearcomentariostarea.js", "?2022102021351780", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavTrtareacomentarios_estado.Name = "vTRTAREACOMENTARIOS_ESTADO";
         cmbavTrtareacomentarios_estado.WebTags = "";
         cmbavTrtareacomentarios_estado.addItem("1", "Activo", 0);
         cmbavTrtareacomentarios_estado.addItem("2", "Inactivo", 0);
         cmbavTrtareacomentarios_estado.addItem("3", "Eliminado", 0);
         if ( cmbavTrtareacomentarios_estado.ItemCount > 0 )
         {
            AV18TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbavTrtareacomentarios_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TrTareaComentarios_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV18TrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(AV18TrTareaComentarios_Estado), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavTrtareacomentarios_id_Internalname = "vTRTAREACOMENTARIOS_ID";
         divTable_container_trtareacomentarios_id_Internalname = "TABLE_CONTAINER_TRTAREACOMENTARIOS_ID";
         edtavTrtareacomentarios_idtarea_Internalname = "vTRTAREACOMENTARIOS_IDTAREA";
         divTable_container_trtareacomentarios_idtarea_Internalname = "TABLE_CONTAINER_TRTAREACOMENTARIOS_IDTAREA";
         lblTrtareacomentarios_descripcion_var_lefttext_Internalname = "TRTAREACOMENTARIOS_DESCRIPCION_VAR_LEFTTEXT";
         edtavTrtareacomentarios_descripcion_Internalname = "vTRTAREACOMENTARIOS_DESCRIPCION";
         divTable_container_trtareacomentarios_descripcionfieldcontainer_Internalname = "TABLE_CONTAINER_TRTAREACOMENTARIOS_DESCRIPCIONFIELDCONTAINER";
         divTable_container_trtareacomentarios_descripcion_Internalname = "TABLE_CONTAINER_TRTAREACOMENTARIOS_DESCRIPCION";
         lblTrtareacomentarios_estado_var_lefttext_Internalname = "TRTAREACOMENTARIOS_ESTADO_VAR_LEFTTEXT";
         cmbavTrtareacomentarios_estado_Internalname = "vTRTAREACOMENTARIOS_ESTADO";
         divTable_container_trtareacomentarios_estadofieldcontainer_Internalname = "TABLE_CONTAINER_TRTAREACOMENTARIOS_ESTADOFIELDCONTAINER";
         divTable_container_trtareacomentarios_estado_Internalname = "TABLE_CONTAINER_TRTAREACOMENTARIOS_ESTADO";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divMaingroupresponsivetable_group_Internalname = "MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = "GROUP";
         bttCrearcomentario_Internalname = "CREARCOMENTARIO";
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
         cmbavTrtareacomentarios_estado_Jsonclick = "";
         cmbavTrtareacomentarios_estado.Enabled = 1;
         edtavTrtareacomentarios_descripcion_Enabled = 1;
         edtavTrtareacomentarios_idtarea_Jsonclick = "";
         edtavTrtareacomentarios_idtarea_Enabled = 1;
         edtavTrtareacomentarios_idtarea_Visible = 1;
         edtavTrtareacomentarios_id_Jsonclick = "";
         edtavTrtareacomentarios_id_Enabled = 1;
         edtavTrtareacomentarios_id_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Wp Crear Comentarios Tarea";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV20TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV19GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV13ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'edtavTrtareacomentarios_id_Visible',ctrl:'vTRTAREACOMENTARIOS_ID',prop:'Visible'},{av:'edtavTrtareacomentarios_idtarea_Visible',ctrl:'vTRTAREACOMENTARIOS_IDTAREA',prop:'Visible'}]}");
         setEventMetadata("'CONFIRMNO'","{handler:'E16291',iparms:[]");
         setEventMetadata("'CONFIRMNO'",",oparms:[{av:'AV14ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'}]}");
         setEventMetadata("'CONFIRMYES'","{handler:'E13292',iparms:[{av:'AV14ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'AV20TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV21TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:''},{av:'AV17TrTareaComentarios_Descripcion',fld:'vTRTAREACOMENTARIOS_DESCRIPCION',pic:''},{av:'cmbavTrtareacomentarios_estado'},{av:'AV18TrTareaComentarios_Estado',fld:'vTRTAREACOMENTARIOS_ESTADO',pic:'ZZZ9'},{av:'AV19GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:'',hsh:true}]");
         setEventMetadata("'CONFIRMYES'",",oparms:[{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV21TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:''}]}");
         setEventMetadata("'E_CREARCOMENTARIO'","{handler:'E14292',iparms:[{av:'AV13ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV20TrGestionTareas_ID',fld:'vTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true},{av:'AV21TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:''},{av:'AV17TrTareaComentarios_Descripcion',fld:'vTRTAREACOMENTARIOS_DESCRIPCION',pic:''},{av:'cmbavTrtareacomentarios_estado'},{av:'AV18TrTareaComentarios_Estado',fld:'vTRTAREACOMENTARIOS_ESTADO',pic:'ZZZ9'},{av:'AV19GestionTareas_SDT',fld:'vGESTIONTAREAS_SDT',pic:'',hsh:true}]");
         setEventMetadata("'E_CREARCOMENTARIO'",",oparms:[{av:'AV12ConfirmMessage',fld:'vCONFIRMMESSAGE',pic:''},{av:'AV14ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'tblTableconditionalconfirm_Visible',ctrl:'TABLECONDITIONALCONFIRM',prop:'Visible'},{av:'AV13ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV21TrComentarioTarea_SDT',fld:'vTRCOMENTARIOTAREA_SDT',pic:''}]}");
         setEventMetadata("VALIDV_TRTAREACOMENTARIOS_ESTADO","{handler:'Validv_Trtareacomentarios_estado',iparms:[]");
         setEventMetadata("VALIDV_TRTAREACOMENTARIOS_ESTADO",",oparms:[]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV19GestionTareas_SDT = new SdtGestionTareas_SDT(context);
         GXKey = "";
         AV14ConfirmationSubId = "";
         AV21TrComentarioTarea_SDT = new SdtTrComentarioTarea_SDT(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblTrtareacomentarios_descripcion_var_lefttext_Jsonclick = "";
         AV17TrTareaComentarios_Descripcion = "";
         lblTrtareacomentarios_estado_var_lefttext_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12ConfirmMessage = "";
         sStyleString = "";
         bttI_buttonconfirmyes_Jsonclick = "";
         bttI_buttonconfirmno_Jsonclick = "";
         bttCrearcomentario_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavConfirmmessage_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV18TrTareaComentarios_Estado ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTrtareacomentarios_id_Visible ;
      private int edtavTrtareacomentarios_id_Enabled ;
      private int edtavTrtareacomentarios_idtarea_Visible ;
      private int edtavTrtareacomentarios_idtarea_Enabled ;
      private int edtavTrtareacomentarios_descripcion_Enabled ;
      private int edtavConfirmmessage_Enabled ;
      private int tblTableconditionalconfirm_Visible ;
      private int idxLst ;
      private long AV20TrGestionTareas_ID ;
      private long wcpOAV20TrGestionTareas_ID ;
      private long AV15TrTareaComentarios_ID ;
      private long AV16TrTareaComentarios_IDTarea ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String AV14ConfirmationSubId ;
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
      private String divTable_container_trtareacomentarios_id_Internalname ;
      private String edtavTrtareacomentarios_id_Internalname ;
      private String TempTags ;
      private String edtavTrtareacomentarios_id_Jsonclick ;
      private String divTable_container_trtareacomentarios_idtarea_Internalname ;
      private String edtavTrtareacomentarios_idtarea_Internalname ;
      private String edtavTrtareacomentarios_idtarea_Jsonclick ;
      private String divTable_container_trtareacomentarios_descripcion_Internalname ;
      private String divTable_container_trtareacomentarios_descripcionfieldcontainer_Internalname ;
      private String lblTrtareacomentarios_descripcion_var_lefttext_Internalname ;
      private String lblTrtareacomentarios_descripcion_var_lefttext_Jsonclick ;
      private String edtavTrtareacomentarios_descripcion_Internalname ;
      private String divTable_container_trtareacomentarios_estado_Internalname ;
      private String divTable_container_trtareacomentarios_estadofieldcontainer_Internalname ;
      private String lblTrtareacomentarios_estado_var_lefttext_Internalname ;
      private String lblTrtareacomentarios_estado_var_lefttext_Jsonclick ;
      private String cmbavTrtareacomentarios_estado_Internalname ;
      private String cmbavTrtareacomentarios_estado_Jsonclick ;
      private String divResponsivetable_containernode_actions_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavConfirmmessage_Internalname ;
      private String AV12ConfirmMessage ;
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
      private String bttCrearcomentario_Internalname ;
      private String bttCrearcomentario_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13ConfirmationRequired ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV17TrTareaComentarios_Descripcion ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTrtareacomentarios_estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtGestionTareas_SDT AV19GestionTareas_SDT ;
      private SdtTrComentarioTarea_SDT AV21TrComentarioTarea_SDT ;
   }

}
